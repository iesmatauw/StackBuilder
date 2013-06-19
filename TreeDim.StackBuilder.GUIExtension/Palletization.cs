#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Engine;
using TreeDim.StackBuilder.GUIExtension.Properties;
using System.IO;
#endregion

namespace TreeDim.StackBuilder.GUIExtension
{
    public class Palletization
    {
        public Palletization()
        {
        }

        public void StartPalletization(string name, double length, double width, double height)
        {
            // show analysis details dialog
            FormDefineAnalysis formDefinition = new FormDefineAnalysis();
            formDefinition.CaseName = name;
            formDefinition.CaseLength = length;
            formDefinition.CaseWidth = width;
            formDefinition.CaseHeight = height;

            if (DialogResult.OK != formDefinition.ShowDialog())
                return;

            // create document
            Document doc = new Document(name, name + "_on_" + formDefinition.Pallet.Name, "from extension component", DateTime.Now, null);
            // create case in document
            BoxProperties caseInDoc = doc.CreateNewCase(formDefinition.Case);
            // create pallet in document
            PalletProperties palletInDoc = doc.CreateNewPallet(formDefinition.Pallet);
            // create interlayer in document
            InterlayerProperties interlayerInDoc = formDefinition.Interlayer == null ? null : doc.CreateNewInterlayer(formDefinition.Interlayer);

            // solver
            CasePalletSolver solver = new CasePalletSolver();
            // build list of solutions
            CasePalletAnalysis analysis = doc.CreateNewCasePalletAnalysis(
                string.Format(Resources.ID_ANALYSISNAME, name, formDefinition.Pallet.Name)
                , string.Format(Resources.ID_ANALYSISDESCRIPTION, name, formDefinition.Pallet.Name)
                , caseInDoc
                , palletInDoc
                , interlayerInDoc
                , formDefinition.Constraints
                , solver);
             
            // select solution / generate report / generate StackBuilder file
            FormSelectSolution formSolutions = new FormSelectSolution(doc, analysis);
            if (DialogResult.OK == formSolutions.ShowDialog())
                return;        
        }

        public void StartCaseOptimization(string name, double length, double width, double height)
        {
            FormDefineCaseOptimization formCaseOptimization = new FormDefineCaseOptimization();
            formCaseOptimization.BoxName = name;
            formCaseOptimization.BoxLength = length;
            formCaseOptimization.BoxWidth = width;
            formCaseOptimization.BoxHeight = height;

            formCaseOptimization.ShowDialog();

        }
    }
}
