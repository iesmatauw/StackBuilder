#region Data members
using System;
using System.Collections.Generic;
using System.Text;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class BoxCaseConstraintSet
    {
        #region Data members
        /// <summary>
        /// allowed ortho axis
        /// </summary>
        private bool[] _allowedOrthoAxis = new bool[6];
        /// <summary>
        /// number of solutions kept
        /// </summary>
        private bool _useNoSolutionsKept;
        private int _noSolutionsKept;
        /// <summary>
        /// maximum case weight
        /// </summary>
        private bool _useCaseMaximumWeight;
        private double _maximumCaseWeight;
        /// <summary>
        /// maximum number of boxes
        /// </summary>
        private bool _useMaximumNumberOfBoxes;
        private int _maximumNumberOfBoxes;
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(BoxCaseConstraintSet));
        #endregion

        #region Validity
        public bool IsValid
        {
            get
            {
                bool allowsAtLeastOneOrthoAxis = false;
                for (int i = 0; i < 6; ++i)
                {
                    if (AllowOrthoAxis((HalfAxis.HAxis)i))
                    {
                        allowsAtLeastOneOrthoAxis = true;
                        break;
                    }
                }
                return allowsAtLeastOneOrthoAxis;
            }
        }
        #endregion

        #region Allowed box axis
        public void SetAllowedOrthoAxisAll()
        { 
            for (int i = 0; i < 6; ++i) _allowedOrthoAxis[i] = true;
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
            set { _maximumCaseWeight = value; }
            get { return _maximumCaseWeight; }
        }
        /// <summary>
        /// Use maximum number of boxes
        /// </summary>
        public bool UseMaximumNumberOfBoxes
        {
            set { _useMaximumNumberOfBoxes = value; }
            get { return _useMaximumNumberOfBoxes; }
        }
        /// <summary>
        /// Maximum number of boxes
        /// </summary>
        public int MaximumNumberOfBoxes
        {
            set { _maximumNumberOfBoxes = value; }
            get { return _maximumNumberOfBoxes; }
        }
        #endregion

        #region Number of solutions kept
        /// <summary>
        /// Use 
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
