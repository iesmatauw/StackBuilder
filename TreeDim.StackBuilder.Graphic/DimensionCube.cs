#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public class DimensionCube
    {
        #region Data members
        private Vector3D _position = Vector3D.Zero;
        private double[] _dim = new double[3];
        private bool[] _showArrow = new bool[3];
        private double offsetPerc = 0.2;
        private Vector3D[] _pts = new Vector3D[8];
        private Color _color = Color.Black;
        private float _fontSize = 10.0F;
        private bool _above = false;
        #endregion

        #region Constructors
        public DimensionCube(double length, double width, double height)
        {
            _dim[0] = length; _dim[1] = width; _dim[2] = height;
            for (int i = 0; i < 3; ++i) _showArrow[i] = true;
            BuildPoints();
        }
        public DimensionCube(Vector3D position, double length, double width, double height, Color color, bool above)
        {
            _position = position;
            _dim[0] = length; _dim[1] = width; _dim[2] = height;
            _color = color;
            _above = above;
            for (int i = 0; i < 3; ++i) _showArrow[i] = true;
            BuildPoints();
        }
        public DimensionCube(Basics.BBox3D bbox, Color color, bool above)
        {
            _position = bbox.PtMin;
            _dim[0] = bbox.Length; _dim[1] = bbox.Width; _dim[2] = bbox.Height;
            _color = color;
            _above = above;
            for (int i = 0; i < 3; ++i) _showArrow[i] = true;
            BuildPoints();
        }
        #endregion

        #region Public properties
        public bool[] ShowArrow
        {
            get { return _showArrow; }
            set { _showArrow = value; }
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

        public Vector3D Position
        {
            get { return _position; }
            set { _position = value; }
        }
        #endregion

        #region Drawing
        public void Draw(Graphics3D graphics)
        {
            int[] arrow0 = null;
            int[] arrow1 = null;
            int[] arrow2 = null;
            ArrowPoints(graphics, out arrow0, out arrow1, out arrow2);

            DrawArrow(arrow0, graphics);
            DrawArrow(arrow1, graphics);
            DrawArrow(arrow2, graphics);
        }

        public Vector3D[] DrawingPoints(Graphics3D graphics)
        {
            int[] arrow0 = null;
            int[] arrow1 = null;
            int[] arrow2 = null;
            ArrowPoints(graphics, out arrow0, out arrow1, out arrow2);

            const double exageration = 1.2;

            Vector3D[] pts = new Vector3D[6];
            pts[0] = _pts[arrow0[0]] + (_pts[arrow0[0]] - _pts[arrow0[2]]) * offsetPerc * exageration;
            pts[1] = _pts[arrow0[1]] + (_pts[arrow0[1]] - _pts[arrow0[3]]) * offsetPerc * exageration;
            pts[2] = _pts[arrow1[0]] + (_pts[arrow1[0]] - _pts[arrow1[2]]) * offsetPerc * exageration;
            pts[3] = _pts[arrow1[1]] + (_pts[arrow1[1]] - _pts[arrow1[3]]) * offsetPerc * exageration;
            pts[4] = _pts[arrow2[0]] + (_pts[arrow2[0]] - _pts[arrow2[2]]) * offsetPerc * exageration;
            pts[5] = _pts[arrow2[1]] + (_pts[arrow2[1]] - _pts[arrow2[3]]) * offsetPerc * exageration;
            return pts;
        }
        #endregion

        #region Transformation
        public static DimensionCube Transform(DimensionCube dimCube, Transform3D transform)
        {
            Vector3D pos = transform.transform(dimCube._position);
            Vector3D dim = transform.transformRot(new Vector3D(dimCube._dim) );
            if (dim.X < 0) { pos.X += dim.X; dim.X = -dim.X; }
            if (dim.Y < 0) { pos.Y += dim.Y; dim.Y = -dim.Y; }
            if (dim.Z < 0) { pos.Z += dim.Z; dim.Z = -dim.Z; }
            return new DimensionCube(pos, dim.X, dim.Y, dim.Z, dimCube.Color, dimCube._above);
        }
        #endregion

        #region Helpers
        private void BuildPoints()
        {
            _pts[0] = _position;
            _pts[1] = _position + _dim[0] * Vector3D.XAxis;
            _pts[2] = _position + _dim[0] * Vector3D.XAxis + _dim[1] * Vector3D.YAxis;
            _pts[3] = _position + _dim[1] * Vector3D.YAxis;
            _pts[4] = _position + _dim[2] * Vector3D.ZAxis;
            _pts[5] = _position + _dim[0] * Vector3D.XAxis + _dim[2] * Vector3D.ZAxis;
            _pts[6] = _position + _dim[0] * Vector3D.XAxis + _dim[1] * Vector3D.YAxis + _dim[2] * Vector3D.ZAxis;
            _pts[7] = _position + _dim[1] * Vector3D.YAxis + _dim[2] * Vector3D.ZAxis; 
        }

        private void ArrowPoints(Graphics3D graphics, out int[] arrow0, out int[] arrow1, out int[] arrow2)
        {
            Vector3D viewDir = graphics.ViewDirection;
            arrow0 = null;
            arrow1 = null;
            arrow2 = null;

            if (!_above)
            {
                if (viewDir.X < 0.0 && viewDir.Y >= 0.0)
                {
                    arrow0 = new int[4] { 0, 4, 1, 5 };
                    arrow1 = new int[4] { 0, 1, 3, 2 };
                    arrow2 = new int[4] { 1, 2, 0, 3 };
                }
                else if (viewDir.X < 0.0 && viewDir.Y < 0.0)
                {
                    arrow0 = new int[4] { 1, 5, 2, 6 };
                    arrow1 = new int[4] { 1, 2, 0, 3 };
                    arrow2 = new int[4] { 2, 3, 1, 0 };
                }
                else if (viewDir.X >= 0.0 && viewDir.Y < 0.0)
                {
                    arrow0 = new int[4] { 2, 6, 3, 7 };
                    arrow1 = new int[4] { 2, 3, 1, 0 };
                    arrow2 = new int[4] { 3, 0, 2, 1 };
                }
                else if (viewDir.X >= 0.0 && viewDir.Y >= 0.0)
                {
                    arrow0 = new int[4] { 3, 7, 0, 4 };
                    arrow1 = new int[4] { 3, 0, 2, 1 };
                    arrow2 = new int[4] { 0, 1, 3, 2 };
                }
            }
            else
            {
                if (viewDir.X < 0.0 && viewDir.Y >= 0.0)
                {
                    arrow0 = new int[4] { 2, 6, 3, 7 };
                    arrow1 = new int[4] { 7, 6, 4, 5 };
                    arrow2 = new int[4] { 4, 7, 5, 6 };
                }
                else if (viewDir.X < 0.0 && viewDir.Y < 0.0)
                {
                    arrow0 = new int[4] { 3, 7, 0, 4 };
                    arrow1 = new int[4] { 4, 7, 5, 6 };
                    arrow2 = new int[4] { 4, 5, 7, 6 };
                }
                else if (viewDir.X >= 0.0 && viewDir.Y < 0.0)
                {
                    arrow0 = new int[4] { 4, 0, 5, 1 };
                    arrow1 = new int[4] { 4, 5, 7, 6 };
                    arrow2 = new int[4] { 6, 5, 7, 4 };
                }
                else if (viewDir.X >= 0.0 && viewDir.Y >= 0.0)
                {
                    arrow0 = new int[4] { 1, 5, 2, 6 };
                    arrow1 = new int[4] { 5, 6, 4, 7 };
                    arrow2 = new int[4] { 7, 6, 4, 5 };
                }
            }
        }

        private void DrawArrow(int[] arrow, Graphics3D graphics)
        {
            Vector3D pt0 = _pts[arrow[0]];
            Vector3D pt0_ = pt0 + (pt0 - _pts[arrow[2]]) * offsetPerc;
            Vector3D pt00_ = pt0 + (pt0 - _pts[arrow[2]]) * offsetPerc * 1.1;

            Vector3D pt1 = _pts[arrow[1]];
            Vector3D pt1_ = pt1 + (pt1 - _pts[arrow[3]]) * offsetPerc;
            Vector3D pt11_ = pt1 + (pt1 - _pts[arrow[3]]) * offsetPerc * 1.1;

            string text = string.Format("{0:0}", (pt1-pt0).GetLength());
            graphics.Draw(text, 0.5 * (pt1_ + pt0_), _color, _fontSize);
            graphics.Draw(new Segment(pt0_, pt0_ + (pt1 - pt0) * (2.0 / 5.0), _color));
            graphics.Draw(new Segment(pt0_ + (pt1 - pt0) * (3.0 / 5.0), pt1_, _color));
            graphics.Draw(new Segment(pt0, pt00_, _color));
            graphics.Draw(new Segment(pt1, pt11_, _color));
        }
        #endregion
    }
}
