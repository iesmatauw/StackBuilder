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
        static readonly ILog _log = LogManager.GetLogger(typeof(CaseAnalysis));
        #endregion

        #region Constructor
        public CaseAnalysis(Document document)
            : base(document)
        { 
        }
        #endregion
    }
    #endregion
}
