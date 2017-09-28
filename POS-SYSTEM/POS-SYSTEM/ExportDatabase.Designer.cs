namespace POS_SYSTEM
{
    partial class ExportDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportDatabase));
            this.databaseBackupButton = new System.Windows.Forms.Button();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // databaseBackupButton
            // 
            this.databaseBackupButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.databaseBackupButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.databaseBackupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseBackupButton.ForeColor = System.Drawing.Color.White;
            this.databaseBackupButton.Location = new System.Drawing.Point(439, 80);
            this.databaseBackupButton.Name = "databaseBackupButton";
            this.databaseBackupButton.Size = new System.Drawing.Size(294, 133);
            this.databaseBackupButton.TabIndex = 13;
            this.databaseBackupButton.Text = "BACKUP";
            this.databaseBackupButton.UseVisualStyleBackColor = false;
            this.databaseBackupButton.Click += new System.EventHandler(this.databaseBackupButton_Click);
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(874, 12);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 97;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // ExportDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 543);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.databaseBackupButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA BACKUP";
            this.Load += new System.EventHandler(this.ExportDatabase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button databaseBackupButton;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
    }
}