namespace TreeDim.StackBuilder.GUIExtension
{
    partial class FormDefineReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDefineReport));
            this.cbReportType = new System.Windows.Forms.ComboBox();
            this.lbReportType = new System.Windows.Forms.Label();
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lbPath = new System.Windows.Forms.Label();
            this.fileSelectCtrl = new TreeDim.UserControls.FileSelect();
            this.chkOpenFile = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbReportType
            // 
            this.cbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReportType.FormattingEnabled = true;
            this.cbReportType.Items.AddRange(new object[] {
            resources.GetString("cbReportType.Items"),
            resources.GetString("cbReportType.Items1")});
            resources.ApplyResources(this.cbReportType, "cbReportType");
            this.cbReportType.Name = "cbReportType";
            this.cbReportType.SelectedIndexChanged += new System.EventHandler(this.cbReportType_SelectedIndexChanged);
            // 
            // lbReportType
            // 
            resources.ApplyResources(this.lbReportType, "lbReportType");
            this.lbReportType.Name = "lbReportType";
            // 
            // bnOK
            // 
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.bnOK, "bnOK");
            this.bnOK.Name = "bnOK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // lbPath
            // 
            resources.ApplyResources(this.lbPath, "lbPath");
            this.lbPath.Name = "lbPath";
            // 
            // fileSelectCtrl
            // 
            this.fileSelectCtrl.BorderStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.fileSelectCtrl.Filter = "MS Word (*.doc)|*.doc";
            resources.ApplyResources(this.fileSelectCtrl, "fileSelectCtrl");
            this.fileSelectCtrl.Name = "fileSelectCtrl";
            this.fileSelectCtrl.SaveMode = true;
            // 
            // chkOpenFile
            // 
            resources.ApplyResources(this.chkOpenFile, "chkOpenFile");
            this.chkOpenFile.Name = "chkOpenFile";
            this.chkOpenFile.UseVisualStyleBackColor = true;
            // 
            // FormDefineReport
            // 
            this.AcceptButton = this.bnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.chkOpenFile);
            this.Controls.Add(this.fileSelectCtrl);
            this.Controls.Add(this.lbPath);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.lbReportType);
            this.Controls.Add(this.cbReportType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDefineReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbReportType;
        private System.Windows.Forms.Label lbReportType;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label lbPath;
        private TreeDim.UserControls.FileSelect fileSelectCtrl;
        private System.Windows.Forms.CheckBox chkOpenFile;
    }
}