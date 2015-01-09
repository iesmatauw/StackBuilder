#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public class Corner : Drawable
    {
        #region Data members
        private uint _pickId;
        private Color _color;
        private Vector3D _position;
        private Vector3D _lengthAxis = Vector3D.XAxis;
        private Vector3D _widthAxis = Vector3D.YAxis;

        private double _w = 0.0, _th = 0.0, _height = 0.0;
        #endregion

        #region Constructor
        public Corner(PalletCornerProperties cornerProperties)
        {
            _w = cornerProperties.Width;
            _th = cornerProperties.Thickness;
            _height = cornerProperties.Length;
            _color = cornerProperties._color;
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
        #endregion

        #region Points / Face
        public Vector3D[] Points
        {
            get
            {
                Vector3D[] points = new Vector3D[12];
                // bottom
                points[0] = _position;
                points[1] = _position - _th * LengthAxis - _th * WidthAxis; 
                points[2] = _position + (_w - _th) * LengthAxis;
                points[3] = _position + (_w - _th) * LengthAxis - _th * WidthAxis;
                points[4] = _position - (_w + _th) * WidthAxis;
                points[5] = _position - _th * LengthAxis + (_w - _th) * WidthAxis;
                // top
                for (int i=0; i<6; ++i)
                    points[i+6] = points[i] + _height * Vector3D.CrossProduct(LengthAxis, WidthAxis);
                return points;
            }
        }

        public Face[] Faces
        {
            get
            {
                int[,] indexes
                = {
                    {5, 0, 7, 11}
                    , {0, 3, 9, 7}
                    , {3, 2, 8, 9}
                    , {2, 0, 6, 8}
                    , {0, 4, 10, 6}
                    , {4, 5, 11, 10}
                    , {6, 7, 9, 8}
                    , {7, 6, 10, 11}
                };

                Face[] faces = new Face[8];
                Vector3D[] points = Points;
                for (int i=0; i<8; ++i)
                    faces[i] = new Face(_pickId, new Vector3D[] { points[indexes[i,0]], points[indexes[i,1]], points[indexes[i,2]], points[indexes[i,3]] });
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
        #endregion
    }
}
