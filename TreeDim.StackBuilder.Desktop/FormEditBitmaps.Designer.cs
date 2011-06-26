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
            this.label1 = new System.Windows.Forms.Label();
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
            this.bnOK.AccessibleDescription = null;
            this.bnOK.AccessibleName = null;
            resources.ApplyResources(this.bnOK, "bnOK");
            this.bnOK.BackgroundImage = null;
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Font = null;
            this.bnOK.Name = "bnOK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.AccessibleDescription = null;
            this.bnCancel.AccessibleName = null;
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.BackgroundImage = null;
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Font = null;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // labelFace
            // 
            this.labelFace.AccessibleDescription = null;
            this.labelFace.AccessibleName = null;
            resources.ApplyResources(this.labelFace, "labelFace");
            this.labelFace.Font = null;
            this.labelFace.Name = "labelFace";
            // 
            // cbFace
            // 
            this.cbFace.AccessibleDescription = null;
            this.cbFace.AccessibleName = null;
            resources.ApplyResources(this.cbFace, "cbFace");
            this.cbFace.BackgroundImage = null;
            this.cbFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFace.Font = null;
            this.cbFace.FormattingEnabled = true;
            this.cbFace.Items.AddRange(new object[] {
            resources.GetString("cbFace.Items"),
            resources.GetString("cbFace.Items1"),
            resources.GetString("cbFace.Items2"),
            resources.GetString("cbFace.Items3"),
            resources.GetString("cbFace.Items4"),
            resources.GetString("cbFace.Items5")});
            this.cbFace.Name = "cbFace";
            this.cbFace.SelectedIndexChanged += new System.EventHandler(this.onSelectedFaceChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.AccessibleDescription = null;
            this.pictureBox.AccessibleName = null;
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.BackgroundImage = null;
            this.pictureBox.Font = null;
            this.pictureBox.ImageLocation = null;
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // trackBarHorizAngle
            // 
            this.trackBarHorizAngle.AccessibleDescription = null;
            this.trackBarHorizAngle.AccessibleName = null;
            resources.ApplyResources(this.trackBarHorizAngle, "trackBarHorizAngle");
            this.trackBarHorizAngle.BackgroundImage = null;
            this.trackBarHorizAngle.Font = null;
            this.trackBarHorizAngle.LargeChange = 90;
            this.trackBarHorizAngle.Maximum = 360;
            this.trackBarHorizAngle.Name = "trackBarHorizAngle";
            this.trackBarHorizAngle.TickFrequency = 90;
            this.trackBarHorizAngle.ValueChanged += new System.EventHandler(this.onHorizAngleChanged);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // lbOrigin
            // 
            this.lbOrigin.AccessibleDescription = null;
            this.lbOrigin.AccessibleName = null;
            resources.ApplyResources(this.lbOrigin, "lbOrigin");
            this.lbOrigin.Font = null;
            this.lbOrigin.Name = "lbOrigin";
            // 
            // lbSize
            // 
            this.lbSize.AccessibleDescription = null;
            this.lbSize.AccessibleName = null;
            resources.ApplyResources(this.lbSize, "lbSize");
            this.lbSize.Font = null;
            this.lbSize.Name = "lbSize";
            // 
            // lbAngle
            // 
            this.lbAngle.AccessibleDescription = null;
            this.lbAngle.AccessibleName = null;
            resources.ApplyResources(this.lbAngle, "lbAngle");
            this.lbAngle.Font = null;
            this.lbAngle.Name = "lbAngle";
            // 
            // nudPositionX
            // 
            this.nudPositionX.AccessibleDescription = null;
            this.nudPositionX.AccessibleName = null;
            resources.ApplyResources(this.nudPositionX, "nudPositionX");
            this.nudPositionX.Font = null;
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
            this.nudPositionY.AccessibleDescription = null;
            this.nudPositionY.AccessibleName = null;
            resources.ApplyResources(this.nudPositionY, "nudPositionY");
            this.nudPositionY.Font = null;
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
            this.nudSizeX.AccessibleDescription = null;
            this.nudSizeX.AccessibleName = null;
            resources.ApplyResources(this.nudSizeX, "nudSizeX");
            this.nudSizeX.Font = null;
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
            this.nudSizeY.AccessibleDescription = null;
            this.nudSizeY.AccessibleName = null;
            resources.ApplyResources(this.nudSizeY, "nudSizeY");
            this.nudSizeY.Font = null;
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
            this.nudAngle.AccessibleDescription = null;
            this.nudAngle.AccessibleName = null;
            resources.ApplyResources(this.nudAngle, "nudAngle");
            this.nudAngle.Font = null;
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
            this.lbUnitOriginX.AccessibleDescription = null;
            this.lbUnitOriginX.AccessibleName = null;
            resources.ApplyResources(this.lbUnitOriginX, "lbUnitOriginX");
            this.lbUnitOriginX.Font = null;
            this.lbUnitOriginX.Name = "lbUnitOriginX";
            // 
            // lbUnitSizeX
            // 
            this.lbUnitSizeX.AccessibleDescription = null;
            this.lbUnitSizeX.AccessibleName = null;
            resources.ApplyResources(this.lbUnitSizeX, "lbUnitSizeX");
            this.lbUnitSizeX.Font = null;
            this.lbUnitSizeX.Name = "lbUnitSizeX";
            // 
            // lbUnitAngle
            // 
            this.lbUnitAngle.AccessibleDescription = null;
            this.lbUnitAngle.AccessibleName = null;
            resources.ApplyResources(this.lbUnitAngle, "lbUnitAngle");
            this.lbUnitAngle.Font = null;
            this.lbUnitAngle.Name = "lbUnitAngle";
            // 
            // lbUnitOriginY
            // 
            this.lbUnitOriginY.AccessibleDescription = null;
            this.lbUnitOriginY.AccessibleName = null;
            resources.ApplyResources(this.lbUnitOriginY, "lbUnitOriginY");
            this.lbUnitOriginY.Font = null;
            this.lbUnitOriginY.Name = "lbUnitOriginY";
            // 
            // lbUnitSizeY
            // 
            this.lbUnitSizeY.AccessibleDescription = null;
            this.lbUnitSizeY.AccessibleName = null;
            resources.ApplyResources(this.lbUnitSizeY, "lbUnitSizeY");
            this.lbUnitSizeY.Font = null;
            this.lbUnitSizeY.Name = "lbUnitSizeY";
            // 
            // bnMoveUp
            // 
            this.bnMoveUp.AccessibleDescription = null;
            this.bnMoveUp.AccessibleName = null;
            resources.ApplyResources(this.bnMoveUp, "bnMoveUp");
            this.bnMoveUp.BackgroundImage = null;
            this.bnMoveUp.Font = null;
            this.bnMoveUp.Name = "bnMoveUp";
            this.bnMoveUp.UseVisualStyleBackColor = true;
            this.bnMoveUp.Click += new System.EventHandler(this.bnMoveUpDown_Click);
            // 
            // bnMoveDown
            // 
            this.bnMoveDown.AccessibleDescription = null;
            this.bnMoveDown.AccessibleName = null;
            resources.ApplyResources(this.bnMoveDown, "bnMoveDown");
            this.bnMoveDown.BackgroundImage = null;
            this.bnMoveDown.Font = null;
            this.bnMoveDown.Name = "bnMoveDown";
            this.bnMoveDown.UseVisualStyleBackColor = true;
            this.bnMoveDown.Click += new System.EventHandler(this.bnMoveUpDown_Click);
            // 
            // bnAdd
            // 
            this.bnAdd.AccessibleDescription = null;
            this.bnAdd.AccessibleName = null;
            resources.ApplyResources(this.bnAdd, "bnAdd");
            this.bnAdd.BackgroundImage = null;
            this.bnAdd.Font = null;
            this.bnAdd.Name = "bnAdd";
            this.bnAdd.UseVisualStyleBackColor = true;
            this.bnAdd.Click += new System.EventHandler(this.bnAdd_Click);
            // 
            // bnRemove
            // 
            this.bnRemove.AccessibleDescription = null;
            this.bnRemove.AccessibleName = null;
            resources.ApplyResources(this.bnRemove, "bnRemove");
            this.bnRemove.BackgroundImage = null;
            this.bnRemove.Font = null;
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
            this.listBoxTextures.AccessibleDescription = null;
            this.listBoxTextures.AccessibleName = null;
            resources.ApplyResources(this.listBoxTextures, "listBoxTextures");
            this.listBoxTextures.BackgroundImage = null;
            this.listBoxTextures.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxTextures.Font = null;
            this.listBoxTextures.Name = "listBoxTextures";
            this.listBoxTextures.SelectedIndexChanged += new System.EventHandler(this.onSelectedTextureChanged);
            // 
            // FormEditBitmaps
            // 
            this.AcceptButton = this.bnOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.bnCancel;
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxTextures);
            this.Controls.Add(this.trackBarHorizAngle);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.cbFace);
            this.Controls.Add(this.labelFace);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditBitmaps";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FormEditBitmaps_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditBitmaps_FormClosing);
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
        private System.Windows.Forms.Label label1;
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
    }
}