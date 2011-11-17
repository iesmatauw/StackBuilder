namespace TreeDim.StackBuilder.Desktop
{
    partial class DockContentTruckAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentTruckAnalysis));
            this.splitContainerHoriz = new System.Windows.Forms.SplitContainer();
            this.btSelectSolution = new System.Windows.Forms.Button();
            this.pictureBoxTruckSolution = new System.Windows.Forms.PictureBox();
            this.gridSolutions = new SourceGrid.Grid();
            this.toolStripViews = new System.Windows.Forms.ToolStrip();
            this.toolStripCornerView0 = new System.Windows.Forms.ToolStripButton();
            this.toolStripCornerView1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripCornerView2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripCornerView3 = new System.Windows.Forms.ToolStripButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTruckSolution)).BeginInit();
            this.toolStripViews.SuspendLayout();
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
            this.splitContainerHoriz.Panel1.Controls.Add(this.btSelectSolution);
            this.splitContainerHoriz.Panel1.Controls.Add(this.pictureBoxTruckSolution);
            // 
            // splitContainerHoriz.Panel2
            // 
            resources.ApplyResources(this.splitContainerHoriz.Panel2, "splitContainerHoriz.Panel2");
            this.splitContainerHoriz.Panel2.Controls.Add(this.gridSolutions);
            // 
            // btSelectSolution
            // 
            resources.ApplyResources(this.btSelectSolution, "btSelectSolution");
            this.btSelectSolution.Name = "btSelectSolution";
            this.btSelectSolution.UseVisualStyleBackColor = true;
            // 
            // pictureBoxTruckSolution
            // 
            resources.ApplyResources(this.pictureBoxTruckSolution, "pictureBoxTruckSolution");
            this.pictureBoxTruckSolution.Name = "pictureBoxTruckSolution";
            this.pictureBoxTruckSolution.TabStop = false;
            this.pictureBoxTruckSolution.SizeChanged += new System.EventHandler(this.pictureBoxSolution_SizeChanged);
            // 
            // gridSolutions
            // 
            resources.ApplyResources(this.gridSolutions, "gridSolutions");
            this.gridSolutions.EnableSort = true;
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // toolStripViews
            // 
            resources.ApplyResources(this.toolStripViews, "toolStripViews");
            this.toolStripViews.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCornerView0,
            this.toolStripCornerView1,
            this.toolStripCornerView2,
            this.toolStripCornerView3,
            this.toolStripSeparator1,
            this.toolStripFrontView,
            this.toolStripRightView,
            this.toolStripBackView,
            this.toolStripLeftView,
            this.toolStripTopView,
            this.toolStripSeparator2,
            this.toolStripShowImages});
            this.toolStripViews.Name = "toolStripViews";
            // 
            // toolStripCornerView0
            // 
            resources.ApplyResources(this.toolStripCornerView0, "toolStripCornerView0");
            this.toolStripCornerView0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCornerView0.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View0;
            this.toolStripCornerView0.Name = "toolStripCornerView0";
            this.toolStripCornerView0.Click += new System.EventHandler(this.onViewCorner_0);
            // 
            // toolStripCornerView1
            // 
            resources.ApplyResources(this.toolStripCornerView1, "toolStripCornerView1");
            this.toolStripCornerView1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCornerView1.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View90;
            this.toolStripCornerView1.Name = "toolStripCornerView1";
            this.toolStripCornerView1.Click += new System.EventHandler(this.onViewCorner_90);
            // 
            // toolStripCornerView2
            // 
            resources.ApplyResources(this.toolStripCornerView2, "toolStripCornerView2");
            this.toolStripCornerView2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCornerView2.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View180;
            this.toolStripCornerView2.Name = "toolStripCornerView2";
            this.toolStripCornerView2.Click += new System.EventHandler(this.onViewCorner_180);
            // 
            // toolStripCornerView3
            // 
            resources.ApplyResources(this.toolStripCornerView3, "toolStripCornerView3");
            this.toolStripCornerView3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCornerView3.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View270;
            this.toolStripCornerView3.Name = "toolStripCornerView3";
            this.toolStripCornerView3.Click += new System.EventHandler(this.onViewCorner_270);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripFrontView
            // 
            resources.ApplyResources(this.toolStripFrontView, "toolStripFrontView");
            this.toolStripFrontView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFrontView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_1;
            this.toolStripFrontView.Name = "toolStripFrontView";
            this.toolStripFrontView.Click += new System.EventHandler(this.onViewSideFront);
            // 
            // toolStripRightView
            // 
            resources.ApplyResources(this.toolStripRightView, "toolStripRightView");
            this.toolStripRightView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRightView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_2;
            this.toolStripRightView.Name = "toolStripRightView";
            this.toolStripRightView.Click += new System.EventHandler(this.onViewSideRight);
            // 
            // toolStripBackView
            // 
            resources.ApplyResources(this.toolStripBackView, "toolStripBackView");
            this.toolStripBackView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBackView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_3;
            this.toolStripBackView.Name = "toolStripBackView";
            this.toolStripBackView.Click += new System.EventHandler(this.onViewSideRear);
            // 
            // toolStripLeftView
            // 
            resources.ApplyResources(this.toolStripLeftView, "toolStripLeftView");
            this.toolStripLeftView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLeftView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_4;
            this.toolStripLeftView.Name = "toolStripLeftView";
            this.toolStripLeftView.Click += new System.EventHandler(this.onViewSideLeft);
            // 
            // toolStripTopView
            // 
            resources.ApplyResources(this.toolStripTopView, "toolStripTopView");
            this.toolStripTopView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTopView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_Top;
            this.toolStripTopView.Name = "toolStripTopView";
            this.toolStripTopView.Click += new System.EventHandler(this.onViewTop);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // toolStripShowImages
            // 
            resources.ApplyResources(this.toolStripShowImages, "toolStripShowImages");
            this.toolStripShowImages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripShowImages.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.Image;
            this.toolStripShowImages.Name = "toolStripShowImages";
            this.toolStripShowImages.Click += new System.EventHandler(this.toolStripButtonShowImages_Click);
            // 
            // DockContentTruckAnalysis
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerHoriz);
            this.Controls.Add(this.toolStripViews);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.HideOnClose = true;
            this.Name = "DockContentTruckAnalysis";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.ShowInTaskbar = false;
            this.splitContainerHoriz.Panel1.ResumeLayout(false);
            this.splitContainerHoriz.Panel2.ResumeLayout(false);
            this.splitContainerHoriz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTruckSolution)).EndInit();
            this.toolStripViews.ResumeLayout(false);
            this.toolStripViews.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripViews;
        private System.Windows.Forms.ToolStripButton toolStripCornerView0;
        private System.Windows.Forms.ToolStripButton toolStripCornerView1;
        private System.Windows.Forms.ToolStripButton toolStripCornerView2;
        private System.Windows.Forms.ToolStripButton toolStripCornerView3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripFrontView;
        private System.Windows.Forms.ToolStripButton toolStripRightView;
        private System.Windows.Forms.ToolStripButton toolStripBackView;
        private System.Windows.Forms.ToolStripButton toolStripLeftView;
        private System.Windows.Forms.ToolStripButton toolStripTopView;
        private System.Windows.Forms.SplitContainer splitContainerHoriz;
        private System.Windows.Forms.PictureBox pictureBoxTruckSolution;
        private System.Windows.Forms.Button btSelectSolution;
        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripShowImages;
    }
}