#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    #region PalletCap
    public class PalletCap : Drawable
    {
        #region Data members
        private uint _pickId = 0;
        private double[] _dim = new double[3];
        private Vector3D _position = Vector3D.Zero;
        private Vector3D _lengthAxis = Vector3D.XAxis;
        private Vector3D _widthAxis = Vector3D.YAxis;
        private Color _color;
        #endregion

        #region Constructor
        public PalletCap(uint pickId, PalletCapProperties capProperties, Vector3D position)
        {
            _dim[0] = capProperties.Length;
            _dim[1] = capProperties.Width;
            _dim[2] = capProperties.Height;

            _color = capProperties.Color;

            Position = position;
        }
        #endregion

        #region Public properties
        public uint PickId
        {
            get { return _pickId; }
        }
        public Vector3D Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public double Length
        {
            get { return _dim[0]; }
        }
        public double Width
        {
            get { return _dim[1]; }
        }
        public double Height
        {
            get { return _dim[2]; }
        }
        public Face[] Faces
        {
            get
            {
                Vector3D heightAxis = Vector3D.CrossProduct(_lengthAxis, _widthAxis);
                Vector3D[] points = new Vector3D[8];
                points[0] = _position;
                points[1] = _position + _dim[0] * _lengthAxis;
                points[2] = _position + _dim[0] * _lengthAxis + _dim[1] * _widthAxis;
                points[3] = _position + _dim[1] * _widthAxis;

                points[4] = _position + _dim[2] * heightAxis;
                points[5] = _position + _dim[2] * heightAxis + _dim[0] * _lengthAxis;
                points[6] = _position + _dim[2] * heightAxis + _dim[0] * _lengthAxis + _dim[1] * _widthAxis;
                points[7] = _position + _dim[2] * heightAxis + _dim[1] * _widthAxis;

                Face[] faces = new Face[6];
                faces[0] = new Face(_pickId, new Vector3D[] { points[3], points[0], points[4], points[7] }, true); // AXIS_X_N
                faces[1] = new Face(_pickId, new Vector3D[] { points[1], points[2], points[6], points[5] }, true); // AXIS_X_P
                faces[2] = new Face(_pickId, new Vector3D[] { points[0], points[1], points[5], points[4] }, true); // AXIS_Y_N
                faces[3] = new Face(_pickId, new Vector3D[] { points[2], points[3], points[7], points[6] }, true); // AXIS_Y_P
                faces[4] = new Face(_pickId, new Vector3D[] { points[3], points[2], points[1], points[0] }, true); // AXIS_Z_N
                faces[5] = new Face(_pickId, new Vector3D[] { points[4], points[5], points[6], points[7] }, true); // AXIS_Z_P

                int i = 0;
                foreach (Face face in faces)
                {
                    face.ColorFill = _color;
                    ++i;
                }
                return faces;
            }
        }
        #endregion

        #region Drawable override
        public override void Draw(Graphics3D graphics)
        {
            foreach (Face face in Faces)
                graphics.AddFace(face);
        }
        public override void DrawEnd(Graphics3D graphics)
        {
            foreach (Face face in Faces)
                    graphics.AddFace(face);
        }
        #endregion
    }
    #endregion
}
