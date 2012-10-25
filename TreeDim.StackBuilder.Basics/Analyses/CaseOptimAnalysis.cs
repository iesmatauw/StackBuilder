#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    /// <summary>
    /// 
    /// </summary>
    public class CaseOptimAnalysis : ItemBase
    {
        #region Data members
        #endregion

        #region Constructor
        public CaseOptimAnalysis(
            BProperties boxProperties
            , PalletProperties palletProperties
            , PalletConstraintSet palletConstraintSet
            , CaseOptimConstraintSet caseOptimConstraintSet)
            : base(boxProperties.ParentDocument)
        {
        }
        #endregion
    }
}
