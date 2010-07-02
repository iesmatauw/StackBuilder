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
using log4net;
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
                ImageList.Images.Add(AnalysisTreeView.CLSDFOLD);    // 0
                ImageList.Images.Add(AnalysisTreeView.OPENFOLD);    // 1
                ImageList.Images.Add(AnalysisTreeView.DOC);         // 2
                ImageList.Images.Add(AnalysisTreeView.Box);         // 3
                ImageList.Images.Add(AnalysisTreeView.Bundle);      // 4
                ImageList.Images.Add(AnalysisTreeView.Pallet);      // 5
                ImageList.Images.Add(AnalysisTreeView.Interlayer);  // 6
                ImageList.Images.Add(AnalysisTreeView.Truck);       // 7
                ImageList.Images.Add(AnalysisTreeView.Analysis);    // 8
                ImageList.Images.Add(AnalysisTreeView.Solution);    // 9
                this.NodeMouseClick += new TreeNodeMouseClickEventHandler(AnalysisTreeView_NodeMouseClick);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
        #endregion

        #region Event handlers
        void AnalysisTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                NodeTag tag = CurrentTag;
                if (null != AnalysisNodeClicked && null != tag.Analysis)
                    AnalysisNodeClicked(this, new AnalysisTreeViewEventArgs(tag.Document, tag.Analysis));
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
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
        internal TreeNode FindNode(TreeNode node, NodeTag nodeTag)
        {
            // check with node itself
            if (null != node)
            {
                NodeTag tag = node.Tag as NodeTag;
                if (tag.Equals(nodeTag))
                    return node;
            }
            // check with child nodes
            TreeNodeCollection tnCollection = null == node ? Nodes : node.Nodes;
            foreach (TreeNode tn in tnCollection)
            {
                TreeNode tnResult = FindNode(tn, nodeTag);
                if (null != tnResult)
                    return tnResult;
            }
            return null;
        }
        #endregion

        #region Delegates
        public delegate void AnalysisNodeClickHandler(object sender, AnalysisTreeViewEventArgs eventArg);
        #endregion

        #region Events 
        public event AnalysisNodeClickHandler AnalysisNodeClicked;
        #endregion

        #region IDocumentListener implementation
        public void OnNewDocument(Document doc)
        {
            // add document node
            TreeNode nodeDoc = new TreeNode(doc.Name, 2, 2);
            nodeDoc.Tag = new NodeTag(NodeTag.NodeType.NT_DOCUMENT, doc, null, null);
            this.Nodes.Add(nodeDoc);
            // add box list node
            TreeNode nodeBoxes = new TreeNode("Boxes", 0, 1);
            nodeBoxes.Tag = new NodeTag(NodeTag.NodeType.NT_LISTBOX, doc,  null, null);
            nodeDoc.Nodes.Add(nodeBoxes);
            // add bundle list node
            TreeNode nodeBundles = new TreeNode("Bundles", 0, 1);
            nodeBundles.Tag = new NodeTag(NodeTag.NodeType.NT_LISTBUNDLE, doc, null, null);
            nodeDoc.Nodes.Add(nodeBundles);
            // add pallet list node
            TreeNode nodeInterlayers = new TreeNode("Interlayers", 0, 1);
            nodeInterlayers.Tag = new NodeTag(NodeTag.NodeType.NT_LISTINTERLAYER, doc, null, null);
            nodeDoc.Nodes.Add(nodeInterlayers);
            // add pallet list node
            TreeNode nodePallets = new TreeNode("Pallets", 0, 1);
            nodePallets.Tag = new NodeTag(NodeTag.NodeType.NT_LISTPALLET, doc,  null, null);
            nodeDoc.Nodes.Add(nodePallets);
            // add truck list node
            TreeNode nodeTrucks = new TreeNode("Trucks", 0, 1);
            nodeTrucks.Tag = new NodeTag(NodeTag.NodeType.NT_LISTTRUCK, doc, null, null);
            nodeDoc.Nodes.Add(nodeTrucks);
            // add analysis list node
            TreeNode nodeAnalyses = new TreeNode("Analyses", 0, 1);
            nodeAnalyses.Tag = new NodeTag(NodeTag.NodeType.NT_LISTANALYSIS, doc,  null, null);
            nodeDoc.Nodes.Add(nodeAnalyses);
            nodeDoc.Expand();
        }
        public void OnNewTypeCreated(Document doc, ItemProperties itemProperties)
        {
            int iconIndex = 0;
            NodeTag.NodeType nodeType = NodeTag.NodeType.NT_BOX;
            NodeTag.NodeType parentNodeType = NodeTag.NodeType.NT_LISTBOX;

            if (itemProperties.GetType() == typeof(BoxProperties))
            {
                iconIndex = 3;
                nodeType = NodeTag.NodeType.NT_BOX;
                parentNodeType = NodeTag.NodeType.NT_LISTBOX;
            }
            else if (itemProperties.GetType() == typeof(BundleProperties))
            {
                iconIndex = 4;
                nodeType = NodeTag.NodeType.NT_BUNDLE;
                parentNodeType = NodeTag.NodeType.NT_LISTBUNDLE;
            }
            else if (itemProperties.GetType() == typeof(PalletProperties))
            {
                iconIndex = 5;
                nodeType = NodeTag.NodeType.NT_PALLET;
                parentNodeType = NodeTag.NodeType.NT_LISTPALLET;
            }
            else if (itemProperties.GetType() == typeof(InterlayerProperties))
            {
                iconIndex = 6;
                nodeType = NodeTag.NodeType.NT_INTERLAYER;
                parentNodeType = NodeTag.NodeType.NT_LISTINTERLAYER;
            }
            else if (itemProperties.GetType() == typeof(TruckProperties))
            {
                iconIndex = 7;
                nodeType = NodeTag.NodeType.NT_TRUCK;
                parentNodeType = NodeTag.NodeType.NT_LISTTRUCK;
            }
            else
            {
                _log.Error("AnalysisTreeView.OnNewTypeCreated() -> unknown type!");
                return;
            }

            // get parent node
            TreeNode parentNode = FindNode(null, new NodeTag(parentNodeType, doc, null, null));
            // instantiate node
            TreeNode nodeItem = new TreeNode(itemProperties.Name, iconIndex, iconIndex);
            // set node tag
            nodeItem.Tag = new NodeTag(nodeType, doc, itemProperties, null);
            // insert
            parentNode.Nodes.Add(nodeItem);
            parentNode.Expand();
        }

        public void OnNewAnalysisCreated(Document doc, Analysis analysis)
        {
            // get parent node
            TreeNode parentNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_LISTANALYSIS, doc, null, null));
            // insert analysis node
            TreeNode nodeAnalysis = new TreeNode(analysis.Name, 8, 8);
            nodeAnalysis.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSIS, doc, null, analysis);
            parentNode.Nodes.Add(nodeAnalysis);
            parentNode.Expand();
            // insert sub box node
            TreeNode subBoxNode = new TreeNode(analysis.BoxProperties.Name, 3, 3);
            subBoxNode.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSISBOX, doc, analysis.BoxProperties, analysis);
            nodeAnalysis.Nodes.Add(subBoxNode);
            // insert sub pallet node
            TreeNode subPalletNode = new TreeNode(analysis.PalletProperties.Name, 5, 5);
            subPalletNode.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSISPALLET, doc, analysis.PalletProperties, analysis);
            nodeAnalysis.Nodes.Add(subPalletNode);
            nodeAnalysis.Expand();
        }

        public void OnNewSolutionAdded(Document doc, Analysis analysis, Solution sol)
        {
        }
        public void OnTypeRemoved(Document doc, Analysis analysis)
        {        
        }
        public void OnAnalysisRemoved(Document doc, Analysis analysis)
        { 
        }
        public void OnDocumentClosed(Document doc)
        { 
        }
        #endregion

        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(AnalysisTreeView));
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
            , NT_LISTBUNDLE
            , NT_LISTPALLET
            , NT_LISTINTERLAYER
            , NT_LISTTRUCK
            , NT_LISTANALYSIS
            , NT_BOX
            , NT_BUNDLE
            , NT_PALLET
            , NT_INTERLAYER
            , NT_TRUCK
            , NT_ANALYSIS
            , NT_ANALYSISBOX
            , NT_ANALYSISPALLET
        }
        #endregion

        #region Data members
        private NodeType _type;
        private Document _document;
        private ItemProperties _itemProperties;
        private Analysis _analysis;
        #endregion

        #region Constructor
        public NodeTag(NodeType type, Document document, ItemProperties itemProperties, Analysis analysis)
        {
            _type = type;
            _document = document;
            _itemProperties = itemProperties;
            _analysis = analysis;
        }
        #endregion

        #region Object method overrides
        public override bool Equals(object obj)
        {
            NodeTag nodeTag = obj as NodeTag;
            if (null == nodeTag) return false;
            return _type == nodeTag._type
                && _document == nodeTag._document
                && _itemProperties == nodeTag._itemProperties
                && _analysis == nodeTag._analysis;
        }
        public override int GetHashCode()
        {
            return _type.GetHashCode() 
                ^ _document.GetHashCode() 
                ^ _itemProperties.GetHashCode() 
                ^ _analysis.GetHashCode();
        }
        #endregion

        #region Public properties
        public NodeType Type { get { return _type; } }
        public Document Document { get { return _document; } }
        public ItemProperties ItemProperties { get { return _itemProperties; } }
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
