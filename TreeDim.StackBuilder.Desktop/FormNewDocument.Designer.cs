namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewDocument));
            this.lbName = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.bnAccept = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lbAuthor = new System.Windows.Forms.Label();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.lbDateCreated = new System.Windows.Forms.Label();
            this.tbDateCreated = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AccessibleDescription = null;
            this.lbName.AccessibleName = null;
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Font = null;
            this.lbName.Name = "lbName";
            // 
            // lbDescription
            // 
            this.lbDescription.AccessibleDescription = null;
            this.lbDescription.AccessibleName = null;
            resources.ApplyResources(this.lbDescription, "lbDescription");
            this.lbDescription.Font = null;
            this.lbDescription.Name = "lbDescription";
            // 
            // tbName
            // 
            this.tbName.AccessibleDescription = null;
            this.tbName.AccessibleName = null;
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.BackgroundImage = null;
            this.tbName.Font = null;
            this.tbName.Name = "tbName";
            this.tbName.TextChanged += new System.EventHandler(this.onDocumentNameChanged);
            // 
            // tbDescription
            // 
            this.tbDescription.AccessibleDescription = null;
            this.tbDescription.AccessibleName = null;
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.BackgroundImage = null;
            this.tbDescription.Font = null;
            this.tbDescription.Name = "tbDescription";
            // 
            // bnAccept
            // 
            this.bnAccept.AccessibleDescription = null;
            this.bnAccept.AccessibleName = null;
            resources.ApplyResources(this.bnAccept, "bnAccept");
            this.bnAccept.BackgroundImage = null;
            this.bnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnAccept.Font = null;
            this.bnAccept.Name = "bnAccept";
            this.bnAccept.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.AccessibleDescription = null;
            this.bnCancel.AccessibleName = null;
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.BackgroundImage = null;
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Font = null;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // lbAuthor
            // 
            this.lbAuthor.AccessibleDescription = null;
            this.lbAuthor.AccessibleName = null;
            resources.ApplyResources(this.lbAuthor, "lbAuthor");
            this.lbAuthor.Font = null;
            this.lbAuthor.Name = "lbAuthor";
            // 
            // tbAuthor
            // 
            this.tbAuthor.AccessibleDescription = null;
            this.tbAuthor.AccessibleName = null;
            resources.ApplyResources(this.tbAuthor, "tbAuthor");
            this.tbAuthor.BackgroundImage = null;
            this.tbAuthor.Font = null;
            this.tbAuthor.Name = "tbAuthor";
            // 
            // lbDateCreated
            // 
            this.lbDateCreated.AccessibleDescription = null;
            this.lbDateCreated.AccessibleName = null;
            resources.ApplyResources(this.lbDateCreated, "lbDateCreated");
            this.lbDateCreated.Font = null;
            this.lbDateCreated.Name = "lbDateCreated";
            // 
            // tbDateCreated
            // 
            this.tbDateCreated.AccessibleDescription = null;
            this.tbDateCreated.AccessibleName = null;
            resources.ApplyResources(this.tbDateCreated, "tbDateCreated");
            this.tbDateCreated.BackgroundImage = null;
            this.tbDateCreated.Font = null;
            this.tbDateCreated.Name = "tbDateCreated";
            this.tbDateCreated.ReadOnly = true;
            // 
            // FormNewDocument
            // 
            this.AcceptButton = this.bnAccept;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.tbDateCreated);
            this.Controls.Add(this.lbDateCreated);
            this.Controls.Add(this.tbAuthor);
            this.Controls.Add(this.lbAuthor);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnAccept);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbName);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewDocument";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormNewDocument_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewDocument_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button bnAccept;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label lbAuthor;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.Label lbDateCreated;
        private System.Windows.Forms.TextBox tbDateCreated;
    }
}