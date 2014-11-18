#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region Case / pallet selected solution
    public class SelCasePalletSolution : ItemBase
    {
        #region Data members
        private CasePalletAnalysis _analysis;
        private CasePalletSolution _solution;
        private List<TruckAnalysis> _truckAnalyses = new List<TruckAnalysis>();
        private List<ECTAnalysis> _ectAnalyses = new List<ECTAnalysis>();
        #endregion

        #region Constructor
        public SelCasePalletSolution(Document document, CasePalletAnalysis analysis, CasePalletSolution sol)
            : base(document)
        {
            _analysis = analysis;
            _analysis.AddDependancy(this);

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
            AddDependancy(truckAnalysis);
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
            AddDependancy(truckAnalysis);
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

        #region ECT analysis
        public ECTAnalysis CreateNewECTAnalysis(string name, string description)
        {
            ECTAnalysis ectAnalysis = new ECTAnalysis(this.ParentDocument, _analysis, this);
            _ectAnalyses.Add(ectAnalysis);
            AddDependancy(ectAnalysis);
            ParentDocument.NotifyOnNewECTAnalysisCreated(_analysis, this, ectAnalysis);
            ParentDocument.Modify();

            return ectAnalysis;
        }

        public bool HasECTAnalyses
        {
            get { return _ectAnalyses.Count > 0; }
        }
        /// <summary>
        /// Removes an ect analysis
        /// </summary>
        /// <param name="ectAnalysis"></param>
        public void RemoveECTAnalysis(ECTAnalysis ectAnalysis)
        {
            ParentDocument.RemoveItem(ectAnalysis);
            _ectAnalyses.Remove(ectAnalysis);
        }

        /// <summary>
        /// List of depending truck analyses
        /// </summary>
        public List<ECTAnalysis> EctAnalyses
        {
            get { return _ectAnalyses; }
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Encapsulated solution
        /// </summary>
        public CasePalletSolution Solution
        {
            get { return _solution; }
        }
        /// <summary>
        /// Parent analysis
        /// </summary>
        public CasePalletAnalysis Analysis
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
            _analysis.RemoveDependancy(this);
            base.RemoveItselfFromDependancies();
        }
        #endregion
    }
    #endregion

    #region Cylinder / pallet selected solution
    public class SelCylinderPalletSolution : ItemBase
    {
        #region Data members
        private CylinderPalletAnalysis _analysis;
        private CylinderPalletSolution _solution;
        private List<TruckAnalysis> _truckAnalyses = new List<TruckAnalysis>();
        #endregion

        #region Constructor
        public SelCylinderPalletSolution(Document document, CylinderPalletAnalysis analysis, CylinderPalletSolution sol)
            : base(document)
        {
            _analysis = analysis;
            _analysis.AddDependancy(this);

            _solution = sol;
            Name = sol.Title;
        }
        #endregion

        #region Truck analyses
        #endregion

        #region Public properties
        /// <summary>
        /// Encapsulated solution
        /// </summary>
        public CylinderPalletSolution Solution
        {
            get { return _solution; }
        }
        /// <summary>
        /// Parent analysis
        /// </summary>
        public CylinderPalletAnalysis Analysis
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
            _analysis.RemoveDependancy(this);
            base.RemoveItselfFromDependancies();
        }
        #endregion
    }
    public class SelHCylinderPalletSolution : ItemBase
    {
        #region Data members
        private HCylinderPalletAnalysis _analysis;
        private HCylinderPalletSolution _solution;
        private List<TruckAnalysis> _truckAnalyses = new List<TruckAnalysis>();
        #endregion

        #region Constructor
        public SelHCylinderPalletSolution(Document document, HCylinderPalletAnalysis analysis, HCylinderPalletSolution sol)
            : base(document)
        {
            _analysis = analysis;
            _analysis.AddDependancy(this);

            _solution = sol;
            Name = sol.Title;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Encapsulated solution
        /// </summary>
        public HCylinderPalletSolution Solution
        {
            get { return _solution; }
        }
        /// <summary>
        /// Parent analysis
        /// </summary>
        public HCylinderPalletAnalysis Analysis
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
            _analysis.RemoveDependancy(this);
            base.RemoveItselfFromDependancies();
        }
        #endregion
    }
    #endregion


    #region Box / case selected solution
    public class SelBoxCaseSolution : ItemBase
    {
        #region Data members
        private BoxCaseAnalysis _analysis;
        private BoxCaseSolution _solution;
        #endregion

        #region Constructor
        public SelBoxCaseSolution(Document document, BoxCaseAnalysis analysis, BoxCaseSolution sol)
            : base(document)
        {
            _analysis = analysis;
            _analysis.AddDependancy(this);

            _solution = sol;
            Name = sol.Title;
        }
        #endregion

        #region Public properties
        public BoxCaseSolution Solution
        {
            get { return _solution; }
        }
        #endregion

        #region ItemBase override
        #endregion
    }
    #endregion

    #region Box / Case / Pallet solution
    public class SelBoxCasePalletSolution : ItemBase
    {
        #region Data members
        private BoxCasePalletAnalysis _analysis;
        private BoxCasePalletSolution _solution;
        #endregion

        #region Constructor
        public SelBoxCasePalletSolution(Document document, BoxCasePalletAnalysis analysis, BoxCasePalletSolution sol)
            : base(document)
        {
            _analysis = analysis;
            _solution = sol;
            Name = sol.Title;
        }
        #endregion

        #region Public properties
        public BoxCasePalletAnalysis Analysis
        {
            get { return _analysis; }
        }
        public BoxCasePalletSolution Solution
        {
            get { return _solution; }
        }
        #endregion

        #region ItemBase override
        protected override void RemoveItselfFromDependancies()
        {
            _analysis.RemoveDependancy(this);
            base.RemoveItselfFromDependancies();
        }
        #endregion
    }
    #endregion
}
