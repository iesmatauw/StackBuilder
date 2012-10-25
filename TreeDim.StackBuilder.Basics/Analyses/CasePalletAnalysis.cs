#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using log4net;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region CasePalletAnalysis
    public class CasePalletAnalysis : ItemBase
    {
        #region Data members
        private BProperties _bProperties;
        private PalletProperties _palletProperties;
        private InterlayerProperties _interlayerProperties;
        private PalletConstraintSet _constraintSet;
        private List<CasePalletSolution> _solutions;
        private List<SelCasePalletSolution> _selectedSolutions = new List<SelCasePalletSolution>();
        private static ICasePalletAnalysisSolver _solver;
        static readonly ILog _log = LogManager.GetLogger(typeof(CasePalletAnalysis));
        #endregion

        #region Delegates
        public delegate void SelectSolution(CasePalletAnalysis analysis, SelCasePalletSolution selSolution);
        #endregion

        #region Events
        public event SelectSolution SolutionSelected;
        public event SelectSolution SolutionSelectionRemoved;
        #endregion

        #region Constructor
        public CasePalletAnalysis(BProperties boxProperties, PalletProperties palletProperties, InterlayerProperties interlayerProperties, PalletConstraintSet constraintSet)
            : base(boxProperties.ParentDocument)
        {
            // sanity checks
            if (palletProperties.ParentDocument != ParentDocument
                || (interlayerProperties != null && interlayerProperties.ParentDocument != ParentDocument))
                throw new Exception("box, pallet, interlayer do not belong to the same document");
            if ((boxProperties is BoxProperties && constraintSet is BundlePalletConstraintSet)
                || (boxProperties is BundleProperties && constraintSet is CasePalletConstraintSet))
                throw new Exception("Invalid analysis: either BoxProperties with ConstraintSetBundle or BundleProperties with ConstraintSetBox");
            // has interlayer ?
            constraintSet.HasInterlayer = null != interlayerProperties;
            // setting members
            this.BProperties = boxProperties;
            this.PalletProperties = palletProperties;
            this.InterlayerProperties = interlayerProperties;
            this.ConstraintSet = constraintSet;
        }
        #endregion

        #region Public properties
        public List<CasePalletSolution> Solutions
        {
            set
            {
                _solutions = value;
                foreach (CasePalletSolution sol in _solutions)
                    sol.Analysis = this;

            }
            get { return _solutions; }
        }

        public BProperties BProperties
        {
            get { return _bProperties; }
            set
            {
                if (value == _bProperties)  return;
                if (null != _bProperties) _bProperties.RemoveDependancie(this);
                _bProperties = value;
                _bProperties.AddDependancie(this);
            }
        }

        public PalletProperties PalletProperties
        {
            get { return _palletProperties; }
            set
            {
                if (_palletProperties == value) return;
                if (null != _palletProperties)  _palletProperties.RemoveDependancie(this);
                _palletProperties = value;
                _palletProperties.AddDependancie(this);
            }
        }

        public bool HasInterlayer
        {
            get { return (null != _interlayerProperties); }
        }

        public InterlayerProperties InterlayerProperties
        {
            get { return _interlayerProperties; }
            set
            {
                if (_interlayerProperties == value) return;
                if (null != _interlayerProperties) _interlayerProperties.RemoveDependancie(this);
                _interlayerProperties = value;
                if (null != _interlayerProperties)
                    _interlayerProperties.AddDependancie(this);
            }
        }

        public PalletConstraintSet ConstraintSet
        {
            get { return _constraintSet; }
            set { _constraintSet = value; }
        }

        public static ICasePalletAnalysisSolver Solver
        {   set { _solver = value; } }
        #endregion

        #region Solution selection
        public void SelectSolutionByIndex(int index)
        {
            if (index < 0 || index > _solutions.Count)
                return;  // no solution with this index
            if (HasSolutionSelected(index)) return;             // solution already selected
            // instantiate new SelSolution
            SelCasePalletSolution selSolution = new SelCasePalletSolution(ParentDocument, this, _solutions[index]);
            // insert in list
            _selectedSolutions.Add(selSolution);
            // fire event
            if (null != SolutionSelected)
                SolutionSelected(this, selSolution);
            // set document modified (not analysis, otherwise selected solutions are erased)
            ParentDocument.Modify();
        }
        public void UnselectSolutionByIndex(int index)
        {
            UnSelectSolution( GetSelSolutionBySolutionIndex(index) );
        }
        public void UnSelectSolution(SelCasePalletSolution selSolution)
        {
            if (null == selSolution) return; // this solution not selected
            // remove from list
            _selectedSolutions.Remove(selSolution);
            ParentDocument.RemoveItem(selSolution);
            // fire event
            if (null != SolutionSelectionRemoved)
                SolutionSelectionRemoved(this, selSolution);
            // set document modified (not analysis, otherwise selected solutions are erased)
            ParentDocument.Modify();
        }
        public bool HasSolutionSelected(int index)
        {
            return (null != GetSelSolutionBySolutionIndex(index));
        }
        public SelCasePalletSolution GetSelSolutionBySolutionIndex(int index)
        {
            if (index < 0 || index > _solutions.Count) return null;  // no solution with this index
            return _selectedSolutions.Find(delegate(SelCasePalletSolution selSol) { return selSol.Solution == _solutions[index]; });
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
    public interface ICasePalletAnalysisSolver
    { 
        void ProcessAnalysis(CasePalletAnalysis analysis);
    }
    #endregion
}
