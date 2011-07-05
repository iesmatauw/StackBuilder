#region Using directive
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine.TestCaseOptimisation
{
    class Program
    {
        static void Main(string[] args)
        {
            // define box properties
            BoxProperties boxProperties = new BoxProperties(null, 120.0, 100.0, 70.0);
            // define pallet properties
            PalletProperties palletProperties = new PalletProperties(null, PalletProperties.PalletType.BLOCK, 1200, 1000, 150);
            // define pallet constraintSet
            PalletConstraintSetBox constraintSet = new PalletConstraintSetBox();
            constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_N, true);
            constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_P, true);
            constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_N, true);
            constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_P, true);
            constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_N, true);
            constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_P, true);

            constraintSet.SetAllowedPattern("Column");
            constraintSet.SetAllowedPattern("Diagonale");
            constraintSet.SetAllowedPattern("Interlocked");
            constraintSet.SetAllowedPattern("Trilock");
            constraintSet.SetAllowedPattern("Spirale");

            constraintSet.AllowAlignedLayers = true;
            constraintSet.AllowAlternateLayers = true;

            constraintSet.MaximumHeight = 2000;
            constraintSet.MaximumNumberOfItems = 2000;
            constraintSet.UseMaximumHeight = true;
            constraintSet.UseMaximumPalletWeight = false;
            constraintSet.UseMaximumWeightOnBox = false;
            Console.WriteLine("=== Constraint set ===");
            Console.WriteLine(constraintSet.ToString());

            // define case optim constraintSet
            CaseOptimConstraintSet caseOptimConstraintSet = new CaseOptimConstraintSet(
                new int[3]{2, 2, 4}
                , 4.0
                , new Vector3D(30.0, 30.0, 70.0)
                , new Vector3D(500.0, 500.0, 500.0)
                , false
                );

            CaseOptimizer caseOptimizer = new CaseOptimizer(boxProperties, palletProperties, constraintSet, caseOptimConstraintSet);

            // get all valid case definitions
            foreach (CaseDefinition caseDefinition in caseOptimizer.CaseDefinitions(48))
                Console.WriteLine(caseDefinition.ToString() + caseDefinition.OuterDimensions(boxProperties, caseOptimConstraintSet));
            // build list of solutions
            List<CaseOptimSolution> caseOptimSolutions = caseOptimizer.CaseOptimSolutions(48);
            foreach (CaseOptimSolution caseOptimSolution in caseOptimSolutions)
                Console.WriteLine(caseOptimSolution.ToString());
        }
    }
}
