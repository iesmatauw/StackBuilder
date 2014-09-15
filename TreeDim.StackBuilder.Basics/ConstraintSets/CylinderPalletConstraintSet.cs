#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class CylinderPalletConstraintSet
    {
        #region Data members
        // Maximum number of items
        private bool _useMaximumNumberOfItems = false;
        private int _maxNumberOfItems;
        // Maximum pallet weight
        private bool _useMaximumPalletWeight = false;
        private double _maximumPalletWeight;
        // Maximum pallet height
        private bool _useMaximumHeight = false;
        private double _maximumHeight;
        // Maximum load on lower cylinder
        private bool _useMaximumWeightOnLowerCylinder;
        private double _maximumLoadOnLowerCylinder;
        /// <summary>
        /// Overhang in direction X and Y
        /// </summary>
        private double _overhangX, _overhangY;
        /// <summary>
        /// Interlayer
        /// </summary>
        private bool _hasInterlayer;
        private int _interlayerPeriod;

        private System.Collections.Specialized.StringCollection _allowedPatterns = new System.Collections.Specialized.StringCollection();
        #endregion

        #region Constructor
        public CylinderPalletConstraintSet()
        {
        }
        #endregion

        #region Validity
        public bool IsValid
        {
            get
            {
                bool hasValidStopCriterion =
                    _useMaximumNumberOfItems
                    || _useMaximumHeight
                    || _useMaximumPalletWeight;
                return hasValidStopCriterion;
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
            set
            {
                _hasInterlayer = value; 
            }
        }
        public int InterlayerPeriod
        {
            get { return _interlayerPeriod; }
            set { _interlayerPeriod = value; }
        }
        #endregion

        #region Stop conditions
        /// <summary>
        /// Use maximum height stop condition
        /// </summary>
        public bool UseMaximumPalletHeight
        {
            get { return _useMaximumHeight; }
            set { _useMaximumHeight = value; }
        }
        public double MaximumPalletHeight
        {
            get { return _maximumHeight; }
            set { _useMaximumHeight = true; _maximumHeight = value; }
        }
        /// <summary>
        /// Use maximum pallet weight stop condition
        /// </summary>
        public bool UseMaximumPalletWeight
        {
            get { return _useMaximumPalletWeight; }
            set { _useMaximumPalletWeight = value; }
        }
        public double MaximumPalletWeight
        {
            get { return _maximumPalletWeight; }
            set { _useMaximumPalletWeight = true; _maximumPalletWeight = value; }
        }
        /// <summary>
        /// Use maximum load on lower cylinder
        /// </summary>
        public bool UseMaximumLoadOnLowerCylinder
        {
            get { return _useMaximumWeightOnLowerCylinder; }
            set { _useMaximumWeightOnLowerCylinder = value; }
        }
        public double MaximumLoadOnLowerCylinder
        {
            get { return _maximumLoadOnLowerCylinder; }
            set { _maximumLoadOnLowerCylinder = value; }
        }
        /// <summary>
        /// Use maximum number of items
        /// </summary>
        public bool UseMaximumNumberOfItems
        {
            get { return _useMaximumNumberOfItems; }
            set { _useMaximumNumberOfItems = value; }
        }
        public int MaximumNumberOfItems
        {
            get { return _maxNumberOfItems; }
            set { _useMaximumNumberOfItems = true; _maxNumberOfItems = value; }
        }
        #endregion

        #region Object method override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (_useMaximumHeight) sb.AppendLine(string.Format("Maximum height = {0}", _maximumHeight));
            if (_useMaximumPalletWeight) sb.AppendLine(string.Format("Maximum pallet weight = {0}", _maximumPalletWeight));
            if (_useMaximumNumberOfItems) sb.AppendLine(string.Format("Maximum number of items = {0}", _maxNumberOfItems));
            sb.AppendLine(IsValid ? "=> is valid" : "=> is invalid");
            return sb.ToString();
        }
        #endregion
    }
}
