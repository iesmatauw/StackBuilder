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
    /// Drawable truck (used to draw a truck with a Graphics3D object)
    /// </summary>
    public class Truck : Drawable
    {
        #region Data members
        private uint _pickId = 0;
        private double _length, _width, _height;
        private Color _colorFill, _colorPath;
        private Vector3D[] _points;
        #endregion

        #region Constructor
        public Truck(TruckProperties truckProperties)
        {
            _length = truckProperties.Length;
            _width = truckProperties.Width;
            _height = truckProperties.Height;
            _colorFill = truckProperties.Color;
            _colorPath = Color.Black;
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

        #region Public properties
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

        public Segment[] Segments
        {
            get
            {
                Segment[] segments = new Segment[12];
                Vector3D[] points = Points;

                segments[0] = new Segment(points[0], points[1], _colorPath);
                segments[1] = new Segment(points[1], points[2], _colorPath);
                segments[2] = new Segment(points[2], points[3], _colorPath);
                segments[3] = new Segment(points[3], points[0], _colorPath);

                segments[4] = new Segment(points[4], points[5], _colorPath);
                segments[5] = new Segment(points[5], points[6], _colorPath);
                segments[6] = new Segment(points[6], points[7], _colorPath);
                segments[7] = new Segment(points[7], points[4], _colorPath);

                segments[8] = new Segment(points[0], points[4], _colorPath);
                segments[9] = new Segment(points[1], points[5], _colorPath);
                segments[10] = new Segment(points[2], points[6], _colorPath);
                segments[11] = new Segment(points[3], points[7], _colorPath);

                return segments;
            }
        }

        public Face[] Faces
        {
            get
            {
                Face[] faces = new Face[5];
                Vector3D[] points = Points;

                faces[0] = new Face(_pickId, new Vector3D[] { points[3], points[2], points[1], points[0] }, _colorFill, _colorPath);    // AXIS_Z_P
                faces[1] = new Face(_pickId, new Vector3D[] { points[1], points[5], points[4], points[0] }, _colorFill, _colorPath);    // AXIS_Y_P
                faces[2] = new Face(_pickId, new Vector3D[] { points[3], points[7], points[6], points[2] }, _colorFill, _colorPath);    // AXIS_Y_N
                faces[3] = new Face(_pickId, new Vector3D[] { points[2], points[6], points[5], points[1] }, _colorFill, _colorPath);    // AXIS_X_N
                faces[4] = new Face(_pickId, new Vector3D[] { points[4], points[7], points[3], points[0] }, _colorFill, _colorPath);    // AXIS_X_P

                return faces;
            }
        }
        #endregion
    }
}
