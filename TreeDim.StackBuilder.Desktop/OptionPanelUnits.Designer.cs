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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionPanelUnits));
            this.cbUnitSystem = new System.Windows.Forms.ComboBox();
            this.lbUnitSystem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbUnitSystem
            // 
            resources.ApplyResources(this.cbUnitSystem, "cbUnitSystem");
            this.cbUnitSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnitSystem.FormattingEnabled = true;
            this.cbUnitSystem.Items.AddRange(new object[] {
            resources.GetString("cbUnitSystem.Items"),
            resources.GetString("cbUnitSystem.Items1"),
            resources.GetString("cbUnitSystem.Items2"),
            resources.GetString("cbUnitSystem.Items3")});
            this.cbUnitSystem.Name = "cbUnitSystem";
            this.cbUnitSystem.SelectedIndexChanged += new System.EventHandler(this.cbUnitSystem_SelectedIndexChanged);
            // 
            // lbUnitSystem
            // 
            resources.ApplyResources(this.lbUnitSystem, "lbUnitSystem");
            this.lbUnitSystem.Name = "lbUnitSystem";
            // 
            // OptionPanelUnits
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Unit system";
            this.Controls.Add(this.lbUnitSystem);
            this.Controls.Add(this.cbUnitSystem);
            this.DisplayName = "Unit system";
            this.Name = "OptionPanelUnits";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUnitSystem;
        private System.Windows.Forms.Label lbUnitSystem;
    }
}
