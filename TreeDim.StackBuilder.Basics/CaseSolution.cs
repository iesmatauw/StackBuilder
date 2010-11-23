#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class CaseSolution : List<ILayer>, IComparable
    {
        #region Data members
        private string _title;
        List<BoxPosition> _boxPositions = new List<BoxPosition>();
        CaseAnalysis _parentCaseAnalysis;
        PalletSolutionDesc _palletSolutionDesc;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="caseAnalysis">Parent case analysis reference</param>
        public CaseSolution(string title, CaseAnalysis caseAnalysis)
        {
            _title = title;
            _parentCaseAnalysis = caseAnalysis;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Parent analysis
        /// </summary>
        public CaseAnalysis ParentCaseAnalysis
        {
            set { _parentCaseAnalysis = value; }
            get { return _parentCaseAnalysis; }
        }
        /// <summary>
        /// Number of boxes in case
        /// </summary>
        public int BoxInCaseCount
        {
            get { return _boxPositions.Count; }
        }
        /// <summary>
        /// Number of boxes on pallet
        /// </summary>
        public int BoxOnPalletCount
        {
            get { return _boxPositions.Count * _palletSolutionDesc.CaseCount; }
        }
        /// <summary>
        /// Case efficiency
        /// </summary>
        public double CaseEfficiency
        {
            get { return 100.0; }
        }
        public double PalletEfficiency
        {
            get { return 100.0; }
        }


        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return _title; }
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            CaseSolution sol = (CaseSolution)obj;
            if (this.BoxOnPalletCount > sol.BoxOnPalletCount)
                return -1;
            else if (this.BoxOnPalletCount == sol.BoxOnPalletCount)
                return 0;
            else
                return 1; 
        }
        #endregion
    }
}
