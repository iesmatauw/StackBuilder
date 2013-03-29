#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using TreeDim.StackBuilder.Basics;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    #region CylinderSolver
    public class CylinderSolver : ICylinderAnalysisSolver
    {
        #region Data members
        private static List<CylinderLayerPattern> _patterns = new List<CylinderLayerPattern>();
        private CylinderProperties _cylProperties;
        private PalletProperties _palletProperties;
        private CylinderPalletConstraintSet _constraintSet;
        static readonly ILog _log = LogManager.GetLogger(typeof(CylinderSolver));
        #endregion

        #region Constructor
        public CylinderSolver()
        {
            CylinderSolver.LoadPatterns();
        }
        #endregion

        #region Processing methods
        public void ProcessAnalysis(CylinderPalletAnalysis analysis)
        {
            _cylProperties = analysis.CylinderProperties;
            _palletProperties = analysis.PalletProperties;
            _constraintSet = analysis.ConstraintSet;

            if (!_constraintSet.IsValid)
                throw new EngineException("Constraint set is invalid!");

            analysis.Solutions = GenerateSolutions();
        }
        #endregion

        #region Private methods
        private List<CylinderPalletSolution> GenerateSolutions()
        {
            List<CylinderPalletSolution> solutions = new List<CylinderPalletSolution>();
            return solutions;
        }
        #endregion

        #region Public properties
        #endregion

        #region Static methods
        private static void LoadPatterns()
        {
            if (0 == _patterns.Count)
            {
            }
        }
        #endregion
    }
    #endregion
}
