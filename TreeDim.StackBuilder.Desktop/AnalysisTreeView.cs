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
using TreeDim.StackBuilder.Desktop.Properties;

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
        /// <summary>
        /// Constructor
        /// </summary>
        public AnalysisTreeView()
        {
            try
            {
                // build image list for tree
                ImageList = new ImageList();
                ImageList.Images.Add(AnalysisTreeView.CLSDFOLD);        // 0
                ImageList.Images.Add(AnalysisTreeView.OPENFOLD);        // 1
                ImageList.Images.Add(AnalysisTreeView.DOC);             // 2
                ImageList.Images.Add(AnalysisTreeView.Box);             // 3
                ImageList.Images.Add(AnalysisTreeView.Case);            // 4
                ImageList.Images.Add(AnalysisTreeView.Bundle);          // 5
                ImageList.Images.Add(AnalysisTreeView.Cylinder);        // 6
                ImageList.Images.Add(AnalysisTreeView.Pallet);          // 7
                ImageList.Images.Add(AnalysisTreeView.Interlayer);      // 8
                ImageList.Images.Add(AnalysisTreeView.Truck);           // 9
                ImageList.Images.Add(AnalysisTreeView.Analysis);        // 10
                ImageList.Images.Add(AnalysisTreeView.AnalysisBundle);  // 11
                ImageList.Images.Add(AnalysisTreeView.Solution);        // 12
                ImageList.Images.Add(AnalysisTreeView.TruckAnalysis);   // 13
                ImageList.Images.Add(AnalysisTreeView.CaseAnalysis);    // 14
                ImageList.Images.Add(AnalysisTreeView.CaseOfBoxes);     // 15
                ImageList.Images.Add(AnalysisTreeView.AnalysisStackingStrength); // 16
                // instantiate context menu
                this.ContextMenuStrip = new ContextMenuStrip();
                // attach event handlers
                this.NodeMouseClick += new TreeNodeMouseClickEventHandler(AnalysisTreeView_NodeMouseClick);
                this.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(AnalysisTreeView_NodeMouseDoubleClick);
                this.ContextMenuStrip.Opening += new CancelEventHandler(ContextMenuStrip_Opening);
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

        #region Context menu strip
        /// <summary>
        /// Handler for ContextMenu.Popup event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                // retrieve node which was clicked
                TreeNode node = GetNodeAt(PointToClient(Cursor.Position));
                if (node == null) return; // user might right click no valid node
                SelectedNode = node;
                // clear previous items
                this.ContextMenuStrip.Items.Clear();
                // let the provider do his work
                NodeTag nodeTag = node.Tag as NodeTag;
                if (null != nodeTag)
                    QueryContextMenuItems(nodeTag, this.ContextMenuStrip);
                // set Cancel to false. 
                // it is optimized to true based on empty entry.
                e.Cancel = !(this.ContextMenuStrip.Items.Count > 0);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private void QueryContextMenuItems(NodeTag nodeTag, ContextMenuStrip contextMenuStrip)
        {
            if (nodeTag.Type == NodeTag.NodeType.NT_DOCUMENT)
            {
                contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWBOX, AnalysisTreeView.Box         , new EventHandler(onCreateNewBox)));
                contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWCASE, AnalysisTreeView.Case, new EventHandler(onCreateNewCase)));
                contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWPALLET, AnalysisTreeView.Pallet      , new EventHandler(onCreateNewPallet)));
                contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWINTERLAYER, AnalysisTreeView.Interlayer, new EventHandler(onCreateNewInterlayer)));
                contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWBUNDLE, AnalysisTreeView.Bundle      , new EventHandler(onCreateNewBundle)));
                contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWTRUCK, AnalysisTreeView.Truck       , new EventHandler(onCreateNewTruck)));
                if (((DocumentSB)nodeTag.Document).CanCreatePalletAnalysis || ((DocumentSB)nodeTag.Document).CanCreateBundleAnalysis || ((DocumentSB)nodeTag.Document).CanCreateCaseAnalysis)
                    contextMenuStrip.Items.Add(new ToolStripSeparator());
                if (((DocumentSB)nodeTag.Document).CanCreatePalletAnalysis)
                    contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWANALYSIS, AnalysisTreeView.Analysis, new EventHandler(onCreateNewAnalysis)));
                if (((DocumentSB)nodeTag.Document).CanCreateBundleAnalysis)
                    contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWBUNDLEANALYSIS, AnalysisTreeView.AnalysisBundle, new EventHandler(onCreateNewBundleAnalysis)));
                if (((DocumentSB)nodeTag.Document).CanCreateCaseAnalysis)
                    contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWCASEANALYSIS, AnalysisTreeView.CaseAnalysis, new EventHandler(onCreateNewCaseAnalysis)));
                contextMenuStrip.Items.Add(new ToolStripSeparator());
                contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_CLOSE, null, new EventHandler(onDocumentClose)));
            }
            if (nodeTag.Type == NodeTag.NodeType.NT_BOX
                || nodeTag.Type == NodeTag.NodeType.NT_CASE
                || nodeTag.Type == NodeTag.NodeType.NT_CASEOFBOXES
                || nodeTag.Type == NodeTag.NodeType.NT_CYLINDER
                || nodeTag.Type == NodeTag.NodeType.NT_PALLET
                || nodeTag.Type == NodeTag.NodeType.NT_BUNDLE
                || nodeTag.Type == NodeTag.NodeType.NT_INTERLAYER
                || nodeTag.Type == NodeTag.NodeType.NT_TRUCK
                )
            {
                string message = string.Format(Resources.ID_DELETE, nodeTag.ItemProperties.Name);
                contextMenuStrip.Items.Add(new ToolStripMenuItem(message, AnalysisTreeView.DELETE, new EventHandler(onDeleteBaseItem)));
            }
            if (nodeTag.Type == NodeTag.NodeType.NT_ANALYSIS)
            {
                string message = string.Format(Resources.ID_EDIT, nodeTag.Analysis.Name);
                contextMenuStrip.Items.Add(new ToolStripMenuItem(message, null, new EventHandler(onEditPalletAnalysis)));
                message = string.Format(Resources.ID_DELETE, nodeTag.Analysis.Name);
                contextMenuStrip.Items.Add(new ToolStripMenuItem(message, AnalysisTreeView.DELETE, new EventHandler(onDeletePalletAnalysis)));
            }
            if (nodeTag.Type == NodeTag.NodeType.NT_ANALYSISSOL)
            {
   
            }
            if (nodeTag.Type == NodeTag.NodeType.NT_TRUCKANALYSIS)
            {
                string message = string.Format(Resources.ID_EDIT, nodeTag.TruckAnalysis.Name);
                contextMenuStrip.Items.Add(new ToolStripMenuItem(message, null, new EventHandler(onEditTruckAnalysis)));
                message = string.Format(Resources.ID_DELETE, nodeTag.TruckAnalysis.Name);
                contextMenuStrip.Items.Add(new ToolStripMenuItem(message, AnalysisTreeView.DELETE, new EventHandler(onDeleteTruckAnalysis)));
            }
            if (nodeTag.Type == NodeTag.NodeType.NT_ECTANALYSIS)
            {
                string message = string.Format(Resources.ID_EDIT, nodeTag.ECTAnalysis.Name);
                contextMenuStrip.Items.Add(new ToolStripMenuItem(message, null, new EventHandler(onEditECTAnalysis)));
                message = string.Format(Resources.ID_DELETE, nodeTag.ECTAnalysis.Name);
                contextMenuStrip.Items.Add(new ToolStripMenuItem(message, AnalysisTreeView.DELETE, new EventHandler(onDeleteECTAnalysis)));
            }
            if (nodeTag.Type == NodeTag.NodeType.NT_LISTBOX)
                contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWBOX, AnalysisTreeView.Box, new EventHandler(onCreateNewBox)));
            if (nodeTag.Type == NodeTag.NodeType.NT_LISTCASE)
                contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWCASE, AnalysisTreeView.Case, new EventHandler(onCreateNewCase)));
            if (nodeTag.Type == NodeTag.NodeType.NT_LISTPALLET)
                contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWPALLET, AnalysisTreeView.Pallet, new EventHandler(onCreateNewPallet)));
            if (nodeTag.Type == NodeTag.NodeType.NT_LISTINTERLAYER)
                contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWINTERLAYER, AnalysisTreeView.Interlayer, new EventHandler(onCreateNewInterlayer)));
            if (nodeTag.Type == NodeTag.NodeType.NT_LISTBUNDLE)
                contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWBUNDLE, AnalysisTreeView.Bundle, new EventHandler(onCreateNewBundle)));
            if (nodeTag.Type == NodeTag.NodeType.NT_LISTTRUCK)
                contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWTRUCK, AnalysisTreeView.Truck, new EventHandler(onCreateNewTruck)));
            if (nodeTag.Type == NodeTag.NodeType.NT_LISTANALYSIS)
            {
                if (nodeTag.Document.CanCreatePalletAnalysis)
                    contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWANALYSIS, AnalysisTreeView.Analysis, new EventHandler(onCreateNewAnalysis)));
                if (nodeTag.Document.CanCreateBundleAnalysis)
                    contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWBUNDLEANALYSIS, AnalysisTreeView.AnalysisBundle, new EventHandler(onCreateNewBundleAnalysis)));
                if (nodeTag.Document.CanCreateCaseAnalysis)
                    contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWCASEANALYSIS, AnalysisTreeView.CaseAnalysis, new EventHandler(onCreateNewCaseAnalysis)));
            }
            if (nodeTag.Type == NodeTag.NodeType.NT_ANALYSISSOL)
            {
                contextMenuStrip.Items.Add(new ToolStripMenuItem(string.Format(Resources.ID_UNSELECTSOLUTION, nodeTag.SelSolution.Solution.Title), AnalysisTreeView.DELETE, new EventHandler(onUnselectAnalysisSolution)));
                if (nodeTag.Document.Trucks.Count > 0 && !nodeTag.SelSolution.HasDependingAnalyses)
                    contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWTRUCKANALYSIS, AnalysisTreeView.TruckAnalysis, new EventHandler(onCreateNewTruckAnalysis)));
                if (!nodeTag.SelSolution.HasECTAnalyses)
                    contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_ADDNEWECTANALYSIS, AnalysisTreeView.AnalysisStackingStrength, new EventHandler(onCreateNewECTAnalysis)));
                if (nodeTag.Analysis.IsBoxAnalysis)
                {
                    BoxProperties bProperties = nodeTag.Analysis.BProperties as BoxProperties;
                    if (bProperties.HasInsideDimensions) // BoxProperties must also have inside dimensions
                        contextMenuStrip.Items.Add(new ToolStripMenuItem(Resources.ID_SENDTODATABASE, AnalysisTreeView.Database, new EventHandler(onSendSolutionToDatabase)));
                }
                string message = string.Format(Resources.ID_GENERATEREPORTHTML, nodeTag.SelSolution.Name);
                contextMenuStrip.Items.Add( new ToolStripMenuItem(message, AnalysisTreeView.HTML, new EventHandler(onAnalysisReportHTML)) );
                message = string.Format(Resources.ID_GENERATEREPORTMSWORD, nodeTag.SelSolution.Name);
                contextMenuStrip.Items.Add( new ToolStripMenuItem(message, AnalysisTreeView.WORD, new EventHandler(onAnalysisReportMSWord)) );
                if (nodeTag.Analysis.IsBoxAnalysis)
                {
                    message = string.Format(Resources.ID_GENERATECOLLADA, nodeTag.SelSolution.Name);
                    contextMenuStrip.Items.Add(new ToolStripMenuItem(message, AnalysisTreeView.COLLADAWEBGL, new EventHandler(onAnalysisExportCollada)));
                }
            }
            if (nodeTag.Type == NodeTag.NodeType.NT_CASEANALYSIS)
            {
                contextMenuStrip.Items.Add(new ToolStripMenuItem(string.Format(Resources.ID_EDIT, nodeTag.CaseAnalysis.Name), null, new EventHandler(onEditCaseAnalysis)));
                contextMenuStrip.Items.Add(new ToolStripMenuItem(string.Format(Resources.ID_DELETE, nodeTag.CaseAnalysis.Name), AnalysisTreeView.DELETE, new EventHandler(onDeleteCaseAnalysis)));
            }
            if (nodeTag.Type == NodeTag.NodeType.NT_CASESOLUTION)
            {
                contextMenuStrip.Items.Add(new ToolStripMenuItem(string.Format(Resources.ID_UNSELECTSOLUTION, nodeTag.SelCaseSolution.Solution.Title), AnalysisTreeView.DELETE, new EventHandler(onUnselectCaseAnalysisSolution)));
                string message = string.Format(Resources.ID_GENERATEREPORTHTML, nodeTag.SelCaseSolution.Name);
                contextMenuStrip.Items.Add(new ToolStripMenuItem(message, AnalysisTreeView.HTML, new EventHandler(onAnalysisReportHTML)));
                message = string.Format(Resources.ID_GENERATEREPORTMSWORD, nodeTag.SelCaseSolution.Name);
                contextMenuStrip.Items.Add(new ToolStripMenuItem(message, AnalysisTreeView.WORD, new EventHandler(onAnalysisReportMSWord))); 
            }
        }
        #endregion

        #region Handling context menus
        private void onDeleteBaseItem(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;                
                tag.Document.RemoveItem(tag.ItemProperties);
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onEditPalletAnalysis(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                ((DocumentSB)tag.Document).EditPalletAnalysis(tag.Analysis);
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onEditCaseAnalysis(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                ((DocumentSB)tag.Document).EditCaseAnalysis(tag.CaseAnalysis);
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onDeletePalletAnalysis(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                tag.Document.RemoveItem(tag.Analysis);
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onAnalysisReportMSWord(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                SolutionReportMSWordClicked(this, new AnalysisTreeViewEventArgs(tag));
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onAnalysisReportHTML(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                SolutionReportHtmlClicked(this, new AnalysisTreeViewEventArgs(tag));
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onAnalysisExportCollada(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                SolutionColladaExportClicked(this, new AnalysisTreeViewEventArgs(tag));
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onEditTruckAnalysis(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                ((DocumentSB)tag.Document).EditTruckAnalysis(tag.TruckAnalysis);
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onEditECTAnalysis(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                AnalysisNodeClicked(this, new AnalysisTreeViewEventArgs(tag));
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onDeleteTruckAnalysis(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                tag.SelSolution.RemoveTruckAnalysis(tag.TruckAnalysis);
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onDeleteECTAnalysis(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                tag.SelSolution.RemoveECTAnalysis(tag.ECTAnalysis);
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        private void onDeleteCaseAnalysis(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                tag.Document.RemoveItem(tag.CaseAnalysis);
            }
            catch (Exception ex) { _log.Error(ex.ToString()); } 
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
        private void onCreateNewCase(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                ((DocumentSB)tag.Document).CreateNewCaseUI();
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

                if (tag.SelSolution.HasDependingAnalyses)
                    return;

                FormNewTruckAnalysis form = new FormNewTruckAnalysis(tag.Document);
                form.Trucks = tag.Document.Trucks.ToArray();
                if (DialogResult.OK == form.ShowDialog())
                {
                    TruckConstraintSet constraintSet = new TruckConstraintSet();
                    constraintSet.MultilayerAllowed = form.AllowSeveralPalletLayers;
                    constraintSet.AllowPalletOrientationX = form.AllowPalletOrientationX;
                    constraintSet.AllowPalletOrientationY = form.AllowPalletOrientationY;
                    constraintSet.MinDistancePalletTruckWall = form.MinDistancePalletTruckWall;
                    constraintSet.MinDistancePalletTruckRoof = form.MinDistancePalletTruckRoof;

                    TruckAnalysis truckAnalysis = tag.SelSolution.CreateNewTruckAnalysis(form.SelectedTruck.Name, string.Empty, form.SelectedTruck, constraintSet, new TruckSolver());
                    if (null != truckAnalysis)
                        FormMain.GetInstance().CreateOrActivateViewTruckAnalysis(truckAnalysis);
                }
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }       
        }
        private void onSendSolutionToDatabase(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                // get PalletSolutionDatabase instance
                PalletSolutionDatabase db = PalletSolutionDatabase.Instance;
                // check that a comparable solution is not already in database
                BoxProperties boxProperties = tag.Analysis.BProperties as BoxProperties;
                PalletProperties palletProperties = tag.Analysis.PalletProperties;
                PalletConstraintSet constraintSet = tag.Analysis.ConstraintSet;
                // show form and get friendly name
                FormAppendSolutionToDB form = new FormAppendSolutionToDB();
                // warn user : keep or replace similar solutions
                form.ShowSimilarSolutionQuestion =db.AlreadyHasSimilarSolution(tag.SelSolution);
                // show dialog
                if (DialogResult.Cancel == form.ShowDialog())
                    return;
                // save in database index
                db.Append(tag.SelSolution, form.FriendlyName, form.KeepSimilarSolutions); 
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }

        private void onCreateNewECTAnalysis(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;

                if (tag.SelSolution.HasECTAnalyses)
                    return;

                SelSolution selSolution = tag.SelSolution;
                CasePalletAnalysis analysis = selSolution.Analysis;

                ECTAnalysis ectAnalysis = selSolution.CreateNewECTAnalysis(analysis.Name, analysis.Description);
                if (null != ectAnalysis)
                    FormMain.GetInstance().CreateOrActivateViewECTAnalysis(ectAnalysis);
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }

        private void onCreateNewCaseAnalysis(object sender, EventArgs e)
        {
            NodeTag tag = SelectedNode.Tag as NodeTag;
            ((DocumentSB)tag.Document).CreateNewCaseAnalysisUI(); 
        }
        private void onUnselectAnalysisSolution(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                tag.Analysis.UnSelectSolution(tag.SelSolution);
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
        private void onUnselectCaseAnalysisSolution(object sender, EventArgs e)
        {
            try
            {
                NodeTag tag = SelectedNode.Tag as NodeTag;
                tag.CaseAnalysis.UnSelectSolution(tag.SelCaseSolution);
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
                    || (tag.Type == NodeTag.NodeType.NT_CASE)
                    || (tag.Type == NodeTag.NodeType.NT_CYLINDER)
                    || (tag.Type == NodeTag.NodeType.NT_CASEOFBOXES)
                    || (tag.Type == NodeTag.NodeType.NT_PALLET)
                    || (tag.Type == NodeTag.NodeType.NT_INTERLAYER)
                    || (tag.Type == NodeTag.NodeType.NT_BUNDLE)
                    || (tag.Type == NodeTag.NodeType.NT_TRUCK)
                    )
                {
                    AnalysisNodeClicked(this, new AnalysisTreeViewEventArgs(tag));
                    e.Node.Expand();
                }
                else if (tag.Type == NodeTag.NodeType.NT_TRUCKANALYSIS && null != AnalysisNodeClicked)
                {
                    AnalysisNodeClicked(this, new AnalysisTreeViewEventArgs(tag));
                }
                else if (tag.Type == NodeTag.NodeType.NT_CASEANALYSIS)
                {
                    AnalysisNodeClicked(this, new AnalysisTreeViewEventArgs(tag));
                }
                else if (tag.Type == NodeTag.NodeType.NT_ECTANALYSIS)
                {
                    AnalysisNodeClicked(this, new AnalysisTreeViewEventArgs(tag));
                }
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
        /// <summary>
        /// is a prototype for event handlers of AnalysisNodeClicked / SolutionReportNodeClicked
        /// </summary>
        /// <param name="sender">sending object (tree)</param>
        /// <param name="eventArg">contains NodeTag to identify clicked TreeNode</param>
        public delegate void AnalysisNodeClickHandler(object sender, AnalysisTreeViewEventArgs eventArg);
        public delegate void NewAnalysisCreatedHandler(object sender, NewAnalysisEventArgs eventArg);
        #endregion

        #region Events
        /// <summary>
        /// event raised when an analysis node is clicked
        /// </summary>
        public event AnalysisNodeClickHandler AnalysisNodeClicked;
        /// <summary>
        /// event raised when a selected solution node is clicked
        /// </summary>
        public event AnalysisNodeClickHandler SolutionReportMSWordClicked;
        public event AnalysisNodeClickHandler SolutionReportHtmlClicked;
        public event AnalysisNodeClickHandler SolutionColladaExportClicked;
        #endregion

        #region IDocumentListener implementation
        /// <summary>
        /// handles new document creation
        /// </summary>
        /// <param name="doc"></param>
        public void OnNewDocument(Document doc)
        {
            // add document node
            TreeNode nodeDoc = new TreeNode(doc.Name, 2, 2);
            nodeDoc.Tag = new NodeTag(NodeTag.NodeType.NT_DOCUMENT, doc);
            this.Nodes.Add(nodeDoc);
            // add box list node
            TreeNode nodeBoxes = new TreeNode(Resources.ID_NODE_BOXES, 0, 1);
            nodeBoxes.Tag = new NodeTag(NodeTag.NodeType.NT_LISTBOX, doc);
            nodeDoc.Nodes.Add(nodeBoxes);
            // add case list node
            TreeNode nodeCases = new TreeNode(Resources.ID_NODE_CASES, 0, 1);
            nodeCases.Tag = new NodeTag(NodeTag.NodeType.NT_LISTCASE, doc);
            nodeDoc.Nodes.Add(nodeCases);
            // add bundle list node
            TreeNode nodeBundles = new TreeNode(Resources.ID_NODE_BUNDLES, 0, 1);
            nodeBundles.Tag = new NodeTag(NodeTag.NodeType.NT_LISTBUNDLE, doc);
            nodeDoc.Nodes.Add(nodeBundles);
            // add cylinder list node
            TreeNode nodeCylinders = new TreeNode(Resources.ID_NODE_CYLINDERS, 0, 1);
            nodeCylinders.Tag = new NodeTag(NodeTag.NodeType.NT_LISTCYLINDER, doc);
            nodeDoc.Nodes.Add(nodeCylinders);
            // add pallet list node
            TreeNode nodeInterlayers = new TreeNode(Resources.ID_NODE_INTERLAYERS, 0, 1);
            nodeInterlayers.Tag = new NodeTag(NodeTag.NodeType.NT_LISTINTERLAYER, doc);
            nodeDoc.Nodes.Add(nodeInterlayers);
            // add pallet list node
            TreeNode nodePallets = new TreeNode(Resources.ID_NODE_PALLETS, 0, 1);
            nodePallets.Tag = new NodeTag(NodeTag.NodeType.NT_LISTPALLET, doc);
            nodeDoc.Nodes.Add(nodePallets);
            // add truck list node
            TreeNode nodeTrucks = new TreeNode(Resources.ID_NODE_TRUCKS, 0, 1);
            nodeTrucks.Tag = new NodeTag(NodeTag.NodeType.NT_LISTTRUCK, doc);
            nodeDoc.Nodes.Add(nodeTrucks);
            // add analysis list node
            TreeNode nodeAnalyses = new TreeNode(Resources.ID_NODE_ANALYSES, 0, 1);
            nodeAnalyses.Tag = new NodeTag(NodeTag.NodeType.NT_LISTANALYSIS, doc);
            nodeDoc.Nodes.Add(nodeAnalyses);
            nodeDoc.Expand();
        }
        /// <summary>
        /// handles new type creation
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="itemProperties"></param>
        public void OnNewTypeCreated(Document doc, ItemBase itemProperties)
        {
            int iconIndex = 0;
            NodeTag.NodeType nodeType = NodeTag.NodeType.NT_BOX;
            NodeTag.NodeType parentNodeType = NodeTag.NodeType.NT_LISTBOX;
            if (itemProperties.GetType() == typeof(CaseOfBoxesProperties))
            {
                iconIndex = 14;
                nodeType = NodeTag.NodeType.NT_CASEOFBOXES;
                parentNodeType = NodeTag.NodeType.NT_LISTCASE;
            }
            else if (itemProperties.GetType() == typeof(BoxProperties))
            {
                BoxProperties boxProperties = itemProperties as BoxProperties;
                if (boxProperties.HasInsideDimensions)
                {
                    iconIndex = 4;
                    nodeType = NodeTag.NodeType.NT_CASE;
                    parentNodeType = NodeTag.NodeType.NT_LISTCASE;
                }
                else 
                {
                    iconIndex = 3;
                    nodeType = NodeTag.NodeType.NT_BOX;
                    parentNodeType = NodeTag.NodeType.NT_LISTBOX;
                }                
            }
            else if (itemProperties.GetType() == typeof(BundleProperties))
            {
                iconIndex = 5;
                nodeType = NodeTag.NodeType.NT_BUNDLE;
                parentNodeType = NodeTag.NodeType.NT_LISTBUNDLE;
            }
            else if (itemProperties.GetType() == typeof(CylinderProperties))
            {
                iconIndex = 6;
                nodeType = NodeTag.NodeType.NT_CYLINDER;
                parentNodeType = NodeTag.NodeType.NT_LISTCYLINDER;
            }
            else if (itemProperties.GetType() == typeof(PalletProperties))
            {
                iconIndex = 7;
                nodeType = NodeTag.NodeType.NT_PALLET;
                parentNodeType = NodeTag.NodeType.NT_LISTPALLET;
            }
            else if (itemProperties.GetType() == typeof(InterlayerProperties))
            {
                iconIndex = 8;
                nodeType = NodeTag.NodeType.NT_INTERLAYER;
                parentNodeType = NodeTag.NodeType.NT_LISTINTERLAYER;
            }
            else if (itemProperties.GetType() == typeof(TruckProperties))
            {
                iconIndex = 9;
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
            TreeNode parentNode = FindNode(null, new NodeTag(parentNodeType, doc));
            if (null == parentNode)
            { 
                _log.Error(string.Format("Failed to load parentNode for {0}", itemProperties.Name));
                return;
            }
            // instantiate node
            TreeNode nodeItem = new TreeNode(itemProperties.Name, iconIndex, iconIndex);
            // set node tag
            nodeItem.Tag = new NodeTag(nodeType, doc, itemProperties);
            // insert
            parentNode.Nodes.Add(nodeItem);
            parentNode.Expand();
            // if item is CaseOfBoxesProperties
            if (itemProperties is CaseOfBoxesProperties)
            {
                // insert sub node
                CaseOfBoxesProperties caseOfBoxesProperties = itemProperties as CaseOfBoxesProperties;
                TreeNode subNode = new TreeNode(caseOfBoxesProperties.InsideBoxProperties.Name, 3, 3);
                subNode.Tag = new NodeTag(NodeTag.NodeType.NT_BOX, doc, caseOfBoxesProperties.InsideBoxProperties);
                nodeItem.Nodes.Add(subNode);
            }
        }
        /// <summary>
        /// handles new analysis created
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="analysis"></param>
        public void OnNewAnalysisCreated(Document doc, CasePalletAnalysis analysis)
        {
            // get parent node
            TreeNode parentNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_LISTANALYSIS, doc));
            // insert analysis node
            int indexIconAnalysis = analysis.IsBoxAnalysis ? 10 : 11;
            TreeNode nodeAnalysis = new TreeNode(analysis.Name, indexIconAnalysis, indexIconAnalysis);
            nodeAnalysis.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSIS, doc, analysis);
            parentNode.Nodes.Add(nodeAnalysis);
            parentNode.Expand();
            // insert sub box node
            int indexIconBoxAnalysis = 4;
            if (analysis.BProperties is CaseOfBoxesProperties)
                indexIconBoxAnalysis = 15;
            else if (analysis.BProperties is BoxProperties)
                indexIconBoxAnalysis = 4;
            else if (analysis.BProperties is BundleProperties)
                indexIconBoxAnalysis = 5;
            TreeNode subBoxNode = new TreeNode(analysis.BProperties.Name, indexIconBoxAnalysis, indexIconBoxAnalysis);
            subBoxNode.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSISBOX, doc, analysis, analysis.BProperties);
            nodeAnalysis.Nodes.Add(subBoxNode);
            // insert sub pallet node
            TreeNode subPalletNode = new TreeNode(analysis.PalletProperties.Name, 7, 7);
            subPalletNode.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSISPALLET, doc, analysis, analysis.PalletProperties);
            nodeAnalysis.Nodes.Add(subPalletNode);
            // insert sub interlayer node if any
            if (analysis.HasInterlayer)
            {
                TreeNode subInterlayer = new TreeNode(analysis.InterlayerProperties.Name, 8, 8);
                subInterlayer.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSISINTERLAYER, doc, analysis, analysis.InterlayerProperties);
                nodeAnalysis.Nodes.Add(subInterlayer);
            }
            nodeAnalysis.Expand();

            // add event handlers for solution selection
            analysis.SolutionSelected += new CasePalletAnalysis.SelectSolution(onPalletAnalysisSolutionSelected);
            analysis.SolutionSelectionRemoved += new CasePalletAnalysis.SelectSolution(onPalletAnalysisSolutionSelectionRemoved);
        }
        /// <summary>
        /// handles new analysis created
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="caseAnalysis"></param>
        public void OnNewCaseAnalysisCreated(Document doc, BoxCasePalletAnalysis caseAnalysis)
        { 
            // get parent node
            TreeNode parentNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_LISTANALYSIS, doc));
            // insert case analysis node
            TreeNode nodeAnalysis = new TreeNode(caseAnalysis.Name, 14, 14);
            nodeAnalysis.Tag = new NodeTag(NodeTag.NodeType.NT_CASEANALYSIS, doc, caseAnalysis);
            parentNode.Nodes.Add(nodeAnalysis);
            parentNode.Expand();
            // insert sub box node
            TreeNode subBoxNode = new TreeNode(caseAnalysis.BoxProperties.Name, 3, 3);
            subBoxNode.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSISBOX, doc, caseAnalysis, caseAnalysis.BoxProperties);
            nodeAnalysis.Nodes.Add(subBoxNode);
            nodeAnalysis.Expand();

            caseAnalysis.SolutionSelected += new Basics.BoxCasePalletAnalysis.SelectSolution(onCaseAnalysisSolutionSelected);
            caseAnalysis.SolutionSelectionRemoved += new Basics.BoxCasePalletAnalysis.SelectSolution(onCaseAnalysisSolutionSelectionRemoved);
        }
        /// <summary>
        /// handles new truck analysis created
        /// </summary>
        public void OnNewTruckAnalysisCreated(Document doc, CasePalletAnalysis analysis, SelSolution selSolution, TruckAnalysis truckAnalysis)
        {
            // get parent node
            TreeNode parentNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_ANALYSISSOL, doc, analysis, selSolution));
            // insert truckAnalysis node
            TreeNode nodeTruckAnalysis = new TreeNode(truckAnalysis.Name, 13, 13);
            nodeTruckAnalysis.Tag = new NodeTag(NodeTag.NodeType.NT_TRUCKANALYSIS, doc, analysis, selSolution, truckAnalysis);
            parentNode.Nodes.Add(nodeTruckAnalysis);
            // expand parent tree node
            parentNode.Expand();
        }
        /// <summary>
        /// handles new ECT analysis created
        /// </summary>
        public void OnNewECTAnalysisCreated(Document doc, CasePalletAnalysis analysis, SelSolution selSolution, ECTAnalysis ectAnalysis)
        {
            // get parent node
            TreeNode parentNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_ANALYSISSOL, doc, analysis, selSolution));
            // insert truckAnalysis node
            TreeNode nodeECTAnalysis = new TreeNode(ectAnalysis.Name, 16, 16);
            nodeECTAnalysis.Tag = new NodeTag(NodeTag.NodeType.NT_ECTANALYSIS, doc, analysis, selSolution, ectAnalysis);
            parentNode.Nodes.Add(nodeECTAnalysis);
            // expand parent tree node
            parentNode.Expand();
        }
        #endregion

        #region Remove functions
        /// <summary>
        /// handles new type removed
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="itemBase"></param>
        public void OnTypeRemoved(Document doc, ItemBase itemBase)
        {
            NodeTag.NodeType nodeType = NodeTag.NodeType.NT_UNKNOWN;
            if (itemBase.GetType() == typeof(BoxProperties))
            {
                BoxProperties box = itemBase as BoxProperties;
                if (box.HasInsideDimensions)
                    nodeType = NodeTag.NodeType.NT_CASE;
                else
                    nodeType = NodeTag.NodeType.NT_BOX;
            }
            else if (itemBase.GetType() == typeof(BundleProperties))
            {
                nodeType = NodeTag.NodeType.NT_BUNDLE;
            }
            else if (itemBase.GetType() == typeof(CaseOfBoxesProperties))
            {
                nodeType = NodeTag.NodeType.NT_CASEOFBOXES;
            }
            else if (itemBase.GetType() == typeof(CaseOfBoxesProperties))
            {
                nodeType = NodeTag.NodeType.NT_CASEOFBOXES;
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
            TreeNode typeNode = FindNode(null, new NodeTag(nodeType, doc, itemBase));
            // remove node
            Nodes.Remove(typeNode);
        }
        /// <summary>
        /// handles analysis removed from document : actually removed analysis node from parent document node
        /// </summary>
        /// <param name="doc">parent document</param>
        /// <param name="analysis">analysis</param>
        public void OnAnalysisRemoved(Document doc, CasePalletAnalysis analysis)
        {
            // get node
            TreeNode analysisNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_ANALYSIS, doc, analysis));
            // test
            if (null == analysisNode)
            {
                _log.Warn(string.Format("Failed to find a valid tree node for analysis {0}", analysis.Name));
                return;
            }
            // remove node
            Nodes.Remove(analysisNode);
        }
        /// <summary>
        /// handles analysis removed from document : actually removed analysis node from parent document node
        /// </summary>
        /// <param name="doc">parent document</param>
        /// <param name="caseAnalysis">analysis</param>
        public void OnCaseAnalysisRemoved(Document doc, BoxCasePalletAnalysis caseAnalysis)
        {
            // get node
            TreeNode caseAnalysisNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_CASEANALYSIS, doc,  caseAnalysis));
            // test
            if (null == caseAnalysisNode)
            {
                _log.Warn(string.Format("Failed to find a valid tree node for caseAnalysis {0}", caseAnalysis.Name));
                return;
            }
            // remove node
            Nodes.Remove(caseAnalysisNode);
        }
        /// <summary>
        /// handles case solution unselected : actually removed selected solution node from case analysis node
        /// </summary>
        public void OnCaseAnalysisSolutionRemoved(Document doc, BoxCasePalletAnalysis caseAnalysis, SelCaseSolution selSolution)
        {
            // get node
            TreeNode selSolutionNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_CASESOLUTION, doc, caseAnalysis, selSolution));
            // test
            if (null == selSolutionNode)
            {
                _log.Error(string.Format("Failed to find a valid tree node for selSolution {0}", selSolution.Name));
                return;
            }
            // remove node
            Nodes.Remove(selSolutionNode);
        }
        /// <summary>
        /// handles truck analysis removal : removed truck analysis node from 
        /// </summary>
        public void OnTruckAnalysisRemoved(Document doc, CasePalletAnalysis analysis, SelSolution selSolution, TruckAnalysis truckAnalysis)
        {
            // get node
            TreeNode truckAnalysisNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_TRUCKANALYSIS, doc, analysis, selSolution, truckAnalysis));
            // test
            if (null == truckAnalysisNode)
            {
                _log.Warn(string.Format("Failed to find a valid tree node for truck analysis {0}", truckAnalysis.Name));
                return;
            }
            // remove node
            Nodes.Remove(truckAnalysisNode);  
        }
        /// <summary>
        /// handles ECT analysis removal
        /// </summary>
        public void OnECTAnalysisRemoved(Document doc, CasePalletAnalysis analysis, SelSolution selSolution, ECTAnalysis ectAnalysis)
        { 
            // get node
            TreeNode ectAnalysisNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_ECTANALYSIS, doc, analysis, selSolution, ectAnalysis));
            // test
            if (null == ectAnalysisNode)
            {
                _log.Warn(string.Format("Failed to find a valid tree node for truck analysis {0}", ectAnalysis.Name));
            }
            // remove node
            Nodes.Remove(ectAnalysisNode);
        }
        /// <summary>
        /// handles document closing event by removing the corresponding document node in TreeView
        /// </summary>
        public void OnDocumentClosed(Document doc)
        {
            NodeTag.NodeType nodeType = NodeTag.NodeType.NT_DOCUMENT;
            // get node
            TreeNode docNode = FindNode(null, new NodeTag(nodeType, doc));
            // remove node
            Nodes.Remove(docNode);
        }
        #endregion

        #region PalletAnalysis/CaseAnalysis solution added/removed Handlers
        private void onCaseAnalysisSolutionSelectionRemoved(BoxCasePalletAnalysis caseAnalysis, SelCaseSolution selSolution)
        {
            // retrieve parent document
            Document doc = caseAnalysis.ParentDocument;
            // get node
            TreeNode caseAnalysisNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_CASEANALYSIS, doc, caseAnalysis));
            // test
            if (null == caseAnalysisNode)
            {
                _log.Warn(string.Format("Failed to find a valid tree node for caseAnalysis {0}", caseAnalysis.Name));
                return;
            }
            // remove node
            Nodes.Remove(caseAnalysisNode);
        }

        private void onCaseAnalysisSolutionSelected(BoxCasePalletAnalysis caseAnalysis, SelCaseSolution selSolution)
        {
            // retrieve document
            Document doc = caseAnalysis.ParentDocument;
            // get parent node
            TreeNode parentNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_CASEANALYSIS, doc, caseAnalysis));
            // insert selected solution node
            TreeNode nodeSelSolution = new TreeNode(selSolution.Name, 12, 12);
            nodeSelSolution.Tag = new NodeTag(NodeTag.NodeType.NT_CASESOLUTION, doc, caseAnalysis, selSolution);
            parentNode.Nodes.Add(nodeSelSolution);
            // expand tree node
            parentNode.Expand();
        }

        private void onPalletAnalysisSolutionSelected(CasePalletAnalysis analysis, SelSolution selSolution)
        {
            // retrieve parent document
            Document doc = analysis.ParentDocument;
            // get parent node
            TreeNode parentNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_ANALYSIS, doc, analysis));
            // insert selected solution node
            TreeNode nodeSelSolution = new TreeNode(selSolution.Name, 12, 12);
            nodeSelSolution.Tag = new NodeTag(NodeTag.NodeType.NT_ANALYSISSOL, doc, analysis, selSolution);
            parentNode.Nodes.Add(nodeSelSolution);
            // expand tree nodes
            parentNode.Expand();
        }

        private void onPalletAnalysisSolutionSelectionRemoved(CasePalletAnalysis analysis, SelSolution selSolution)
        {
            // retrieve parent document
            Document doc = analysis.ParentDocument;
            // get node
            TreeNode selSolutionNode = FindNode(null, new NodeTag(NodeTag.NodeType.NT_ANALYSISSOL, doc, analysis, selSolution));
            // test
            if (null == selSolutionNode)
            {
                _log.Error(string.Format("Failed to find a valid tree node for selSolution {0}", selSolution.Name));
                return;
            }
            // remove node
            Nodes.Remove(selSolutionNode);
        }
        #endregion

        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(AnalysisTreeView));
        #endregion
    }
    #endregion

    #region NodeTag class
    /// <summary>
    /// NodeTag will be used for each TreeNode.Tag
    /// </summary>
    public class NodeTag
    {
        #region Enums
        /// <summary>
        /// AnalysisTreeView node types
        /// </summary>
        public enum NodeType
        {
            /// <summary>
            /// document
            /// </summary>
            NT_DOCUMENT,
            /// <summary>
            /// list of boxes
            /// </summary>
            NT_LISTBOX,
            /// <summary>
            /// list of cases
            /// </summary>
            NT_LISTCASE,
            /// <summary>
            /// list of cylinders
            /// </summary>
            NT_LISTCYLINDER,
            /// <summary>
            /// list of bundles
            /// </summary>
            NT_LISTBUNDLE,
            /// <summary>
            /// list of palets
            /// </summary>
            NT_LISTPALLET,
            /// <summary>
            /// list of interlayers
            /// </summary>
            NT_LISTINTERLAYER,
            /// <summary>
            /// list of trucks
            /// </summary>
            NT_LISTTRUCK,
            /// <summary>
            /// list of analyses
            /// </summary>
            NT_LISTANALYSIS,
            /// <summary>
            /// box
            /// </summary>
            NT_BOX,
            /// <summary>
            /// case
            /// </summary>
            NT_CASE,
            /// <summary>
            /// case of boxes
            /// </summary>
            NT_CASEOFBOXES,
            /// <summary>
            /// bundle
            /// </summary>
            NT_BUNDLE,
            /// <summary>
            /// cylinder
            /// </summary>
            NT_CYLINDER,
            /// <summary>
            /// palet
            /// </summary>
            NT_PALLET,
            /// <summary>
            /// interlayer
            /// </summary>
            NT_INTERLAYER,
            /// <summary>
            /// truck
            /// </summary>
            NT_TRUCK,
            /// <summary>
            /// analysis
            /// </summary>
            NT_ANALYSIS,
            /// <summary>
            /// analysis box
            /// </summary>
            NT_ANALYSISBOX,
            /// <summary>
            /// analysis pallet
            /// </summary>
            NT_ANALYSISPALLET,
            /// <summary>
            /// analysis interlayer
            /// </summary>
            NT_ANALYSISINTERLAYER,
            /// <summary>
            /// analysis solution
            /// </summary>
            NT_ANALYSISSOL,
            /// <summary>
            /// analysis report
            /// </summary>
            NT_ANALYSISSOLREPORT,
            /// <summary>
            /// truck analysis
            /// </summary>
            NT_TRUCKANALYSIS,
            /// <summary>
            /// truck analysis solution
            /// </summary>
            NT_TRUCKANALYSISSOL,
            /// <summary>
            /// case analysis
            /// </summary>
            NT_CASEANALYSIS,
            /// <summary>
            /// case analysis solution
            /// </summary>
            NT_CASESOLUTION,
            /// <summary>
            /// ECT analysis (Edge Crush Test)
            /// </summary>
            NT_ECTANALYSIS,
            /// <summary>
            /// unknown
            /// </summary>
            NT_UNKNOWN
        }
        #endregion

        #region Data members
        private NodeType _type;
        private Document _document;
        private ItemBase _itemProperties;
        private CasePalletAnalysis _analysis;
        private SelSolution _selSolution;
        private TruckAnalysis _truckAnalysis;
        private BoxCasePalletAnalysis _caseAnalysis;
        private SelCaseSolution _selCaseSolution;
        private ECTAnalysis _ectAnalysis;
        #endregion

        #region Constructor
        public NodeTag(NodeType type, Document document)
        {
            _type = type;
            _document = document;       
        }
        public NodeTag(NodeType type, Document document, ItemBase itemProperties)
        {
            _type = type;
            _document = document;
            if (_type == NodeType.NT_ANALYSIS && itemProperties is CasePalletAnalysis)
            {
                _analysis = itemProperties as CasePalletAnalysis;
                _itemProperties = null;
            }
            else
            {
                _analysis = null;
                _itemProperties = itemProperties;
            }
        }
        public NodeTag(NodeType type, Document document, CasePalletAnalysis analysis, ItemBase itemProperties)
        {
            _type = type;
            _document = document;
            _itemProperties = itemProperties;
            _analysis = analysis;
        }
        public NodeTag(NodeType type, Document document, CasePalletAnalysis analysis, SelSolution selSolution)
        {
            _type = type;
            _document = document;
            _itemProperties = null;
            _analysis = analysis;
            _selSolution = selSolution;
        }
        public NodeTag(NodeType type, Document document, CasePalletAnalysis analysis, SelSolution selSolution, TruckAnalysis truckAnalysis)
        {
            _type = type;
            _document = document;
            _itemProperties = null;
            _analysis = analysis;
            _selSolution = selSolution;
            _truckAnalysis = truckAnalysis;
        }
        public NodeTag(NodeType type, Document document, CasePalletAnalysis analysis, SelSolution selSolution, ECTAnalysis ectAnalysis)
        {
            _type = type;
            _document = document;
            _itemProperties = null;
            _analysis = analysis;
            _selSolution = selSolution;
            _ectAnalysis = ectAnalysis;
        }
        public NodeTag(NodeType type, Document doc, BoxCasePalletAnalysis caseAnalysis)
        { 
            _type = type;
            _document = doc;
            _caseAnalysis = caseAnalysis;       
        }
        public NodeTag(NodeType type, Document doc, BoxCasePalletAnalysis caseAnalysis, ItemBase itemProperties)
        {
            _type = type;
            _document = doc;
            _caseAnalysis = caseAnalysis;
            _itemProperties = itemProperties;
            _selSolution = null;
        }
        public NodeTag(NodeType type, Document document, BoxCasePalletAnalysis caseAnalysis, SelCaseSolution selCaseSolution)
        {
            _type = type;
            _document = document;
            _caseAnalysis = caseAnalysis;
            _selCaseSolution = selCaseSolution;
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
                && _analysis == nodeTag._analysis
                && _selSolution == nodeTag._selSolution
                && _truckAnalysis == nodeTag._truckAnalysis;
        }
        public override int GetHashCode()
        {
            return _type.GetHashCode()
                ^ _document.GetHashCode()
                ^ _itemProperties.GetHashCode()
                ^ _analysis.GetHashCode()
                ^ _selSolution.GetHashCode()
                ^ _truckAnalysis.GetHashCode();
        }
        #endregion

        #region Public properties
        /// <summary>
        /// returns node type
        /// </summary>
        public NodeType Type { get { return _type; } }
        /// <summary>
        /// returns document adressed 
        /// </summary>
        public Document Document { get { return _document; } }
        /// <summary>
        /// returns itempProperties (box/palet/interlayer)
        /// </summary>
        public ItemBase ItemProperties { get { return _itemProperties; } }
        /// <summary>
        /// returns analysis if any
        /// </summary>
        public CasePalletAnalysis Analysis { get { return _analysis; } }
        /// <summary>
        ///  returns selected solution if any
        /// </summary>
        public SelSolution SelSolution { get { return _selSolution; } }
        /// <summary>
        /// returns truck analysis of selected solution
        /// </summary>
        public TruckAnalysis TruckAnalysis { get { return _truckAnalysis; } }
        /// <summary>
        /// returns case analysis
        /// </summary>
        public BoxCasePalletAnalysis CaseAnalysis { get { return _caseAnalysis; } }
        /// <summary>
        /// returns selected case solution if any
        /// </summary>
        public SelCaseSolution SelCaseSolution { get { return _selCaseSolution; } }
        /// <summary>
        /// returns ECT analysis
        /// </summary>
        public ECTAnalysis ECTAnalysis { get { return _ectAnalysis; } }
        #endregion
    }
    #endregion

    #region AnalysisTreeViewEventArgs class
    /// <summary>
    /// EventArg inherited class used as AnalysisNodeClickHandler delegate argument
    /// Encapsulates a reference to a NodeTag
    /// </summary>
    public class AnalysisTreeViewEventArgs : EventArgs
    {
        #region Data members
        private NodeTag _nodeTag;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor takes the clicked node tag as argument
        /// </summary>
        /// <param name="nodeTag"></param>
        public AnalysisTreeViewEventArgs(NodeTag nodeTag)
        {
            _nodeTag = nodeTag;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Document
        /// </summary>
        public Document Document { get { return _nodeTag.Document; } }
        /// <summary>
        /// Analysis
        /// </summary>
        public CasePalletAnalysis Analysis { get { return _nodeTag.Analysis; } }
        /// <summary>
        /// ItemBase (BoxProperties \ PaletProperties \ Interlayer properties)
        /// </summary>
        public ItemBase ItemBase { get { return _nodeTag.ItemProperties; } }
        /// <summary>
        /// Selected solution
        /// </summary>
        public SelSolution SelSolution { get { return _nodeTag.SelSolution; } }
        /// <summary>
        /// Truck analysis
        /// </summary>
        public TruckAnalysis TruckAnalysis { get { return _nodeTag.TruckAnalysis; } }
        /// <summary>
        /// Case analysis
        /// </summary>
        public BoxCasePalletAnalysis CaseAnalysis { get { return _nodeTag.CaseAnalysis; } }
        /// <summary>
        /// Selected case solution
        /// </summary>
        public SelCaseSolution SelCaseSolution { get { return _nodeTag.SelCaseSolution; } }
        /// <summary>
        /// ECTAnalysis
        /// </summary>
        public ECTAnalysis ECTAnalysis { get { return _nodeTag.ECTAnalysis; } }
        #endregion
    }
    #endregion

    #region NewAnalysisCreatedEventArgs class
    /// <summary>
    /// EventArg inherited class used as AnalysisNodeClickHandler delegate argument
    /// Encapsulates a reference to an analysis
    /// </summary>
    public class NewAnalysisEventArgs : EventArgs
    {
        #region Data members
        private ItemBase _analysis;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor takes the newly created analysis as argument
        /// </summary>
        /// <param name="analysis"></param>
        public NewAnalysisEventArgs(ItemBase analysis)
        {
            _analysis = analysis;
        }
        #endregion

        #region Public properties

        #endregion
    }
    #endregion
}
