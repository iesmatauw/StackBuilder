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
        private double _insideLength, _insideWidth, _insideHeight;
        private Color[] _colors = new Color[6];
        private Color _colorPath = Color.Black;
        private Vector3D[] _points;
        private Transform3D _transf = Transform3D.Identity;
        #endregion

        #region Constructor
        public Case(BoxProperties boxProperties)
        {
            _length = boxProperties.Length;
            _width = boxProperties.Width;
            _height = boxProperties.Height;
            _insideLength = boxProperties.InsideLength;
            _insideWidth = boxProperties.InsideWidth;
            _insideHeight = boxProperties.InsideHeight;
            _colors = boxProperties.Colors;
            _colorPath = Color.Black;
        }
        public Case(BoxProperties boxProperties, Transform3D transf)
        {
            _length = boxProperties.Length;
            _width = boxProperties.Width;
            _height = boxProperties.Height;
            _insideLength = boxProperties.InsideLength;
            _insideWidth = boxProperties.InsideWidth;
            _insideHeight = boxProperties.InsideHeight;
            _colors = boxProperties.Colors;
            _colorPath = Color.Black;
            _transf = transf;
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
                    _points[0] = _transf.transform(new Vector3D(0.0, 0.0, 0.0));
                    _points[1] = _transf.transform(new Vector3D(_length, 0.0, 0.0));
                    _points[2] = _transf.transform(new Vector3D(_length, _width, 0.0));
                    _points[3] = _transf.transform(new Vector3D(0.0, _width, 0.0));

                    _points[4] = _transf.transform(new Vector3D(0.0, 0.0, _height));
                    _points[5] = _transf.transform(new Vector3D(_length, 0.0, _height));
                    _points[6] = _transf.transform(new Vector3D(_length, _width, _height));
                    _points[7] = _transf.transform(new Vector3D(0.0, _width, _height));
                }
                return _points;
            }
        }

        public Vector3D[] InsidePoints
        {
            get
            {
                double xThickness = 0.5 * (_length - _insideLength);
                double yThickness = 0.5 * (_width - _insideWidth);
                double zThickness = 0.5 * (_height - _insideHeight);
                if (null == _points)
                {
                    _points = new Vector3D[8];
                    _points[0] = _transf.transform(new Vector3D(0.0 + xThickness, 0.0 + yThickness, 0.0 + zThickness));
                    _points[1] = _transf.transform(new Vector3D(_length - xThickness, 0.0 + yThickness, 0.0 + zThickness));
                    _points[2] = _transf.transform(new Vector3D(_length - xThickness, _width - yThickness, 0.0 + zThickness));
                    _points[3] = _transf.transform(new Vector3D(0.0 + xThickness, _width - yThickness, 0.0 + zThickness));

                    _points[4] = _transf.transform(new Vector3D(0.0 + xThickness, 0.0 + yThickness, _height - zThickness));
                    _points[5] = _transf.transform(new Vector3D(_length - xThickness, 0.0 + yThickness, _height - zThickness));
                    _points[6] = _transf.transform(new Vector3D(_length - xThickness, _width - yThickness, _height - zThickness));
                    _points[7] = _transf.transform(new Vector3D(0.0 + xThickness, _width - yThickness, _height - zThickness));
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
                Face[] faces = new Face[6];
                Vector3D[] points = Points;

                faces[0] = new Face(_pickId, new Vector3D[] { points[3], points[2], points[1], points[0] }, _colors[0], _colorPath);    // AXIS_Z_P
                faces[1] = new Face(_pickId, new Vector3D[] { points[4], points[5], points[6], points[7] }, _colors[1], _colorPath);    // AXIS_Z_N
                faces[2] = new Face(_pickId, new Vector3D[] { points[1], points[5], points[4], points[0] }, _colors[2], _colorPath);    // AXIS_Y_P
                faces[3] = new Face(_pickId, new Vector3D[] { points[3], points[7], points[6], points[2] }, _colors[3], _colorPath);    // AXIS_Y_N
                faces[4] = new Face(_pickId, new Vector3D[] { points[2], points[6], points[5], points[1] }, _colors[4], _colorPath);    // AXIS_X_N
                faces[5] = new Face(_pickId, new Vector3D[] { points[4], points[7], points[3], points[0] }, _colors[5], _colorPath);    // AXIS_X_P

                return faces;
            }
        }
        public Face[] InsideFaces
        {
            get
            {
                Face[] faces = new Face[6];
                Vector3D[] points = InsidePoints;

                faces[0] = new Face(_pickId, new Vector3D[] { points[3], points[2], points[1], points[0] }, _colors[0], _colorPath);    // AXIS_Z_P
                faces[1] = new Face(_pickId, new Vector3D[] { points[4], points[5], points[6], points[7] }, _colors[1], _colorPath);    // AXIS_Z_N
                faces[2] = new Face(_pickId, new Vector3D[] { points[1], points[5], points[4], points[0] }, _colors[2], _colorPath);    // AXIS_Y_P
                faces[3] = new Face(_pickId, new Vector3D[] { points[3], points[7], points[6], points[2] }, _colors[3], _colorPath);    // AXIS_Y_N
                faces[4] = new Face(_pickId, new Vector3D[] { points[2], points[6], points[5], points[1] }, _colors[4], _colorPath);    // AXIS_X_N
                faces[5] = new Face(_pickId, new Vector3D[] { points[4], points[7], points[3], points[0] }, _colors[5], _colorPath);    // AXIS_X_P

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
