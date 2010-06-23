#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public class DocumentSB : Document, IDocument
    {
        #region Data members
        private string _filePath;
        private bool _dirty = false;
        private List<IView> _views = new List<IView>();
        private IView _activeView;
        public event EventHandler Modified;
        #endregion

        #region Constructor
        public DocumentSB(string filePath, IDocumentListener listener)
            :base(filePath, listener)
        {
            _dirty = false;
        }
        public DocumentSB(string name, string description, string author, IDocumentListener listener)
            : base(name, description, author, DateTime.Now, listener)
        {
            _dirty = false;
        }
        #endregion

        #region Public properties
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        #endregion

        #region IDocument implementation
        public bool IsDirty { get { return _dirty; } }
        public bool IsNew { get { return string.IsNullOrEmpty(_filePath); } }
        public void Save()
        {
            if (IsNew) return;
            Write(_filePath);
            _dirty = false;
        }

        public void SaveAs(string filePath)
        {
            _filePath = filePath;
            Save();
        }

        public void Close(CancelEventArgs e)
        {
            foreach (IView view in Views)
                view.Close();
            base.Close();
        }

        public override void Modify()
        {
            _dirty = true;
            if (null != Modified)
                Modified(this, new EventArgs());
        }

        public List<IView> Views { get { return _views; } }

        public IView ActiveView
        {
            set
            {
                _activeView = value;
                _activeView.Activate();
            }
            get
            {
                return _activeView;
            }
        }
        #endregion

        #region View creation methods
        public DockContentAnalysis CreateAnalysisView(Analysis analysis)
        {
            DockContentAnalysis form = new DockContentAnalysis(this, analysis);
            _views.Add(form);
            return form;
        }
        #endregion
    }
}
