#region Data members
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    /// <summary>
    /// Form used to append solution to database
    /// User has to define friendly name
    /// He may also have to decide whether to keep or replace similar solutions
    /// </summary>
    public partial class FormAppendSolutionToDB : Form
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FormAppendSolutionToDB()
        {
            InitializeComponent();
            UpdateButtonOkStatus();
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Friendly name to use when saving solution to database
        /// </summary>
        public string FriendlyName
        {
            get { return tbFriendlyName.Text; }
            set { tbFriendlyName.Text = value; }
        }
        /// <summary>
        /// Set to true if similar solution already exists in database
        /// This will let the user decide if similar solutions can be kept
        /// </summary>
        public bool ShowSimilarSolutionQuestion
        {
            set
            {
                labelQuestion.Visible = value;
                rbKeepReplace1.Visible = value;
                rbKeepReplace2.Visible = value;
            }
        }
        /// <summary>
        /// if false, similar solutions will be destroyed
        /// </summary>
        public bool KeepSimilarSolutions
        {
            get { return rbKeepReplace1.Checked; }
            set
            {
                rbKeepReplace1.Checked = value;
                rbKeepReplace2.Checked = value;
            }
        }
        #endregion

        #region Status
        private void UpdateButtonOkStatus()
        {
            bnOk.Enabled = !string.IsNullOrEmpty(FriendlyName) && PalletSolutionDatabase.Instance.IsValidFriendlyName(FriendlyName, null);
            // status + message
            bool statusOk = true;
            string message = string.Empty;
            if (string.IsNullOrEmpty(FriendlyName))
            { statusOk = false; message = Resources.ID_FIELDNAMEEMPTY; }
            else if (!PalletSolutionDatabase.Instance.IsValidFriendlyName(FriendlyName, null))
            { statusOk = false; message = string.Format(Resources.ID_INVALIDNAME, FriendlyName); }
            else
            { statusOk = true; message = Resources.ID_READY; }
            // accept
            bnOk.Enabled = statusOk;
            if (statusOk) toolStripStatusLabelDef.ForeColor = Color.Black; else toolStripStatusLabelDef.ForeColor = Color.Red;
            toolStripStatusLabelDef.Text = message;
        }
        #endregion

        #region Event handlers
        private void tbFriendlyName_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        #endregion
    }
}
