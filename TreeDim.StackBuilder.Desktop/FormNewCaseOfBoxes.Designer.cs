namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewCaseOfBoxes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewCaseOfBoxes));
            this.splitContainerCaseOfBoxes = new System.Windows.Forms.SplitContainer();
            this.pictureBoxCaseDefinition = new System.Windows.Forms.PictureBox();
            this.pictureBoxCase = new System.Windows.Forms.PictureBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.btBitmaps = new System.Windows.Forms.Button();
            this.cbFace = new System.Windows.Forms.ComboBox();
            this.gbFaceColor = new System.Windows.Forms.GroupBox();
            this.chkAllFaces = new System.Windows.Forms.CheckBox();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbFace = new System.Windows.Forms.Label();
            this.trackBarHorizAngle = new System.Windows.Forms.TrackBar();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCaseOfBoxes)).BeginInit();
            this.splitContainerCaseOfBoxes.Panel1.SuspendLayout();
            this.splitContainerCaseOfBoxes.Panel2.SuspendLayout();
            this.splitContainerCaseOfBoxes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaseDefinition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCase)).BeginInit();
            this.gbFaceColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).BeginInit();
            this.statusStripDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerCaseOfBoxes
            // 
            resources.ApplyResources(this.splitContainerCaseOfBoxes, "splitContainerCaseOfBoxes");
            this.splitContainerCaseOfBoxes.Name = "splitContainerCaseOfBoxes";
            // 
            // splitContainerCaseOfBoxes.Panel1
            // 
            resources.ApplyResources(this.splitContainerCaseOfBoxes.Panel1, "splitContainerCaseOfBoxes.Panel1");
            this.splitContainerCaseOfBoxes.Panel1.Controls.Add(this.pictureBoxCaseDefinition);
            // 
            // splitContainerCaseOfBoxes.Panel2
            // 
            resources.ApplyResources(this.splitContainerCaseOfBoxes.Panel2, "splitContainerCaseOfBoxes.Panel2");
            this.splitContainerCaseOfBoxes.Panel2.Controls.Add(this.pictureBoxCase);
            // 
            // pictureBoxCaseDefinition
            // 
            resources.ApplyResources(this.pictureBoxCaseDefinition, "pictureBoxCaseDefinition");
            this.pictureBoxCaseDefinition.Name = "pictureBoxCaseDefinition";
            this.pictureBoxCaseDefinition.TabStop = false;
            this.pictureBoxCaseDefinition.SizeChanged += new System.EventHandler(this.pictureBox_SizeChanged);
            // 
            // pictureBoxCase
            // 
            resources.ApplyResources(this.pictureBoxCase, "pictureBoxCase");
            this.pictureBoxCase.Name = "pictureBoxCase";
            this.pictureBoxCase.TabStop = false;
            this.pictureBoxCase.SizeChanged += new System.EventHandler(this.pictureBox_SizeChanged);
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Name = "lbName";
            // 
            // lbDescription
            // 
            resources.ApplyResources(this.lbDescription, "lbDescription");
            this.lbDescription.Name = "lbDescription";
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
            // btBitmaps
            // 
            resources.ApplyResources(this.btBitmaps, "btBitmaps");
            this.btBitmaps.Name = "btBitmaps";
            this.btBitmaps.UseVisualStyleBackColor = true;
            this.btBitmaps.Click += new System.EventHandler(this.btBitmaps_Click);
            // 
            // cbFace
            // 
            resources.ApplyResources(this.cbFace, "cbFace");
            this.cbFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            // gbFaceColor
            // 
            resources.ApplyResources(this.gbFaceColor, "gbFaceColor");
            this.gbFaceColor.Controls.Add(this.btBitmaps);
            this.gbFaceColor.Controls.Add(this.chkAllFaces);
            this.gbFaceColor.Controls.Add(this.cbColor);
            this.gbFaceColor.Controls.Add(this.cbFace);
            this.gbFaceColor.Controls.Add(this.lbFace);
            this.gbFaceColor.Name = "gbFaceColor";
            this.gbFaceColor.TabStop = false;
            // 
            // chkAllFaces
            // 
            resources.ApplyResources(this.chkAllFaces, "chkAllFaces");
            this.chkAllFaces.Name = "chkAllFaces";
            this.chkAllFaces.UseVisualStyleBackColor = true;
            this.chkAllFaces.CheckedChanged += new System.EventHandler(this.chkAllFaces_CheckedChanged);
            // 
            // cbColor
            // 
            resources.ApplyResources(this.cbColor, "cbColor");
            this.cbColor.Color = System.Drawing.Color.Chocolate;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
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
            resources.GetString("cbColor.Items15"),
            resources.GetString("cbColor.Items16"),
            resources.GetString("cbColor.Items17"),
            resources.GetString("cbColor.Items18"),
            resources.GetString("cbColor.Items19"),
            resources.GetString("cbColor.Items20"),
            resources.GetString("cbColor.Items21"),
            resources.GetString("cbColor.Items22"),
            resources.GetString("cbColor.Items23"),
            resources.GetString("cbColor.Items24"),
            resources.GetString("cbColor.Items25"),
            resources.GetString("cbColor.Items26"),
            resources.GetString("cbColor.Items27"),
            resources.GetString("cbColor.Items28"),
            resources.GetString("cbColor.Items29"),
            resources.GetString("cbColor.Items30"),
            resources.GetString("cbColor.Items31"),
            resources.GetString("cbColor.Items32"),
            resources.GetString("cbColor.Items33"),
            resources.GetString("cbColor.Items34"),
            resources.GetString("cbColor.Items35"),
            resources.GetString("cbColor.Items36"),
            resources.GetString("cbColor.Items37"),
            resources.GetString("cbColor.Items38"),
            resources.GetString("cbColor.Items39"),
            resources.GetString("cbColor.Items40"),
            resources.GetString("cbColor.Items41"),
            resources.GetString("cbColor.Items42"),
            resources.GetString("cbColor.Items43"),
            resources.GetString("cbColor.Items44"),
            resources.GetString("cbColor.Items45"),
            resources.GetString("cbColor.Items46"),
            resources.GetString("cbColor.Items47"),
            resources.GetString("cbColor.Items48"),
            resources.GetString("cbColor.Items49"),
            resources.GetString("cbColor.Items50"),
            resources.GetString("cbColor.Items51"),
            resources.GetString("cbColor.Items52"),
            resources.GetString("cbColor.Items53"),
            resources.GetString("cbColor.Items54"),
            resources.GetString("cbColor.Items55"),
            resources.GetString("cbColor.Items56"),
            resources.GetString("cbColor.Items57")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.onFaceColorChanged);
            // 
            // lbFace
            // 
            resources.ApplyResources(this.lbFace, "lbFace");
            this.lbFace.Name = "lbFace";
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
            // statusStripDef
            // 
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStripDef.Name = "statusStripDef";
            // 
            // toolStripStatusLabelDef
            // 
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            // 
            // FormNewCaseOfBoxes
            // 
            this.AcceptButton = this.bnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.gbFaceColor);
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.trackBarHorizAngle);
            this.Controls.Add(this.splitContainerCaseOfBoxes);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewCaseOfBoxes";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewCaseOfBoxes_FormClosing);
            this.Load += new System.EventHandler(this.FormNewCaseOfBoxes_Load);
            this.splitContainerCaseOfBoxes.Panel1.ResumeLayout(false);
            this.splitContainerCaseOfBoxes.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCaseOfBoxes)).EndInit();
            this.splitContainerCaseOfBoxes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaseDefinition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCase)).EndInit();
            this.gbFaceColor.ResumeLayout(false);
            this.gbFaceColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).EndInit();
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.SplitContainer splitContainerCaseOfBoxes;
        private System.Windows.Forms.Button btBitmaps;
        private System.Windows.Forms.ComboBox cbFace;
        private System.Windows.Forms.GroupBox gbFaceColor;
        private System.Windows.Forms.CheckBox chkAllFaces;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.Label lbFace;
        private System.Windows.Forms.TrackBar trackBarHorizAngle;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private System.Windows.Forms.PictureBox pictureBoxCaseDefinition;
        private System.Windows.Forms.PictureBox pictureBoxCase;
    }
}