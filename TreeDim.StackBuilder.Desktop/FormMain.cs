#region Using directives
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WeifenLuo.WinFormsUI.Docking;
using log4net;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Engine;

using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormMain : Form, IDocumentFactory
    {
        #region Data members
        /// <summary>
        /// Docking manager
        /// </summary>
        private DockContentDocumentExplorer _documentExplorer = new DockContentDocumentExplorer();
        private DockContentLogConsole _logConsole = new DockContentLogConsole();
        private ToolStripProfessionalRenderer _defaultRenderer = new ToolStripProfessionalRenderer(new PropertyGridEx.CustomColorScheme());
        private DeserializeDockContent _deserializeDockContent;
        /// <summary>
        /// List of document instance
        /// The document class holds data (boxes/pallets/interlayers/anslyses)
        /// </summary>
        private List<IDocument> _documents = new List<IDocument>();
        private IDocument _activeDocument;
        static readonly ILog _log = LogManager.GetLogger(typeof(FormMain));
        #endregion

        #region Constructor
        public FormMain()
        {
            _deserializeDockContent = new DeserializeDockContent(ReloadContent);
            InitializeComponent();

            // --- instantiate and start splach screen thread
            Thread th = new Thread(new ThreadStart(DoSplash));
            th.Start();
            Thread.Sleep(1000);
            th.Abort();
            Thread.Sleep(100);
            // ---
        }
        #endregion

        #region SplashScreen
        public void DoSplash()
        {
            SplashScreen sp = new SplashScreen();
            sp.ShowDialog();
        }
        #endregion

        #region Docking
        private void CreateBasicLayout()
        {
            _documentExplorer.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
            _documentExplorer.DocumentTreeView.AnalysisNodeClicked += new AnalysisTreeView.AnalysisNodeClickHandler(DocumentTreeView_AnalysisNodeClicked);
            _logConsole.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockBottom);
        }
        private IDockContent ReloadContent(string persistString)
        {
            switch (persistString)
            {
                case "frmDocument":
                    return null;
                case "frmSolution":
                    _documentExplorer = new DockContentDocumentExplorer();
                    return _documentExplorer;
                case "frmLogConsole":
                    _logConsole = new DockContentLogConsole();
                    return _logConsole;
                default:
                    return null;
            }
        }

        void FormMain_Load(object sender, System.EventArgs e)
        {
             string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

            // Apply a gray professional renderer as a default renderer
             ToolStripManager.Renderer = _defaultRenderer;
            _defaultRenderer.RoundedEdges = false;

            // Set DockPanel properties
            dockPanel.ActiveAutoHideContent = null;
            dockPanel.Parent = this;

            dockPanel.SuspendLayout(true);
            if (File.Exists(configFile))
                dockPanel.LoadFromXml(configFile, _deserializeDockContent);
            else
                // Load a basic layout
                CreateBasicLayout();
            dockPanel.ResumeLayout(true, true);

            UpdateToolbarState();

            // windows settings
            if (null != Settings.Default.FormMainPosition)
                Settings.Default.FormMainPosition.Restore(this);
        }

        private void FormMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (null == Settings.Default.FormMainPosition)
                Settings.Default.FormMainPosition = new WindowSettings();
            Settings.Default.FormMainPosition.Record(this);
            Settings.Default.Save();                
        }
        #endregion

        #region DocumentTreeView event handlers
        void DocumentTreeView_AnalysisNodeClicked(object sender, AnalysisTreeViewEventArgs eventArg)
        {
            CreateOrActivateViewAnalysis(eventArg.Analysis);
        }
        #endregion

        #region Caption text / toolbar state
        private void UpdateFormUI()
        {
            // get active document
            DocumentSB doc = ActiveDocument as DocumentSB;
            // form text
            string caption = string.Empty;
            if (null != doc)
            {
                caption += System.IO.Path.GetFileNameWithoutExtension(doc.FilePath);
                caption += " - "; 
            }
            caption += Application.ProductName;
            Text = caption;
        }
        /// <summary>
        /// enables / disable menu/toolbar items
        /// </summary>
        private void UpdateToolbarState()
        {
            DocumentSB doc = (DocumentSB)ActiveDocument;

            // save
            saveToolStripMenuItem.Enabled = (null != doc) && (doc.IsDirty);
            toolStripButtonFileSave.Enabled = (null != doc) && (doc.IsDirty);
            // save all
            saveAllToolStripMenuItem.Enabled = OneDocDirty;
            toolStripButtonFileSaveAll.Enabled = OneDocDirty;
            // save as
            saveAsToolStripMenuItem.Enabled = (null != doc);
            // close
            closeToolStripMenuItem.Enabled = (null != doc);
            // new box
            newBoxToolStripMenuItem.Enabled = (null != doc);
            toolStripButtonAddNewBox.Enabled = (null != doc);
            // new pallet
            newPalletToolStripMenuItem.Enabled = (null != doc);
            toolStripButtonAddNewPallet.Enabled = (null != doc);
            // new interlayer
            newInterlayerToolStripMenuItem.Enabled = (null != doc);
            toolStripButtonCreateNewInterlayer.Enabled = (null != doc);
            // new bundle
            newBundleToolStripMenuItem.Enabled = (null != doc);
            toolStripButtonCreateNewBundle.Enabled = (null != doc);
            // new truck
            newTruckToolStripMenuItem.Enabled = (null != doc);
            toolStripButtonAddNewTruck.Enabled = (null != doc);

            // new analysis
            newAnalysisToolStripMenuItem.Enabled = (null != doc) && doc.CanCreateAnalysis;
            toolStripButtonCreateNewAnalysis.Enabled = (null != doc) && doc.CanCreateAnalysis;
        }
        #endregion

        #region IDocumentFactory implementation
        public void NewDocument()
        {
            FormNewDocument form = new FormNewDocument();
            if (DialogResult.OK == form.ShowDialog())
            {
                AddDocument(new DocumentSB(form.DocName, form.DocDescription, form.Author, _documentExplorer.DocumentTreeView));
                _log.Debug("New document added!");
            }
        }

        public void OpenDocument(string filePath)
        {
            AddDocument(new DocumentSB(filePath, _documentExplorer.DocumentTreeView));
            _log.Debug(string.Format("File {0} loaded!", filePath));
        }

        public void AddDocument(IDocument doc)
        {
            _documents.Add(doc);
            doc.Modified += new EventHandler(documentModified);
            UpdateToolbarState();
        }

        public void SaveDocument()
        {
            IDocument doc = ActiveDocument;
            if (null == doc) return;
            CancelEventArgs e = new CancelEventArgs();
            SaveDocument(doc, e);
        }

        public void SaveDocument(IDocument doc, CancelEventArgs e)
        {
            if (doc.IsNew)
                SaveDocumentAs(doc, e);
            else
                doc.Save();
        }

        public void SaveAllDocuments(CancelEventArgs e)
        {
            if (e.Cancel) return;
            foreach (IDocument doc in Documents)
                SaveDocument(doc, e);
        }

        public void CloseAllDocuments(CancelEventArgs e)
        {
            // exit if already canceled
            if (e.Cancel) return;

            // try and close every opened documents
            while (_documents.Count > 0)
            {
                if (e.Cancel) return;

                IDocument doc = _documents[0];
                CloseDocument(doc, e);
            }
        }

        public void CloseDocument(IDocument doc, CancelEventArgs e)
        {
            // exit if already canceled
            if (e.Cancel)
                return;
            if (doc.IsDirty)
            {
                DialogResult res = MessageBox.Show(string.Format("Save file {0}?", doc.Name), Application.ProductName, MessageBoxButtons.YesNoCancel);
                if (DialogResult.Yes == res)
                    SaveDocument(doc, e);
                else if (DialogResult.Cancel == res)
                    e.Cancel = true;
            }
            if (e.Cancel)
                return;
            // close document
            doc.Close();
            // remove from document list
            _documents.Remove(doc);
        }

        public void SaveDocumentAs(IDocument doc, CancelEventArgs e)
        {
            if (saveFileDialogSB.ShowDialog() == DialogResult.OK)
                doc.SaveAs(saveFileDialogSB.FileName);
            else
                e.Cancel = true;
        }

        public void SaveDocumentAs()
        {
            IDocument doc = ActiveDocument;
            if (null == doc) return;
            CancelEventArgs e = new CancelEventArgs();
            SaveDocumentAs(doc, e);
        }

        public void CloseDocument()
        {
            IDocument doc = ActiveDocument;
            if (null == doc) return;

            // close active document
            CancelEventArgs e = new CancelEventArgs();
            CloseDocument(doc, e);
        }

        public List<IDocument> Documents { get { return _documents; } }
        public IView ActiveView
        {
            get
            {
                if (null == ActiveDocument)
                    return null;
                return ActiveDocument.ActiveView;
            }
        }

        public IDocument ActiveDocument
        {
            get
            {
                ResetActiveDocument();
                return _activeDocument;
            }
        }

        public void ResetActiveDocument()
        {
            if (null == _activeDocument && _documents.Count > 0)
                _activeDocument = _documents[0];
        }
        /// <summary>
        /// 
        /// </summary>
        public bool OneDocDirty
        {
            get
            {
                foreach (IDocument doc in Documents)
                    if (doc.IsDirty)
                        return true;
                return false;
            }
        }
        #endregion

        #region Form override 
        protected override void OnClosing(CancelEventArgs e)
        {
            CloseAllDocuments(e);
            base.OnClosing(e);
        }
        #endregion

        #region File menu event handlers
        private void fileClose(object sender, EventArgs e)
        {
            IDocument doc = ActiveDocument;
            if (null != doc)
            {
                if (doc.IsDirty)
                {
                    DialogResult res = MessageBox.Show("Save changes?", Application.ProductName, MessageBoxButtons.YesNoCancel);
                    if (res == DialogResult.Cancel)
                        return;
                    else if (res == DialogResult.Yes)
                        SaveDocument();
                }
                doc.Close();
            }
        }

        private void fileNew(object sender, EventArgs e)
        {
            NewDocument();
        }

        private void fileOpen(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialogSB.ShowDialog())
                foreach(string fileName in openFileDialogSB.FileNames)
                    OpenDocument(fileName);
            
        }

        private void fileSave(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void fileSaveAll(object sender, EventArgs e)
        {
            CancelEventArgs ea = new CancelEventArgs();
            SaveAllDocuments(ea);
        }

        private void fileExit(object sender, EventArgs e)
        {
            Close();                
        }
        #endregion

        #region Tools
        private void toolAddNewBox(object sender, EventArgs e)
        {
            DocumentSB doc = (DocumentSB)ActiveDocument;
            FormNewBox form = new FormNewBox(doc);
            if (DialogResult.OK == form.ShowDialog())
                doc.CreateNewBox(form.BoxName, form.Description, form.BoxLength, form.BoxWidth, form.BoxHeight, form.Weight, form.Colors);
        }

        private void toolAddNewBundle(object sender, EventArgs e)
        {
            DocumentSB doc = (DocumentSB)ActiveDocument;
            FormNewBundle form = new FormNewBundle(doc);
            if (DialogResult.OK == form.ShowDialog())
                doc.CreateNewBundle(
                    form.BundleName, form.Description
                    , form.BundleLength, form.BundleWidth, form.UnitThickness
                    , form.UnitWeight
                    , form.Color
                    , form.NoFlats);
        }

        private void toolAddNewInterlayer(object sender, EventArgs e)
        {
            DocumentSB doc = (DocumentSB)ActiveDocument;
            FormNewInterlayer form = new FormNewInterlayer(doc);
            if (DialogResult.OK == form.ShowDialog())
                doc.CreateNewInterlayer(
                    form.InterlayerName, form.Description
                    , form.InterlayerLength, form.InterlayerWidth, form.Thickness
                    , form.Weight
                    , form.Color);
        }

        private void toolAddNewPallet(object sender, EventArgs e)
        {
            DocumentSB doc = (DocumentSB)ActiveDocument;
            FormNewPallet form = new FormNewPallet(doc);
            if (DialogResult.OK == form.ShowDialog())
                doc.CreateNewPallet(form.PalletName, form.Description, form.PalletType
                    , form.PalletLength, form.PalletWidth, form.PalletHeight
                    , form.Weight
                    , form.AdmissibleLoadWeight, form.AdmissibleLoadHeight);
        }

        private void toolAddNewTruck(object sender, EventArgs e)
        {
            DocumentSB doc = (DocumentSB)ActiveDocument;
            if (null == doc) return;

            FormNewTruck form = new FormNewTruck(doc);
            if (DialogResult.OK == form.ShowDialog())
                doc.CreateNewTruck(form.TruckName, form.Description
                    , form.TruckLength, form.TruckWidth, form.TruckHeight
                    , form.TruckAdmissibleLoadWeight
                    , form.TruckColor);
        }

        private void toolAddNewAnalysis(object sender, EventArgs e)
        {
            DocumentSB doc = (DocumentSB)ActiveDocument;
            if (null == doc || !doc.CanCreateAnalysis)
                return;

            FormNewAnalysis form = new FormNewAnalysis(doc);
            form.Boxes = doc.Boxes.ToArray();
            form.Pallets = doc.Pallets.ToArray();
            form.Interlayers = doc.Interlayers.ToArray();
            if (DialogResult.OK == form.ShowDialog())
            {
                // build constraint set
                ConstraintSet constraintSet = new ConstraintSet();
                // overhang / underhang
                constraintSet.OverhangX = form.OverhangX;
                constraintSet.OverhangY = form.OverhangY;
                // allowed axes
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_N, form.AllowVerticalX);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_P, form.AllowVerticalX);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_N, form.AllowVerticalY);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_P, form.AllowVerticalY);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_N, form.AllowVerticalZ);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_P, form.AllowVerticalZ);
                // allowed patterns
                foreach (string s in form.AllowedPatterns)
                    constraintSet.SetAllowedPattern(s);
                // allow alternate layer
                constraintSet.AllowAlternateLayers = form.AllowAlternateLayers;
                constraintSet.AllowAlignedLayers = form.AllowAlignedLayers;
                // interlayers
                constraintSet.HasInterlayer = form.HasInterlayers;
                constraintSet.InterlayerPeriod = form.InterlayerPeriod;
                // stop criterion
                constraintSet.UseMaximumHeight = form.UseMaximumPalletHeight;
                constraintSet.UseMaximumNumberOfItems = form.UseMaximumNumberOfBoxes;
                constraintSet.UseMaximumPalletWeight = form.UseMaximumPalletWeight;
                constraintSet.UseMaximumWeightOnBox = form.UseMaximumLoadOnBox;
                constraintSet.MaximumHeight = form.MaximumPalletHeight;
                constraintSet.MaximumNumberOfItems = form.MaximumNumberOfBoxes;
                constraintSet.MaximumPalletWeight = form.MaximumPalletWeight;

                Analysis analysis = doc.CreateNewAnalysis(
                    form.AnalysisName, form.AnalysisDescription,
                    form.SelectedBox, form.SelectedPallet, form.SelectedInterlayer
                    , constraintSet
                    , new Solver());
                CreateOrActivateViewAnalysis(analysis);
            }
        }
        #endregion

        #region Document / View status change handlers
        void documentModified(object sender, EventArgs e)
        {
            UpdateToolbarState();
        }
        #endregion

        #region Form activation/creation
        public void CreateOrActivateViewAnalysis(Analysis analysis)
        {
            // ---> search among existing views
            // ---> activate if found
            foreach (IDocument doc in Documents)
                foreach (IView view in doc.Views)
                {
                    DockContentAnalysis form = view as DockContentAnalysis;
                    if (analysis == form.Analysis)
                    {
                        form.Activate();
                        return;
                    }
                }

            // ---> not found
            // ---> create new form
            // get document
            DocumentSB parentDocument = (DocumentSB)analysis.ParentDocument;
            DockContentAnalysis formAnalysis = parentDocument.CreateAnalysisView(analysis);
            formAnalysis.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }
        #endregion

        #region About dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox dlg = new AboutBox();
            dlg.ShowDialog();
        }
        #endregion
    }
}
