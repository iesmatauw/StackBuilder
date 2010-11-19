#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    /// <summary>
    /// Solves CaseAnalysis
    /// </summary>
    public class CaseSolver : ICaseAnalysisSolver
    {
        #region Public methods
        public List<CaseSolution> GenerateSolutions()
        {
            List<CaseSolution> list = new List<CaseSolution>();
            return list;
        }
        #endregion

        #region ICaseAnalysisSolver implementation
        public void ProcessAnalysis(CaseAnalysis analysis)
        {
            analysis.Solutions = GenerateSolutions();
        }
        #endregion
    }
}
