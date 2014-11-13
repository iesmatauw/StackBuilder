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
                for (int swapPos = 0; swapPos < (pattern.CanBeSwapped ? 2 : 1); ++swapPos)
                {
                    pattern.Swapped = swapPos == 1;

                    for (int orientation = 0; orientation < 2; ++orientation)
                    {
                        try
                        {
                            Layer layer = new Layer(truckAnalysis.ParentSolution, truckAnalysis.TruckProperties, truckAnalysis.ConstraintSet, orientation);
                            double actualLength = 0.0, actualWidth = 0.0;
                            pattern.GetLayerDimensionsChecked(layer, out actualLength, out actualWidth);

                            pattern.GenerateLayer(layer, actualLength, actualWidth);

                            TruckSolution sol = new TruckSolution("sol", truckAnalysis);

                            BoxLayer boxLayer = new BoxLayer(0.0, string.Empty);
                            foreach (LayerPosition layerPos in layer)
                                boxLayer.AddPosition(layerPos.Position, layerPos.LengthAxis, layerPos.WidthAxis);

                            sol.Layer = boxLayer;

                            // insert solution
                            if (sol.PalletCount > 0)
                                solutions.Add(sol);
                        }
                        catch (Exception ex)
                        {
                            _log.Error(string.Format("Exception caught: {0}", ex.ToString()));
                        }
                    }
                }
            }

            // sort solutions
            solutions.Sort();

            return solutions;
        }

        private void LoadPatterns()
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
}
