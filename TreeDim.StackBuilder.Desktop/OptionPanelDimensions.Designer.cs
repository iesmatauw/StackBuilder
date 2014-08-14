namespace TreeDim.StackBuilder.Desktop
{
    partial class OptionPanelDimensions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionPanelDimensions));
            this.lbDimensions1 = new System.Windows.Forms.Label();
            this.lbDimensions2 = new System.Windows.Forms.Label();
            this.cbDim1 = new System.Windows.Forms.ComboBox();
            this.cbDim2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbDimensions1
            // 
            resources.ApplyResources(this.lbDimensions1, "lbDimensions1");
            this.lbDimensions1.Name = "lbDimensions1";
            // 
            // lbDimensions2
            // 
            resources.ApplyResources(this.lbDimensions2, "lbDimensions2");
            this.lbDimensions2.Name = "lbDimensions2";
            // 
            // cbDim1
            // 
            resources.ApplyResources(this.cbDim1, "cbDim1");
            this.cbDim1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDim1.FormattingEnabled = true;
            this.cbDim1.Items.AddRange(new object[] {
            resources.GetString("cbDim1.Items"),
            resources.GetString("cbDim1.Items1"),
            resources.GetString("cbDim1.Items2")});
            this.cbDim1.Name = "cbDim1";
            // 
            // cbDim2
            // 
            resources.ApplyResources(this.cbDim2, "cbDim2");
            this.cbDim2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDim2.FormattingEnabled = true;
            this.cbDim2.Items.AddRange(new object[] {
            resources.GetString("cbDim2.Items"),
            resources.GetString("cbDim2.Items1"),
            resources.GetString("cbDim2.Items2")});
            this.cbDim2.Name = "cbDim2";
            // 
            // OptionPanelDimensions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Dimensions\\\\Solution caisse/palette";
            this.Controls.Add(this.cbDim2);
            this.Controls.Add(this.cbDim1);
            this.Controls.Add(this.lbDimensions2);
            this.Controls.Add(this.lbDimensions1);
            this.DisplayName = "Dimensions Case/Pallet solution";
            this.Name = "OptionPanelDimensions";
            this.Load += new System.EventHandler(this.OptionPanelDimensions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDimensions1;
        private System.Windows.Forms.Label lbDimensions2;
        private System.Windows.Forms.ComboBox cbDim1;
        private System.Windows.Forms.ComboBox cbDim2;
    }
}
