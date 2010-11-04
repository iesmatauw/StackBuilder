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
        public TruckAnalysis CreateNewTruckAnalysis(string name, string description, TruckProperties truckProperties, TruckConstraintSet constraintSet, ITruckSolver solver)
        {
            TruckAnalysis truckAnalysis = new TruckAnalysis(this.ParentDocument, _analysis, this, truckProperties, constraintSet);
            truckAnalysis.Name = name;
            truckAnalysis.Description = description;
            _truckAnalyses.Add(truckAnalysis);
            AddDependancie(truckAnalysis);
            solver.ProcessAnalysis(truckAnalysis);
            ParentDocument.NotifyOnNewTruckAnalysisCreated(_analysis, this, truckAnalysis);
            ParentDocument.Modify();

            return truckAnalysis;
        }
        public TruckAnalysis CreateNewTruckAnalysis(string name, string description, TruckProperties truckProperties, TruckConstraintSet constraintSet, List<TruckSolution> solutions)
        {
            TruckAnalysis truckAnalysis = new TruckAnalysis(this.ParentDocument, _analysis, this, truckProperties, constraintSet);
            truckAnalysis.Name = name;
            truckAnalysis.Description = description;
            truckAnalysis.Solutions = solutions;
            _truckAnalyses.Add(truckAnalysis);
            AddDependancie(truckAnalysis);
            ParentDocument.NotifyOnNewTruckAnalysisCreated(_analysis, this, truckAnalysis);
            ParentDocument.Modify();

            return truckAnalysis;
        }

        public bool HasTruckAnalyses
        {
            get { return _truckAnalyses.Count > 0; }
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
        public List<TruckAnalysis> TruckAnalyses
        {
            get { return _truckAnalyses; }
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
