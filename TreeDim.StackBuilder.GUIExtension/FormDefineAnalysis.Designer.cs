namespace TreeDim.StackBuilder.GUIExtension
{
    partial class FormDefineAnalysis
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
            this.nudCaseLength = new System.Windows.Forms.NumericUpDown();
            this.lbCaseLength = new System.Windows.Forms.Label();
            this.lbCaseWidth = new System.Windows.Forms.Label();
            this.nudCaseWidth = new System.Windows.Forms.NumericUpDown();
            this.lbCaseHeight = new System.Windows.Forms.Label();
            this.nudCaseHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.pbCaseX = new System.Windows.Forms.PictureBox();
            this.pbCaseY = new System.Windows.Forms.PictureBox();
            this.pbCaseZ = new System.Windows.Forms.PictureBox();
            this.chkX = new System.Windows.Forms.CheckBox();
            this.chkY = new System.Windows.Forms.CheckBox();
            this.chkZ = new System.Windows.Forms.CheckBox();
            this.gbCase = new System.Windows.Forms.GroupBox();
            this.bnRevertZ = new System.Windows.Forms.Button();
            this.bnRevertY = new System.Windows.Forms.Button();
            this.bnRevertX = new System.Windows.Forms.Button();
            this.gbPallet = new System.Windows.Forms.GroupBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.bnEditPalletList = new System.Windows.Forms.Button();
            this.lbPalletDescription = new System.Windows.Forms.Label();
            this.pbPallet = new System.Windows.Forms.PictureBox();
            this.cbPallet = new System.Windows.Forms.ComboBox();
            this.lbPallet = new System.Windows.Forms.Label();
            this.gbConstraints = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudMaxPalletWeight = new System.Windows.Forms.NumericUpDown();
            this.chkMaxPalletWeight = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMaxPalletHeight = new System.Windows.Forms.NumericUpDown();
            this.nudOverhangY = new System.Windows.Forms.NumericUpDown();
            this.nudOverhangX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lbOverhangWidth = new System.Windows.Forms.Label();
            this.lbOverhangLength = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbWeight = new System.Windows.Forms.Label();
            this.nudCaseWeight = new System.Windows.Forms.NumericUpDown();
            this.lbCaseWeight = new System.Windows.Forms.Label();
            this.bnCaseColors = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaseX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaseY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaseZ)).BeginInit();
            this.gbCase.SuspendLayout();
            this.gbPallet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPallet)).BeginInit();
            this.gbConstraints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPalletWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPalletHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // bnOK
            // 
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Location = new System.Drawing.Point(457, 10);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 0;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(456, 39);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 1;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // nudCaseLength
            // 
            this.nudCaseLength.DecimalPlaces = 1;
            this.nudCaseLength.Location = new System.Drawing.Point(73, 12);
            this.nudCaseLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCaseLength.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCaseLength.Name = "nudCaseLength";
            this.nudCaseLength.Size = new System.Drawing.Size(75, 20);
            this.nudCaseLength.TabIndex = 2;
            this.nudCaseLength.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lbCaseLength
            // 
            this.lbCaseLength.AutoSize = true;
            this.lbCaseLength.Location = new System.Drawing.Point(26, 16);
            this.lbCaseLength.Name = "lbCaseLength";
            this.lbCaseLength.Size = new System.Drawing.Size(40, 13);
            this.lbCaseLength.TabIndex = 3;
            this.lbCaseLength.Text = "Length";
            // 
            // lbCaseWidth
            // 
            this.lbCaseWidth.AutoSize = true;
            this.lbCaseWidth.Location = new System.Drawing.Point(177, 16);
            this.lbCaseWidth.Name = "lbCaseWidth";
            this.lbCaseWidth.Size = new System.Drawing.Size(35, 13);
            this.lbCaseWidth.TabIndex = 4;
            this.lbCaseWidth.Text = "Width";
            // 
            // nudCaseWidth
            // 
            this.nudCaseWidth.DecimalPlaces = 1;
            this.nudCaseWidth.Location = new System.Drawing.Point(218, 12);
            this.nudCaseWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCaseWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCaseWidth.Name = "nudCaseWidth";
            this.nudCaseWidth.Size = new System.Drawing.Size(72, 20);
            this.nudCaseWidth.TabIndex = 5;
            this.nudCaseWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lbCaseHeight
            // 
            this.lbCaseHeight.AutoSize = true;
            this.lbCaseHeight.Location = new System.Drawing.Point(318, 16);
            this.lbCaseHeight.Name = "lbCaseHeight";
            this.lbCaseHeight.Size = new System.Drawing.Size(38, 13);
            this.lbCaseHeight.TabIndex = 6;
            this.lbCaseHeight.Text = "Height";
            // 
            // nudCaseHeight
            // 
            this.nudCaseHeight.DecimalPlaces = 1;
            this.nudCaseHeight.Location = new System.Drawing.Point(362, 12);
            this.nudCaseHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCaseHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCaseHeight.Name = "nudCaseHeight";
            this.nudCaseHeight.Size = new System.Drawing.Size(72, 20);
            this.nudCaseHeight.TabIndex = 7;
            this.nudCaseHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Allowed orientations";
            // 
            // pbCaseX
            // 
            this.pbCaseX.Location = new System.Drawing.Point(30, 84);
            this.pbCaseX.Name = "pbCaseX";
            this.pbCaseX.Size = new System.Drawing.Size(118, 90);
            this.pbCaseX.TabIndex = 9;
            this.pbCaseX.TabStop = false;
            // 
            // pbCaseY
            // 
            this.pbCaseY.Location = new System.Drawing.Point(172, 84);
            this.pbCaseY.Name = "pbCaseY";
            this.pbCaseY.Size = new System.Drawing.Size(118, 90);
            this.pbCaseY.TabIndex = 10;
            this.pbCaseY.TabStop = false;
            // 
            // pbCaseZ
            // 
            this.pbCaseZ.Location = new System.Drawing.Point(317, 84);
            this.pbCaseZ.Name = "pbCaseZ";
            this.pbCaseZ.Size = new System.Drawing.Size(118, 90);
            this.pbCaseZ.TabIndex = 11;
            this.pbCaseZ.TabStop = false;
            // 
            // chkX
            // 
            this.chkX.AutoSize = true;
            this.chkX.Location = new System.Drawing.Point(30, 181);
            this.chkX.Name = "chkX";
            this.chkX.Size = new System.Drawing.Size(33, 17);
            this.chkX.TabIndex = 12;
            this.chkX.Text = "X";
            this.chkX.UseVisualStyleBackColor = true;
            // 
            // chkY
            // 
            this.chkY.AutoSize = true;
            this.chkY.Location = new System.Drawing.Point(172, 181);
            this.chkY.Name = "chkY";
            this.chkY.Size = new System.Drawing.Size(33, 17);
            this.chkY.TabIndex = 13;
            this.chkY.Text = "Y";
            this.chkY.UseVisualStyleBackColor = true;
            // 
            // chkZ
            // 
            this.chkZ.AutoSize = true;
            this.chkZ.Location = new System.Drawing.Point(317, 181);
            this.chkZ.Name = "chkZ";
            this.chkZ.Size = new System.Drawing.Size(33, 17);
            this.chkZ.TabIndex = 14;
            this.chkZ.Text = "Z";
            this.chkZ.UseVisualStyleBackColor = true;
            // 
            // gbCase
            // 
            this.gbCase.Controls.Add(this.bnCaseColors);
            this.gbCase.Controls.Add(this.lbCaseWeight);
            this.gbCase.Controls.Add(this.nudCaseWeight);
            this.gbCase.Controls.Add(this.lbWeight);
            this.gbCase.Controls.Add(this.bnRevertZ);
            this.gbCase.Controls.Add(this.pbCaseY);
            this.gbCase.Controls.Add(this.bnRevertY);
            this.gbCase.Controls.Add(this.nudCaseLength);
            this.gbCase.Controls.Add(this.bnRevertX);
            this.gbCase.Controls.Add(this.lbCaseLength);
            this.gbCase.Controls.Add(this.lbCaseWidth);
            this.gbCase.Controls.Add(this.chkZ);
            this.gbCase.Controls.Add(this.nudCaseWidth);
            this.gbCase.Controls.Add(this.chkY);
            this.gbCase.Controls.Add(this.lbCaseHeight);
            this.gbCase.Controls.Add(this.chkX);
            this.gbCase.Controls.Add(this.nudCaseHeight);
            this.gbCase.Controls.Add(this.pbCaseZ);
            this.gbCase.Controls.Add(this.label4);
            this.gbCase.Controls.Add(this.pbCaseX);
            this.gbCase.Location = new System.Drawing.Point(7, 4);
            this.gbCase.Name = "gbCase";
            this.gbCase.Size = new System.Drawing.Size(443, 206);
            this.gbCase.TabIndex = 15;
            this.gbCase.TabStop = false;
            this.gbCase.Text = "Case";
            // 
            // bnRevertZ
            // 
            this.bnRevertZ.Location = new System.Drawing.Point(378, 180);
            this.bnRevertZ.Name = "bnRevertZ";
            this.bnRevertZ.Size = new System.Drawing.Size(57, 19);
            this.bnRevertZ.TabIndex = 18;
            this.bnRevertZ.Text = "Revert";
            this.bnRevertZ.UseVisualStyleBackColor = true;
            // 
            // bnRevertY
            // 
            this.bnRevertY.Location = new System.Drawing.Point(233, 180);
            this.bnRevertY.Name = "bnRevertY";
            this.bnRevertY.Size = new System.Drawing.Size(57, 19);
            this.bnRevertY.TabIndex = 17;
            this.bnRevertY.Text = "Revert";
            this.bnRevertY.UseVisualStyleBackColor = true;
            // 
            // bnRevertX
            // 
            this.bnRevertX.Location = new System.Drawing.Point(90, 180);
            this.bnRevertX.Name = "bnRevertX";
            this.bnRevertX.Size = new System.Drawing.Size(57, 19);
            this.bnRevertX.TabIndex = 16;
            this.bnRevertX.Text = "Revert";
            this.bnRevertX.UseVisualStyleBackColor = true;
            this.bnRevertX.Click += new System.EventHandler(this.bnRevertX_Click);
            // 
            // gbPallet
            // 
            this.gbPallet.Controls.Add(this.lbDescription);
            this.gbPallet.Controls.Add(this.bnEditPalletList);
            this.gbPallet.Controls.Add(this.lbPalletDescription);
            this.gbPallet.Controls.Add(this.pbPallet);
            this.gbPallet.Controls.Add(this.cbPallet);
            this.gbPallet.Controls.Add(this.lbPallet);
            this.gbPallet.Location = new System.Drawing.Point(7, 216);
            this.gbPallet.Name = "gbPallet";
            this.gbPallet.Size = new System.Drawing.Size(525, 105);
            this.gbPallet.TabIndex = 16;
            this.gbPallet.TabStop = false;
            this.gbPallet.Text = "Pallet";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(13, 51);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(63, 13);
            this.lbDescription.TabIndex = 5;
            this.lbDescription.Text = "Description:";
            // 
            // bnEditPalletList
            // 
            this.bnEditPalletList.Location = new System.Drawing.Point(303, 19);
            this.bnEditPalletList.Name = "bnEditPalletList";
            this.bnEditPalletList.Size = new System.Drawing.Size(53, 21);
            this.bnEditPalletList.TabIndex = 4;
            this.bnEditPalletList.Text = "Edit...";
            this.bnEditPalletList.UseVisualStyleBackColor = true;
            this.bnEditPalletList.Click += new System.EventHandler(this.bnEditPalletList_Click);
            // 
            // lbPalletDescription
            // 
            this.lbPalletDescription.AutoSize = true;
            this.lbPalletDescription.Location = new System.Drawing.Point(87, 51);
            this.lbPalletDescription.Name = "lbPalletDescription";
            this.lbPalletDescription.Size = new System.Drawing.Size(94, 13);
            this.lbPalletDescription.TabIndex = 3;
            this.lbPalletDescription.Text = "lbPalletDescription";
            // 
            // pbPallet
            // 
            this.pbPallet.Location = new System.Drawing.Point(362, 12);
            this.pbPallet.Name = "pbPallet";
            this.pbPallet.Size = new System.Drawing.Size(157, 87);
            this.pbPallet.TabIndex = 2;
            this.pbPallet.TabStop = false;
            // 
            // cbPallet
            // 
            this.cbPallet.AllowDrop = true;
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.FormattingEnabled = true;
            this.cbPallet.Location = new System.Drawing.Point(73, 19);
            this.cbPallet.Name = "cbPallet";
            this.cbPallet.Size = new System.Drawing.Size(224, 21);
            this.cbPallet.TabIndex = 1;
            this.cbPallet.SelectedIndexChanged += new System.EventHandler(this.cbPallet_SelectedIndexChanged);
            // 
            // lbPallet
            // 
            this.lbPallet.AutoSize = true;
            this.lbPallet.Location = new System.Drawing.Point(12, 21);
            this.lbPallet.Name = "lbPallet";
            this.lbPallet.Size = new System.Drawing.Size(33, 13);
            this.lbPallet.TabIndex = 0;
            this.lbPallet.Text = "Pallet";
            // 
            // gbConstraints
            // 
            this.gbConstraints.Controls.Add(this.label7);
            this.gbConstraints.Controls.Add(this.label6);
            this.gbConstraints.Controls.Add(this.label5);
            this.gbConstraints.Controls.Add(this.nudMaxPalletWeight);
            this.gbConstraints.Controls.Add(this.chkMaxPalletWeight);
            this.gbConstraints.Controls.Add(this.label3);
            this.gbConstraints.Controls.Add(this.nudMaxPalletHeight);
            this.gbConstraints.Controls.Add(this.nudOverhangY);
            this.gbConstraints.Controls.Add(this.nudOverhangX);
            this.gbConstraints.Controls.Add(this.label2);
            this.gbConstraints.Controls.Add(this.lbOverhangWidth);
            this.gbConstraints.Controls.Add(this.lbOverhangLength);
            this.gbConstraints.Controls.Add(this.label1);
            this.gbConstraints.Location = new System.Drawing.Point(6, 327);
            this.gbConstraints.Name = "gbConstraints";
            this.gbConstraints.Size = new System.Drawing.Size(525, 91);
            this.gbConstraints.TabIndex = 17;
            this.gbConstraints.TabStop = false;
            this.gbConstraints.Text = "Constraints";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(454, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "mm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "mm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "kg";
            // 
            // nudMaxPalletWeight
            // 
            this.nudMaxPalletWeight.Location = new System.Drawing.Point(183, 65);
            this.nudMaxPalletWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxPalletWeight.Name = "nudMaxPalletWeight";
            this.nudMaxPalletWeight.Size = new System.Drawing.Size(73, 20);
            this.nudMaxPalletWeight.TabIndex = 9;
            // 
            // chkMaxPalletWeight
            // 
            this.chkMaxPalletWeight.AutoSize = true;
            this.chkMaxPalletWeight.Location = new System.Drawing.Point(6, 67);
            this.chkMaxPalletWeight.Name = "chkMaxPalletWeight";
            this.chkMaxPalletWeight.Size = new System.Drawing.Size(132, 17);
            this.chkMaxPalletWeight.TabIndex = 8;
            this.chkMaxPalletWeight.Text = "Maximum pallet weight";
            this.chkMaxPalletWeight.UseVisualStyleBackColor = true;
            this.chkMaxPalletWeight.CheckedChanged += new System.EventHandler(this.chkMaxPalletWeight_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "mm";
            // 
            // nudMaxPalletHeight
            // 
            this.nudMaxPalletHeight.Location = new System.Drawing.Point(183, 39);
            this.nudMaxPalletHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxPalletHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMaxPalletHeight.Name = "nudMaxPalletHeight";
            this.nudMaxPalletHeight.Size = new System.Drawing.Size(73, 20);
            this.nudMaxPalletHeight.TabIndex = 6;
            this.nudMaxPalletHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudOverhangY
            // 
            this.nudOverhangY.DecimalPlaces = 1;
            this.nudOverhangY.Location = new System.Drawing.Point(377, 14);
            this.nudOverhangY.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudOverhangY.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nudOverhangY.Name = "nudOverhangY";
            this.nudOverhangY.Size = new System.Drawing.Size(70, 20);
            this.nudOverhangY.TabIndex = 5;
            // 
            // nudOverhangX
            // 
            this.nudOverhangX.DecimalPlaces = 1;
            this.nudOverhangX.Location = new System.Drawing.Point(183, 14);
            this.nudOverhangX.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nudOverhangX.Name = "nudOverhangX";
            this.nudOverhangX.Size = new System.Drawing.Size(73, 20);
            this.nudOverhangX.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Maximum pallet height";
            // 
            // lbOverhangWidth
            // 
            this.lbOverhangWidth.AutoSize = true;
            this.lbOverhangWidth.Location = new System.Drawing.Point(315, 18);
            this.lbOverhangWidth.Name = "lbOverhangWidth";
            this.lbOverhangWidth.Size = new System.Drawing.Size(35, 13);
            this.lbOverhangWidth.TabIndex = 2;
            this.lbOverhangWidth.Text = "Width";
            // 
            // lbOverhangLength
            // 
            this.lbOverhangLength.AutoSize = true;
            this.lbOverhangLength.Location = new System.Drawing.Point(127, 18);
            this.lbOverhangLength.Name = "lbOverhangLength";
            this.lbOverhangLength.Size = new System.Drawing.Size(40, 13);
            this.lbOverhangLength.TabIndex = 1;
            this.lbOverhangLength.Text = "Length";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Overhang";
            // 
            // lbWeight
            // 
            this.lbWeight.AutoSize = true;
            this.lbWeight.Location = new System.Drawing.Point(26, 40);
            this.lbWeight.Name = "lbWeight";
            this.lbWeight.Size = new System.Drawing.Size(41, 13);
            this.lbWeight.TabIndex = 19;
            this.lbWeight.Text = "Weight";
            // 
            // nudCaseWeight
            // 
            this.nudCaseWeight.Location = new System.Drawing.Point(73, 37);
            this.nudCaseWeight.Name = "nudCaseWeight";
            this.nudCaseWeight.Size = new System.Drawing.Size(75, 20);
            this.nudCaseWeight.TabIndex = 20;
            // 
            // lbCaseWeight
            // 
            this.lbCaseWeight.AutoSize = true;
            this.lbCaseWeight.Location = new System.Drawing.Point(152, 40);
            this.lbCaseWeight.Name = "lbCaseWeight";
            this.lbCaseWeight.Size = new System.Drawing.Size(19, 13);
            this.lbCaseWeight.TabIndex = 21;
            this.lbCaseWeight.Text = "kg";
            // 
            // bnCaseColors
            // 
            this.bnCaseColors.Location = new System.Drawing.Point(362, 37);
            this.bnCaseColors.Name = "bnCaseColors";
            this.bnCaseColors.Size = new System.Drawing.Size(72, 20);
            this.bnCaseColors.TabIndex = 22;
            this.bnCaseColors.Text = "Colors...";
            this.bnCaseColors.UseVisualStyleBackColor = true;
            // 
            // FormDefineAnalysis
            // 
            this.AcceptButton = this.bnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(544, 425);
            this.Controls.Add(this.gbConstraints);
            this.Controls.Add(this.gbPallet);
            this.Controls.Add(this.gbCase);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDefineAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Define pallet analysis...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDefineAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.FormDefineAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaseX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaseY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaseZ)).EndInit();
            this.gbCase.ResumeLayout(false);
            this.gbCase.PerformLayout();
            this.gbPallet.ResumeLayout(false);
            this.gbPallet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPallet)).EndInit();
            this.gbConstraints.ResumeLayout(false);
            this.gbConstraints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPalletWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPalletHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.NumericUpDown nudCaseLength;
        private System.Windows.Forms.Label lbCaseLength;
        private System.Windows.Forms.Label lbCaseWidth;
        private System.Windows.Forms.NumericUpDown nudCaseWidth;
        private System.Windows.Forms.Label lbCaseHeight;
        private System.Windows.Forms.NumericUpDown nudCaseHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbCaseX;
        private System.Windows.Forms.PictureBox pbCaseY;
        private System.Windows.Forms.PictureBox pbCaseZ;
        private System.Windows.Forms.CheckBox chkX;
        private System.Windows.Forms.CheckBox chkY;
        private System.Windows.Forms.CheckBox chkZ;
        private System.Windows.Forms.GroupBox gbCase;
        private System.Windows.Forms.Button bnRevertZ;
        private System.Windows.Forms.Button bnRevertY;
        private System.Windows.Forms.Button bnRevertX;
        private System.Windows.Forms.GroupBox gbPallet;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Button bnEditPalletList;
        private System.Windows.Forms.Label lbPalletDescription;
        private System.Windows.Forms.PictureBox pbPallet;
        private System.Windows.Forms.ComboBox cbPallet;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.GroupBox gbConstraints;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudMaxPalletWeight;
        private System.Windows.Forms.CheckBox chkMaxPalletWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMaxPalletHeight;
        private System.Windows.Forms.NumericUpDown nudOverhangY;
        private System.Windows.Forms.NumericUpDown nudOverhangX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbOverhangWidth;
        private System.Windows.Forms.Label lbOverhangLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCaseWeight;
        private System.Windows.Forms.NumericUpDown nudCaseWeight;
        private System.Windows.Forms.Label lbWeight;
        private System.Windows.Forms.Button bnCaseColors;
    }
}