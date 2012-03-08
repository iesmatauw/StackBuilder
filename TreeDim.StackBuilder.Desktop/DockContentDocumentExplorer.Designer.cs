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
            this._documentTreeView = new TreeDim.StackBuilder.Desktop.AnalysisTreeView();
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
            this.ContextMenuDock.Size = new System.Drawing.Size(174, 114);
            this.ContextMenuDock.Text = "Window Position";
            // 
            // FloatingToolStripMenuItem
            // 
            this.FloatingToolStripMenuItem.CheckOnClick = true;
            this.FloatingToolStripMenuItem.Name = "FloatingToolStripMenuItem";
            this.FloatingToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.FloatingToolStripMenuItem.Text = "Floating";
            this.FloatingToolStripMenuItem.Click += new System.EventHandler(this.FloatingToolStripMenuItem_Click);
            // 
            // DockableToolStripMenuItem
            // 
            this.DockableToolStripMenuItem.Checked = true;
            this.DockableToolStripMenuItem.CheckOnClick = true;
            this.DockableToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DockableToolStripMenuItem.Name = "DockableToolStripMenuItem";
            this.DockableToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.DockableToolStripMenuItem.Text = "Dockable";
            this.DockableToolStripMenuItem.Click += new System.EventHandler(this.DockableToolStripMenuItem_Click);
            // 
            // TabbedDocumentToolStripMenuItem
            // 
            this.TabbedDocumentToolStripMenuItem.CheckOnClick = true;
            this.TabbedDocumentToolStripMenuItem.Name = "TabbedDocumentToolStripMenuItem";
            this.TabbedDocumentToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.TabbedDocumentToolStripMenuItem.Text = "Tabbed Document";
            this.TabbedDocumentToolStripMenuItem.Click += new System.EventHandler(this.TabbedDocumentToolStripMenuItem_Click);
            // 
            // AutoHideToolStripMenuItem
            // 
            this.AutoHideToolStripMenuItem.CheckOnClick = true;
            this.AutoHideToolStripMenuItem.Name = "AutoHideToolStripMenuItem";
            this.AutoHideToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.AutoHideToolStripMenuItem.Text = "Auto Hide";
            this.AutoHideToolStripMenuItem.Click += new System.EventHandler(this.AutoHideToolStripMenuItem_Click);
            // 
            // HideToolStripMenuItem
            // 
            this.HideToolStripMenuItem.CheckOnClick = true;
            this.HideToolStripMenuItem.Name = "HideToolStripMenuItem";
            this.HideToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.HideToolStripMenuItem.Text = "Hide";
            // 
            // _documentTreeView
            // 
            this._documentTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._documentTreeView.ImageIndex = 0;
            this._documentTreeView.Location = new System.Drawing.Point(0, 0);
            this._documentTreeView.Name = "_documentTreeView";
            this._documentTreeView.SelectedImageIndex = 0;
            this._documentTreeView.Size = new System.Drawing.Size(284, 549);
            this._documentTreeView.TabIndex = 1;
            // 
            // DockContentDocumentExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 549);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.ControlBox = false;
            this.Controls.Add(this._documentTreeView);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DockContentDocumentExplorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.ShowInTaskbar = false;
            this.TabPageContextMenuStrip = this.ContextMenuDock;
            this.Text = "Document explorer";
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