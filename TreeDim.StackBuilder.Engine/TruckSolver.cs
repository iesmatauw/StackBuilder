#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using TreeDim.StackBuilder.Basics;
using Sharp3D.Math.Core;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    public class TruckSolver : ITruckSolver
    {
        #region Data members
        private List<LayerPattern> _patterns = new List<LayerPattern>();
        static readonly ILog _log = LogManager.GetLogger(typeof(TruckSolver));
        #endregion

        #region TruckSolver
        public TruckSolver()
        {
            LoadPatterns();
        }
        #endregion

        #region Public methods
        public void ProcessAnalysis(TruckAnalysis truckAnalysis)
        {
            truckAnalysis.Solutions = GenerateSolutions(truckAnalysis);
        }
        #endregion

        #region Private methods
        private List<TruckSolution> GenerateSolutions(TruckAnalysis truckAnalysis)
        {
            List<TruckSolution> solutions = new List<TruckSolution>();

            // build layer using truck length / width
            foreach (LayerPattern pattern in _patterns)
            {
                try
                {
                    TruckSolution sol = new TruckSolution("sol", truckAnalysis);
                    // insert solution
                    if (sol.PalletCount > 0)
                        solutions.Add(sol);

                    Layer layer = new Layer(truckAnalysis.ParentSolution, truckAnalysis.TruckProperties, truckAnalysis.ConstraintSet);
                }
                catch (Exception ex)
                {
                    _log.Error(string.Format("Exception caught: {0}", ex.Message));
                }
            }

            // sort solutions
            solutions.Sort();

            return solutions;
        }

        private void LoadPatterns()
        {
            _patterns.Add(new LayerPatternColumn());
            _patterns.Add(new LayerPatternInterlocked());
        }
        #endregion
    }
}
