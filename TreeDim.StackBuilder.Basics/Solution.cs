#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Sharp3D.Math.Core;
using System.Drawing;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region HalfAxis
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
    #endregion

    #region BoxPosition
    /// <summary>
    /// Box position
    /// </summary>
    public struct BoxPosition
    {
        #region Data members
        private Vector3D _vPosition;
        private HalfAxis.HAxis _axisLength, _axisWidth;
        #endregion

        #region Constructor
        public BoxPosition(Vector3D vPosition, HalfAxis.HAxis dirLength, HalfAxis.HAxis dirWidth)
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
            set { _vPosition = value; }
        }
        public HalfAxis.HAxis DirectionLength
        {
            get { return _axisLength; }
        }
        public HalfAxis.HAxis DirectionWidth
        {
            get { return _axisWidth; }
        }
        public bool IsValid
        {
            get { return _axisLength != _axisWidth; }
        }
        #endregion

        #region Transformation
        public Transform3D Transformation
        {
            get
            {
                // build 4D matrix
                Vector3D vAxisLength = HalfAxis.ToVector3D(_axisLength);
                Vector3D vAxisWidth = HalfAxis.ToVector3D(_axisWidth);
                Vector3D vAxisHeight = Vector3D.CrossProduct(vAxisLength, vAxisWidth);
                Matrix4D matRot = Matrix4D.Identity;
                matRot.M11 = vAxisLength.X;
                matRot.M12 = vAxisLength.Y;
                matRot.M13 = vAxisLength.Z;
                matRot.M21 = vAxisWidth.X;
                matRot.M22 = vAxisWidth.Y;
                matRot.M23 = vAxisWidth.Z;
                matRot.M31 = vAxisHeight.X;
                matRot.M32 = vAxisHeight.Y;
                matRot.M33 = vAxisHeight.Z;
                Matrix4D matTransl = Matrix4D.Identity;
                matTransl.M14 = _vPosition.X;
                matTransl.M24 = _vPosition.Y;
                matTransl.M34 = _vPosition.Z;
                return new Transform3D(matTransl * matRot);
            }
        }
        public static BoxPosition Transform(BoxPosition boxPosition, Transform3D transform)
        {
            if (!boxPosition.IsValid)
                throw new Exception("Invalid box position : can not transform");


            return new BoxPosition(
                transform.transform(boxPosition.Position)
                , HalfAxis.ToHalfAxis(transform.transformRot(HalfAxis.ToVector3D(boxPosition.DirectionLength)))
                , HalfAxis.ToHalfAxis(transform.transformRot(HalfAxis.ToVector3D(boxPosition.DirectionWidth)))
                );
        }
        #endregion

        #region Object method overrides
        public override string ToString()
        {
            return string.Format("{0} | ({1},{2})", _vPosition, HalfAxis.ToString(_axisLength), HalfAxis.ToString(_axisWidth));
        }
        #endregion
    }
    #endregion

    #region Layer classes (box layer + interlayer)
    /// <summary>
    /// Layer interface to be implemented by either BoxLayer or InterlayerPos
    /// </summary>
    public interface ILayer
    {
        double ZLow { get; }
        int BoxCount { get; }
        int InterlayerCount { get; }
    }

    public class InterlayerPos : ILayer
    {
        #region Data members
        private double _zLower = 0.0;
        #endregion

        #region Constructor
        public InterlayerPos(double zLow)
        {
            _zLower = zLow;
        }
        #endregion

        #region ILayer implementation
        public double ZLow
        {
            get { return _zLower; }
        }
        public int BoxCount
        {
            get { return 0; }
        }
        public int InterlayerCount
        {
            get { return 1; }
        }
        #endregion
    }

    /// <summary>
    /// A layer of box
    /// </summary>
    public class BoxLayer : List<BoxPosition>, ILayer
    {
        #region Data members
        double _zLower = 0.0;
        #endregion

        #region Constructor
        public BoxLayer(double zLow)
        {
            _zLower = zLow;
        }
        #endregion

        #region Public properties
        public double ZLow
        {
            get { return _zLower; }
        }
        public int BoxCount
        {
            get { return Count; }
        }

        public int InterlayerCount
        {
            get { return 0; }
        }
        #endregion

        #region Public methods
        public void AddPosition(Vector3D vPosition, HalfAxis.HAxis dirLength, HalfAxis.HAxis dirWidth)
        {
            Add(new BoxPosition(vPosition, dirLength, dirWidth));
        }
        #endregion
    }
    #endregion

    #region Solution
    /// <summary>
    /// A set of box position and orientation that represent a valid solution
    /// </summary>
    public class Solution : List<ILayer>, IComparable  
    {
        #region Data members
        private string _title;
        private bool _homogeneousLayer = false;
        private Analysis _parentAnalysis = null;
        #endregion

        #region Constructor
        public Solution(Analysis analysis, string title, bool homogenousLayer)
        {
            _parentAnalysis = analysis;
            _title = title;
            _homogeneousLayer = homogenousLayer;
        }
        #endregion

        #region Public properties
        public string Title
        {
            get { return _title; }
        }
        public Analysis Analysis
        {
            get { return _parentAnalysis; }
            set { _parentAnalysis = value; }
        }
        public int BoxCount
        {
            get
            {
                int iCount = 0;
                foreach (ILayer layer in this)
                    iCount += layer.BoxCount;
                return iCount;
            }
        }
        public int InterlayerCount
        {
            get
            {
                int iCount = 0;
                foreach (ILayer layer in this)
                    iCount += layer.InterlayerCount;
                return iCount;
            }
        }
        public double Efficiency(Analysis analysis)
        {
            return 100.0 * BoxCount * analysis.BProperties.Volume
                /
                (
                    (analysis.PalletProperties.Length - analysis.ConstraintSet.OverhangX)
                    * (analysis.PalletProperties.Width - analysis.ConstraintSet.OverhangY)
                    * (analysis.ConstraintSet.MaximumHeight - analysis.PalletProperties.Height)
                );
        }
        public double PalletWeight(Analysis analysis)
        {
            return analysis.PalletProperties.Weight + BoxCount * analysis.BProperties.Weight;
        }
        public double PalletHeight(Analysis analysis)
        {
            return this[Count - 1].ZLow + analysis.BProperties.Height;
        }
        public bool HasHomogeneousLayers
        {
            get { return _homogeneousLayer; }
            set { _homogeneousLayer = value; }
        }
        #endregion

        #region Adding layer / interlayer
        public BoxLayer CreateNewLayer(double zLow)
        {
            BoxLayer layer = new BoxLayer(zLow);
            Add(layer);
            return layer;
        }
        public InterlayerPos CreateNewInterlayer(double zLow)
        {
            InterlayerPos layer = new InterlayerPos(zLow);
            Add(layer);
            return layer;
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            Solution sol = (Solution)obj;
            if (this.BoxCount > sol.BoxCount)
                return -1;
            else if (this.BoxCount == sol.BoxCount)
                return 0;
            else
                return 1;
        }
        #endregion

        #region Object method overrides
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("=== Solution ===> {0} layers -> {1} boxes", this.Count, this.BoxCount));
            int index = 0;
            foreach (BoxLayer layer in this)
                foreach (BoxPosition boxPosition in layer)
                    sb.AppendLine(string.Format("{0} : {1}", index++, boxPosition.ToString()));
            return sb.ToString();
        }
        #endregion
    }
    #endregion
}