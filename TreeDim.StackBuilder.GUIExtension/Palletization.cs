#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Engine;
#endregion

namespace TreeDim.StackBuilder.GUIExtension
{
    public class Palletization
    {
        public Palletization()
        {
        }

        public void StartPalletization(double length, double width, double height)
        {
            // show analysis details dialog
            FormDefineAnalysis formDefinition = new FormDefineAnalysis();
            formDefinition.CaseLength = length;
            formDefinition.CaseWidth = width;
            formDefinition.CaseHeight = height;

            if (DialogResult.OK != formDefinition.ShowDialog())
                return;

            // build list of solutions
            CasePalletAnalysis analysis = new CasePalletAnalysis(
                formDefinition.Case
                , formDefinition.Pallet
                , formDefinition.Interlayer
                , formDefinition.Constraints);

            // solve
            CasePalletSolver solver = new CasePalletSolver();
            solver.ProcessAnalysis(analysis);

            // select solution / generate report / generate StackBuilder file
        
        }
    }
}
