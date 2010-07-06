using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDim.StackBuilder.Basics
{
    /// <summary>
    /// Gathers a set of constraint to be used while computing solutions
    /// </summary>
    public class ConstraintSet
    {
        #region Data members
        private int _maxNumberOfItems;
        private double _maximumPalletWeight;
        private double _maximumHeight;
        private double _overhangX, _overhangY;
        private bool _useMaximumPalletWeight;
        private bool _useMaximumHeight;
        private bool _useMaximumNumberOfItems;
        private bool _useMaximumWeightOnBox;
        private bool[] _allowedOrthoAxis = new bool[6];
        private bool _allowAlternateLayers = true;
        private bool _allowAlignedLayers = false;
        private System.Collections.Specialized.StringCollection _allowedPatterns = new System.Collections.Specialized.StringCollection();
        private bool _hasInterlayer;
        private int _interlayerPeriod;
        #endregion

        #region Constructor
        public ConstraintSet()
        {
            for (int i = 0; i < 6; ++i) _allowedOrthoAxis[i] = false;
        }
        #endregion

        #region Validity
        public bool IsValid
        {
            get
            {
                return _useMaximumNumberOfItems
                || _useMaximumHeight
                || _useMaximumWeightOnBox
                || _useMaximumPalletWeight;
            }
        }
        #endregion

        #region Allowed layer alignments
        public bool AllowAlignedLayers
        {
            set { _allowAlignedLayers = value;  }
            get { return _allowAlignedLayers;   }
        }
        public bool AllowAlternateLayers
        {
            set { _allowAlternateLayers = value;  }
            get { return _allowAlternateLayers; }
        }
        #endregion

        #region Stop conditions
        public bool UseMaximumNumberOfItems
        {
            set { _useMaximumNumberOfItems = value; }
            get { return _useMaximumNumberOfItems; }
        }
        public bool UseMaximumHeight
        {
            set { _useMaximumHeight = value; }
            get { return _useMaximumHeight; }
        }
        public bool UseMaximumPalletWeight
        {
            set { _useMaximumPalletWeight = value; }
            get { return _useMaximumPalletWeight; }
        }
        public bool UseMaximumWeightOnBox
        {
            set { _useMaximumWeightOnBox = value; }
            get { return _useMaximumWeightOnBox; }
        }
        public int MaximumNumberOfItems
        {
            set
            {
                _useMaximumNumberOfItems = true;
                _maxNumberOfItems = value;
            }
            get { return _maxNumberOfItems; }
        }
        public double MaximumPalletWeight
        {
            set
            {
                _useMaximumPalletWeight = true;
                _maximumPalletWeight = value;
            }
            get { return _maximumPalletWeight; }
        }
        public double MaximumHeight
        {
            set
            {
                _useMaximumHeight = true;
                _maximumHeight = value;
            }
            get { return _maximumHeight; }
        }
        #endregion

        #region Allowed patterns and box axis
        public void SetAllowedPattern(string patternName)
        {
            _allowedPatterns.Add(patternName);
        }
        public bool AllowPattern(string patternName)
        {
            return _allowedPatterns.Contains(patternName);
        }
        public string AllowedPatternString
        {
            get
            {
                string sGlobal = string.Empty;
                foreach (string s in _allowedPatterns)
                    sGlobal += s + ";";
                return sGlobal;
            }
        }
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
                if (AllowOrthoAxis(HalfAxis.HAxis.AXIS_X_N)) sGlobal += "X-;";
                if (AllowOrthoAxis(HalfAxis.HAxis.AXIS_X_P)) sGlobal += "X+;";
                if (AllowOrthoAxis(HalfAxis.HAxis.AXIS_Y_N)) sGlobal += "Y-;";
                if (AllowOrthoAxis(HalfAxis.HAxis.AXIS_Y_P)) sGlobal += "Y+;";
                if (AllowOrthoAxis(HalfAxis.HAxis.AXIS_Z_N)) sGlobal += "Z-;";
                if (AllowOrthoAxis(HalfAxis.HAxis.AXIS_Z_P)) sGlobal += "Z+;";
                return sGlobal;
            }
        }
        #endregion

        #region Overhang / underhang
        public double OverhangX
        {
            get { return _overhangX; }
            set { _overhangX = value; }
        }
        public double OverhangY
        {
            get { return _overhangY; }
            set { _overhangY = value; }
        }
        #endregion

        #region Interlayer
        public bool HasInterlayer
        {
            get { return _hasInterlayer; }
            set { _hasInterlayer = value; }
        }
        public int InterlayerPeriod
        {
            get { return _interlayerPeriod; }
            set { _interlayerPeriod = value; }
        }
        #endregion

        #region Allow new layer / allow new box
        public bool AllowNewLayer(int iNoLayer)
        {
            return !_useMaximumWeightOnBox;
        }
        public bool AllowNewBox(int iNoBox)
        {
            return !_useMaximumNumberOfItems || (iNoBox <= _maxNumberOfItems);
        }
        #endregion

        #region Object method override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (_useMaximumHeight) sb.AppendLine(string.Format("Maximum height = {0}", _maximumHeight));
            if (_useMaximumPalletWeight) sb.AppendLine(string.Format("Maximum pallet weight = {0}", _maximumPalletWeight));
            if (_useMaximumWeightOnBox) sb.AppendLine(string.Format("Maximum weight on box = {0}", 0.0));
            if (_useMaximumNumberOfItems) sb.AppendLine(string.Format("Maximum number of items = {0}", _maxNumberOfItems));

            return sb.ToString();
        }
        #endregion
    }
}
