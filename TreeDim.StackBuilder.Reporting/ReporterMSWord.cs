﻿#region Using directives
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
    #region Margins
    public class Margins
    {
        public Margins()
        {
            _top = Properties.Settings.Default.MarginTop;
            _bottom = Properties.Settings.Default.MarginBottom;
            _left = Properties.Settings.Default.MarginLeft;
            _right = Properties.Settings.Default.MarginRight;
        }
        public float Top { get { return _top > 0.0f ? _top : 0.0f; } }
        public float Bottom { get { return _bottom > 0.0f ? _bottom : 0.0f; } }
        public float Left { get { return _left > 0.0f ? _left : 0.0f; } }
        public float Right { get { return _right > 0.0f ? _right : 0.0f; } }
        private float _top = 10.0f
            , _bottom = 10.0f
            , _right = 10.0f
            , _left = 10.0f;
    }
    #endregion
    #region ReporterMSWord
    public class ReporterMSWord : Reporter
    {
        #region Constructor
        public ReporterMSWord(ReportData inputData
            , string templatePath, string outputFilePath, Margins margins)
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
            wordDoc.PageSetup.TopMargin = wordApp.CentimetersToPoints(margins.Top);
            wordDoc.PageSetup.BottomMargin = wordApp.CentimetersToPoints(margins.Bottom);
            wordDoc.PageSetup.RightMargin = wordApp.CentimetersToPoints(margins.Right);
            wordDoc.PageSetup.LeftMargin = wordApp.CentimetersToPoints(margins.Left);
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
#endregion
}
