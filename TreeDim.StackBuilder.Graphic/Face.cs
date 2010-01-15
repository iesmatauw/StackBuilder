#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    #region Face
    public class Face
    {
        #region Private members
        uint _pickingId = 0;
        Vector3D[] _points;
        Color _colorFill = Color.Red;
        Color _colorPath = Color.Black;
        #endregion

        #region Constructor
        public Face(uint pickId, Vector3D[] vertices)
        {
            _points = vertices;
            if (_points.Length < 3)
                throw new GraphicsException("Face is degenerated");
            _pickingId = pickId;
        }

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
        public Color ColorFill
        {
            get { return _colorFill; }
            set { _colorFill = value; }
        }
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
        public FaceComparison(Transform3D transform)
        {
            _transform = transform;
        }
        #endregion

        #region Implementation IComparer
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
