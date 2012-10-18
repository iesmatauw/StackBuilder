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
    public class CylinderLayer : List<Vector2D>
    {
        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(CylinderLayer));
        private double _palletLength = 0.0, _palletWidth = 0.0;
        private double _cylinderRadius = 0.0, _cylinderHeight = 0.0;
        #endregion

        #region Constructor
        public CylinderLayer(CylinderProperties cylProperties, PalletProperties palletProperties)
        {
            _palletLength = palletProperties.Length;
            _palletWidth = palletProperties.Width;
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
            return true;
        }
        public bool IntersectWithContent(Vector2D vPosition)
        {
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
        public double CylinderHeight
        {
            get { return _cylinderHeight; }
        }
        #endregion
    }
}
