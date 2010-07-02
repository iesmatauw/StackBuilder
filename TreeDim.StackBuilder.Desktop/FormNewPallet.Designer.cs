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
            this.bnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnAccept.Location = new System.Drawing.Point(383, 13);
            this.bnAccept.Name = "bnAccept";
            this.bnAccept.Size = new System.Drawing.Size(75, 23);
            this.bnAccept.TabIndex = 0;
            this.bnAccept.Text = "&Ok";
            this.bnAccept.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(383, 42);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 1;
            this.bnCancel.Text = "&Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // radioButtonPallet1
            // 
            this.radioButtonPallet1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonPallet1.AutoSize = true;
            this.radioButtonPallet1.Location = new System.Drawing.Point(11, 252);
            this.radioButtonPallet1.Name = "radioButtonPallet1";
            this.radioButtonPallet1.Size = new System.Drawing.Size(149, 17);
            this.radioButtonPallet1.TabIndex = 3;
            this.radioButtonPallet1.TabStop = true;
            this.radioButtonPallet1.Text = "Insert pallet from database";
            this.radioButtonPallet1.UseVisualStyleBackColor = true;
            this.radioButtonPallet1.CheckedChanged += new System.EventHandler(this.onPalletInsertionModeChanged);
            // 
            // radioButtonPallet2
            // 
            this.radioButtonPallet2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonPallet2.AutoSize = true;
            this.radioButtonPallet2.Location = new System.Drawing.Point(11, 364);
            this.radioButtonPallet2.Name = "radioButtonPallet2";
            this.radioButtonPallet2.Size = new System.Drawing.Size(107, 17);
            this.radioButtonPallet2.TabIndex = 6;
            this.radioButtonPallet2.TabStop = true;
            this.radioButtonPallet2.Text = "Create new pallet";
            this.radioButtonPallet2.UseVisualStyleBackColor = true;
            this.radioButtonPallet2.CheckedChanged += new System.EventHandler(this.onPalletInsertionModeChanged);
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(11, 394);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 7;
            this.lbName.Text = "Name";
            // 
            // lbDescription
            // 
            this.lbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(11, 425);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(60, 13);
            this.lbDescription.TabIndex = 9;
            this.lbDescription.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbDescription.Location = new System.Drawing.Point(129, 422);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(329, 20);
            this.tbDescription.TabIndex = 10;
            this.tbDescription.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbName.Location = new System.Drawing.Point(129, 394);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(146, 20);
            this.tbName.TabIndex = 8;
            this.tbName.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // lbLength
            // 
            this.lbLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLength.AutoSize = true;
            this.lbLength.Location = new System.Drawing.Point(11, 495);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(40, 13);
            this.lbLength.TabIndex = 15;
            this.lbLength.Text = "Length";
            // 
            // lbWidth
            // 
            this.lbWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(11, 521);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(35, 13);
            this.lbWidth.TabIndex = 21;
            this.lbWidth.Text = "Width";
            // 
            // lbHeight
            // 
            this.lbHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(11, 547);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(38, 13);
            this.lbHeight.TabIndex = 24;
            this.lbHeight.Text = "Height";
            // 
            // nudLength
            // 
            this.nudLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudLength.Location = new System.Drawing.Point(129, 495);
            this.nudLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudLength.Name = "nudLength";
            this.nudLength.Size = new System.Drawing.Size(60, 20);
            this.nudLength.TabIndex = 16;
            this.nudLength.ValueChanged += new System.EventHandler(this.onPalletPropertyChanged);
            // 
            // nudWidth
            // 
            this.nudWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudWidth.Location = new System.Drawing.Point(129, 521);
            this.nudWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(60, 20);
            this.nudWidth.TabIndex = 22;
            this.nudWidth.ValueChanged += new System.EventHandler(this.onPalletPropertyChanged);
            // 
            // nudHeight
            // 
            this.nudHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudHeight.Location = new System.Drawing.Point(129, 547);
            this.nudHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(60, 20);
            this.nudHeight.TabIndex = 25;
            this.nudHeight.ValueChanged += new System.EventHandler(this.onPalletPropertyChanged);
            // 
            // lbWeight
            // 
            this.lbWeight.AutoSize = true;
            this.lbWeight.Location = new System.Drawing.Point(250, 496);
            this.lbWeight.Name = "lbWeight";
            this.lbWeight.Size = new System.Drawing.Size(41, 13);
            this.lbWeight.TabIndex = 18;
            this.lbWeight.Text = "Weight";
            // 
            // nudWeight
            // 
            this.nudWeight.Location = new System.Drawing.Point(331, 496);
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(60, 20);
            this.nudWeight.TabIndex = 19;
            // 
            // lbMm1
            // 
            this.lbMm1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMm1.AutoSize = true;
            this.lbMm1.Location = new System.Drawing.Point(202, 495);
            this.lbMm1.Name = "lbMm1";
            this.lbMm1.Size = new System.Drawing.Size(23, 13);
            this.lbMm1.TabIndex = 17;
            this.lbMm1.Text = "mm";
            // 
            // lbMm2
            // 
            this.lbMm2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMm2.AutoSize = true;
            this.lbMm2.Location = new System.Drawing.Point(202, 521);
            this.lbMm2.Name = "lbMm2";
            this.lbMm2.Size = new System.Drawing.Size(23, 13);
            this.lbMm2.TabIndex = 23;
            this.lbMm2.Text = "mm";
            // 
            // lbMm3
            // 
            this.lbMm3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMm3.AutoSize = true;
            this.lbMm3.Location = new System.Drawing.Point(202, 547);
            this.lbMm3.Name = "lbMm3";
            this.lbMm3.Size = new System.Drawing.Size(23, 13);
            this.lbMm3.TabIndex = 26;
            this.lbMm3.Text = "mm";
            // 
            // lbAdmissibleWeight
            // 
            this.lbAdmissibleWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbAdmissibleWeight.AutoSize = true;
            this.lbAdmissibleWeight.Location = new System.Drawing.Point(250, 579);
            this.lbAdmissibleWeight.Name = "lbAdmissibleWeight";
            this.lbAdmissibleWeight.Size = new System.Drawing.Size(79, 13);
            this.lbAdmissibleWeight.TabIndex = 30;
            this.lbAdmissibleWeight.Text = "Admissible load";
            // 
            // nudAdmissibleLoadWeight
            // 
            this.nudAdmissibleLoadWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudAdmissibleLoadWeight.Location = new System.Drawing.Point(331, 579);
            this.nudAdmissibleLoadWeight.Name = "nudAdmissibleLoadWeight";
            this.nudAdmissibleLoadWeight.Size = new System.Drawing.Size(60, 20);
            this.nudAdmissibleLoadWeight.TabIndex = 31;
            // 
            // lbKg1
            // 
            this.lbKg1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbKg1.AutoSize = true;
            this.lbKg1.Location = new System.Drawing.Point(398, 495);
            this.lbKg1.Name = "lbKg1";
            this.lbKg1.Size = new System.Drawing.Size(19, 13);
            this.lbKg1.TabIndex = 20;
            this.lbKg1.Text = "kg";
            // 
            // lbKg2
            // 
            this.lbKg2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbKg2.AutoSize = true;
            this.lbKg2.Location = new System.Drawing.Point(398, 579);
            this.lbKg2.Name = "lbKg2";
            this.lbKg2.Size = new System.Drawing.Size(19, 13);
            this.lbKg2.TabIndex = 32;
            this.lbKg2.Text = "kg";
            // 
            // cbPallet
            // 
            this.cbPallet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.FormattingEnabled = true;
            this.cbPallet.Location = new System.Drawing.Point(182, 253);
            this.cbPallet.Name = "cbPallet";
            this.cbPallet.Size = new System.Drawing.Size(185, 21);
            this.cbPallet.TabIndex = 4;
            // 
            // tbPalletProperties
            // 
            this.tbPalletProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPalletProperties.Location = new System.Drawing.Point(11, 280);
            this.tbPalletProperties.Multiline = true;
            this.tbPalletProperties.Name = "tbPalletProperties";
            this.tbPalletProperties.ReadOnly = true;
            this.tbPalletProperties.Size = new System.Drawing.Size(446, 78);
            this.tbPalletProperties.TabIndex = 5;
            // 
            // lbAdmissibleHeight
            // 
            this.lbAdmissibleHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbAdmissibleHeight.AutoSize = true;
            this.lbAdmissibleHeight.Location = new System.Drawing.Point(11, 579);
            this.lbAdmissibleHeight.Name = "lbAdmissibleHeight";
            this.lbAdmissibleHeight.Size = new System.Drawing.Size(111, 13);
            this.lbAdmissibleHeight.TabIndex = 27;
            this.lbAdmissibleHeight.Text = "Admissible load height";
            // 
            // nudAmissibleLoadHeight
            // 
            this.nudAmissibleLoadHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudAmissibleLoadHeight.Location = new System.Drawing.Point(129, 579);
            this.nudAmissibleLoadHeight.Name = "nudAmissibleLoadHeight";
            this.nudAmissibleLoadHeight.Size = new System.Drawing.Size(60, 20);
            this.nudAmissibleLoadHeight.TabIndex = 28;
            this.nudAmissibleLoadHeight.ValueChanged += new System.EventHandler(this.onPalletPropertyChanged);
            // 
            // lbMm4
            // 
            this.lbMm4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMm4.AutoSize = true;
            this.lbMm4.Location = new System.Drawing.Point(202, 579);
            this.lbMm4.Name = "lbMm4";
            this.lbMm4.Size = new System.Drawing.Size(23, 13);
            this.lbMm4.TabIndex = 29;
            this.lbMm4.Text = "mm";
            // 
            // lbType
            // 
            this.lbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(11, 452);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(31, 13);
            this.lbType.TabIndex = 11;
            this.lbType.Text = "Type";
            // 
            // cbType
            // 
            this.cbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(129, 452);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(146, 21);
            this.cbType.TabIndex = 12;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.onPalletPropertyChanged);
            // 
            // trackBarHorizAngle
            // 
            this.trackBarHorizAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBarHorizAngle.Location = new System.Drawing.Point(11, 197);
            this.trackBarHorizAngle.Maximum = 360;
            this.trackBarHorizAngle.Name = "trackBarHorizAngle";
            this.trackBarHorizAngle.Size = new System.Drawing.Size(356, 45);
            this.trackBarHorizAngle.TabIndex = 2;
            this.trackBarHorizAngle.TickFrequency = 90;
            this.trackBarHorizAngle.Value = 45;
            this.trackBarHorizAngle.ValueChanged += new System.EventHandler(this.onHorizAngleChanged);
            // 
            // lbColor
            // 
            this.lbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(341, 452);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(31, 13);
            this.lbColor.TabIndex = 13;
            this.lbColor.Text = "Color";
            // 
            // cbColor
            // 
            this.cbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbColor.Color = System.Drawing.Color.Gold;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.IntegralHeight = false;
            this.cbColor.ItemHeight = 16;
            this.cbColor.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color"});
            this.cbColor.Location = new System.Drawing.Point(378, 452);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(79, 22);
            this.cbColor.TabIndex = 14;
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.onPalletPropertyChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(11, 8);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(356, 183);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // FormNewPallet
            // 
            this.AcceptButton = this.bnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(470, 612);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewPallet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Create new Pallet...";
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