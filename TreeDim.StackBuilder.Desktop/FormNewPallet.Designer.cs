namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewPallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewPallet));
            this.bnAccept = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.radioButtonPallet1 = new System.Windows.Forms.RadioButton();
            this.radioButtonPallet2 = new System.Windows.Forms.RadioButton();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbLength = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbHeight = new System.Windows.Forms.Label();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.lbWeight = new System.Windows.Forms.Label();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.lbMm1 = new System.Windows.Forms.Label();
            this.lbMm2 = new System.Windows.Forms.Label();
            this.lbMm3 = new System.Windows.Forms.Label();
            this.lbAdmissibleWeight = new System.Windows.Forms.Label();
            this.nudAdmissibleLoadWeight = new System.Windows.Forms.NumericUpDown();
            this.lbKg1 = new System.Windows.Forms.Label();
            this.lbKg2 = new System.Windows.Forms.Label();
            this.cbPallet = new System.Windows.Forms.ComboBox();
            this.tbPalletProperties = new System.Windows.Forms.TextBox();
            this.lbAdmissibleHeight = new System.Windows.Forms.Label();
            this.nudAmissibleLoadHeight = new System.Windows.Forms.NumericUpDown();
            this.lbMm4 = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.trackBarHorizAngle = new System.Windows.Forms.TrackBar();
            this.lbColor = new System.Windows.Forms.Label();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdmissibleLoadWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmissibleLoadHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bnAccept
            // 
            this.bnAccept.AccessibleDescription = null;
            this.bnAccept.AccessibleName = null;
            resources.ApplyResources(this.bnAccept, "bnAccept");
            this.bnAccept.BackgroundImage = null;
            this.bnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnAccept.Font = null;
            this.bnAccept.Name = "bnAccept";
            this.bnAccept.UseVisualStyleBackColor = true;
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
            // radioButtonPallet1
            // 
            this.radioButtonPallet1.AccessibleDescription = null;
            this.radioButtonPallet1.AccessibleName = null;
            resources.ApplyResources(this.radioButtonPallet1, "radioButtonPallet1");
            this.radioButtonPallet1.BackgroundImage = null;
            this.radioButtonPallet1.Font = null;
            this.radioButtonPallet1.Name = "radioButtonPallet1";
            this.radioButtonPallet1.TabStop = true;
            this.radioButtonPallet1.UseVisualStyleBackColor = true;
            this.radioButtonPallet1.CheckedChanged += new System.EventHandler(this.onPalletInsertionModeChanged);
            // 
            // radioButtonPallet2
            // 
            this.radioButtonPallet2.AccessibleDescription = null;
            this.radioButtonPallet2.AccessibleName = null;
            resources.ApplyResources(this.radioButtonPallet2, "radioButtonPallet2");
            this.radioButtonPallet2.BackgroundImage = null;
            this.radioButtonPallet2.Font = null;
            this.radioButtonPallet2.Name = "radioButtonPallet2";
            this.radioButtonPallet2.TabStop = true;
            this.radioButtonPallet2.UseVisualStyleBackColor = true;
            this.radioButtonPallet2.CheckedChanged += new System.EventHandler(this.onPalletInsertionModeChanged);
            // 
            // lbName
            // 
            this.lbName.AccessibleDescription = null;
            this.lbName.AccessibleName = null;
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Font = null;
            this.lbName.Name = "lbName";
            // 
            // lbDescription
            // 
            this.lbDescription.AccessibleDescription = null;
            this.lbDescription.AccessibleName = null;
            resources.ApplyResources(this.lbDescription, "lbDescription");
            this.lbDescription.Font = null;
            this.lbDescription.Name = "lbDescription";
            // 
            // tbDescription
            // 
            this.tbDescription.AccessibleDescription = null;
            this.tbDescription.AccessibleName = null;
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.BackgroundImage = null;
            this.tbDescription.Font = null;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // tbName
            // 
            this.tbName.AccessibleDescription = null;
            this.tbName.AccessibleName = null;
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.BackgroundImage = null;
            this.tbName.Font = null;
            this.tbName.Name = "tbName";
            this.tbName.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // lbLength
            // 
            this.lbLength.AccessibleDescription = null;
            this.lbLength.AccessibleName = null;
            resources.ApplyResources(this.lbLength, "lbLength");
            this.lbLength.Font = null;
            this.lbLength.Name = "lbLength";
            // 
            // lbWidth
            // 
            this.lbWidth.AccessibleDescription = null;
            this.lbWidth.AccessibleName = null;
            resources.ApplyResources(this.lbWidth, "lbWidth");
            this.lbWidth.Font = null;
            this.lbWidth.Name = "lbWidth";
            // 
            // lbHeight
            // 
            this.lbHeight.AccessibleDescription = null;
            this.lbHeight.AccessibleName = null;
            resources.ApplyResources(this.lbHeight, "lbHeight");
            this.lbHeight.Font = null;
            this.lbHeight.Name = "lbHeight";
            // 
            // nudLength
            // 
            this.nudLength.AccessibleDescription = null;
            this.nudLength.AccessibleName = null;
            resources.ApplyResources(this.nudLength, "nudLength");
            this.nudLength.Font = null;
            this.nudLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudLength.Name = "nudLength";
            this.nudLength.ValueChanged += new System.EventHandler(this.onPalletPropertyChanged);
            // 
            // nudWidth
            // 
            this.nudWidth.AccessibleDescription = null;
            this.nudWidth.AccessibleName = null;
            resources.ApplyResources(this.nudWidth, "nudWidth");
            this.nudWidth.Font = null;
            this.nudWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.ValueChanged += new System.EventHandler(this.onPalletPropertyChanged);
            // 
            // nudHeight
            // 
            this.nudHeight.AccessibleDescription = null;
            this.nudHeight.AccessibleName = null;
            resources.ApplyResources(this.nudHeight, "nudHeight");
            this.nudHeight.Font = null;
            this.nudHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.ValueChanged += new System.EventHandler(this.onPalletPropertyChanged);
            // 
            // lbWeight
            // 
            this.lbWeight.AccessibleDescription = null;
            this.lbWeight.AccessibleName = null;
            resources.ApplyResources(this.lbWeight, "lbWeight");
            this.lbWeight.Font = null;
            this.lbWeight.Name = "lbWeight";
            // 
            // nudWeight
            // 
            this.nudWeight.AccessibleDescription = null;
            this.nudWeight.AccessibleName = null;
            resources.ApplyResources(this.nudWeight, "nudWeight");
            this.nudWeight.Font = null;
            this.nudWeight.Name = "nudWeight";
            // 
            // lbMm1
            // 
            this.lbMm1.AccessibleDescription = null;
            this.lbMm1.AccessibleName = null;
            resources.ApplyResources(this.lbMm1, "lbMm1");
            this.lbMm1.Font = null;
            this.lbMm1.Name = "lbMm1";
            // 
            // lbMm2
            // 
            this.lbMm2.AccessibleDescription = null;
            this.lbMm2.AccessibleName = null;
            resources.ApplyResources(this.lbMm2, "lbMm2");
            this.lbMm2.Font = null;
            this.lbMm2.Name = "lbMm2";
            // 
            // lbMm3
            // 
            this.lbMm3.AccessibleDescription = null;
            this.lbMm3.AccessibleName = null;
            resources.ApplyResources(this.lbMm3, "lbMm3");
            this.lbMm3.Font = null;
            this.lbMm3.Name = "lbMm3";
            // 
            // lbAdmissibleWeight
            // 
            this.lbAdmissibleWeight.AccessibleDescription = null;
            this.lbAdmissibleWeight.AccessibleName = null;
            resources.ApplyResources(this.lbAdmissibleWeight, "lbAdmissibleWeight");
            this.lbAdmissibleWeight.Font = null;
            this.lbAdmissibleWeight.Name = "lbAdmissibleWeight";
            // 
            // nudAdmissibleLoadWeight
            // 
            this.nudAdmissibleLoadWeight.AccessibleDescription = null;
            this.nudAdmissibleLoadWeight.AccessibleName = null;
            resources.ApplyResources(this.nudAdmissibleLoadWeight, "nudAdmissibleLoadWeight");
            this.nudAdmissibleLoadWeight.Font = null;
            this.nudAdmissibleLoadWeight.Name = "nudAdmissibleLoadWeight";
            // 
            // lbKg1
            // 
            this.lbKg1.AccessibleDescription = null;
            this.lbKg1.AccessibleName = null;
            resources.ApplyResources(this.lbKg1, "lbKg1");
            this.lbKg1.Font = null;
            this.lbKg1.Name = "lbKg1";
            // 
            // lbKg2
            // 
            this.lbKg2.AccessibleDescription = null;
            this.lbKg2.AccessibleName = null;
            resources.ApplyResources(this.lbKg2, "lbKg2");
            this.lbKg2.Font = null;
            this.lbKg2.Name = "lbKg2";
            // 
            // cbPallet
            // 
            this.cbPallet.AccessibleDescription = null;
            this.cbPallet.AccessibleName = null;
            resources.ApplyResources(this.cbPallet, "cbPallet");
            this.cbPallet.BackgroundImage = null;
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.Font = null;
            this.cbPallet.FormattingEnabled = true;
            this.cbPallet.Name = "cbPallet";
            // 
            // tbPalletProperties
            // 
            this.tbPalletProperties.AccessibleDescription = null;
            this.tbPalletProperties.AccessibleName = null;
            resources.ApplyResources(this.tbPalletProperties, "tbPalletProperties");
            this.tbPalletProperties.BackgroundImage = null;
            this.tbPalletProperties.Font = null;
            this.tbPalletProperties.Name = "tbPalletProperties";
            this.tbPalletProperties.ReadOnly = true;
            // 
            // lbAdmissibleHeight
            // 
            this.lbAdmissibleHeight.AccessibleDescription = null;
            this.lbAdmissibleHeight.AccessibleName = null;
            resources.ApplyResources(this.lbAdmissibleHeight, "lbAdmissibleHeight");
            this.lbAdmissibleHeight.Font = null;
            this.lbAdmissibleHeight.Name = "lbAdmissibleHeight";
            // 
            // nudAmissibleLoadHeight
            // 
            this.nudAmissibleLoadHeight.AccessibleDescription = null;
            this.nudAmissibleLoadHeight.AccessibleName = null;
            resources.ApplyResources(this.nudAmissibleLoadHeight, "nudAmissibleLoadHeight");
            this.nudAmissibleLoadHeight.Font = null;
            this.nudAmissibleLoadHeight.Name = "nudAmissibleLoadHeight";
            this.nudAmissibleLoadHeight.ValueChanged += new System.EventHandler(this.onPalletPropertyChanged);
            // 
            // lbMm4
            // 
            this.lbMm4.AccessibleDescription = null;
            this.lbMm4.AccessibleName = null;
            resources.ApplyResources(this.lbMm4, "lbMm4");
            this.lbMm4.Font = null;
            this.lbMm4.Name = "lbMm4";
            // 
            // lbType
            // 
            this.lbType.AccessibleDescription = null;
            this.lbType.AccessibleName = null;
            resources.ApplyResources(this.lbType, "lbType");
            this.lbType.Font = null;
            this.lbType.Name = "lbType";
            // 
            // cbType
            // 
            this.cbType.AccessibleDescription = null;
            this.cbType.AccessibleName = null;
            resources.ApplyResources(this.cbType, "cbType");
            this.cbType.BackgroundImage = null;
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.Font = null;
            this.cbType.FormattingEnabled = true;
            this.cbType.Name = "cbType";
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.onPalletPropertyChanged);
            // 
            // trackBarHorizAngle
            // 
            this.trackBarHorizAngle.AccessibleDescription = null;
            this.trackBarHorizAngle.AccessibleName = null;
            resources.ApplyResources(this.trackBarHorizAngle, "trackBarHorizAngle");
            this.trackBarHorizAngle.BackgroundImage = null;
            this.trackBarHorizAngle.Font = null;
            this.trackBarHorizAngle.Maximum = 360;
            this.trackBarHorizAngle.Name = "trackBarHorizAngle";
            this.trackBarHorizAngle.TickFrequency = 90;
            this.trackBarHorizAngle.Value = 45;
            this.trackBarHorizAngle.ValueChanged += new System.EventHandler(this.onHorizAngleChanged);
            // 
            // lbColor
            // 
            this.lbColor.AccessibleDescription = null;
            this.lbColor.AccessibleName = null;
            resources.ApplyResources(this.lbColor, "lbColor");
            this.lbColor.Font = null;
            this.lbColor.Name = "lbColor";
            // 
            // cbColor
            // 
            this.cbColor.AccessibleDescription = null;
            this.cbColor.AccessibleName = null;
            resources.ApplyResources(this.cbColor, "cbColor");
            this.cbColor.BackgroundImage = null;
            this.cbColor.Color = System.Drawing.Color.Gold;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
            this.cbColor.Font = null;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            resources.GetString("cbColor.Items"),
            resources.GetString("cbColor.Items1"),
            resources.GetString("cbColor.Items2"),
            resources.GetString("cbColor.Items3"),
            resources.GetString("cbColor.Items4"),
            resources.GetString("cbColor.Items5"),
            resources.GetString("cbColor.Items6"),
            resources.GetString("cbColor.Items7"),
            resources.GetString("cbColor.Items8")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.onPalletPropertyChanged);
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
            // FormNewPallet
            // 
            this.AcceptButton = this.bnAccept;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.trackBarHorizAngle);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.lbMm4);
            this.Controls.Add(this.nudAmissibleLoadHeight);
            this.Controls.Add(this.lbAdmissibleHeight);
            this.Controls.Add(this.tbPalletProperties);
            this.Controls.Add(this.cbPallet);
            this.Controls.Add(this.lbKg2);
            this.Controls.Add(this.lbKg1);
            this.Controls.Add(this.nudAdmissibleLoadWeight);
            this.Controls.Add(this.lbAdmissibleWeight);
            this.Controls.Add(this.lbMm3);
            this.Controls.Add(this.lbMm2);
            this.Controls.Add(this.lbMm1);
            this.Controls.Add(this.nudWeight);
            this.Controls.Add(this.lbWeight);
            this.Controls.Add(this.nudHeight);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.nudLength);
            this.Controls.Add(this.lbHeight);
            this.Controls.Add(this.lbWidth);
            this.Controls.Add(this.lbLength);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.radioButtonPallet2);
            this.Controls.Add(this.radioButtonPallet1);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnAccept);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewPallet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormNewPallet_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewPallet_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdmissibleLoadWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmissibleLoadHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnAccept;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.RadioButton radioButtonPallet1;
        private System.Windows.Forms.RadioButton radioButtonPallet2;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.NumericUpDown nudAdmissibleLoadWeight;
        private System.Windows.Forms.NumericUpDown nudAmissibleLoadHeight;
        private System.Windows.Forms.Label lbWeight;
        private System.Windows.Forms.Label lbMm1;
        private System.Windows.Forms.Label lbMm2;
        private System.Windows.Forms.Label lbMm3;
        private System.Windows.Forms.Label lbAdmissibleWeight;
        private System.Windows.Forms.Label lbKg1;
        private System.Windows.Forms.Label lbKg2;
        private System.Windows.Forms.ComboBox cbPallet;
        private System.Windows.Forms.TextBox tbPalletProperties;
        private System.Windows.Forms.Label lbAdmissibleHeight;
        private System.Windows.Forms.Label lbMm4;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.TrackBar trackBarHorizAngle;
        private System.Windows.Forms.Label lbColor;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
    }
}