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
using TreeDim.StackBuilder.Engine;
using log4net;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    #region AnalysisTreeView
    /// <summary>
    /// AnalysisTreeView : left frame treeview control
    /// </summary>
    public partial class AnalysisTreeView
        : System.Windows.Forms.TreeView, IDocumentListener
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
                ImageList.Images.Add(AnalysisTreeView.AnalysisBundle);    // 9
                ImageList.Images.Add(AnalysisTreeView.Solution);    // 10
                ImageList.Images.Add(AnalysisTreeView.Word);        // 11
                // instantiate context menu
                ContextMenu = new ContextMenu();
                // attach event handlers
                this.NodeMouseClick += new TreeNodeMouseClickEventHandler(AnalysisTreeView_NodeMouseClick);
                this.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(AnalysisTreeView_NodeMouseDoubleClick);
                ContextMenu.Popup += new EventHandler(ContextMenu_Popup);
                this.DrawMode = TreeViewDrawMode.OwnerDrawText;
                this.DrawNode += new DrawTreeNodeEventHandler(AnalysisTreeView_DrawNode);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AnalysisTreeView
            // 
            this.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.ResumeLayout(false);

        }
        #endregion

        #region Context menu
        /// <summary>
        /// Handler for ContextMenu.Popup event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenu_Popup(object sender, EventArgs e)
        {
            try
            {
                // retrieve node which was clicked
                TreeNode node = GetNodeAt(PointToClient(Cursor.Position));
                if (node == null) return; // user might right click no valid node
                SelectedNode = node;
                // clear previous items
                ContextMenu.MenuItems.Clear();
                // let the provider do his work
                NodeTag nodeTag = node.Tag as NodeTag;
                if (null != nodeTag)
                    QueryContextMenuItems(nodeTag, this.ContextMenu);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private void QueryContextMenuItems(NodeTag nodeTag, ContextMenu contextMenu)
        {
            if (nodeTag.Type == NodeTag.NodeType.NT_DOCUMENT)
            {
                contextMenu.MenuItems.Add(new MenuItem("Add new box..."         , new EventHandler(onCreateNewBox)));
                contextMenu.MenuItems.Add(new MenuItem("Add new pallet..."      , new EventHandler(onCreateNewPallet)));
                contextMenu.MenuItems.Add(new MenuItem("Add new interlayer..."  , new EventHandler(onCreateNewInterlayer)));
                contextMenu.MenuItems.Add(new MenuItem("Add new bundle..."      , new EventHandler(onCreateNewBundle)));
                contextMenu.MenuItems.Add(new MenuItem("Add new truck..."       , new EventHandler(onCreateNewTruck)));
                if (((DocumentSB)nodeTag.Document).CanCreateAnalysis)
                    contextMenu.MenuItems.Add(new MenuItem("Add new analysis..."    , new EventHandler(onCreateNewAnalysis)));
                if (((DocumentSB)nodeTag.Document).CanCreateBundleAnalysis)
                    contextMenu.MenuItems.Add(new MenuItem("Add new bundle analysis...", new EventHandler(onCreateNewBundleAnalysis)));
                contextMenu.MenuItems.Add(new MenuItem("-"));
                contextMenu.MenuItems.Add(new MenuItem("Close"                  , new EventHandler(onDocumentClose)));

            }
            if (nodeTag.Type == NodeTag.NodeType.NT_BOX
                || nodeTag.Type == NodeTag.NodeType.NT_PALLET
                || nodeTag.Type == NodeTag.NodeType.NT_BUNDLE
                || nodeTag.Type == NodeTag.NodeType.NT_INTERLAYER
                || nodeTag.Type == NodeTag.NodeType.NT_TRUCK
                )
            {
                string message = string.Format("Delete {0}...", nodeTag.ItemProperties.Name);
                contextMenu.MenuItems.Add(new MenuItem(message, new EventHandler(onBaseItemDelete)));
            }
            if (nodeTag.Type == NodeTag.NodeType.NT_ANALYSIS)
            {
                string message = string.Format("Edit {0}...", nodeTag.Analysis.Name);
                contextMenu.MenuItems.Add(new MenuItem(message, new EventHandler(onAnalysisEdit)));
                message = string.Format("Delete {0}...", nodeTag.Analysis.Name);
                contextMenu.MenuItems.Add(new MenuItem(message, new EventHandler(onAnalysisDelete)));
            }
            if (nodeTag.Type == NodeTag.NodeType.NT_LISTBOX)
                contextMenu.MenuItems.Add(new MenuItem("Add new box...", new EventHandler(onCreateNewBox)));
            if (nodeTag.Type == NodeTag.NodeType.NT_LISTPALLET)
                contextMenu.MenuItems.Add(new MenuItem("Add new pallet...", new EventHandler(onCreateNewPallet)));
            if (nodeTag.Type == NodeTag.NodeType.NT_LISTINTERLAYER)
                contextMenu.MenuItems.Add(new MenuItem("Add new interlayer...", new EventHandler(onCreateNewInterlayer)));
            if (nodeTag.Type == NodeTag.NodeType.NT_LISTBUNDLE)
                contextMenu.MenuItems.Add(new MenuItem("Add new bundle...", new EventHandler(onCreateNewBundle)));
            if (nodeTag.Type == NodeTag.NodeType.NT_LISTTRUCK)
                contextMenu.MenuItems.Add(new MenuItem("Add new truck...", new EventHandler(onCreateNewTruck)));
            if (nodeTag.Type == NodeTag.NodeType.NT_LISTANALYSIS)
            {
                if (nodeTag.Document.CanCreateAnalysis)
                    contextMenu.MenuItems.Add(new MenuItem("Add new analysis...", new EventHandler(onCreateNewAnalysis)));
                if (nodeTag.Document.CanCreateBundleAnalysis)
                    contextMenu.MenuItems.Add(new MenuItem("Add new bundle analysis", new EventHandler(onCreateNewBundleAnalysis)));
            }
            if (nodeTag.Type == NodeTag.NodeType.NT_ANALYSISSOL)
            {
                if (nodeTag.Document.Trucks.Count > 0)
                    contextMenu.MenuItems.Add(new MenuItem("Add new truck analysis...", new EventHandler(onCreateNewTruckAnalysis)));
            }
        }
        #endregion

        #region Handling context menus
        private void onBaseItemDelete(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;                
                tag.Document.RemoveItem(tag.ItemProperties);
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onAnalysisEdit(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                ((DocumentSB)tag.Document).EditAnalysis(tag.Analysis);
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onAnalysisDelete(object sender, EventArgs e)
        {
            NodeTag tag = SelectedNode.Tag as NodeTag;
            tag.Document.RemoveItem(tag.Analysis);
        }
        private void onCreateNewBox(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                ((DocumentSB)tag.Document).CreateNewBoxUI();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onCreateNewPallet(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                ((DocumentSB)tag.Document).CreateNewPalletUI();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onCreateNewInterlayer(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                ((DocumentSB)tag.Document).CreateNewInterlayerUI();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onCreateNewBundle(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                ((DocumentSB)tag.Document).CreateNewBundleUI();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onCreateNewTruck(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                ((DocumentSB)tag.Document).CreateNewTruckUI();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onCreateNewAnalysis(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                ((DocumentSB)tag.Document).CreateNewAnalysisUI();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onCreateNewBundleAnalysis(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                ((DocumentSB)tag.Document).CreateNewAnalysisBundleUI();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onCreateNewTruckAnalysis(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                FormNewTruckAnalysis form = new FormNewTruckAnalysis(tag.Document);
                form.TruckProperties = tag.Document.Trucks.ToArray();
                if (DialogResult.OK == form.ShowDialog())
                {
                    TruckConstraintSet constraintSet = new TruckConstraintSet();
                    constraintSet.MultilayerAllowed = form.AllowSeveralPalletLayers;
                    constraintSet.AllowPalletOrientationX = form.AllowPalletOrientationX;
                    constraintSet.AllowPalletOrientationY = form.AllowPalletOrientationY;
                    constraintSet.MinDistancePalletTruckWall = form.MinDistancePalletTruckWall;
                    constraintSet.MinDistancePalletTruckRoof = form.MinDistancePalletTruckRoof;

                    TruckAnalysis truckAnalysis = ((SelSolution)tag.SelSolution).CreateNewTruckAnalysis(form.SelectedTruck, constraintSet, new TruckSolver());
                    if (null != truckAnalysis)
                        FormMain.GetInstance().CreateOrActivateViewTruckAnalysis(truckAnalysis);
                }
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }       
        }
        private void onDocumentClose(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                CancelEventArgs cea = new CancelEventArgs();
                FormMain.GetInstance().CloseDocument((DocumentSB)tag.Document, cea); ;
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        #endregion

        #region Event handlers
        void AnalysisTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                SelectedNode = e.Node;
                // handle only left mouse button click
                if (e.Button != MouseButtons.Left) return;
                NodeTag tag = CurrentTag;
                NodeTag.NodeType tagType = tag.Type;
                if (null != AnalysisNodeClicked &&
                    (tag.Type == NodeTag.NodeType.NT_ANALYSIS)
                    || (tag.Type == NodeTag.NodeType.NT_ANALYSISBOX)
                    || (tag.Type == NodeTag.NodeType.NT_ANALYSISPALLET)
                    || (tag.Type == NodeTag.NodeType.NT_ANALYSISINTERLAYER)
                    || (tag.Type == NodeTag.NodeType.NT_BOX)
                    || (tag.Type == NodeTag.NodeType.NT_PALLET)
                    || (tag.Type == NodeTag.NodeType.NT_INTERLAYER)
                    || (tag.Type == NodeTag.NodeType.NT_BUNDLE)
                    || (tag.Type == NodeTag.NodeType.NT_TRUCK)
                    )
                {
                    AnalysisNodeClicked(this, new AnalysisTreeViewEventArgs(tag));
                    e.Node.Expand();
                }
                else if (tag.Type == NodeTag.NodeType.NT_ANALYSISSOLREPORT && null != SolutionReportNodeClicked)
                    SolutionReportNodeClicked(this, new AnalysisTreeViewEventArgs(tag));
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        void AnalysisTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }
        void AnalysisTreeView_DrawNode(object sender, System.Windows.Forms.DrawTreeNodeEventArgs e)
        {
            // get NodeTag
            NodeTag tag = e.Node.Tag as NodeTag;
            Rectangle nodeBounds = e.Node.Bounds;
            if (null != tag.ItemProperties)
                TextRenderer.DrawText(e.Graphics, tag.ItemProperties.Name, Font, nodeBounds, System.Drawing.Color.Black, Color.Transparent, TextFormatFlags.VerticalCenter | TextFormatFlags.NoClipping);
            else
                TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, nodeBounds, System.Drawing.Color.Black, Color.Transparent, TextFormatFlags.VerticalCenter | TextFormatFlags.NoClipping);
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
        public event AnalysisNodeClickHandler SolutionReportNodeClicked;
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
            nodeBoxes.Tag = new NodeTag(NodeTag.NodeType.NT_LISTBOX, doc, null, null);
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
            nodePallets.Tag = new NodeTag(NodeTag.NodeType.NT_LISTPALLET, doc, null, null);
            nodeDoc.Nodes.Add(nodePallets);
            // add truck list node
            TreeNode nodeTrucks = new TreeNode("Trucks", 0, 1);
            nodeTrucks.Tag = new NodeTag(NodeTag.NodeType.NT_LISTTRUCK, doc, null, null);
            nodeDoc.Nodes.Add(nodeTrucks);
            // add analysis list node
            TreeNode nodeAnalyses = new TreeNode("Analyses", 0, 1);
            nodeAnalyses.Tag = new NodeTag(NodeTag.NodeType.NT_LISTANALYSIS, doc, null, null);
            nodeDoc.Nodes.Add(nodeAnalyses);
            nodeDoc.Expand();
        }
        public void OnNewTypeCreated(Document doc, ItemBase itemProperties)
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
                Debug.Assert(false);
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
            TreeNode subBoxNode = new TreeNode(analysis.BProperties.Name, 3, 3);
            subBoxNode.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSISBOX, doc, analysis.BProperties, analysis);
            nodeAnalysis.Nodes.Add(subBoxNode);
            // insert sub pallet node
            TreeNode subPalletNode = new TreeNode(analysis.PalletProperties.Name, 5, 5);
            subPalletNode.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSISPALLET, doc, analysis.PalletProperties, analysis);
            nodeAnalysis.Nodes.Add(subPalletNode);
            // insert sub interlayer node if any
            if (analysis.HasInterlayer)
            {
                TreeNode subInterlayer = new TreeNode(analysis.InterlayerProperties.Name, 6, 6);
                subInterlayer.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSISINTERLAYER, doc, analysis.InterlayerProperties, analysis);
                nodeAnalysis.Nodes.Add(subInterlayer);
            }
            nodeAnalysis.Expand();
        }
        public void OnNewSolutionAdded(Document doc, Analysis analysis, SelSolution selSolution)
        {
            // get parent node
            TreeNode parentNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_ANALYSIS, doc, null, analysis));
            // insert selected solution node
            TreeNode nodeSelSolution = new TreeNode(selSolution.Name, 10, 10);
            nodeSelSolution.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSISSOL, doc, analysis, selSolution);
            parentNode.Nodes.Add(nodeSelSolution);
            TreeNode nodeReport = new TreeNode("Report", 11, 11);
            nodeReport.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSISSOLREPORT, doc, analysis, selSolution);
            nodeSelSolution.Nodes.Add(nodeReport);
            // expand tree nodes
            nodeSelSolution.Expand();
            parentNode.Expand();
        }
        public void OnNewTruckAnalysisCreated(Document doc, Analysis analysis, SelSolution selSolution, TruckAnalysis truckAnalysis)
        {
            // get parent node
            TreeNode parentNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_ANALYSISSOL, doc, analysis, selSolution));
            // insert truckAnalysis node
            TreeNode nodeTruckAnalysis = new TreeNode(truckAnalysis.Name, 7, 7);
            nodeTruckAnalysis.Tag = new NodeTag(NodeTag.NodeType.NT_TRUCKANALYSIS, doc, analysis, selSolution, truckAnalysis);
            parentNode.Nodes.Add(nodeTruckAnalysis);
            // expand parent tree node
            parentNode.Expand();
        }
        public void OnTypeRemoved(Document doc, ItemBase itemBase)
        {
            NodeTag.NodeType nodeType = NodeTag.NodeType.NT_UNKNOWN;
            if (itemBase.GetType() == typeof(BoxProperties))
            {
                nodeType = NodeTag.NodeType.NT_BOX;
            }
            else if (itemBase.GetType() == typeof(BundleProperties))
            {
                nodeType = NodeTag.NodeType.NT_BUNDLE;
            }
            else if (itemBase.GetType() == typeof(InterlayerProperties))
            {
                nodeType = NodeTag.NodeType.NT_INTERLAYER;
            }
            else if (itemBase.GetType() == typeof(PalletProperties))
            {
                nodeType = NodeTag.NodeType.NT_PALLET;
            }
            else if (itemBase.GetType() == typeof(TruckProperties))
            {
                nodeType = NodeTag.NodeType.NT_TRUCK;
            }
            Debug.Assert(nodeType != NodeTag.NodeType.NT_UNKNOWN);
            if (nodeType == NodeTag.NodeType.NT_UNKNOWN)
                return; // ->not found exit
            // get node
            TreeNode typeNode = FindNode(null, new NodeTag(nodeType, doc, itemBase, null));
            // remove node
            Nodes.Remove(typeNode);
        }
        public void OnAnalysisRemoved(Document doc, Analysis analysis)
        {
            // get node
            TreeNode analysisNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_ANALYSIS, doc, null, analysis));
            // remove node
            Nodes.Remove(analysisNode);
        }
        public void OnSolutionRemoved(Document doc, Analysis analysis, SelSolution selSolution)
        {
            // get node
            TreeNode selSolutionNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_ANALYSISSOL, doc, analysis, selSolution));
            // remove node
            Nodes.Remove(selSolutionNode);
        }
        public void OnTruckAnalysisRemoved(Document doc, Analysis analysis, SelSolution selSolution, TruckAnalysis truckAnalysis)
        {
            // get node
            TreeNode truckAnalysisNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_TRUCKANALYSIS, doc, analysis, selSolution, truckAnalysis));
            // remove node
            Nodes.Remove(truckAnalysisNode);  
        }
        public void OnDocumentClosed(Document doc)
        {
            NodeTag.NodeType nodeType = NodeTag.NodeType.NT_DOCUMENT;
            // get node
            TreeNode docNode = FindNode(null, new NodeTag(nodeType, doc, null, null));
            // remove node
            Nodes.Remove(docNode);
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
            NT_DOCUMENT,
            NT_LISTBOX,
            NT_LISTBUNDLE,
            NT_LISTPALLET,
            NT_LISTINTERLAYER,
            NT_LISTTRUCK,
            NT_LISTANALYSIS,
            NT_BOX,
            NT_BUNDLE,
            NT_PALLET,
            NT_INTERLAYER,
            NT_TRUCK,
            NT_ANALYSIS,
            NT_ANALYSISBOX,
            NT_ANALYSISPALLET,
            NT_ANALYSISINTERLAYER,
            NT_ANALYSISSOL,
            NT_ANALYSISSOLREPORT,
            NT_TRUCKANALYSIS,
            NT_TRUCKANALYSISSOL,
            NT_UNKNOWN
        }
        #endregion

        #region Data members
        private NodeType _type;
        private Document _document;
        private ItemBase _itemProperties;
        private Analysis _analysis;
        private SelSolution _selSolution;
        private TruckAnalysis _truckAnalysis;
        #endregion

        #region Constructor
        public NodeTag(NodeType type, Document document, ItemBase itemProperties, Analysis analysis)
        {
            _type = type;
            _document = document;
            _itemProperties = itemProperties;
            _analysis = analysis;
        }
        public NodeTag(NodeType type, Document document, Analysis analysis, SelSolution selSolution)
        {
            _type = type;
            _document = document;
            _itemProperties = null;
            _analysis = analysis;
            _selSolution = selSolution;
        }
        public NodeTag(NodeType type, Document document, Analysis analysis, SelSolution selSolution, TruckAnalysis truckAnalysis)
        {
            _type = type;
            _document = document;
            _itemProperties = null;
            _analysis = analysis;
            _selSolution = selSolution;
            _truckAnalysis = truckAnalysis;
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
        public ItemBase ItemProperties { get { return _itemProperties; } }
        public Analysis Analysis { get { return _analysis; } }
        public SelSolution SelSolution { get { return _selSolution; } }
        public TruckAnalysis TruckAnalysis { get { return _truckAnalysis; } }
        #endregion
    }
    #endregion

    #region AnalysisTreeViewEventArgs class
    public class AnalysisTreeViewEventArgs : EventArgs
    {
        #region Data members
        private NodeTag _nodeTag;
        #endregion

        #region Constructor
        public AnalysisTreeViewEventArgs(NodeTag nodeTag)
        {
            _nodeTag = nodeTag;
        }
        #endregion

        #region Public properties
        public Document Document { get { return _nodeTag.Document; } }
        public Analysis Analysis { get { return _nodeTag.Analysis; } }
        public ItemBase ItemBase { get { return _nodeTag.ItemProperties; } }
        public SelSolution SelSolution { get { return _nodeTag.SelSolution; } }
        public TruckAnalysis TruckAnalysis { get { return _nodeTag.TruckAnalysis; } }
        #endregion
    }
    #endregion
}
