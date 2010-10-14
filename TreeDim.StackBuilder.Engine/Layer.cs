#region Using directives
using System.Collections.Generic;
using System.Text;
using Sharp3D.Math.Core;

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

        #region Public properties
        public Vector3D Position { get { return _position; } }
        public HalfAxis.HAxis LengthAxis { get { return _lengthAxis; } }
        public HalfAxis.HAxis WidthAxis { get { return _widthAxis; } }
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
        private double _boxLength = 0.0, _boxWidth = 0.0, _boxHeight = 0.0;
        private double _palletLength = 0.0, _palletWidth = 0.0;
        private Vector3D _vecTransf = Vector3D.Zero; 
        #endregion

        #region Constructor
        public Layer(BProperties boxProperties, PalletProperties palletProperties, ConstraintSet constraintSet, HalfAxis.HAxis axisOrtho)
        {
            _axisOrtho = axisOrtho;
            _palletLength = palletProperties.Length + 2.0 * constraintSet.OverhangX;
            _palletWidth = palletProperties.Width + 2.0 * constraintSet.OverhangY;
            Initialize(boxProperties);
        }

        public Layer(Solution sol, TruckProperties truckProperties, TruckConstraintSet constraintSet)
        {
            _axisOrtho = HalfAxis.HAxis.AXIS_Z_P;
            _palletLength = truckProperties.Length;
            _palletWidth = truckProperties.Width;
            Initialize(sol);
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

        private void Initialize(Solution sol)
        { }
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
                if (pt.X < 0 || pt.X > _palletLength || pt.Y < 0 || pt.Y > _palletWidth)
                    return false;
            }
            return true;
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

            LayerPosition layerPos = new LayerPosition(
                originTranslation.transform(new Vector3D(vPosition.X, vPosition.Y, 0.0))
                , HalfAxis.ToHalfAxis(localTransfInv.transform(HalfAxis.ToVector3D(_lengthAxis)))
                , HalfAxis.ToHalfAxis(localTransfInv.transform(HalfAxis.ToVector3D(_widthAxis)))
                );

            
            
            

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
        #endregion
    }
}
