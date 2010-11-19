#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public interface IItemListener
    {
        void Update(ItemBase itemFrom);
        void Kill(ItemBase itemFrom);
    }

    /// <summary>
    /// This class holds Name / description properties for Box / Pallet / Interlayer / Analysis
    /// it also handle dependancy problems
    /// </summary>
    public class ItemBase : IDisposable
    {
        #region Data members
        // parent document
        private Document _parentDocument;
        // name / description
        protected string _name, _description;
        // guid
        protected Guid _guid = Guid.NewGuid();
        // dependancies
        private List<ItemBase> _dependancies = new List<ItemBase>();
        // Track whether Dispose has been called.
        private bool disposed = false;
        // listeners
        List<IItemListener> _listeners = new List<IItemListener>();
        // logger
        static readonly ILog _log = LogManager.GetLogger(typeof(ItemBase));
        #endregion

        #region Constructors
        public ItemBase(Document document)
        {
            _parentDocument = document;
        }
        public ItemBase(Document document, string name, string description)
        {
            _parentDocument = document;
            _name = name;
            _description = description;
        }
        #endregion

        #region Public properties
        public Document ParentDocument
        {
            get { return _parentDocument; }
        }
        public Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion

        #region Dependancies
        public void AddDependancie(ItemBase dependancie)
        {
            if (_dependancies.Contains(dependancie))
            {
                _log.Warn(string.Format("Tried to add {0} as a dependancy of {1} a second time!", dependancie.Name, this.Name));
                return;
            }
            _dependancies.Add(dependancie);    
        }
        public bool HasDependingAnalyses
        { get { return _dependancies.Count > 0; } }
        public void RemoveDependancie(ItemBase dependancie)
        {   _dependancies.Remove(dependancie);  }
        protected void Modify()
        {
            // update dependancies
            foreach (ItemBase item in _dependancies)
                item.OnAttributeModified(this);
            // update listeners
            UpdateListeners();
            // update parent document
            if (null != _parentDocument)
                _parentDocument.Modify();
        }
        public void EndUpdate()
        {
            // update dependancies
            foreach (ItemBase item in _dependancies)
                item.OnEndUpdate(this);
        }
        public virtual void OnAttributeModified(ItemBase modifiedAttribute) {}
        public virtual void OnEndUpdate(ItemBase updatedAttribute) {}
        protected virtual void RemoveItselfFromDependancies() {}
        protected virtual void OnDispose() {}
        #endregion

        #region IDisposable implementation
        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this); 
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects.
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                OnDispose();
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources
                    int iCount = _dependancies.Count;
                    while (_dependancies.Count > 0)
                    {
                        _parentDocument.RemoveItem(_dependancies[0]);
                        if (_dependancies.Count == iCount)
                        {
                            _log.Warn(string.Format("Failed to remove correcly dependancy {0} ", _dependancies[0].Name));
                            _dependancies.Remove(_dependancies[0]);
                            break;
                        }
                    }
                }
                RemoveItselfFromDependancies();
                KillListeners();
                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false, only the following code is executed.
 
                // Note disposing has been done.
                disposed = true;
            }
        }
        #endregion

        #region Object overrides
        public override string ToString()
        {
            return string.Format("Name:{0} \nDescription: {1}\n", _name, _description);
        }
        #endregion

        #region Listeners
        public void AddListener(IItemListener listener)
        {
            _listeners.Add(listener);
        }
        public void RemoveListener(IItemListener listener)
        {
            _listeners.Remove(listener);
        }
        protected void UpdateListeners()
        {
            foreach (IItemListener listener in _listeners)
                listener.Update(this);
        }
        protected void KillListeners()
        {
            while (_listeners.Count > 0)
                _listeners[0].Kill(this);
        }
        #endregion
    }
}
