#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region Analysis
    public class Analysis
    {
        #region Data members
        private string _name;
        private string _description;
        private BoxProperties _boxProperties;
        private PalletProperties _palletProperties;
        private InterlayerProperties _interlayerProperties;
        private ConstraintSet _constraintSet;
        private List<Solution> _solutions;
        #endregion

        #region Constructor
        public Analysis(BoxProperties boxProperties, PalletProperties palletProperties, InterlayerProperties interlayerProperties, ConstraintSet constraintSet)
        {
            _boxProperties = boxProperties;
            _palletProperties = palletProperties;
            _interlayerProperties = interlayerProperties;
            _constraintSet = constraintSet;
        }
        #endregion

        #region Public properties
        public Document ParentDocument
        {
            get { return _boxProperties.ParentDocument; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

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
    }
    #endregion

    #region IAnalysisSolver
    public interface IAnalysisSolver
    { 
        void ProcessAnalysis(Analysis analysis);
    }
    #endregion
}
