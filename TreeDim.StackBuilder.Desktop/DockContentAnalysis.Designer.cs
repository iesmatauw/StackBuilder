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
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.pictureBoxSolution = new System.Windows.Forms.PictureBox();
            this.trackBarAngleHoriz = new System.Windows.Forms.TrackBar();
            this.trackBarAngleVert = new System.Windows.Forms.TrackBar();
            this.btSelectSolution = new System.Windows.Forms.Button();
            this.gridSolutions = new SourceGrid.Grid();
            this.toolStrip_view = new System.Windows.Forms.ToolStrip();
            this.toolStripCornerView0 = new System.Windows.Forms.ToolStripButton();
            this.toolStripCornerView90 = new System.Windows.Forms.ToolStripButton();
            this.toolStripCornerView180 = new System.Windows.Forms.ToolStripButton();
            this.toolStripCornerView270 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripFrontView = new System.Windows.Forms.ToolStripButton();
            this.toolStripRightView = new System.Windows.Forms.ToolStripButton();
            this.toolStripBackView = new System.Windows.Forms.ToolStripButton();
            this.toolStripLeftView = new System.Windows.Forms.ToolStripButton();
            this.toolStripTopView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripShowImages = new System.Windows.Forms.ToolStripButton();
            this.splitContainerHoriz.Panel1.SuspendLayout();
            this.splitContainerHoriz.Panel2.SuspendLayout();
            this.splitContainerHoriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleHoriz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleVert)).BeginInit();
            this.toolStrip_view.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerHoriz
            // 
            this.splitContainerHoriz.AccessibleDescription = null;
            this.splitContainerHoriz.AccessibleName = null;
            resources.ApplyResources(this.splitContainerHoriz, "splitContainerHoriz");
            this.splitContainerHoriz.BackgroundImage = null;
            this.splitContainerHoriz.Font = null;
            this.splitContainerHoriz.Name = "splitContainerHoriz";
            // 
            // splitContainerHoriz.Panel1
            // 
            this.splitContainerHoriz.Panel1.AccessibleDescription = null;
            this.splitContainerHoriz.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainerHoriz.Panel1, "splitContainerHoriz.Panel1");
            this.splitContainerHoriz.Panel1.BackgroundImage = null;
            this.splitContainerHoriz.Panel1.Controls.Add(this.pictureBoxSolution);
            this.splitContainerHoriz.Panel1.Controls.Add(this.trackBarAngleHoriz);
            this.splitContainerHoriz.Panel1.Controls.Add(this.trackBarAngleVert);
            this.splitContainerHoriz.Panel1.Controls.Add(this.btSelectSolution);
            this.splitContainerHoriz.Panel1.Font = null;
            // 
            // splitContainerHoriz.Panel2
            // 
            this.splitContainerHoriz.Panel2.AccessibleDescription = null;
            this.splitContainerHoriz.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainerHoriz.Panel2, "splitContainerHoriz.Panel2");
            this.splitContainerHoriz.Panel2.BackgroundImage = null;
            this.splitContainerHoriz.Panel2.Controls.Add(this.gridSolutions);
            this.splitContainerHoriz.Panel2.Font = null;
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
            // toolStrip_view
            // 
            this.toolStrip_view.AccessibleDescription = null;
            this.toolStrip_view.AccessibleName = null;
            resources.ApplyResources(this.toolStrip_view, "toolStrip_view");
            this.toolStrip_view.BackgroundImage = null;
            this.toolStrip_view.Font = null;
            this.toolStrip_view.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCornerView0,
            this.toolStripCornerView90,
            this.toolStripCornerView180,
            this.toolStripCornerView270,
            this.toolStripSeparator1,
            this.toolStripFrontView,
            this.toolStripRightView,
            this.toolStripBackView,
            this.toolStripLeftView,
            this.toolStripTopView,
            this.toolStripSeparator2,
            this.toolStripShowImages});
            this.toolStrip_view.Name = "toolStrip_view";
            // 
            // toolStripCornerView0
            // 
            this.toolStripCornerView0.AccessibleDescription = null;
            this.toolStripCornerView0.AccessibleName = null;
            resources.ApplyResources(this.toolStripCornerView0, "toolStripCornerView0");
            this.toolStripCornerView0.BackgroundImage = null;
            this.toolStripCornerView0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCornerView0.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View0;
            this.toolStripCornerView0.Name = "toolStripCornerView0";
            this.toolStripCornerView0.Click += new System.EventHandler(this.onViewCorner_0);
            // 
            // toolStripCornerView90
            // 
            this.toolStripCornerView90.AccessibleDescription = null;
            this.toolStripCornerView90.AccessibleName = null;
            resources.ApplyResources(this.toolStripCornerView90, "toolStripCornerView90");
            this.toolStripCornerView90.BackgroundImage = null;
            this.toolStripCornerView90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCornerView90.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View90;
            this.toolStripCornerView90.Name = "toolStripCornerView90";
            this.toolStripCornerView90.Click += new System.EventHandler(this.onViewCorner_90);
            // 
            // toolStripCornerView180
            // 
            this.toolStripCornerView180.AccessibleDescription = null;
            this.toolStripCornerView180.AccessibleName = null;
            resources.ApplyResources(this.toolStripCornerView180, "toolStripCornerView180");
            this.toolStripCornerView180.BackgroundImage = null;
            this.toolStripCornerView180.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCornerView180.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View180;
            this.toolStripCornerView180.Name = "toolStripCornerView180";
            this.toolStripCornerView180.Click += new System.EventHandler(this.onViewCorner_180);
            // 
            // toolStripCornerView270
            // 
            this.toolStripCornerView270.AccessibleDescription = null;
            this.toolStripCornerView270.AccessibleName = null;
            resources.ApplyResources(this.toolStripCornerView270, "toolStripCornerView270");
            this.toolStripCornerView270.BackgroundImage = null;
            this.toolStripCornerView270.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCornerView270.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View270;
            this.toolStripCornerView270.Name = "toolStripCornerView270";
            this.toolStripCornerView270.Click += new System.EventHandler(this.onViewCorner_270);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripFrontView
            // 
            this.toolStripFrontView.AccessibleDescription = null;
            this.toolStripFrontView.AccessibleName = null;
            resources.ApplyResources(this.toolStripFrontView, "toolStripFrontView");
            this.toolStripFrontView.BackgroundImage = null;
            this.toolStripFrontView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFrontView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_1;
            this.toolStripFrontView.Name = "toolStripFrontView";
            this.toolStripFrontView.Click += new System.EventHandler(this.onViewSideFront);
            // 
            // toolStripRightView
            // 
            this.toolStripRightView.AccessibleDescription = null;
            this.toolStripRightView.AccessibleName = null;
            resources.ApplyResources(this.toolStripRightView, "toolStripRightView");
            this.toolStripRightView.BackgroundImage = null;
            this.toolStripRightView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRightView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_2;
            this.toolStripRightView.Name = "toolStripRightView";
            this.toolStripRightView.Click += new System.EventHandler(this.onViewSideRight);
            // 
            // toolStripBackView
            // 
            this.toolStripBackView.AccessibleDescription = null;
            this.toolStripBackView.AccessibleName = null;
            resources.ApplyResources(this.toolStripBackView, "toolStripBackView");
            this.toolStripBackView.BackgroundImage = null;
            this.toolStripBackView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBackView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_3;
            this.toolStripBackView.Name = "toolStripBackView";
            this.toolStripBackView.Click += new System.EventHandler(this.onViewSideRear);
            // 
            // toolStripLeftView
            // 
            this.toolStripLeftView.AccessibleDescription = null;
            this.toolStripLeftView.AccessibleName = null;
            resources.ApplyResources(this.toolStripLeftView, "toolStripLeftView");
            this.toolStripLeftView.BackgroundImage = null;
            this.toolStripLeftView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLeftView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_4;
            this.toolStripLeftView.Name = "toolStripLeftView";
            this.toolStripLeftView.Click += new System.EventHandler(this.onViewSideLeft);
            // 
            // toolStripTopView
            // 
            this.toolStripTopView.AccessibleDescription = null;
            this.toolStripTopView.AccessibleName = null;
            resources.ApplyResources(this.toolStripTopView, "toolStripTopView");
            this.toolStripTopView.BackgroundImage = null;
            this.toolStripTopView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTopView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_Top;
            this.toolStripTopView.Name = "toolStripTopView";
            this.toolStripTopView.Click += new System.EventHandler(this.onViewTop);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AccessibleDescription = null;
            this.toolStripSeparator2.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // toolStripShowImages
            // 
            this.toolStripShowImages.AccessibleDescription = null;
            this.toolStripShowImages.AccessibleName = null;
            resources.ApplyResources(this.toolStripShowImages, "toolStripShowImages");
            this.toolStripShowImages.BackgroundImage = null;
            this.toolStripShowImages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripShowImages.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.Image;
            this.toolStripShowImages.Name = "toolStripShowImages";
            this.toolStripShowImages.Click += new System.EventHandler(this.toolStripShowImages_Click);
            // 
            // DockContentAnalysis
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.splitContainerHoriz);
            this.Controls.Add(this.toolStrip_view);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.HideOnClose = true;
            this.Name = "DockContentAnalysis";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.ShowInTaskbar = false;
            this.ToolTipText = null;
            this.Load += new System.EventHandler(this.DockContentAnalysis_Load);
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel1.PerformLayout();
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            this.splitContainerHoriz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleHoriz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleVert)).EndInit();
            this.toolStrip_view.ResumeLayout(false);
            this.toolStrip_view.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSolution;
        private System.Windows.Forms.TrackBar trackBarAngleHoriz;
        private System.Windows.Forms.TrackBar trackBarAngleVert;
        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.ToolStrip toolStrip_view;
        private System.Windows.Forms.ToolStripButton toolStripCornerView0;
        private System.Windows.Forms.ToolStripButton toolStripCornerView90;
        private System.Windows.Forms.ToolStripButton toolStripCornerView180;
        private System.Windows.Forms.ToolStripButton toolStripCornerView270;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripFrontView;
        private System.Windows.Forms.ToolStripButton toolStripRightView;
        private System.Windows.Forms.ToolStripButton toolStripBackView;
        private System.Windows.Forms.ToolStripButton toolStripLeftView;
        private System.Windows.Forms.ToolStripButton toolStripTopView;
        private System.Windows.Forms.Button btSelectSolution;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripShowImages;
    }
}