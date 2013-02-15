namespace TreeDim.StackBuilder.GUIExtension
{
    partial class FormSelectSolution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectSolution));
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.trackBarAngleVert = new System.Windows.Forms.TrackBar();
            this.trackBarAngleHoriz = new System.Windows.Forms.TrackBar();
            this.pictureBoxSolution = new System.Windows.Forms.PictureBox();
            this.gridSolutions = new SourceGrid.Grid();
            this.toolStripTools = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStackBuilder = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialogAsStb = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).BeginInit();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleVert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleHoriz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).BeginInit();
            this.toolStripTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerHoriz
            // 
            resources.ApplyResources(this.splitContainerHoriz, "splitContainerHoriz");
            this.splitContainerHoriz.Name = "splitContainerHoriz";
            // 
            // splitContainerHoriz.Panel1
            // 
            resources.ApplyResources(this.splitContainerHoriz.Panel1, "splitContainerHoriz.Panel1");
            this.splitContainerHoriz.Panel1.Controls.Add(this.trackBarAngleVert);
            this.splitContainerHoriz.Panel1.Controls.Add(this.trackBarAngleHoriz);
            this.splitContainerHoriz.Panel1.Controls.Add(this.pictureBoxSolution);
            // 
            // splitContainerHoriz.Panel2
            // 
            resources.ApplyResources(this.splitContainerHoriz.Panel2, "splitContainerHoriz.Panel2");
            this.splitContainerHoriz.Panel2.Controls.Add(this.gridSolutions);
            // 
            // trackBarAngleVert
            // 
            resources.ApplyResources(this.trackBarAngleVert, "trackBarAngleVert");
            this.trackBarAngleVert.LargeChange = 15;
            this.trackBarAngleVert.Maximum = 90;
            this.trackBarAngleVert.Name = "trackBarAngleVert";
            this.trackBarAngleVert.TickFrequency = 15;
            this.trackBarAngleVert.Value = 45;
            this.trackBarAngleVert.ValueChanged += new System.EventHandler(this.onRedrawNeeded);
            // 
            // trackBarAngleHoriz
            // 
            resources.ApplyResources(this.trackBarAngleHoriz, "trackBarAngleHoriz");
            this.trackBarAngleHoriz.LargeChange = 45;
            this.trackBarAngleHoriz.Maximum = 360;
            this.trackBarAngleHoriz.Name = "trackBarAngleHoriz";
            this.trackBarAngleHoriz.SmallChange = 45;
            this.trackBarAngleHoriz.TickFrequency = 90;
            this.trackBarAngleHoriz.Value = 225;
            this.trackBarAngleHoriz.ValueChanged += new System.EventHandler(this.onRedrawNeeded);
            // 
            // pictureBoxSolution
            // 
            resources.ApplyResources(this.pictureBoxSolution, "pictureBoxSolution");
            this.pictureBoxSolution.Name = "pictureBoxSolution";
            this.pictureBoxSolution.TabStop = false;
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
            // toolStripTools
            // 
            resources.ApplyResources(this.toolStripTools, "toolStripTools");
            this.toolStripTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonReport,
            this.toolStripButtonStackBuilder});
            this.toolStripTools.Name = "toolStripTools";
            // 
            // toolStripButtonReport
            // 
            resources.ApplyResources(this.toolStripButtonReport, "toolStripButtonReport");
            this.toolStripButtonReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReport.Name = "toolStripButtonReport";
            this.toolStripButtonReport.Click += new System.EventHandler(this.ToolsGenerateReport);
            // 
            // toolStripButtonStackBuilder
            // 
            resources.ApplyResources(this.toolStripButtonStackBuilder, "toolStripButtonStackBuilder");
            this.toolStripButtonStackBuilder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStackBuilder.Name = "toolStripButtonStackBuilder";
            this.toolStripButtonStackBuilder.Click += new System.EventHandler(this.ToolsGenerateStackBuilderProject);
            // 
            // saveFileDialogAsStb
            // 
            this.saveFileDialogAsStb.DefaultExt = "stb";
            resources.ApplyResources(this.saveFileDialogAsStb, "saveFileDialogAsStb");
            // 
            // FormSelectSolution
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerHoriz);
            this.Controls.Add(this.toolStripTools);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectSolution";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeChanged += new System.EventHandler(this.onRedrawNeeded);
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel1.PerformLayout();
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHoriz)).EndInit();
            this.splitContainerHoriz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleVert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleHoriz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).EndInit();
            this.toolStripTools.ResumeLayout(false);
            this.toolStripTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.ToolStrip toolStripTools;
        private System.Windows.Forms.ToolStripButton toolStripButtonReport;
        private System.Windows.Forms.ToolStripButton toolStripButtonStackBuilder;
        private System.Windows.Forms.PictureBox pictureBoxSolution;
        private System.Windows.Forms.TrackBar trackBarAngleHoriz;
        private System.Windows.Forms.TrackBar trackBarAngleVert;
        private System.Windows.Forms.SaveFileDialog saveFileDialogAsStb;
    }
}