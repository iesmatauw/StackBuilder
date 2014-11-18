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
        private double _radiusOuter, _radiusInner, _height;
        private Color _colorTop, _colorWallOuter, _colorWallInner;
        private List<Texture> _textureList = new List<Texture>();
        private uint _noFaces = 36;
        private CylPosition _cylPosition = new CylPosition(Vector3D.Zero, HalfAxis.HAxis.AXIS_Z_P);
        #endregion

        #region Constructor
        public Cylinder(uint pickId, double radiusOuter, double radiusInner, double height, Color colorTop, Color colorWallOuter, Color colorWallInner)
        {
            _pickId = pickId;
            _radiusOuter = radiusOuter;
            _radiusInner = radiusInner;
            _height = height;
            _colorTop = colorTop;
            _colorWallOuter = colorWallOuter;
            _colorWallInner = colorWallInner;
        }
        public Cylinder(uint pickId, CylinderProperties cylProperties)
        {
            _pickId = pickId;
            _radiusOuter = cylProperties.RadiusOuter;
            _radiusInner = cylProperties.RadiusInner;
            _height = cylProperties.Height;
            _colorTop = cylProperties.ColorTop;
            _colorWallOuter = cylProperties.ColorWallOuter;
            _colorWallInner = cylProperties.ColorWallInner;
        }
        public Cylinder(uint pickId, CylinderProperties cylProperties, CylPosition cylPosition)
        {
            _pickId = pickId;
            _radiusOuter = cylProperties.RadiusOuter;
            _radiusInner = cylProperties.RadiusInner;
            _height = cylProperties.Height;
            _colorTop = cylProperties.ColorTop;
            _colorWallOuter = cylProperties.ColorWallOuter;
            _colorWallInner = cylProperties.ColorWallInner;
            _cylPosition = cylPosition;
        }
        #endregion

        #region Public properties
        public double DiameterOuter { get { return 2.0 * _radiusOuter; } }
        public double DiameterInner  { get { return 2.0 * _radiusInner; } }
        public double Height { get { return _height; } }
        public CylPosition Position  { get { return _cylPosition; } }
        public Face[] FacesWalls
        {
            get
            {
                Transform3D t = _cylPosition.Transf;

                bool showInnerFaces = _radiusInner > 0;
                Face[] faces = new Face[(showInnerFaces ? 2 : 1) * _noFaces];
                if (showInnerFaces)
                {
                    for (int i = 0; i < _noFaces; ++i)
                    {
                        double angleBeg = (double)i * 2.0 * Math.PI / (double)_noFaces;
                        double angleEnd = (double)(i + 1) * 2.0 * Math.PI / (double)_noFaces;
                        Vector3D vRadiusBeg = new Vector3D(0.0, Math.Cos(angleBeg), Math.Sin(angleBeg));
                        Vector3D vRadiusEnd = new Vector3D(0.0, Math.Cos(angleEnd), Math.Sin(angleEnd));
                        Vector3D vLength = _height * Vector3D.XAxis;
                        Vector3D[] vertices = new Vector3D[4];
                        vertices[0] = t.transform(_radiusInner * vRadiusBeg);
                        vertices[1] = t.transform(_radiusInner * vRadiusBeg + _height * Vector3D.XAxis);
                        vertices[2] = t.transform(_radiusInner * vRadiusEnd + _height * Vector3D.XAxis);
                        vertices[3] = t.transform(_radiusInner * vRadiusEnd);
                        faces[i] = new Face(_pickId, vertices);
                        faces[i].ColorFill = ColorWallInner;
                    }
                }

                for (int i = 0; i < _noFaces; ++i)
                {
                    double angleBeg = (double)i * 2.0 * Math.PI / (double)_noFaces;
                    double angleEnd = (double)(i + 1) * 2.0 * Math.PI / (double)_noFaces;
                    Vector3D vRadiusBeg = new Vector3D(0.0, Math.Cos(angleBeg), Math.Sin(angleBeg));
                    Vector3D vRadiusEnd = new Vector3D(0.0, Math.Cos(angleEnd), Math.Sin(angleEnd));
                    Vector3D vLength = _height * Vector3D.XAxis;
                    Vector3D[] vertices = new Vector3D[4];
                    vertices[0] = t.transform(_radiusOuter * vRadiusBeg);
                    vertices[1] = t.transform(_radiusOuter * vRadiusEnd);
                    vertices[2] = t.transform(_radiusOuter * vRadiusEnd + _height * Vector3D.XAxis);
                    vertices[3] = t.transform(_radiusOuter * vRadiusBeg + _height * Vector3D.XAxis);
                    faces[(showInnerFaces ? _noFaces : 0) + i] = new Face(_pickId, vertices);
                    faces[(showInnerFaces ? _noFaces : 0) + i].ColorFill = ColorWallOuter;
                }
                return faces;
            }
        }
        public Face[] FacesTop
        {
            get
            {
                Transform3D t = _cylPosition.Transf;
                Face[] faces = new Face[2 * _noFaces];
                for (uint i = 0; i < _noFaces; ++i)
                {
                    double angleBeg = (double)i * 2.0 * Math.PI / (double)_noFaces;
                    double angleEnd = (double)(i + 1) * 2.0 * Math.PI / (double)_noFaces;
                    Vector3D vRadiusBeg = new Vector3D(0.0, Math.Cos(angleBeg), Math.Sin(angleBeg));
                    Vector3D vRadiusEnd = new Vector3D(0.0, Math.Cos(angleEnd), Math.Sin(angleEnd));
                    Vector3D vLength = _height * Vector3D.XAxis;
                    Vector3D[] vertices = new Vector3D[4];
                    vertices[0] = t.transform(_radiusInner * vRadiusBeg + _height * Vector3D.XAxis);
                    vertices[1] = t.transform(_radiusOuter * vRadiusBeg + _height * Vector3D.XAxis);
                    vertices[2] = t.transform(_radiusOuter * vRadiusEnd + _height * Vector3D.XAxis);
                    vertices[3] = t.transform(_radiusInner * vRadiusEnd + _height * Vector3D.XAxis);
                    faces[i] = new Face(_pickId, vertices);
                    faces[i].ColorFill = ColorTop;
                }

                for (uint i = 0; i < _noFaces; ++i)
                {
                    double angleBeg = (double)i * 2.0 * Math.PI / (double)_noFaces;
                    double angleEnd = (double)(i + 1) * 2.0 * Math.PI / (double)_noFaces;
                    Vector3D vRadiusBeg = new Vector3D(0.0, Math.Cos(angleBeg), Math.Sin(angleBeg));
                    Vector3D vRadiusEnd = new Vector3D(0.0, Math.Cos(angleEnd), Math.Sin(angleEnd));
                    Vector3D vLength = _height * Vector3D.XAxis;
                    Vector3D[] vertices = new Vector3D[4];
                    vertices[0] = t.transform(_radiusInner * vRadiusEnd);
                    vertices[1] = t.transform(_radiusOuter * vRadiusEnd);
                    vertices[2] = t.transform(_radiusOuter * vRadiusBeg);
                    vertices[3] = t.transform(_radiusInner * vRadiusBeg);
                    faces[_noFaces + i] = new Face(_pickId, vertices);
                    faces[_noFaces + i].ColorFill = ColorTop; 
                }
                return faces;
            }        
        }
        public Color ColorWallInner
        {
            get { return _colorWallInner; }
        }
        public Color ColorWallOuter
        {
            get { return _colorWallOuter; }
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
                Transform3D t = _cylPosition.Transf;
                Vector3D[] pts = new Vector3D[_noFaces];
                for (int i = 0; i < _noFaces; ++i)
                {
                    double angle = i * 2.0 * Math.PI / _noFaces;
                    Vector3D vRadius = new Vector3D(0.0, Math.Cos(angle), Math.Sin(angle));
                    pts[i] = t.transform(_radiusOuter * vRadius);
                }
                return pts;
            }
        }
        public Vector3D[] TopPoints
        {
            get
            {
                Transform3D t = _cylPosition.Transf;
                Vector3D[] pts = new Vector3D[_noFaces];
                for (int i = 0; i < _noFaces; ++i)
                {
                    double angle = i * 2.0 * Math.PI / _noFaces;
                    Vector3D vRadius = new Vector3D(0.0, Math.Cos(angle), Math.Sin(angle));
                    pts[i] = t.transform(_radiusOuter * vRadius + _height * Vector3D.XAxis);
                }
                return pts;
            }
        }
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
