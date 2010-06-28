#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewDocument : Form
    {
        #region Constructor
        public FormNewDocument()
        {
            InitializeComponent();

            tbDateCreated.Text = string.Format("{0}", DateTime.Now);
            onDocumentNameChanged(this, null);
        }
        #endregion

        #region Public properties
        public string DocName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string DocDescription
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        public string Author
        {
            get { return tbAuthor.Text; }
            set { tbAuthor.Text = value; }
        }
        public DateTime DateCreated
        {
            get { return Convert.ToDateTime(tbDateCreated.Text); }
            set { tbDateCreated.Text = string.Format("{0}", value); }
        }
        #endregion

        #region Event handlers
        private void onDocumentNameChanged(object sender, EventArgs e)
        {
            bnAccept.Enabled = (DocName.Length > 0);
        }
        #endregion

        #region Load / FormClosing event
        private void FormNewDocument_Load(object sender, EventArgs e)
        {
            // author
            Author = Settings.Default.DocumentAuthor;
            // windows settings
            if (null != Settings.Default.FormNewDocumentPosition)
                Settings.Default.FormNewDocumentPosition.Restore(this);
        }
        private void FormNewDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            // author
            Settings.Default.DocumentAuthor = Author;
            // window position
            if (null == Settings.Default.FormNewDocumentPosition)
                Settings.Default.FormNewDocumentPosition = new WindowSettings();
            Settings.Default.FormNewDocumentPosition.Record(this);
        }
        #endregion
    }
}