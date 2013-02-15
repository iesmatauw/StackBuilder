namespace TreeDim.StackBuilder.GUIExtension.Test
{
    partial class FormMain
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
            this.bnGUIExtension = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bnGUIExtension
            // 
            this.bnGUIExtension.Location = new System.Drawing.Point(13, 13);
            this.bnGUIExtension.Name = "bnGUIExtension";
            this.bnGUIExtension.Size = new System.Drawing.Size(101, 23);
            this.bnGUIExtension.TabIndex = 0;
            this.bnGUIExtension.Text = "GUIExtension";
            this.bnGUIExtension.UseVisualStyleBackColor = true;
            this.bnGUIExtension.Click += new System.EventHandler(this.bnGUIExtension_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.bnGUIExtension);
            this.Name = "FormMain";
            this.Text = "GUIExtension.Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnGUIExtension;
    }
}

