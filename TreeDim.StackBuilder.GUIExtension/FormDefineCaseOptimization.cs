using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeDim.StackBuilder.GUIExtension
{
    public partial class FormDefineCaseOptimization : Form
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FormDefineCaseOptimization()
        {
            InitializeComponent();
        }
        #endregion

        #region Public properties
        public string BoxName
        {
            get { return _boxName; }
            set { _boxName = value; }
        }
        public double BoxLength
        {
            get { return Convert.ToDouble(nudBoxLength.Value); }
            set { nudBoxLength.Value = Convert.ToDecimal(value); }
        }
        public double BoxWidth
        {
            get { return Convert.ToDouble(nudBoxWidth.Value); }
            set { nudBoxWidth.Value = Convert.ToDecimal(value); }
        }
        public double BoxHeight
        {
            get { return Convert.ToDouble(nudBoxHeight.Value); }
            set { nudBoxHeight.Value = Convert.ToDecimal(value); }
        }
        #endregion

        #region Data members
        private string _boxName;
        #endregion
    }
}
