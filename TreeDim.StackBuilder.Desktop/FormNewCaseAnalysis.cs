#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using log4net;

using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewCaseAnalysis : Form
    {
        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(FormNewCaseAnalysis));
        #endregion

        #region Constructor
        public FormNewCaseAnalysis()
        {
            InitializeComponent();
        }
        #endregion

        #region Public properties
        public string CaseAnalysisName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string CaseAnalysisDescription
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        #endregion

        #region Load / FormClosing event
        private void FormNewCaseAnalysis_Load(object sender, EventArgs e)
        {

        }

        private void FormNewCaseAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion
    }
}
