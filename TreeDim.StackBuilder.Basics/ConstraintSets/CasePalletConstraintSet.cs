using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDim.StackBuilder.Basics
{
    public class CasePalletConstraintSet : PalletConstraintSet
    {
        #region Data members
        private bool _hasInterlayer;
        private int _interlayerPeriod;
        private bool[] _allowedOrthoAxis = new bool[6];
        private bool _useMaximumWeightOnBox;
        private double _maximumWeightOnBox;
        #endregion

        #region Constructor
        public CasePalletConstraintSet()
        {
            for (int i = 0; i < 6; ++i) _allowedOrthoAxis[i] = false;
        }
        #endregion

        #region Interlayer
        public override bool HasInterlayer
        {
            get { return _hasInterlayer; }
            set { _hasInterlayer = value; }
        }
        public override int InterlayerPeriod
        {
            get { return _interlayerPeriod; }
            set { _interlayerPeriod = value; }
        }
        #endregion

        #region Allowed box axis
        public override bool AllowOrthoAxis(HalfAxis.HAxis orthoAxis)
        {
            return _allowedOrthoAxis[(int)orthoAxis];
        }
        public void SetAllowedOrthoAxis(HalfAxis.HAxis axis, bool allowed)
        {
            _allowedOrthoAxis[(int)axis] = allowed;
        }
        #endregion

        #region Stop conditions
        public override bool UseMaximumWeightOnBox
        {
            set { _useMaximumWeightOnBox = value; }
            get { return _useMaximumWeightOnBox; }
        }
        public override double MaximumWeightOnBox
        {
            get { return _maximumWeightOnBox; }
            set { _maximumWeightOnBox = value; }
        }
        #endregion
    }
}
