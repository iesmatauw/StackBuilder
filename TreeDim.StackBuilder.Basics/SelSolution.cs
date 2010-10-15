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
        public TruckAnalysis CreateNewTruckAnalysis(TruckProperties truckProperties, TruckConstraintSet constraintSet, ITruckSolver solver)
        {
            TruckAnalysis truckAnalysis = new TruckAnalysis(this.ParentDocument, _analysis, _solution, truckProperties, constraintSet);
            _truckAnalyses.Add(truckAnalysis);
            solver.ProcessAnalysis(truckAnalysis);
            ParentDocument.NotifyOnNewTruckAnalysisCreated(_analysis, this, truckAnalysis);
            ParentDocument.Modify();

            return truckAnalysis;
        }
        #endregion

        #region Public properties
        public Solution Solution
        {
            get { return _solution; }
        }
        public Analysis Analysis
        {
            get { return _analysis; }
        }
        #endregion

        #region ItemBase override
        protected override void RemoveItselfFromDependancies()
        {
            _analysis.RemoveDependancie(this);
            base.RemoveItselfFromDependancies();
        }
        #endregion
    }
}
