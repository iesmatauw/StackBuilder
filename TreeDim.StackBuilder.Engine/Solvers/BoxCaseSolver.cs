#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
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
        private bool _keepAllSolutions = false;
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
                for (int i = 0; i < 6; ++i)
                {
                    HalfAxis.HAxis axisOrtho = (HalfAxis.HAxis)i;

                    if (!_constraintSet.AllowOrthoAxis(axisOrtho))
                        continue;

                    try
                    {
                        // build layer
                        Layer layer = new Layer(_boxProperties, _caseProperties, axisOrtho);
                        double actualLength = 0.0, actualWidth = 0.0;
                        pattern.GetLayerDimensionsChecked(layer, out actualLength, out actualWidth);
                        pattern.GenerateLayer(layer, actualLength, actualWidth);

                        string title = string.Empty;
                        BoxCaseSolution sol = new BoxCaseSolution(null, axisOrtho, pattern.Name);
                        double zLayer = 0.5 * (_caseProperties.Height - _caseProperties.InsideHeight);
                        bool maxWeightReached = _constraintSet.UseMaximumCaseWeight && (_caseProperties.Weight + _boxProperties.Weight > _constraintSet.MaximumCaseWeight);
                        bool maxHeightReached = _boxProperties.Dimension(axisOrtho) > _caseProperties.InsideHeight;
                        bool maxNumberReached = false;
                        int boxCount = 0;

                        while (!maxWeightReached && !maxHeightReached && !maxNumberReached)
                        {
                            BoxLayer bLayer = sol.CreateNewLayer(zLayer);

                            foreach (LayerPosition layerPos in layer)
                            {
                                // increment
                                ++boxCount;
                                if (maxNumberReached = _constraintSet.UseMaximumNumberOfBoxes && (boxCount > _constraintSet.MaximumNumberOfBoxes))
                                    break;

                                double weight = _caseProperties.Weight + boxCount * _boxProperties.Weight;
                                maxWeightReached = _constraintSet.UseMaximumCaseWeight && weight >  _constraintSet.MaximumCaseWeight;
                                if (maxWeightReached)
                                    break;

                                // insert new box in current layer
                                BoxPosition boxPos = new BoxPosition(
                                    layerPos.Position + zLayer * Vector3D.ZAxis
                                    , layerPos.LengthAxis
                                    , layerPos.WidthAxis
                                    );
                                bLayer.Add(boxPos);
                            }
                            zLayer += layer.BoxHeight;
                            if (!maxWeightReached && !maxNumberReached)
                                maxHeightReached = zLayer + layer.BoxHeight > 0.5 * (_caseProperties.Height + _caseProperties.InsideHeight);
                        }
                        // set maximum criterion
                        if (maxNumberReached) sol.LimitReached = BoxCaseSolution.Limit.LIMIT_MAXNUMBERREACHED;
                        else if (maxWeightReached) sol.LimitReached = BoxCaseSolution.Limit.LIMIT_MAXWEIGHTREACHED;
                        else if (maxHeightReached) sol.LimitReached = BoxCaseSolution.Limit.LIMIT_MAXHEIGHTREACHED;
                        // insert solution
                        if (sol.BoxPerCaseCount > 0)
                            solutions.Add(sol);
                    }
                    catch (NotImplementedException)
                    {
                        _log.Info(string.Format("Pattern {0} is not implemented", pattern.Name));
                    }
                    catch (Exception ex)
                    {
                        _log.Error(string.Format("Exception caught: {0}", ex.Message));
                    }
                } // loop through all vertical axes
            } // loop through all patterns

            // sort solutions
            solutions.Sort();

            // removes solutions that do not equal the best number
            if (!_keepAllSolutions)
            {
                int indexFrom = 0, maxCount = solutions[0].BoxPerCaseCount;
                while (solutions[indexFrom].BoxPerCaseCount == maxCount)
                    ++indexFrom;
                solutions.RemoveRange(indexFrom, solutions.Count - indexFrom);
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
