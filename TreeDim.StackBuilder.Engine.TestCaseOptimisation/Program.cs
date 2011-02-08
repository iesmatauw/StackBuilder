#region Using directive
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Engine.TestCaseOptimisation
{
    class Program
    {
        static void Main(string[] args)
        {
            CaseOptimizer caseOptimizer = new CaseOptimizer();
            caseOptimizer.BoxArrangements(180);

            foreach (BoxArrangement arr in caseOptimizer.BoxArrangements(180))
                Console.WriteLine(arr.ToString());
        }
    }
}
