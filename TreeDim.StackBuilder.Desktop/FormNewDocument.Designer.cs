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
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(13, 9);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "&Name";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(13, 36);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(60, 13);
            this.lbDescription.TabIndex = 2;
            this.lbDescription.Text = "&Description";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(108, 9);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(279, 20);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.onDocumentNameChanged);
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(108, 36);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(279, 106);
            this.tbDescription.TabIndex = 3;
            // 
            // bnAccept
            // 
            this.bnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnAccept.Location = new System.Drawing.Point(397, 9);
            this.bnAccept.Name = "bnAccept";
            this.bnAccept.Size = new System.Drawing.Size(75, 23);
            this.bnAccept.TabIndex = 8;
            this.bnAccept.Text = "&OK";
            this.bnAccept.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(397, 36);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 9;
            this.bnCancel.Text = "&Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // lbAuthor
            // 
            this.lbAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAuthor.AutoSize = true;
            this.lbAuthor.Location = new System.Drawing.Point(13, 151);
            this.lbAuthor.Name = "lbAuthor";
            this.lbAuthor.Size = new System.Drawing.Size(38, 13);
            this.lbAuthor.TabIndex = 4;
            this.lbAuthor.Text = "&Author";
            // 
            // tbAuthor
            // 
            this.tbAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAuthor.Location = new System.Drawing.Point(108, 151);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.Size = new System.Drawing.Size(279, 20);
            this.tbAuthor.TabIndex = 5;
            // 
            // lbDateCreated
            // 
            this.lbDateCreated.AutoSize = true;
            this.lbDateCreated.Location = new System.Drawing.Point(13, 182);
            this.lbDateCreated.Name = "lbDateCreated";
            this.lbDateCreated.Size = new System.Drawing.Size(69, 13);
            this.lbDateCreated.TabIndex = 6;
            this.lbDateCreated.Text = "Date created";
            // 
            // tbDateCreated
            // 
            this.tbDateCreated.Location = new System.Drawing.Point(109, 182);
            this.tbDateCreated.Name = "tbDateCreated";
            this.tbDateCreated.ReadOnly = true;
            this.tbDateCreated.Size = new System.Drawing.Size(277, 20);
            this.tbDateCreated.TabIndex = 7;
            // 
            // FormNewDocument
            // 
            this.AcceptButton = this.bnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(484, 212);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewDocument";
            this.ShowIcon = false;
            this.Text = "Create new document...";
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