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
    public class LayerCyl : List<Vector2D>
    {
        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(LayerCyl));
        private double _palletLength = 0.0, _palletWidth = 0.0;
        private double _cylinderRadius = 0.0, _cylinderHeight = 0.0;
        #endregion

        #region Constructor
        public LayerCyl(CylinderProperties cylProperties, PalletProperties palletProperties, CylinderPalletConstraintSet constraintSet)
        {
            _palletLength = palletProperties.Length + 2.0 * constraintSet.OverhangX;
            _palletWidth = palletProperties.Width + 2.0 * constraintSet.OverhangY;
            Initialize(cylProperties);
        }
        #endregion

        #region Private methods
        private void Initialize(CylinderProperties cylProperties)
        {
            _cylinderRadius = cylProperties.Radius;
            _cylinderHeight = cylProperties.Height;
        }
        #endregion

        #region Public methods
        public bool IsValidPosition(Vector2D vPosition)
        {
            if (vPosition.X - _cylinderRadius < 0
                || vPosition.X + _cylinderRadius > _palletLength
                || vPosition.Y - _cylinderRadius < 0
                || vPosition.Y + _cylinderRadius > _palletWidth)
                return false;
            return true;
        }
        public bool IntersectWithContent(Vector2D vPosition)
        {
            foreach (Vector2D v in this)
            {
                if ((v - vPosition).GetLength() < _cylinderRadius)
                    return true; // new position intersect current content
            }
            return false; // no intersection with current content
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
        public double CylinderHeight
        {
            get { return _cylinderHeight; }
        }
        #endregion
    }
}
