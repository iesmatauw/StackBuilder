#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Sharp3D.Math.Core;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    #region IDrawingContainer
    public interface IDrawingContainer
    {
        void Draw(Graphics3DControl ctrl, Graphics3D graphics);
    }
    #endregion

    #region Graphics3DControl
    public partial class Graphics3DControl : UserControl
    {
        #region Data members
        public double _angleHoriz = 45.0, _angleVert = 45.0;
        private IDrawingContainer _drawingContainer;
        private bool _isDrag = false;
        private Point _prevLocation;
        private bool _showToolBar = false;
        private const int _toolbarButtonOffset = 17;
        internal static Cursor _cursorRotate;
        static readonly ILog _log = LogManager.GetLogger(typeof(Graphics3DControl));
        #endregion

        #region Delegates
        public delegate void ButtonPressedHandler(int iIndex);
        #endregion

        #region Events
        public event ButtonPressedHandler ButtonPressed;
        #endregion

        #region Constructor
        public Graphics3DControl()
        {
            InitializeComponent();
            _drawingContainer = null;

            // double buffering
            SetDoubleBuffered();
            // toolbar event
            ButtonPressed += onButtonPressed;
        }
        #endregion

        #region Cursor / double buffering
        internal static Cursor CursorRotate
        {
            get
            {
                if (null == _cursorRotate)
                {
                    try
                    {
                        var buffer = Properties.Resource.ResourceManager.GetObject("rotate") as byte[];
                        using (var m = new MemoryStream(buffer))
                        { _cursorRotate = new Cursor(m); }
                    }
                    catch (Exception)
                    {
                        _cursorRotate = Cursors.Default;
                    }
                }
                return _cursorRotate;
            }
        } 

        private void SetDoubleBuffered()
        { 
            System.Reflection.PropertyInfo aProp =
                typeof(System.Windows.Forms.Control).GetProperty(
                    "DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);

            aProp.SetValue(this, true, null);        
        }
        #endregion

        #region Accessors
        public IDrawingContainer DrawingContainer
        {
            set { _drawingContainer = value; }            
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics3DForm graphics = new Graphics3DForm(this, e.Graphics);
            double angleHorizRad = _angleHoriz * Math.PI / 180.0;
            double angleVertRad = _angleVert * Math.PI / 180.0;
            double cameraDistance = 10000.0;
            graphics.CameraPosition = new Vector3D(
                cameraDistance * Math.Cos(angleHorizRad) * Math.Cos(angleVertRad)
                , cameraDistance * Math.Sin(angleHorizRad) * Math.Cos(angleVertRad)
                , cameraDistance * Math.Sin(angleVertRad));
            // set camera target
            graphics.Target = Vector3D.Zero;
            // set viewport (not actually needed)
            graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
            // show images
            graphics.ShowTextures = true;
            if (null != _drawingContainer)
            {
                try
                {
                    _drawingContainer.Draw(this, graphics);
                }
                catch (Exception ex)
                {
                    e.Graphics.DrawString(ex.Message
                        , new Font("Arial", 12)
                        , new SolidBrush(Color.Red)
                        , new Point(0, 0)
                        , StringFormat.GenericDefault);
                    _log.Error(ex.Message); 
                }
            }
            graphics.Flush();

            // draw toolbar
            if (ShowToolBar)
                DrawToolBar(e.Graphics);
        }
        #endregion

        #region Toolbar
        public bool ShowHideToolBar(Point pt)
        {
            return -1 != ToolbarButtonIndex(pt);
        }

        public int ToolbarButtonIndex(Point pt)
        {
            for (int i = 0; i < 9; ++i)
            {
                Rectangle rect = new Rectangle(i * _toolbarButtonOffset, 0, _toolbarButtonOffset, 16);
                if (rect.Contains(pt))
                    return i;
            }
            return -1;
        }
        public bool ShowToolBar
        {
            get { return _showToolBar; }
        }

        void DrawToolBar(System.Drawing.Graphics g)
        { 
            int offsetIcon = 0;
            g.DrawImage(Properties.Resource.View_1, new Point(offsetIcon, 1));
            g.DrawImage(Properties.Resource.View_2, new Point(offsetIcon += _toolbarButtonOffset, 1));
            g.DrawImage(Properties.Resource.View_3, new Point(offsetIcon += _toolbarButtonOffset, 1));
            g.DrawImage(Properties.Resource.View_4, new Point(offsetIcon += _toolbarButtonOffset, 1));
            g.DrawImage(Properties.Resource.View_Top, new Point(offsetIcon += _toolbarButtonOffset, 1));
            g.DrawImage(Properties.Resource.View0, new Point(offsetIcon += _toolbarButtonOffset, 1));
            g.DrawImage(Properties.Resource.View90, new Point(offsetIcon += _toolbarButtonOffset, 1));
            g.DrawImage(Properties.Resource.View180, new Point(offsetIcon += _toolbarButtonOffset, 1));
            g.DrawImage(Properties.Resource.View270, new Point(offsetIcon += _toolbarButtonOffset, 1));        
        }
        void onButtonPressed(int iIndex)
        {
            switch (iIndex)
            {
                case 0: _angleHoriz = 0.0; _angleVert = 0.0; break;
                case 1: _angleHoriz = 90.0; _angleVert = 0.0; break;
                case 2: _angleHoriz = 180.0; _angleVert = 0.0; break;
                case 3: _angleHoriz = 270.0; _angleVert = 0.0; break;
                case 4: _angleHoriz = 0.0; _angleVert = 90.0; break;
                case 5: _angleHoriz = 45.0 + 0.0; _angleVert = 45.0; break;
                case 6: _angleHoriz = 45.0 + 90.0; _angleVert = 45.0; break;
                case 7: _angleHoriz = 45.0 + 180.0; _angleVert = 45.0; break;
                case 8: _angleHoriz = 45.0 + 270.0; _angleVert = 45.0; break;
                default: break;
            }
            Invalidate();
        }
        #endregion

        #region Mouse event handlers
        private void onMouseMove(object sender, MouseEventArgs e)
        {
            // not dragging ?
            if (!_isDrag)
            {
                bool showToolBar = ShowHideToolBar(e.Location);
                if (_showToolBar != showToolBar)
                {
                    _showToolBar = showToolBar;
                    Invalidate();
                }
            }
            else
            {

                double angleXDiff = -(e.Location.X - _prevLocation.X) * 360.0 / Size.Width;
                double angleYDiff = (e.Location.Y - _prevLocation.Y) * 90.0 / Size.Height;
                _prevLocation = e.Location;

                if (_angleHoriz + angleXDiff < 0.0)
                    _angleHoriz += angleXDiff + 360.0;
                else if (_angleHoriz + angleXDiff > 360.0)
                    _angleHoriz += angleXDiff - 360.0;
                else
                    _angleHoriz += angleXDiff;

                if (_angleVert + angleYDiff < 0.0)
                    _angleVert = 0.0;
                else if (_angleVert + angleYDiff >= 90.0)
                    _angleVert = 90.0;
                else
                    _angleVert += angleYDiff;

                Invalidate();
            }
        }

        private void onMouseDown(object sender, MouseEventArgs e)
        {
            // clicking toolbar ?
            if (!_isDrag)
            { 
                int tbBIndex = ToolbarButtonIndex(e.Location);
                if ((-1 != tbBIndex) && (null != ButtonPressed))
                {
                    ButtonPressed(tbBIndex);
                    return;
                }
            }
            // switch to drag mode
            if (MouseButtons.Left == e.Button)
            {
                _isDrag = true;
                _prevLocation = e.Location;
            }
            // set rotate cursor
            Cursor.Current = _isDrag ? CursorRotate : Cursors.Default;
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                _isDrag = false;
                _prevLocation = e.Location;
                // back to default cursor
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region Event handlers
        private void onResize(object sender, EventArgs e)
        {
            Invalidate();
        }
        #endregion
    }
    #endregion
}
