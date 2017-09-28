namespace POS_SYSTEM
{
    partial class ImportDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportDatabase));
            this.databaseRestoreButton = new System.Windows.Forms.Button();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // databaseRestoreButton
            // 
            this.databaseRestoreButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.databaseRestoreButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.databaseRestoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseRestoreButton.ForeColor = System.Drawing.Color.White;
            this.databaseRestoreButton.Location = new System.Drawing.Point(451, 58);
            this.databaseRestoreButton.Name = "databaseRestoreButton";
            this.databaseRestoreButton.Size = new System.Drawing.Size(294, 133);
            this.databaseRestoreButton.TabIndex = 14;
            this.databaseRestoreButton.Text = "RESTORE";
            this.databaseRestoreButton.UseVisualStyleBackColor = false;
            this.databaseRestoreButton.Click += new System.EventHandler(this.databaseRestoreButton_Click);
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(882, 12);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 97;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // ImportDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 534);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.databaseRestoreButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RESTORE DATA";
            this.Load += new System.EventHandler(this.ImportDatabase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button databaseRestoreButton;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
    }
}