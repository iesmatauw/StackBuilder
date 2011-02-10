#region Using directive
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Engine.TestCaseOptimisation
{
    class Program
    {
        static void Main(string[] args)
        {
            CaseOptimizer caseOptimizer = new CaseOptimizer();
            caseOptimizer.NoWalls = new int[3]{2, 2, 4};
            caseOptimizer.CaseLimitMax = new Vector3D(500.0, 500.0, 500.0);
            caseOptimizer.CaseLimitMin = new Vector3D(30.0, 30.0, 70.0);
            caseOptimizer.BoxDimensions = new Vector3D(120.0, 100.0, 70.0);
            caseOptimizer.WallThickness = 4.0;

            foreach (CaseDefinition caseDefinition in caseOptimizer.CaseDefinitions(48))
            {
                Console.WriteLine(caseDefinition.ToString() + caseDefinition.OuterDimensions(caseOptimizer));
            }


        }
    }
}
