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
            this.lbOrigin = new System.Windows.Forms.Label();
            this.lbSize = new System.Windows.Forms.Label();
            this.lbAngle = new System.Windows.Forms.Label();
            this.nudPositionX = new System.Windows.Forms.NumericUpDown();
            this.nudPositionY = new System.Windows.Forms.NumericUpDown();
            this.nudSizeX = new System.Windows.Forms.NumericUpDown();
            this.nudSizeY = new System.Windows.Forms.NumericUpDown();
            this.nudAngle = new System.Windows.Forms.NumericUpDown();
            this.lbUnitOriginX = new System.Windows.Forms.Label();
            this.lbUnitSizeX = new System.Windows.Forms.Label();
            this.lbUnitAngle = new System.Windows.Forms.Label();
            this.lbUnitOriginY = new System.Windows.Forms.Label();
            this.lbUnitSizeY = new System.Windows.Forms.Label();
            this.bnMoveUp = new System.Windows.Forms.Button();
            this.bnMoveDown = new System.Windows.Forms.Button();
            this.bnAdd = new System.Windows.Forms.Button();
            this.bnRemove = new System.Windows.Forms.Button();
            this.openImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listBoxTextures = new TreeDim.StackBuilder.Desktop.ListBoxImages();
            this.lbImage = new System.Windows.Forms.Label();
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
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            this.cbFace.SelectedIndexChanged += new System.EventHandler(this.onSelectedFaceChanged);
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // trackBarHorizAngle
            // 
            resources.ApplyResources(this.trackBarHorizAngle, "trackBarHorizAngle");
            this.trackBarHorizAngle.LargeChange = 90;
            this.trackBarHorizAngle.Maximum = 360;
            this.trackBarHorizAngle.Name = "trackBarHorizAngle";
            this.trackBarHorizAngle.TickFrequency = 90;
            this.trackBarHorizAngle.ValueChanged += new System.EventHandler(this.onHorizAngleChanged);
            // 
            // lbOrigin
            // 
            resources.ApplyResources(this.lbOrigin, "lbOrigin");
            this.lbOrigin.Name = "lbOrigin";
            // 
            // lbSize
            // 
            resources.ApplyResources(this.lbSize, "lbSize");
            this.lbSize.Name = "lbSize";
            // 
            // lbAngle
            // 
            resources.ApplyResources(this.lbAngle, "lbAngle");
            this.lbAngle.Name = "lbAngle";
            // 
            // nudPositionX
            // 
            resources.ApplyResources(this.nudPositionX, "nudPositionX");
            this.nudPositionX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPositionX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudPositionX.Name = "nudPositionX";
            this.nudPositionX.ValueChanged += new System.EventHandler(this.texturePosition_ValueChanged);
            // 
            // nudPositionY
            // 
            resources.ApplyResources(this.nudPositionY, "nudPositionY");
            this.nudPositionY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPositionY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudPositionY.Name = "nudPositionY";
            this.nudPositionY.ValueChanged += new System.EventHandler(this.texturePosition_ValueChanged);
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
            this.nudSizeX.ValueChanged += new System.EventHandler(this.texturePosition_ValueChanged);
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
            this.nudSizeY.ValueChanged += new System.EventHandler(this.texturePosition_ValueChanged);
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
            this.nudAngle.ValueChanged += new System.EventHandler(this.texturePosition_ValueChanged);
            // 
            // lbUnitOriginX
            // 
            resources.ApplyResources(this.lbUnitOriginX, "lbUnitOriginX");
            this.lbUnitOriginX.Name = "lbUnitOriginX";
            // 
            // lbUnitSizeX
            // 
            resources.ApplyResources(this.lbUnitSizeX, "lbUnitSizeX");
            this.lbUnitSizeX.Name = "lbUnitSizeX";
            // 
            // lbUnitAngle
            // 
            resources.ApplyResources(this.lbUnitAngle, "lbUnitAngle");
            this.lbUnitAngle.Name = "lbUnitAngle";
            // 
            // lbUnitOriginY
            // 
            resources.ApplyResources(this.lbUnitOriginY, "lbUnitOriginY");
            this.lbUnitOriginY.Name = "lbUnitOriginY";
            // 
            // lbUnitSizeY
            // 
            resources.ApplyResources(this.lbUnitSizeY, "lbUnitSizeY");
            this.lbUnitSizeY.Name = "lbUnitSizeY";
            // 
            // bnMoveUp
            // 
            resources.ApplyResources(this.bnMoveUp, "bnMoveUp");
            this.bnMoveUp.Name = "bnMoveUp";
            this.bnMoveUp.UseVisualStyleBackColor = true;
            this.bnMoveUp.Click += new System.EventHandler(this.bnMoveUpDown_Click);
            // 
            // bnMoveDown
            // 
            resources.ApplyResources(this.bnMoveDown, "bnMoveDown");
            this.bnMoveDown.Name = "bnMoveDown";
            this.bnMoveDown.UseVisualStyleBackColor = true;
            this.bnMoveDown.Click += new System.EventHandler(this.bnMoveUpDown_Click);
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
            // listBoxTextures
            // 
            this.listBoxTextures.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            resources.ApplyResources(this.listBoxTextures, "listBoxTextures");
            this.listBoxTextures.Name = "listBoxTextures";
            this.listBoxTextures.SelectedIndexChanged += new System.EventHandler(this.onSelectedTextureChanged);
            // 
            // lbImage
            // 
            resources.ApplyResources(this.lbImage, "lbImage");
            this.lbImage.Name = "lbImage";
            // 
            // FormEditBitmaps
            // 
            this.AcceptButton = this.bnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.lbImage);
            this.Controls.Add(this.bnRemove);
            this.Controls.Add(this.bnAdd);
            this.Controls.Add(this.bnMoveDown);
            this.Controls.Add(this.bnMoveUp);
            this.Controls.Add(this.lbUnitSizeY);
            this.Controls.Add(this.lbUnitOriginY);
            this.Controls.Add(this.lbUnitAngle);
            this.Controls.Add(this.lbUnitSizeX);
            this.Controls.Add(this.lbUnitOriginX);
            this.Controls.Add(this.nudAngle);
            this.Controls.Add(this.nudSizeY);
            this.Controls.Add(this.nudSizeX);
            this.Controls.Add(this.nudPositionY);
            this.Controls.Add(this.nudPositionX);
            this.Controls.Add(this.lbAngle);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.lbOrigin);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditBitmaps_FormClosing);
            this.Load += new System.EventHandler(this.FormEditBitmaps_Load);
            this.Resize += new System.EventHandler(this.FormEditBitmaps_Resize);
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
        private System.Windows.Forms.Label lbOrigin;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Label lbAngle;
        private System.Windows.Forms.NumericUpDown nudPositionX;
        private System.Windows.Forms.NumericUpDown nudPositionY;
        private System.Windows.Forms.NumericUpDown nudSizeX;
        private System.Windows.Forms.NumericUpDown nudSizeY;
        private System.Windows.Forms.NumericUpDown nudAngle;
        private System.Windows.Forms.Label lbUnitOriginX;
        private System.Windows.Forms.Label lbUnitSizeX;
        private System.Windows.Forms.Label lbUnitAngle;
        private System.Windows.Forms.Label lbUnitOriginY;
        private System.Windows.Forms.Label lbUnitSizeY;
        private System.Windows.Forms.Button bnMoveUp;
        private System.Windows.Forms.Button bnMoveDown;
        private System.Windows.Forms.Button bnAdd;
        private System.Windows.Forms.Button bnRemove;
        private System.Windows.Forms.OpenFileDialog openImageFileDialog;
        private System.Windows.Forms.Label lbImage;
    }
}