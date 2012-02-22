#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Sharp3D.Math.Core;
using System.Drawing;
using TreeDim.StackBuilder.Basics;

using System.Diagnostics;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    #region Box
    /// <summary>
    /// This class used to draw any brick with side parallel to axes and normal oriented to exterior
    /// Use method Graphics.Draw(Box box) to draw as ordered boxel
    /// </summary>
    public class Box : Drawable
    {
        #region Data members
        private uint _pickId = 0;
        private double[] _dim = new double[3];
        private Vector3D _position = Vector3D.Zero;
        private Vector3D _lengthAxis = Vector3D.XAxis;
        private Vector3D _widthAxis = Vector3D.YAxis;
        private Color[] _colors;
        private List<Texture>[] _textureLists = new List<Texture>[6];
        /// <summary>
        /// Bundle properties
        /// </summary>
        private bool _isBundle = false;
        private int _noFlats = 0;
        /// <summary>
        /// Tape related properties
        /// </summary>
        private bool _showTape = false;
        private double _tapeWidth;
        private Color _tapeColor;
        #endregion

        #region Constructor
        public Box(uint pickId, double length, double width, double height)
        {
            _pickId = pickId;
            _dim[0] = length;
            _dim[1] = width;
            _dim[2] = height;

            _colors = new Color[6];
            _colors[0] = Color.Red;
            _colors[1] = Color.Red;
            _colors[2] = Color.Green;
            _colors[3] = Color.Green;
            _colors[4] = Color.Blue;
            _colors[5] = Color.Blue;

            for (int i = 0; i < 6; ++i)
                _textureLists[i] = null;
        }
        public Box(uint pickId, double length, double width, double height, double x, double y, double z)
        {
            _pickId = pickId;
            _dim[0] = length;
            _dim[1] = width;
            _dim[2] = height;

            _colors = new Color[6];
            _colors[0] = Color.Red;
            _colors[1] = Color.Red;
            _colors[2] = Color.Green;
            _colors[3] = Color.Green;
            _colors[4] = Color.Blue;
            _colors[5] = Color.Blue;

            for (int i = 0; i < 6; ++i)
                _textureLists[i] = null;

            _position.X = x;
            _position.Y = y;
            _position.Z = z;
        }
        public Box(uint pickId, BProperties bProperties)
        {
            _pickId = pickId;
            _dim[0] = bProperties.Length;
            _dim[1] = bProperties.Width;
            _dim[2] = bProperties.Height;

            _colors = bProperties.Colors;

            // IsBundle ?
            _isBundle = bProperties.IsBundle;

            // textures
            BoxProperties boxProperties = bProperties as BoxProperties;
            if (null != boxProperties)
            {
                List<Pair<HalfAxis.HAxis, Texture>> textures = boxProperties.TextureList;
                foreach (Pair<HalfAxis.HAxis, Texture> tex in textures)
                {
                    int iIndex = (int)tex.first;
                    if (null == _textureLists[iIndex])
                        _textureLists[iIndex] = new List<Texture>();
                    _textureLists[iIndex].Add(tex.second);

                }
                // tape
                _showTape = boxProperties.ShowTape;
                _tapeWidth = boxProperties.TapeWidth;
                _tapeColor = boxProperties.TapeColor;
            }
        }
        public Box(uint pickId, BProperties bProperties, BoxPosition bPosition)
        {
            if (!bPosition.IsValid)
                throw new GraphicsException("Invalid BoxPosition: can not create box");
            _pickId = pickId;
            _dim[0] = bProperties.Length;
            _dim[1] = bProperties.Width;
            _dim[2] = bProperties.Height;

            _colors = bProperties.Colors;

            BoxProperties boxProperties = bProperties as BoxProperties;
            if (null != boxProperties)
            {
                List<Pair<HalfAxis.HAxis, Texture>> textures = boxProperties.TextureList;
                foreach (Pair<HalfAxis.HAxis, Texture> tex in textures)
                {
                    int iIndex = (int)tex.first;
                    if (null == _textureLists[iIndex])
                        _textureLists[iIndex] = new List<Texture>();
                    _textureLists[iIndex].Add(tex.second);
                }
                _showTape = boxProperties.ShowTape;
                _tapeWidth = boxProperties.TapeWidth;
                _tapeColor = boxProperties.TapeColor;
            }

            // set position
            Position = bPosition.Position;
            // set direction length
            LengthAxis = HalfAxis.ToVector3D(bPosition.DirectionLength);
            // set direction width
            WidthAxis = HalfAxis.ToVector3D(bPosition.DirectionWidth);
            // IsBundle ?
            _noFlats = 3;
            _isBundle = bProperties.IsBundle;
        }

        public Box(uint pickId, InterlayerProperties interlayerProperties)
        {
            _pickId = pickId;
            _dim[0] = interlayerProperties.Length;
            _dim[1] = interlayerProperties.Width;
            _dim[2] = interlayerProperties.Thickness;
            _colors = new Color[6];
            for (int i = 0; i < 6; ++i)
                _colors[i] = interlayerProperties.Color;
        }

        public Box(uint pickId, InterlayerProperties interlayerProperties, BoxPosition bPosition)
        {
            _pickId = pickId;
            _dim[0] = interlayerProperties.Length;
            _dim[1] = interlayerProperties.Width;
            _dim[2] = interlayerProperties.Thickness;
            _colors = new Color[6];
            for (int i = 0; i < 6; ++i)
                _colors[i] = interlayerProperties.Color;

            // set position
            Position = bPosition.Position;
            // set direction length
            LengthAxis = HalfAxis.ToVector3D(bPosition.DirectionLength);
            // set direction width
            WidthAxis = HalfAxis.ToVector3D(bPosition.DirectionWidth);
        }

        public Box(uint pickId, BundleProperties bundleProperties)
        {
            _pickId = pickId;
            _isBundle = true;
            _dim[0] = bundleProperties.Length;
            _dim[1] = bundleProperties.Width;
            _dim[2] = bundleProperties.Height;
            _colors = new Color[6];
            for (int i = 0; i < 6; ++i)
                _colors[i] = bundleProperties.Color;
            _noFlats = bundleProperties.NoFlats;
            // IsBundle ?
            _isBundle = bundleProperties.IsBundle;
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

        public Color[] Colors
        {
            get { return _colors; }
        }

        public bool IsBundle
        {
            get { return _isBundle; }
            set { _isBundle = value; }
        }
        public int BundleFlats
        {
            get { return _noFlats; }
        }

        public Face TopFace
        {
            get
            {
                Face[] faces = Faces;
                Face topFace = faces[0];
                foreach (Face face in faces)
                    if (face.Center.Z > topFace.Center.Z)
                        topFace = face;
                return topFace;
            }
        }

        public Vector3D[] Oriented(Vector3D pt0, Vector3D pt1, Vector3D pt2, Vector3D pt3, Vector3D pt)
        {
            Vector3D crossProduct = Vector3D.CrossProduct(pt1 - pt0, pt2 - pt0);
            if (Vector3D.DotProduct(crossProduct, pt - pt0) < 0)
                return new Vector3D[] { pt0, pt1, pt2, pt3 };
            else
                return new Vector3D[] { pt3, pt2, pt1, pt0 };
        }

        public Vector3D Center
        {
            get
            {
                return _position
                    + 0.5 * _dim[0] * _lengthAxis
                    + 0.5 * _dim[1] * _widthAxis
                    + 0.5 * _dim[2] * Vector3D.CrossProduct(_lengthAxis, _widthAxis);
            }
        }

        public bool ShowTape
        {
            get { return _showTape; }
            set { _showTape = value; }
        }

        public double TapeWidth
        {
            get { return _tapeWidth; }
        }

        public Color TapeColor
        {
            get { return _tapeColor; }
        }

        public Vector3D[] TapePoints
        {
            get
            {
                Vector3D heightAxis = Vector3D.CrossProduct(_lengthAxis, _widthAxis);
                Vector3D[] points = new Vector3D[4];
                points[0] = _position + 0.0 * _lengthAxis + 0.5 * (_dim[1] - _tapeWidth) * _widthAxis + _dim[2] * heightAxis;
                points[1] = _position + _dim[0] * _lengthAxis + 0.5 * (_dim[1] - _tapeWidth) * _widthAxis + _dim[2] * heightAxis;
                points[2] = _position + _dim[0] * _lengthAxis + 0.5 * (_dim[1] + _tapeWidth) * _widthAxis + _dim[2] * heightAxis;
                points[3] = _position + 0.0 * _lengthAxis + 0.5 * (_dim[1] + _tapeWidth) * _widthAxis + _dim[2] * heightAxis;
                return points;
            }
        }
        #endregion

        #region XMin / XMax / YMin / YMax / ZMin
        public double XMin
        {
            get
            {
                double xmin = double.MaxValue;
                foreach (Vector3D v in this.Points)
                {
                    if (v.X < xmin)
                        xmin = v.X;
                }
                return xmin;
            }
        }
        public double XMax
        {
            get
            {
                double xmax = double.MinValue;
                foreach (Vector3D v in this.Points)
                {
                    if (v.X > xmax)
                        xmax = v.X;
                }
                return xmax;
            }
        }
        public double YMin
        {
            get
            {
                double ymin = double.MaxValue;
                foreach (Vector3D v in this.Points)
                {
                    if (v.Y < ymin)
                        ymin = v.Y;
                }
                return ymin;
            }
        }
        public double YMax
        {
            get
            {
                double ymax = double.MinValue;
                foreach (Vector3D v in this.Points)
                {
                    if (v.Y > ymax)
                        ymax = v.Y;
                }
                return ymax;
            }
        }

        public double ZMin
        {
            get
            {
                double zmin = double.MaxValue;
                foreach (Vector3D v in this.Points)
                    zmin = Math.Min(v.Z, zmin);
                return zmin;
            }
        }
        #endregion

        #region Points / Faces
        public Vector3D[] Points
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

                return points;
            }
        }
        public Vector3D[] Normals
        {
            get
            {
                Vector3D[] normals = new Vector3D[6];
                normals[0] = -Vector3D.XAxis;
                normals[1] = Vector3D.XAxis;
                normals[2] = -Vector3D.YAxis;
                normals[3] = Vector3D.YAxis;
                normals[4] = -Vector3D.ZAxis;
                normals[5] = Vector3D.ZAxis;
                return normals;
            }
        }
        public Vector2D[] UVs
        {
            get
            {
                Vector2D[] uvs = new Vector2D[4];
                uvs[0] = new Vector2D(0.0, 0.0);
                uvs[1] = new Vector2D(1.0, 0.0);
                uvs[2] = new Vector2D(0.0, 1.0);
                uvs[3] = new Vector2D(1.0, 1.0);
                return uvs;
            }
        }

        public TriangleIndices[] Triangles
        {
            get
            {
                Vector3D heightAxis = Vector3D.CrossProduct(_lengthAxis, _widthAxis);
                TriangleIndices[] tri = new TriangleIndices[12];
                ulong n0 = (ulong)HalfAxis.ToHalfAxis(-LengthAxis);
                tri[0] = new TriangleIndices(0, 4, 3, n0, n0, n0, 1, 3, 0);
                tri[1] = new TriangleIndices(3, 4, 7, n0, n0, n0, 0, 3, 2);
                ulong n1 = (ulong)HalfAxis.ToHalfAxis(LengthAxis);
                tri[2] = new TriangleIndices(1, 2, 5, n1, n1, n1, 0, 1, 2);
                tri[3] = new TriangleIndices(5, 2, 6, n1, n1, n1, 1, 3, 2);
                ulong n2 = (ulong)HalfAxis.ToHalfAxis(-WidthAxis);
                tri[4] = new TriangleIndices(0, 1, 4, n2, n2, n2, 0, 1, 2);
                tri[5] = new TriangleIndices(4, 1, 5, n2, n2, n2, 2, 1, 3);
                ulong n3 = (ulong)HalfAxis.ToHalfAxis(WidthAxis);
                tri[6] = new TriangleIndices(7, 6, 2, n3, n3, n3, 3, 2, 0);
                tri[7] = new TriangleIndices(7, 2, 3, n3, n3, n3, 3, 0, 1);
                ulong n4 = (ulong)HalfAxis.ToHalfAxis(-heightAxis);
                tri[8] = new TriangleIndices(0, 3, 1, n4, n4, n4, 2, 0, 3);
                tri[9] = new TriangleIndices(1, 3, 2, n4, n4, n4, 3, 0, 1);
                ulong n5 = (ulong)HalfAxis.ToHalfAxis(heightAxis);
                tri[10] = new TriangleIndices(4, 5, 7, n5, n5, n5, 0, 1, 2);
                tri[11] = new TriangleIndices(7, 5, 6, n5, n5, n5, 2, 1, 3);
                return tri;
            }
        }
        public TriangleIndices[] TrianglesByFace(HalfAxis.HAxis axis)
        {
            TriangleIndices[] tri = new TriangleIndices[2];
            ulong n = (ulong)axis;
            switch (axis)
            {
                case HalfAxis.HAxis.AXIS_X_N:
                    tri[0] = new TriangleIndices(0, 4, 3, n, n, n, 1, 3, 0);
                    tri[1] = new TriangleIndices(3, 4, 7, n, n, n, 0, 3, 2);
                    break;
                case HalfAxis.HAxis.AXIS_X_P:
                    tri[0] = new TriangleIndices(1, 2, 5, n, n, n, 0, 1, 2);
                    tri[1] = new TriangleIndices(5, 2, 6, n, n, n, 1, 3, 2);
                    break;
                case HalfAxis.HAxis.AXIS_Y_N:
                    tri[0] = new TriangleIndices(0, 1, 4, n, n, n, 0, 1, 2);
                    tri[1] = new TriangleIndices(4, 1, 5, n, n, n, 2, 1, 3);
                    break;
                case HalfAxis.HAxis.AXIS_Y_P:
                    tri[0] = new TriangleIndices(7, 6, 2, n, n, n, 3, 2, 0);
                    tri[1] = new TriangleIndices(7, 2, 3, n, n, n, 3, 0, 1);
                    break;
                case HalfAxis.HAxis.AXIS_Z_N:
                    tri[0] = new TriangleIndices(0, 3, 1, n, n, n, 2, 0, 3);
                    tri[1] = new TriangleIndices(1, 3, 2, n, n, n, 3, 0, 1);
                    break;
                case HalfAxis.HAxis.AXIS_Z_P:
                    tri[0] = new TriangleIndices(4, 5, 7, n, n, n, 0, 1, 2);
                    tri[1] = new TriangleIndices(7, 5, 6, n, n, n, 2, 1, 3);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            return tri;
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
                faces[0] = new Face(_pickId, new Vector3D[] { points[3], points[0], points[4], points[7] }); // AXIS_X_N
                faces[1] = new Face(_pickId, new Vector3D[] { points[1], points[2], points[6], points[5] }); // AXIS_X_P
                faces[2] = new Face(_pickId, new Vector3D[] { points[0], points[1], points[5], points[4] }); // AXIS_Y_N
                faces[3] = new Face(_pickId, new Vector3D[] { points[2], points[3], points[7], points[6] }); // AXIS_Y_P
                faces[4] = new Face(_pickId, new Vector3D[] { points[3], points[2], points[1], points[0] }); // AXIS_Z_N
                faces[5] = new Face(_pickId, new Vector3D[] { points[4], points[5], points[6], points[7] }); // AXIS_Z_P

                int i = 0;
                foreach (Face face in faces)
                {
                    face.ColorFill = _colors[i];
                    face.Textures = _textureLists[i];
                    ++i;
                }
                return faces;
            }
        }
        /// <summary>
        /// PointsImage
        /// </summary>
        /// <param name="texture">Texture (bitmap + Vector2D (position) + Vector2D(size) + double(angle))</param>
        /// <returns>array of Vector3D points</returns>
        public Vector3D[] PointsImage(int faceId, Texture texture)
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

            Vector3D vecI = Vector3D.XAxis, vecJ = Vector3D.YAxis, vecO = Vector3D.Zero;
            switch (faceId)
            {
                case 0: vecI = points[0] - points[3]; vecJ = points[7] - points[3]; vecO = points[3]; break;
                case 1: vecI = points[2] - points[1]; vecJ = points[5] - points[1]; vecO = points[1]; break;
                case 2: vecI = points[1] - points[0]; vecJ = points[4] - points[0]; vecO = points[0]; break;
                case 3: vecI = points[3] - points[2]; vecJ = points[6] - points[2]; vecO = points[2]; break;
                case 4: vecI = points[0] - points[1]; vecJ = points[2] - points[1]; vecO = points[1]; break;
                case 5: vecI = points[5] - points[4]; vecJ = points[7] - points[4]; vecO = points[4]; break;
                default: break;
            }
            vecI.Normalize();
            vecJ.Normalize();

            Vector3D[] pts = new Vector3D[4];
            double cosAngle = Math.Cos(texture.Angle * Math.PI / 180.0);
            double sinAngle = Math.Sin(texture.Angle * Math.PI / 180.0);

            pts[0] = vecO + texture.Position.X * vecI + texture.Position.Y * vecJ;
            pts[1] = vecO + (texture.Position.X + texture.Size.X * cosAngle) * vecI + (texture.Position.Y + texture.Size.X * sinAngle) * vecJ;
            pts[2] = vecO + (texture.Position.X + texture.Size.X * cosAngle - texture.Size.Y * sinAngle) * vecI + (texture.Position.Y + texture.Size.X * sinAngle + texture.Size.Y * cosAngle) * vecJ;
            pts[3] = vecO + (texture.Position.X - texture.Size.Y * sinAngle) * vecI + (texture.Position.Y + texture.Size.Y * cosAngle) * vecJ;
            return pts;
        }
        #endregion

        #region Validity
        public bool IsValid
        {
            get
            {
                return _dim[0] > 0.0 && _dim[1] > 0.0 && _dim[2] > 0.0 && (_lengthAxis != _widthAxis);
            }
        }
        #endregion

        #region Public methods
        public override void Draw(Graphics3D graphics)
        {
            foreach (Face face in Faces)
                graphics.AddFace(face);
        }

        public void SetAllFacesColor(Color color)
        {
            for (int i = 0; i < 6; ++i)
                _colors[i] = color;
        }

        public void SetFaceColor(HalfAxis.HAxis iFace, Color color)
        {
            _colors[(int)iFace] = color;
        }

        public void SetFaceTextures(HalfAxis.HAxis iFace, List<Texture> textures)
        {
            _textureLists[(int)iFace] = textures;
        }

        public bool PointInside(Vector3D pt)
        {
            foreach (Face face in Faces)
            {
                if (face.PointRelativePosition(pt) != -1)
                    return false;
            }
            return true;
        }
        #endregion
    }
    #endregion


    public class TriangleIndices
    {
        #region Constructor
        public TriangleIndices(ulong v0, ulong v1, ulong v2, ulong n0, ulong n1, ulong n2, ulong uv0, ulong uv1, ulong uv2)
        {
            _vertex[0] = v0; _vertex[1] = v1; _vertex[2] = v2;
            _normal[0] = n0; _normal[1] = n1; _normal[2] = n2;
            _UV[0] = uv0; _UV[1] = uv1; _UV[2] = uv2;
        }
        #endregion

        public string ConvertToString(ulong iTriangleIndex)
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} "
                , _vertex[0] + iTriangleIndex * 8, _normal[0], _UV[0]
                , _vertex[1] + iTriangleIndex * 8, _normal[1], _UV[1]
                , _vertex[2] + iTriangleIndex * 8, _normal[2], _UV[2]
                );
        }

        #region Data members
        public ulong[] _vertex = new ulong[3];
        public ulong[] _normal = new ulong[3];
        public ulong[] _UV = new ulong[3];
        #endregion
    }
}
