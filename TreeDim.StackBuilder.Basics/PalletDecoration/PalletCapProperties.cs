#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class PalletCapProperties : ItemBase
    {
        public PalletCapProperties(Document doc)
            : base(doc)
        { 
        }
        public PalletCapProperties(Document doc,
            string name, string description)
            : base(doc)
        {
        }
    }
}
