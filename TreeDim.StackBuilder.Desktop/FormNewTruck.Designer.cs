namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewTruck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewTruck));
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnOK = new System.Windows.Forms.Button();
            this.trackBarHorizAngle = new System.Windows.Forms.TrackBar();
            this.tbPalletProperties = new System.Windows.Forms.TextBox();
            this.cbTruck = new System.Windows.Forms.ComboBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.radioButtonTruck2 = new System.Windows.Forms.RadioButton();
            this.radioButtonTruck1 = new System.Windows.Forms.RadioButton();
            this.lbMm3 = new System.Windows.Forms.Label();
            this.lbMm2 = new System.Windows.Forms.Label();
            this.lbMm1 = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbColor = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudAdmissibleLoadWeight = new System.Windows.Forms.NumericUpDown();
            this.lbKg = new System.Windows.Forms.Label();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdmissibleLoadWeight)).BeginInit();
            this.statusStripDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnAccept
            // 
            resources.ApplyResources(this.bnOK, "bnAccept");
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Name = "bnAccept";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // trackBarHorizAngle
            // 
            resources.ApplyResources(this.trackBarHorizAngle, "trackBarHorizAngle");
            this.trackBarHorizAngle.Maximum = 360;
            this.trackBarHorizAngle.Name = "trackBarHorizAngle";
            this.trackBarHorizAngle.TickFrequency = 90;
            this.trackBarHorizAngle.Value = 45;
            this.trackBarHorizAngle.ValueChanged += new System.EventHandler(this.onHorizAngleChanged);
            // 
            // tbPalletProperties
            // 
            resources.ApplyResources(this.tbPalletProperties, "tbPalletProperties");
            this.tbPalletProperties.Name = "tbPalletProperties";
            this.tbPalletProperties.ReadOnly = true;
            // 
            // cbTruck
            // 
            resources.ApplyResources(this.cbTruck, "cbTruck");
            this.cbTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTruck.FormattingEnabled = true;
            this.cbTruck.Name = "cbTruck";
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            this.tbName.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // lbDescription
            // 
            resources.ApplyResources(this.lbDescription, "lbDescription");
            this.lbDescription.Name = "lbDescription";
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Name = "lbName";
            // 
            // radioButtonTruck2
            // 
            resources.ApplyResources(this.radioButtonTruck2, "radioButtonTruck2");
            this.radioButtonTruck2.Name = "radioButtonTruck2";
            this.radioButtonTruck2.TabStop = true;
            this.radioButtonTruck2.UseVisualStyleBackColor = true;
            // 
            // radioButtonTruck1
            // 
            resources.ApplyResources(this.radioButtonTruck1, "radioButtonTruck1");
            this.radioButtonTruck1.Name = "radioButtonTruck1";
            this.radioButtonTruck1.TabStop = true;
            this.radioButtonTruck1.UseVisualStyleBackColor = true;
            // 
            // lbMm3
            // 
            resources.ApplyResources(this.lbMm3, "lbMm3");
            this.lbMm3.Name = "lbMm3";
            // 
            // lbMm2
            // 
            resources.ApplyResources(this.lbMm2, "lbMm2");
            this.lbMm2.Name = "lbMm2";
            // 
            // lbMm1
            // 
            resources.ApplyResources(this.lbMm1, "lbMm1");
            this.lbMm1.Name = "lbMm1";
            // 
            // nudHeight
            // 
            resources.ApplyResources(this.nudHeight, "nudHeight");
            this.nudHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.ValueChanged += new System.EventHandler(this.onTruckPropertyChanged);
            // 
            // nudWidth
            // 
            resources.ApplyResources(this.nudWidth, "nudWidth");
            this.nudWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.ValueChanged += new System.EventHandler(this.onTruckPropertyChanged);
            // 
            // nudLength
            // 
            resources.ApplyResources(this.nudLength, "nudLength");
            this.nudLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudLength.Name = "nudLength";
            this.nudLength.ValueChanged += new System.EventHandler(this.onTruckPropertyChanged);
            // 
            // lbHeight
            // 
            resources.ApplyResources(this.lbHeight, "lbHeight");
            this.lbHeight.Name = "lbHeight";
            // 
            // lbWidth
            // 
            resources.ApplyResources(this.lbWidth, "lbWidth");
            this.lbWidth.Name = "lbWidth";
            // 
            // lbLength
            // 
            resources.ApplyResources(this.lbLength, "lbLength");
            this.lbLength.Name = "lbLength";
            // 
            // cbColor
            // 
            resources.ApplyResources(this.cbColor, "cbColor");
            this.cbColor.Color = System.Drawing.Color.Gold;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
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
            resources.GetString("cbColor.Items8"),
            resources.GetString("cbColor.Items9"),
            resources.GetString("cbColor.Items10"),
            resources.GetString("cbColor.Items11"),
            resources.GetString("cbColor.Items12"),
            resources.GetString("cbColor.Items13"),
            resources.GetString("cbColor.Items14"),
            resources.GetString("cbColor.Items15")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.onTruckPropertyChanged);
            // 
            // lbColor
            // 
            resources.ApplyResources(this.lbColor, "lbColor");
            this.lbColor.Name = "lbColor";
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // nudAdmissibleLoadWeight
            // 
            resources.ApplyResources(this.nudAdmissibleLoadWeight, "nudAdmissibleLoadWeight");
            this.nudAdmissibleLoadWeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudAdmissibleLoadWeight.Name = "nudAdmissibleLoadWeight";
            this.nudAdmissibleLoadWeight.ValueChanged += new System.EventHandler(this.onTruckPropertyChanged);
            // 
            // lbKg
            // 
            resources.ApplyResources(this.lbKg, "lbKg");
            this.lbKg.Name = "lbKg";
            // 
            // statusStripDef
            // 
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.Name = "statusStripDef";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            // 
            // FormNewTruck
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.lbKg);
            this.Controls.Add(this.nudAdmissibleLoadWeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.lbMm3);
            this.Controls.Add(this.lbMm2);
            this.Controls.Add(this.lbMm1);
            this.Controls.Add(this.nudHeight);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.nudLength);
            this.Controls.Add(this.lbHeight);
            this.Controls.Add(this.lbWidth);
            this.Controls.Add(this.lbLength);
            this.Controls.Add(this.tbPalletProperties);
            this.Controls.Add(this.cbTruck);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.radioButtonTruck2);
            this.Controls.Add(this.radioButtonTruck1);
            this.Controls.Add(this.trackBarHorizAngle);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewTruck";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormNewTruck_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewTruck_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdmissibleLoadWeight)).EndInit();
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.TrackBar trackBarHorizAngle;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox tbPalletProperties;
        private System.Windows.Forms.ComboBox cbTruck;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.RadioButton radioButtonTruck2;
        private System.Windows.Forms.RadioButton radioButtonTruck1;
        private System.Windows.Forms.Label lbMm3;
        private System.Windows.Forms.Label lbMm2;
        private System.Windows.Forms.Label lbMm1;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbLength;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudAdmissibleLoadWeight;
        private System.Windows.Forms.Label lbKg;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
    }
}