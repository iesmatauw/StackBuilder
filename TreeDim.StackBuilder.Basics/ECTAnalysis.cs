#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using TreeDim.EdgeCrushTest;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    /// <summary>
    /// ECT analysis
    /// </summary>
    public class ECTAnalysis : ItemBase
    {
        #region Data members
        private CasePalletAnalysis _analysis;
        private SelSolution _selSolution;
        private TreeDim.EdgeCrushTest.McKeeFormula.QualityData _qualityData;
        private McKeeFormula.FormulaType _mcKeeFormula;
        private string _caseType;
        private string _printSurface;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ECTAnalysis(
            Document document
            , CasePalletAnalysis analysis
            , SelSolution selSolution)
            : base(document)
        {
            _analysis = analysis;
            _selSolution = selSolution;
            // get a cardboard quality
            foreach (string skey in McKeeFormula.CardboardQualityDictionary.Keys)
            {
                _qualityData = McKeeFormula.CardboardQualityDictionary[skey];
                break;
            }
            // get a _printSurface value
            foreach (string skey in McKeeFormula.PrintCoefDictionary.Keys)
            {
                _printSurface = skey;
                break;
            }                       
        }
        #endregion

        #region Public properties
        public override string Name
        {
            get { return "ECT"; }
        }
        public override string Description
        {
            get { return "Edge Crush Test Analysis"; }
        }
        public McKeeFormula.QualityData Cardboard
        {
            get { return _qualityData; }
            set { _qualityData = value; }
        }
        public SelSolution ParentSelSolution  
        {
            get { return _selSolution; }
            set { _selSolution = value; }
        }
        /// <summary>
        /// Use improved mc kee formula ?
        /// </summary>
        public bool UseImprovedFormula
        {
            get { return _mcKeeFormula == McKeeFormula.FormulaType.MCKEE_IMPROVED; }
            set { _mcKeeFormula = value ? McKeeFormula.FormulaType.MCKEE_IMPROVED : McKeeFormula.FormulaType.MCKEE_CLASSIC; }
        }
        /// <summary>
        /// Use classic mc kee formula
        /// </summary>
        public bool UseClassicFormula
        {
            get { return _mcKeeFormula == McKeeFormula.FormulaType.MCKEE_CLASSIC; }
        }
        /// <summary>
        /// Mc Kee formula used
        /// </summary>
        public string McKeeFormulaText
        {
            get { return McKeeFormula.ModeText(_mcKeeFormula); }
            set { _mcKeeFormula = McKeeFormula.TextToMode(value); }
        }
        /// <summary>
        /// Case type
        /// </summary>
        public string CaseType
        {
            get { return _caseType; }
            set { _caseType = value; }
        }

        public string PrintSurface
        {
            get { return _printSurface; }
            set { _printSurface = value; }
        }

        public double LoadOnFirstLayerCase
        {
            get
            {
                PalletSolution palletSolution = _selSolution.Solution;
                return palletSolution.AverageLoadOnFirstLayerCase;
            }
        }
        #endregion

        #region Results
        public double StaticBCT
        {
            get
            {
                BoxProperties boxProperties = _analysis.BProperties as BoxProperties;
                return McKeeFormula.ComputeStaticBCT(boxProperties.Length, boxProperties.Width, boxProperties.Height, _qualityData.Id, _caseType, _mcKeeFormula); 
            }
        }
        public Dictionary<KeyValuePair<string, string>, double> DynamicBCTDictionary
        {
            get
            {
                BoxProperties boxProperties = _analysis.BProperties as BoxProperties;
                return McKeeFormula.EvaluateEdgeCrushTestMatrix(boxProperties.Length, boxProperties.Width, boxProperties.Height, _qualityData.Id, _caseType, _printSurface, _mcKeeFormula);
            }
        }
        #endregion

        #region ItemBase overrides
        protected override void RemoveItselfFromDependancies()
        {
            _selSolution.RemoveDependancie(this);
            base.RemoveItselfFromDependancies();
        }
        #endregion
    }
}
