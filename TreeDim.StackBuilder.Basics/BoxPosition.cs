#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
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
        public HalfAxis.HAxis DirectionHeight
        {
            get
            {
                if (!IsValid)
                    throw new Exception("Invalid position -> Can not compute DirectionHeight.");
                return HalfAxis.ToHalfAxis(Vector3D.CrossProduct(HalfAxis.ToVector3D(_axisLength), HalfAxis.ToVector3D(_axisWidth)));
            }
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
                Matrix4D mat = Matrix4D.Identity;
                mat.M11 = vAxisLength.X; mat.M12 = vAxisWidth.X; mat.M13 = vAxisHeight.X; mat.M14 = _vPosition.X;
                mat.M21 = vAxisLength.Y; mat.M22 = vAxisWidth.Y; mat.M23 = vAxisHeight.Y; mat.M24 = _vPosition.Y;
                mat.M31 = vAxisLength.Z; mat.M32 = vAxisWidth.Z; mat.M33 = vAxisHeight.Z; mat.M34 = _vPosition.Z;
                return new Transform3D(mat);
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
}
