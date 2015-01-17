#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Sharp3D.Math.Core;
using log4net;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    public class LayerPosition
    {
        #region Constructor
        public LayerPosition(Vector3D position, HalfAxis.HAxis lengthAxis, HalfAxis.HAxis widthAxis)
        {
            _position = position;
            _lengthAxis = lengthAxis;
            _widthAxis = widthAxis;
        }
        #endregion

        #region Static methods
        public static bool Intersect(LayerPosition p1, LayerPosition p2, double boxLength, double boxWidth)
        {
            Vector2D v1Min, v1Max, v2Min, v2Max;
            p1.MinMax(boxLength, boxWidth, out v1Min, out v1Max);
            p2.MinMax(boxLength, boxWidth, out v2Min, out v2Max);

            if (v1Max.X <= v2Min.X || v2Max.X <= v1Min.X || v1Max.Y <= v2Min.Y || v2Max.Y <= v1Min.Y)
                return false;
            return true;
        }
        public void MinMax(double boxLength, double boxWidth, out Vector2D vMin, out Vector2D vMax)
        {
            Vector3D[] pts = new Vector3D[4];
            pts[0] = new Vector3D(_position.X, _position.Y, 0.0);
            pts[1] = new Vector3D(_position.X, _position.Y, 0.0) + HalfAxis.ToVector3D(_lengthAxis) * boxLength;
            pts[2] = new Vector3D(_position.X, _position.Y, 0.0) + HalfAxis.ToVector3D(_widthAxis) * boxWidth;
            pts[3] = new Vector3D(_position.X, _position.Y, 0.0) + HalfAxis.ToVector3D(_lengthAxis) * boxLength + HalfAxis.ToVector3D(_widthAxis) * boxWidth;

            vMin = new Vector2D(double.MaxValue, double.MaxValue);
            vMax = new Vector2D(double.MinValue, double.MinValue);
            foreach (Vector3D v in pts)
            {
                vMin.X = Math.Min(v.X, vMin.X);
                vMin.Y = Math.Min(v.Y, vMin.Y);
                vMax.X = Math.Max(v.X, vMax.X);
                vMax.Y = Math.Max(v.Y, vMax.Y);
            }
 
        }
        #endregion

        #region Public properties
        public Vector3D Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public HalfAxis.HAxis LengthAxis
        {
            get { return _lengthAxis; }
            set { _lengthAxis = value; }
        }
        public HalfAxis.HAxis WidthAxis
        {
            get { return _widthAxis; }
            set { _widthAxis = value; }
        }
        public HalfAxis.HAxis HeightAxis
        {
            get
            {
                return HalfAxis.ToHalfAxis(
                    Vector3D.CrossProduct( HalfAxis.ToVector3D(_lengthAxis), HalfAxis.ToVector3D(_widthAxis))
                    );
            } 
        }
        #endregion

        #region Data members
        private Vector3D _position;
        private HalfAxis.HAxis _lengthAxis, _widthAxis;
        #endregion
    }

    public class Layer : List<LayerPosition>
    {
        #region Data members
        private HalfAxis.HAxis _axisOrtho = HalfAxis.HAxis.AXIS_Z_P;
        private HalfAxis.HAxis _lengthAxis = HalfAxis.HAxis.AXIS_X_P, _widthAxis = HalfAxis.HAxis.AXIS_Y_P;
        private bool _inversed = false;
        private double _boxLength = 0.0, _boxWidth = 0.0, _boxHeight = 0.0;
        private double _palletLength = 0.0, _palletWidth = 0.0;
        private Vector3D _vecTransf = Vector3D.Zero;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(Layer));
        #endregion

        #region Constructor
        /// <summary>
        /// Layer pallet analysis constructor (inversed = false)
        /// </summary>
        public Layer(BProperties boxProperties, PalletProperties palletProperties, PalletCornerProperties cornerProperties,
            PalletConstraintSet constraintSet, HalfAxis.HAxis axisOrtho)
        {
            double cornerThickness = null != cornerProperties ? cornerProperties.Thickness : 0.0;
            _axisOrtho = axisOrtho;
            _inversed = false;
            _palletLength = palletProperties.Length + constraintSet.OverhangX - 2.0 * cornerThickness;
            _palletWidth = palletProperties.Width + constraintSet.OverhangY - 2.0 * cornerThickness;
            Initialize(boxProperties);
        }

        /// <summary>
        /// Layer pallet analysis constructor (inversed = false)
        /// </summary>
        public Layer(BProperties boxProperties, PalletProperties palletProperties, PalletCornerProperties cornerProperties,
            PalletConstraintSet constraintSet, HalfAxis.HAxis axisOrtho, bool inversed)
        {
            double cornerThickness = null != cornerProperties ? cornerProperties.Thickness : 0.0;
            _axisOrtho = axisOrtho;
            _inversed = inversed;
            _palletLength = palletProperties.Length + constraintSet.OverhangX - 2.0 * cornerThickness;
            _palletWidth = palletProperties.Width + constraintSet.OverhangY - 2.0 * cornerThickness;
            Initialize(boxProperties);
        }

        /// <summary>
        /// Layer truck analysis constructor
        /// </summary>
        public Layer(CasePalletSolution sol, TruckProperties truckProperties, TruckConstraintSet constraintSet, int orientation)
        {
            switch (orientation)
            {
                case 0: _axisOrtho = HalfAxis.HAxis.AXIS_Z_P; break;
                case 1: _axisOrtho = HalfAxis.HAxis.AXIS_Z_N; break;
                default: _axisOrtho = HalfAxis.HAxis.AXIS_Z_P; break;
            }
            _palletLength = truckProperties.Length - 2.0 * constraintSet.MinDistancePalletTruckWall;
            _palletWidth = truckProperties.Width - 2.0 * constraintSet.MinDistancePalletTruckWall;
            Initialize(sol);
        }
        /// <summary>
        /// Layer case analysis constructor
        /// </summary>
        public Layer(BoxProperties boxProperties, BoxProperties caseProperties, HalfAxis.HAxis axisOrtho)
        {
            _axisOrtho = axisOrtho;
            _palletLength = caseProperties.InsideLength;
            _palletWidth = caseProperties.InsideWidth;
            Initialize(boxProperties);
        }
        #endregion

        #region Private methods
        private void Initialize(BProperties boxProperties)
        {
            switch (_axisOrtho)
            {
                case HalfAxis.HAxis.AXIS_X_N:
                    _boxLength = boxProperties.Width;
                    _boxWidth = boxProperties.Height;
                    _boxHeight = boxProperties.Length;
                    _lengthAxis = HalfAxis.HAxis.AXIS_Z_N;
                    _widthAxis = HalfAxis.HAxis.AXIS_X_N;
                    _vecTransf = new Vector3D(boxProperties.Width, 0.0, boxProperties.Length);
                    break;
                case HalfAxis.HAxis.AXIS_X_P:
                    _boxLength = boxProperties.Height;
                    _boxWidth = boxProperties.Width;
                    _boxHeight = boxProperties.Length;
                    _lengthAxis = HalfAxis.HAxis.AXIS_Z_P;
                    _widthAxis = HalfAxis.HAxis.AXIS_Y_P;
                    _vecTransf = new Vector3D(boxProperties.Height, 0.0, 0.0);
                    break;
                case HalfAxis.HAxis.AXIS_Y_N:
                    _boxLength = boxProperties.Length;
                    _boxWidth = boxProperties.Height;
                    _boxHeight = boxProperties.Width;
                    _lengthAxis = HalfAxis.HAxis.AXIS_X_P;
                    _widthAxis = HalfAxis.HAxis.AXIS_Z_N;
                    _vecTransf = new Vector3D(0.0, 0.0, boxProperties.Width);
                    break;
                case HalfAxis.HAxis.AXIS_Y_P:
                    _boxLength = boxProperties.Height;
                    _boxWidth = boxProperties.Length;
                    _boxHeight = boxProperties.Width;
                    _lengthAxis = HalfAxis.HAxis.AXIS_Y_P;
                    _widthAxis = HalfAxis.HAxis.AXIS_Z_P;
                    _vecTransf = Vector3D.Zero;
                    break;
                case HalfAxis.HAxis.AXIS_Z_N:
                    _boxLength = boxProperties.Width;
                    _boxWidth = boxProperties.Length;
                    _boxHeight = boxProperties.Height;
                    _lengthAxis = HalfAxis.HAxis.AXIS_Y_P;
                    _widthAxis = HalfAxis.HAxis.AXIS_X_P;
                    _vecTransf = new Vector3D(0.0, 0.0, boxProperties.Height);
                    break;
                case HalfAxis.HAxis.AXIS_Z_P:
                    _boxLength = boxProperties.Length;
                    _boxWidth = boxProperties.Width;
                    _boxHeight = boxProperties.Height;
                    _lengthAxis = HalfAxis.HAxis.AXIS_X_P;
                    _widthAxis = HalfAxis.HAxis.AXIS_Y_P;
                    _vecTransf = Vector3D.Zero;
                    break;
                default:
                    _boxLength = boxProperties.Length;
                    _boxWidth = boxProperties.Width;
                    _boxHeight = boxProperties.Height;
                    _lengthAxis = HalfAxis.HAxis.AXIS_X_P;
                    _widthAxis = HalfAxis.HAxis.AXIS_Y_P;
                    _vecTransf = Vector3D.Zero;
                    break;
            }
        }

        private void Initialize(CasePalletSolution sol)
        {
            switch (_axisOrtho)
            {
                case HalfAxis.HAxis.AXIS_Z_N:
                    _boxLength = sol.PalletWidth;
                    _boxWidth = sol.PalletLength;
                    _boxHeight = sol.PalletHeight;
                    _lengthAxis = HalfAxis.HAxis.AXIS_Y_P;
                    _widthAxis = HalfAxis.HAxis.AXIS_X_N;
                    _vecTransf = new Vector3D(_boxLength, 0.0, 0.0);
                    break;
                case HalfAxis.HAxis.AXIS_Z_P:
                    _boxLength = sol.PalletLength;
                    _boxWidth = sol.PalletWidth;
                    _boxHeight = sol.PalletHeight;
                    _lengthAxis = HalfAxis.HAxis.AXIS_X_P;
                    _widthAxis = HalfAxis.HAxis.AXIS_Y_P;
                    _vecTransf = new Vector3D(0.0, 0.0, 0.0);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Public methods
        public bool IsValidPosition(Vector2D vPosition, HalfAxis.HAxis lengthAxis, HalfAxis.HAxis widthAxis)
        { 
            // check layerPos
            // get 4 points
            Vector3D[] pts = new Vector3D[4];
            pts[0] = new Vector3D(vPosition.X, vPosition.Y, 0.0);
            pts[1] = new Vector3D(vPosition.X, vPosition.Y, 0.0) + HalfAxis.ToVector3D(lengthAxis) * _boxLength;
            pts[2] = new Vector3D(vPosition.X, vPosition.Y, 0.0) + HalfAxis.ToVector3D(widthAxis) * _boxWidth;
            pts[3] = new Vector3D(vPosition.X, vPosition.Y, 0.0) + HalfAxis.ToVector3D(lengthAxis) * _boxLength + HalfAxis.ToVector3D(widthAxis) * _boxWidth;
            foreach (Vector3D pt in pts)
            {
                if (pt.X < 0.0 || pt.X > _palletLength  || pt.Y < 0.0 || pt.Y > _palletWidth)
                    return false;
            }
            return true;
        }

        public bool IntersectWithContent(Vector2D vPosition, HalfAxis.HAxis lengthAxis, HalfAxis.HAxis widthAxis)
        {
            LayerPosition posNew = new LayerPosition(new Vector3D(vPosition.X, vPosition.Y, 0.0), lengthAxis, widthAxis);
            foreach (LayerPosition pos in this)
            {
                if (LayerPosition.Intersect(pos, posNew, _boxLength, _boxWidth))
                    return true;
            }
            return false;
        }

        public void AddPosition(Vector2D vPosition, HalfAxis.HAxis lengthAxis, HalfAxis.HAxis widthAxis)
        {
            // build 4D matrix
            Vector3D vAxisLength = HalfAxis.ToVector3D(lengthAxis);
            Vector3D vAxisWidth = HalfAxis.ToVector3D(widthAxis);
            Vector3D vAxisHeight = Vector3D.CrossProduct(vAxisLength, vAxisWidth);
            Matrix4D mat = Matrix4D.Identity;
            mat.M11 = vAxisLength.X;
            mat.M12 = vAxisLength.Y;
            mat.M13 = vAxisLength.Z;
            mat.M21 = vAxisWidth.X;
            mat.M22 = vAxisWidth.Y;
            mat.M23 = vAxisWidth.Z;
            mat.M31 = vAxisHeight.X;
            mat.M32 = vAxisHeight.Y;
            mat.M33 = vAxisHeight.Z;
            Transform3D localTransf = new Transform3D(mat);
            Transform3D localTransfInv = localTransf.Inverse();
            Transform3D originTranslation = Transform3D.Translation(localTransfInv.transform(_vecTransf));

            Vector3D vPos = originTranslation.transform(new Vector3D(vPosition.X, vPosition.Y, 0.0));
            LayerPosition layerPos = new LayerPosition(
                originTranslation.transform(new Vector3D(vPosition.X, vPosition.Y, 0.0))
                , HalfAxis.ToHalfAxis(localTransfInv.transform(HalfAxis.ToVector3D(_lengthAxis)))
                , HalfAxis.ToHalfAxis(localTransfInv.transform(HalfAxis.ToVector3D(_widthAxis)))
                );

            // add position
            this.Add(layerPos);
        }
        #endregion

        #region Public properties
        public double BoxLength
        {
            get { return _boxLength; }
        }
        public double BoxWidth
        {
            get { return _boxWidth; }
        }
        public double BoxHeight
        {
            get { return _boxHeight; }
        }
        public HalfAxis.HAxis AxisOrtho
        {
            get { return _axisOrtho; }
        }
        public double PalletLength
        {
            get { return _palletLength; }
        }
        public double PalletWidth
        {
            get { return _palletWidth; }
        }
        public bool Inversed
        {
            get { return _inversed; }
        }
        #endregion
    }
}
