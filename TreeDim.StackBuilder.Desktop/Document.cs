#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using TreeDim.StackBuilder.Graphics;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    class Document
    {
        #region Data members
        public List<BoxProperties> _boxList = new List<BoxProperties>();
        public List<PalletProperties> _palletProperties = new List<PalletProperties>();
        public List<Analysis> _analyses = new List<Analysis>();
        #endregion


    }
}
