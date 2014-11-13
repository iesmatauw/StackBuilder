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
        private double _palletLength = 0.0, _palletWidth = 0.0;
        private double _cylinderRadius = 0.0, _cylinderLength = 0.0;
        #endregion

        #region Constructor
        public CylLoad(CylinderProperties cylProperties, PalletProperties palletProperties, HCylinderPalletConstraintSet constraintSet)
        {
            _palletLength = palletProperties.Length + constraintSet.OverhangX;
            _palletWidth = palletProperties.Width + constraintSet.OverhangY;
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
                    if (cylPosition.Position.X - _cylinderLength < 0.0) return false;
                    if (cylPosition.Position.X > _palletLength) return false;
                    if (cylPosition.Position.Y - _cylinderRadius < 0.0) return false;
                    if (cylPosition.Position.Y + _cylinderRadius > _palletWidth) return false;
                    break;
                case HalfAxis.HAxis.AXIS_X_P:
                    if (cylPosition.Position.X < 0.0) return false;
                    if (cylPosition.Position.X - _cylinderLength > _palletLength) return false;
                    if (cylPosition.Position.Y - _cylinderRadius < 0.0) return false;
                    if (cylPosition.Position.Y + _cylinderRadius > _palletWidth) return false;
                    break;
                case HalfAxis.HAxis.AXIS_Y_N:
                    if (cylPosition.Position.Y - _cylinderLength < 0) return false;
                    if (cylPosition.Position.Y > _palletWidth) return false;
                    if (cylPosition.Position.X - _cylinderRadius < 0) return false;
                    if (cylPosition.Position.X + _cylinderRadius > _palletLength) return false;
                    break;
                case HalfAxis.HAxis.AXIS_Y_P:
                    if (cylPosition.Position.Y < 0) return false;
                    if (cylPosition.Position.Y + _cylinderLength > _palletWidth) return false;
                    if (cylPosition.Position.X - _cylinderRadius < 0) return false;
                    if (cylPosition.Position.X + _cylinderRadius > _palletLength) return false;
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
                Vector3D vDiff = c.Position - cylPosition.Position;
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
        public double CylinderRadius
        {
            get { return _cylinderRadius; }
        }
        public double CylinderLength
        {
            get { return _cylinderLength; }
        }
        #endregion
    }
}
