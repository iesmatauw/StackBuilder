using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDim.StackBuilder.Basics
{
    public class BoxCaseSolution : IComparable
    {
        #region Data members
        private string _title;
        private BoxCaseAnalysis _boxCaseAnalysis;
        private BoxLayer _boxLayer;
        private int _iNoLayer;
        #endregion

        #region Constructor
        public BoxCaseSolution(BoxCaseAnalysis boxCaseAnalysis, string title)
        {
            _boxCaseAnalysis = boxCaseAnalysis;
            _title = title;
        }
        #endregion

        #region Public properties
        public BoxCaseAnalysis ParentBoxCaseAnalysis
        {
            get { return _boxCaseAnalysis; }
        }
        public int BoxPerCaseCount
        {
            get { return _boxLayer.BoxCount * _iNoLayer; }
        }
        #endregion

        #region Adding layer / interlayer
        public BoxLayer BoxLayer
        {
            set { _boxLayer = value; }
        }
        public int LayersCount
        {
            get { return _iNoLayer; }
            set { _iNoLayer = value; }
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            BoxCaseSolution sol = (BoxCaseSolution) obj;
            if (this.BoxPerCaseCount > sol.BoxPerCaseCount)
                return -1;
            else if (this.BoxPerCaseCount == sol.BoxPerCaseCount)
                return 0;
            else
                return 1;
        }
        #endregion
    }
}
