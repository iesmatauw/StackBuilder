#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using log4net;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;
using Sharp3D.Math.Core;

using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormEditBitmaps : Form
    {
        #region Data members
        private  BoxProperties _boxProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(FormEditBitmaps));
        private List<Pair<HalfAxis.HAxis, Texture>> _textures;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FormEditBitmaps()
        {
            InitializeComponent();
            // set default face
            cbFace.SelectedIndex = 0;
            // set horizontal angle
            trackBarHorizAngle.Value = 45;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Box properties
        /// </summary>
        public BoxProperties BoxProperties
        {
            get { return _boxProperties; }
            set { _boxProperties = value; }
        }
        #endregion

        #region Load / Closing
        private void FormEditBitmaps_Load(object sender, EventArgs e)
        {
            // windows settings
            if (null != Settings.Default.FormEditBitmapsPosition)
                Settings.Default.FormEditBitmapsPosition.Restore(this);
            DrawBox();
        }
        private void FormEditBitmaps_FormClosing(object sender, FormClosingEventArgs e)
        {
            // window position
            if (null == Settings.Default.FormEditBitmapsPosition)
                Settings.Default.FormEditBitmapsPosition = new WindowSettings();
            Settings.Default.FormEditBitmapsPosition.Record(this);
        }
        #endregion

        #region Draw box
        private void DrawBox()
        {
            try
            {
                // get horizontal angle
                double angle = trackBarHorizAngle.Value;
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(pictureBox.Size);
                graphics.CameraPosition = new Vector3D(
                    Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , 10000.0);
                graphics.Target = Vector3D.Zero;
                graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
                graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
                // draw
                BoxProperties boxProperties = new BoxProperties(null, _boxProperties.Length, _boxProperties.Width, _boxProperties.Height);
                boxProperties.SetAllColors(_boxProperties.Colors);
                boxProperties.TextureList = _textures;
                Box box = new Box(0, boxProperties);
                graphics.AddBox(box);
                graphics.Flush();
                // set to picture box
                pictureBox.Image = graphics.Bitmap;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Handlers
        private void onSelectedFaceChanged(object sender, EventArgs e)
        {
            FillBitmapControl(SelectedFace);
        }
        private void FillBitmapControl(HalfAxis.HAxis iFace)
        {
            List<Texture> listTexture = new List<Texture>();
            foreach (Pair<HalfAxis.HAxis, Texture> p in _textures)
                if (p.first == iFace)
                    listTexture.Add(p.second);
            listBoxTextures.SetTextureList(listTexture);
        }

        private void onHorizAngleChanged(object sender, EventArgs e)
        {
            DrawBox();
        }

        private void bnMoveUp_Click(object sender, EventArgs e)
        {
            DrawBox();
        }

        private void bnMoveDown_Click(object sender, EventArgs e)
        {
            DrawBox();
        }

        private void bnAdd_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openImageFileDialog.ShowDialog())
            {
                double faceLength = 0.0, faceWidth = 0.0; 
                foreach (string filePath in openImageFileDialog.FileNames)
                {
                    Bitmap bmp = new Bitmap(filePath);
                    Pair<HalfAxis.HAxis, Texture> faceTexturePair = new Pair<HalfAxis.HAxis, Texture>(SelectedFace, new Texture(bmp, Vector2D.Zero, new Vector2D(faceLength, faceWidth), 0.0));
                    _textures.Add(faceTexturePair);
                }
                FillBitmapControl(SelectedFace);
            }
        }
        private void bnRemove_Click(object sender, EventArgs e)
        {
            HalfAxis.HAxis currentAxis = SelectedFace;
            Texture currentTexture = SelectedTexture;
            _textures.RemoveAll(delegate(Pair<HalfAxis.HAxis, Texture> p) { return p.first == currentAxis && p.second == currentTexture; });
            // update bitmap control
            FillBitmapControl(SelectedFace);
        }
        #endregion

        #region Private properties (Helpers)
        private HalfAxis.HAxis SelectedFace
        {
            get
            {
                if (-1 == cbFace.SelectedIndex)
                    throw new Exception("No face selected");
                return (HalfAxis.HAxis)cbFace.SelectedIndex; 
            }
        }

        private Texture SelectedTexture
        {
            get
            { 
                // get ListBoxImageItem
                ListBoxImagesItem item = listBoxTextures.SelectedItem as ListBoxImagesItem;
                // sanity check
                if (null == item) return null;
                // return texture
                return item.Texture;
            }
        }
        #endregion
    }
}
