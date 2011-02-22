#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    /// <summary>
    /// drawable case (used to draw a case with a Graphics3D object)
    /// </summary>
    public class Case : Drawable
    {
        #region Data members
        private uint _pickId = 0;
        private double _length, _width, _height;
        private Color[] _colors = new Color[6];
        private Color _colorPath = Color.Black;
        private Vector3D[] _points;
        #endregion

        #region Constructor
        public Case(BoxProperties boxProperties)
        {
            _length = boxProperties.Length;
            _width = boxProperties.Width;
            _height = boxProperties.Height;
            _colors = boxProperties.Colors;
            _colorPath = Color.Black;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Points
        /// </summary>
        public Vector3D[] Points
        {
            get
            {
                if (null == _points)
                {
                    _points = new Vector3D[8];
                    _points[0] = new Vector3D(0.0, 0.0, 0.0);
                    _points[1] = new Vector3D(_length, 0.0, 0.0);
                    _points[2] = new Vector3D(_length, _width, 0.0);
                    _points[3] = new Vector3D(0.0, _width, 0.0);

                    _points[4] = new Vector3D(0.0, 0.0, _height);
                    _points[5] = new Vector3D(_length, 0.0, _height);
                    _points[6] = new Vector3D(_length, _width, _height);
                    _points[7] = new Vector3D(0.0, _width, _height);
                }
                return _points;
            }
        }
        /// <summary>
        /// Faces
        /// </summary>
        public Face[] Faces
        {
            get
            {
                Face[] faces = new Face[5];
                Vector3D[] points = Points;

                faces[0] = new Face(_pickId, new Vector3D[] { points[3], points[2], points[1], points[0] }, _colors[0], _colorPath);    // AXIS_Z_P
                faces[1] = new Face(_pickId, new Vector3D[] { points[1], points[5], points[4], points[0] }, _colors[1], _colorPath);    // AXIS_Y_P
                faces[2] = new Face(_pickId, new Vector3D[] { points[3], points[7], points[6], points[2] }, _colors[2], _colorPath);    // AXIS_Y_N
                faces[3] = new Face(_pickId, new Vector3D[] { points[2], points[6], points[5], points[1] }, _colors[3], _colorPath);    // AXIS_X_N
                faces[4] = new Face(_pickId, new Vector3D[] { points[4], points[7], points[3], points[0] }, _colors[4], _colorPath);    // AXIS_X_P

                return faces;
            }
        }
        #endregion

        #region Overrides
        public override void DrawBegin(Graphics3D graphics)
        {
            foreach (Face face in Faces)
                graphics.AddFace(face);
        }
        public override void Draw(Graphics3D graphics)
        {
        }
        public override void DrawEnd(Graphics3D graphics)
        {

        }
        #endregion
    }
}
