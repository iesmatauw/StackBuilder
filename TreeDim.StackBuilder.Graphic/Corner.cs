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
        private uint _pickId = 0;
        private Color _color;
        private Vector3D _position;
        private HalfAxis.HAxis _lengthAxis = HalfAxis.HAxis.AXIS_X_P, _widthAxis = HalfAxis.HAxis.AXIS_Y_P;

        private double _w = 0.0, _th = 0.0, _height = 0.0;
        #endregion

        #region Constructor
        public Corner(uint pickId, PalletCornerProperties cornerProperties)
        {
            _pickId = pickId;
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
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public Vector3D Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public HalfAxis.HAxis LengthAxis
        {
            get { return _lengthAxis; }
            set { _lengthAxis = value; }
        }
        public HalfAxis.HAxis WidthAxis
        {
            get { return _widthAxis; }
            set { _widthAxis = value; }
        }
        #endregion

        #region Points / Face
        public void SetPosition(Vector3D position, HalfAxis.HAxis lengthAxis, HalfAxis.HAxis widthAxis)
        {
            _position = position;
            _lengthAxis = lengthAxis;
            _widthAxis = widthAxis;
        }

        public Vector3D[] Points
        {
            get
            {
                //
                // 5---4
                // |   |
                // |   |
                // |   0 ----- 2
                // |           |
                // 1 --------- 3
                //
                // 11--10
                // |   |
                // |   |
                // |   6 ----- 8
                // |           |
                // 7 --------- 9
                //
                Vector3D[] points = new Vector3D[12];

                Vector3D LAxis = HalfAxis.ToVector3D(_lengthAxis);
                Vector3D WAxis = HalfAxis.ToVector3D(_widthAxis);
                Vector3D HAxis = Vector3D.CrossProduct(LAxis, WAxis);
                // bottom
                points[0] = _position;
                points[1] = _position - _th * LAxis - _th * WAxis; 
                points[2] = _position + (_w - _th) * LAxis;
                points[3] = _position + (_w - _th) * LAxis - _th * WAxis;
                points[4] = _position + (_w - _th) * WAxis;
                points[5] = _position - _th * LAxis + (_w - _th) * WAxis;
                // top
                for (int i=0; i<6; ++i)
                    points[i+6] = points[i] + _height * HAxis;
                return points;
            }
        }

        public Face[] Faces
        {
            get
            {
                int[,] indexes
                = {
                    {1, 7, 11, 5}
                    , {5, 11, 10, 4}
                    , {4, 10, 6, 0}
                    , {7, 6, 10, 11}
                    , {3, 9, 7, 1}
                    , {6, 7, 9, 8}
                    , {0, 6, 8, 2}
                    , {2, 8, 9, 3}
                };

                Face[] faces = new Face[8];
                Vector3D[] points = Points;
                for (int i = 0; i < 8; ++i)
                {
                    faces[i] = new Face(_pickId, new Vector3D[] { points[indexes[i, 0]], points[indexes[i, 1]], points[indexes[i, 2]], points[indexes[i, 3]] }, true);
                    faces[i].ColorFill = _color;
                }
                return faces;
            }
        }

        public Vector3D NormalPart1
        {
            get
            {
                Vector3D[] points = Points;
                Vector3D norm = Vector3D.CrossProduct(points[7]-points[1], points[5]-points[1]);
                norm.Normalize();
                return norm;
            }
        }

        public Vector3D NormalPart2
        {
            get
            {
                Vector3D[] points = Points;
                Vector3D norm = Vector3D.CrossProduct(points[3]-points[1], points[7]-points[1]);
                norm.Normalize();
                return norm;
            }
        }
        #endregion

        #region Drawable override
        public override void Draw(Graphics3D graphics)
        {
            foreach (Face face in Faces)
                graphics.AddFace(face);
        }
        public override void DrawBegin(Graphics3D graphics)
        {
            Face[] faces = Faces;
            if (Vector3D.DotProduct(faces[0].Normal, graphics.ViewDirection) >= 0.0)
            {
                for (int i = 0; i < 4; ++i)
                    graphics.AddFaceBackground(faces[i]);
            }
            if (Vector3D.DotProduct(faces[4].Normal, graphics.ViewDirection) >= 0.0)
            {
                for (int i = 4; i < 8; ++i)
                    graphics.AddFaceBackground(faces[i]); 
            }
        }
        public override void DrawEnd(Graphics3D graphics)
        {
            Face[] faces = Faces;
            if (Vector3D.DotProduct(faces[0].Normal, graphics.ViewDirection) <= 0.0)
            {
                for (int i = 0; i < 4; ++i)
                {
                    graphics.AddFace(faces[i]);
                }
            }
            if (Vector3D.DotProduct(faces[4].Normal, graphics.ViewDirection) <= 0.0)
            {
                for (int i = 4; i < 8; ++i)
                    graphics.AddFace(faces[i]); 
            }
        }
        #endregion
    }
}
