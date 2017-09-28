namespace POS_SYSTEM
{
    partial class AddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.productPfsession = new System.Windows.Forms.TextBox();
            this.productform = new System.Windows.Forms.ComboBox();
            this.productname = new System.Windows.Forms.TextBox();
            this.registerProductButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.addProductdataGridView = new System.Windows.Forms.DataGridView();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addProductdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.productPfsession);
            this.groupBox1.Controls.Add(this.productform);
            this.groupBox1.Controls.Add(this.productname);
            this.groupBox1.Controls.Add(this.registerProductButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(75, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 428);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Details";
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Active",
            "Disable"});
            this.statusComboBox.Location = new System.Drawing.Point(189, 194);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(250, 28);
            this.statusComboBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(6, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "status";
            // 
            // productPfsession
            // 
            this.productPfsession.Location = new System.Drawing.Point(233, 10);
            this.productPfsession.Name = "productPfsession";
            this.productPfsession.Size = new System.Drawing.Size(170, 26);
            this.productPfsession.TabIndex = 2;
            this.productPfsession.Visible = false;
            // 
            // productform
            // 
            this.productform.FormattingEnabled = true;
            this.productform.Location = new System.Drawing.Point(189, 112);
            this.productform.Name = "productform";
            this.productform.Size = new System.Drawing.Size(250, 28);
            this.productform.TabIndex = 6;
            // 
            // productname
            // 
            this.productname.Location = new System.Drawing.Point(189, 45);
            this.productname.MaxLength = 150;
            this.productname.Name = "productname";
            this.productname.Size = new System.Drawing.Size(250, 26);
            this.productname.TabIndex = 5;
            // 
            // registerProductButton
            // 
            this.registerProductButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.registerProductButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerProductButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerProductButton.ForeColor = System.Drawing.Color.White;
            this.registerProductButton.Location = new System.Drawing.Point(210, 277);
            this.registerProductButton.Name = "registerProductButton";
            this.registerProductButton.Size = new System.Drawing.Size(123, 40);
            this.registerProductButton.TabIndex = 3;
            this.registerProductButton.Text = "save";
            this.registerProductButton.UseVisualStyleBackColor = false;
            this.registerProductButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Form";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name";
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(694, 65);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 8;
            // 
            // addProductdataGridView
            // 
            this.addProductdataGridView.AllowUserToOrderColumns = true;
            this.addProductdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addProductdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.addProductdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addProductdataGridView.Location = new System.Drawing.Point(550, 83);
            this.addProductdataGridView.Name = "addProductdataGridView";
            this.addProductdataGridView.Size = new System.Drawing.Size(667, 428);
            this.addProductdataGridView.TabIndex = 7;
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(799, 12);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 97;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 576);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.addProductdataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTER PRODUCT";
            this.Load += new System.EventHandler(this.AddProduct_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addProductdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox productPfsession;
        private System.Windows.Forms.ComboBox productform;
        private System.Windows.Forms.TextBox productname;
        private System.Windows.Forms.Button registerProductButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.DataGridView addProductdataGridView;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
    }
}