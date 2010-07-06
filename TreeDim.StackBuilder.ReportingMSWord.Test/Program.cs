#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

using log4net;
using log4net.Config;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Engine;
using TreeDim.StackBuilder.Graphics;
using TreeDim.StackBuilder.ReportingMSWord;
#endregion

namespace TreeDim.StackBuilder.ReportingMSWord.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog log = LogManager.GetLogger(typeof(Program));
            XmlConfigurator.Configure();

            try
            {
                // load document
                Document doc = new Document(@"..\..\..\Samples\d1.stb",  new DocumentListenerLog());
                // get first analysis
                List<Analysis> analyses = doc.Analyses;
                if (analyses.Count == 0)
                {
                    log.Info("Document has no analysis -> Exiting...");
                    return;
                }
                // build output file path
                string outputFilePath = Path.ChangeExtension(Path.GetTempFileName(), "doc");
                string xsltTemplateFilePath = @"..\..\..\TreeDim.StackBuilder.ReportingMSWord\ReportTemplate\Report.xslt";
                Reporter.BuidAnalysisReport(analyses[0], analyses[0].Solutions[0], xsltTemplateFilePath, outputFilePath);

                Console.WriteLine("Saved report to: {0}", outputFilePath);
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();

                // Display resulting report in Word
                Process.Start(new ProcessStartInfo(outputFilePath));
                
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

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
            public void OnNewTypeCreated(Document doc, ItemProperties itemProperties)
            {
                _log.Info(string.Format("Loaded item {0}", itemProperties.Name));
            }
            public void OnNewAnalysisCreated(Document doc, Analysis analysis)
            {
                _log.Info(string.Format("Loaded analysis {0}", analysis.Name));
            }
            public void OnTypeRemoved(Document doc, Analysis analysis)
            { 
            }
            public void OnAnalysisRemoved(Document doc, Analysis analysis)
            { 
            }
            public void OnDocumentClosed(Document doc)
            { 
            }
            #endregion
        }
        #endregion
    }
}
