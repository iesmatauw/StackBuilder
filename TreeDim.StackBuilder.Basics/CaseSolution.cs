#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class CaseSolution : IComparable
    {
        #region Data members
        List<BoxPosition> _boxPositions = new List<BoxPosition>();
        Solution _palletSolution;
        #endregion
        #region Constructor
        #endregion

        #region Public properties
        public int BoxCount
        {
            get { return _boxPositions.Count * _palletSolution.CaseCount; }
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            CaseSolution sol = (CaseSolution)obj;
            if (this.BoxCount > sol.BoxCount)
                return -1;
            else if (this.BoxCount == sol.BoxCount)
                return 0;
            else
                return 1; 
        }
        #endregion
    }
}
