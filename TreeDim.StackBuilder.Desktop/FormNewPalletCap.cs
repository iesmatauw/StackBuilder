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
    public partial class FormNewPalletCap : FormNewBase
    {
        #region Constructor
        public FormNewPalletCap(Document document)
            : base(document)
        {
            InitializeComponent();
        }
        #endregion

        #region FormNewBase overrides
        public override ItemBase Item
        {
            get
            {
                PalletCapProperties palletCap = new PalletCapProperties(_document);
                return palletCap;
            }
        }
        #endregion
    }
}
