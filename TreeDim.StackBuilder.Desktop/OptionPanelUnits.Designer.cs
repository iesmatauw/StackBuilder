namespace TreeDim.StackBuilder.Desktop
{
    partial class OptionPanelUnits
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbUnitSystem = new System.Windows.Forms.ComboBox();
            this.lbUnitSystem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbUnitSystem
            // 
            this.cbUnitSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnitSystem.FormattingEnabled = true;
            this.cbUnitSystem.Items.AddRange(new object[] {
            "Metric (mm/kg/l)",
            "UK (in/lb/gal)",
            "US (in/lb/gal)"});
            this.cbUnitSystem.Location = new System.Drawing.Point(99, 21);
            this.cbUnitSystem.Name = "cbUnitSystem";
            this.cbUnitSystem.Size = new System.Drawing.Size(121, 21);
            this.cbUnitSystem.TabIndex = 0;
            this.cbUnitSystem.SelectedIndexChanged += new System.EventHandler(this.cbUnitSystem_SelectedIndexChanged);
            // 
            // lbUnitSystem
            // 
            this.lbUnitSystem.AutoSize = true;
            this.lbUnitSystem.Location = new System.Drawing.Point(8, 23);
            this.lbUnitSystem.Name = "lbUnitSystem";
            this.lbUnitSystem.Size = new System.Drawing.Size(61, 13);
            this.lbUnitSystem.TabIndex = 1;
            this.lbUnitSystem.Text = "Unit system";
            // 
            // OptionPanelUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Unit system";
            this.Controls.Add(this.lbUnitSystem);
            this.Controls.Add(this.cbUnitSystem);
            this.DisplayName = "Unit system";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "OptionPanelUnits";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUnitSystem;
        private System.Windows.Forms.Label lbUnitSystem;
    }
}
