#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Sharp3D.Math.Core;
using System.Drawing;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public class Box
    {
        #region enums
        enum FaceId
        { 
            AXIS_X_P   // X
            , AXIS_X_N // -X
            , AXIS_Y_P // Y
            , AXIS_Y_N // -Y
            , AXIS_Z_P // Z
            , AXIS_Z_N // -Z
        }
        #endregion

        #region Data members
        uint _pickId = 0;
        double[] _dim = new double[3];
        Vector3D _position = Vector3D.Zero;
        Vector3D _lengthAxis = Vector3D.XAxis;
        Vector3D _widthAxis = Vector3D.YAxis;
        Color[] _color;
        #endregion

        #region Constructor
        public Box(uint pickId, double length, double width, double height)
        {
            _pickId = pickId;
            _dim[0] = length;
            _dim[1] = width;
            _dim[2] = height;

            _color = new Color[6];
            _color[0] = Color.Red;
            _color[1] = Color.Red;
            _color[2] = Color.Green;
            _color[3] = Color.Green;
            _color[4] = Color.Blue;
            _color[5] = Color.Blue;
        }
        #endregion

        #region Public properties
        public Vector3D Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Vector3D LengthAxis
        {
            get { return _lengthAxis; }
            set { _lengthAxis = value; }
        }
        public Vector3D WidthAxis
        {
            get { return _widthAxis; }
            set { _widthAxis = value; }
        }

        public Face[] Faces
        {
            get
            {
                Vector3D[] points = new Vector3D[8];
                points[0] = _position;
                points[1] = _position + _dim[0] * _lengthAxis;
                points[2] = _position + _dim[0] * _lengthAxis + _dim[1] * _widthAxis;
                points[3] = _position + _dim[1] * _widthAxis;

                Vector3D heightAxis = Vector3D.CrossProduct(_lengthAxis, _widthAxis);
                points[4] = _position + _dim[2] * heightAxis;
                points[5] = _position + _dim[0] * _lengthAxis + _dim[2] * heightAxis;
                points[6] = _position + _dim[0] * _lengthAxis + _dim[1] * _widthAxis + _dim[2] * heightAxis;
                points[7] = _position + _dim[1] * _widthAxis + _dim[2] * heightAxis;

                Face[] faces = new Face[6];
                faces[0] = new Face(_pickId, new Vector3D[] { points[0], points[3], points[2], points[1] });
                faces[1] = new Face(_pickId, new Vector3D[] { points[4], points[5], points[6], points[7] });
                faces[2] = new Face(_pickId, new Vector3D[] { points[0], points[1], points[5], points[4] });
                faces[3] = new Face(_pickId, new Vector3D[] { points[3], points[7], points[6], points[2] });
                faces[4] = new Face(_pickId, new Vector3D[] { points[4], points[7], points[3], points[0] });
                faces[5] = new Face(_pickId, new Vector3D[] { points[1], points[2], points[6], points[5] });

                int i = 0;
                foreach (Face face in faces)
                    face.ColorFill = _color[i++];

                return faces;
            }
        }
        #endregion


    }
}
