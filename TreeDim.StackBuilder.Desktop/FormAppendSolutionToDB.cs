#region Data members
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
    public partial class FormAppendSolutionToDB : Form
    {
        #region Constructor
        public FormAppendSolutionToDB()
        {
            InitializeComponent();
        }
        #endregion

        #region Public properties
        public string FriendlyName
        {
            get { return tbFriendlyName.Text; }
            set { tbFriendlyName.Text = value; }
        }
        #endregion
    }
}
