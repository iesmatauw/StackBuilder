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
        private CylinderProperties _cylinderProperties;
        private PalletProperties _palletProperties;
        private CylinderPalletConstraintSet _constraintSet;
        private List<CylinderPalletSolution> _solutions = new List<CylinderPalletSolution>();
        static readonly ILog _log = LogManager.GetLogger(typeof(CylinderPalletAnalysis));
        #endregion

        #region Delegates
        #endregion

        #region Constructor
        public CylinderPalletAnalysis(CylinderProperties cylProperties, PalletProperties palletProperties)
            : base(cylProperties.ParentDocument)
        { 
        }
        #endregion

        #region Public properties
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
            set { _solutions = value; }
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
