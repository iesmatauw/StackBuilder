#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using TreeDim.StackBuilder.GUIExtension.Properties;
#endregion

namespace TreeDim.StackBuilder.GUIExtension
{
    public partial class FormDefineReport : Form
    {
        #region Constructor
        public FormDefineReport()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override 
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // set report type
            cbReportType.SelectedIndex = Settings.Default.ReportTypeIndex;
            // get default path for reports
            fileSelectCtrl.FileName = DefaultPath;
            // check / uncheck open generated file
            chkOpenFile.Checked = Settings.Default.OpenGeneratedFile;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            // save report type
            Settings.Default.ReportTypeIndex = cbReportType.SelectedIndex;
            // save directory
            Settings.Default.DefaultDirectory = Path.GetDirectoryName(FilePath);
            // save check box state
            Settings.Default.OpenGeneratedFile = chkOpenFile.Checked;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Project name is used to build default file path
        /// </summary>
        public string ProjectName
        {
            set { _projName = value; }
        }
        /// <summary>
        /// File extension to be used to infer report type
        /// </summary>
        public string FileExtension
        {
            get
            {
                switch (cbReportType.SelectedIndex)
                {
                    case 0: return "doc";
                    case 1: return "html";
                    default: return string.Empty;
                }
            }
        }
        public string FileFilter
        {
            get
            {
                switch (cbReportType.SelectedIndex)
                {
                    case 0: return "Microsoft Word (*.doc)|*.doc";
                    case 1: return "Html (*.html)|*.html";
                    default: return string.Empty;
                }
            }
        }
        /// <summary>
        /// File path
        /// </summary>
        public string FilePath
        { get { return fileSelectCtrl.FileName; } }
        /// <summary>
        /// open generated file
        /// </summary>
        public bool OpenGeneratedFile
        {
            get { return chkOpenFile.Checked; }
        }
        #endregion

        #region Handlers
        private void cbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filePath = fileSelectCtrl.FileName;
            fileSelectCtrl.Filter = FileFilter;
            fileSelectCtrl.FileName = Path.ChangeExtension(filePath, FileExtension);
        }
        #endregion

        #region Private helpers
        private string DefaultPath
        {
            get
            { 
                // get directory path
                string path = Path.Combine(Settings.Default.DefaultDirectory, _projName);
                return Path.ChangeExtension(path, FileExtension);
            }
        }
        #endregion

        #region Data members
        private string _projName;
        #endregion


    }
}
