#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    #region AnalysisTreeView
    /// <summary>
    /// AnalysisTreeView : left frame treeview control
    /// </summary>
    public partial class AnalysisTreeView : System.Windows.Forms.TreeView, IDocumentListener
    {
        #region Constructor
        public AnalysisTreeView()
        {
            try
            {
                // build image list for tree
                ImageList = new ImageList();
                ImageList.Images.Add(AnalysisTreeView.CLSDFOLD);
                ImageList.Images.Add(AnalysisTreeView.OPENFOLD);
                ImageList.Images.Add(AnalysisTreeView.DOC);
                ImageList.Images.Add(AnalysisTreeView.Box);
                ImageList.Images.Add(AnalysisTreeView.Pallet);
                ImageList.Images.Add(AnalysisTreeView.Analysis);

                AfterSelect += new TreeViewEventHandler(AnalysisTreeView_AfterSelect);
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.ToString());
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
        #endregion

        #region Helpers
        internal NodeTag CurrentTag
        {
            get
            {
                TreeNode currentNode = this.SelectedNode;
                if (null == currentNode)
                    throw new Exception("No node selected");
                return currentNode.Tag as NodeTag;
            }
        }
        #endregion

        #region Select event handler
        void AnalysisTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                NodeTag tag = CurrentTag;
                AnalysisSelected(this, new AnalysisTreeViewEventArgs(tag.Document, tag.Analysis));
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.ToString());
            }
        }
        #endregion

        #region Delegates
        public delegate void AnalysisSelectHandler(object sender, AnalysisTreeViewEventArgs eventArg);
        #endregion

        #region Events 
        public event AnalysisSelectHandler AnalysisSelected;
        #endregion

        #region IDocumentListener implementation
        public void OnNewDocument(Document doc)
        {
            // add document node
            TreeNode nodeDoc = new TreeNode(doc.Title, 2, 2);
            nodeDoc.Tag = new NodeTag(NodeTag.NodeType.NT_DOCUMENT, doc, null, null, null);
            this.Nodes.Add(nodeDoc);
            // add box list node
            TreeNode nodeBoxes = new TreeNode("Boxes", 0, 1);
            nodeBoxes.Tag = new NodeTag(NodeTag.NodeType.NT_LISTBOX, doc, null, null, null);
            nodeDoc.Nodes.Add(nodeBoxes);
            // add pallet list node
            TreeNode nodePallets = new TreeNode("Pallets", 0, 1);
            nodePallets.Tag = new NodeTag(NodeTag.NodeType.NT_LISTPALLET, doc, null, null, null);
            nodeDoc.Nodes.Add(nodePallets);
            // add analysis list node
            TreeNode nodeAnalyses = new TreeNode("Analyses", 0, 1);
            nodeAnalyses.Tag = new NodeTag(NodeTag.NodeType.NT_LISTANALYSIS, doc, null, null, null);
            nodeDoc.Nodes.Add(nodeAnalyses);
        }
        public void OnNewBoxCreated(Document doc, BoxProperties boxProperties)
        { 
        }
        public void OnNewPalletCreated(Document doc, PalletProperties palletProperties)
        { 
        }
        public void OnNewAnalysisCreated(Document doc, Analysis analysis)
        {
        }
        public void OnBoxRemoved(Document doc, Analysis analysis)
        {        
        }
        public void OnPalletRemoved(Document doc, Analysis analysis)
        {
        }
        public void OnAnalysisRemoved(Document doc, Analysis analysis)
        { 
        }
        #endregion
    }
    #endregion

    #region NodeTag class
    public class NodeTag
    {
        #region Enums
        public enum NodeType
        { 
            NT_DOCUMENT
            , NT_LISTBOX
            , NT_LISTPALLET
            , NT_LISTANALYSIS
            , NT_BOX
            , NT_PALLET
            , NT_ANALYSIS
            , NT_ANALYSISBOX
            , NT_ANALYSISPALLET
        }
        #endregion

        #region Data members
        private NodeType _type;
        private Document _document;
        private BoxProperties _boxProperties;
        private PalletProperties _palletProperties;
        private Analysis _analysis;
        #endregion

        #region Constructor
        public NodeTag(NodeType type, Document document, BoxProperties boxProperties, PalletProperties palletProperties, Analysis analysis)
        {
            _type = type;
            _document = document;
            _boxProperties = boxProperties;
            _palletProperties = palletProperties;
            _analysis = analysis;
        }
        #endregion

        #region Public properties
        public NodeType Type { get { return _type; } }
        public Document Document { get { return _document; } }
        public BoxProperties BoxProperties { get { return _boxProperties; } }
        public PalletProperties PalletProperties { get { return _palletProperties; } }
        public Analysis Analysis { get { return _analysis; } }
        #endregion
    }
    #endregion

    #region AnalysisTreeViewEventArgs class
    public class AnalysisTreeViewEventArgs : EventArgs
    {
        #region Data members
        private Document _document;
        private Analysis _analysis;
        #endregion

        #region Constructor
        public AnalysisTreeViewEventArgs(Document document, Analysis analysis)
        {
            _document = document;
            _analysis = analysis;
        }
        #endregion

        #region Public properties
        public Document Document { get { return _document; } }
        public Analysis Analysis { get { return _analysis; } }
        #endregion

    }
    #endregion
}
