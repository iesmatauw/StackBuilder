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
        PalletAnalysis _analysis;
        PalletSolution _solution;
        List<TruckAnalysis> _truckAnalyses = new List<TruckAnalysis>();
        #endregion

        #region Constructor
        internal SelSolution(Document document, PalletAnalysis analysis, PalletSolution sol)
            : base(document)
        {
            _analysis = analysis;
            _analysis.AddDependancie(this);

            _solution = sol;
            Name = sol.Title; 
        }
        #endregion

        #region Truck analyses
        /// <summary>
        /// Creates a new truck analysis based on solution
        /// </summary>
        /// <param name="name">Analysis name</param>
        /// <param name="description">Description</param>
        /// <param name="truckProperties">Truck</param>
        /// <param name="constraintSet">ConstraintSet</param>
        /// <param name="solver">Solver to use to generate solutions</param>
        /// <returns></returns>
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
        /// <summary>
        /// Creates new truck analysis based on solution
        /// This method used when loading truck analysis from file
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="truckProperties"></param>
        /// <param name="constraintSet"></param>
        /// <param name="solutions"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Returns true if SelSolution has some truck analyses
        /// </summary>
        public bool HasTruckAnalyses
        {
            get { return _truckAnalyses.Count > 0; }
        }
        /// <summary>
        /// Removes a truck analysis
        /// </summary>
        /// <param name="truckAnalysis">Removed truck analysis</param>
        public void RemoveTruckAnalysis(TruckAnalysis truckAnalysis)
        {
            ParentDocument.RemoveItem(truckAnalysis);
            _truckAnalyses.Remove(truckAnalysis);
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Encapsulated solution
        /// </summary>
        public PalletSolution Solution
        {
            get { return _solution; }
        }
        /// <summary>
        /// Parent analysis
        /// </summary>
        public PalletAnalysis Analysis
        {
            get { return _analysis; }
        }
        /// <summary>
        /// List of depending truck analyses
        /// </summary>
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
