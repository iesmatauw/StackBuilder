namespace TreeDim.StackBuilder.Desktop
{
    partial class DockContentDocumentExplorer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockContentDocumentExplorer));
            this.ContextMenuDock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FloatingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DockableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabbedDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDock.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenuDock
            // 
            this.ContextMenuDock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FloatingToolStripMenuItem,
            this.DockableToolStripMenuItem,
            this.TabbedDocumentToolStripMenuItem,
            this.AutoHideToolStripMenuItem,
            this.HideToolStripMenuItem});
            this.ContextMenuDock.Name = "ContextMenuStrip1";
            resources.ApplyResources(this.ContextMenuDock, "ContextMenuDock");
            // 
            // FloatingToolStripMenuItem
            // 
            this.FloatingToolStripMenuItem.CheckOnClick = true;
            this.FloatingToolStripMenuItem.Name = "FloatingToolStripMenuItem";
            resources.ApplyResources(this.FloatingToolStripMenuItem, "FloatingToolStripMenuItem");
            this.FloatingToolStripMenuItem.Click += new System.EventHandler(this.FloatingToolStripMenuItem_Click);
            // 
            // DockableToolStripMenuItem
            // 
            this.DockableToolStripMenuItem.Checked = true;
            this.DockableToolStripMenuItem.CheckOnClick = true;
            this.DockableToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DockableToolStripMenuItem.Name = "DockableToolStripMenuItem";
            resources.ApplyResources(this.DockableToolStripMenuItem, "DockableToolStripMenuItem");
            this.DockableToolStripMenuItem.Click += new System.EventHandler(this.DockableToolStripMenuItem_Click);
            // 
            // TabbedDocumentToolStripMenuItem
            // 
            this.TabbedDocumentToolStripMenuItem.CheckOnClick = true;
            this.TabbedDocumentToolStripMenuItem.Name = "TabbedDocumentToolStripMenuItem";
            resources.ApplyResources(this.TabbedDocumentToolStripMenuItem, "TabbedDocumentToolStripMenuItem");
            this.TabbedDocumentToolStripMenuItem.Click += new System.EventHandler(this.TabbedDocumentToolStripMenuItem_Click);
            // 
            // AutoHideToolStripMenuItem
            // 
            this.AutoHideToolStripMenuItem.CheckOnClick = true;
            this.AutoHideToolStripMenuItem.Name = "AutoHideToolStripMenuItem";
            resources.ApplyResources(this.AutoHideToolStripMenuItem, "AutoHideToolStripMenuItem");
            this.AutoHideToolStripMenuItem.Click += new System.EventHandler(this.AutoHideToolStripMenuItem_Click);
            // 
            // HideToolStripMenuItem
            // 
            this.HideToolStripMenuItem.CheckOnClick = true;
            this.HideToolStripMenuItem.Name = "HideToolStripMenuItem";
            resources.ApplyResources(this.HideToolStripMenuItem, "HideToolStripMenuItem");
            // 
            // DockContentDocumentExplorer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.ControlBox = false;
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DockContentDocumentExplorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.ShowInTaskbar = false;
            this.TabPageContextMenuStrip = this.ContextMenuDock;
            this.ContextMenuDock.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        internal System.Windows.Forms.ContextMenuStrip ContextMenuDock;
        internal System.Windows.Forms.ToolStripMenuItem FloatingToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem DockableToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem TabbedDocumentToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem AutoHideToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem HideToolStripMenuItem;
        internal AnalysisTreeView _documentTreeView;
    }
}