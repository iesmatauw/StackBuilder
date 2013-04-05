#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class CylinderPalletAnalysis : ItemBase
    {
        #region Data members
        private InterlayerProperties _interlayerProperties;
        private CylinderProperties _cylinderProperties;
        private PalletProperties _palletProperties;
        private CylinderPalletConstraintSet _constraintSet;
        private List<CylinderPalletSolution> _solutions = new List<CylinderPalletSolution>();
        static readonly ILog _log = LogManager.GetLogger(typeof(CylinderPalletAnalysis));
        #endregion

        #region Delegates
        #endregion

        #region Constructor
        public CylinderPalletAnalysis(CylinderProperties cylProperties, PalletProperties palletProperties, InterlayerProperties interlayerProperties)
            : base(cylProperties.ParentDocument)
        {
            _cylinderProperties = cylProperties;
            _palletProperties = palletProperties;
            _interlayerProperties = interlayerProperties;
        }
        #endregion

        #region Public properties
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
        public CylinderProperties CylinderProperties
        {
            get { return _cylinderProperties; }
        }
        public PalletProperties PalletProperties
        {
            get { return _palletProperties; }
        }
        public CylinderPalletConstraintSet ConstraintSet
        {
            set { _constraintSet = value; }
            get { return _constraintSet; }
        }
        public List<CylinderPalletSolution> Solutions
        {
            get { return _solutions; }
            set
            {
                _solutions = value;
                foreach (CylinderPalletSolution sol in _solutions)
                    sol.Analysis = this;
            }
        }
        #endregion

        #region Solution selection
        #endregion

        #region Dependancies
        #endregion
    }

    public interface ICylinderAnalysisSolver
    {
        void ProcessAnalysis(CylinderPalletAnalysis analysis);
    }
}
