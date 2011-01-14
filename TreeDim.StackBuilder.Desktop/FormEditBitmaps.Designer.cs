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
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.labelFace = new System.Windows.Forms.Label();
            this.comboBoxFace = new System.Windows.Forms.ComboBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.trackBarHorizAngle = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // bnOK
            // 
            this.bnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOK.Location = new System.Drawing.Point(499, 7);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 0;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(499, 36);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 1;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // labelFace
            // 
            this.labelFace.AutoSize = true;
            this.labelFace.Location = new System.Drawing.Point(6, 9);
            this.labelFace.Name = "labelFace";
            this.labelFace.Size = new System.Drawing.Size(31, 13);
            this.labelFace.TabIndex = 2;
            this.labelFace.Text = "Face";
            // 
            // comboBoxFace
            // 
            this.comboBoxFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFace.FormattingEnabled = true;
            this.comboBoxFace.Items.AddRange(new object[] {
            "Rear",
            "Front",
            "Right",
            "Left",
            "Bottom",
            "Top"});
            this.comboBoxFace.Location = new System.Drawing.Point(80, 9);
            this.comboBoxFace.Name = "comboBoxFace";
            this.comboBoxFace.Size = new System.Drawing.Size(123, 21);
            this.comboBoxFace.TabIndex = 3;
            this.comboBoxFace.Click += new System.EventHandler(this.onSelectedFaceChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(364, 65);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(210, 234);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // trackBarHorizAngle
            // 
            this.trackBarHorizAngle.LargeChange = 90;
            this.trackBarHorizAngle.Location = new System.Drawing.Point(364, 306);
            this.trackBarHorizAngle.Maximum = 360;
            this.trackBarHorizAngle.Name = "trackBarHorizAngle";
            this.trackBarHorizAngle.Size = new System.Drawing.Size(210, 45);
            this.trackBarHorizAngle.TabIndex = 5;
            this.trackBarHorizAngle.TickFrequency = 90;
            // 
            // FormEditBitmaps
            // 
            this.AcceptButton = this.bnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.trackBarHorizAngle);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.comboBoxFace);
            this.Controls.Add(this.labelFace);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditBitmaps";
            this.ShowIcon = false;
            this.Text = "Edit face bitmaps...";
            this.Load += new System.EventHandler(this.FormEditBitmaps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label labelFace;
        private System.Windows.Forms.ComboBox comboBoxFace;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar trackBarHorizAngle;
    }
}