#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class TruckSolution : IComparable
    {
        #region Data members
        #endregion

        #region Constructor
        #endregion

        #region Public properties
        int PalletCount
        {
            get { return 0; }
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            TruckSolution sol = (TruckSolution)obj;
            if (this.PalletCount > sol.PalletCount)
                return -1;
            else if (this.PalletCount == sol.PalletCount)
                return 0;
            else
                return 1;
        }
        #endregion
    }
}
