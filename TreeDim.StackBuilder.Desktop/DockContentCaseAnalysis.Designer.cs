namespace TreeDim.StackBuilder.Desktop
{
    partial class DockContentCaseAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentCaseAnalysis));
            this.toolStrip_view = new System.Windows.Forms.ToolStrip();
            this.toolStripCornerView0 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripFrontView = new System.Windows.Forms.ToolStripButton();
            this.toolStripBackView = new System.Windows.Forms.ToolStripButton();
            this.toolStripLeftView = new System.Windows.Forms.ToolStripButton();
            this.toolStripRightView = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTopView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripShowPallet = new System.Windows.Forms.ToolStripButton();
            this.btSelectSolution = new System.Windows.Forms.Button();
            this.trackBarAngleVert = new System.Windows.Forms.TrackBar();
            this.trackBarAngleHoriz = new System.Windows.Forms.TrackBar();
            this.gridSolutions = new SourceGrid.Grid();
            this.pictureBoxSolution = new System.Windows.Forms.PictureBox();
            this.pictureBoxPalletSolution = new System.Windows.Forms.PictureBox();
            this.toolStrip_view.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleVert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleHoriz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalletSolution)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip_view
            // 
            this.toolStrip_view.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCornerView0,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripFrontView,
            this.toolStripBackView,
            this.toolStripLeftView,
            this.toolStripRightView,
            this.toolStripButtonTopView,
            this.toolStripSeparator2,
            this.toolStripShowPallet});
            resources.ApplyResources(this.toolStrip_view, "toolStrip_view");
            this.toolStrip_view.Name = "toolStrip_view";
            // 
            // toolStripCornerView0
            // 
            this.toolStripCornerView0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCornerView0.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View0;
            resources.ApplyResources(this.toolStripCornerView0, "toolStripCornerView0");
            this.toolStripCornerView0.Name = "toolStripCornerView0";
            this.toolStripCornerView0.Click += new System.EventHandler(this.onViewCorner_0);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View90;
            resources.ApplyResources(this.toolStripButton2, "toolStripButton2");
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.onViewCorner_90);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View180;
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.onViewCorner_180);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View270;
            resources.ApplyResources(this.toolStripButton4, "toolStripButton4");
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.onViewCorner_270);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripFrontView
            // 
            this.toolStripFrontView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFrontView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_1;
            resources.ApplyResources(this.toolStripFrontView, "toolStripFrontView");
            this.toolStripFrontView.Name = "toolStripFrontView";
            this.toolStripFrontView.Click += new System.EventHandler(this.onViewSideFront);
            // 
            // toolStripBackView
            // 
            this.toolStripBackView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBackView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_2;
            resources.ApplyResources(this.toolStripBackView, "toolStripBackView");
            this.toolStripBackView.Name = "toolStripBackView";
            this.toolStripBackView.Click += new System.EventHandler(this.onViewSideRight);
            // 
            // toolStripLeftView
            // 
            this.toolStripLeftView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLeftView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_3;
            resources.ApplyResources(this.toolStripLeftView, "toolStripLeftView");
            this.toolStripLeftView.Name = "toolStripLeftView";
            this.toolStripLeftView.Click += new System.EventHandler(this.onViewCorner_180);
            // 
            // toolStripRightView
            // 
            this.toolStripRightView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRightView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_4;
            resources.ApplyResources(this.toolStripRightView, "toolStripRightView");
            this.toolStripRightView.Name = "toolStripRightView";
            this.toolStripRightView.Click += new System.EventHandler(this.onViewSideRear);
            // 
            // toolStripButtonTopView
            // 
            this.toolStripButtonTopView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTopView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_Top;
            resources.ApplyResources(this.toolStripButtonTopView, "toolStripButtonTopView");
            this.toolStripButtonTopView.Name = "toolStripButtonTopView";
            this.toolStripButtonTopView.Click += new System.EventHandler(this.onViewTop);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripShowPallet
            // 
            this.toolStripShowPallet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripShowPallet.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.Analysis;
            resources.ApplyResources(this.toolStripShowPallet, "toolStripShowPallet");
            this.toolStripShowPallet.Name = "toolStripShowPallet";
            this.toolStripShowPallet.Click += new System.EventHandler(this.toolStripShowPallet_Click);
            // 
            // btSelectSolution
            // 
            resources.ApplyResources(this.btSelectSolution, "btSelectSolution");
            this.btSelectSolution.Name = "btSelectSolution";
            this.btSelectSolution.UseVisualStyleBackColor = true;
            // 
            // trackBarAngleVert
            // 
            resources.ApplyResources(this.trackBarAngleVert, "trackBarAngleVert");
            this.trackBarAngleVert.LargeChange = 15;
            this.trackBarAngleVert.Maximum = 90;
            this.trackBarAngleVert.Name = "trackBarAngleVert";
            this.trackBarAngleVert.TickFrequency = 15;
            this.trackBarAngleVert.Value = 45;
            this.trackBarAngleVert.ValueChanged += new System.EventHandler(this.onAngleVertChanged);
            // 
            // trackBarAngleHoriz
            // 
            resources.ApplyResources(this.trackBarAngleHoriz, "trackBarAngleHoriz");
            this.trackBarAngleHoriz.LargeChange = 45;
            this.trackBarAngleHoriz.Maximum = 360;
            this.trackBarAngleHoriz.Name = "trackBarAngleHoriz";
            this.trackBarAngleHoriz.SmallChange = 45;
            this.trackBarAngleHoriz.TickFrequency = 90;
            this.trackBarAngleHoriz.Value = 45;
            this.trackBarAngleHoriz.ValueChanged += new System.EventHandler(this.onAngleHorizChanged);
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
            // pictureBoxSolution
            // 
            resources.ApplyResources(this.pictureBoxSolution, "pictureBoxSolution");
            this.pictureBoxSolution.Name = "pictureBoxSolution";
            this.pictureBoxSolution.TabStop = false;
            this.pictureBoxSolution.SizeChanged += new System.EventHandler(this.pictureBoxSolution_SizeChanged);
            // 
            // pictureBoxPalletSolution
            // 
            resources.ApplyResources(this.pictureBoxPalletSolution, "pictureBoxPalletSolution");
            this.pictureBoxPalletSolution.Name = "pictureBoxPalletSolution";
            this.pictureBoxPalletSolution.TabStop = false;
            // 
            // DockContentCaseAnalysis
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridSolutions);
            this.Controls.Add(this.btSelectSolution);
            this.Controls.Add(this.trackBarAngleVert);
            this.Controls.Add(this.trackBarAngleHoriz);
            this.Controls.Add(this.toolStrip_view);
            this.Controls.Add(this.pictureBoxSolution);
            this.Controls.Add(this.pictureBoxPalletSolution);
            this.Name = "DockContentCaseAnalysis";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.DockContentCaseAnalysis_Load);
            this.toolStrip_view.ResumeLayout(false);
            this.toolStrip_view.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleVert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleHoriz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPalletSolution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_view;
        private System.Windows.Forms.ToolStripButton toolStripCornerView0;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripFrontView;
        private System.Windows.Forms.ToolStripButton toolStripBackView;
        private System.Windows.Forms.ToolStripButton toolStripLeftView;
        private System.Windows.Forms.ToolStripButton toolStripRightView;
        private System.Windows.Forms.ToolStripButton toolStripButtonTopView;
        private System.Windows.Forms.Button btSelectSolution;
        private System.Windows.Forms.TrackBar trackBarAngleVert;
        private System.Windows.Forms.TrackBar trackBarAngleHoriz;
        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripShowPallet;
        private System.Windows.Forms.PictureBox pictureBoxSolution;
        private System.Windows.Forms.PictureBox pictureBoxPalletSolution;
    }
}