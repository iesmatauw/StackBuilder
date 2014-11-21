namespace TreeDim.StackBuilder.Desktop
{
    partial class DockContentHCylinderPalletAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentHCylinderPalletAnalysis));
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxSolution = new System.Windows.Forms.PictureBox();
            this.trackBarAngleHoriz = new System.Windows.Forms.TrackBar();
            this.btSelectSolution = new System.Windows.Forms.Button();
            this.trackBarAngleVert = new System.Windows.Forms.TrackBar();
            this.gridSolutions = new SourceGrid.Grid();
            this.toolStrip_view.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleHoriz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleVert)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip_view
            // 
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
            this.toolStripTopView});
            this.toolStrip_view.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_view.Name = "toolStrip_view";
            this.toolStrip_view.Size = new System.Drawing.Size(604, 25);
            this.toolStrip_view.TabIndex = 16;
            this.toolStrip_view.Text = "Views";
            // 
            // toolStripCornerView0
            // 
            this.toolStripCornerView0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCornerView0.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View0;
            this.toolStripCornerView0.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripCornerView0.Name = "toolStripCornerView0";
            this.toolStripCornerView0.Size = new System.Drawing.Size(23, 22);
            this.toolStripCornerView0.Text = "Corner view 0°";
            this.toolStripCornerView0.Click += new System.EventHandler(this.onViewCorner_0);
            // 
            // toolStripCornerView90
            // 
            this.toolStripCornerView90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCornerView90.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View90;
            this.toolStripCornerView90.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripCornerView90.Name = "toolStripCornerView90";
            this.toolStripCornerView90.Size = new System.Drawing.Size(23, 22);
            this.toolStripCornerView90.Text = "Corner view 90°";
            this.toolStripCornerView90.Click += new System.EventHandler(this.onViewCorner_90);
            // 
            // toolStripCornerView180
            // 
            this.toolStripCornerView180.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCornerView180.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View180;
            this.toolStripCornerView180.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripCornerView180.Name = "toolStripCornerView180";
            this.toolStripCornerView180.Size = new System.Drawing.Size(23, 22);
            this.toolStripCornerView180.Text = "Corner view 180°";
            this.toolStripCornerView180.Click += new System.EventHandler(this.onViewCorner_180);
            // 
            // toolStripCornerView270
            // 
            this.toolStripCornerView270.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCornerView270.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View270;
            this.toolStripCornerView270.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripCornerView270.Name = "toolStripCornerView270";
            this.toolStripCornerView270.Size = new System.Drawing.Size(23, 22);
            this.toolStripCornerView270.Text = "Corner view 270°";
            this.toolStripCornerView270.Click += new System.EventHandler(this.onViewCorner_270);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripFrontView
            // 
            this.toolStripFrontView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFrontView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_1;
            this.toolStripFrontView.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripFrontView.Name = "toolStripFrontView";
            this.toolStripFrontView.Size = new System.Drawing.Size(23, 22);
            this.toolStripFrontView.Text = "Front view";
            this.toolStripFrontView.Click += new System.EventHandler(this.onViewSideFront);
            // 
            // toolStripRightView
            // 
            this.toolStripRightView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRightView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_2;
            this.toolStripRightView.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripRightView.Name = "toolStripRightView";
            this.toolStripRightView.Size = new System.Drawing.Size(23, 22);
            this.toolStripRightView.Text = "Back view";
            this.toolStripRightView.ToolTipText = "Right view";
            this.toolStripRightView.Click += new System.EventHandler(this.onViewSideRight);
            // 
            // toolStripBackView
            // 
            this.toolStripBackView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBackView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_3;
            this.toolStripBackView.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripBackView.Name = "toolStripBackView";
            this.toolStripBackView.Size = new System.Drawing.Size(23, 22);
            this.toolStripBackView.Text = "Rear view";
            this.toolStripBackView.ToolTipText = "Back view";
            this.toolStripBackView.Click += new System.EventHandler(this.onViewSideRear);
            // 
            // toolStripLeftView
            // 
            this.toolStripLeftView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLeftView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_4;
            this.toolStripLeftView.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripLeftView.Name = "toolStripLeftView";
            this.toolStripLeftView.Size = new System.Drawing.Size(23, 22);
            this.toolStripLeftView.Text = "Right view";
            this.toolStripLeftView.ToolTipText = "Left view";
            this.toolStripLeftView.Click += new System.EventHandler(this.onViewSideLeft);
            // 
            // toolStripTopView
            // 
            this.toolStripTopView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTopView.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_Top;
            this.toolStripTopView.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripTopView.Name = "toolStripTopView";
            this.toolStripTopView.Size = new System.Drawing.Size(23, 22);
            this.toolStripTopView.Text = "Top view";
            this.toolStripTopView.Click += new System.EventHandler(this.onViewTop);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxSolution);
            this.splitContainer1.Panel1.Controls.Add(this.trackBarAngleHoriz);
            this.splitContainer1.Panel1.Controls.Add(this.btSelectSolution);
            this.splitContainer1.Panel1.Controls.Add(this.trackBarAngleVert);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridSolutions);
            this.splitContainer1.Size = new System.Drawing.Size(604, 627);
            this.splitContainer1.SplitterDistance = 508;
            this.splitContainer1.TabIndex = 17;
            // 
            // pictureBoxSolution
            // 
            this.pictureBoxSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSolution.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxSolution.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxSolution.Name = "pictureBoxSolution";
            this.pictureBoxSolution.Size = new System.Drawing.Size(598, 455);
            this.pictureBoxSolution.TabIndex = 17;
            this.pictureBoxSolution.TabStop = false;
            this.pictureBoxSolution.SizeChanged += new System.EventHandler(this.pictureBoxSolution_SizeChanged);
            // 
            // trackBarAngleHoriz
            // 
            this.trackBarAngleHoriz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarAngleHoriz.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBarAngleHoriz.LargeChange = 45;
            this.trackBarAngleHoriz.Location = new System.Drawing.Point(2, 463);
            this.trackBarAngleHoriz.Margin = new System.Windows.Forms.Padding(1);
            this.trackBarAngleHoriz.Maximum = 360;
            this.trackBarAngleHoriz.Name = "trackBarAngleHoriz";
            this.trackBarAngleHoriz.Size = new System.Drawing.Size(306, 45);
            this.trackBarAngleHoriz.SmallChange = 45;
            this.trackBarAngleHoriz.TabIndex = 20;
            this.trackBarAngleHoriz.TickFrequency = 90;
            this.trackBarAngleHoriz.Value = 225;
            this.trackBarAngleHoriz.ValueChanged += new System.EventHandler(this.onAngleHorizChanged);
            // 
            // btSelectSolution
            // 
            this.btSelectSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSelectSolution.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btSelectSolution.Location = new System.Drawing.Point(501, 463);
            this.btSelectSolution.Name = "btSelectSolution";
            this.btSelectSolution.Size = new System.Drawing.Size(101, 30);
            this.btSelectSolution.TabIndex = 22;
            this.btSelectSolution.Text = "Select";
            this.btSelectSolution.UseVisualStyleBackColor = true;
            this.btSelectSolution.Click += new System.EventHandler(this.btSelectSolution_Click);
            // 
            // trackBarAngleVert
            // 
            this.trackBarAngleVert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarAngleVert.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBarAngleVert.LargeChange = 15;
            this.trackBarAngleVert.Location = new System.Drawing.Point(310, 463);
            this.trackBarAngleVert.Margin = new System.Windows.Forms.Padding(1);
            this.trackBarAngleVert.Maximum = 90;
            this.trackBarAngleVert.Name = "trackBarAngleVert";
            this.trackBarAngleVert.Size = new System.Drawing.Size(187, 45);
            this.trackBarAngleVert.TabIndex = 21;
            this.trackBarAngleVert.TickFrequency = 15;
            this.trackBarAngleVert.Value = 45;
            this.trackBarAngleVert.ValueChanged += new System.EventHandler(this.onAngleVertChanged);
            // 
            // gridSolutions
            // 
            this.gridSolutions.AcceptsInputChar = false;
            this.gridSolutions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gridSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSolutions.EnableSort = false;
            this.gridSolutions.Location = new System.Drawing.Point(0, 0);
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridSolutions.Size = new System.Drawing.Size(604, 115);
            this.gridSolutions.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridSolutions.TabIndex = 15;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // DockContentHCylinderPalletAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 652);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip_view);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DockContentHCylinderPalletAnalysis";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.Text = "Cylinder/pallet analysis...";
            this.toolStrip_view.ResumeLayout(false);
            this.toolStrip_view.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleHoriz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleVert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBoxSolution;
        private System.Windows.Forms.TrackBar trackBarAngleHoriz;
        private System.Windows.Forms.Button btSelectSolution;
        private System.Windows.Forms.TrackBar trackBarAngleVert;
        private SourceGrid.Grid gridSolutions;

    }
}