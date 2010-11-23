#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class CaseConstraintSet
    {
        #region Data members
        private bool _allowAlternateLayers = true;
        private bool _allowAlignedLayers = false;
        private System.Collections.Specialized.StringCollection _allowedPatterns = new System.Collections.Specialized.StringCollection();
        private bool _useNoSolutionsKept;
        private int _noSolutionsKept;
        private bool[] _allowedOrthoAxis = new bool[6];
        #endregion

        #region Constructor
        #endregion

        #region Validity
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
                    if (AllowOrthoAxis(HalfAxis.HAxis.AXIS_X_N))
                        sGlobal += HalfAxis.ToString(axis);
                }
                return sGlobal;
            }
        }
        #endregion
    }
}
