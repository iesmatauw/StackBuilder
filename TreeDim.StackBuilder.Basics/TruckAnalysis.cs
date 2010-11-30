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
        private Analysis _analysis;
        private SelSolution _selSolution;
        private TruckProperties _truckProperties;
        private TruckConstraintSet _constraintSet;
        private List<TruckSolution> _truckSolutions = new List<TruckSolution>();
        private int _selectedSolutionIndex;
        #endregion

        #region Constructor
        /// <summary>
        /// Truck analysis
        /// </summary>
        /// <param name="document">Parent document</param>
        /// <param name="analysis">Parent pallet analysis</param>
        /// <param name="selSolution">Parent selected solution</param>
        /// <param name="truckProperties">TruckProperties item</param>
        /// <param name="constraintSet">Constraint set</param>
        public TruckAnalysis(
            Document document
            , Analysis analysis
            , SelSolution selSolution
            , TruckProperties truckProperties
            , TruckConstraintSet constraintSet)
            : base(document)
        {
            Name = truckProperties.Name;
            _analysis = analysis;
            _selSolution = selSolution;
            this.TruckProperties = truckProperties;
            _constraintSet = constraintSet;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Parent analysis
        /// </summary>
        public Analysis ParentAnalysis   { get { return _analysis; } }
        /// <summary>
        /// Truck properties item
        /// </summary>
        public TruckProperties TruckProperties
        {
            get { return _truckProperties; }
            set
            {
                if (value == _truckProperties) return;
                if (null != _truckProperties) _truckProperties.RemoveDependancie(this);
                _truckProperties = value;
                _truckProperties.AddDependancie(this);
            }
        }
        /// <summary>
        /// Parent solution (from pallet analysis)
        /// </summary>
        public Solution ParentSolution { get { return _selSolution.Solution; } }
        /// <summary>
        /// Parent selected solution (from pallet analysis)
        /// </summary>
        public SelSolution ParentSelSolution { get { return _selSolution; } }
        public List<TruckSolution> Solutions
        {
            get { return _truckSolutions; }
            set
            {
                _truckSolutions = value;
                foreach (TruckSolution truckSolution in _truckSolutions)
                    truckSolution.ParentTruckAnalysis = this;
            }
        }
        /// <summary>
        /// Constraint set
        /// </summary>
        public TruckConstraintSet ConstraintSet
        {
            get { return _constraintSet; }
            set { _constraintSet = value; }
        }
        /// <summary>
        /// Selected solution index in list of truck analysis solutions
        /// </summary>
        public int SelectedSolutionIndex
        {
            set
            {
                if (_selectedSolutionIndex < 0 || _selectedSolutionIndex >= Solutions.Count)
                    throw new Exception("Can not select such truck solution");
                _selectedSolutionIndex = value;
                ParentDocument.Modify();
            }
        }
        /// <summary>
        /// Selected solution
        /// </summary>
        public TruckSolution SelectedSolution
        {
            get
            {
                if (_selectedSolutionIndex < 0 || _selectedSolutionIndex >= _truckSolutions.Count)
                    return null;
                else
                    return _truckSolutions[_selectedSolutionIndex]; 
            }
        }
        /// <summary>
        /// True if index corresponds to a selected solution
        /// Note: in truck analysis, only one solution can be selected
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool HasSolutionSelected(int index)
        {
            return index == _selectedSolutionIndex;
        }
        #endregion

        #region Override
        protected override void RemoveItselfFromDependancies()
        {
            _truckProperties.RemoveDependancie(this);
            _selSolution.RemoveDependancie(this);
            base.RemoveItselfFromDependancies();
        }
        #endregion
    }

    #region ITruckSolver
    /// <summary>
    /// ITruckSolver interface should be implemented by any solver used for truck analyses
    /// </summary>
    public interface ITruckSolver
    {
        void ProcessAnalysis(TruckAnalysis truckAnalysis);
    }
    #endregion
}
