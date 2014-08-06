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
                        double offsetX = 0.5 * (_caseProperties.Length - _caseProperties.InsideLength);
                        double offsetY = 0.5 * (_caseProperties.Width - _caseProperties.InsideWidth);
                        double zLayer = 0.5 * (_caseProperties.Height - _caseProperties.InsideHeight);
                        bool maxWeightReached = _constraintSet.UseMaximumCaseWeight && (_caseProperties.Weight + _boxProperties.Weight > _constraintSet.MaximumCaseWeight);
                        bool maxHeightReached = _boxProperties.Dimension(axisOrtho) > _caseProperties.InsideHeight;
                        bool maxNumberReached = false;
                        int boxCount = 0;

                        while (!maxWeightReached && !maxHeightReached && !maxNumberReached)
                        {
                            BoxLayer bLayer = sol.CreateNewLayer(zLayer, string.Empty);

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
                                LayerPosition layerPosTemp = AdjustLayerPosition(layerPos);
                                BoxPosition boxPos = new BoxPosition(
                                    layerPosTemp.Position
                                    + offsetX * Vector3D.XAxis
                                    + offsetY * Vector3D.YAxis
                                    + zLayer * Vector3D.ZAxis
                                    , layerPosTemp.LengthAxis
                                    , layerPosTemp.WidthAxis
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
            if (!_keepAllSolutions && solutions.Count > 0)
            {
                int indexFrom = 0, maxCount = solutions[0].BoxPerCaseCount;
                while (indexFrom < solutions.Count && solutions[indexFrom].BoxPerCaseCount == maxCount)
                    ++indexFrom;
                solutions.RemoveRange(indexFrom, solutions.Count - indexFrom);
            }
            return solutions;        
        }
        #endregion

        #region Public properties
        /// <summary>
        /// if box bottom oriented to Z+, reverse box
        /// </summary>
        private LayerPosition AdjustLayerPosition(LayerPosition layerPos)
        {
            LayerPosition layerPosTemp = layerPos;
            if (layerPosTemp.HeightAxis == HalfAxis.HAxis.AXIS_Z_N)
            {
                if (layerPosTemp.LengthAxis == HalfAxis.HAxis.AXIS_X_P)
                {
                    layerPosTemp.WidthAxis = HalfAxis.HAxis.AXIS_Y_P;
                    layerPosTemp.Position += new Vector3D(0.0, -_boxProperties.Width, -_boxProperties.Height);
                }
                else if (layerPos.LengthAxis == HalfAxis.HAxis.AXIS_Y_P)
                {
                    layerPosTemp.WidthAxis = HalfAxis.HAxis.AXIS_X_N;
                    layerPosTemp.Position += new Vector3D(_boxProperties.Width, 0.0, -_boxProperties.Height);
                }
                else if (layerPos.LengthAxis == HalfAxis.HAxis.AXIS_X_N)
                {
                    layerPosTemp.LengthAxis = HalfAxis.HAxis.AXIS_X_P;
                    layerPosTemp.Position += new Vector3D(-_boxProperties.Length, 0.0, -_boxProperties.Height);
                }
                else if (layerPos.LengthAxis == HalfAxis.HAxis.AXIS_Y_N)
                {
                    layerPosTemp.WidthAxis = HalfAxis.HAxis.AXIS_X_P;
                    layerPosTemp.Position += new Vector3D(-_boxProperties.Width, 0.0, -_boxProperties.Height);
                }
            }
            return layerPosTemp;
        }
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
