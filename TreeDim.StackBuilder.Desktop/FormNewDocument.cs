#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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

        private void onDocumentNameChanged(object sender, EventArgs e)
        {
            bnAccept.Enabled = (DocName.Length > 0);
        }
    }
}