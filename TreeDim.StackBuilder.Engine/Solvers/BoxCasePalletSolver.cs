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
    /// <summary>
    /// Solves CaseAnalysis
    /// </summary>
    public class BoxCasePalletSolver : IBoxCasePalletAnalysisSolver
    {
        #region Data members
        private static List<LayerPattern> _patterns = new List<LayerPattern>();
        private BoxProperties _boxProperties;
        private List<PalletSolutionDesc> _palletSolutionList;
        private InterlayerProperties _interlayerProperties;
        private BoxCasePalletConstraintSet _constraintSet;
        static readonly ILog _log = LogManager.GetLogger(typeof(CasePalletSolver));
        #endregion

        #region Constructor
        public BoxCasePalletSolver()
        {
            BoxCasePalletSolver.LoadPatterns();
        }
        #endregion

        #region Public methods
        private List<BoxCasePalletSolution> GenerateSolutions()
        {
            List<BoxCasePalletSolution> solutions = new List<BoxCasePalletSolution>();

            // loop through all pallet solutions
            foreach (PalletSolutionDesc desc in _palletSolutionList)
            {
                CasePalletSolution palletSolution = desc.LoadPalletSolution();
                if (null == palletSolution)
                {
                    _log.Warn(string.Format("Failed to load pallet solution "));
                    continue; 
                }
                BoxProperties caseProperties = palletSolution.Analysis.BProperties as BoxProperties;

                // loop through all patterns
                foreach (LayerPattern pattern in _patterns)
                {
                    if (!_constraintSet.AllowPattern(pattern.Name))
                        continue;

                    // loop through all swap positions (if layer can be swapped)
                    for (int swapPos = 0; swapPos < (pattern.CanBeSwapped ? 2 : 1); ++swapPos)
                    {
                        pattern.Swapped = swapPos == 1;

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
                                Layer layer1 = new Layer(_boxProperties, caseProperties, axisOrtho1);
                                Layer layer2 = new Layer(_boxProperties, caseProperties, axisOrtho2);
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
                                    string title = string.Format("{0}-{1}-{2}{3}", pattern.Name, axisName, layerAlignment, swapPos == 1 ? "-swapped" : "");

                                    BoxCasePalletSolution sol = new BoxCasePalletSolution(null, title, desc, layer1T == layer2T);
                                    int iLayerIndex = 0;
                                    bool innerLoopStop = false;
                                    double zLayer = 0.0; // caseProperties.Height;
                                    int iInterlayer = 0;
                                    int boxCount = 0;

                                    while (
                                        !innerLoopStop
                                        &&
                                        ((zLayer + _boxProperties.Dimension(axisOrtho1) < caseProperties.InsideHeight))
                                        )
                                    {
                                        if (_constraintSet.HasInterlayer)
                                        {
                                            if (iInterlayer >= _constraintSet.InterlayerPeriod)
                                            {
                                                InterlayerPos interlayerPos = sol.CreateNewInterlayer(zLayer, 0);
                                                zLayer += _interlayerProperties.Thickness;
                                                iInterlayer = 0;
                                            }
                                            ++iInterlayer;
                                        }

                                        // select current layer type
                                        Layer currentLayer = iLayerIndex % 2 == 0 ? layer1T : layer2T;
                                        BoxLayer layer = sol.CreateNewLayer(zLayer, pattern.Name);

                                        foreach (LayerPosition layerPos in currentLayer)
                                        {
                                            int iCount = sol.Count + 1;
                                            innerLoopStop = (_constraintSet.UseMaximumCaseWeight && ((boxCount+1) * _boxProperties.Weight + caseProperties.Weight > _constraintSet.MaximumCaseWeight))
                                            || (_constraintSet.UseMaximumNumberOfItems && ((boxCount+1) > _constraintSet.MaximumNumberOfItems));

                                            if (!innerLoopStop)
                                            {
                                                BoxPosition boxPos = new BoxPosition(
                                                    layerPos.Position + zLayer * Vector3D.ZAxis
                                                    , layerPos.LengthAxis
                                                    , layerPos.WidthAxis
                                                    );
                                                layer.Add(boxPos);
                                                ++boxCount;
                                            }
                                            else
                                                break;
                                        }

                                        // increment layer index
                                        ++iLayerIndex;
                                        zLayer += currentLayer.BoxHeight;
                                    }
                                    // insert solution
                                    if (
                                        sol.Count > 0
                                        && (!_constraintSet.UseMinimumNumberOfItems || sol.Count >=_constraintSet.MinimumNumberOfItems)
                                        )
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
                    }// loop through all swap positions (if layer can be swapped)
                }// loop through all patterns
            }// loop through all pallet solutions
            // sort solutions
            solutions.Sort();
            // return list of solutions
            return solutions;
        }
        private static void LoadPatterns()
        {
            if (0 == _patterns.Count)
            {
                _patterns.Add(new LayerPatternColumn());
                _patterns.Add(new LayerPatternInterlocked());
                _patterns.Add(new LayerPatternDiagonale());
                _patterns.Add(new LayerPatternTrilock());
                _patterns.Add(new LayerPatternSpirale());
                _patterns.Add(new LayerPatternEnlargedSpirale());
            }
        }

        public static string[] PatternNames
        {
            get
            {
                BoxCasePalletSolver.LoadPatterns();
                string[] patternNames = new string[_patterns.Count];
                int i = 0;
                foreach (LayerPattern p in _patterns)
                    patternNames[i++] = p.Name;
                return patternNames;
            }
        }
        #endregion

        #region ICaseAnalysisSolver implementation
        public void ProcessAnalysis(BoxCasePalletAnalysis analysis)
        {
            _boxProperties = analysis.BoxProperties;
            _interlayerProperties = analysis.InterlayerProperties;
            _palletSolutionList = analysis.PalletSolutionsList;
            _constraintSet = analysis.ConstraintSet;
            analysis.Solutions = GenerateSolutions();
        }
        #endregion
    }
}
