#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace treeDiM.StackBuilder.Plugin
{
    public interface IPlugin
    {
        bool onFileNew(ref string fileName);
    }
}
