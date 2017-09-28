namespace POS_SYSTEM
{
    partial class ViewProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewProduct));
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.printProductExcel = new System.Windows.Forms.Button();
            this.printProductPdfButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.viewProductdataGridView = new System.Windows.Forms.DataGridView();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.viewProductdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(926, 89);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 10;
            // 
            // printProductExcel
            // 
            this.printProductExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.printProductExcel.BackgroundImage = global::POS_SYSTEM.Properties.Resources.excel;
            this.printProductExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.printProductExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printProductExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printProductExcel.Location = new System.Drawing.Point(690, 49);
            this.printProductExcel.Name = "printProductExcel";
            this.printProductExcel.Size = new System.Drawing.Size(170, 61);
            this.printProductExcel.TabIndex = 9;
            this.printProductExcel.UseVisualStyleBackColor = false;
            this.printProductExcel.Click += new System.EventHandler(this.printProductExcel_Click);
            // 
            // printProductPdfButton
            // 
            this.printProductPdfButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.printProductPdfButton.BackgroundImage = global::POS_SYSTEM.Properties.Resources.pdf;
            this.printProductPdfButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.printProductPdfButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printProductPdfButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printProductPdfButton.Location = new System.Drawing.Point(499, 44);
            this.printProductPdfButton.Name = "printProductPdfButton";
            this.printProductPdfButton.Size = new System.Drawing.Size(170, 66);
            this.printProductPdfButton.TabIndex = 8;
            this.printProductPdfButton.UseVisualStyleBackColor = false;
            this.printProductPdfButton.Click += new System.EventHandler(this.printProductPdfButton_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(366, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "View Products";
            // 
            // viewProductdataGridView
            // 
            this.viewProductdataGridView.AllowUserToOrderColumns = true;
            this.viewProductdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.viewProductdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.viewProductdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewProductdataGridView.Location = new System.Drawing.Point(103, 128);
            this.viewProductdataGridView.Name = "viewProductdataGridView";
            this.viewProductdataGridView.Size = new System.Drawing.Size(1107, 411);
            this.viewProductdataGridView.TabIndex = 6;
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(996, 44);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 97;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // ViewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 570);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.printProductExcel);
            this.Controls.Add(this.printProductPdfButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewProductdataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIEW PRODUCTS";
            this.Load += new System.EventHandler(this.ViewProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewProductdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.Button printProductExcel;
        private System.Windows.Forms.Button printProductPdfButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView viewProductdataGridView;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
    }
}