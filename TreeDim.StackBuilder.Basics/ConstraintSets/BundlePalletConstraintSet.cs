using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDim.StackBuilder.Basics
{
    public class BundlePalletConstraintSet : PalletConstraintSet
    {
        #region Interlayer
        public override bool HasInterlayer
        {
            get { return false; }
            set { }
        }
        public override int InterlayerPeriod
        {
            get { return 0; }
            set { }
        }
        #endregion

        #region Allowed box axis
        public override bool AllowOrthoAxis(HalfAxis.HAxis orthoAxis)
        {
            return (orthoAxis == HalfAxis.HAxis.AXIS_Z_N) || (orthoAxis == HalfAxis.HAxis.AXIS_Z_P);
        }
        public override bool AllowTwoLayerOrientations
        {
            get { return false; }
            set { }
        }
        public override bool AllowLastLayerOrientationChange
        {
            get { return false; }
            set { }
        } 
        #endregion

        #region Stop conditions
        public override bool UseMaximumWeightOnBox
        {
            get { return false; }
            set { }
        }
        public override double MaximumWeightOnBox
        {
            get { return 0.0; }
            set { }
        }
        #endregion
    }
}
