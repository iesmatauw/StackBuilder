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
        private InterlayerProperties _interlayerProperties, _interlayerPropertiesAntiSlip;
        private PalletCornerProperties _cornerProperties;
        private PalletCapProperties _capProperties;
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
            _interlayerPropertiesAntiSlip = analysis.InterlayerPropertiesAntiSlip;
            _cornerProperties = analysis.PalletCornerProperties;
            _capProperties = analysis.PalletCapProperties;
            _constraintSet = analysis.ConstraintSet;
            // check contraint set validity
            if (!_constraintSet.IsValid)
                throw new EngineException("Constraint set is invalid!");
            // generate solutions
            analysis.Solutions = GenerateSolutions();
        }

        public List<CasePalletSolution> Process(
            BoxProperties boxProperties, PalletProperties palletProperties,
            InterlayerProperties interlayerProperties, InterlayerProperties interlayerPropertiesAntiSlip,
            PalletConstraintSet constraintSet)
        {
            _bProperties = boxProperties;
            _palletProperties = palletProperties;
            _interlayerProperties = interlayerProperties;
            _interlayerPropertiesAntiSlip = interlayerPropertiesAntiSlip;
            _constraintSet = constraintSet;
            // check constraint set validity
            if (!_constraintSet.IsValid)
                throw new EngineException("Constraint set is invalid!");
            // generate solutions
            return GenerateSolutions();
        }
        #endregion

        #region Private methods
        private Layer GenerateBestLayer(
            BProperties bProperties, PalletProperties palletProperties, PalletCornerProperties cornerProperties,
            PalletConstraintSet constraintSet, HalfAxis.HAxis hAxis)
        {
            Layer bestLayer = null;
            // loop through all patterns
            foreach (LayerPattern pattern in _patterns)
            {
                // is pattern allowed
                if (!_constraintSet.AllowPattern(pattern.Name)) continue;

                // direction 1
                Layer layer1 = new Layer(bProperties, palletProperties, cornerProperties,
                    constraintSet, hAxis);
                double actualLength = 0.0, actualWidth = 0.0;
                pattern.GetLayerDimensionsChecked(layer1, out actualLength, out actualWidth);
                pattern.GenerateLayer(layer1, actualLength, actualWidth);
                // save as best pattern
                if (null == bestLayer || bestLayer.Count < layer1.Count)
                    bestLayer = layer1;
                // direction 2 (opposite)
                Layer layer2 = new Layer(bProperties, palletProperties, cornerProperties,
                    constraintSet, HalfAxis.Opposite(hAxis));
                actualLength = 0.0; actualWidth = 0.0;
                pattern.GetLayerDimensionsChecked(layer2, out actualLength, out actualWidth);
                pattern.GenerateLayer(layer2, actualLength, actualWidth);
                // save as best pattern
                if (null == bestLayer || bestLayer.Count < layer2.Count)
                    bestLayer = layer2;
            }
            return bestLayer;
        }

        private List<CasePalletSolution> GenerateSolutions()
        {
            // generate best layers
            Layer[] bestLayers = new Layer[3];
            if (_constraintSet.AllowLastLayerOrientationChange)
            {
                bestLayers[0] = GenerateBestLayer(_bProperties, _palletProperties, _cornerProperties, _constraintSet, HalfAxis.HAxis.AXIS_X_P);
                bestLayers[1] = GenerateBestLayer(_bProperties, _palletProperties, _cornerProperties, _constraintSet, HalfAxis.HAxis.AXIS_Y_P);
                bestLayers[2] = GenerateBestLayer(_bProperties, _palletProperties, _cornerProperties, _constraintSet, HalfAxis.HAxis.AXIS_Z_P);
            }

            List<CasePalletSolution> solutions = new List<CasePalletSolution>();
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
                            Layer layer1 = new Layer(_bProperties, _palletProperties, _cornerProperties, _constraintSet, axisOrtho1);
                            Layer layer1_inv = new Layer(_bProperties, _palletProperties, _cornerProperties, _constraintSet, axisOrtho1, true);
                            Layer layer2 = new Layer(_bProperties, _palletProperties, _cornerProperties, _constraintSet, axisOrtho2);
                            Layer layer2_inv = new Layer(_bProperties, _palletProperties, _cornerProperties, _constraintSet, axisOrtho2, true);
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
                                string title = string.Format("{0}-{1}-{2}{3}", pattern.Name, axisName, layerAlignment, swapPos == 1 ? "-swapped" : "");

                                CasePalletSolution sol = new CasePalletSolution(null, title, layer1T == layer2T);
                                int iLayerIndex = 0;
                                double zLayer = _palletProperties.Height;
                                double capThickness = null != _capProperties ? _capProperties.Thickness : 0;
                                int iInterlayer = 0;
                                int iCount = 0;

                                bool maxWeightReached = _constraintSet.UseMaximumPalletWeight && (_palletProperties.Weight + _bProperties.Weight > _constraintSet.MaximumPalletWeight);
                                bool maxHeightReached = _constraintSet.UseMaximumHeight && (zLayer + capThickness + _bProperties.Dimension(axisOrtho1) > _constraintSet.MaximumHeight);
                                bool maxNumberReached = false;

                                // insert anti-slip interlayer id there is one
                                if (_constraintSet.HasInterlayerAntiSlip)
                                {
                                    InterlayerPos interlayerPos = sol.CreateNewInterlayer(zLayer, 1);
                                    zLayer += _interlayerPropertiesAntiSlip.Thickness;
                                }

                                while (!maxWeightReached && !maxHeightReached && !maxNumberReached)
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
                                    double cornerThickness = null != _cornerProperties ? _cornerProperties.Thickness : 0.0;
                                    Layer currentLayer = iLayerIndex % 2 == 0 ? layer1T : layer2T;
                                    BoxLayer layer = sol.CreateNewLayer(zLayer, pattern.Name);

                                    foreach (LayerPosition layerPos in currentLayer)
                                    {
                                        ++iCount;
                                        maxWeightReached = _constraintSet.UseMaximumPalletWeight && ((iCount * _bProperties.Weight + _palletProperties.Weight) > _constraintSet.MaximumPalletWeight);
                                        maxNumberReached = _constraintSet.UseMaximumNumberOfCases && (iCount > _constraintSet.MaximumNumberOfItems);
                                        if (!maxWeightReached && !maxNumberReached)
                                        {
                                            LayerPosition layerPosTemp = AdjustLayerPosition(layerPos);
                                            BoxPosition boxPos = new BoxPosition(
                                                layerPosTemp.Position
                                                    - (0.5 *_constraintSet.OverhangX - cornerThickness) * Vector3D.XAxis 
                                                    - (0.5 * _constraintSet.OverhangY - cornerThickness)* Vector3D.YAxis
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

                                if (maxHeightReached && _constraintSet.AllowLastLayerOrientationChange)
                                {
                                    // remaining height
                                    double remainingHeight = _constraintSet.MaximumHeight - zLayer;
                                    // test to complete with best layer
                                    Layer bestLayer = null; int ibestLayerCount = 0;
                                    for (int iLayerDir = 0; iLayerDir < 3; ++iLayerDir)
                                    {
                                        // another direction than the current direction
                                        if (iLayerDir == i) continue;

                                        Layer layer = bestLayers[iLayerDir];
                                        if (null == layer) continue;

                                        int layerCount = Convert.ToInt32(Math.Floor(remainingHeight / layer.BoxHeight));
                                        if (layerCount < 1) continue;

                                        if (null == bestLayer || ibestLayerCount * bestLayer.Count < layerCount * layer.Count)
                                        {
                                            bestLayer = layer;
                                            ibestLayerCount = layerCount;
                                        }
                                    }

                                    if (null != bestLayer)
                                    {
                                        double cornerThickness = null != _cornerProperties ? _cornerProperties.Thickness : 0.0;

                                        for (int iAddLayer = 0; iAddLayer < ibestLayerCount; ++iAddLayer)
                                        {
                                            BoxLayer layer = sol.CreateNewLayer(zLayer, string.Empty);

                                            foreach (LayerPosition layerPos in bestLayer)
                                            {
                                                LayerPosition layerPosTemp = AdjustLayerPosition(layerPos);
                                                BoxPosition boxPos = new BoxPosition(
                                                    layerPosTemp.Position
                                                    - (0.5 * _constraintSet.OverhangX - cornerThickness)* Vector3D.XAxis
                                                    - (0.5 * _constraintSet.OverhangY - cornerThickness) * Vector3D.YAxis
                                                    + zLayer * Vector3D.ZAxis
                                                    , layerPosTemp.LengthAxis
                                                    , layerPosTemp.WidthAxis
                                                    );
                                                layer.Add(boxPos);
                                            }
                                            zLayer += bestLayer.BoxHeight;
                                        }
                                    }
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
                    } // loop through all vertical axes
                } // loop through all swap positions (if layer can be swapped)
            } // loop through all patterns
            // sort solutions
            solutions.Sort();

            if (ConstraintSet.AllowTwoLayerOrientations && solutions.Count > 0)
            {
                // get best solution count
                int iBestSolutionCount = solutions[0].CaseCount;
                // if solutions exceeds
                List<CasePalletSolution> multiOrientSolution = GenerateOptimizedCombinationOfLayers();
                foreach (CasePalletSolution sol in multiOrientSolution)
                {
                    if (sol.CaseCount > iBestSolutionCount)
                        solutions.Add(sol);
                }
                solutions.Sort();
            }

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

        /// <summary>
        /// build optimal solutions with 2 layer types
        /// </summary>
        /// <returns></returns>
        private List<CasePalletSolution> GenerateOptimizedCombinationOfLayers()
        {
            List<CasePalletSolution> solutions = new List<CasePalletSolution>();

            // generate best layers
            Layer[] bestLayers = new Layer[3];
            bestLayers[0] = GenerateBestLayer(_bProperties, _palletProperties, _cornerProperties, _constraintSet, HalfAxis.HAxis.AXIS_X_P);
            bestLayers[1] = GenerateBestLayer(_bProperties, _palletProperties, _cornerProperties, _constraintSet, HalfAxis.HAxis.AXIS_Y_P);
            bestLayers[2] = GenerateBestLayer(_bProperties, _palletProperties, _cornerProperties, _constraintSet, HalfAxis.HAxis.AXIS_Z_P);

            string[] dir = { "X", "Y", "Z" };
            for (int i = 0; i < 3; ++i)
            {
                HalfAxis.HAxis axisOrtho = (HalfAxis.HAxis)(2 * i + 1);
                HalfAxis.HAxis axis0 = (HalfAxis.HAxis)((2 * (i + 1)) % 6 + 1);
                HalfAxis.HAxis axis1 = (HalfAxis.HAxis)((2 * (i + 2)) % 6 + 1);

                int noLayer0 = 0, noLayer1 = 0;
                if (GetOptimalRequest(
                    _bProperties.Dimension(axis0), bestLayers[i % 3].Count
                    , _bProperties.Dimension(axis1), bestLayers[(i + 1) % 3].Count
                    , out noLayer0, out noLayer1))
                {
                    Layer layer0 = bestLayers[i % 3];
                    Layer layer1 = bestLayers[(i + 1) % 3];

                    // sol0
                    CasePalletSolution sol0 = new CasePalletSolution(null, string.Format("combination_{0}{1}", dir[i % 3], dir[(i % 3) + 1]), false);
                    double zLayer = _palletProperties.Height;
                    double cornerThickness = null != _cornerProperties ? _cornerProperties.Thickness : 0.0;

                    for (int j = 0; j < noLayer0; ++j)
                    {
                        BoxLayer layer = sol0.CreateNewLayer(zLayer, string.Empty);
                        foreach (LayerPosition layerPos in layer0)
                        {
                            LayerPosition layerPosTemp = AdjustLayerPosition(layerPos);
                            BoxPosition boxPos = new BoxPosition(
                                layerPosTemp.Position
                                - 0.5 * _constraintSet.OverhangX * Vector3D.XAxis
                                - 0.5 * _constraintSet.OverhangY * Vector3D.YAxis
                                + zLayer * Vector3D.ZAxis
                                , layerPosTemp.LengthAxis
                                , layerPosTemp.WidthAxis
                                );
                            layer.Add(boxPos);
                        }
                        zLayer += layer0.BoxHeight;
                    }
                    for (int j = 0; j < noLayer1; ++j)
                    {
                        BoxLayer layer = sol0.CreateNewLayer(zLayer, string.Empty);
                        foreach (LayerPosition layerPos in layer1)
                        {
                            LayerPosition layerPosTemp = AdjustLayerPosition(layerPos);
                            BoxPosition boxPos = new BoxPosition(
                                layerPosTemp.Position
                                - (0.5 * _constraintSet.OverhangX - cornerThickness) * Vector3D.XAxis
                                - (0.5 * _constraintSet.OverhangY - cornerThickness) * Vector3D.YAxis
                                + zLayer * Vector3D.ZAxis
                                , layerPosTemp.LengthAxis
                                , layerPosTemp.WidthAxis
                                );
                            layer.Add(boxPos);
                        }
                        zLayer += layer1.BoxHeight;
                    }
                    solutions.Add(sol0);

                    // sol1
                    CasePalletSolution sol1 = new CasePalletSolution(null, string.Format("combination_{0}{1}", dir[i % 3], dir[(i % 3) + 1]), false);
                    zLayer = _palletProperties.Height;

                    for (int j = 0; j < noLayer0; ++j)
                    {
                        BoxLayer layer = sol1.CreateNewLayer(zLayer, string.Empty);
                        foreach (LayerPosition layerPos in layer1)
                        {
                            LayerPosition layerPosTemp = AdjustLayerPosition(layerPos);
                            BoxPosition boxPos = new BoxPosition(
                                layerPosTemp.Position
                                - (0.5 * _constraintSet.OverhangX - cornerThickness) * Vector3D.XAxis
                                - (0.5 * _constraintSet.OverhangY - cornerThickness) * Vector3D.YAxis
                                + zLayer * Vector3D.ZAxis
                                , layerPosTemp.LengthAxis
                                , layerPosTemp.WidthAxis
                                );
                            layer.Add(boxPos);
                        }
                        zLayer += layer1.BoxHeight;
                    }
                    for (int j = 0; j < noLayer1; ++j)
                    {
                        BoxLayer layer = sol1.CreateNewLayer(zLayer, string.Empty);
                        foreach (LayerPosition layerPos in layer0)
                        {
                            LayerPosition layerPosTemp = AdjustLayerPosition(layerPos);
                            BoxPosition boxPos = new BoxPosition(
                                layerPosTemp.Position
                                - (0.5 * _constraintSet.OverhangX - cornerThickness) * Vector3D.XAxis
                                - (0.5 * _constraintSet.OverhangY - cornerThickness) * Vector3D.YAxis
                                + zLayer * Vector3D.ZAxis
                                , layerPosTemp.LengthAxis
                                , layerPosTemp.WidthAxis
                                );
                            layer.Add(boxPos);
                        }
                        zLayer += layer0.BoxHeight;
                    }
                    solutions.Add(sol1);
                }
            }
            return solutions;
        }

        private bool GetOptimalRequest(double thickness0, int layerCaseCount0, double thickness1, int layerCaseCount1, out int noLayer0, out int noLayer1)
        {
            noLayer0 = 0; noLayer1 = 0;

            int maxNoLayer0 = Convert.ToInt32(Math.Floor((_constraintSet.MaximumHeight - _palletProperties.Height) / thickness0));
            int maxNoLayer1 = Convert.ToInt32(Math.Floor((_constraintSet.MaximumHeight - _palletProperties.Height) / thickness1));

            int maxCaseCount = 0;
            for (int i = 1; i < maxNoLayer0; ++i)
            {
                int iLayer0 = i;
                int iLayer1 = Convert.ToInt32(Math.Floor((_constraintSet.MaximumHeight - _palletProperties.Height - i * thickness0) / thickness1));
                int caseCount = noLayer0 * layerCaseCount0 + noLayer1 * layerCaseCount1;
                if (caseCount > maxCaseCount)
                {
                    maxCaseCount = caseCount;
                    noLayer0 = iLayer0;
                    noLayer1 = iLayer1;
                }
            }
            return noLayer0 * layerCaseCount0 + noLayer1 * layerCaseCount1 > Math.Max(maxNoLayer0 * layerCaseCount0, maxNoLayer1 * layerCaseCount1);
        }

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
                int i = 0;
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
                    patternNameList.Add(p.Name);
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
