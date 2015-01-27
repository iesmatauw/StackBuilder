#region Data members
using System;
using System.Collections.Generic;
using System.Text;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public abstract class BCaseConstraintSet
    {
        #region Data members
        /// <summary>
        /// maximum case weight
        /// </summary>
        private bool _useCaseMaximumWeight = false;
        private double _maximumCaseWeight;
        /// <summary>
        /// maximum number of boxes
        /// </summary>
        private bool _useMaximumNumberOfBoxes = false;
        private int _maximumNumberOfBoxes;
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
        #endregion

        #region Maximum number of boxes
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

        #region Public properties
        public abstract bool AllowOrthoAxis(HalfAxis.HAxis orthoAxis);
        public abstract bool IsValid { get; }
        #endregion
    }

    public class BoxCaseConstraintSet : BCaseConstraintSet
    {
        #region Data members
        /// <summary>
        /// allowed ortho axis
        /// </summary>
        private bool[] _allowedOrthoAxis = new bool[6];
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(BoxCaseConstraintSet));
        #endregion

        #region Constructor
        public BoxCaseConstraintSet()
        { 
        }
        #endregion

        #region Validity
        public override bool IsValid
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
        public override bool AllowOrthoAxis(HalfAxis.HAxis orthoAxis)
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
    }

    public class BundleCaseConstraintSet : BCaseConstraintSet
    {
        #region Constructors
        public BundleCaseConstraintSet()
        { 
        }
        #endregion

        #region Public properties
        public override bool AllowOrthoAxis(HalfAxis.HAxis orthoAxis)
        {
            return (orthoAxis == HalfAxis.HAxis.AXIS_Z_N) || (orthoAxis == HalfAxis.HAxis.AXIS_Z_P);
        }
        public override bool IsValid { get { return true; } }
        #endregion
    }
}
