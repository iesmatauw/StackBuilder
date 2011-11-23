#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml;

using log4net;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Reporting
{
    public class ReporterHtml : Reporter
    {
        #region Constructor
        /// <summary>
        /// ReportHtml : generate html report
        /// </summary>
        public ReporterHtml(ReportData inputData, string templatePath,  string outpuFilePath)
        {
            BuildAnalysisReport(inputData, templatePath, outpuFilePath);
        }
        #endregion

        #region Override Reporter
        public override bool RetrieveXsltTemplate(string reportTemplatePath, ref string xsltTemplateFilePath)
        {
            // report template name
            string xsltFileName = string.Format("ReportTemplateHTML_{0}.xsl"
                , System.Globalization.CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName);
            // report file path
            xsltTemplateFilePath = Path.Combine(reportTemplatePath, xsltFileName);
            // check if file can be found, else get default
            if (!File.Exists(xsltTemplateFilePath))
                xsltTemplateFilePath = Path.Combine(reportTemplatePath, "ReportTemplateHtml_ENU.xsl");
            // check template file existence
            if (!File.Exists(xsltTemplateFilePath))
                throw new FileNotFoundException(string.Format("Failed to find template file {0}", xsltTemplateFilePath), xsltTemplateFilePath);
            return true;
        }

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
