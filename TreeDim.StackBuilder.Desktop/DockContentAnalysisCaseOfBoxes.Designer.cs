namespace TreeDim.StackBuilder.Desktop
{
    partial class DockContentAnalysisCaseOfBoxes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentAnalysisCaseOfBoxes));
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.splitContainerHorizInside = new System.Windows.Forms.SplitContainer();
            this.splitContainerVertInside = new System.Windows.Forms.SplitContainer();
            this.graphCtrlCase = new TreeDim.StackBuilder.Graphics.Graphics3DControl();
            this.graphCtrlPallet = new TreeDim.StackBuilder.Graphics.Graphics3DControl();
            this.gridSolutions = new SourceGrid.Grid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHorizInside)).BeginInit();
            this.splitContainerHorizInside.Panel1.SuspendLayout();
            this.splitContainerHorizInside.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVertInside)).BeginInit();
            this.splitContainerVertInside.Panel1.SuspendLayout();
            this.splitContainerVertInside.Panel2.SuspendLayout();
            this.splitContainerVertInside.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerHoriz
            // 
            resources.ApplyResources(this.splitContainerHoriz, "splitContainerHoriz");
            this.splitContainerHoriz.Name = "splitContainerHoriz";
            // 
            // splitContainerHoriz.Panel1
            // 
            this.splitContainerHoriz.Panel1.Controls.Add(this.splitContainerHorizInside);
            // 
            // splitContainerHoriz.Panel2
            // 
            this.splitContainerHoriz.Panel2.Controls.Add(this.gridSolutions);
            // 
            // splitContainerHorizInside
            // 
            resources.ApplyResources(this.splitContainerHorizInside, "splitContainerHorizInside");
            this.splitContainerHorizInside.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerHorizInside.Name = "splitContainerHorizInside";
            // 
            // splitContainerHorizInside.Panel1
            // 
            this.splitContainerHorizInside.Panel1.Controls.Add(this.splitContainerVertInside);
            // 
            // splitContainerVertInside
            // 
            resources.ApplyResources(this.splitContainerVertInside, "splitContainerVertInside");
            this.splitContainerVertInside.Name = "splitContainerVertInside";
            // 
            // splitContainerVertInside.Panel1
            // 
            this.splitContainerVertInside.Panel1.Controls.Add(this.graphCtrlCase);
            // 
            // splitContainerVertInside.Panel2
            // 
            this.splitContainerVertInside.Panel2.Controls.Add(this.graphCtrlPallet);
            // 
            // graphCtrlCase
            // 
            resources.ApplyResources(this.graphCtrlCase, "graphCtrlCase");
            this.graphCtrlCase.Name = "graphCtrlCase";
            this.graphCtrlCase.TabStop = false;
            this.graphCtrlCase.SizeChanged += new System.EventHandler(this.pictureBox_SizeChanged);
            // 
            // graphCtrlPallet
            // 
            resources.ApplyResources(this.graphCtrlPallet, "graphCtrlPallet");
            this.graphCtrlPallet.Name = "graphCtrlPallet";
            this.graphCtrlPallet.TabStop = false;
            this.graphCtrlPallet.SizeChanged += new System.EventHandler(this.pictureBox_SizeChanged);
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
            // DockContentAnalysisCaseOfBoxes
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerHoriz);
            this.Name = "DockContentAnalysisCaseOfBoxes";
            this.ShowIcon = false;
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            this.splitContainerHorizInside.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHorizInside)).EndInit();
            this.splitContainerHorizInside.ResumeLayout(false);
            this.splitContainerVertInside.Panel1.ResumeLayout(false);
            this.splitContainerVertInside.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVertInside)).EndInit();
            this.splitContainerVertInside.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.SplitContainer splitContainerHorizInside;
        private System.Windows.Forms.SplitContainer splitContainerVertInside;
        private TreeDim.StackBuilder.Graphics.Graphics3DControl graphCtrlCase;
        private TreeDim.StackBuilder.Graphics.Graphics3DControl graphCtrlPallet;
    }
}