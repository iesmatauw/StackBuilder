#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class PalletFilmProperties : ItemBase
    {
        #region Data members
       
        #endregion

        #region Constructors
        public PalletFilmProperties(Document doc)
            : base(doc)
        { 
        }

        public PalletFilmProperties(Document doc,
            string name, string description)
            : base(doc)
        {
        }
        #endregion

        #region Public properties
        #endregion
    }
}
