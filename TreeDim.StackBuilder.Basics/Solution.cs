#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region HalfAxis enum and Convert class
    public enum HalfAxis
    {
        AXIS_X_N // -X
      , AXIS_X_P // X
      , AXIS_Y_N // -Y
      , AXIS_Y_P // Y
      , AXIS_Z_N // -Z
      , AXIS_Z_P // Z
    }

    public class Convert
    {
        #region Static conversion methods
        public static Vector3D ToVector3D(HalfAxis axis)
        {
            switch (axis)
            {
                case HalfAxis.AXIS_X_N: return -Vector3D.XAxis;
                case HalfAxis.AXIS_X_P: return Vector3D.XAxis;
                case HalfAxis.AXIS_Y_N: return -Vector3D.YAxis;
                case HalfAxis.AXIS_Y_P: return Vector3D.YAxis;
                case HalfAxis.AXIS_Z_N: return -Vector3D.ZAxis;
                default:                return Vector3D.ZAxis;
            }
        }
        public static HalfAxis ToHalfAxis(Vector3D v)
        {
            const double eps = 1.0E-03;
            v.Normalize();
            if (Math.Abs(Vector3D.DotProduct(v, -Vector3D.XAxis) - 1) < eps)
                return HalfAxis.AXIS_X_N;
            else if (Math.Abs(Vector3D.DotProduct(v, Vector3D.XAxis) - 1) < eps)
                return HalfAxis.AXIS_X_P;
            else if (Math.Abs(Vector3D.DotProduct(v, -Vector3D.YAxis) - 1) < eps)
                return HalfAxis.AXIS_Y_N;
            else if (Math.Abs(Vector3D.DotProduct(v, Vector3D.YAxis) - 1) < eps)
                return HalfAxis.AXIS_Y_P;
            else if (Math.Abs(Vector3D.DotProduct(v, -Vector3D.ZAxis) - 1) < eps)
                return HalfAxis.AXIS_Z_N;
            else
                return HalfAxis.AXIS_Z_P;
        }
        public static string ToString(HalfAxis axis)
        {
            switch (axis)
            {
                case HalfAxis.AXIS_X_N: return "-X";
                case HalfAxis.AXIS_X_P: return " X";
                case HalfAxis.AXIS_Y_N: return "-Y";
                case HalfAxis.AXIS_Y_P: return " Y";
                case HalfAxis.AXIS_Z_N: return "-Z";
                case HalfAxis.AXIS_Z_P: return " Z";
                default: return " Z";
            }
        }
        #endregion
    }
    #endregion

    #region Solution
    /// <summary>
    /// Box position
    /// </summary>
    public class BoxPosition
    {
        #region Data members
        private Vector3D _vPosition = new Vector3D();
        private HalfAxis _axisLength, _axisWidth;
        #endregion

        #region Constructor
        public BoxPosition(Vector3D vPosition, HalfAxis dirLength, HalfAxis dirWidth)
        {
            _vPosition = vPosition;
            _axisLength = dirLength;
            _axisWidth = dirWidth;
        }
        #endregion

        #region Public properties
        public Vector3D Position
        {
            get { return _vPosition; }
        }
        public HalfAxis DirectionLength
        {
            get { return _axisLength; }
        }
        public HalfAxis DirectionWidth
        {
            get { return _axisWidth; }
        }
        #endregion

        #region Object method overrides
        public override string ToString()
        {
            return string.Format("{0} | ({1},{2})", _vPosition, Convert.ToString(_axisLength), Convert.ToString(_axisWidth));
        }
        #endregion
    }
    /// <summary>
    /// A set of box position and orientation that represent a valid solution
    /// </summary>
    public class Solution : List<BoxPosition>, IComparable
    {
        #region Data members
        string _title;
        #endregion

        #region Constructor
        public Solution(string title)
        {
            _title = title;
        }
        #endregion

        #region Public properties
        string Title
        {
            get { return _title; }
        }
        #endregion

        #region Public methods
        public void AddPosition(Vector3D vPosition, HalfAxis dirLength, HalfAxis dirWidth)
        { 
            Add(new BoxPosition(vPosition, dirLength, dirWidth));
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            Solution sol = (Solution)obj;
            if (this.Count > sol.Count)
                return -1;
            else if (this.Count == sol.Count)
                return 0;
            else
                return 1;
        }
        #endregion

        #region Object method overrides
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("=== Solution ===> {0} items", this.Count));
            int index = 0;
            foreach (BoxPosition boxPosition in this)
                sb.AppendLine(string.Format("{0} : {1}", index++, boxPosition.ToString()));
            return sb.ToString();
        }
        #endregion
    }
    #endregion
}
