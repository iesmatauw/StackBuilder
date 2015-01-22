namespace TreeDim.StackBuilder.Desktop
{
    partial class DockContentStartPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentStartPage));
            this.webBrowserStartPage = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserStartPage
            // 
            resources.ApplyResources(this.webBrowserStartPage, "webBrowserStartPage");
            this.webBrowserStartPage.Name = "webBrowserStartPage";
            // 
            // DockContentStartPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webBrowserStartPage);
            this.HideOnClose = true;
            this.Name = "DockContentStartPage";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.WebBrowser webBrowserStartPage;
    }
}