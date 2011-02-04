#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class HalfAxis
    {
        #region Values
        public enum HAxis
        {
            AXIS_X_N // -X
          , AXIS_X_P // X
          , AXIS_Y_N // -Y
          , AXIS_Y_P // Y
          , AXIS_Z_N // -Z
          , AXIS_Z_P // Z
        }
        #endregion

        #region Static conversion methods
        public static Vector3D ToVector3D(HAxis axis)
        {
            switch (axis)
            {
                case HAxis.AXIS_X_N: return -Vector3D.XAxis;
                case HAxis.AXIS_X_P: return Vector3D.XAxis;
                case HAxis.AXIS_Y_N: return -Vector3D.YAxis;
                case HAxis.AXIS_Y_P: return Vector3D.YAxis;
                case HAxis.AXIS_Z_N: return -Vector3D.ZAxis;
                default:                return Vector3D.ZAxis;
            }
        }
        public static HAxis ToHalfAxis(Vector3D v)
        {
            const double eps = 1.0E-03;
            v.Normalize();
            if (Math.Abs(Vector3D.DotProduct(v, -Vector3D.XAxis) - 1) < eps)
                return HAxis.AXIS_X_N;
            else if (Math.Abs(Vector3D.DotProduct(v, Vector3D.XAxis) - 1) < eps)
                return HAxis.AXIS_X_P;
            else if (Math.Abs(Vector3D.DotProduct(v, -Vector3D.YAxis) - 1) < eps)
                return HAxis.AXIS_Y_N;
            else if (Math.Abs(Vector3D.DotProduct(v, Vector3D.YAxis) - 1) < eps)
                return HAxis.AXIS_Y_P;
            else if (Math.Abs(Vector3D.DotProduct(v, -Vector3D.ZAxis) - 1) < eps)
                return HAxis.AXIS_Z_N;
            else
                return HAxis.AXIS_Z_P;
        }
        public static HAxis Transform(HAxis axis, Transform3D transform)
        {
            return HalfAxis.ToHalfAxis(transform.transformRot(HalfAxis.ToVector3D(axis)));
        }
        public static string ToString(HAxis axis)
        {
            switch (axis)
            {
                case HAxis.AXIS_X_N: return "XN";
                case HAxis.AXIS_X_P: return "XP";
                case HAxis.AXIS_Y_N: return "YN";
                case HAxis.AXIS_Y_P: return "YP";
                case HAxis.AXIS_Z_N: return "ZN";
                case HAxis.AXIS_Z_P: return "ZP";
                default: return "ZP";
            }
        }
        public static HAxis Parse(string sAxis)
        {
            if (string.Equals(sAxis, "XN", StringComparison.CurrentCultureIgnoreCase)) return HAxis.AXIS_X_N;
            else if (string.Equals(sAxis, "XP", StringComparison.CurrentCultureIgnoreCase)) return HAxis.AXIS_X_P;
            else if (string.Equals(sAxis, "YN", StringComparison.CurrentCultureIgnoreCase)) return HAxis.AXIS_Y_N;
            else if (string.Equals(sAxis, "YP", StringComparison.CurrentCultureIgnoreCase)) return HAxis.AXIS_Y_P;
            else if (string.Equals(sAxis, "ZN", StringComparison.CurrentCultureIgnoreCase)) return HAxis.AXIS_Z_N;
            else if (string.Equals(sAxis, "ZP", StringComparison.CurrentCultureIgnoreCase)) return HAxis.AXIS_Z_P;
            throw new Exception(string.Format("Invalid HalfAxis value {0}", sAxis));
        }
        #endregion
    }
}
