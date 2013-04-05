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
    /// CasePalletSolver
    /// </summary>
    public class CasePalletSolver : ICasePalletAnalysisSolver
    {
        #region Data members
        private static List<LayerPattern> _patterns = new List<LayerPattern>();
        private BProperties _bProperties;
        private PalletProperties _palletProperties;
        private InterlayerProperties _interlayerProperties;
        private PalletConstraintSet _constraintSet;
        static readonly ILog _log = LogManager.GetLogger(typeof(CasePalletSolver));
        #endregion

        #region Constructor
        public CasePalletSolver()
        {
            CasePalletSolver.LoadPatterns();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Process case/pallet analysis
        /// </summary>
        /// <param name="analysis">Pallet analysis to process</param>
        public void ProcessAnalysis(CasePalletAnalysis analysis)
        {
            _bProperties = analysis.BProperties;
            _palletProperties = analysis.PalletProperties;
            _interlayerProperties = analysis.InterlayerProperties;
            _constraintSet = analysis.ConstraintSet;
            // check contraint set validity
            if (!_constraintSet.IsValid)
                throw new EngineException("Constraint set is invalid!");
            // generate solutions
            analysis.Solutions = GenerateSolutions();
        }

        public List<CasePalletSolution> Process(BoxProperties boxProperties, PalletProperties palletProperties, InterlayerProperties interlayerProperties, PalletConstraintSet constraintSet)
        {
            _bProperties = boxProperties;
            _palletProperties = palletProperties;
            _interlayerProperties = interlayerProperties;
            _constraintSet = constraintSet;
            // check constraint set validity
            if (!_constraintSet.IsValid)
                throw new EngineException("Constraint set is invalid!");
            // generate solutions
            return GenerateSolutions();            
        }
        #endregion

        #region Private methods
        private List<CasePalletSolution> GenerateSolutions()
        {
            List<CasePalletSolution> solutions = new List<CasePalletSolution>();

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
                            Layer layer1_inv = new Layer(_bProperties, _palletProperties, _constraintSet, axisOrtho1, true);
                            Layer layer2 = new Layer(_bProperties, _palletProperties, _constraintSet, axisOrtho2);
                            Layer layer2_inv = new Layer(_bProperties, _palletProperties, _constraintSet, axisOrtho2, true);
                            double actualLength1 = 0.0, actualLength2 = 0.0, actualWidth1 = 0.0, actualWidth2 = 0.0;
                            pattern.GetLayerDimensionsChecked(layer1, out actualLength1, out actualWidth1);
                            pattern.GetLayerDimensionsChecked(layer2, out actualLength2, out actualWidth2);

                            string layerAlignment = string.Empty;
                            for (int j = 0; j < 6; ++j)
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
                                else if (4 == j && _constraintSet.AllowAlternateLayers && pattern.CanBeInverted)
                                {
                                    pattern.GenerateLayer(layer1, actualLength1, actualWidth1);
                                    pattern.GenerateLayer(layer1_inv, actualLength1, actualWidth1);
                                    layer1T = layer1; layer2T = layer1_inv;
                                    layerAlignment = "inv-1";
                                }
                                else if (5 == j && _constraintSet.AllowAlternateLayers && pattern.CanBeInverted)
                                {
                                    pattern.GenerateLayer(layer2, actualLength2, actualWidth2);
                                    pattern.GenerateLayer(layer2_inv, actualLength2, actualWidth2);
                                    layer1T = layer2; layer2T = layer2_inv;
                                    layerAlignment = "inv-2";

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

                                CasePalletSolution sol = new CasePalletSolution(null, title, layer1T == layer2T);
                                int iLayerIndex = 0;
                                double zLayer = _palletProperties.Height;
                                int iInterlayer = 0;
                                int iCount = 0;

                                bool maxWeightReached = _constraintSet.UseMaximumPalletWeight && (_palletProperties.Weight + _bProperties.Weight > _constraintSet.MaximumPalletWeight);
                                bool maxHeightReached = _constraintSet.UseMaximumHeight && (zLayer + _bProperties.Dimension(axisOrtho1) > _constraintSet.MaximumHeight);
                                bool maxNumberReached = false;

                                while (!maxWeightReached && !maxHeightReached && !maxNumberReached)
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
                                        ++iCount;

                                        maxWeightReached = _constraintSet.UseMaximumPalletWeight && ((iCount * _bProperties.Weight + _palletProperties.Weight)> _constraintSet.MaximumPalletWeight);
                                        maxNumberReached = _constraintSet.UseMaximumNumberOfCases && (iCount > _constraintSet.MaximumNumberOfItems);

                                        if (!maxWeightReached && !maxNumberReached)
                                        {
                                            LayerPosition layerPosTemp = layerPos;

                                            // if box bottom oriented to Z+, reverse box
                                            if (layerPosTemp.HeightAxis == HalfAxis.HAxis.AXIS_Z_N)
                                            {
                                                if (layerPosTemp.LengthAxis == HalfAxis.HAxis.AXIS_X_P)
                                                {
                                                    layerPosTemp.WidthAxis = HalfAxis.HAxis.AXIS_Y_P;
                                                    layerPosTemp.Position += new Vector3D(0.0, -_bProperties.Width, -_bProperties.Height);
                                                }
                                                else if (layerPos.LengthAxis == HalfAxis.HAxis.AXIS_Y_P)
                                                {
                                                    layerPosTemp.WidthAxis = HalfAxis.HAxis.AXIS_X_N;
                                                    layerPosTemp.Position += new Vector3D(_bProperties.Width, 0.0, -_bProperties.Height);
                                                }
                                                else if (layerPos.LengthAxis == HalfAxis.HAxis.AXIS_X_N)
                                                {
                                                    layerPosTemp.LengthAxis = HalfAxis.HAxis.AXIS_X_P;
                                                    layerPosTemp.Position += new Vector3D(-_bProperties.Length, 0.0, -_bProperties.Height);
                                                }
                                                else if (layerPos.LengthAxis == HalfAxis.HAxis.AXIS_Y_N)
                                                {
                                                    layerPosTemp.WidthAxis = HalfAxis.HAxis.AXIS_X_P;
                                                    layerPosTemp.Position += new Vector3D(-_bProperties.Width, 0.0, -_bProperties.Height);
                                                }
                                            }

                                            BoxPosition boxPos = new BoxPosition(
                                                layerPosTemp.Position
                                                    - _constraintSet.OverhangX * Vector3D.XAxis
                                                    - _constraintSet.OverhangY * Vector3D.YAxis
                                                    + zLayer * Vector3D.ZAxis
                                                , layerPosTemp.LengthAxis
                                                , layerPosTemp.WidthAxis
                                                );
                                            layer.Add(boxPos);
                                        }
                                        else
                                            break;
                                    }

                                    // increment layer index
                                    ++iLayerIndex;
                                    zLayer += currentLayer.BoxHeight;

                                    // check height
                                    maxHeightReached = _constraintSet.UseMaximumHeight && (zLayer + _bProperties.Dimension(axisOrtho1) > _constraintSet.MaximumHeight);
                                }

                                // set maximum criterion
                                if (maxNumberReached) sol.LimitReached = CasePalletSolution.Limit.LIMIT_MAXNUMBERREACHED;
                                else if (maxWeightReached) sol.LimitReached = CasePalletSolution.Limit.LIMIT_MAXWEIGHTREACHED;
                                else if (maxHeightReached) sol.LimitReached = CasePalletSolution.Limit.LIMIT_MAXHEIGHTREACHED;

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
        #endregion

        #region Static methods
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
                CasePalletSolver.LoadPatterns();
                string[] patternNames = new string[_patterns.Count];
                int i=0;
                foreach (LayerPattern p in _patterns)
                    patternNames[i++] = p.Name;
                return patternNames;
            }
        }
        public static List<string> PatternNameList
        {
            get
            {
                CasePalletSolver.LoadPatterns();
                List<string> patternNameList = new List<string>();
                foreach (LayerPattern p in _patterns)
                    patternNameList.Add( p.Name );
                return patternNameList;
            }
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
        public PalletConstraintSet ConstraintSet
        {
            get { return _constraintSet; }
            set { _constraintSet = value; }
        }
        #endregion
    }
}
