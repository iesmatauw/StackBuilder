namespace TreeDim.StackBuilder.Desktop
{
    partial class DockContentAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentAnalysis));
            this.trackBarAngleHoriz = new System.Windows.Forms.TrackBar();
            this.trackBarAngleVert = new System.Windows.Forms.TrackBar();
            this.gridSolutions = new SourceGrid.Grid();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btSelectSolution = new System.Windows.Forms.Button();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxSolution = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleHoriz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleVert)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarAngleHoriz
            // 
            this.trackBarAngleHoriz.AccessibleDescription = null;
            this.trackBarAngleHoriz.AccessibleName = null;
            resources.ApplyResources(this.trackBarAngleHoriz, "trackBarAngleHoriz");
            this.trackBarAngleHoriz.BackgroundImage = null;
            this.trackBarAngleHoriz.Font = null;
            this.trackBarAngleHoriz.LargeChange = 45;
            this.trackBarAngleHoriz.Maximum = 360;
            this.trackBarAngleHoriz.Name = "trackBarAngleHoriz";
            this.trackBarAngleHoriz.SmallChange = 45;
            this.trackBarAngleHoriz.TickFrequency = 90;
            this.trackBarAngleHoriz.Value = 45;
            this.trackBarAngleHoriz.ValueChanged += new System.EventHandler(this.onAngleHorizChanged);
            // 
            // trackBarAngleVert
            // 
            this.trackBarAngleVert.AccessibleDescription = null;
            this.trackBarAngleVert.AccessibleName = null;
            resources.ApplyResources(this.trackBarAngleVert, "trackBarAngleVert");
            this.trackBarAngleVert.BackgroundImage = null;
            this.trackBarAngleVert.Font = null;
            this.trackBarAngleVert.LargeChange = 15;
            this.trackBarAngleVert.Maximum = 90;
            this.trackBarAngleVert.Name = "trackBarAngleVert";
            this.trackBarAngleVert.TickFrequency = 15;
            this.trackBarAngleVert.Value = 45;
            this.trackBarAngleVert.ValueChanged += new System.EventHandler(this.onAngleVertChanged);
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
            this.gridSolutions.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // toolStrip2
            // 
            this.toolStrip2.AccessibleDescription = null;
            this.toolStrip2.AccessibleName = null;
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.BackgroundImage = null;
            this.toolStrip2.Font = null;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton9});
            this.toolStrip2.Name = "toolStrip2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // btSelectSolution
            // 
            this.btSelectSolution.AccessibleDescription = null;
            this.btSelectSolution.AccessibleName = null;
            resources.ApplyResources(this.btSelectSolution, "btSelectSolution");
            this.btSelectSolution.BackgroundImage = null;
            this.btSelectSolution.Font = null;
            this.btSelectSolution.Name = "btSelectSolution";
            this.btSelectSolution.UseVisualStyleBackColor = true;
            this.btSelectSolution.Click += new System.EventHandler(this.btSelectSolution_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AccessibleDescription = null;
            this.toolStripButton1.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.BackgroundImage = null;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View0;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.onViewCorner_0);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AccessibleDescription = null;
            this.toolStripButton2.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.BackgroundImage = null;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View90;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.onViewCorner_90);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AccessibleDescription = null;
            this.toolStripButton3.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.BackgroundImage = null;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View180;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.onViewCorner_180);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AccessibleDescription = null;
            this.toolStripButton4.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            this.toolStripButton4.BackgroundImage = null;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View270;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.onViewCorner_270);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AccessibleDescription = null;
            this.toolStripButton5.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton5, "toolStripButton5");
            this.toolStripButton5.BackgroundImage = null;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_1;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.onViewSideFront);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AccessibleDescription = null;
            this.toolStripButton6.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton6, "toolStripButton6");
            this.toolStripButton6.BackgroundImage = null;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_2;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Click += new System.EventHandler(this.onViewSideLeft);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.AccessibleDescription = null;
            this.toolStripButton7.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton7, "toolStripButton7");
            this.toolStripButton7.BackgroundImage = null;
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_3;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Click += new System.EventHandler(this.onViewSideRear);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.AccessibleDescription = null;
            this.toolStripButton8.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton8, "toolStripButton8");
            this.toolStripButton8.BackgroundImage = null;
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_4;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Click += new System.EventHandler(this.onViewSideRight);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.AccessibleDescription = null;
            this.toolStripButton9.AccessibleName = null;
            resources.ApplyResources(this.toolStripButton9, "toolStripButton9");
            this.toolStripButton9.BackgroundImage = null;
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_Top;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Click += new System.EventHandler(this.onViewTop);
            // 
            // pictureBoxSolution
            // 
            this.pictureBoxSolution.AccessibleDescription = null;
            this.pictureBoxSolution.AccessibleName = null;
            resources.ApplyResources(this.pictureBoxSolution, "pictureBoxSolution");
            this.pictureBoxSolution.BackgroundImage = null;
            this.pictureBoxSolution.Font = null;
            this.pictureBoxSolution.ImageLocation = null;
            this.pictureBoxSolution.Name = "pictureBoxSolution";
            this.pictureBoxSolution.TabStop = false;
            this.pictureBoxSolution.SizeChanged += new System.EventHandler(this.pictureBoxSolution_SizeChanged);
            // 
            // DockContentAnalysis
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.btSelectSolution);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.gridSolutions);
            this.Controls.Add(this.trackBarAngleVert);
            this.Controls.Add(this.trackBarAngleHoriz);
            this.Controls.Add(this.pictureBoxSolution);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.HideOnClose = true;
            this.Icon = null;
            this.Name = "DockContentAnalysis";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.ToolTipText = null;
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleHoriz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleVert)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSolution;
        private System.Windows.Forms.TrackBar trackBarAngleHoriz;
        private System.Windows.Forms.TrackBar trackBarAngleVert;
        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.Button btSelectSolution;
    }
}