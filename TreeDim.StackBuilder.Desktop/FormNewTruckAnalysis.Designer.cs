namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewTruckAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewTruckAnalysis));
            this.bnOk = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.labelTruck = new System.Windows.Forms.Label();
            this.cbTruck = new System.Windows.Forms.ComboBox();
            this.checkBoxAllowSeveralLayers = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowPalletOrientationX = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowPalletOrientationY = new System.Windows.Forms.CheckBox();
            this.labelMinimalDistPalletWall = new System.Windows.Forms.Label();
            this.labelMinimalDistPalletRoof = new System.Windows.Forms.Label();
            this.nudDistancePalletWall = new System.Windows.Forms.NumericUpDown();
            this.nudDistancePalletRoof = new System.Windows.Forms.NumericUpDown();
            this.uLengthDistancePalletWalls = new System.Windows.Forms.Label();
            this.uLengthTruckRoof = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistancePalletWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistancePalletRoof)).BeginInit();
            this.SuspendLayout();
            // 
            // bnOk
            // 
            resources.ApplyResources(this.bnOk, "bnOk");
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Name = "bnOk";
            this.bnOk.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // labelTruck
            // 
            resources.ApplyResources(this.labelTruck, "labelTruck");
            this.labelTruck.Name = "labelTruck";
            // 
            // cbTruck
            // 
            resources.ApplyResources(this.cbTruck, "cbTruck");
            this.cbTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTruck.FormattingEnabled = true;
            this.cbTruck.Name = "cbTruck";
            // 
            // checkBoxAllowSeveralLayers
            // 
            resources.ApplyResources(this.checkBoxAllowSeveralLayers, "checkBoxAllowSeveralLayers");
            this.checkBoxAllowSeveralLayers.Name = "checkBoxAllowSeveralLayers";
            this.checkBoxAllowSeveralLayers.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllowPalletOrientationX
            // 
            resources.ApplyResources(this.checkBoxAllowPalletOrientationX, "checkBoxAllowPalletOrientationX");
            this.checkBoxAllowPalletOrientationX.Name = "checkBoxAllowPalletOrientationX";
            this.checkBoxAllowPalletOrientationX.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllowPalletOrientationY
            // 
            resources.ApplyResources(this.checkBoxAllowPalletOrientationY, "checkBoxAllowPalletOrientationY");
            this.checkBoxAllowPalletOrientationY.Name = "checkBoxAllowPalletOrientationY";
            this.checkBoxAllowPalletOrientationY.UseVisualStyleBackColor = true;
            // 
            // labelMinimalDistPalletWall
            // 
            resources.ApplyResources(this.labelMinimalDistPalletWall, "labelMinimalDistPalletWall");
            this.labelMinimalDistPalletWall.Name = "labelMinimalDistPalletWall";
            // 
            // labelMinimalDistPalletRoof
            // 
            resources.ApplyResources(this.labelMinimalDistPalletRoof, "labelMinimalDistPalletRoof");
            this.labelMinimalDistPalletRoof.Name = "labelMinimalDistPalletRoof";
            // 
            // nudDistancePalletWall
            // 
            resources.ApplyResources(this.nudDistancePalletWall, "nudDistancePalletWall");
            this.nudDistancePalletWall.Name = "nudDistancePalletWall";
            // 
            // nudDistancePalletRoof
            // 
            resources.ApplyResources(this.nudDistancePalletRoof, "nudDistancePalletRoof");
            this.nudDistancePalletRoof.Name = "nudDistancePalletRoof";
            // 
            // uLengthDistancePalletWalls
            // 
            resources.ApplyResources(this.uLengthDistancePalletWalls, "uLengthDistancePalletWalls");
            this.uLengthDistancePalletWalls.Name = "uLengthDistancePalletWalls";
            // 
            // uLengthTruckRoof
            // 
            resources.ApplyResources(this.uLengthTruckRoof, "uLengthTruckRoof");
            this.uLengthTruckRoof.Name = "uLengthTruckRoof";
            // 
            // FormNewTruckAnalysis
            // 
            this.AcceptButton = this.bnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.uLengthTruckRoof);
            this.Controls.Add(this.uLengthDistancePalletWalls);
            this.Controls.Add(this.nudDistancePalletRoof);
            this.Controls.Add(this.nudDistancePalletWall);
            this.Controls.Add(this.labelMinimalDistPalletRoof);
            this.Controls.Add(this.labelMinimalDistPalletWall);
            this.Controls.Add(this.checkBoxAllowPalletOrientationY);
            this.Controls.Add(this.checkBoxAllowPalletOrientationX);
            this.Controls.Add(this.checkBoxAllowSeveralLayers);
            this.Controls.Add(this.cbTruck);
            this.Controls.Add(this.labelTruck);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewTruckAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewTruckAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.FormNewTruckAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDistancePalletWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistancePalletRoof)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label labelTruck;
        private System.Windows.Forms.ComboBox cbTruck;
        private System.Windows.Forms.CheckBox checkBoxAllowSeveralLayers;
        private System.Windows.Forms.CheckBox checkBoxAllowPalletOrientationX;
        private System.Windows.Forms.CheckBox checkBoxAllowPalletOrientationY;
        private System.Windows.Forms.Label labelMinimalDistPalletWall;
        private System.Windows.Forms.Label labelMinimalDistPalletRoof;
        private System.Windows.Forms.NumericUpDown nudDistancePalletWall;
        private System.Windows.Forms.NumericUpDown nudDistancePalletRoof;
        private System.Windows.Forms.Label uLengthDistancePalletWalls;
        private System.Windows.Forms.Label uLengthTruckRoof;
    }
}