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
        List<TruckAnalysis> _truckAnalyses = new List<TruckAnalysis>();
        #endregion

        #region Constructor
        internal SelSolution(Document document, Analysis analysis, Solution sol)
            : base(document)
        {
            _analysis = analysis;
            _analysis.AddDependancie(this);

            _solution = sol;
            Name = sol.Title; 
        }
        #endregion

        #region Truck analyses
        void CreateNewTruckAnalysis(TruckProperties truckProperties, TruckConstraintSet constraintSet)
        {
            _truckAnalyses.Add(new TruckAnalysis(this.ParentDocument, _analysis, _solution, truckProperties, constraintSet));
        }
        #endregion

        #region Public properties
        public Solution Solution
        {
            get { return _solution; }
        }
        #endregion
    }
}
