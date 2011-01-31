namespace TreeDim.StackBuilder.Desktop
{
    partial class FormEditBitmaps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditBitmaps));
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.labelFace = new System.Windows.Forms.Label();
            this.cbFace = new System.Windows.Forms.ComboBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.trackBarHorizAngle = new System.Windows.Forms.TrackBar();
            this.listBoxTextures = new TreeDim.StackBuilder.Desktop.ListBoxImages();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudPositionX = new System.Windows.Forms.NumericUpDown();
            this.nudPositionY = new System.Windows.Forms.NumericUpDown();
            this.nudSizeX = new System.Windows.Forms.NumericUpDown();
            this.nudSizeY = new System.Windows.Forms.NumericUpDown();
            this.nudAngle = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bnMoveUp = new System.Windows.Forms.Button();
            this.bnMoveDown = new System.Windows.Forms.Button();
            this.bnAdd = new System.Windows.Forms.Button();
            this.bnRemove = new System.Windows.Forms.Button();
            this.openImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // bnOK
            // 
            resources.ApplyResources(this.bnOK, "bnOK");
            this.bnOK.Name = "bnOK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // labelFace
            // 
            resources.ApplyResources(this.labelFace, "labelFace");
            this.labelFace.Name = "labelFace";
            // 
            // cbFace
            // 
            this.cbFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFace.FormattingEnabled = true;
            this.cbFace.Items.AddRange(new object[] {
            resources.GetString("cbFace.Items"),
            resources.GetString("cbFace.Items1"),
            resources.GetString("cbFace.Items2"),
            resources.GetString("cbFace.Items3"),
            resources.GetString("cbFace.Items4"),
            resources.GetString("cbFace.Items5")});
            resources.ApplyResources(this.cbFace, "cbFace");
            this.cbFace.Name = "cbFace";
            this.cbFace.Click += new System.EventHandler(this.onSelectedFaceChanged);
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // trackBarHorizAngle
            // 
            this.trackBarHorizAngle.LargeChange = 90;
            resources.ApplyResources(this.trackBarHorizAngle, "trackBarHorizAngle");
            this.trackBarHorizAngle.Maximum = 360;
            this.trackBarHorizAngle.Name = "trackBarHorizAngle";
            this.trackBarHorizAngle.TickFrequency = 90;
            this.trackBarHorizAngle.ValueChanged += new System.EventHandler(this.onHorizAngleChanged);
            // 
            // listBoxTextures
            // 
            this.listBoxTextures.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxTextures.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxTextures, "listBoxTextures");
            this.listBoxTextures.Name = "listBoxTextures";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // nudPositionX
            // 
            resources.ApplyResources(this.nudPositionX, "nudPositionX");
            this.nudPositionX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPositionX.Name = "nudPositionX";
            // 
            // nudPositionY
            // 
            resources.ApplyResources(this.nudPositionY, "nudPositionY");
            this.nudPositionY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPositionY.Name = "nudPositionY";
            // 
            // nudSizeX
            // 
            resources.ApplyResources(this.nudSizeX, "nudSizeX");
            this.nudSizeX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSizeX.Name = "nudSizeX";
            // 
            // nudSizeY
            // 
            resources.ApplyResources(this.nudSizeY, "nudSizeY");
            this.nudSizeY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSizeY.Name = "nudSizeY";
            // 
            // nudAngle
            // 
            resources.ApplyResources(this.nudAngle, "nudAngle");
            this.nudAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAngle.Name = "nudAngle";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // bnMoveUp
            // 
            resources.ApplyResources(this.bnMoveUp, "bnMoveUp");
            this.bnMoveUp.Name = "bnMoveUp";
            this.bnMoveUp.UseVisualStyleBackColor = true;
            this.bnMoveUp.Click += new System.EventHandler(this.bnMoveUp_Click);
            // 
            // bnMoveDown
            // 
            resources.ApplyResources(this.bnMoveDown, "bnMoveDown");
            this.bnMoveDown.Name = "bnMoveDown";
            this.bnMoveDown.UseVisualStyleBackColor = true;
            this.bnMoveDown.Click += new System.EventHandler(this.bnMoveDown_Click);
            // 
            // bnAdd
            // 
            resources.ApplyResources(this.bnAdd, "bnAdd");
            this.bnAdd.Name = "bnAdd";
            this.bnAdd.UseVisualStyleBackColor = true;
            this.bnAdd.Click += new System.EventHandler(this.bnAdd_Click);
            // 
            // bnRemove
            // 
            resources.ApplyResources(this.bnRemove, "bnRemove");
            this.bnRemove.Name = "bnRemove";
            this.bnRemove.UseVisualStyleBackColor = true;
            this.bnRemove.Click += new System.EventHandler(this.bnRemove_Click);
            // 
            // openImageFileDialog
            // 
            this.openImageFileDialog.AddExtension = false;
            this.openImageFileDialog.DefaultExt = "jpg";
            resources.ApplyResources(this.openImageFileDialog, "openImageFileDialog");
            // 
            // FormEditBitmaps
            // 
            this.AcceptButton = this.bnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.bnRemove);
            this.Controls.Add(this.bnAdd);
            this.Controls.Add(this.bnMoveDown);
            this.Controls.Add(this.bnMoveUp);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudAngle);
            this.Controls.Add(this.nudSizeY);
            this.Controls.Add(this.nudSizeX);
            this.Controls.Add(this.nudPositionY);
            this.Controls.Add(this.nudPositionX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxTextures);
            this.Controls.Add(this.trackBarHorizAngle);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.cbFace);
            this.Controls.Add(this.labelFace);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditBitmaps";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FormEditBitmaps_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditBitmaps_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label labelFace;
        private System.Windows.Forms.ComboBox cbFace;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar trackBarHorizAngle;
        private TreeDim.StackBuilder.Desktop.ListBoxImages listBoxTextures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudPositionX;
        private System.Windows.Forms.NumericUpDown nudPositionY;
        private System.Windows.Forms.NumericUpDown nudSizeX;
        private System.Windows.Forms.NumericUpDown nudSizeY;
        private System.Windows.Forms.NumericUpDown nudAngle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bnMoveUp;
        private System.Windows.Forms.Button bnMoveDown;
        private System.Windows.Forms.Button bnAdd;
        private System.Windows.Forms.Button bnRemove;
        private System.Windows.Forms.OpenFileDialog openImageFileDialog;
    }
}