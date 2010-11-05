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
            _truckProperties = truckProperties;
            _constraintSet = constraintSet;
        }
        #endregion

        #region Public properties
        public Analysis ParentAnalysis   { get { return _analysis; } }
        public TruckProperties TruckProperties { get { return _truckProperties; } }
        public Solution ParentSolution { get { return _selSolution.Solution; } }
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
        public TruckConstraintSet ConstraintSet
        {
            get { return _constraintSet; }
            set { _constraintSet = value; }
        }

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
        public bool HasSolutionSelected(int index)
        {
            return index == _selectedSolutionIndex;
        }
        #endregion

        #region Override
        protected override void RemoveItselfFromDependancies()
        {
            _selSolution.RemoveDependancie(this);
            base.RemoveItselfFromDependancies();
        }
        #endregion
    }

    public interface ITruckSolver
    {
        void ProcessAnalysis(TruckAnalysis truckAnalysis);
    }
}
