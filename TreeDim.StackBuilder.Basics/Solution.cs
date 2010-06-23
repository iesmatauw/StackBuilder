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
        public static string ToString(HAxis axis)
        {
            switch (axis)
            {
                case HAxis.AXIS_X_N: return "-X";
                case HAxis.AXIS_X_P: return " X";
                case HAxis.AXIS_Y_N: return "-Y";
                case HAxis.AXIS_Y_P: return " Y";
                case HAxis.AXIS_Z_N: return "-Z";
                case HAxis.AXIS_Z_P: return " Z";
                default: return " Z";
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
    public class BoxPosition
    {
        #region Data members
        private Vector3D _vPosition = new Vector3D();
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
        }
        public HalfAxis.HAxis DirectionLength
        {
            get { return _axisLength; }
        }
        public HalfAxis.HAxis DirectionWidth
        {
            get { return _axisWidth; }
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
        #endregion

        #region Constructor
        public Solution(string title, bool homogenousLayer)
        {
            _title = title;
            _homogeneousLayer = homogenousLayer;
        }
        #endregion

        #region Public properties
        public string Title
        {
            get { return _title; }
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
            return 100.0 * BoxCount * analysis.BoxProperties.Volume
                /
                (
                    (analysis.PalletProperties.Length - analysis.ConstraintSet.OverhangX)
                    * (analysis.PalletProperties.Width - analysis.ConstraintSet.OverhangY)
                    * (analysis.ConstraintSet.MaximumHeight - analysis.PalletProperties.Height)
                );
        }
        public double PalletWeight(Analysis analysis)
        {
            return analysis.PalletProperties.Weight + BoxCount * analysis.BoxProperties.Weight;
        }
        public double PalletHeight(Analysis analysis)
        {
            return this[Count - 1].ZLow + analysis.BoxProperties.Height;
        }
        public Image PatternImage
        {
            get
            {
                Bitmap bmp = new Bitmap(200,75);
                Graphics g = System.Drawing.Graphics.FromImage(bmp);
                g.FillRectangle(Brushes.Blue, 0, 0, 200, 75);
                return bmp;
            }
        }
        public bool HasHomogeneousLayers
        {
            get { return _homogeneousLayer; }
            set { _homogeneousLayer = value; }
        }
        #endregion

        #region Public methods
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