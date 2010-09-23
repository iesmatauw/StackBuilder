#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class TruckAnalysis : ItemBase
    {
        #region Data members
        Analysis _analysis;
        Solution _solution;
        TruckProperties _truckProperties;
        TruckConstraintSet _constraintSet;
        List<TruckSolution> _truckSolutions = new List<TruckSolution>();
        #endregion

        #region Constructor
        public TruckAnalysis(
            Document document
            , Analysis analysis
            , Solution solution
            , TruckProperties truckProperties
            , TruckConstraintSet constraintSet)
            : base(document)
        {
            _analysis = analysis;
            _solution = solution;
            _truckProperties = truckProperties;
            _constraintSet = constraintSet;
        }
        #endregion
    }
}
