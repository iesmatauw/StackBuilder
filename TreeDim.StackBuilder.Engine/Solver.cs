#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using TreeDim.StackBuilder.Basics;
using Sharp3D.Math.Core;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    /// <summary>
    /// Solver
    /// </summary>
    public class Solver : IAnalysisSolver
    {
        #region Data members
        private List<LayerPattern> _patterns = new List<LayerPattern>();
        private BProperties _bProperties;
        private PalletProperties _palletProperties;
        private InterlayerProperties _interlayerProperties;
        private ConstraintSet _constraintSet;
        static readonly ILog _log = LogManager.GetLogger(typeof(Solver));
        #endregion

        #region Constructor
        public Solver()
        {
            LoadPatterns();
        }
        #endregion

        #region Public methods
        public void ProcessAnalysis(Analysis analysis)
        {
            _bProperties = analysis.BProperties;
            _palletProperties = analysis.PalletProperties;
            _interlayerProperties = analysis.InterlayerProperties;
            _constraintSet = analysis.ConstraintSet;
            if (!_constraintSet.IsValid)
                throw new Exception("Constraint set is invalid!");

            analysis.Solutions = GenerateSolutions();
        }
        #endregion

        #region Private methods
        private List<Solution> GenerateSolutions()
        {
            List<Solution> solutions = new List<Solution>();

            // loop through all patterns
            foreach (LayerPattern pattern in _patterns)
            {
                if (!_constraintSet.AllowPattern(pattern.Name))
                    continue;
                // loop through all swap positions (if layer can be swaped)
                for (int swapPos = 0; swapPos < (pattern.CanBeSwaped ? 2 : 1); ++swapPos)
                {
                    pattern.Swaped = swapPos == 1;

                    // loop through all vertical axes
                    for (int i = 0; i < 3; ++i)
                    {
                        HalfAxis.HAxis axisOrtho1 = (HalfAxis.HAxis)(2 * i);
                        HalfAxis.HAxis axisOrtho2 = (HalfAxis.HAxis)(2 * i + 1);

                        if (!_constraintSet.AllowOrthoAxis(axisOrtho2))
                            continue;
                        try
                        {
                            // build 2 layers (pallet length/width)
                            Layer layer1 = new Layer(_bProperties, _palletProperties, _constraintSet, axisOrtho1);
                            Layer layer2 = new Layer(_bProperties, _palletProperties, _constraintSet, axisOrtho2);
                            double actualLength1 = 0.0, actualLength2 = 0.0, actualWidth1 = 0.0, actualWidth2 = 0.0;
                            pattern.GetLayerDimensionsChecked(layer1, out actualLength1, out actualWidth1);
                            pattern.GetLayerDimensionsChecked(layer2, out actualLength2, out actualWidth2);

                            string layerAlignment = string.Empty;
                            for (int j = 0; j < 4; ++j)
                            {
                                Layer layer1T = null, layer2T = null;
                                if (0 == j && _constraintSet.AllowAlignedLayers)
                                {
                                    pattern.GenerateLayer(layer1, actualLength1, actualWidth1);
                                    layer1T = layer1; layer2T = layer1;
                                    layerAlignment = "aligned-1";
                                }
                                else if (1 == j && _constraintSet.AllowAlignedLayers)
                                {
                                    pattern.GenerateLayer(layer2, actualLength2, actualWidth2);
                                    layer1T = layer2; layer2T = layer2;
                                    layerAlignment = "aligned-2";
                                }
                                else if (2 == j && _constraintSet.AllowAlternateLayers)
                                {
                                    pattern.GenerateLayer(layer1, Math.Max(actualLength1, actualLength2), Math.Max(actualWidth1, actualWidth2));
                                    pattern.GenerateLayer(layer2, Math.Max(actualLength1, actualLength2), Math.Max(actualWidth1, actualWidth2));
                                    layer1T = layer1; layer2T = layer2;
                                    layerAlignment = "alternate-12";
                                }
                                else if (3 == j && _constraintSet.AllowAlternateLayers)
                                {
                                    pattern.GenerateLayer(layer1, Math.Max(actualLength1, actualLength2), Math.Max(actualWidth1, actualWidth2));
                                    pattern.GenerateLayer(layer2, Math.Max(actualLength1, actualLength2), Math.Max(actualWidth1, actualWidth2));
                                    layer1T = layer2; layer2T = layer1;
                                    layerAlignment = "alternate-21";
                                }

                                if (null == layer1T || null == layer2T || 0 == layer1T.Count || 0 == layer2T.Count)
                                    continue;

                                // counters
                                string axisName = string.Empty;
                                switch (i)
                                {
                                    case 0: axisName = "X"; break;
                                    case 1: axisName = "Y"; break;
                                    case 2: axisName = "Z"; break;
                                    default: break;
                                }
                                string title = string.Format("{0}-{1}-{2}{3}", pattern.Name, axisName, layerAlignment, swapPos == 1 ? "-swaped" : "");

                                Solution sol = new Solution(null, title, layer1T == layer2T);
                                int iLayerIndex = 0;
                                bool innerLoopStop = false;
                                double zLayer = _palletProperties.Height;
                                int iInterlayer = 0;

                                while (
                                    !innerLoopStop
                                    &&
                                    (!_constraintSet.UseMaximumHeight || (zLayer + _bProperties.Dimension(axisOrtho1) < _constraintSet.MaximumHeight))
                                    )
                                {
                                    if (_constraintSet.HasInterlayer)
                                    {
                                        if (iInterlayer >= _constraintSet.InterlayerPeriod)
                                        {
                                            InterlayerPos interlayerPos = sol.CreateNewInterlayer(zLayer);
                                            zLayer += _interlayerProperties.Thickness;
                                            iInterlayer = 0;
                                        }
                                        ++iInterlayer;
                                    }

                                    // select current layer type
                                    Layer currentLayer = iLayerIndex % 2 == 0 ? layer1T : layer2T;
                                    BoxLayer layer = sol.CreateNewLayer(zLayer);

                                    foreach (LayerPosition layerPos in currentLayer)
                                    {
                                        int iCount = sol.Count + 1;
                                        innerLoopStop = (iCount * _bProperties.Weight > _constraintSet.MaximumPalletWeight)
                                        || (_constraintSet.UseMaximumNumberOfItems && (iCount > _constraintSet.MaximumNumberOfItems));

                                        if (!innerLoopStop)
                                        {
                                            BoxPosition boxPos = new BoxPosition(
                                                layerPos.Position + zLayer * Vector3D.ZAxis
                                                , layerPos.LengthAxis
                                                , layerPos.WidthAxis
                                                );

                                            layer.Add(boxPos);
                                        }
                                        else
                                            break;
                                    }

                                    // increment layer index
                                    ++iLayerIndex;
                                    zLayer += currentLayer.BoxHeight;
                                }
                                // insert solution
                                if (sol.Count > 0)
                                    solutions.Add(sol);
                            }
                        }
                        catch (NotImplementedException)
                        {
                            _log.Info(string.Format("Pattern {0} is not implemented", pattern.Name));
                        }
                        catch (Exception ex)
                        {
                            _log.Error(string.Format("Exception caught: {0}", ex.Message));
                        }
                    }// loop through all vertical axes
                }// loop through all swap positions (if layer can be swaped)
            } // loop through all patterns
            // sort solutions
            solutions.Sort();

            // remove unwanted solutions
            if (_constraintSet.UseNumberOfSolutionsKept && solutions.Count > _constraintSet.NumberOfSolutionsKept)
            { 
                // get minimum box count
                int minBoxCount = solutions[_constraintSet.NumberOfSolutionsKept].CaseCount;
                // remove any solution with less boxes than minBoxCount
                while (solutions[solutions.Count - 1].CaseCount < minBoxCount)
                    solutions.RemoveAt(solutions.Count - 1);
            }

            return solutions;
        }

        private void LoadPatterns()
        {
            _patterns.Add(new LayerPatternColumn());
            _patterns.Add(new LayerPatternInterlocked());
            _patterns.Add(new LayerPatternDiagonale());
            _patterns.Add(new LayerPatternTrilock());
            _patterns.Add(new LayerPatternSpirale());
            _patterns.Add(new LayerPatternEnlargedSpirale());
        }
        #endregion

        #region Public properties
        public BProperties Box
        {
            get { return _bProperties; }
            set { _bProperties = value; }
        }
        public PalletProperties Pallet
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
