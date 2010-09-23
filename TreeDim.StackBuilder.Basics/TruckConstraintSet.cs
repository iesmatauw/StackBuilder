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
        #endregion

        #region Constructor
        public TruckConstraintSet()
        { 
        }
        #endregion

        #region Public properties
        public bool MultilayerAllowed
        {
            get { return _multilayerAllowed; }
        }
        #endregion
    }
}
