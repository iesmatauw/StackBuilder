#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using log4net;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    #region CylinderSolver
    public class CylinderSolver : ICylinderAnalysisSolver
    {
        #region Data members
        private static List<CylinderLayerPattern> _patterns = new List<CylinderLayerPattern>();
        private CylinderProperties _cylProperties;
        private PalletProperties _palletProperties;
        private InterlayerProperties _interlayerProperties;
        private CylinderPalletConstraintSet _constraintSet;
        static readonly ILog _log = LogManager.GetLogger(typeof(CylinderSolver));
        #endregion

        #region Constructor
        public CylinderSolver()
        {
            CylinderSolver.LoadPatterns();
        }
        #endregion

        #region Processing methods
        public void ProcessAnalysis(CylinderPalletAnalysis analysis)
        {
            _cylProperties = analysis.CylinderProperties;
            _palletProperties = analysis.PalletProperties;
            _interlayerProperties = analysis.InterlayerProperties;
            _constraintSet = analysis.ConstraintSet;
            if (!_constraintSet.IsValid)
                throw new EngineException("Constraint set is invalid!");

            analysis.Solutions = GenerateSolutions();
        }
        #endregion

        #region Private methods
        private List<CylinderPalletSolution> GenerateSolutions()
        {
            List<CylinderPalletSolution> solutions = new List<CylinderPalletSolution>();

            // loop through all patterns
            foreach (CylinderLayerPattern pattern in _patterns)
            {
                for (int iDir = 0; iDir < (pattern.CanBeSwaped ? 2 : 1); ++iDir)
                {
                    // alternate pallet direction
                    LayerCyl layer = new LayerCyl(_cylProperties, _palletProperties, _constraintSet);

                    string title = string.Format("{0}-{1}", pattern.Name, iDir);
                    CylinderPalletSolution sol = new CylinderPalletSolution(null, title, true);
 
                    double actualLength = 0.0, actualWidth = 0.0;
                    pattern.Swaped = (iDir % 2 != 0);
                    pattern.GetLayerDimensions(layer, out actualLength, out actualWidth);
                    try
                    {
                        pattern.GenerateLayer(layer, actualLength, actualWidth);
                    }
                    catch (NotImplementedException ex)
                    {
                        _log.Debug(ex.Message);
                        continue;
                    }
                    catch (Exception ex)
                    {
                        _log.Error(ex.Message);
                        continue;
                    }

                    // stop
                    double zLayer = _palletProperties.Height;
                    bool maxWeightReached = _constraintSet.UseMaximumPalletWeight && (_palletProperties.Weight + _cylProperties.Weight > _constraintSet.MaximumPalletWeight);
                    bool maxHeightReached = _constraintSet.UseMaximumPalletHeight && (zLayer + _cylProperties.Height > _constraintSet.MaximumPalletHeight);
                    bool maxNumberReached = false;

                    int iCount = 0;

                    while (!maxWeightReached && !maxHeightReached && !maxNumberReached)
                    {
                        // interlayer
                        if (_constraintSet.HasInterlayer && (sol.Count > 0))
                        {
                            sol.CreateNewInterlayer(zLayer);
                            zLayer += _interlayerProperties.Thickness;
                        }
                        // select current layer type
                        CylinderLayer cylLayer = sol.CreateNewLayer(zLayer);
                        foreach (Vector2D layerPos in layer)
                        {
                            ++iCount;
                            maxWeightReached = _constraintSet.UseMaximumPalletWeight && ((iCount * _cylProperties.Weight + _palletProperties.Weight) > _constraintSet.MaximumPalletWeight);
                            maxNumberReached = _constraintSet.UseMaximumNumberOfItems && (iCount > _constraintSet.MaximumNumberOfItems);
                            if (!maxWeightReached && !maxNumberReached)
                                cylLayer.Add(new Vector3D(layerPos.X, layerPos.Y, zLayer));
                        }
                        // increment zLayer
                        zLayer += _cylProperties.Height;

                        maxHeightReached = _constraintSet.UseMaximumPalletHeight && (zLayer + _cylProperties.Height > _constraintSet.MaximumPalletHeight);
                    }
                    solutions.Add(sol);
                }
            }
            // sort solutions
            solutions.Sort();
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
                _patterns.Add(new CylinderLayerPatternAligned());
                _patterns.Add(new CylinderLayerPatternStaggered());
                _patterns.Add(new CylinderLayerPatternMixed12());
            }
        }
        #endregion
    }
    #endregion
}
