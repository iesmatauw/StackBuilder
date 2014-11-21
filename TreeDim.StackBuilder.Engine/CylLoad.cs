#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TreeDim.StackBuilder.Basics;

using Sharp3D.Math.Core;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    class CylLoad : List<CylPosition>
    {
        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(CylLoad));
        private double _palletLength = 0.0, _palletWidth = 0.0, _palletHeight = 0.0;
        private double _cylinderRadius = 0.0, _cylinderLength = 0.0;
        private double _rowSpacing = 0.0;
        private Limit _limitReached = Limit.LIMIT_UNKNOWN;
        #endregion

        #region Constructor
        public CylLoad(CylinderProperties cylProperties, PalletProperties palletProperties, HCylinderPalletConstraintSet constraintSet)
        {
            _palletLength = palletProperties.Length + constraintSet.OverhangX;
            _palletWidth = palletProperties.Width + constraintSet.OverhangY;
            _palletHeight = palletProperties.Height;
            _rowSpacing = constraintSet.RowSpacing;
            Initialize(cylProperties);
        }
        #endregion

        #region Private methods
        private void Initialize(CylinderProperties cylProperties)
        {
            _cylinderRadius = cylProperties.RadiusOuter;
            _cylinderLength = cylProperties.Height;
        }
        #endregion

        #region Public methods
        public bool IsValidPosition(CylPosition cylPosition)
        {
            switch (cylPosition.Direction)
            {
                case HalfAxis.HAxis.AXIS_X_N:
                    if (cylPosition.XYZ.X - _cylinderLength < 0.0) return false;
                    if (cylPosition.XYZ.X > _palletLength) return false;
                    if (cylPosition.XYZ.Y - _cylinderRadius < 0.0) return false;
                    if (cylPosition.XYZ.Y + _cylinderRadius > _palletWidth) return false;
                    break;
                case HalfAxis.HAxis.AXIS_X_P:
                    if (cylPosition.XYZ.X < 0.0) return false;
                    if (cylPosition.XYZ.X - _cylinderLength > _palletLength) return false;
                    if (cylPosition.XYZ.Y - _cylinderRadius < 0.0) return false;
                    if (cylPosition.XYZ.Y + _cylinderRadius > _palletWidth) return false;
                    break;
                case HalfAxis.HAxis.AXIS_Y_N:
                    if (cylPosition.XYZ.Y - _cylinderLength < 0) return false;
                    if (cylPosition.XYZ.Y > _palletWidth) return false;
                    if (cylPosition.XYZ.X - _cylinderRadius < 0) return false;
                    if (cylPosition.XYZ.X + _cylinderRadius > _palletLength) return false;
                    break;
                case HalfAxis.HAxis.AXIS_Y_P:
                    if (cylPosition.XYZ.Y < 0) return false;
                    if (cylPosition.XYZ.Y + _cylinderLength > _palletWidth) return false;
                    if (cylPosition.XYZ.X - _cylinderRadius < 0) return false;
                    if (cylPosition.XYZ.X + _cylinderRadius > _palletLength) return false;
                    break;
                default:
                    return false;
            }
            return true;
        }
        public bool IntersectWithContent(CylPosition cylPosition)
        {
            Vector3D cylDirection = HalfAxis.ToVector3D(cylPosition.Direction);

            foreach (CylPosition c in this)
            {
                Vector3D vDiff = c.XYZ - cylPosition.XYZ;
                double axisProj = Vector3D.DotProduct(cylDirection, vDiff);
                Vector3D vDiffProj = vDiff - axisProj * cylDirection;
                if (axisProj < _cylinderLength && vDiffProj.GetLength() < _cylinderRadius)
                    return true;
            }
            return false;
        }
        #endregion

        #region Public properties
        public double PalletLength
        {
            get { return _palletLength; }
        }
        public double PalletWidth
        {
            get { return _palletWidth; }
        }
        public double PalletHeight
        {
            get { return _palletHeight; }
        }
        public double CylinderRadius
        {
            get { return _cylinderRadius; }
        }
        public double CylinderLength
        {
            get { return _cylinderLength; }
        }
        public double RowSpacing
        {
            get { return _rowSpacing; }
        }

        public Limit LimitReached
        {
            get { return _limitReached; }
            set { _limitReached = value; }
        }
        #endregion
    }
}
