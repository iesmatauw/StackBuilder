namespace TreeDim.StackBuilder.Desktop
{
    partial class OptionPanelPlugins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionPanelPlugins));
            this.chkbPluginINTEX = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkbPluginINTEX
            // 
            resources.ApplyResources(this.chkbPluginINTEX, "chkbPluginINTEX");
            this.chkbPluginINTEX.Name = "chkbPluginINTEX";
            this.chkbPluginINTEX.UseVisualStyleBackColor = true;
            // 
            // OptionPanelPlugins
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Plugins";
            this.Controls.Add(this.chkbPluginINTEX);
            this.DisplayName = "Plugins";
            this.Name = "OptionPanelPlugins";
            this.Load += new System.EventHandler(this.OptionPanelPlugins_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkbPluginINTEX;
    }
}
