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
using System.Diagnostics;
using System.Reflection;

using WeifenLuo.WinFormsUI.Docking;
using log4net;
using Utilities;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Engine;
using TreeDim.StackBuilder.ReportingMSWord;

using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormMain : Form, IDocumentFactory, IMRUClient, IDocumentListener
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
        static readonly ILog _log = LogManager.GetLogger(typeof(FormMain));
        private static FormMain _instance;
        private MruManager _mruManager;
        #endregion

        #region Constructor
        public FormMain()
        {
            // set static instance
            _instance = this;
            // set analysis solver
            PalletAnalysis.Solver = new TreeDim.StackBuilder.Engine.Solver();
            CaseAnalysis.Solver = new TreeDim.StackBuilder.Engine.CaseSolver();
            // load content
            _deserializeDockContent = new DeserializeDockContent(ReloadContent);

            InitializeComponent();

            // initialize database
            PalletSolutionDatabase.Directory = Settings.Default.PalletSolutionsPath;
            PalletSolutionDatabase.Instance.SolutionAppended += new PalletSolutionDatabase.SolutionMoveHandler(PalletSolutionDBModified);
            PalletSolutionDatabase.Instance.SolutionDeleted += new PalletSolutionDatabase.SolutionMoveHandler(PalletSolutionDBModified);

            // load file passed as argument
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length >= 2)
            {
                OpenDocument(args[1]);
            }
            // or show splash sceen 
            else
            {
                // --- instantiate and start splach screen thread
                Thread th = new Thread(new ThreadStart(DoSplash));
                th.Start();
                // ---
            }
        }

        void PalletSolutionDBModified(object sender, PalletSolutionEventArgs eventArg)
        {
            UpdateToolbarState();
        }
        #endregion

        #region SplashScreen
        public void DoSplash()
        {
            SplashScreen sp = new SplashScreen(this);
            sp.TimerInterval = 2500;
            sp.ShowDialog();
        }
        #endregion

        #region Docking
        private void CreateBasicLayout()
        {
            _documentExplorer.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
            _documentExplorer.DocumentTreeView.AnalysisNodeClicked += new AnalysisTreeView.AnalysisNodeClickHandler(DocumentTreeView_NodeClicked);
            _documentExplorer.DocumentTreeView.SolutionReportNodeClicked += new AnalysisTreeView.AnalysisNodeClickHandler(DocumentTreeView_SolutionReportNodeClicked);

            // show or hide log console ?
            if (AssemblyConf == "debug" || Settings.Default.ShowLogConsole)
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

            // MRUManager
            _mruManager = new MruManager();
            _mruManager.Initialize(
             this,                              // owner form
             mnuFileMRU,                        // Recent Files menu item
             "Software\\TreeDim\\StackBuilder"); // Registry path to keep MRU list


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
        void DocumentTreeView_NodeClicked(object sender, AnalysisTreeViewEventArgs eventArg)
        {
            if ((null == eventArg.ItemBase) && (null != eventArg.Analysis) && (null == eventArg.TruckAnalysis))
            {
                CaseOfBoxesProperties caseOfBoxes = eventArg.Analysis.BProperties as CaseOfBoxesProperties;
                if (null != caseOfBoxes)
                    CreateOrActivateViewPalletAnalysisWithBox(eventArg.Analysis);
                else
                    CreateOrActivateViewPalletAnalysis(eventArg.Analysis);
            }
            else if (null != eventArg.ItemBase)
            {
                ItemBase itemProp = eventArg.ItemBase;
                if (itemProp.GetType() == typeof(BoxProperties))
                {
                    BoxProperties box = itemProp as BoxProperties;
                    FormNewBox form = new FormNewBox(eventArg.Document, eventArg.ItemBase as BoxProperties);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        if (box.HasDependingAnalyses)
                        {
                            if (DialogResult.Cancel == MessageBox.Show(
                                string.Format(Resources.ID_DEPENDINGANALYSES, box.Name)
                                , Application.ProductName
                                , MessageBoxButtons.OKCancel))
                                return;
                        }

                        box.Name = form.BoxName;
                        box.Description = form.Description;
                        box.Length = form.BoxLength;
                        box.Width = form.BoxWidth;
                        box.Height = form.BoxHeight;
                        box.Weight = form.Weight;
                        box.InsideLength = form.InsideLength;
                        box.InsideWidth = form.InsideWidth;
                        box.InsideHeight = form.InsideHeight;
                        box.SetAllColors(form.Colors);
                        box.TextureList = form.TextureList;
                        box.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(CaseOfBoxesProperties))
                {
                    CaseOfBoxesProperties caseOfBoxes = itemProp as CaseOfBoxesProperties;
                    FormNewCaseOfBoxes form = new FormNewCaseOfBoxes(eventArg.Document, caseOfBoxes);
                    form.CaseName = itemProp.Name;
                    form.CaseDescription = itemProp.Description;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (caseOfBoxes.HasDependingAnalyses)
                        {
                            if (DialogResult.Cancel == MessageBox.Show(
                               string.Format(Resources.ID_DEPENDINGANALYSES, caseOfBoxes.Name)
                               , Application.ProductName
                               , MessageBoxButtons.OKCancel))
                                return;
                        }
                        caseOfBoxes.Name = form.CaseName;
                        caseOfBoxes.Description = form.CaseDescription;
                        caseOfBoxes.SetAllColors(form.Colors);
                        caseOfBoxes.TextureList = form.TextureList;
                        caseOfBoxes.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(BundleProperties))
                {
                    BundleProperties bundle = itemProp as BundleProperties;
                    FormNewBundle form = new FormNewBundle(eventArg.Document, bundle);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        if (bundle.HasDependingAnalyses)
                        {
                            if (DialogResult.Cancel == MessageBox.Show(
                                string.Format(Resources.ID_DEPENDINGANALYSES, bundle.Name)
                                , Application.ProductName
                                , MessageBoxButtons.OKCancel))
                                return;
                        }

                        bundle.Name = form.BundleName;
                        bundle.Description = form.Description;
                        bundle.Length = form.BundleLength;
                        bundle.Width = form.BundleWidth;
                        bundle.UnitThickness = form.UnitThickness;
                        bundle.UnitWeight = form.UnitWeight;
                        bundle.NoFlats = form.NoFlats;
                        bundle.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(InterlayerProperties))
                {
                    InterlayerProperties interlayer = itemProp as InterlayerProperties;
                    FormNewInterlayer form = new FormNewInterlayer(eventArg.Document, interlayer);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        if (interlayer.HasDependingAnalyses)
                        {
                            if (DialogResult.Cancel == MessageBox.Show(
                                string.Format(Resources.ID_DEPENDINGANALYSES, interlayer.Name)
                                , Application.ProductName
                                , MessageBoxButtons.OKCancel))
                                return;
                        }
                        interlayer.Name = form.InterlayerName;
                        interlayer.Description = form.Description;
                        interlayer.Length = form.InterlayerLength;
                        interlayer.Width = form.InterlayerWidth;
                        interlayer.Thickness = form.Thickness;
                        interlayer.Weight = form.Weight;
                        interlayer.Color = form.Color;
                        interlayer.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(PalletProperties))
                {
                    PalletProperties pallet = itemProp as PalletProperties;
                    FormNewPallet form = new FormNewPallet(eventArg.Document, pallet);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        if (pallet.HasDependingAnalyses)
                        {
                            if (DialogResult.Cancel == MessageBox.Show(
                                string.Format(Resources.ID_DEPENDINGANALYSES, pallet.Name)
                                , Application.ProductName
                                , MessageBoxButtons.OKCancel))
                                return;
                        }
                        pallet.Name = form.PalletName;
                        pallet.Description = form.Description;
                        pallet.Length = form.PalletLength;
                        pallet.Width = form.PalletWidth;
                        pallet.Height = form.PalletHeight;
                        pallet.Type = form.PalletType;
                        pallet.Color = form.Color;
                        pallet.EndUpdate();
                    }
                }
                else if (itemProp.GetType() == typeof(TruckProperties))
                {
                    TruckProperties truck = itemProp as TruckProperties;
                    FormNewTruck form = new FormNewTruck(eventArg.Document, truck);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        truck.Name = form.TruckName;
                        truck.Description = form.Description;
                        truck.Length = form.TruckLength;
                        truck.Width = form.TruckWidth;
                        truck.Height = form.TruckHeight;
                        truck.AdmissibleLoadWeight = form.TruckAdmissibleLoadWeight;
                        truck.Color = form.TruckColor;
                        truck.EndUpdate();
                    }
                }
                else
                    Debug.Assert(false);
            }
            else if ((null == eventArg.ItemBase) && (null != eventArg.CaseAnalysis))
            {
                CaseAnalysis caseAnalysis = eventArg.CaseAnalysis;
                if (null != caseAnalysis)
                    CreateOrActivateViewCaseAnalysis(caseAnalysis);

            }
            else if (null != eventArg.TruckAnalysis)
            {
                TruckAnalysis truckAnalysis = eventArg.TruckAnalysis;
                if (null != truckAnalysis)
                    CreateOrActivateViewTruckAnalysis(truckAnalysis);
            }
        }

        void DocumentTreeView_SolutionReportNodeClicked(object sender, AnalysisTreeViewEventArgs eventArg)
        {
            try
            {
                if ((null == eventArg.ItemBase) && (null != eventArg.Analysis) && (null != eventArg.SelSolution))
                {
                    // build output file path
                    string outputFilePath = Path.ChangeExtension(Path.GetTempFileName(), "doc");
                    // build report
                    Reporter.BuidAnalysisReport(
                        eventArg.Analysis
                        , eventArg.SelSolution
                        , Settings.Default.ReportTemplatePath
                        , outputFilePath);
                    // logging
                    _log.Debug(string.Format("Saved report to: {0}", outputFilePath));
                    // open resulting report in Word
                    Process.Start(new ProcessStartInfo(outputFilePath));
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                Program.ReportException(ex);
            }
        }

        void DocumentTreeView_TruckAnalysisNodeClicked(object sender, AnalysisTreeViewEventArgs eventArg)
        {
            try
            {
                if ((null == eventArg.ItemBase) && (null != eventArg.Analysis) && (null != eventArg.SelSolution) && (null != eventArg.TruckAnalysis))
                { 

                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                Program.ReportException(ex);
            }
        }

        void DocumentTreeView_MenuEditAnalysis(object sender, AnalysisTreeViewEventArgs eventArg)
        {
            try
            {
                DocumentSB doc = eventArg.Document as DocumentSB;
                if ((null != doc) && (null != eventArg.Analysis))
                    doc.EditPalletAnalysis(eventArg.Analysis);
                CreateOrActivateViewPalletAnalysis(eventArg.Analysis);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                Program.ReportException(ex);
            }
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
            // new case
            newCaseToolStripMenuItem.Enabled = (null != doc);
            toolStripButtonAddNewCase.Enabled = (null != doc);
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
            newAnalysisToolStripMenuItem.Enabled = (null != doc) && doc.CanCreatePalletAnalysis;
            toolStripButtonCreateNewAnalysis.Enabled = (null != doc) && doc.CanCreatePalletAnalysis;
            // new case analysis
            newCaseAnalysisToolStripMenuItem.Enabled = (null != doc) && doc.CanCreateCaseAnalysis;
            toolStripButtonCreateNewCaseAnalysis.Enabled = (null != doc) && doc.CanCreateCaseAnalysis;
            // new analysis bundle
            newAnalysisBundleToolStripMenuItem.Enabled = (null != doc) && doc.CanCreateBundleAnalysis;
            toolStripButtonCreateNewBundleAnalysis.Enabled = (null != doc) && doc.CanCreateBundleAnalysis;
            // case optmisation
            caseOptimisationToolStripMenu.Enabled = (null != doc) && doc.CanCreateCaseOptimization;
            toolStripButtonOptimiseCase.Enabled = (null != doc) && doc.CanCreateCaseOptimization; 
            // edit pallet solutions database
            editPaletSolutionsDBToolStripMenuItem.Enabled = !PalletSolutionDatabase.Instance.IsEmpty;
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
            UpdateFormUI();
        }

        public void OpenDocument(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show(string.Format(Resources.ID_FILENOTFOUND, filePath));
                    return;
                }
                AddDocument(new DocumentSB(filePath, _documentExplorer.DocumentTreeView));

                // update mruFileManager as file was successfully loaded
                if (null != _mruManager)
                    _mruManager.Add(filePath);

                _log.Debug(string.Format("File {0} loaded!", filePath));
            }
            catch (Exception ex)
            {
                // update mruFileManager as we failed to load file
                if (null != _mruManager)
                    _mruManager.Remove(filePath);

                _log.Error(ex.ToString());
                Program.ReportException(ex);
            }
            UpdateFormUI();
        }

        public void AddDocument(IDocument doc)
        {
            // add this form as document listener
            DocumentSB docSB = doc as DocumentSB;
            if (null != docSB)
                docSB.AddListener(this);
            // add document 
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

        public void SaveAllDocuments()
        {
            CancelEventArgs e = new CancelEventArgs();
            SaveAllDocuments(e);
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
                DialogResult res = MessageBox.Show(string.Format(Resources.ID_SAVEMODIFIEDFILE, doc.Name), Application.ProductName, MessageBoxButtons.YesNoCancel);
                if (DialogResult.Yes == res)
                {
                    SaveDocument(doc, e);
                    e.Cancel = false;
                }
                else if (DialogResult.No == res)
                    e.Cancel = false;
                else if (DialogResult.Cancel == res)
                    e.Cancel = true;
            }
            if (e.Cancel)
                return;
            // close document
            doc.Close();
            // remove from document list
            _documents.Remove(doc);
            // handle the case
            _log.Debug(string.Format("Document {0} closed", doc.Name));
            // update toolbar
            UpdateToolbarState();
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
        /// <summary>
        /// Access list of documents
        /// </summary>
        public List<IDocument> Documents { get { return _documents; } }

        /// <summary>
        /// Get active view based on ActiveMdiChild
        /// </summary>
        public IView ActiveView
        {
            get
            {
                // search ammong existing views
                foreach (IDocument doc in Documents)
                    foreach (IView view in doc.Views)
                    {
                        Form form = view as Form;
                        if (this.ActiveMdiChild == form)
                            return view;
                    }
                return null;
            }            
        }

        public IDocument ActiveDocument
        {
            get
            {
                IView view = ActiveView;
                if (view != null)
                    return view.Document;
                else if (_documents.Count == 1)
                    return _documents[0];
                else
                    return null;
            }
        }

        /// <summary>
        /// Returns true if at least one document is dirty
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

        #region IDocumentListener implementation
        // new
        public void OnNewDocument(Document doc) {}
        public void OnNewTypeCreated(Document doc, ItemBase itemBase) { }
        public void OnNewAnalysisCreated(Document doc, PalletAnalysis analysis)
        {
            CaseOfBoxesProperties caseOfBoxes = analysis.BProperties as CaseOfBoxesProperties;
            if (null != caseOfBoxes)
                CreateOrActivateViewPalletAnalysisWithBox(analysis);
            else
                CreateOrActivateViewPalletAnalysis(analysis); 
        }
        public void OnNewCaseAnalysisCreated(Document doc, CaseAnalysis caseAnalysis)
        {
            CreateOrActivateViewCaseAnalysis(caseAnalysis); 
        }
        public void OnNewTruckAnalysisCreated(Document doc, PalletAnalysis analysis, SelSolution selSolution, TruckAnalysis truckAnalysis) { CreateOrActivateViewTruckAnalysis(truckAnalysis); }
        public void OnNewSolutionAdded(Document doc, PalletAnalysis analysis, SelSolution selectedSolution) { }
        // remove
        public void OnTypeRemoved(Document doc, ItemBase itemBase) { }
        public void OnAnalysisRemoved(Document doc, PalletAnalysis analysis) { }
        public void OnCaseAnalysisRemoved(Document doc, CaseAnalysis caseAnalysis) { }
        public void OnCaseAnalysisRemoved(Document doc, PalletAnalysis caseAnalysis) { }
        public void OnSolutionRemoved(Document doc, PalletAnalysis analysis, SelSolution selectedSolution) { }
        public void OnTruckAnalysisRemoved(Document doc, PalletAnalysis analysis, SelSolution selSolution, TruckAnalysis truckAnalysis) { }

        // close
        public void OnDocumentClosed(Document doc) { }
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
            CancelEventArgs cea = new CancelEventArgs();
            CloseDocument(doc, cea);
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

        private void fileSave(object sender, EventArgs e)        {   SaveDocument();                }
        private void fileSaveAs(object sender, EventArgs e)      {   SaveDocumentAs();              }
        private void fileSaveAll(object sender, EventArgs e)     {   SaveAllDocuments();            }
        private void fileExit(object sender, EventArgs e)
        {
            CancelEventArgs cea = new CancelEventArgs();
            CloseAllDocuments(cea);
            Close();
            Application.Exit(); 
        }
        public void OpenMRUFile(string filePath)
        {
            // open file e.FileName
            OpenDocument(filePath); // -> exception handled in OpenDocument
        }
        #endregion

        #region Tools
        private void toolAddNewBox(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewBoxUI();    }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.ReportException(ex); }
        }
        private void toolAddNewCase(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewCaseUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.ReportException(ex); }
        }
        private void toolAddNewBundle(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewBundleUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.ReportException(ex); }
        }

        private void toolAddNewInterlayer(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewInterlayerUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.ReportException(ex); }
        }

        private void toolAddNewPallet(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewPalletUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.ReportException(ex); }
        }

        private void toolAddNewTruck(object sender, EventArgs e)
        {
            try { ((DocumentSB)ActiveDocument).CreateNewTruckUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.ReportException(ex); }
        }

        private void toolAddNewAnalysis(object sender, EventArgs e)
        {
            try { PalletAnalysis analysis = ((DocumentSB)ActiveDocument).CreateNewAnalysisUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.ReportException(ex); }
        }
        private void toolAddNewAnalysisBundle(object sender, EventArgs e)
        {
            try { PalletAnalysis analysis = ((DocumentSB)ActiveDocument).CreateNewAnalysisBundleUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.ReportException(ex); }
        }
        private void toolAddNewCaseAnalysis(object sender, EventArgs e)
        {
            try { CaseAnalysis analysis = ((DocumentSB)ActiveDocument).CreateNewCaseAnalysisUI(); }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.ReportException(ex); }
        }
        private void toolEditPalletSolutionsDB(object sender, EventArgs e)
        {
            try
            {
                // show database edit form
                FormEditPalletSolutionDB form = new FormEditPalletSolutionDB();
                form.ShowDialog();
                // update toolbar state as database may now be empty
                UpdateToolbarState();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.ReportException(ex); }
        }
        private void toolStripButtonOptimiseCase_Click(object sender, EventArgs e)
        {
            try
            {
                // show optimisation form
                FormOptimizeCase form = new FormOptimizeCase((DocumentSB)ActiveDocument);
                form.ShowDialog();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); Program.ReportException(ex); }
        }
        #endregion

        #region Document / View status change handlers
        void documentModified(object sender, EventArgs e)
        {
            UpdateToolbarState();
        }
        #endregion

        #region Form activation/creation
        /// <summary>
        /// Creates or activate a pallet analysis view
        /// </summary>
        public void CreateOrActivateViewPalletAnalysis(PalletAnalysis analysis)
        {
            // ---> search among existing views
            // ---> activate if found
            foreach (IDocument doc in Documents)
                foreach (IView view in doc.Views)
                {
                    DockContentAnalysis form = view as DockContentAnalysis;
                    if (null == form) continue;
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

        public void CreateOrActivateViewPalletAnalysisWithBox(PalletAnalysis analysis)
        {
            // ---> search among existing views
            // ---> activate if found
            foreach (IDocument doc in Documents)
                foreach (IView view in doc.Views)
                {
                    DockContentAnalysisCaseOfBoxes form = view as DockContentAnalysisCaseOfBoxes;
                    if (null == form) continue;
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
            DockContentAnalysisCaseOfBoxes formAnalysis = parentDocument.CreateAnalysisViewCaseOfBoxes(analysis);
            formAnalysis.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }
        /// <summary>
        /// Creates or activate a truck analysis view
        /// </summary>
        public void CreateOrActivateViewTruckAnalysis(TruckAnalysis analysis)
        {
            // search among existing views
            foreach (IDocument doc in Documents)
                foreach (IView view in doc.Views)
                {
                    DockContentTruckAnalysis form = view as DockContentTruckAnalysis;
                    if (null == form) continue;
                    if (analysis == form.TruckAnalysis)
                    {
                        form.Activate();
                        return;
                    }
                }
            // ---> not found
            // ---> create new form
            // get document
            DocumentSB parentDocument = (DocumentSB)analysis.ParentDocument;
            // instantiate form
            DockContentTruckAnalysis formTruckAnalysis = parentDocument.CreateTruckAnalysisView(analysis);
            // show docked
            formTruckAnalysis.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }
        /// <summary>
        /// Creates or activate a case analysis view
        /// </summary>
        public void CreateOrActivateViewCaseAnalysis(CaseAnalysis caseAnalysis)
        {
            // search ammong existing views
            foreach (IDocument doc in Documents)
                foreach (IView view in doc.Views)
                {
                    DockContentCaseAnalysis form = view as DockContentCaseAnalysis;
                    if (null == form) continue;
                    if (caseAnalysis == form.CaseAnalysis)
                    {
                        form.Activate();
                        return;
                    }
                }
            // ---> not found
            // ---> create new form
            DocumentSB parentDocument = (DocumentSB)caseAnalysis.ParentDocument;
            DockContentCaseAnalysis formCaseAnalysis = parentDocument.CreateCaseAnalysisView(caseAnalysis);
            formCaseAnalysis.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        #endregion

        #region Helpers
        public string AssemblyConf
        {
            get
            {
                object[] attributes = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyConfigurationAttribute confAttribute = (AssemblyConfigurationAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (!string.IsNullOrEmpty(confAttribute.Configuration))
                        return confAttribute.Configuration.ToLower();
                }
                return "release";
            }
        }
        #endregion

        #region Help menu event handlers
        private void helpToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            AboutBox form = new AboutBox();
            form.CompanyUrl = "http://www.picador.fr/";
            form.ShowDialog();
        }
        private void helpToolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this
                    , Path.ChangeExtension(Application.ExecutablePath, "chm")
                    , HelpNavigator.Topic
                    , "FormMain.html");
            }
            catch (Exception ex)
            {   _log.Error(ex.ToString());  Program.ReportException(ex); }
        }
        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this
                    , Path.ChangeExtension(Application.ExecutablePath, "chm")
                    , HelpNavigator.Topic
                    , "TutorialIntroduction.html");
            }
            catch (Exception ex)
            { _log.Error(ex.ToString()); Program.ReportException(ex); }
        }
        #endregion

        #region Static instance accessor
        public static FormMain GetInstance()
        {
            return _instance;
        }
        #endregion
    }
}
