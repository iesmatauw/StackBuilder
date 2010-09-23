#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class SelSolution : ItemBase
    {
        #region Data members
        Analysis _analysis;
        Solution _solution;
        List<TruckAnalysis> _truckAnalyses;
        #endregion

        #region Constructor
        SelSolution(Document document, Analysis analysis, Solution sol)
            : base(document)
        {
            _analysis = analysis;
            _solution = sol; 
        }
        #endregion

        #region Truck analyses
        void CreateNewTruckAnalysis(TruckProperties truckProperties, TruckConstraintSet constraintSet)
        {
            _truckAnalyses.Add(new TruckAnalysis(this.ParentDocument, _analysis, _solution, truckProperties, constraintSet));
        }
        #endregion
    }
}
