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
        Vector3D _position;
        double[] _dim = new double[3];
        bool[] _showArrow = new bool[3];
        double offsetPerc = 0.1;
        Vector3D[] _pts = new Vector3D[8];
        #endregion

        #region Constructor
        public DimensionCube(double length, double width, double height)
        {
            _dim[0] = length; _dim[1] = width; _dim[2] = height;
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

            Vector3D[] pts = new Vector3D[6];
            pts[0] = _pts[arrow0[0]] + (_pts[arrow0[0]] - _pts[arrow0[2]]) * offsetPerc * 1.1;
            pts[1] = _pts[arrow0[1]] + (_pts[arrow0[1]] - _pts[arrow0[3]]) * offsetPerc * 1.1;
            pts[2] = _pts[arrow1[0]] + (_pts[arrow1[0]] - _pts[arrow1[2]]) * offsetPerc * 1.1;
            pts[3] = _pts[arrow1[1]] + (_pts[arrow1[1]] - _pts[arrow1[3]]) * offsetPerc * 1.1;
            pts[4] = _pts[arrow2[0]] + (_pts[arrow2[0]] - _pts[arrow2[2]]) * offsetPerc * 1.1;
            pts[5] = _pts[arrow2[1]] + (_pts[arrow2[1]] - _pts[arrow2[3]]) * offsetPerc * 1.1;
            return pts;
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

        private void DrawArrow(int[] arrow, Graphics3D graphics)
        {
            Vector3D pt0 = _pts[arrow[0]];
            Vector3D pt0_ = pt0 + (pt0 - _pts[arrow[2]]) * offsetPerc;
            Vector3D pt00_ = pt0 + (pt0 - _pts[arrow[2]]) * offsetPerc * 1.1;

            Vector3D pt1 = _pts[arrow[1]];
            Vector3D pt1_ = pt1 + (pt1 - _pts[arrow[3]]) * offsetPerc;
            Vector3D pt11_ = pt1 + (pt1 - _pts[arrow[3]]) * offsetPerc * 1.1;

            string text = string.Format("{0}", (pt1-pt0).GetLength());
            graphics.Draw(text, 0.5 * (pt1_ + pt0_), Color.Red, 8.0F);
            graphics.Draw(new Segment(pt0_, pt0_+ (pt1-pt0) * (2.0/5.0), Color.Red));
            graphics.Draw(new Segment(pt0_ + (pt1 - pt0) * (3.0 / 5.0), pt1_, Color.Red));
            graphics.Draw(new Segment(pt0, pt00_, Color.Red));
            graphics.Draw(new Segment(pt1, pt11_, Color.Red));
        }
        #endregion
    }
}
