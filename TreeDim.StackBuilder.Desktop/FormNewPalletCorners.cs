#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewPalletCorners : TreeDim.StackBuilder.Desktop.FormNewBase
    {
        #region Constructor
        public FormNewPalletCorners(Document doc)
            : base(doc, null)
        {
            InitializeComponent();
        }
        public FormNewPalletCorners(Document doc, PalletCornerProperties item)
            : base(doc, item)
        {
            InitializeComponent();
        }
        #endregion

        #region Public properties
        public double CornerLength
        {
            get { return (double)nudLength.Value; }
            set { nudLength.Value = (decimal)value; }
        }
        public double CornerWidth
        {
            get { return (double)nudWidth.Value; }
            set { nudWidth.Value = (decimal)value;}
        }
        public double CornerThickness
        {
            get { return (double)nudThickness.Value; }
            set { nudThickness.Value = (decimal)value; }
        }
        public double CornerWeight
        {
            get { return (double)nudWeight.Value; }
            set { nudWeight.Value = (decimal)value; }
        }
        public Color Color
        {
            get { return cbColorCorners.Color; }
            set { cbColorCorners.Color = value; }
        }
        #endregion
    }
}
