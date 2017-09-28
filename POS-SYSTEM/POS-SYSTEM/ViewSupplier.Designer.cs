namespace POS_SYSTEM
{
    partial class ViewSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewSupplier));
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.viewSupplierdataGridView = new System.Windows.Forms.DataGridView();
            this.exportToExcelButton = new System.Windows.Forms.Button();
            this.supplierReportPdf = new System.Windows.Forms.Button();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.viewSupplierdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(949, 46);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(399, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "View Suppliers";
            // 
            // viewSupplierdataGridView
            // 
            this.viewSupplierdataGridView.AllowUserToOrderColumns = true;
            this.viewSupplierdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.viewSupplierdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.viewSupplierdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewSupplierdataGridView.Location = new System.Drawing.Point(119, 79);
            this.viewSupplierdataGridView.Name = "viewSupplierdataGridView";
            this.viewSupplierdataGridView.Size = new System.Drawing.Size(1012, 327);
            this.viewSupplierdataGridView.TabIndex = 7;
            // 
            // exportToExcelButton
            // 
            this.exportToExcelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.exportToExcelButton.BackgroundImage = global::POS_SYSTEM.Properties.Resources.excel1;
            this.exportToExcelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportToExcelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportToExcelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportToExcelButton.Location = new System.Drawing.Point(761, 24);
            this.exportToExcelButton.Name = "exportToExcelButton";
            this.exportToExcelButton.Size = new System.Drawing.Size(138, 49);
            this.exportToExcelButton.TabIndex = 11;
            this.exportToExcelButton.UseVisualStyleBackColor = false;
            this.exportToExcelButton.Click += new System.EventHandler(this.exportToExcelButton_Click);
            // 
            // supplierReportPdf
            // 
            this.supplierReportPdf.BackColor = System.Drawing.Color.DarkOrange;
            this.supplierReportPdf.BackgroundImage = global::POS_SYSTEM.Properties.Resources.pdf;
            this.supplierReportPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.supplierReportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.supplierReportPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierReportPdf.Location = new System.Drawing.Point(608, 24);
            this.supplierReportPdf.Name = "supplierReportPdf";
            this.supplierReportPdf.Size = new System.Drawing.Size(131, 49);
            this.supplierReportPdf.TabIndex = 9;
            this.supplierReportPdf.UseVisualStyleBackColor = false;
            this.supplierReportPdf.Click += new System.EventHandler(this.supplierReportPdf_Click);
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(917, 39);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 98;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // ViewSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1250, 444);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.exportToExcelButton);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.supplierReportPdf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewSupplierdataGridView);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIEW SUPPLIERS";
            this.Load += new System.EventHandler(this.ViewSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewSupplierdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exportToExcelButton;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.Button supplierReportPdf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView viewSupplierdataGridView;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
    }
}