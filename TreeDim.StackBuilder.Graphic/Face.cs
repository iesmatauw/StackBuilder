#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    #region Texture class
    public class Texture
    {
        #region Data members
        /// <summary>
        /// Texture bitmap
        /// </summary>
        private Bitmap _bitmap = null;
        /// <summary>
        /// Image position 
        /// </summary>
        private Vector2D _position = new Vector2D();
        /// <summary>
        /// Image size
        /// </summary>
        private Vector2D _size = new Vector2D();
        #endregion

        #region Constructor
        public Texture(Bitmap bitmap, Vector2D position, Vector2D size)
        {
            _bitmap = bitmap;
            _position = position;
            _size = size;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Bitmap
        /// </summary>
        public Bitmap Bitmap
        {
            get { return _bitmap; }
            set { _bitmap = value; }
        }
        /// <summary>
        /// Image position
        /// </summary>
        public Vector2D Position
        {
            get { return _position; }
            set { _position = value; }
        }
        /// <summary>
        /// Image size
        /// </summary>
        public Vector2D Size
        {
            get { return _size; }
            set { _size = value; }
        }
        #endregion
    }
    #endregion

    #region Face
    public class Face
    {
        #region Private members
        uint _pickingId = 0;
        Vector3D[] _points;
        /// <summary>
        /// colors
        /// </summary>
        Color _colorFill = Color.Red;
        Color _colorPath = Color.Black;
        List<Texture> _textureList = new List<Texture>();
        #endregion

        #region Constructor
        public Face(uint pickId, Vector3D[] vertices)
        {
            _points = vertices;
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
        /// PointsImage
        /// </summary>
        /// <param name="texture">Texture (bitmap + Vector2D + Vector2D)</param>
        /// <returns>Vector3D</returns>
        public Vector3D[] PointsImage(Texture texture)
        {
            Vector3D[] pts = new Vector3D[4];
            Vector3D vecI = (_points[1] - _points[0]); vecI.Normalize();
            Vector3D vecJ = (_points[3] - _points[0]); vecJ.Normalize();

            pts[0] = _points[0] + texture.Position.X * vecI + texture.Position.Y * vecJ;
            pts[1] = _points[0] + (texture.Position.X + texture.Size.X) * vecI + texture.Position.Y * vecJ;
            pts[2] = _points[0] + (texture.Position.X + texture.Size.X) * vecI + (texture.Position.Y + texture.Size.Y) * vecJ;
            pts[3] = _points[0] + texture.Position.X * vecI + (texture.Position.Y + texture.Size.Y) * vecJ;

            return pts;
        }
        /// <summary>
        /// The center point of the face
        /// </summary>
        public Vector3D Center
        {
            get
            {
                Vector3D vCenter = new Vector3D();
                foreach (Vector3D v in _points)
                    vCenter += v;
                return vCenter * 1.0 / _points.Length;
            }
        }
        /// <summary>
        /// The unit normal of the face
        /// </summary>
        public Vector3D Normal
        {
            get
            {
                Vector3D vecNormal = Vector3D.CrossProduct(_points[2] - _points[0], _points[1] - _points[0]);
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
        #endregion

        #region Object override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Face => PickId : {0} Points : ", _pickingId));
            foreach (Vector3D point in _points)
            {
                sb.Append(point.ToString());
            }
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
            if (_transform.transform(f1.Center).Z < _transform.transform(f2.Center).Z)
                return 1;
            else if (_transform.transform(f1.Center).Z == _transform.transform(f2.Center).Z)
                return 0;
            else
                return -1;
        }
        #endregion

        #region Data members
        Transform3D _transform;
        #endregion
    }
    #endregion
}
