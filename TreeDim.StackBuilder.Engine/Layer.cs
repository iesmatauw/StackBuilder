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
        public LayerPosition(Vector3D position, HalfAxis lengthAxis, HalfAxis widthAxis)
        {
            _position = position;
            _lengthAxis = lengthAxis;
            _widthAxis = widthAxis;
        }
        #endregion

        #region Public properties
        public Vector3D Position { get { return _position; } }
        public HalfAxis LengthAxis { get { return _lengthAxis; } }
        public HalfAxis WidthAxis { get { return _widthAxis; } }
        #endregion

        #region Data members
        private Vector3D _position;
        private HalfAxis _lengthAxis, _widthAxis;
        #endregion
    }

    public class Layer : List<LayerPosition>
    {
        #region Data members
        private HalfAxis _axisOrtho = HalfAxis.AXIS_Z_P;
        private HalfAxis _lengthAxis = HalfAxis.AXIS_X_P, _widthAxis = HalfAxis.AXIS_Y_P;
        private double _boxLength = 0.0, _boxWidth = 0.0, _boxHeight;
        private double _palletLength = 0.0, _palletWidth = 0.0;
        private Vector3D _vecTransf = Vector3D.Zero; 
        #endregion

        #region Constructor
        public Layer(BoxProperties boxProperties, PalletProperties palletProperties, HalfAxis axisOrtho)
        {
            _axisOrtho = axisOrtho;
            _palletLength = palletProperties.Length;
            _palletWidth = palletProperties.Width;
            Initialize(boxProperties);
        }
        #endregion

        #region Private methods
        private void Initialize(BoxProperties boxProperties)
        {
            switch (_axisOrtho)
            {
                case HalfAxis.AXIS_X_N:
                    _boxLength = boxProperties.Width;
                    _boxWidth = boxProperties.Height;
                    _boxHeight = boxProperties.Length;
                    _lengthAxis = HalfAxis.AXIS_Z_N;
                    _widthAxis = HalfAxis.AXIS_X_N;
                    _vecTransf = new Vector3D(boxProperties.Width, 0.0, boxProperties.Length);
                    break;
                case HalfAxis.AXIS_X_P:
                    _boxLength = boxProperties.Height;
                    _boxWidth = boxProperties.Width;
                    _boxHeight = boxProperties.Length;
                    _lengthAxis = HalfAxis.AXIS_Z_P;
                    _widthAxis = HalfAxis.AXIS_Y_P;
                    _vecTransf = new Vector3D(boxProperties.Height, 0.0, 0.0);
                    break;
                case HalfAxis.AXIS_Y_N:
                    _boxLength = boxProperties.Length;
                    _boxWidth = boxProperties.Height;
                    _boxHeight = boxProperties.Width;
                    _lengthAxis = HalfAxis.AXIS_X_P;
                    _widthAxis = HalfAxis.AXIS_Z_N;
                    _vecTransf = new Vector3D(0.0, 0.0, boxProperties.Width);
                    break;
                case HalfAxis.AXIS_Y_P:
                    _boxLength = boxProperties.Height;
                    _boxWidth = boxProperties.Length;
                    _boxHeight = boxProperties.Width;
                    _lengthAxis = HalfAxis.AXIS_Y_P;
                    _widthAxis = HalfAxis.AXIS_Z_P;
                    _vecTransf = Vector3D.Zero;
                    break;
                case HalfAxis.AXIS_Z_N:
                    _boxLength = boxProperties.Width;
                    _boxWidth = boxProperties.Length;
                    _boxHeight = boxProperties.Height;
                    _lengthAxis = HalfAxis.AXIS_Y_P;
                    _widthAxis = HalfAxis.AXIS_X_P;
                    _vecTransf = new Vector3D(0.0, 0.0, boxProperties.Height);
                    break;
                case HalfAxis.AXIS_Z_P:
                    _boxLength = boxProperties.Length;
                    _boxWidth = boxProperties.Width;
                    _boxHeight = boxProperties.Height;
                    _lengthAxis = HalfAxis.AXIS_X_P;
                    _widthAxis = HalfAxis.AXIS_Y_P;
                    _vecTransf = Vector3D.Zero;
                    break;
                default:
                    _boxLength = boxProperties.Length;
                    _boxWidth = boxProperties.Width;
                    _boxHeight = boxProperties.Height;
                    _lengthAxis = HalfAxis.AXIS_X_P;
                    _widthAxis = HalfAxis.AXIS_Y_P;
                    _vecTransf = Vector3D.Zero;
                    break;
            }
        }
        #endregion

        #region Public methods
        public void AddPosition(Vector2D vPosition, HalfAxis lengthAxis, HalfAxis widthAxis)
        {
            // build 4D matrix
            Vector3D vAxisLength = Convert.ToVector3D(lengthAxis);
            Vector3D vAxisWidth = Convert.ToVector3D(widthAxis);
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
                , Convert.ToHalfAxis(localTransfInv.transform(Convert.ToVector3D(_lengthAxis)))
                , Convert.ToHalfAxis(localTransfInv.transform(Convert.ToVector3D(_widthAxis)))
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
        public HalfAxis AxisOrtho
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
