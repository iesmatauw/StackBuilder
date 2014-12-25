using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewPalletCorners : TreeDim.StackBuilder.Desktop.FormNewBase
    {
        public FormNewPalletCorners()
        {
            InitializeComponent();
        }

        public double CornerWidth
        {
            get { return 0.0; }
        }

        public Color Color
        {
            get { return Color.Brown; }
        }
    }
}
