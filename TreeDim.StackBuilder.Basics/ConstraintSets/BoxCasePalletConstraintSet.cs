#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class BoxCasePalletConstraintSet
    {
        #region Data members
        private bool _allowAlternateLayers = true;
        private bool _allowAlignedLayers = false;
        private System.Collections.Specialized.StringCollection _allowedPatterns = new System.Collections.Specialized.StringCollection();
        private bool[] _allowedOrthoAxis = new bool[6];
        private bool _useNoSolutionsKept, _useMinimumBoxPerCase, _useMaxNumberOfItems, _useCaseMaximumWeight;
        private int _noSolutionsKept, _minimumBoxPerCase, _maxNumberOfItems;
        private double _maximumCaseWeight;
        #endregion

        #region Constructor
        public BoxCasePalletConstraintSet()
        { 
        }
        #endregion

        #region Validity
        public bool IsValid
        {
            get
            {
                // stop criterions
                bool hasValidStopCriterion = true;
                // allowed otho axis
                bool allowsAtLeastOneOrthoAxis = false;
                for (int i = 0; i < 6; ++i)
                {
                    if (AllowOrthoAxis((HalfAxis.HAxis)i))
                    {
                        allowsAtLeastOneOrthoAxis = true;
                        break;
                    }
                }
                return hasValidStopCriterion
                    && allowsAtLeastOneOrthoAxis
                    && _allowedPatterns.Count > 0
                    && (!_useNoSolutionsKept || _noSolutionsKept > 0);
            }
        }
        #endregion

        #region Allowed layer alignments
        public bool AllowAlignedLayers
        {
            set { _allowAlignedLayers = value; }
            get { return _allowAlignedLayers; }
        }
        public bool AllowAlternateLayers
        {
            set { _allowAlternateLayers = value; }
            get { return _allowAlternateLayers; }
        }
        #endregion

        #region Allowed patterns
        public void ClearAllowedPatterns()
        {
            _allowedPatterns.Clear();
        }
        public void SetAllowedPattern(string patternName)
        {
            if (patternName == string.Empty) return;
            _allowedPatterns.Add(patternName);
        }
        public bool AllowPattern(string patternName)
        {
            return _allowedPatterns.Contains(patternName);
        }
        public string AllowedPatternString
        {
            set
            {
                string[] patternNames = value.Split(',');
                foreach (string patternName in patternNames)
                    SetAllowedPattern(patternName);
            }
            get
            {
                string sGlobal = string.Empty;
                foreach (string patternName in _allowedPatterns)
                {
                    if (!string.IsNullOrEmpty(sGlobal))
                        sGlobal += ",";
                    sGlobal += patternName;
                }
                return sGlobal;
            }
        }
        #endregion

        #region Allowed box axis
        public bool AllowOrthoAxis(HalfAxis.HAxis orthoAxis)
        {
            return _allowedOrthoAxis[(int)orthoAxis];
        }
        public void SetAllowedOrthoAxis(HalfAxis.HAxis axis, bool allowed)
        {
            _allowedOrthoAxis[(int)axis] = allowed;
        }
        public string AllowOrthoAxisString
        {
            get
            {
                string sGlobal = string.Empty;
                for (int i = 0; i < 6; ++i)
                {
                    if (!string.IsNullOrEmpty(sGlobal))
                        sGlobal += ",";
                    HalfAxis.HAxis axis = (HalfAxis.HAxis)i;
                    if (AllowOrthoAxis(axis))
                        sGlobal += HalfAxis.ToString(axis);
                }
                return sGlobal;
            }
            set
            {
                string[] sAxes = value.Split(',');
                foreach (string sAxis in sAxes)
                    SetAllowedOrthoAxis(HalfAxis.Parse(sAxis), true);            
            }
        }
        #endregion

        #region Interlayer
        public bool HasInterlayer
        { get { return false; } }
        public int InterlayerPeriod
        { get { throw new NotImplementedException(); } }
        public bool HasInterlayerAntiSlip
        { get { return false; } }
        #endregion

        #region Minimum number of box
        /// <summary>
        /// Use minimum number of box per case
        /// </summary>
        public bool UseMinimumNumberOfItems
        {
            set { _useMinimumBoxPerCase = value; }
            get { return _useMinimumBoxPerCase; }
        }
        /// <summary>
        /// Minimum number of box per case
        /// </summary>
        public int MinimumNumberOfItems
        {
            set { _minimumBoxPerCase = value; }
            get { return _minimumBoxPerCase; }
        }
        #endregion

        #region Maximum number of items
        /// <summary>
        /// Use maximum number of items
        /// </summary>
        public bool UseMaximumNumberOfItems
        {
            set { _useMaxNumberOfItems = value; }
            get { return _useMaxNumberOfItems; }
        }
        /// <summary>
        /// Maximum number of items
        /// </summary>
        public int MaximumNumberOfItems
        {
            set { _maxNumberOfItems = value; }
            get { return _maxNumberOfItems; }
        }
        #endregion

        #region Maximum case weight
        /// <summary>
        /// Use maximum case weight
        /// </summary>
        public bool UseMaximumCaseWeight
        {
            set { _useCaseMaximumWeight = value; }
            get { return _useCaseMaximumWeight; }
        }
        /// <summary>
        /// Maximum case weight
        /// </summary>
        public double MaximumCaseWeight
        {
            set { _maximumCaseWeight = value;  }
            get { return _maximumCaseWeight; }
        }
        #endregion

        #region Number of solutions kept
        /// <summary>
        /// Use number of solutions kept
        /// </summary>
        public bool UseNumberOfSolutionsKept
        {
            set { _useNoSolutionsKept = value; }
            get { return _useNoSolutionsKept; }
        }
        public int NumberOfSolutionsKept
        {
            set
            {
                _useNoSolutionsKept = true;
                _noSolutionsKept = value;
            }
            get { return _noSolutionsKept; }
        }
        #endregion
    }
}
