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
            this.pictureBoxSolution = new System.Windows.Forms.PictureBox();
            this.trackBarAngleHoriz = new System.Windows.Forms.TrackBar();
            this.trackBarAngleVert = new System.Windows.Forms.TrackBar();
            this.gridSolutions = new SourceGrid.Grid();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.btSelectSolution = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleHoriz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleVert)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxSolution
            // 
            this.pictureBoxSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSolution.Location = new System.Drawing.Point(0, 28);
            this.pictureBoxSolution.Name = "pictureBoxSolution";
            this.pictureBoxSolution.Size = new System.Drawing.Size(593, 294);
            this.pictureBoxSolution.TabIndex = 2;
            this.pictureBoxSolution.TabStop = false;
            this.pictureBoxSolution.SizeChanged += new System.EventHandler(this.pictureBoxSolution_SizeChanged);
            // 
            // trackBarAngleHoriz
            // 
            this.trackBarAngleHoriz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarAngleHoriz.LargeChange = 45;
            this.trackBarAngleHoriz.Location = new System.Drawing.Point(0, 326);
            this.trackBarAngleHoriz.Margin = new System.Windows.Forms.Padding(1);
            this.trackBarAngleHoriz.Maximum = 360;
            this.trackBarAngleHoriz.Name = "trackBarAngleHoriz";
            this.trackBarAngleHoriz.Size = new System.Drawing.Size(296, 45);
            this.trackBarAngleHoriz.SmallChange = 45;
            this.trackBarAngleHoriz.TabIndex = 11;
            this.trackBarAngleHoriz.TickFrequency = 90;
            this.trackBarAngleHoriz.Value = 45;
            this.trackBarAngleHoriz.ValueChanged += new System.EventHandler(this.onAngleHorizChanged);
            // 
            // trackBarAngleVert
            // 
            this.trackBarAngleVert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarAngleVert.LargeChange = 15;
            this.trackBarAngleVert.Location = new System.Drawing.Point(297, 326);
            this.trackBarAngleVert.Margin = new System.Windows.Forms.Padding(1);
            this.trackBarAngleVert.Maximum = 90;
            this.trackBarAngleVert.Name = "trackBarAngleVert";
            this.trackBarAngleVert.Size = new System.Drawing.Size(187, 45);
            this.trackBarAngleVert.TabIndex = 12;
            this.trackBarAngleVert.TickFrequency = 15;
            this.trackBarAngleVert.Value = 45;
            this.trackBarAngleVert.ValueChanged += new System.EventHandler(this.onAngleVertChanged);
            // 
            // gridSolutions
            // 
            this.gridSolutions.AcceptsInputChar = false;
            this.gridSolutions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gridSolutions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridSolutions.EnableSort = false;
            this.gridSolutions.Location = new System.Drawing.Point(0, 360);
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridSolutions.Size = new System.Drawing.Size(593, 287);
            this.gridSolutions.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridSolutions.TabIndex = 13;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // toolStrip2
            // 
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
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(593, 25);
            this.toolStrip2.TabIndex = 14;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View0;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Corner view 0°";
            this.toolStripButton1.Click += new System.EventHandler(this.onViewCorner_0);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View90;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Corner view 90°";
            this.toolStripButton2.Click += new System.EventHandler(this.onViewCorner_90);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View180;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Corner view 180°";
            this.toolStripButton3.Click += new System.EventHandler(this.onViewCorner_180);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View270;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Corner view 270°";
            this.toolStripButton4.Click += new System.EventHandler(this.onViewCorner_270);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_1;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Front view";
            this.toolStripButton5.Click += new System.EventHandler(this.onViewSideFront);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_2;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Back view";
            this.toolStripButton6.Click += new System.EventHandler(this.onViewSideLeft);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_3;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Left view";
            this.toolStripButton7.Click += new System.EventHandler(this.onViewSideRear);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_4;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "Right view";
            this.toolStripButton8.Click += new System.EventHandler(this.onViewSideRight);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = global::TreeDim.StackBuilder.Desktop.Properties.Resources.View_Top;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton9.Text = "Top view";
            this.toolStripButton9.Click += new System.EventHandler(this.onViewTop);
            // 
            // btSelectSolution
            // 
            this.btSelectSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSelectSolution.Location = new System.Drawing.Point(488, 326);
            this.btSelectSolution.Name = "btSelectSolution";
            this.btSelectSolution.Size = new System.Drawing.Size(101, 30);
            this.btSelectSolution.TabIndex = 15;
            this.btSelectSolution.Text = "Select";
            this.btSelectSolution.UseVisualStyleBackColor = true;
            this.btSelectSolution.Click += new System.EventHandler(this.btSelectSolution_Click);
            // 
            // DockContentAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 647);
            this.Controls.Add(this.btSelectSolution);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.gridSolutions);
            this.Controls.Add(this.trackBarAngleVert);
            this.Controls.Add(this.trackBarAngleHoriz);
            this.Controls.Add(this.pictureBoxSolution);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Name = "DockContentAnalysis";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.Text = "DockContentAnalysis";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleHoriz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleVert)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
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