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
