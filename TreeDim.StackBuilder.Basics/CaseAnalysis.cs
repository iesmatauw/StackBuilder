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
        private List<CaseSolution> _caseSolutions = new List<CaseSolution>();
        static readonly ILog _log = LogManager.GetLogger(typeof(CaseAnalysis));
        #endregion

        #region Constructor
        public CaseAnalysis(Document document)
            : base(document)
        { 
        }
        #endregion

        #region Public properties
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
