namespace TreeDim.StackBuilder.Desktop
{
    partial class FormEditPalletSolutionDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditPalletSolutionDB));
            this.btClose = new System.Windows.Forms.Button();
            this.lbPalletDimensions = new System.Windows.Forms.Label();
            this.cbPalletDimensions = new System.Windows.Forms.ComboBox();
            this.gridSolutions = new SourceGrid.Grid();
            this.pictureBoxCase = new System.Windows.Forms.PictureBox();
            this.pictureBoxSolution = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).BeginInit();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.AccessibleDescription = null;
            this.btClose.AccessibleName = null;
            resources.ApplyResources(this.btClose, "btClose");
            this.btClose.BackgroundImage = null;
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Font = null;
            this.btClose.Name = "btClose";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // lbPalletDimensions
            // 
            this.lbPalletDimensions.AccessibleDescription = null;
            this.lbPalletDimensions.AccessibleName = null;
            resources.ApplyResources(this.lbPalletDimensions, "lbPalletDimensions");
            this.lbPalletDimensions.Font = null;
            this.lbPalletDimensions.Name = "lbPalletDimensions";
            // 
            // cbPalletDimensions
            // 
            this.cbPalletDimensions.AccessibleDescription = null;
            this.cbPalletDimensions.AccessibleName = null;
            resources.ApplyResources(this.cbPalletDimensions, "cbPalletDimensions");
            this.cbPalletDimensions.BackgroundImage = null;
            this.cbPalletDimensions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalletDimensions.Font = null;
            this.cbPalletDimensions.FormattingEnabled = true;
            this.cbPalletDimensions.Name = "cbPalletDimensions";
            this.cbPalletDimensions.SelectedIndexChanged += new System.EventHandler(this.cbPalletDimensions_SelectedIndexChanged);
            // 
            // gridSolutions
            // 
            this.gridSolutions.AcceptsInputChar = false;
            this.gridSolutions.AccessibleDescription = null;
            this.gridSolutions.AccessibleName = null;
            resources.ApplyResources(this.gridSolutions, "gridSolutions");
            this.gridSolutions.BackgroundImage = null;
            this.gridSolutions.EnableSort = false;
            this.gridSolutions.Font = null;
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridSolutions.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // pictureBoxCase
            // 
            this.pictureBoxCase.AccessibleDescription = null;
            this.pictureBoxCase.AccessibleName = null;
            resources.ApplyResources(this.pictureBoxCase, "pictureBoxCase");
            this.pictureBoxCase.BackgroundImage = null;
            this.pictureBoxCase.Font = null;
            this.pictureBoxCase.ImageLocation = null;
            this.pictureBoxCase.Name = "pictureBoxCase";
            this.pictureBoxCase.TabStop = false;
            this.pictureBoxCase.SizeChanged += new System.EventHandler(this.pictureBoxSolution_SizeChanged);
            // 
            // pictureBoxSolution
            // 
            this.pictureBoxSolution.AccessibleDescription = null;
            this.pictureBoxSolution.AccessibleName = null;
            resources.ApplyResources(this.pictureBoxSolution, "pictureBoxSolution");
            this.pictureBoxSolution.BackgroundImage = null;
            this.pictureBoxSolution.Font = null;
            this.pictureBoxSolution.ImageLocation = null;
            this.pictureBoxSolution.Name = "pictureBoxSolution";
            this.pictureBoxSolution.TabStop = false;
            // 
            // FormEditPalletSolutionDB
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pictureBoxSolution);
            this.Controls.Add(this.pictureBoxCase);
            this.Controls.Add(this.cbPalletDimensions);
            this.Controls.Add(this.lbPalletDimensions);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.gridSolutions);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditPalletSolutionDB";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormEditPalletSolutionDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSolution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label lbPalletDimensions;
        private System.Windows.Forms.ComboBox cbPalletDimensions;
        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.PictureBox pictureBoxCase;
        private System.Windows.Forms.PictureBox pictureBoxSolution;
    }
}