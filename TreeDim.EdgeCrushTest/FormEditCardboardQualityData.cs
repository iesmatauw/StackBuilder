#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#endregion

namespace TreeDim.EdgeCrushTest
{
    public partial class FormEditCardboardQualityData : Form
    {
        #region Data members
        enum Mode
        { MODE_CREATE
            , MODE_MODIFY}
        #endregion

        #region Constructor
        public FormEditCardboardQualityData()
        {
            InitializeComponent();
        }
        #endregion
    }
}
