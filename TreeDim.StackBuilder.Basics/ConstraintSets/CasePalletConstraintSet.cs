using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDim.StackBuilder.Basics
{
    public class CasePalletConstraintSet : PalletConstraintSet
    {
        #region Data members
        private bool _hasInterlayer = false, _hasInterlayerAntiSlip = false;
        private int _interlayerPeriod;
        private bool[] _allowedOrthoAxis = new bool[6];
        private bool _useMaximumWeightOnBox;
        private double _maximumWeightOnBox;
        private bool _allowTwoLayerOrientations = false, _allowLastLayerOrientationChange = false;
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
        public override bool HasInterlayerAntiSlip
        {
            get { return _hasInterlayerAntiSlip; }
            set { _hasInterlayerAntiSlip = value; }
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
        public override bool AllowTwoLayerOrientations
        {
            get { return _allowTwoLayerOrientations; }
            set { _allowTwoLayerOrientations = value; }
        }
        public override bool AllowLastLayerOrientationChange
        {
            get { return _allowLastLayerOrientationChange; }
            set { _allowLastLayerOrientationChange = value; }
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
