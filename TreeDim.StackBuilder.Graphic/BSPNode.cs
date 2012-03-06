#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using System.Diagnostics;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    internal class BSPNode : IDisposable
    {
        #region Data members
        public Face _face;
        private double _a, _b, _c, _d;
        public BSPNode _nodeLeft, _nodeRight, _nodeCoincident ;
        #endregion

        #region Constructor
        public BSPNode(Face face)
        {
            _face = face;
            initEquation(face, out _a, out _b, out _c, out _d);
        }
        #endregion

        #region Insertion methods
        public void insert(Face face)
        {
            Face faceleft, faceRight, faceCoincident;
            Split(face, out faceleft, out faceRight, out faceCoincident);
            if (null != faceleft)
            {
                if (null == _nodeLeft)
                    _nodeLeft = new BSPNode(faceleft);
                else
                    _nodeLeft.insert(faceleft);
            }
            if (null != faceRight)
            {
                if (null == _nodeRight)
                    _nodeRight = new BSPNode(faceRight);
                else
                    _nodeRight.insert(faceRight);
            }
            if (null != faceCoincident)
            {
                if (null == _nodeCoincident)
                    _nodeCoincident = new BSPNode(faceCoincident);
                else
                    _nodeCoincident.insert(faceCoincident);
            }
        }

        public void recursFillFaceArray(ref List<Face> faces)
        {
            if (_nodeRight != null)
                _nodeRight.recursFillFaceArray(ref faces);
            faces.Add(_face);
            if (_nodeLeft != null)
                _nodeLeft.recursFillFaceArray(ref faces);
        }
        #endregion

        #region Private methods
        private void initEquation(Face face, out double a, out double b, out double c, out double d)
        {
            const double EQUALITY_EPS = 0.00001;
            Vector3D n = Vector3D.CrossProduct(face.Points[1] - face.Points[0], face.Points[2] - face.Points[0]);
            if (n.GetLengthSquared() <= EQUALITY_EPS)
            {
                a = 0.0; b = 0.0; c = 0.0; d = 0.0;
                return;
            }
            double D = n.GetLength();
            if (n[2] < 0.0)
                n = n * (1.0 / -D);
            else
                n = n * (1.0 / D);

            d = Vector3D.DotProduct(n, face.Points[0]);

            a = n[0];
            b = n[1];
            c = n[2];
        }

        public double classifyPoint(Vector3D pt)
        { 
            return Vector3D.DotProduct(pt, new Vector3D(_a, _b, _c)) - _d;
        }

        private int testPoint(Vector3D pt)
        {
            const double EQUALITY_EPS = 0.01;
            double Z = pt.X * _a + pt.Y * _b + pt.Z * _c - _d;
            if (Z > EQUALITY_EPS)
                return 1;
            else if (Z < -EQUALITY_EPS)
                return -1;
            else
                return 0;
        }

        private bool testLine(Vector3D pt0, Vector3D pt1, out Vector3D ptInter)
        {
            double EQUALITY_EPS = 0.00001;
            Vector3D normal = _face.Normal;
            if (Math.Abs(Vector3D.DotProduct(normal, pt1 - pt0)) < EQUALITY_EPS)
            {
                ptInter = pt0;
                return false;
            }
            double s = Vector3D.DotProduct(normal, _face.Points[0] - pt0) / Vector3D.DotProduct(normal, pt1 - pt0);
            ptInter = pt0 + s * (pt1 - pt0);
            return true;
        }

        int Split(Face face, out Face faceSplit1, out Face faceSplit2, out Face faceCoincident)
        {
            // check if coincident
            int noCoincident = 0;
            foreach (Vector3D pt in face.Points)
            {
                if (0 == testPoint(pt))
                    ++noCoincident;
            }
            if (4 == noCoincident)
            {
                faceCoincident = face;
                faceSplit1 = null;
                faceSplit2 = null;
                return 1;
            }

            List<Vector3D> outpts = new List<Vector3D>(), inpts = new List<Vector3D>();
            List<bool> outPath = new List<bool>(), inPath = new List<bool>();
            int count = face.Points.Length;
            Vector3D ptA = face.Points[count - 1];
            double sideA = classifyPoint(ptA);
            for (int i = -1; ++i < count;)
            {
                Vector3D ptB = face.Points[i];
                double sideB = classifyPoint(ptB);
                if (sideB > 0)
                {
                    if (sideA < 0)
                    {
                        // compute the intersection point of the line
                        // from point A to point B with the partition
                        // plane. This is a simple ray-plane intersection.
                        Vector3D v = ptB - ptA;
                        double sect = -classifyPoint(ptA) / Vector3D.DotProduct(_face.Normal, v);
                        Vector3D ptI = ptA - v * sect;
                        outpts.Add(ptI);    outPath.Add(true);
                        inpts.Add(ptI);     inPath.Add(true);
                    }
                }
                else if (sideB < 0)
                {
                    if (sideA > 0)
                    {
                        // compute the intersection point of the line
                        // from point A to point B with the partition
                        // plane. This is a simple ray-plane intersection.
                        Vector3D v = ptB - ptA;
                        double sect = -classifyPoint(ptA) / Vector3D.DotProduct(_face.Normal, v);
                        Vector3D ptI = ptA - v * sect;
                        outpts.Add(ptI);    outPath.Add(true);
                        inpts.Add(ptI);     inPath.Add(true);
                    }
                }
                else
                {
                    outpts.Add(ptB);
                    inpts.Add(ptB);
                }
                ptA = ptB;
                sideA = sideB;
            }
            if (outpts.Count == 4)
            {
                faceSplit1 = new Face(face.PickingId, outpts.ToArray(), outPath.ToArray());
                faceSplit1.ColorFill = face.ColorFill;
                faceSplit1.ColorPath = face.ColorPath;
            }
            else
                faceSplit1 = null;

            if (inpts.Count == 4)
            {
                faceSplit2 = new Face(face.PickingId, inpts.ToArray(), inPath.ToArray());
                faceSplit2.ColorFill = face.ColorFill;
                faceSplit2.ColorPath = face.ColorPath;
            }
            else
                faceSplit2 = null;

            faceCoincident = null;

            return 1;
        }

        /*
        int Split(Face face, out Face faceSplit1, out Face faceSplit2, out Face faceCoincident)
        {
            int[] v = new int[face.Points.Length];
            int val = 0, i = 0;

            foreach (Vector3D pt in face.Points)
            {
                v[i] = testPoint(pt);
                val += v[i];
                ++i;
            }

            if (val > 0)
            {
                faceSplit1 = face;
                faceSplit2 = null;
                faceCoincident = null;
                return 1;
            }
            else if (val < 0)
            {
                faceSplit1 = null;
                faceSplit2 = face;
                faceCoincident = null;
                return 1;
            }
            else // triangle is inside plane, assign to positive node
            {
                if (face.Center.Z > _face.Center.Z)
                {
                    faceSplit1 = null;
                    faceSplit2 = face;
                    faceCoincident = null;
                }
                else if (face.Center.Z < _face.Center.Z)
                {
                    faceSplit1 = face;
                    faceSplit2 = null;
                    faceCoincident = null;
                }
                else
                {
                    faceSplit1 = null;
                    faceSplit2 = null;
                    faceCoincident = face;                
                }
                return 1;
            }
        }
        */
        public void Print(string offset)
        {
            Console.WriteLine(offset + _face.PickingId.ToString() + "===> " + _face.ToString());
            if (_nodeLeft != null)          _nodeLeft.Print(offset + "---l-");
            if (_nodeCoincident != null)    _nodeCoincident.Print(offset + "---c-");
            if (_nodeRight != null)         _nodeRight.Print(offset + "---r-");
        }
        #endregion

        #region IDisposable interface
        public void Dispose()
        {
            _nodeLeft.Dispose();
            _nodeLeft = null;
            _nodeRight.Dispose();
            _nodeRight = null;
        }
        #endregion
    }
}
