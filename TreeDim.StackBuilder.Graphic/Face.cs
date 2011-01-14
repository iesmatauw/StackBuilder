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
    #region Segment
    public class Segment
    {
        #region Private members
        private uint _pickingId = 0;
        private Vector3D[] _points = new Vector3D[2];
        private Color _color = Color.Black;
        #endregion

        #region Constructor
        public Segment(Vector3D pt0, Vector3D pt1, Color color)
        {
            _points[0] = pt0; _points[1] = pt1; _color = color;
        }
        #endregion

        #region Public properties
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public Vector3D[] Points
        {
            get { return _points; }
        }
        #endregion

        #region Public methods
        #endregion

        #region Object override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Segment => PickId : {0} Points : ", _pickingId));
            foreach (Vector3D v in _points)
                sb.Append(v.ToString());
            return sb.ToString();
        }
        #endregion
    }
    #endregion

    #region Face
    public class Face
    {
        #region Private members
        private uint _pickingId = 0;
        private Vector3D[] _points;
        public bool[] _isIntersection;
        /// <summary>
        /// colors
        /// </summary>
        private Color _colorFill = Color.Red;
        private Color _colorPath = Color.Black;
        /// <summary>
        /// textures
        /// </summary>
        private List<Texture> _textureList = new List<Texture>();
        #endregion

        #region Constructor
        public Face(uint pickId, Vector3D[] vertices)
        {
            _points = vertices;
            _isIntersection = new bool[vertices.Length];
            for (int i = 0; i < vertices.Length; ++i) _isIntersection[i] = false;
            if (_points.Length < 3)
                throw new GraphicsException("Face is degenerated");
            _pickingId = pickId;
        }
        public Face(uint pickId, Vector3D[] vertices, Color colorFill, Color colorPath)
        {
            _points = vertices;
            _isIntersection = new bool[vertices.Length];
            for (int i = 0; i < vertices.Length; ++i) _isIntersection[i] = false;
            if (_points.Length < 3)
                throw new GraphicsException("Face is degenerated");
            _pickingId = pickId;
            _colorFill = colorFill;
            _colorPath = colorPath;
        }

        public Face(uint pickId, Vector3D[] vertices, bool[] isInter)
        {
            _points = vertices;
            _isIntersection = isInter;
            if (_points.Length < 3)
                throw new GraphicsException("Face is degenerated");
            _pickingId = pickId;
        }
        /// <summary>
        /// Face constructor
        /// </summary>
        /// <param name="pickId">Picking id</param>
        /// <param name="pt0">Lower left point</param>
        /// <param name="pt1">Lower right point</param>
        /// <param name="pt2">Upper right point</param>
        /// <param name="pt3">Upper left point</param>
        public Face(uint pickId, Vector3D pt0, Vector3D pt1, Vector3D pt2, Vector3D pt3)
        {
            _pickingId = pickId;
            _points = new Vector3D[4];
            _points[0] = pt0;
            _points[1] = pt1;
            _points[2] = pt2;
            _points[3] = pt3;
        }
        #endregion

        #region Public properties

        /// <summary>
        /// fill color of face
        /// </summary>
        public Color ColorFill
        {
            get { return _colorFill; }
            set { _colorFill = value; }
        }
        /// <summary>
        /// path color of face
        /// </summary>
        public Color ColorPath
        {
            get { return _colorPath; }
            set { _colorPath = value; }
        }
        /// <summary>
        /// The array of 3D Points corresponding to the corners of this Face
        /// </summary>
        public Vector3D[] Points
        {
            get { return _points; }
        }

        /// <summary>
        /// The center point of the face
        /// </summary>
        public Vector3D Center
        {
            get
            {
                Vector3D vCenter = Vector3D.Zero;
                foreach (Vector3D v in _points)
                    vCenter += v;
                return vCenter * (1.0 / _points.Length);
            }
        }
        /// <summary>
        /// The unit normal of the face
        /// </summary>
        public Vector3D Normal
        {
            get
            {
                Vector3D vecNormal = Vector3D.CrossProduct(_points[1] - _points[0], _points[2] - _points[0]);
                if (vecNormal.GetLength() < MathFunctions.EpsilonD)
                    throw new GraphicsException("Face is degenerated");
                vecNormal.Normalize();
                return vecNormal;
            }
        }
        /// <summary>
        /// The picking id of the face
        /// </summary>
        public uint PickingId
        {
            get { return _pickingId; }
        }
        /// <summary>
        /// Has bitmap
        /// </summary>
        public bool HasBitmap
        {
            get { return (null != _textureList) && (_textureList.Count > 0); }
        }
        /// <summary>
        /// Bitmap
        /// </summary>
        public List<Texture> Textures
        {
            set { _textureList = value; }
            get { return _textureList; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Gives point placement relative to face
        /// </summary>
        /// <param name="pt">Tested point</param>
        /// <returns>
        /// -> 1 : interior
        /// -> 0 : on face
        /// -> -1 : exterior
        /// </returns>
        public int PointRelativePosition(Vector3D pt)
        {
            const double eps = 1.0E-06;
            double dotProd = Vector3D.DotProduct(pt - Center, Normal);
            if (Math.Abs(dotProd) < eps)
                return 0;
            else if (dotProd > 0)
                return 1; // ext
            else
                return -1; // int
        }

        public bool IsVisible(Vector3D viewDir)
        {
            return Vector3D.DotProduct(viewDir, Normal) < 0.0;
        }

        public bool PointIsBehind(Vector3D pt, Vector3D viewDir)
        {
            const double eps = 0.0001;
            return (Vector3D.DotProduct(pt - Center, Normal) * Vector3D.DotProduct(viewDir, Normal)) > eps;
        }

        public bool PointIsInFront(Vector3D pt, Vector3D viewDir)
        {
            const double eps = 0.0001;
            return (Vector3D.DotProduct(pt - Center, Normal) * Vector3D.DotProduct(viewDir, Normal)) < eps;
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Face => PickId : {0} Points : ", _pickingId));
            foreach (Vector3D point in _points)
                sb.Append(point.ToString());
            return sb.ToString();
        }
        #endregion
    }
    #endregion

    #region Face comparison
    public class FaceComparison : IComparer<Face>
    {
        #region Constructor
        /// <summary>
        /// Constructor FaceComparison
        /// </summary>
        /// <param name="transform">Transform</param>
        public FaceComparison(Transform3D transform)
        {
            _transform = transform;
        }
        #endregion

        #region Implementation IComparer
        /// <summary>
        /// Implementation of IComparer
        /// </summary>
        /// <param name="f1">Face f1</param>
        /// <param name="f2">Face f2</param>
        /// <returns>integer "f1>f2 => 1", "f1<f2 => -1", "f1==f2 => 0"  </returns>
        public int Compare(Face f1, Face f2)
        {
            int mode = 0;
            if (0 == mode) // use barycenter.Z in global coordinate then in distance
            {
                if (f1.Center.Z > f2.Center.Z)
                    return 1;
                else if (f1.Center.Z == f2.Center.Z)
                {
                    if (_transform.transform(f1.Center).Z < _transform.transform(f2.Center).Z)
                        return 1;
                    else if (_transform.transform(f1.Center).Z == _transform.transform(f2.Center).Z)
                        return 0;
                    else
                        return -1;
                }
                else
                    return -1;
            }
            else if (1 == mode) // use barycenter distance to eye only
            {
                if (_transform.transform(f1.Center).Z < _transform.transform(f2.Center).Z)
                    return 1;
                else if (_transform.transform(f1.Center).Z == _transform.transform(f2.Center).Z)
                    return 0;
                else
                    return -1;
            }
            else
            {
                double length1 = 0.0, length2 = 0.0;
                foreach (Vector3D pt in f1.Points)
                    length1 += _transform.transform(pt).Z;
                foreach (Vector3D pt in f2.Points)
                    length2 += _transform.transform(pt).Z;

                if (length1 < length2)
                    return 1;
                else if (length1 == length2)
                    return 0;
                else
                    return -1;
            }
        }
        #endregion

        #region Data members
        Transform3D _transform;
        #endregion
    }
    #endregion
}
