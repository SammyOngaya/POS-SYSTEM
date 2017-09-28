namespace POS_SYSTEM
{
    partial class UpdateProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateProduct));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.updateProductId = new System.Windows.Forms.TextBox();
            this.updateProductForm = new System.Windows.Forms.ComboBox();
            this.updateProductName = new System.Windows.Forms.TextBox();
            this.updateProductButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.updateProductdataGridView = new System.Windows.Forms.DataGridView();
            this.searchProductUpdate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.updateproductpfsession = new System.Windows.Forms.TextBox();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateProductdataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.updateProductId);
            this.groupBox1.Controls.Add(this.updateProductForm);
            this.groupBox1.Controls.Add(this.updateProductName);
            this.groupBox1.Controls.Add(this.updateProductButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(51, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 456);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Product Details";
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Active",
            "Disable"});
            this.statusComboBox.Location = new System.Drawing.Point(217, 226);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(250, 32);
            this.statusComboBox.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(21, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "status";
            // 
            // updateProductId
            // 
            this.updateProductId.Location = new System.Drawing.Point(247, 20);
            this.updateProductId.Name = "updateProductId";
            this.updateProductId.Size = new System.Drawing.Size(191, 29);
            this.updateProductId.TabIndex = 16;
            this.updateProductId.Visible = false;
            // 
            // updateProductForm
            // 
            this.updateProductForm.FormattingEnabled = true;
            this.updateProductForm.Location = new System.Drawing.Point(229, 129);
            this.updateProductForm.Name = "updateProductForm";
            this.updateProductForm.Size = new System.Drawing.Size(250, 32);
            this.updateProductForm.TabIndex = 14;
            // 
            // updateProductName
            // 
            this.updateProductName.Location = new System.Drawing.Point(229, 55);
            this.updateProductName.MaxLength = 150;
            this.updateProductName.Name = "updateProductName";
            this.updateProductName.Size = new System.Drawing.Size(250, 29);
            this.updateProductName.TabIndex = 13;
            // 
            // updateProductButton
            // 
            this.updateProductButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.updateProductButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateProductButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateProductButton.ForeColor = System.Drawing.Color.White;
            this.updateProductButton.Location = new System.Drawing.Point(179, 281);
            this.updateProductButton.Name = "updateProductButton";
            this.updateProductButton.Size = new System.Drawing.Size(147, 47);
            this.updateProductButton.TabIndex = 11;
            this.updateProductButton.Text = "update";
            this.updateProductButton.UseVisualStyleBackColor = false;
            this.updateProductButton.Click += new System.EventHandler(this.updateProductButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(15, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Product Form";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(18, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Product Name";
            // 
            // updateProductdataGridView
            // 
            this.updateProductdataGridView.AllowUserToOrderColumns = true;
            this.updateProductdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.updateProductdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updateProductdataGridView.Location = new System.Drawing.Point(604, 108);
            this.updateProductdataGridView.Name = "updateProductdataGridView";
            this.updateProductdataGridView.Size = new System.Drawing.Size(597, 447);
            this.updateProductdataGridView.TabIndex = 20;
            // 
            // searchProductUpdate
            // 
            this.searchProductUpdate.Location = new System.Drawing.Point(195, 29);
            this.searchProductUpdate.Name = "searchProductUpdate";
            this.searchProductUpdate.Size = new System.Drawing.Size(344, 20);
            this.searchProductUpdate.TabIndex = 3;
            this.searchProductUpdate.TextChanged += new System.EventHandler(this.searchProductUpdate_TextChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(41, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "product name";
            // 
            // updateproductpfsession
            // 
            this.updateproductpfsession.Location = new System.Drawing.Point(319, 77);
            this.updateproductpfsession.Name = "updateproductpfsession";
            this.updateproductpfsession.Size = new System.Drawing.Size(183, 20);
            this.updateproductpfsession.TabIndex = 21;
            this.updateproductpfsession.Visible = false;
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(291, 7);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rowCountLabel);
            this.groupBox2.Controls.Add(this.searchProductUpdate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox2.Location = new System.Drawing.Point(604, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(597, 68);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search by product name";
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(940, 12);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 97;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // UpdateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 589);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.updateProductdataGridView);
            this.Controls.Add(this.updateproductpfsession);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPDATE PRODUCT";
            this.Load += new System.EventHandler(this.UpdateProduct_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateProductdataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox updateProductId;
        private System.Windows.Forms.ComboBox updateProductForm;
        private System.Windows.Forms.TextBox updateProductName;
        private System.Windows.Forms.Button updateProductButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView updateProductdataGridView;
        private System.Windows.Forms.TextBox searchProductUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox updateproductpfsession;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
    }
}