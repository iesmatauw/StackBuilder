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
            this.graphCtrlBoxesLayout = new TreeDim.StackBuilder.Graphics.Graphics3DControl();
            this.graphCtrlPallet = new TreeDim.StackBuilder.Graphics.Graphics3DControl();
            this.btClose = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.chkVerticalOrientationOnly = new System.Windows.Forms.CheckBox();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbBoxDimensions = new System.Windows.Forms.Label();
            this.cbBoxes = new System.Windows.Forms.ComboBox();
            this.lbBox = new System.Windows.Forms.Label();
            this.gbCase = new System.Windows.Forms.GroupBox();
            this.uSurfaceMassCase = new System.Windows.Forms.Label();
            this.nudWallSurfaceMass = new System.Windows.Forms.NumericUpDown();
            this.lbSurfaceMass = new System.Windows.Forms.Label();
            this.uLengthWallThickness = new System.Windows.Forms.Label();
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
            this.uLengthPalletHeight = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCasePallet)).BeginInit();
            this.splitContainerCasePallet.Panel1.SuspendLayout();
            this.splitContainerCasePallet.Panel2.SuspendLayout();
            this.splitContainerCasePallet.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            this.gbCase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallSurfaceMass)).BeginInit();
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
            resources.ApplyResources(this.splitContainerCasePallet, "splitContainerCasePallet");
            this.splitContainerCasePallet.Name = "splitContainerCasePallet";
            // 
            // splitContainerCasePallet.Panel1
            // 
            this.splitContainerCasePallet.Panel1.Controls.Add(this.graphCtrlBoxesLayout);
            // 
            // splitContainerCasePallet.Panel2
            // 
            this.splitContainerCasePallet.Panel2.Controls.Add(this.graphCtrlPallet);
            this.splitContainerCasePallet.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainerCasePallet_SplitterMoved);
            // 
            // graphCtrlBoxesLayout
            // 
            resources.ApplyResources(this.graphCtrlBoxesLayout, "graphCtrlBoxesLayout");
            this.graphCtrlBoxesLayout.Name = "graphCtrlBoxesLayout";
            this.graphCtrlBoxesLayout.TabStop = false;
            // 
            // graphCtrlPallet
            // 
            resources.ApplyResources(this.graphCtrlPallet, "graphCtrlPallet");
            this.graphCtrlPallet.Name = "graphCtrlPallet";
            this.graphCtrlPallet.TabStop = false;
            // 
            // btClose
            // 
            resources.ApplyResources(this.btClose, "btClose");
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Name = "btClose";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            resources.ApplyResources(this.groupBox, "groupBox");
            this.groupBox.Controls.Add(this.chkVerticalOrientationOnly);
            this.groupBox.Controls.Add(this.nudNumber);
            this.groupBox.Controls.Add(this.lbNumber);
            this.groupBox.Controls.Add(this.lbBoxDimensions);
            this.groupBox.Controls.Add(this.cbBoxes);
            this.groupBox.Controls.Add(this.lbBox);
            this.groupBox.Name = "groupBox";
            this.groupBox.TabStop = false;
            // 
            // chkVerticalOrientationOnly
            // 
            resources.ApplyResources(this.chkVerticalOrientationOnly, "chkVerticalOrientationOnly");
            this.chkVerticalOrientationOnly.Name = "chkVerticalOrientationOnly";
            this.chkVerticalOrientationOnly.UseVisualStyleBackColor = true;
            // 
            // nudNumber
            // 
            resources.ApplyResources(this.nudNumber, "nudNumber");
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
            resources.ApplyResources(this.lbNumber, "lbNumber");
            this.lbNumber.Name = "lbNumber";
            // 
            // lbBoxDimensions
            // 
            resources.ApplyResources(this.lbBoxDimensions, "lbBoxDimensions");
            this.lbBoxDimensions.Name = "lbBoxDimensions";
            // 
            // cbBoxes
            // 
            this.cbBoxes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxes.FormattingEnabled = true;
            resources.ApplyResources(this.cbBoxes, "cbBoxes");
            this.cbBoxes.Name = "cbBoxes";
            this.cbBoxes.SelectedIndexChanged += new System.EventHandler(this.cbBoxes_SelectedIndexChanged);
            // 
            // lbBox
            // 
            resources.ApplyResources(this.lbBox, "lbBox");
            this.lbBox.Name = "lbBox";
            // 
            // gbCase
            // 
            resources.ApplyResources(this.gbCase, "gbCase");
            this.gbCase.Controls.Add(this.uSurfaceMassCase);
            this.gbCase.Controls.Add(this.nudWallSurfaceMass);
            this.gbCase.Controls.Add(this.lbSurfaceMass);
            this.gbCase.Controls.Add(this.uLengthWallThickness);
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
            this.gbCase.Name = "gbCase";
            this.gbCase.TabStop = false;
            // 
            // uSurfaceMassCase
            // 
            resources.ApplyResources(this.uSurfaceMassCase, "uSurfaceMassCase");
            this.uSurfaceMassCase.Name = "uSurfaceMassCase";
            // 
            // nudWallSurfaceMass
            // 
            this.nudWallSurfaceMass.DecimalPlaces = 3;
            this.nudWallSurfaceMass.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.nudWallSurfaceMass, "nudWallSurfaceMass");
            this.nudWallSurfaceMass.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWallSurfaceMass.Name = "nudWallSurfaceMass";
            // 
            // lbSurfaceMass
            // 
            resources.ApplyResources(this.lbSurfaceMass, "lbSurfaceMass");
            this.lbSurfaceMass.Name = "lbSurfaceMass";
            // 
            // uLengthWallThickness
            // 
            resources.ApplyResources(this.uLengthWallThickness, "uLengthWallThickness");
            this.uLengthWallThickness.Name = "uLengthWallThickness";
            // 
            // btSetMaximum
            // 
            resources.ApplyResources(this.btSetMaximum, "btSetMaximum");
            this.btSetMaximum.Name = "btSetMaximum";
            this.btSetMaximum.UseVisualStyleBackColor = true;
            this.btSetMaximum.Click += new System.EventHandler(this.btSetMaximum_Click);
            // 
            // btSetMinimum
            // 
            resources.ApplyResources(this.btSetMinimum, "btSetMinimum");
            this.btSetMinimum.Name = "btSetMinimum";
            this.btSetMinimum.UseVisualStyleBackColor = true;
            this.btSetMinimum.Click += new System.EventHandler(this.btSetMinimum_Click);
            // 
            // nudWallThickness
            // 
            this.nudWallThickness.DecimalPlaces = 2;
            this.nudWallThickness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.nudWallThickness, "nudWallThickness");
            this.nudWallThickness.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWallThickness.Name = "nudWallThickness";
            this.nudWallThickness.ValueChanged += new System.EventHandler(this.OptimizationParameterChanged);
            // 
            // lbWallThickness
            // 
            resources.ApplyResources(this.lbWallThickness, "lbWallThickness");
            this.lbWallThickness.Name = "lbWallThickness";
            // 
            // nudWallsHeightDir
            // 
            resources.ApplyResources(this.nudWallsHeightDir, "nudWallsHeightDir");
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
            resources.ApplyResources(this.nudWallsWidthDir, "nudWallsWidthDir");
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
            resources.ApplyResources(this.nudWallsLengthDir, "nudWallsLengthDir");
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
            this.nudMaxCaseHeight.DecimalPlaces = 2;
            resources.ApplyResources(this.nudMaxCaseHeight, "nudMaxCaseHeight");
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
            this.nudMaxCaseWidth.DecimalPlaces = 2;
            resources.ApplyResources(this.nudMaxCaseWidth, "nudMaxCaseWidth");
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
            this.nudMaxCaseLength.DecimalPlaces = 2;
            resources.ApplyResources(this.nudMaxCaseLength, "nudMaxCaseLength");
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
            this.nudMinCaseHeight.DecimalPlaces = 2;
            resources.ApplyResources(this.nudMinCaseHeight, "nudMinCaseHeight");
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
            this.nudMinCaseWidth.DecimalPlaces = 2;
            resources.ApplyResources(this.nudMinCaseWidth, "nudMinCaseWidth");
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
            this.nudMinCaseLength.DecimalPlaces = 2;
            resources.ApplyResources(this.nudMinCaseLength, "nudMinCaseLength");
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
            resources.ApplyResources(this.lbHeight, "lbHeight");
            this.lbHeight.Name = "lbHeight";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lbLength
            // 
            resources.ApplyResources(this.lbLength, "lbLength");
            this.lbLength.Name = "lbLength";
            // 
            // lbWalls
            // 
            resources.ApplyResources(this.lbWalls, "lbWalls");
            this.lbWalls.Name = "lbWalls";
            // 
            // lbMaxCaseDimensions
            // 
            resources.ApplyResources(this.lbMaxCaseDimensions, "lbMaxCaseDimensions");
            this.lbMaxCaseDimensions.Name = "lbMaxCaseDimensions";
            // 
            // lbMinCaseDimensions
            // 
            resources.ApplyResources(this.lbMinCaseDimensions, "lbMinCaseDimensions");
            this.lbMinCaseDimensions.Name = "lbMinCaseDimensions";
            // 
            // gbPallet
            // 
            resources.ApplyResources(this.gbPallet, "gbPallet");
            this.gbPallet.Controls.Add(this.uLengthPalletHeight);
            this.gbPallet.Controls.Add(this.nudPalletHeight);
            this.gbPallet.Controls.Add(this.lbPalletHeight);
            this.gbPallet.Controls.Add(this.lbPalletDimensions);
            this.gbPallet.Controls.Add(this.cbPallet);
            this.gbPallet.Controls.Add(this.lbPallet);
            this.gbPallet.Name = "gbPallet";
            this.gbPallet.TabStop = false;
            // 
            // uLengthPalletHeight
            // 
            resources.ApplyResources(this.uLengthPalletHeight, "uLengthPalletHeight");
            this.uLengthPalletHeight.Name = "uLengthPalletHeight";
            // 
            // nudPalletHeight
            // 
            this.nudPalletHeight.DecimalPlaces = 2;
            resources.ApplyResources(this.nudPalletHeight, "nudPalletHeight");
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
            resources.ApplyResources(this.lbPalletHeight, "lbPalletHeight");
            this.lbPalletHeight.Name = "lbPalletHeight";
            // 
            // lbPalletDimensions
            // 
            resources.ApplyResources(this.lbPalletDimensions, "lbPalletDimensions");
            this.lbPalletDimensions.Name = "lbPalletDimensions";
            // 
            // cbPallet
            // 
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.FormattingEnabled = true;
            resources.ApplyResources(this.cbPallet, "cbPallet");
            this.cbPallet.Name = "cbPallet";
            this.cbPallet.SelectedIndexChanged += new System.EventHandler(this.cbPallet_SelectedIndexChanged);
            // 
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
            // 
            // btOptimize
            // 
            resources.ApplyResources(this.btOptimize, "btOptimize");
            this.btOptimize.Name = "btOptimize";
            this.btOptimize.UseVisualStyleBackColor = true;
            this.btOptimize.Click += new System.EventHandler(this.btOptimize_Click);
            // 
            // gridSolutions
            // 
            this.gridSolutions.AcceptsInputChar = false;
            resources.ApplyResources(this.gridSolutions, "gridSolutions");
            this.gridSolutions.EnableSort = false;
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // btAddSolution
            // 
            resources.ApplyResources(this.btAddSolution, "btAddSolution");
            this.btAddSolution.Name = "btAddSolution";
            this.btAddSolution.UseVisualStyleBackColor = true;
            this.btAddSolution.Click += new System.EventHandler(this.btAddSolution_Click);
            // 
            // statusStripDef
            // 
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.Name = "statusStripDef";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            // 
            // FormOptimizeCase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerCasePallet);
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.btAddSolution);
            this.Controls.Add(this.gridSolutions);
            this.Controls.Add(this.btOptimize);
            this.Controls.Add(this.gbPallet);
            this.Controls.Add(this.gbCase);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.btClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptimizeCase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOptimizeCase_FormClosing);
            this.Load += new System.EventHandler(this.FormOptimizeCase_Load);
            this.splitContainerCasePallet.Panel1.ResumeLayout(false);
            this.splitContainerCasePallet.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCasePallet)).EndInit();
            this.splitContainerCasePallet.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            this.gbCase.ResumeLayout(false);
            this.gbCase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWallSurfaceMass)).EndInit();
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
        private TreeDim.StackBuilder.Graphics.Graphics3DControl graphCtrlBoxesLayout;
        private TreeDim.StackBuilder.Graphics.Graphics3DControl graphCtrlPallet;
        private System.Windows.Forms.CheckBox chkVerticalOrientationOnly;
        private System.Windows.Forms.Label uLengthWallThickness;
        private System.Windows.Forms.Label uLengthPalletHeight;
        private System.Windows.Forms.Label uSurfaceMassCase;
        private System.Windows.Forms.NumericUpDown nudWallSurfaceMass;
        private System.Windows.Forms.Label lbSurfaceMass;
    }
}