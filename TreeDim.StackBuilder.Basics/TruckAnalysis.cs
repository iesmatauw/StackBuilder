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
        Analysis _analysis;
        SelSolution _selSolution;
        TruckProperties _truckProperties;
        TruckConstraintSet _constraintSet;
        List<TruckSolution> _truckSolutions = new List<TruckSolution>();
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
            set { _truckSolutions = value; }
        }
        public TruckConstraintSet ConstraintSet
        {
            get { return _constraintSet; }
            set { _constraintSet = value; }
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
