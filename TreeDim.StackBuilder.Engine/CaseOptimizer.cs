#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using PrimeFactorisation;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    public class BoxArrangement
    {
        public BoxArrangement(int iLength, int iWidth, int iHeight)
        {
            _iLength = iLength; _iWidth = iWidth;   _iHeight = iHeight;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("({0}, {1}, {2})", _iLength, _iWidth, _iHeight);
            return sb.ToString(); ;

        }

        public int _iLength, _iWidth, _iHeight;
    }

    public class PrimeMultiple
    {
        public PrimeMultiple(int iPrime, int iMultiple)
        {
            _iPrime = iPrime; _iMultiple = iMultiple;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("({0}, {1})", _iPrime, _iMultiple);
            return sb.ToString(); ;
        }

        public int _iPrime, _iMultiple;
    }

    public class CaseOptimizer
    {
        #region Helpers
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

        public void Decomp1(List<PrimeMultiple> primeMultiples, int iStep, ref int[] multiples1, ref List<BoxArrangement> listArrangements)
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

        public void Decomp2(List<PrimeMultiple> primeMultiples, int iStep, int[] multiples1, ref int[] multiples2, ref List<BoxArrangement> listArrangements)
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
    }
}
