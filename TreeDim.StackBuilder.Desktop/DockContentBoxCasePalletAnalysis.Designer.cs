namespace TreeDim.StackBuilder.Desktop
{
    partial class DockContentBoxCasePalletAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentBoxCasePalletAnalysis));
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.splitContainerVert = new System.Windows.Forms.SplitContainer();
            this.graphCtrlCaseSolution = new TreeDim.StackBuilder.Graphics.Graphics3DControl();
            this.graphCtrlPalletSolution = new TreeDim.StackBuilder.Graphics.Graphics3DControl();
            this.btSelectSolution = new System.Windows.Forms.Button();
            this.gridSolutions = new SourceGrid.Grid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).BeginInit();
            this.splitContainerVert.Panel1.SuspendLayout();
            this.splitContainerVert.Panel2.SuspendLayout();
            this.splitContainerVert.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerHoriz
            // 
            resources.ApplyResources(this.splitContainerHoriz, "splitContainerHoriz");
            this.splitContainerHoriz.Name = "splitContainerHoriz";
            // 
            // splitContainerHoriz.Panel1
            // 
            this.splitContainerHoriz.Panel1.Controls.Add(this.splitContainerVert);
            // 
            // splitContainerHoriz.Panel2
            // 
            this.splitContainerHoriz.Panel2.Controls.Add(this.gridSolutions);
            // 
            // splitContainerVert
            // 
            resources.ApplyResources(this.splitContainerVert, "splitContainerVert");
            this.splitContainerVert.Name = "splitContainerVert";
            // 
            // splitContainerVert.Panel1
            // 
            this.splitContainerVert.Panel1.Controls.Add(this.graphCtrlCaseSolution);
            this.splitContainerVert.Panel1.Controls.Add(this.btSelectSolution);
            // 
            // splitContainerVert.Panel2
            // 
            this.splitContainerVert.Panel2.Controls.Add(this.graphCtrlPalletSolution);
            // 
            // graphCtrlCaseSolution
            // 
            resources.ApplyResources(this.graphCtrlCaseSolution, "graphCtrlCaseSolution");
            this.graphCtrlCaseSolution.Name = "graphCtrlCaseSolution";
            this.graphCtrlCaseSolution.TabStop = false;
            // 
            // btSelectSolution
            // 
            resources.ApplyResources(this.btSelectSolution, "btSelectSolution");
            this.btSelectSolution.Name = "btSelectSolution";
            this.btSelectSolution.UseVisualStyleBackColor = true;
            this.btSelectSolution.Click += new System.EventHandler(this.btSelectSolution_Click);
            // 
            // graphCtrlPalletSolution
            // 
            resources.ApplyResources(this.graphCtrlPalletSolution, "graphCtrlPalletSolution");
            this.graphCtrlPalletSolution.Name = "graphCtrlPalletSolution";
            this.graphCtrlPalletSolution.TabStop = false;
            // 
            // gridSolutions
            // 
            this.gridSolutions.AcceptsInputChar = false;
            resources.ApplyResources(this.gridSolutions, "gridSolutions");
            this.gridSolutions.EnableSort = false;
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridSolutions.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // DockContentBoxCasePalletAnalysis
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerHoriz);
            this.Name = "DockContentBoxCasePalletAnalysis";
            this.ShowInTaskbar = false;
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.splitContainerVert.Panel1.ResumeLayout(false);
            this.splitContainerVert.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVert)).EndInit();
            this.splitContainerVert.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Button btSelectSolution;
        private SourceGrid.Grid gridSolutions;
        private TreeDim.StackBuilder.Graphics.Graphics3DControl graphCtrlCaseSolution;
        private TreeDim.StackBuilder.Graphics.Graphics3DControl graphCtrlPalletSolution;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.SplitContainer splitContainerVert;
    }
}