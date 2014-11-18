#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    /// <summary>
    /// Cylinder position
    /// </summary>
    public struct CylPosition
    {
        #region Data members
        private Vector3D _vPosition;
        private HalfAxis.HAxis _axis;
        #endregion

        #region Constructor
        public CylPosition(Vector3D vPosition, HalfAxis.HAxis axis)
        {
            _vPosition = vPosition;
            _axis = axis;        
        }
        #endregion

        #region Public properties
        public Vector3D XYZ
        {
            get { return _vPosition; }
            set { _vPosition = value; }
        }
        public HalfAxis.HAxis Direction
        {
            get { return _axis; }
            set { _axis = value; }
        }
        public Transform3D Transf
        {
            get
            {
                Matrix4D mat = new Matrix4D();
                Vector4D vt = new Vector4D(XYZ.X, XYZ.Y, XYZ.Z, 1.0);
                switch (_axis)
                {
                    case HalfAxis.HAxis.AXIS_X_N: mat = new Matrix4D(new Vector4D(-1.0, 0.0, 0.0, 0.0), new Vector4D(0.0, -1.0, 0.0, 0.0), new Vector4D(0.0, 0.0, 1.0, 0.0), vt); break;
                    case HalfAxis.HAxis.AXIS_X_P: mat = new Matrix4D(new Vector4D(1.0, 0.0, 0.0, 0.0), new Vector4D(0.0, 1.0, 0.0, 0.0), new Vector4D(0.0, 0.0, 1.0, 0.0), vt); break;
                    case HalfAxis.HAxis.AXIS_Y_N: mat = new Matrix4D(new Vector4D(0.0, -1.0, 0.0, 0.0), new Vector4D(0.0, 0.0, -1.0, 0.0), new Vector4D(1.0, 0.0, 0.0, 0.0), vt); break;
                    case HalfAxis.HAxis.AXIS_Y_P: mat = new Matrix4D(new Vector4D(0.0, 1.0, 0.0, 0.0), new Vector4D(0.0, 0.0, 1.0, 0.0), new Vector4D(1.0, 0.0, 0.0, 0.0), vt); break;
                    case HalfAxis.HAxis.AXIS_Z_N: mat = new Matrix4D(new Vector4D(0.0, 0.0, -1.0, 0.0), new Vector4D(-1.0, 0.0, 0.0, 0.0), new Vector4D(0.0, 1.0, 0.0, 0.0), vt); break;
                    case HalfAxis.HAxis.AXIS_Z_P: mat = new Matrix4D(new Vector4D(0.0, 0.0, 1.0, 0.0), new Vector4D(1.0, 0.0, 0.0, 0.0), new Vector4D(0.0, 1.0, 0.0, 0.0), vt); break;
                    default: break;
                }
                return new Transform3D(mat);
            }
        }
        public BBox3D BBox(double radius, double length)
        {
            Transform3D t = Transf;
            Vector3D[] pts = new Vector3D[]
                {
                    new Vector3D(0.0, -radius, -radius),
                    new Vector3D(0.0, -radius, radius),
                    new Vector3D(0.0, radius, -radius),
                    new Vector3D(0.0, radius, radius),
                    new Vector3D(length, -radius, -radius),
                    new Vector3D(length, -radius, radius),
                    new Vector3D(length, radius, -radius),
                    new Vector3D(length, radius, radius)
                };
            BBox3D bbox = new BBox3D();
            foreach (Vector3D pt in pts)
                bbox.Extend(t.transform(pt));
            return bbox;
        }

        public CylPosition Transform(Transform3D transf)
        {
            return new CylPosition(
                transf.transform(_vPosition),
                HalfAxis.ToHalfAxis(transf.transformRot(HalfAxis.ToVector3D(_axis)))
                );
        }
        #endregion

        #region Transformation
        public static CylPosition Transform(CylPosition cylPosition, Transform3D transform)
        {
            return new CylPosition(
                transform.transform(cylPosition._vPosition),
                HalfAxis.ToHalfAxis(
                    transform.transformRot(HalfAxis.ToVector3D(cylPosition._axis))
                    )
                );
        }
        #endregion
    }
}
