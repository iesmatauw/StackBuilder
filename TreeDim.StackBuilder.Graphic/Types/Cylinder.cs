#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Sharp3D.Math.Core;
using System.Drawing;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public class Cylinder : Drawable
    {
        #region Data members
        private uint _pickId = 0;
        private double _radius, _height;
        private Vector3D _position = Vector3D.Zero;
        private Color _colorTop, _colorWall;
        private List<Texture> _textureList = new List<Texture>();
        private uint _noFaces = 36;
        #endregion

        #region Constructor
        public Cylinder(uint pickId, double radius, double height, Color colorTop, Color colorWall)
        {
            _pickId = pickId;
            _radius = radius;
            _height = height;
            _colorTop = colorTop;
            _colorWall = colorWall;
        }
        public Cylinder(uint pickId, CylinderProperties cylProperties)
        {
            _pickId = pickId;
            _radius = cylProperties.Radius;
            _height = cylProperties.Height;
            _colorTop = cylProperties.ColorTop;
            _colorWall = cylProperties.ColorWall;
        }
        public Cylinder(uint pickId, CylinderProperties cylProperties, Vector3D position)
        {
            _pickId = pickId;
            _radius = cylProperties.Radius;
            _height = cylProperties.Height;
            _colorTop = cylProperties.ColorTop;
            _colorWall = cylProperties.ColorWall;

            _position = position;
        }
        #endregion

        #region Public properties
        public Vector3D Position
        {
            get { return _position; }
        }
        public Face[] Faces
        {
            get
            {
                Face[] faces = new Face[_noFaces];

                for (int i=0; i<_noFaces; ++i)
                {
                    double angleBeg = (double)i * 2.0 * Math.PI / (double)_noFaces;
                    double angleEnd = (double)(i + 1) * 2.0 * Math.PI / (double)_noFaces;

                    Vector3D[] vertices = new Vector3D[4];
                    vertices[0] = new Vector3D(_position.X + _radius * Math.Cos(angleBeg), _position.Y + _radius * Math.Sin(angleBeg), _position.Z );
                    vertices[1] = new Vector3D(_position.X + _radius * Math.Cos(angleEnd), _position.Y + _radius * Math.Sin(angleEnd), _position.Z );
                    vertices[2] = new Vector3D(_position.X + _radius * Math.Cos(angleEnd), _position.Y + _radius * Math.Sin(angleEnd), _position.Z + _height );
                    vertices[3] = new Vector3D(_position.X + _radius * Math.Cos(angleBeg), _position.Y + _radius * Math.Sin(angleBeg), _position.Z + _height );
                    faces[i] = new Face(_pickId, vertices);
                }

                return faces;
            }
        }
        public Color ColorWall
        {
            get { return _colorWall; }
        }
        public Color ColorTop
        {
            get { return _colorTop; }
        }
        public Color ColorPath
        {
            get { return Color.Black; }
        }
        public List<Texture> Textures
        {
            get { return _textureList; }
            set { _textureList = value; }
        }
        public Vector3D[] BottomPoints
        {
            get
            {
                Vector3D[] pts = new Vector3D[_noFaces];
                for (int i = 0; i < _noFaces; ++i)
                {
                    double angle = i * 2.0 * Math.PI / _noFaces;
                    pts[i] = new Vector3D(
                        _position.X + _radius * Math.Cos(angle)
                        , _position.Y + _radius * Math.Sin(angle)
                        , _position.Z);
                }
                return pts;
            }
        }
        public Vector3D[] TopPoints
        {
            get
            {
                Vector3D[] pts = new Vector3D[_noFaces];
                for (int i = 0; i < _noFaces; ++i)
                {
                    double angle = i * 2.0 * Math.PI / _noFaces;
                    pts[i] = new Vector3D(
                        _position.X + _radius * Math.Cos(angle)
                        , _position.Y + _radius * Math.Sin(angle)
                        , _position.Z + _height);
                }
                return pts; 
            }
        }
        public uint NoFaces { get { return _noFaces; } }
        #endregion

        #region overrides
        public override void DrawBegin(Graphics3D graphics)
        {            
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
