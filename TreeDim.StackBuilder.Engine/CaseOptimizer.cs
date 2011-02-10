#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using PrimeFactorisation;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    #region Internal class BoxArrangement
    public class BoxArrangement
    {
        #region Constructor
        public BoxArrangement(int iLength, int iWidth, int iHeight)
        {
            _iLength = iLength; _iWidth = iWidth;   _iHeight = iHeight;
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("({0}, {1}, {2})", _iLength, _iWidth, _iHeight);
            return sb.ToString();
        }
        #endregion

        #region Data members
        public int _iLength, _iWidth, _iHeight;
        #endregion
    }
    #endregion

    #region Internal class PrimeMultiple
    internal class PrimeMultiple
    {
        #region Constructor
        public PrimeMultiple(int iPrime, int iMultiple)
        {
            _iPrime = iPrime; _iMultiple = iMultiple;
        }
        #endregion

        #region System.Object override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("({0}, {1})", _iPrime, _iMultiple);
            return sb.ToString(); ;
        }
        #endregion

        #region Data members
        public int _iPrime, _iMultiple;
        #endregion
    }
    #endregion

    #region CaseSolution
    public class CaseDefinition
    {
        #region Data members
        private BoxArrangement _arrangement;
        private int _dim0, _dim1;
        #endregion

        #region Constructor
        /// <summary>
        /// Case definition constructor
        /// </summary>
        /// <param name="arrangement">Box arrangement</param>
        /// <param name="dim0">Dim 0 is 0, 1 or 2</param>
        /// <param name="dim1">Dim 1 is 0, 1 or 2</param>
        public CaseDefinition(BoxArrangement arrangement, int dim0, int dim1)
        {
            _arrangement = arrangement;
            _dim0 = dim0;
            _dim1 = dim1;
        }
        #endregion

        #region Public methods referring CaseOptimizer
        /// <summary>
        /// Inner dimensions
        /// </summary>
        /// <param name="optimizer">Parent optimizer class</param>
        /// <returns>Inner dimensions stored in Vector3D</returns>
        public Vector3D InnerDimensions(CaseOptimizer optimizer)
        {
            return new Vector3D(
                _arrangement._iLength * optimizer.BoxDim(Dim0)
                , _arrangement._iWidth * optimizer.BoxDim(Dim1)
                , _arrangement._iHeight * optimizer.BoxDim(Dim2)
                );
        }
        /// <summary>
        ///  Outer dimensions
        /// </summary>
        /// <param name="optimizer">Parent optimizer class</param>
        /// <returns>Outer dimensions stored in Vector3D</returns>
        public Vector3D OuterDimensions(CaseOptimizer optimizer)
        {
            return new Vector3D(
                _arrangement._iLength * optimizer.BoxDim(Dim0) + optimizer.WallThickness * optimizer.NoWalls[0]
                , _arrangement._iWidth * optimizer.BoxDim(Dim1) + optimizer.WallThickness * optimizer.NoWalls[1]
                , _arrangement._iHeight * optimizer.BoxDim(Dim2) + optimizer.WallThickness * optimizer.NoWalls[2]
                );
        }
        /// <summary>
        /// Returns true 
        /// </summary>
        /// <param name="optimizer"></param>
        /// <returns></returns>
        public bool IsValid(CaseOptimizer optimizer)
        {
            Vector3D outerDim = OuterDimensions(optimizer);
            return outerDim.X <= optimizer.CaseLimitMax.X && outerDim.Y <= optimizer.CaseLimitMax.Y && outerDim.Z <= optimizer.CaseLimitMax.Z
                && outerDim.X >= optimizer.CaseLimitMin.X && outerDim.Y >= optimizer.CaseLimitMin.Y && outerDim.Z >= optimizer.CaseLimitMin.Z;
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
        private int Dim0 { get { return _dim0; } }
        private int Dim1 { get { return _dim1; } }
        private int Dim2 { get { return 3 - _dim0 - _dim1; } }
        #endregion
    }
    #endregion

    #region CaseOptimizer
    public class CaseOptimizer
    {
        #region Public methods
        /// <summary>
        /// Box dimensions
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>Box dimension in direction</returns>
        public double BoxDim(int direction)
        { 
            return _boxDimensions[direction];
        }
        /// <summary>
        /// Box properties
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        public List<CaseDefinition> CaseDefinitions(int iNumber)
        {
            List<CaseDefinition> caseDefinitionList = new List<CaseDefinition>();
            foreach (BoxArrangement arr in BoxArrangements(iNumber))
            {
                for (int i=0; i<3; ++i)
                    for (int j=0; j<3; ++j)
                    {
                        if (j == i)
                            continue;

                        CaseDefinition caseDefinition = new CaseDefinition(arr, i, j);
                        if (caseDefinition.IsValid(this))
                            caseDefinitionList.Add(caseDefinition);
                    }
            }
            return caseDefinitionList;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        public IEnumerable<BoxArrangement> BoxArrangements(int iNumber)
        {
            // get the prime factorisation of iNumber
            List<int> primeList = new List<int>(Eratosthenes.GetPrimeFactors(iNumber));
            primeList.Sort();
            // build list of prime multiple
            List<PrimeMultiple> primeMultiples = new List<PrimeMultiple>();
            int i = 0, j = 0;
            while (j < primeList.Count)
            {
                while (j < primeList.Count && primeList[j] == primeList[i])
                    ++j;
                primeMultiples.Add(new PrimeMultiple(primeList[i], j - i));
                i = j;
            }

            List<BoxArrangement> listArrangements = new List<BoxArrangement>();
            // Decomp
            int[] multiples1 = new int[primeMultiples.Count];
            Decomp1(primeMultiples, 0, ref multiples1, ref listArrangements);
            return listArrangements;
        }

        private void Decomp1(List<PrimeMultiple> primeMultiples, int iStep, ref int[] multiples1, ref List<BoxArrangement> listArrangements)
        {
            if (iStep == primeMultiples.Count)
            {
                int[] multiples2 = new int[primeMultiples.Count];
                Decomp2(primeMultiples, 0, multiples1, ref multiples2, ref listArrangements);
            }
            else
            {
                for (int i = 0; i <= primeMultiples[iStep]._iMultiple; ++i)
                {
                    multiples1[iStep] = i;
                    Decomp1(primeMultiples, iStep+1, ref multiples1, ref listArrangements);
                }
            }
        }

        private void Decomp2(List<PrimeMultiple> primeMultiples, int iStep, int[] multiples1, ref int[] multiples2, ref List<BoxArrangement> listArrangements)
        {
            if (iStep == primeMultiples.Count)
            {
                int iLength = 1;
                for (int i = 0; i < primeMultiples.Count; ++i)
                    iLength *= (int)Math.Pow(primeMultiples[i]._iPrime, multiples1[i]);
                int iWidth = 1;
                for (int i = 0; i < primeMultiples.Count; ++i)
                    iWidth *= (int)Math.Pow(primeMultiples[i]._iPrime, multiples2[i]);
                int iHeight = 1;
                for (int i = 0; i < primeMultiples.Count; ++i)
                    iHeight *= (int)Math.Pow(primeMultiples[i]._iPrime, primeMultiples[i]._iMultiple - multiples1[i] - multiples2[i]);
                // add new arrangement
                listArrangements.Add(new BoxArrangement(iLength, iWidth, iHeight));
            }
            else
            {
                for (int i=0; i <= (primeMultiples[iStep]._iMultiple-multiples1[iStep]); ++i)
                {
                    multiples2[iStep] = i;
                    Decomp2(primeMultiples, iStep+1, multiples1, ref multiples2, ref listArrangements);
                }
            }
        }
        #endregion

        #region Public properties
        public Vector3D BoxDimensions
        {
            get { return _boxDimensions; }
            set { _boxDimensions = value; }
        }
        /// <summary>
        /// Minimum size limit
        /// </summary>
        public Vector3D CaseLimitMin
        {
            get { return _caseLimitMin; }
            set { _caseLimitMin = value; }
        }
        /// <summary>
        /// Maximum size limit
        /// </summary>
        public Vector3D CaseLimitMax
        {
            get { return _caseLimitMax; }
            set { _caseLimitMax = value; }
        }
        /// <summary>
        /// Case wall thickness
        /// </summary>
        public double WallThickness
        {
            get { return _wallThickness; }
            set { _wallThickness = value; }
        }
        /// <summary>
        /// Case number of cardboard wall
        /// </summary>
        public int[] NoWalls
        {
            get { return _noWalls; }
            set { for (int i = 0; i < 3; ++i)   _noWalls[i] = value[i]; }
        }
        #endregion

        #region Data members
        private double _wallThickness;
        private int[] _noWalls = new int[3];
        Vector3D _caseLimitMin, _caseLimitMax;
        Vector3D _boxDimensions;
        #endregion
    }
    #endregion
}
