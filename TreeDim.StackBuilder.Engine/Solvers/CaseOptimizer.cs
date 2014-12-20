#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using PrimeFactorisation;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
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

    #region CaseOptimizer
    public class CaseOptimizer
    {
        #region Constructor
        public CaseOptimizer(
            BoxProperties boxProperties
            , PalletProperties palletProperties
            , PalletConstraintSet palletContraintSet
            , CaseOptimConstraintSet caseOptimConstraintSet)
        {
            _boxProperties = boxProperties;
            _palletProperties = palletProperties;
            _palletConstraintSet = palletContraintSet;
            _caseOptimConstraintSet = caseOptimConstraintSet;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Build a list of all case definitions given a number of box
        /// </summary>
        /// <param name="iNumber">Number of items to fit in box</param>
        /// <returns></returns>
        public List<CaseDefinition> CaseDefinitions(int iNumber)
        {
            List<CaseDefinition> caseDefinitionList = new List<CaseDefinition>();
            foreach (CaseOptimArrangement arr in BoxArrangements(iNumber))
            {
                for (int i=0; i<3; ++i)
                    for (int j=0; j<3; ++j)
                    {
                        if (j == i)
                            continue;

                        CaseDefinition caseDefinition = new CaseDefinition(arr, i, j);
                        if (caseDefinition.IsValid(_boxProperties, _caseOptimConstraintSet))
                            caseDefinitionList.Add(caseDefinition);
                    }
            }
            return caseDefinitionList;
        }

        public List<CaseOptimSolution> CaseOptimSolutions(int iNumber)
        {
            List<CaseOptimSolution> caseOptimSolutions = new List<CaseOptimSolution>();

            foreach (CaseDefinition caseDefinition in CaseDefinitions(iNumber))
            {
                Vector3D outerDimensions = caseDefinition.OuterDimensions(_boxProperties, _caseOptimConstraintSet);
                BoxProperties bProperties = new BoxProperties(_palletProperties.ParentDocument, outerDimensions.X, outerDimensions.Y, outerDimensions.Z);
                // build analysis
                CasePalletAnalysis casePalletAnalysis = new CasePalletAnalysis(bProperties, _palletProperties, null, null, _palletConstraintSet);
                // instantiate solver
                CasePalletSolver solver = new CasePalletSolver();
                // solve
                solver.ProcessAnalysis(casePalletAnalysis);
                // get list of pallet solutions
                List<CasePalletSolution> palletSolutions = casePalletAnalysis.Solutions;
                if (palletSolutions.Count > 0)
                {
                    int maxCaseCount = palletSolutions[0].CaseCount;
                    int i = 0;
                    while (maxCaseCount == palletSolutions[i].CaseCount)
                    {
                        caseOptimSolutions.Add(new CaseOptimSolution(caseDefinition, palletSolutions[i]));
                        ++i;
                    }
                }
            }
            // sort caseOptimSolution
            caseOptimSolutions.Sort();
            return caseOptimSolutions;
        }

        /// <summary>
        /// Pallet properties
        /// </summary>
        public PalletProperties PalletProperties
        {
            set { _palletProperties = value; }
            get { return _palletProperties; }
        }
        /// <summary>
        /// Product BoxProperties
        /// </summary>
        public BoxProperties BoxProperties
        {
            set { _boxProperties = value; }
            get { return _boxProperties; }
        }
        /// <summary>
        ///  Palletization constraint set
        /// </summary>
        public PalletConstraintSet ConstraintSet
        {
            set { _palletConstraintSet = value; }
            get { return _palletConstraintSet; }
        }
        #endregion

        #region Helpers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        public IEnumerable<CaseOptimArrangement> BoxArrangements(int iNumber)
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

            List<CaseOptimArrangement> listArrangements = new List<CaseOptimArrangement>();
            // Decomp
            int[] multiples1 = new int[primeMultiples.Count];
            Decomp1(primeMultiples, 0, ref multiples1, ref listArrangements);
            return listArrangements;
        }

        private void Decomp1(List<PrimeMultiple> primeMultiples, int iStep, ref int[] multiples1, ref List<CaseOptimArrangement> listArrangements)
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

        private void Decomp2(List<PrimeMultiple> primeMultiples, int iStep, int[] multiples1, ref int[] multiples2, ref List<CaseOptimArrangement> listArrangements)
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
                listArrangements.Add(new CaseOptimArrangement(iLength, iWidth, iHeight));
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
        #endregion

        #region Data members
        /// <summary>
        /// case optim constraint set
        /// </summary>
        CaseOptimConstraintSet _caseOptimConstraintSet;
        /// <summary>
        /// Input product used to search solution
        /// </summary>
        private BoxProperties _boxProperties;
        /// <summary>
        /// Input pallet properties
        /// </summary>
        private PalletProperties _palletProperties;
        /// <summary>
        /// Input palletization contraint set
        /// </summary>
        private PalletConstraintSet _palletConstraintSet;
        #endregion
    }
    #endregion
}
