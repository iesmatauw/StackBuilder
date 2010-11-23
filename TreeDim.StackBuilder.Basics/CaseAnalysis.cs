#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using log4net;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region CaseAnalysis
    public class CaseAnalysis : ItemBase
    {
        #region Data members
        private BoxProperties _boxProperties;
        private List<PalletSolutionDesc> _palletSolutionsList = new List<PalletSolutionDesc>();
        private List<CaseSolution> _caseSolutions = new List<CaseSolution>();
        private CaseConstraintSet _constraintSet;
        static readonly ILog _log = LogManager.GetLogger(typeof(CaseAnalysis));
        #endregion

        #region Constructor
        public CaseAnalysis(BProperties boxProperties, List<PalletSolutionDesc> palletSolutionList, CaseConstraintSet constraintSet)
            : base(boxProperties.ParentDocument)
        { 
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Box properties
        /// </summary>
        public BoxProperties BoxProperties
        {
            get { return _boxProperties; }
            set { _boxProperties = value; }
        }
        /// <summary>
        /// List of pallet solutions evaluated in this analysis
        /// </summary>
        public List<PalletSolutionDesc> PalletSolutionsList
        {
            get { return _palletSolutionsList; }
        }
        /// <summary>
        /// List of solutions
        /// </summary>
        public List<CaseSolution> Solutions
        {
            get { return _caseSolutions; }
            set
            {
                _caseSolutions = value;
                foreach (CaseSolution caseSolution in _caseSolutions)
                    caseSolution.ParentCaseAnalysis = this;
            }
        }
        /// <summary>
        /// Case analysis contraint set
        /// </summary>
        public CaseConstraintSet ConstraintSet
        {
            get { return _constraintSet; }
        }
        #endregion


    }
    #endregion

    #region IAnalysisSolver
    public interface ICaseAnalysisSolver
    {
        void ProcessAnalysis(CaseAnalysis analysis);
    }
    #endregion
}
