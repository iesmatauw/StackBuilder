#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using log4net;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region CaseAnalysis
    public class CaseAnalysis : ItemBase
    {
        #region Data members
        private BoxProperties _boxProperties;
        private List<PalletSolutionDesc> _palletSolutionsList = new List<PalletSolutionDesc>();
        private List<CaseSolution> _caseSolutions = new List<CaseSolution>();
        private List<SelCaseSolution> _selectedSolutions = new List<SelCaseSolution>();
        private CaseConstraintSet _constraintSet;
        private static ICaseAnalysisSolver _solver;
        static readonly ILog _log = LogManager.GetLogger(typeof(CaseAnalysis));
        #endregion

        #region Delegates
        public delegate void SelectSolution(CaseAnalysis analysis, SelCaseSolution selSolution);
        #endregion

        #region Events
        public event SelectSolution SolutionSelected;
        public event SelectSolution SolutionSelectionRemoved;
        #endregion

        #region Constructor
        public CaseAnalysis(BoxProperties boxProperties, List<PalletSolutionDesc> palletSolutionList, CaseConstraintSet constraintSet)
            : base(boxProperties.ParentDocument)
        {
            if (!constraintSet.IsValid)
                throw new Exception("Using invalid case constraintset -> Can not instantiate case analysis!");
            _boxProperties = boxProperties;
            boxProperties.AddDependancie(this);
            _palletSolutionsList = palletSolutionList;
            _constraintSet = constraintSet;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Box properties
        /// </summary>
        public BoxProperties BoxProperties
        {
            get { return _boxProperties; }
            set { _boxProperties = value; }
        }
        /// <summary>
        /// Interlayer properties
        /// </summary>
        public InterlayerProperties InterlayerProperties
        {
            get { return null; }
        }
        /// <summary>
        /// List of pallet solutions evaluated in this analysis
        /// </summary>
        public List<PalletSolutionDesc> PalletSolutionsList
        {
            get { return _palletSolutionsList; }
        }
        public PalletSolutionDesc GetPalletSolutionDescByGuid(Guid guid)
        {
            return _palletSolutionsList.Find(delegate(PalletSolutionDesc desc) { return desc.Guid == guid; });
        }
        /// <summary>
        /// List of solutions
        /// </summary>
        public List<CaseSolution> Solutions
        {
            get { return _caseSolutions; }
            set
            {
                _caseSolutions = value;
                foreach (CaseSolution caseSolution in _caseSolutions)
                    caseSolution.ParentCaseAnalysis = this;
            }
        }
        /// <summary>
        /// Case analysis contraint set
        /// </summary>
        public CaseConstraintSet ConstraintSet
        {
            get { return _constraintSet; }
        }

        public static ICaseAnalysisSolver Solver
        {
            set { _solver = value; }
        }
        #endregion

        #region Solution selection
        public void SelectSolutionByIndex(int index)
        {
            if (index < 0 || index >= _caseSolutions.Count)
                return;
            if (HasSolutionSelected(index)) return;
            // instantiate new SelCaseSolution 
            SelCaseSolution selCaseSolution = new SelCaseSolution(ParentDocument, this, _caseSolutions[index]);
            // insert in list
            _selectedSolutions.Add(selCaseSolution);
            // fire event
            if (null != SolutionSelected)
                SolutionSelected(this, selCaseSolution);
            //  set document modified
            ParentDocument.Modify();
        }
        public void UnselectSolutionByIndex(int index)
        {
            UnSelectSolution(GetSelCaseSolutionBySolutionIndex(index));
        }
        public void UnSelectSolution(SelCaseSolution selSolution)
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
            return (null != GetSelCaseSolutionBySolutionIndex(index));
        }
        public SelCaseSolution GetSelCaseSolutionBySolutionIndex(int index)
        {
            if (index < 0 || index > _selectedSolutions.Count) return null;
            return _selectedSolutions.Find(delegate(SelCaseSolution selSol) { return selSol.Solution == _caseSolutions[index]; });
        }
        #endregion

        #region Dependancies
        protected override void OnDispose()
        {
            base.OnDispose();
        }

        protected override void RemoveItselfFromDependancies()
        {
            _boxProperties.RemoveDependancie(this);
            base.RemoveItselfFromDependancies();
        }
        public override void OnAttributeModified(ItemBase modifiedAttribute)
        {
            // clear solutions
            _caseSolutions.Clear();

        }
        public override void OnEndUpdate(ItemBase updatedAttribute)
        {
            // clear solutions
            _caseSolutions.Clear();
            // get default analysis solver
            if (null != _solver)
                _solver.ProcessAnalysis(this);
            else
                _log.Error("_solver == null : solver was not set");
            if (_caseSolutions.Count == 0)
                _log.Debug("Recomputed analysis has no solutions");
            // set modified / propagate modifications
            Modify();
        }
        #endregion
    }
    #endregion

    #region IAnalysisSolver
    public interface ICaseAnalysisSolver
    {
        void ProcessAnalysis(CaseAnalysis analysis);
    }
    #endregion
}
