#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    interface IDocumentFactory
    {
        void NewDocument();
        void OpenDocument(string filePath);
        void SaveDocument();
        void CloseDocument();

        void AddDocument(IDocument doc);
        List<IDocument> Documents { get; }

        IView ActiveView { get; }
        IDocument ActiveDocument { get; }
    }
}
