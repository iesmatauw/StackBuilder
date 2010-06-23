#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public interface IDocument
    {
        string Name { get; }
        string FilePath { get; }
        bool IsDirty { get; }
        bool IsNew { get; }
        void Save();
        void SaveAs(string context);
        void Close();
        List<IView> Views { get; }
        IView ActiveView { get; }

        event EventHandler Modified;
    }


}
