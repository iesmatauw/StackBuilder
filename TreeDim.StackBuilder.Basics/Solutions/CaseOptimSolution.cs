#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Sharp3D.Math.Core;
using System.Text.RegularExpressions;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region CaseOptimConstraintSet
    public class CaseOptimConstraintSet
    {
        #region Constructor
        public CaseOptimConstraintSet(int[] noWalls, double wallThickness, Vector3D caseLimitMin, Vector3D caseLimitMax, bool forceVerticalCaseOrientation)
        {
            NoWalls = noWalls;
            _wallThickness = wallThickness;
            _caseLimitMin = caseLimitMin;
            _caseLimitMax = caseLimitMax;
            _forceVerticalCaseOrientation = forceVerticalCaseOrientation;
        }
        #endregion

        #region Data members
        private bool _forceVerticalCaseOrientation;
        /// <summary>
        /// Case wall thickness
        /// </summary>
        private double _wallThickness;
        /// <summary>
        /// Number of walls in each direction (used to compute outer case dimensions)
        /// </summary>
        private int[] _noWalls = new int[3];
        /// <summary>
        /// Optimal case min / max size limits
        /// </summary>
        private Vector3D _caseLimitMin, _caseLimitMax;
        #endregion

        #region Public properties
        public double WallThickness
        {
            get { return _wallThickness; }
            set { _wallThickness = value; }
        }
        public Vector3D CaseLimitMin
        {
            get { return _caseLimitMin; }
            set { _caseLimitMin = value; }
        }
        public Vector3D CaseLimitMax
        {
            get { return _caseLimitMax; }
            set { _caseLimitMax = value; }
        }
        public int[] NoWalls
        {
            get { return _noWalls; }
            set { for (int i = 0; i < 3; ++i)   _noWalls[i] = value[i]; }
        }
        public bool ForceVerticalcaseOrientation
        {
            get { return _forceVerticalCaseOrientation; }
            set { _forceVerticalCaseOrientation = value; }
        }
        #endregion

        #region Public properties
        public int GetNoWalls(int iDir)
        {
            return _noWalls[iDir];
        }
        #endregion
    }
    #endregion

    #region CaseOptimArrangement
    public class CaseOptimArrangement
    {
        #region Constructor
        public CaseOptimArrangement(int iLength, int iWidth, int iHeight)
        {
            _iLength = iLength; _iWidth = iWidth;   _iHeight = iHeight;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Number of inner boxes
        /// </summary>
        public int Number
        {
            get { return _iLength * _iWidth * _iHeight; }
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _iLength, _iWidth, _iHeight);
        }
        #endregion

        #region Parsing
        public static CaseOptimArrangement TryParse(string value)
        { 
            string regularExp = "(?<i1>.*) (?<i2>.*) (?<i3>.*)";
			Regex r = new Regex(regularExp, RegexOptions.Singleline);
    		Match m = r.Match(value);
		    if (m.Success)
                return new CaseOptimArrangement(int.Parse(m.Result("${i1}")), int.Parse(m.Result("${i2}")), int.Parse(m.Result("${i3}"))) ;
		    else
			    throw new Exception("Failed parsing int[3] from " + value );
        }
        #endregion

        #region Data members
        public int _iLength, _iWidth, _iHeight;
        #endregion
    }
    #endregion

    #region CaseOptimDefinition
    public class CaseDefinition
    {
        #region Data members
        private CaseOptimArrangement _arrangement;
        private int _dim0, _dim1;
        #endregion

        #region Constructor
        /// <summary>
        /// Case definition constructor
        /// </summary>
        /// <param name="arrangement">Box arrangement</param>
        /// <param name="dim0">Dim 0 is 0, 1 or 2</param>
        /// <param name="dim1">Dim 1 is 0, 1 or 2</param>
        public CaseDefinition(CaseOptimArrangement arrangement, int dim0, int dim1)
        {
            _arrangement = arrangement;
            _dim0 = dim0;
            _dim1 = dim1;
        }
        #endregion

        #region Public properties
        public CaseOptimArrangement Arrangement
        {   get { return _arrangement; }    }
        public double BoxLength(BoxProperties boxProperties)
        { return boxProperties.Dim(_dim0); }
        public double BoxWidth(BoxProperties boxProperties)
        { return boxProperties.Dim(_dim1); }
        public double BoxHeight(BoxProperties boxProperties)
        { return boxProperties.Dim(Dim2); }
        public double Area(BoxProperties boxProperties, CaseOptimConstraintSet constraintSet)
        {
            Vector3D outerDim = OuterDimensions(boxProperties, constraintSet);
            return constraintSet.NoWalls[0] * outerDim.Y * outerDim.Z
                + constraintSet.NoWalls[1] * outerDim.X * outerDim.Z
                + constraintSet.NoWalls[2] * outerDim.X * outerDim.Y;
        }
        public double InnerVolume(BoxProperties boxProperties)
        {
            Vector3D innerDim = InnerDimensions(boxProperties);
            return innerDim.X * innerDim.Y * innerDim.Z;
        }
        public double OuterVolume(BoxProperties boxProperties, CaseOptimConstraintSet constraintSet)
        {
            Vector3D outerDim = OuterDimensions(boxProperties, constraintSet);
            return outerDim.X * outerDim.Y * outerDim.Z;
        }
        public double Weight(BoxProperties boxProperties)
        {
            return _arrangement.Number * boxProperties.Weight;
        }

        #endregion

        #region Public methods referring CaseOptimizer
        /// <summary>
        /// Inner dimensions
        /// </summary>
        /// <param name="optimizer">Parent optimizer class</param>
        /// <returns>Inner dimensions stored in Vector3D</returns>
        public Vector3D InnerDimensions(BoxProperties boxProperties)
        {
            return new Vector3D(
                _arrangement._iLength * boxProperties.Dim(Dim0)
                , _arrangement._iWidth * boxProperties.Dim(Dim1)
                , _arrangement._iHeight * boxProperties.Dim(Dim2)
                );
        }
        /// <summary>
        ///  Outer dimensions
        /// </summary>
        /// <param name="optimizer">Parent optimizer class</param>
        /// <returns>Outer dimensions stored in Vector3D</returns>
        public Vector3D OuterDimensions(BoxProperties boxProperties, CaseOptimConstraintSet constraintSet)
        {
            return new Vector3D(
                _arrangement._iLength * boxProperties.Dim(Dim0) + constraintSet.WallThickness * constraintSet.NoWalls[0]
                , _arrangement._iWidth * boxProperties.Dim(Dim1) + constraintSet.WallThickness * constraintSet.NoWalls[1]
                , _arrangement._iHeight * boxProperties.Dim(Dim2) + constraintSet.WallThickness * constraintSet.NoWalls[2]
                );
        }
        public Vector3D InnerOffset(CaseOptimConstraintSet constraintSet)
        {
            return new Vector3D(
                0.5 * constraintSet.WallThickness * constraintSet.NoWalls[0]
                , 0.5 * constraintSet.WallThickness * constraintSet.NoWalls[1]
                , 0.5 * constraintSet.WallThickness * constraintSet.NoWalls[2]);
        }
        /// <summary>
        /// Returns true 
        /// </summary>
        /// <param name="optimizer"></param>
        /// <returns></returns>
        public bool IsValid(BoxProperties boxProperties, CaseOptimConstraintSet constraintSet)
        {
            Vector3D outerDim = OuterDimensions(boxProperties, constraintSet);
            return outerDim.X <= constraintSet.CaseLimitMax.X && outerDim.Y <= constraintSet.CaseLimitMax.Y && outerDim.Z <= constraintSet.CaseLimitMax.Z
                && outerDim.X >= constraintSet.CaseLimitMin.X && outerDim.Y >= constraintSet.CaseLimitMin.Y && outerDim.Z >= constraintSet.CaseLimitMin.Z
                && ((_dim0 == 0 && _dim1 == 1) || !constraintSet.ForceVerticalcaseOrientation);
        }
        #endregion

        #region System.Object override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} / ({1}, {2}, {3})", _arrangement.ToString(), Dim0, Dim1, Dim2);
            return sb.ToString();
        }
        #endregion

        #region Helpers
        public int Dim0 { get { return _dim0; } }
        public int Dim1 { get { return _dim1; } }
        public int Dim2 { get { return 3 - _dim0 - _dim1; } }
        #endregion
    }
    #endregion

    #region CaseOptimSolution
    /// <summary>
    /// Solution of CaseOptimAnalysis
    /// </summary>
    public class CaseOptimSolution
        : IComparable
    {
        #region Data members
        private CaseDefinition _caseDefinition;
        private CasePalletSolution _palletSolution;
        #endregion

        #region Constructor
        public CaseOptimSolution(CaseDefinition caseDefinition, CasePalletSolution palletSolution)
        {
            _caseDefinition = caseDefinition;
            _palletSolution = palletSolution;
        }
        #endregion

        #region Public properties
        public CasePalletSolution PalletSolution
        {  get { return _palletSolution; }  }
        public CaseDefinition CaseDefinition
        { get { return _caseDefinition; } }
        public int LayerCount
        { get { return _palletSolution.Count; } }
        public int CaseCount
        { get { return _palletSolution.CaseCount; } }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            CaseOptimSolution sol = (CaseOptimSolution)obj;
            if (this.CaseCount > sol.CaseCount)
                return -1;
            else if (this.CaseCount == sol.CaseCount)
                return 0;
            else
                return 1;
        }
        #endregion

        #region System.Object overrides
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Case definition:");
            sb.Append(_caseDefinition.ToString());
            sb.Append(" - Pallet solution:");
            sb.Append(" Cases ");
            sb.Append(_palletSolution.CaseCount);
            sb.Append(" Layers ");
            sb.Append(_palletSolution.Count);
            return sb.ToString();
        }
        #endregion
    }
    #endregion
}
