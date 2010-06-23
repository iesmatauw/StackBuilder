#region Using directives
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public interface IView
    {
        IDocument Document { get; }
        void Close();
        void Activate();

        event EventHandler Closed;
    }
}
