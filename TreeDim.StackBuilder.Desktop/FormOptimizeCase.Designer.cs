namespace TreeDim.StackBuilder.Desktop
{
    partial class FormOptimizeCase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptimizeCase));
            this.splitContainerCasePallet = new System.Windows.Forms.SplitContainer();
            this.pbBoxesLayout = new System.Windows.Forms.PictureBox();
            this.pbPallet = new System.Windows.Forms.PictureBox();
            this.btClose = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbBoxDimensions = new System.Windows.Forms.Label();
            this.cbBoxes = new System.Windows.Forms.ComboBox();
            this.lbBox = new System.Windows.Forms.Label();
            this.gbCase = new System.Windows.Forms.GroupBox();
            this.btSetMaximum = new System.Windows.Forms.Button();
            this.btSetMinimum = new System.Windows.Forms.Button();
            this.nudWallThickness = new System.Windows.Forms.NumericUpDown();
            this.lbWallThickness = new System.Windows.Forms.Label();
            this.nudWallsHeightDir = new System.Windows.Forms.NumericUpDown();
            this.nudWallsWidthDir = new System.Windows.Forms.NumericUpDown();
            this.nudWallsLengthDir = new System.Windows.Forms.NumericUpDown();
            this.nudMaxCaseHeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaxCaseWidth = new System.Windows.Forms.NumericUpDown();
            this.nudMaxCaseLength = new System.Windows.Forms.NumericUpDown();
            this.nudMinCaseHeight = new System.Windows.Forms.NumericUpDown();
            this.nudMinCaseWidth = new System.Windows.Forms.NumericUpDown();
            this.nudMinCaseLength = new System.Windows.Forms.NumericUpDown();
            this.lbHeight = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.lbWalls = new System.Windows.Forms.Label();
            this.lbMaxCaseDimensions = new System.Windows.Forms.Label();
            this.lbMinCaseDimensions = new System.Windows.Forms.Label();
            this.gbPallet = new System.Windows.Forms.GroupBox();
            this.nudPalletHeight = new System.Windows.Forms.NumericUpDown();
            this.lbPalletHeight = new System.Windows.Forms.Label();
            this.lbPalletDimensions = new System.Windows.Forms.Label();
            this.cbPallet = new System.Windows.Forms.ComboBox();
            this.lbPallet = new System.Windows.Forms.Label();
            this.btOptimize = new System.Windows.Forms.Button();
            this.gridSolutions = new SourceGrid.Grid();
            this.btAddSolution = new System.Windows.Forms.Button();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainerCasePallet.Panel1.SuspendLayout();
            this.splitContainerCasePallet.Panel2.SuspendLayout();
            this.splitContainerCasePallet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoxesLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPallet)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            this.gbCase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsHeightDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsWidthDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsLengthDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCaseHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCaseWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCaseLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaseHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaseWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaseLength)).BeginInit();
            this.gbPallet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletHeight)).BeginInit();
            this.statusStripDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerCasePallet
            // 
            this.splitContainerCasePallet.AccessibleDescription = null;
            this.splitContainerCasePallet.AccessibleName = null;
            resources.ApplyResources(this.splitContainerCasePallet, "splitContainerCasePallet");
            this.splitContainerCasePallet.BackgroundImage = null;
            this.splitContainerCasePallet.Font = null;
            this.splitContainerCasePallet.Name = "splitContainerCasePallet";
            // 
            // splitContainerCasePallet.Panel1
            // 
            this.splitContainerCasePallet.Panel1.AccessibleDescription = null;
            this.splitContainerCasePallet.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainerCasePallet.Panel1, "splitContainerCasePallet.Panel1");
            this.splitContainerCasePallet.Panel1.BackgroundImage = null;
            this.splitContainerCasePallet.Panel1.Controls.Add(this.pbBoxesLayout);
            this.splitContainerCasePallet.Panel1.Font = null;
            // 
            // splitContainerCasePallet.Panel2
            // 
            this.splitContainerCasePallet.Panel2.AccessibleDescription = null;
            this.splitContainerCasePallet.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainerCasePallet.Panel2, "splitContainerCasePallet.Panel2");
            this.splitContainerCasePallet.Panel2.BackgroundImage = null;
            this.splitContainerCasePallet.Panel2.Controls.Add(this.pbPallet);
            this.splitContainerCasePallet.Panel2.Font = null;
            this.splitContainerCasePallet.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainerCasePallet_SplitterMoved);
            // 
            // pbBoxesLayout
            // 
            this.pbBoxesLayout.AccessibleDescription = null;
            this.pbBoxesLayout.AccessibleName = null;
            resources.ApplyResources(this.pbBoxesLayout, "pbBoxesLayout");
            this.pbBoxesLayout.BackgroundImage = null;
            this.pbBoxesLayout.Font = null;
            this.pbBoxesLayout.ImageLocation = null;
            this.pbBoxesLayout.Name = "pbBoxesLayout";
            this.pbBoxesLayout.TabStop = false;
            // 
            // pbPallet
            // 
            this.pbPallet.AccessibleDescription = null;
            this.pbPallet.AccessibleName = null;
            resources.ApplyResources(this.pbPallet, "pbPallet");
            this.pbPallet.BackgroundImage = null;
            this.pbPallet.Font = null;
            this.pbPallet.ImageLocation = null;
            this.pbPallet.Name = "pbPallet";
            this.pbPallet.TabStop = false;
            // 
            // btClose
            // 
            this.btClose.AccessibleDescription = null;
            this.btClose.AccessibleName = null;
            resources.ApplyResources(this.btClose, "btClose");
            this.btClose.BackgroundImage = null;
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Font = null;
            this.btClose.Name = "btClose";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.AccessibleDescription = null;
            this.groupBox.AccessibleName = null;
            resources.ApplyResources(this.groupBox, "groupBox");
            this.groupBox.BackgroundImage = null;
            this.groupBox.Controls.Add(this.nudNumber);
            this.groupBox.Controls.Add(this.lbNumber);
            this.groupBox.Controls.Add(this.lbBoxDimensions);
            this.groupBox.Controls.Add(this.cbBoxes);
            this.groupBox.Controls.Add(this.lbBox);
            this.groupBox.Font = null;
            this.groupBox.Name = "groupBox";
            this.groupBox.TabStop = false;
            // 
            // nudNumber
            // 
            this.nudNumber.AccessibleDescription = null;
            this.nudNumber.AccessibleName = null;
            resources.ApplyResources(this.nudNumber, "nudNumber");
            this.nudNumber.Font = null;
            this.nudNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNumber.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNumber.Name = "nudNumber";
            this.nudNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNumber.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // lbNumber
            // 
            this.lbNumber.AccessibleDescription = null;
            this.lbNumber.AccessibleName = null;
            resources.ApplyResources(this.lbNumber, "lbNumber");
            this.lbNumber.Font = null;
            this.lbNumber.Name = "lbNumber";
            // 
            // lbBoxDimensions
            // 
            this.lbBoxDimensions.AccessibleDescription = null;
            this.lbBoxDimensions.AccessibleName = null;
            resources.ApplyResources(this.lbBoxDimensions, "lbBoxDimensions");
            this.lbBoxDimensions.Font = null;
            this.lbBoxDimensions.Name = "lbBoxDimensions";
            // 
            // cbBoxes
            // 
            this.cbBoxes.AccessibleDescription = null;
            this.cbBoxes.AccessibleName = null;
            resources.ApplyResources(this.cbBoxes, "cbBoxes");
            this.cbBoxes.BackgroundImage = null;
            this.cbBoxes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxes.Font = null;
            this.cbBoxes.FormattingEnabled = true;
            this.cbBoxes.Name = "cbBoxes";
            this.cbBoxes.SelectedIndexChanged += new System.EventHandler(this.cbBoxes_SelectedIndexChanged);
            // 
            // lbBox
            // 
            this.lbBox.AccessibleDescription = null;
            this.lbBox.AccessibleName = null;
            resources.ApplyResources(this.lbBox, "lbBox");
            this.lbBox.Font = null;
            this.lbBox.Name = "lbBox";
            // 
            // gbCase
            // 
            this.gbCase.AccessibleDescription = null;
            this.gbCase.AccessibleName = null;
            resources.ApplyResources(this.gbCase, "gbCase");
            this.gbCase.BackgroundImage = null;
            this.gbCase.Controls.Add(this.btSetMaximum);
            this.gbCase.Controls.Add(this.btSetMinimum);
            this.gbCase.Controls.Add(this.nudWallThickness);
            this.gbCase.Controls.Add(this.lbWallThickness);
            this.gbCase.Controls.Add(this.nudWallsHeightDir);
            this.gbCase.Controls.Add(this.nudWallsWidthDir);
            this.gbCase.Controls.Add(this.nudWallsLengthDir);
            this.gbCase.Controls.Add(this.nudMaxCaseHeight);
            this.gbCase.Controls.Add(this.nudMaxCaseWidth);
            this.gbCase.Controls.Add(this.nudMaxCaseLength);
            this.gbCase.Controls.Add(this.nudMinCaseHeight);
            this.gbCase.Controls.Add(this.nudMinCaseWidth);
            this.gbCase.Controls.Add(this.nudMinCaseLength);
            this.gbCase.Controls.Add(this.lbHeight);
            this.gbCase.Controls.Add(this.label3);
            this.gbCase.Controls.Add(this.lbLength);
            this.gbCase.Controls.Add(this.lbWalls);
            this.gbCase.Controls.Add(this.lbMaxCaseDimensions);
            this.gbCase.Controls.Add(this.lbMinCaseDimensions);
            this.gbCase.Font = null;
            this.gbCase.Name = "gbCase";
            this.gbCase.TabStop = false;
            // 
            // btSetMaximum
            // 
            this.btSetMaximum.AccessibleDescription = null;
            this.btSetMaximum.AccessibleName = null;
            resources.ApplyResources(this.btSetMaximum, "btSetMaximum");
            this.btSetMaximum.BackgroundImage = null;
            this.btSetMaximum.Font = null;
            this.btSetMaximum.Name = "btSetMaximum";
            this.btSetMaximum.UseVisualStyleBackColor = true;
            this.btSetMaximum.Click += new System.EventHandler(this.btSetMaximum_Click);
            // 
            // btSetMinimum
            // 
            this.btSetMinimum.AccessibleDescription = null;
            this.btSetMinimum.AccessibleName = null;
            resources.ApplyResources(this.btSetMinimum, "btSetMinimum");
            this.btSetMinimum.BackgroundImage = null;
            this.btSetMinimum.Font = null;
            this.btSetMinimum.Name = "btSetMinimum";
            this.btSetMinimum.UseVisualStyleBackColor = true;
            this.btSetMinimum.Click += new System.EventHandler(this.btSetMinimum_Click);
            // 
            // nudWallThickness
            // 
            this.nudWallThickness.AccessibleDescription = null;
            this.nudWallThickness.AccessibleName = null;
            resources.ApplyResources(this.nudWallThickness, "nudWallThickness");
            this.nudWallThickness.Font = null;
            this.nudWallThickness.Name = "nudWallThickness";
            this.nudWallThickness.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // lbWallThickness
            // 
            this.lbWallThickness.AccessibleDescription = null;
            this.lbWallThickness.AccessibleName = null;
            resources.ApplyResources(this.lbWallThickness, "lbWallThickness");
            this.lbWallThickness.Font = null;
            this.lbWallThickness.Name = "lbWallThickness";
            // 
            // nudWallsHeightDir
            // 
            this.nudWallsHeightDir.AccessibleDescription = null;
            this.nudWallsHeightDir.AccessibleName = null;
            resources.ApplyResources(this.nudWallsHeightDir, "nudWallsHeightDir");
            this.nudWallsHeightDir.Font = null;
            this.nudWallsHeightDir.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudWallsHeightDir.Name = "nudWallsHeightDir";
            this.nudWallsHeightDir.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudWallsHeightDir.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // nudWallsWidthDir
            // 
            this.nudWallsWidthDir.AccessibleDescription = null;
            this.nudWallsWidthDir.AccessibleName = null;
            resources.ApplyResources(this.nudWallsWidthDir, "nudWallsWidthDir");
            this.nudWallsWidthDir.Font = null;
            this.nudWallsWidthDir.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudWallsWidthDir.Name = "nudWallsWidthDir";
            this.nudWallsWidthDir.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudWallsWidthDir.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // nudWallsLengthDir
            // 
            this.nudWallsLengthDir.AccessibleDescription = null;
            this.nudWallsLengthDir.AccessibleName = null;
            resources.ApplyResources(this.nudWallsLengthDir, "nudWallsLengthDir");
            this.nudWallsLengthDir.Font = null;
            this.nudWallsLengthDir.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudWallsLengthDir.Name = "nudWallsLengthDir";
            this.nudWallsLengthDir.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudWallsLengthDir.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // nudMaxCaseHeight
            // 
            this.nudMaxCaseHeight.AccessibleDescription = null;
            this.nudMaxCaseHeight.AccessibleName = null;
            resources.ApplyResources(this.nudMaxCaseHeight, "nudMaxCaseHeight");
            this.nudMaxCaseHeight.Font = null;
            this.nudMaxCaseHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxCaseHeight.Name = "nudMaxCaseHeight";
            this.nudMaxCaseHeight.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // nudMaxCaseWidth
            // 
            this.nudMaxCaseWidth.AccessibleDescription = null;
            this.nudMaxCaseWidth.AccessibleName = null;
            resources.ApplyResources(this.nudMaxCaseWidth, "nudMaxCaseWidth");
            this.nudMaxCaseWidth.Font = null;
            this.nudMaxCaseWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxCaseWidth.Name = "nudMaxCaseWidth";
            this.nudMaxCaseWidth.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // nudMaxCaseLength
            // 
            this.nudMaxCaseLength.AccessibleDescription = null;
            this.nudMaxCaseLength.AccessibleName = null;
            resources.ApplyResources(this.nudMaxCaseLength, "nudMaxCaseLength");
            this.nudMaxCaseLength.Font = null;
            this.nudMaxCaseLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxCaseLength.Name = "nudMaxCaseLength";
            this.nudMaxCaseLength.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // nudMinCaseHeight
            // 
            this.nudMinCaseHeight.AccessibleDescription = null;
            this.nudMinCaseHeight.AccessibleName = null;
            resources.ApplyResources(this.nudMinCaseHeight, "nudMinCaseHeight");
            this.nudMinCaseHeight.Font = null;
            this.nudMinCaseHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMinCaseHeight.Name = "nudMinCaseHeight";
            this.nudMinCaseHeight.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // nudMinCaseWidth
            // 
            this.nudMinCaseWidth.AccessibleDescription = null;
            this.nudMinCaseWidth.AccessibleName = null;
            resources.ApplyResources(this.nudMinCaseWidth, "nudMinCaseWidth");
            this.nudMinCaseWidth.Font = null;
            this.nudMinCaseWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMinCaseWidth.Name = "nudMinCaseWidth";
            this.nudMinCaseWidth.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // nudMinCaseLength
            // 
            this.nudMinCaseLength.AccessibleDescription = null;
            this.nudMinCaseLength.AccessibleName = null;
            resources.ApplyResources(this.nudMinCaseLength, "nudMinCaseLength");
            this.nudMinCaseLength.Font = null;
            this.nudMinCaseLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMinCaseLength.Name = "nudMinCaseLength";
            this.nudMinCaseLength.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // lbHeight
            // 
            this.lbHeight.AccessibleDescription = null;
            this.lbHeight.AccessibleName = null;
            resources.ApplyResources(this.lbHeight, "lbHeight");
            this.lbHeight.Font = null;
            this.lbHeight.Name = "lbHeight";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // lbLength
            // 
            this.lbLength.AccessibleDescription = null;
            this.lbLength.AccessibleName = null;
            resources.ApplyResources(this.lbLength, "lbLength");
            this.lbLength.Font = null;
            this.lbLength.Name = "lbLength";
            // 
            // lbWalls
            // 
            this.lbWalls.AccessibleDescription = null;
            this.lbWalls.AccessibleName = null;
            resources.ApplyResources(this.lbWalls, "lbWalls");
            this.lbWalls.Font = null;
            this.lbWalls.Name = "lbWalls";
            // 
            // lbMaxCaseDimensions
            // 
            this.lbMaxCaseDimensions.AccessibleDescription = null;
            this.lbMaxCaseDimensions.AccessibleName = null;
            resources.ApplyResources(this.lbMaxCaseDimensions, "lbMaxCaseDimensions");
            this.lbMaxCaseDimensions.Font = null;
            this.lbMaxCaseDimensions.Name = "lbMaxCaseDimensions";
            // 
            // lbMinCaseDimensions
            // 
            this.lbMinCaseDimensions.AccessibleDescription = null;
            this.lbMinCaseDimensions.AccessibleName = null;
            resources.ApplyResources(this.lbMinCaseDimensions, "lbMinCaseDimensions");
            this.lbMinCaseDimensions.Font = null;
            this.lbMinCaseDimensions.Name = "lbMinCaseDimensions";
            // 
            // gbPallet
            // 
            this.gbPallet.AccessibleDescription = null;
            this.gbPallet.AccessibleName = null;
            resources.ApplyResources(this.gbPallet, "gbPallet");
            this.gbPallet.BackgroundImage = null;
            this.gbPallet.Controls.Add(this.nudPalletHeight);
            this.gbPallet.Controls.Add(this.lbPalletHeight);
            this.gbPallet.Controls.Add(this.lbPalletDimensions);
            this.gbPallet.Controls.Add(this.cbPallet);
            this.gbPallet.Controls.Add(this.lbPallet);
            this.gbPallet.Font = null;
            this.gbPallet.Name = "gbPallet";
            this.gbPallet.TabStop = false;
            // 
            // nudPalletHeight
            // 
            this.nudPalletHeight.AccessibleDescription = null;
            this.nudPalletHeight.AccessibleName = null;
            resources.ApplyResources(this.nudPalletHeight, "nudPalletHeight");
            this.nudPalletHeight.Font = null;
            this.nudPalletHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPalletHeight.Name = "nudPalletHeight";
            this.nudPalletHeight.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // lbPalletHeight
            // 
            this.lbPalletHeight.AccessibleDescription = null;
            this.lbPalletHeight.AccessibleName = null;
            resources.ApplyResources(this.lbPalletHeight, "lbPalletHeight");
            this.lbPalletHeight.Font = null;
            this.lbPalletHeight.Name = "lbPalletHeight";
            // 
            // lbPalletDimensions
            // 
            this.lbPalletDimensions.AccessibleDescription = null;
            this.lbPalletDimensions.AccessibleName = null;
            resources.ApplyResources(this.lbPalletDimensions, "lbPalletDimensions");
            this.lbPalletDimensions.Font = null;
            this.lbPalletDimensions.Name = "lbPalletDimensions";
            // 
            // cbPallet
            // 
            this.cbPallet.AccessibleDescription = null;
            this.cbPallet.AccessibleName = null;
            resources.ApplyResources(this.cbPallet, "cbPallet");
            this.cbPallet.BackgroundImage = null;
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.Font = null;
            this.cbPallet.FormattingEnabled = true;
            this.cbPallet.Name = "cbPallet";
            this.cbPallet.SelectedIndexChanged += new System.EventHandler(this.cbPallet_SelectedIndexChanged);
            // 
            // lbPallet
            // 
            this.lbPallet.AccessibleDescription = null;
            this.lbPallet.AccessibleName = null;
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Font = null;
            this.lbPallet.Name = "lbPallet";
            // 
            // btOptimize
            // 
            this.btOptimize.AccessibleDescription = null;
            this.btOptimize.AccessibleName = null;
            resources.ApplyResources(this.btOptimize, "btOptimize");
            this.btOptimize.BackgroundImage = null;
            this.btOptimize.Font = null;
            this.btOptimize.Name = "btOptimize";
            this.btOptimize.UseVisualStyleBackColor = true;
            this.btOptimize.Click += new System.EventHandler(this.btOptimize_Click);
            // 
            // gridSolutions
            // 
            this.gridSolutions.AcceptsInputChar = false;
            this.gridSolutions.AccessibleDescription = null;
            this.gridSolutions.AccessibleName = null;
            resources.ApplyResources(this.gridSolutions, "gridSolutions");
            this.gridSolutions.BackgroundImage = null;
            this.gridSolutions.EnableSort = false;
            this.gridSolutions.Font = null;
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // btAddSolution
            // 
            this.btAddSolution.AccessibleDescription = null;
            this.btAddSolution.AccessibleName = null;
            resources.ApplyResources(this.btAddSolution, "btAddSolution");
            this.btAddSolution.BackgroundImage = null;
            this.btAddSolution.Font = null;
            this.btAddSolution.Name = "btAddSolution";
            this.btAddSolution.UseVisualStyleBackColor = true;
            this.btAddSolution.Click += new System.EventHandler(this.btAddSolution_Click);
            // 
            // statusStripDef
            // 
            this.statusStripDef.AccessibleDescription = null;
            this.statusStripDef.AccessibleName = null;
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.BackgroundImage = null;
            this.statusStripDef.Font = null;
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStripDef.Name = "statusStripDef";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.AccessibleDescription = null;
            this.toolStripStatusLabelDef.AccessibleName = null;
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            this.toolStripStatusLabelDef.BackgroundImage = null;
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            // 
            // FormOptimizeCase
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.splitContainerCasePallet);
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.btAddSolution);
            this.Controls.Add(this.gridSolutions);
            this.Controls.Add(this.btOptimize);
            this.Controls.Add(this.gbPallet);
            this.Controls.Add(this.gbCase);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.btClose);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptimizeCase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormOptimizeCase_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOptimizeCase_FormClosing);
            this.splitContainerCasePallet.Panel1.ResumeLayout(false);
            this.splitContainerCasePallet.Panel2.ResumeLayout(false);
            this.splitContainerCasePallet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBoxesLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPallet)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            this.gbCase.ResumeLayout(false);
            this.gbCase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsHeightDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsWidthDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallsLengthDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCaseHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCaseWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxCaseLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaseHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaseWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinCaseLength)).EndInit();
            this.gbPallet.ResumeLayout(false);
            this.gbPallet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletHeight)).EndInit();
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ComboBox cbBoxes;
        private System.Windows.Forms.Label lbBox;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbBoxDimensions;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.GroupBox gbCase;
        private System.Windows.Forms.Label lbWalls;
        private System.Windows.Forms.Label lbMaxCaseDimensions;
        private System.Windows.Forms.Label lbMinCaseDimensions;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.NumericUpDown nudWallsHeightDir;
        private System.Windows.Forms.NumericUpDown nudWallsWidthDir;
        private System.Windows.Forms.NumericUpDown nudWallsLengthDir;
        private System.Windows.Forms.NumericUpDown nudMaxCaseHeight;
        private System.Windows.Forms.NumericUpDown nudMaxCaseWidth;
        private System.Windows.Forms.NumericUpDown nudMaxCaseLength;
        private System.Windows.Forms.NumericUpDown nudMinCaseHeight;
        private System.Windows.Forms.NumericUpDown nudMinCaseWidth;
        private System.Windows.Forms.NumericUpDown nudMinCaseLength;
        private System.Windows.Forms.NumericUpDown nudWallThickness;
        private System.Windows.Forms.Label lbWallThickness;
        private System.Windows.Forms.GroupBox gbPallet;
        private System.Windows.Forms.ComboBox cbPallet;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.Label lbPalletDimensions;
        private System.Windows.Forms.NumericUpDown nudPalletHeight;
        private System.Windows.Forms.Label lbPalletHeight;
        private System.Windows.Forms.Button btOptimize;
        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.Button btAddSolution;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private System.Windows.Forms.Button btSetMaximum;
        private System.Windows.Forms.Button btSetMinimum;
        private System.Windows.Forms.SplitContainer splitContainerCasePallet;
        private System.Windows.Forms.PictureBox pbBoxesLayout;
        private System.Windows.Forms.PictureBox pbPallet;
    }
}