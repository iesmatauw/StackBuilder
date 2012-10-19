#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using TreeDim.StackBuilder.Basics;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    #region BoxCaseSolver
    public class BoxCaseSolver : IBoxCaseAnalysisSolver
    {
        #region Data members
        private static List<LayerPattern> _patterns = new List<LayerPattern>();
        private BoxProperties _boxProperties;
        private BoxProperties _caseProperties;
        private BoxCaseConstraintSet _constraintSet;
        static readonly ILog _log = LogManager.GetLogger(typeof(BoxCaseSolver));
        #endregion

        #region Constructor
        public BoxCaseSolver()
        {
            BoxCaseSolver.LoadPatterns();
        }
        #endregion

        #region Processing methods
        public void ProcessAnalysis(BoxCaseAnalysis analysis)
        {
            _boxProperties = analysis.BoxProperties;
            _caseProperties = analysis.CaseProperties;
            _constraintSet = analysis.ConstraintSet;

            if (!_constraintSet.IsValid)
                throw new EngineException("Constraint set is invalid!");

            analysis.Solutions = GenerateSolutions();
        }
        #endregion

        #region Private methods
        private List<BoxCaseSolution> GenerateSolutions()
        {
            List<BoxCaseSolution> solutions = new List<BoxCaseSolution>();

            // loop throw all patterns
            foreach (LayerPattern pattern in _patterns)
            {
                // loop through all vertical axes
                for (int i = 0; i < 3; ++i)
                {
                    HalfAxis.HAxis axisOrtho1 = (HalfAxis.HAxis)(2 * i);
                    HalfAxis.HAxis axisOrtho2 = (HalfAxis.HAxis)(2 * i + 1);

                    if (!_constraintSet.AllowOrthoAxis(axisOrtho2))
                        continue;

                    string title = string.Empty;
                    BoxCaseSolution sol = new BoxCaseSolution(null, title);
                    // insert solution
                    if (sol.BoxPerCaseCount > 0)
                        solutions.Add(sol);
                }
            }
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
                _patterns.Add(new LayerPatternColumn());
                _patterns.Add(new LayerPatternInterlocked());
                _patterns.Add(new LayerPatternTrilock());
                _patterns.Add(new LayerPatternDiagonale());
                _patterns.Add(new LayerPatternSpirale());
                _patterns.Add(new LayerPatternEnlargedSpirale());
            }
        }
        #endregion
    }
    #endregion
}
