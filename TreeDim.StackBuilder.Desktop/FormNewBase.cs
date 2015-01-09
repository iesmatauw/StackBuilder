#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewBase : Form
    {
        #region Data members
        protected Document _document;
        protected ItemBase _item;
        #endregion

        #region Constructor
        /// <summary>
        /// constructor
        /// </summary>
        public FormNewBase(Document document, ItemBase item)
        {
            InitializeComponent();
            _document = document;
            _item = item;
        }
        #endregion

        #region Properties
        public string ItemName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string ItemDescription
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        public virtual ItemBase Item { get { return _item; } }
        #endregion

        public virtual void UpdateStatus(string message)
        {
            // status + message
            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            else if (!_document.IsValidNewTypeName(tbName.Text, Item))
                message = string.Format(Resources.ID_INVALIDNAME, tbName.Text);
            // description
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            bnOk.Enabled = string.IsNullOrEmpty(message);
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }

        private void onTextChanged(object sender, EventArgs e)
        {
            UpdateStatus(string.Empty);
        }
    }
}
