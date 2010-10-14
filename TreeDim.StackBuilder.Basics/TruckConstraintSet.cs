#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class TruckConstraintSet
    {
        #region Data members
        private bool _multilayerAllowed;
        private bool _allowPalletOrientationX;
        private bool _allowPalletOrientationY;
        private double _minDistancePalletTruckWall;
        private double _minDistancePalletTruckRoof;
        #endregion

        #region Constructor
        public TruckConstraintSet()
        {
            _multilayerAllowed = true;
        }
        #endregion

        #region Public properties
        public bool MultilayerAllowed
        {
            get { return _multilayerAllowed; }
            set { _multilayerAllowed = value; }
        }
        public bool AllowPalletOrientationX
        {
            get { return _allowPalletOrientationX; }
            set { _allowPalletOrientationX = value; }
        }
        public bool AllowPalletOrientationY
        {
            get { return _allowPalletOrientationY; }
            set { _allowPalletOrientationY = value; }
        }
        public double MinDistancePalletTruckWall
        {
            get { return _minDistancePalletTruckWall; }
            set { _minDistancePalletTruckWall = value; }
        }
        public double MinDistancePalletTruckRoof
        {
            get { return _minDistancePalletTruckRoof; }
            set { _minDistancePalletTruckRoof = value; }
        }
        #endregion

        #region Validity
        #endregion

    }
}
