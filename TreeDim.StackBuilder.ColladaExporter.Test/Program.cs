#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using log4net;
using log4net.Config;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Engine;
using TreeDim.StackBuilder.Graphics;
using TreeDim.StackBuilder.ColladaExporter;
#endregion

namespace TreeDim.StackBuilder.ColladaExporter.Test
{
    #region Program
    class Program
    {
        static void Main(string[] args)
        {
            ILog log = LogManager.GetLogger(typeof(Program));
            XmlConfigurator.Configure();

            try
            {
                // check arguments
                if (args.Length != 1)
                {
                    log.Info("No command argument. Exiting...");
                    return;
                }
                if (!File.Exists(args[0]))
                {
                    log.Info(string.Format("File {0} could not be found. Exiting...", args[0]));
                    return;
                }

                string filePath = args[0];
                string outputPath = Path.ChangeExtension(filePath, "dae");
                // load document
                Document doc = new Document(filePath, new DocumentListenerLog());
                // get first analysis
                List<CasePalletAnalysis> analyses = doc.Analyses;
                if (analyses.Count == 0)
                {
                    log.Info("Document has no analysis -> Exiting...");
                    return;
                }
                CasePalletAnalysis analysis = analyses[0];
                if (analysis.Solutions.Count == 0)
                {
                    log.Info("Analysis has no solution -> Exiting...");
                    return;
                }

                PalletSolution palletSolution = analysis.Solutions[0];
                // export collada file
                ColladaExporter.Exporter exporter = new Exporter(palletSolution);
                exporter.Export(outputPath);
                log.Debug(string.Format("Successfully exported {0} ...", outputPath));

                // browse file
                Exporter.BrowseWithGoogleChrome(outputPath);

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }
    }
    #endregion

    #region DocumentListener -> Log
    internal class DocumentListenerLog : IDocumentListener
    {
        #region Data members
        static protected ILog _log = LogManager.GetLogger(typeof(Program));
        #endregion

        #region Override
        public void OnNewDocument(Document doc)
        {
            _log.Info(string.Format("Opened document {0}", doc.Name));
        }
        public void OnNewTypeCreated(Document doc, ItemBase itemBase)
        {
            _log.Info(string.Format("Loaded item {0}", itemBase.Name));
        }
        public void OnNewAnalysisCreated(Document doc, CasePalletAnalysis analysis)
        {
            _log.Info(string.Format("Loaded analysis {0}", analysis.Name));
        }
        public void OnNewCaseAnalysisCreated(Document doc, BoxCasePalletAnalysis caseAnalysis)
        {
            _log.Info(string.Format("Loaded case analysis {0}", caseAnalysis.Name));
        }
        public void OnNewTruckAnalysisCreated(Document doc, CasePalletAnalysis analysis, SelSolution selectedSolution, TruckAnalysis truckAnalysis)
        {
        }
        public void OnNewECTAnalysisCreated(Document doc, CasePalletAnalysis analysis, SelSolution selectedSolution, ECTAnalysis ectAnalysis)
        {
        }
        public void OnTypeRemoved(Document doc, ItemBase itemBase)
        {
        }
        public void OnAnalysisRemoved(Document doc, CasePalletAnalysis analysis)
        {
        }
        public void OnCaseAnalysisRemoved(Document doc, BoxCasePalletAnalysis caseAnalysis)
        {
        }
        public void OnTruckAnalysisRemoved(Document doc, CasePalletAnalysis analysis, SelSolution selectedSolution, TruckAnalysis truckAnalysis)
        {
        }
        public void OnECTAnalysisRemoved(Document doc, CasePalletAnalysis analysis, SelSolution selectedSolution, ECTAnalysis ectAnalysis)
        {
        }
        public void OnDocumentClosed(Document doc)
        {
        }
        #endregion
    }
    #endregion
}
