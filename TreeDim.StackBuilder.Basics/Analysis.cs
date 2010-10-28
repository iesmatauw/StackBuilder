#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using log4net;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region Analysis
    public class Analysis : ItemBase
    {
        #region Data members
        private BProperties _bProperties;
        private PalletProperties _palletProperties;
        private InterlayerProperties _interlayerProperties;
        private ConstraintSet _constraintSet;
        private List<Solution> _solutions;
        private List<SelSolution> _selectedSolutions = new List<SelSolution>();
        private static IAnalysisSolver _solver;
        static readonly ILog _log = LogManager.GetLogger(typeof(Analysis));
        #endregion

        #region Constructor
        public Analysis(BProperties boxProperties, PalletProperties palletProperties, InterlayerProperties interlayerProperties, ConstraintSet constraintSet)
            : base(boxProperties.ParentDocument)
        {
            // sanity check
            if (palletProperties.ParentDocument != ParentDocument
                || (interlayerProperties != null && interlayerProperties.ParentDocument != ParentDocument))
                throw new Exception();

            _bProperties = boxProperties;
            _palletProperties = palletProperties;
            _interlayerProperties = interlayerProperties;
            _constraintSet = constraintSet;

            boxProperties.AddDependancie(this);
            palletProperties.AddDependancie(this);
            if (null != interlayerProperties)
                interlayerProperties.AddDependancie(this);
        }
        #endregion

        #region Public properties
        public List<Solution> Solutions
        {
            set
            {
                _solutions = value;
                foreach (Solution sol in _solutions)
                    sol.Analysis = this;
            }
            get { return _solutions; }
        }

        public BProperties BProperties
        {
            get { return _bProperties; }
            set { _bProperties = value; }
        }

        public PalletProperties PalletProperties
        {
            get { return _palletProperties; }
            set { _palletProperties = value; }
        }

        public bool HasInterlayer
        {
            get { return (null != _interlayerProperties); }
        }

        public InterlayerProperties InterlayerProperties
        {
            get { return _interlayerProperties; }
            set { _interlayerProperties = value; }
        }

        public ConstraintSet ConstraintSet
        {
            get { return _constraintSet; }
            set { _constraintSet = value; }
        }

        public static IAnalysisSolver Solver
        {
            set { _solver = value; }
        }
        #endregion

        #region Solution selection
        public void SelectSolutionByIndex(int index)
        {
            if (index < 0 || index > _solutions.Count) return;  // no solution with this index
            if (HasSolutionSelected(index)) return;             // solution already selected
            // instantiate new SelSolution
            SelSolution selSolution = new SelSolution(ParentDocument, this, _solutions[index]);
            // insert in list
            _selectedSolutions.Add(selSolution);
            // notify document listeners
            ParentDocument.NotifyOnNewSolutionAdded(this, selSolution);
            // set document modified (not analysis, otherwise selected solutions are erased)
            ParentDocument.Modify();
        }
        public void UnselectSolutionByIndex(int index)
        {
            UnSelectSolution( GetSelSolutionBySolutionIndex(index) );
        }
        public void UnSelectSolution(SelSolution selSolution)
        {
            if (null == selSolution) return; // this solution not selected
            // remove from list
            _selectedSolutions.Remove(selSolution);
            ParentDocument.RemoveItem(selSolution);
            // set document modified (not analysis, otherwise selected solutions are erased)
            ParentDocument.Modify();
        }
        public bool HasSolutionSelected(int index)
        {
            return (null != GetSelSolutionBySolutionIndex(index));
        }
        private SelSolution GetSelSolutionBySolutionIndex(int index)
        {
            if (index < 0 || index > _solutions.Count) return null;  // no solution with this index
            return _selectedSolutions.Find(delegate(SelSolution selSol) { return selSol.Solution == _solutions[index]; });
        }
        public bool IsBundleAnalysis { get { return _bProperties is BundleProperties; } }
        public bool IsBoxAnalysis { get { return _bProperties is BoxProperties; } }
        #endregion

        #region Dependancies
        protected override void OnDispose()
        {
            while (_selectedSolutions.Count > 0)
                UnSelectSolution(_selectedSolutions[0]);
            base.OnDispose();
        }

        protected override void RemoveItselfFromDependancies()
        {
            _bProperties.RemoveDependancie(this);
            _palletProperties.RemoveDependancie(this);
            if (null != _interlayerProperties)
                _interlayerProperties.RemoveDependancie(this);
            base.RemoveItselfFromDependancies();
        }
        public override void OnAttributeModified(ItemBase modifiedAttribute)
        {
            // clear selected solutions
            while (_selectedSolutions.Count > 0)
                UnSelectSolution(_selectedSolutions[0]);
            // clear solutions
            _solutions.Clear();

        }
        public override void OnEndUpdate(ItemBase updatedAttribute)
        {
            // clear selected solutions
            while (_selectedSolutions.Count > 0)
                UnSelectSolution(_selectedSolutions[0]);
            // clear solutions
            _solutions.Clear();
            // get default analysis solver
            if (null != _solver)
                _solver.ProcessAnalysis(this);
            else
                _log.Error("_solver == null : solver was not set");
            if (_solutions.Count == 0)
                _log.Debug("Recomputed analysis has no solutions");
            // set modified / propagate modifications
            Modify();
        }
        #endregion
    }
    #endregion

    #region IAnalysisSolver
    public interface IAnalysisSolver
    { 
        void ProcessAnalysis(Analysis analysis);
    }
    #endregion
}
