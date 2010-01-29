using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDim.StackBuilder.Basics
{
    public class Analysis
    {
        #region Data members
        private string _name;
        private string _description;
        private BoxProperties _boxProperties;
        private PalletProperties _palletProperties;
        private ConstraintSet _constraintSet;
        private List<Solution> _solutions;
        #endregion

        #region Constructor
        public Analysis(BoxProperties boxProperties, PalletProperties palletProperties, ConstraintSet constraintSet)
        {
            _boxProperties = boxProperties;
            _palletProperties = palletProperties;
            _constraintSet = constraintSet;
        }
        #endregion

        #region Public properties
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

        public ConstraintSet ConstraintSet
        {
            get { return _constraintSet; }
            set { _constraintSet = value; }
        }
        #endregion
    }
}
