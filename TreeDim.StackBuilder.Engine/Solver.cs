#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using TreeDim.StackBuilder.Basics;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    public class Solver
    {
        #region Data members
        private List<LayerPattern> _patterns= new List<LayerPattern>();
        private BoxProperties _boxProperties;
        private PalletProperties _palletProperties;
        private ConstraintSet _constraintSet;
        #endregion

        #region Solver
        public Solver()
        {
            LoadPatterns();
        }
        #endregion

        #region Public methods
        public void ProcessAnalysis(Analysis analysis)
        {
            _boxProperties = analysis.BoxProperties;
            _palletProperties = analysis.PalletProperties;
            _constraintSet = analysis.ConstraintSet;

            analysis.Solutions = GenerateSolutions();
        }
        #endregion

        #region Private methods
        private List<Solution> GenerateSolutions()
        {
            List<Solution> solutions = new List<Solution>();

            // build 2 layers (pallet length/width)
            foreach (LayerPattern pattern in _patterns)
            {
                if (!_constraintSet.AllowPattern(pattern.Name))
                    continue;
                for (int swapPos = 0; swapPos < (pattern.CanBeSwaped ? 2 : 1); ++swapPos)
                {
                    pattern.Swaped = swapPos == 1;

                    for (int i = 0; i < 3; ++i)
                    {
                        HalfAxis axisOrtho1 = (HalfAxis)(2 * i);
                        HalfAxis axisOrtho2 = (HalfAxis)(2 * i + 1);

                        if (!_constraintSet.AllowOrthoAxis(axisOrtho2))
                            continue;

                        Layer layer1 = new Layer(_boxProperties, _palletProperties, axisOrtho1);
                        Layer layer2 = new Layer(_boxProperties, _palletProperties, axisOrtho2);
                        double actualLength1 = 0.0, actualLength2 = 0.0, actualWidth1 = 0.0, actualWidth2 = 0.0;
                        pattern.GetLayerDimensions(layer1, out actualLength1, out actualWidth1);
                        pattern.GetLayerDimensions(layer2, out actualLength2, out actualWidth2);

                        for (int j = 0; j < 4; ++j)
                        {
                            Layer layer1T = null, layer2T = null;
                            if (0 == j && !_constraintSet.ForceAlternateLayer)
                            {
                                pattern.GenerateLayer(layer1, actualLength1, actualWidth1);
                                layer1T = layer1; layer2T = layer1;
                            }
                            else if (1 == j && !_constraintSet.ForceAlternateLayer)
                            {
                                pattern.GenerateLayer(layer2, actualLength2, actualWidth2);
                                layer1T = layer2; layer2T = layer2;
                            }
                            else if (2 == j && _constraintSet.AllowAlternateLayer)
                            {
                                pattern.GenerateLayer(layer1, Math.Max(actualLength1, actualLength2), Math.Max(actualWidth1, actualWidth2));
                                pattern.GenerateLayer(layer2, Math.Max(actualLength1, actualLength2), Math.Max(actualWidth1, actualWidth2));
                                layer1T = layer1; layer2T = layer2;
                            }
                            else if (3 == j && _constraintSet.AllowAlternateLayer)
                            {
                                pattern.GenerateLayer(layer1, Math.Max(actualLength1, actualLength2), Math.Max(actualWidth1, actualWidth2));
                                pattern.GenerateLayer(layer2, Math.Max(actualLength1, actualLength2), Math.Max(actualWidth1, actualWidth2));
                                layer1T = layer2; layer2T = layer1;
                            }

                            if (null == layer1T || null == layer2T)
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
                            string title = string.Format("Pattern name : {0}\nVertical axis : {0}\n", pattern.Name, axisName);

                            Solution sol = new Solution(title);
                            int iLayerIndex = 0;
                            bool innerLoopStop = false;
                            double zLayer = _palletProperties.Height;

                            while (
                                !innerLoopStop
                                &&
                                (!_constraintSet.UseMaximumHeight || ((iLayerIndex + 1) * _boxProperties.Dimension(axisOrtho1) < _constraintSet.MaximumHeight))
                                )
                            {
                                // select current layer type
                                Layer currentLayer = iLayerIndex % 2 == 0 ? layer1T : layer2T;
                                foreach (LayerPosition layerPos in currentLayer)
                                {
                                    int iCount = sol.Count + 1;
                                    innerLoopStop = (iCount * _boxProperties.Weight > _constraintSet.MaximumPalletWeight)
                                    || (_constraintSet.UseMaximumNumberOfItems && (iCount > _constraintSet.MaximumNumberOfItems));

                                    if (!innerLoopStop)
                                    {
                                        BoxPosition boxPos = new BoxPosition(
                                            layerPos.Position + zLayer * Vector3D.ZAxis
                                            , layerPos.LengthAxis
                                            , layerPos.WidthAxis
                                            );

                                        sol.Add(boxPos);
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
            _patterns.Add(new LayerPatternSpirale());
            _patterns.Add(new LayerPatternEnlargedSpirale());
        }
        #endregion
        #region Public properties
        public BoxProperties Box
        {
            get { return _boxProperties; }
            set { _boxProperties = value; }
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
