#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class BoxCasePalletSolution : List<ILayer>, IComparable
    {
        #region Data members
        private string _title;
        private BoxCasePalletAnalysis _parentCaseAnalysis;
        private PalletSolutionDesc _palletSolutionDesc;
        private bool _hasHomogeneousLayers;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="caseAnalysis">Parent case analysis reference</param>
        public BoxCasePalletSolution(BoxCasePalletAnalysis caseAnalysis, string title, PalletSolutionDesc palletSolutionDesc, bool hasHomogeneousLayers)
        {
            _title = title;
            _parentCaseAnalysis = caseAnalysis;
            _palletSolutionDesc = palletSolutionDesc;
            _hasHomogeneousLayers = hasHomogeneousLayers;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Parent analysis
        /// </summary>
        public BoxCasePalletAnalysis ParentCaseAnalysis
        {
            set { _parentCaseAnalysis = value; }
            get { return _parentCaseAnalysis; }
        }
        /// <summary>
        /// Pallet solution descriptor
        /// </summary>
        public PalletSolutionDesc PalletSolutionDesc { get { return _palletSolutionDesc; } }
        /// <summary>
        /// Number of boxes in case
        /// </summary>
        public int BoxPerCaseCount
        {
            get
            {
                int iCount = 0;
                foreach (ILayer layer in this)
                    iCount += layer.BoxCount;
                return iCount;
            }
        }
        /// <summary>
        /// Case per pallet count
        /// </summary>
        public int CasePerPalletCount { get { return _palletSolutionDesc.CaseCount; } }
        /// <summary>
        /// Number of boxes on pallet
        /// </summary>
        public int BoxPerPalletCount { get { return BoxPerCaseCount * CasePerPalletCount; } }
        /// <summary>
        /// Case efficiency
        /// </summary>
        public double CaseEfficiency { get { return 100.0 * _parentCaseAnalysis.BoxProperties.Volume * BoxPerCaseCount / _palletSolutionDesc.InsideVolume; } }
        /// <summary>
        /// Pallet efficiency
        /// </summary>
        public double PalletEfficiency {
            get
            {
                CasePalletSolution sol = _palletSolutionDesc.LoadPalletSolution();
                return (100.0 * _parentCaseAnalysis.BoxProperties.Volume * BoxPerPalletCount) / (sol.PalletLength * sol.PalletWidth * sol.PalletHeight); 
            } 
        }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get { return _title; } }
        /// <summary>
        /// Parent case analysis
        /// </summary>
        public BoxCasePalletAnalysis ParentAnalysis  { get { return _parentCaseAnalysis; } }
        /// <summary>
        /// Does solution have homogeneous layers?
        /// </summary>
        public bool HasHomogeneousLayers { get { return _hasHomogeneousLayers; } }
        /// <summary>
        /// Case length
        /// </summary>
        public double CaseLength { get { return _palletSolutionDesc.CaseDimensions[0]; } }
        /// <summary>
        /// Case width
        /// </summary>
        public double CaseWidth { get { return _palletSolutionDesc.CaseDimensions[1]; } }
        /// <summary>
        /// Case height
        /// </summary>
        public double CaseHeight { get { return _palletSolutionDesc.CaseDimensions[2]; } }
        /// <summary>
        /// Case weight
        /// </summary>
        public double CaseWeight { get { return _parentCaseAnalysis.BoxProperties.Weight * BoxPerCaseCount + _palletSolutionDesc.CaseWeight; } }
        /// <summary>
        /// Pallet weight
        /// </summary>
        public double PalletWeight
        {
            get
            {
                return _palletSolutionDesc.CaseCount * CaseWeight + _palletSolutionDesc.PalletWeight; 
            } 
        }
        /// <summary>
        /// PalletSolution loaded from file
        /// </summary>
        public CasePalletSolution AttachedPalletSolution { get { return _palletSolutionDesc.LoadPalletSolution(); } }
        #endregion

        #region Adding layer / interlayer
        public BoxLayer CreateNewLayer(double zLow, string patternName)
        {
            BoxLayer layer = new BoxLayer(zLow, patternName);
            Add(layer);
            return layer;
        }
        public InterlayerPos CreateNewInterlayer(double zLow)
        {
            InterlayerPos layer = new InterlayerPos(zLow);
            Add(layer);
            return layer;
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            BoxCasePalletSolution sol = (BoxCasePalletSolution)obj;
            if (this.BoxPerPalletCount > sol.BoxPerPalletCount)
                return -1;
            else if (this.BoxPerPalletCount == sol.BoxPerPalletCount)
            {
                if ((sol.Count > 0 && sol[0] is BoxLayer)
                    && (this.Count > 0 && this[0] is BoxLayer))
                {
                    BoxLayer layerSol = (BoxLayer)sol[0];
                    int iPatternSol = PatternNameToIndex(layerSol.PatternName);
                    BoxLayer layerThis = (BoxLayer)this[0];
                    int iPatternThis = PatternNameToIndex(layerThis.PatternName);

                    if (iPatternSol > iPatternThis)
                        return -1;
                    else if (iPatternSol == iPatternThis)
                        return 0;
                    else
                        return 1;                    
                }
                return 0;
            }
            else
                return 1; 
        }
        private int PatternNameToIndex(string patternName)
        {
            if (string.Equals(patternName, "Column"))               return 0;
            else if (string.Equals(patternName, "Interlocked"))     return 1;
            else if (string.Equals(patternName, "Trilock"))         return 2;
            else if (string.Equals(patternName,  "Diagonale"))      return 3;
            else if (string.Equals(patternName, "Spirale"))         return 4;
            else if (string.Equals(patternName, "Enlarged spiral")) return 5;
            else return 6;        
        }
        #endregion
    }
}
