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
    public partial class FormNewPalletFilm : FormNewBase
    {
        #region Constructor
        public FormNewPalletFilm(Document document)
        {
            InitializeComponent();
        }
        #endregion

        #region FormNewBase overrides
        public override ItemBase Item
        {
            get
            {
                PalletFilmProperties palletFilm = new PalletFilmProperties(_document);
                return palletFilm;
            }
        }
        #endregion
    }
}
