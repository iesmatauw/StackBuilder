#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml;

using log4net;

using TreeDim.StackBuilder.Basics;


using Microsoft.Office.Interop;
#endregion

namespace TreeDim.StackBuilder.Reporting
{
    public class ReporterMSWord : Reporter
    {
        #region Constructor
        public ReporterMSWord(ReportData inputData, string templatePath, string outputFilePath)
        {
            // html file path
            string htmlFilePath = Path.ChangeExtension(outputFilePath, "html");
            BuildAnalysisReport(inputData, templatePath, htmlFilePath);

            // opens word
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;
            Microsoft.Office.Interop.Word.Document wordDoc = wordApp.Documents.Open(htmlFilePath, false, true, NoEncodingDialog: true);
            // embed pictures (unlinking images)
            for (int i = 1; i <= wordDoc.InlineShapes.Count; ++i)
            {
                if (null != wordDoc.InlineShapes[i].LinkFormat && !wordDoc.InlineShapes[i].LinkFormat.SavePictureWithDocument)
                    wordDoc.InlineShapes[i].LinkFormat.SavePictureWithDocument = true;
            }
            // set margins (unit?)
            wordDoc.PageSetup.TopMargin = 10.0f;
            wordDoc.PageSetup.BottomMargin = 10.0f;
            wordDoc.PageSetup.RightMargin = 10.0f;
            wordDoc.PageSetup.LeftMargin = 10.0f;
            // set print view 
            wordApp.ActiveWindow.ActivePane.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdPrintView;
            wordDoc.SaveAs(outputFilePath, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocumentDefault);
            _log.Info(string.Format("Saved doc report to {0}", outputFilePath));
            // delete image directory
            DeleteImageDirectory();
            // delete html report
            File.Delete(htmlFilePath);
        }
        #endregion

        #region Override Reporter
        public override bool WriteNamespace
        {
            get { return false; }
        }
        public override bool WriteImageFiles
        {
            get { return true; }
        }
        #endregion
    }
}
