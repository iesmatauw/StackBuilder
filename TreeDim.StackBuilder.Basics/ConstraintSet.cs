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
        private bool _useMaximumPalletWeight;
        private bool _useMaximumHeight;
        private bool _useMaximumNumberOfItems;
        private bool _useMaximumWeightOnBox;
        #endregion

        #region Constructor
        public ConstraintSet()
        {
        }
        #endregion

        #region Public properties
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

        public bool ForceAlternateLayer
        {
            get { return false; }
        }
        public bool AllowAlternateLayer
        {
            get { return true; }
        }
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
            get
            {
                return _maxNumberOfItems;
            }
        }
        public double MaximumPalletWeight
        {
            set
            {
                _useMaximumPalletWeight = true;
                _maximumPalletWeight = value;
            }
            get
            {
                return _maximumPalletWeight;
            }
        }
        public double MaximumHeight
        {
            set
            {
                _useMaximumHeight = true;
                _maximumHeight = value;
            }
            get
            {
                return _maximumHeight;
            }
        }
        #endregion

        #region Public methods
        public bool AllowPattern(string patternName)
        {
            return true;
        }
        public bool AllowNewLayer(int iNoLayer)
        {
            return !_useMaximumWeightOnBox;
        }
        public bool AllowNewBox(int iNoBox)
        {
            return !_useMaximumNumberOfItems || (iNoBox <= _maxNumberOfItems);
        }
        public bool AllowOrthoAxis(HalfAxis orthoAxis)
        {
            return true;
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
