#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region Analysis
    public class Analysis : ItemBase
    {
        #region Data members
        private BoxProperties _boxProperties;
        private PalletProperties _palletProperties;
        private InterlayerProperties _interlayerProperties;
        private ConstraintSet _constraintSet;
        private List<Solution> _solutions;
        #endregion

        #region Constructor
        public Analysis(BoxProperties boxProperties, PalletProperties palletProperties, InterlayerProperties interlayerProperties, ConstraintSet constraintSet)
            : base(boxProperties.ParentDocument)
        {
            // sanity check
            if (palletProperties.ParentDocument != ParentDocument
                || (interlayerProperties != null && interlayerProperties.ParentDocument != ParentDocument))
                throw new Exception();

            _boxProperties = boxProperties;
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
            set { _solutions = value; }
            get { return _solutions; }
        }

        public BoxProperties BoxProperties
        {
            get { return _boxProperties; }
            set { _boxProperties = value; }
        }

        public PalletProperties PalletProperties
        {
            get { return _palletProperties; }
            set { _palletProperties = value; }
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
        #endregion

        #region Dependancies
        protected override void RemoveItselfFromDependancies()
        {
            _boxProperties.RemoveDependancie(this);
            _palletProperties.RemoveDependancie(this);
            if (null != _interlayerProperties)
                _interlayerProperties.RemoveDependancie(this);
            base.RemoveItselfFromDependancies();
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
