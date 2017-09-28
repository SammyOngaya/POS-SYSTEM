namespace POS_SYSTEM
{
    partial class AddStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStock));
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.reoderLevelTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.currentBatchTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cancelStock = new System.Windows.Forms.Button();
            this.saveStock = new System.Windows.Forms.Button();
            this.sellingPrice = new System.Windows.Forms.TextBox();
            this.buyingPrice = new System.Windows.Forms.TextBox();
            this.addQuantity = new System.Windows.Forms.TextBox();
            this.addSupplierCombo = new System.Windows.Forms.ComboBox();
            this.addProductCombo = new System.Windows.Forms.ComboBox();
            this.productidforeignkey = new System.Windows.Forms.TextBox();
            this.addStockdataGridView = new System.Windows.Forms.DataGridView();
            this.supplieridforeignkey = new System.Windows.Forms.TextBox();
            this.addDate = new System.Windows.Forms.DateTimePicker();
            this.addBatchNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addstockpfsession = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addUnit = new System.Windows.Forms.TextBox();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.addStockdataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(487, 267);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 23;
            // 
            // reoderLevelTextBox
            // 
            this.reoderLevelTextBox.Location = new System.Drawing.Point(133, 191);
            this.reoderLevelTextBox.MaxLength = 30;
            this.reoderLevelTextBox.Name = "reoderLevelTextBox";
            this.reoderLevelTextBox.Size = new System.Drawing.Size(322, 26);
            this.reoderLevelTextBox.TabIndex = 23;
            this.reoderLevelTextBox.TextChanged += new System.EventHandler(this.reoderLevelTextBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(6, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Re-oder level";
            // 
            // currentBatchTextBox
            // 
            this.currentBatchTextBox.Enabled = false;
            this.currentBatchTextBox.Location = new System.Drawing.Point(810, 177);
            this.currentBatchTextBox.Name = "currentBatchTextBox";
            this.currentBatchTextBox.Size = new System.Drawing.Size(288, 26);
            this.currentBatchTextBox.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(608, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Current Batch No";
            // 
            // cancelStock
            // 
            this.cancelStock.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancelStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelStock.ForeColor = System.Drawing.Color.White;
            this.cancelStock.Location = new System.Drawing.Point(992, 265);
            this.cancelStock.Name = "cancelStock";
            this.cancelStock.Size = new System.Drawing.Size(106, 33);
            this.cancelStock.TabIndex = 17;
            this.cancelStock.Text = "cancel";
            this.cancelStock.UseVisualStyleBackColor = false;
            // 
            // saveStock
            // 
            this.saveStock.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.saveStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveStock.ForeColor = System.Drawing.Color.White;
            this.saveStock.Location = new System.Drawing.Point(810, 265);
            this.saveStock.Name = "saveStock";
            this.saveStock.Size = new System.Drawing.Size(109, 33);
            this.saveStock.TabIndex = 16;
            this.saveStock.Text = "save";
            this.saveStock.UseVisualStyleBackColor = false;
            this.saveStock.Click += new System.EventHandler(this.saveStock_Click);
            // 
            // sellingPrice
            // 
            this.sellingPrice.Location = new System.Drawing.Point(810, 81);
            this.sellingPrice.MaxLength = 20;
            this.sellingPrice.Name = "sellingPrice";
            this.sellingPrice.Size = new System.Drawing.Size(288, 26);
            this.sellingPrice.TabIndex = 15;
            // 
            // buyingPrice
            // 
            this.buyingPrice.Location = new System.Drawing.Point(810, 40);
            this.buyingPrice.MaxLength = 20;
            this.buyingPrice.Name = "buyingPrice";
            this.buyingPrice.Size = new System.Drawing.Size(288, 26);
            this.buyingPrice.TabIndex = 14;
            // 
            // addQuantity
            // 
            this.addQuantity.Location = new System.Drawing.Point(133, 142);
            this.addQuantity.MaxLength = 30;
            this.addQuantity.Name = "addQuantity";
            this.addQuantity.Size = new System.Drawing.Size(322, 26);
            this.addQuantity.TabIndex = 13;
            // 
            // addSupplierCombo
            // 
            this.addSupplierCombo.FormattingEnabled = true;
            this.addSupplierCombo.Location = new System.Drawing.Point(133, 94);
            this.addSupplierCombo.Name = "addSupplierCombo";
            this.addSupplierCombo.Size = new System.Drawing.Size(322, 28);
            this.addSupplierCombo.TabIndex = 12;
            this.addSupplierCombo.SelectedIndexChanged += new System.EventHandler(this.addSupplierCombo_SelectedIndexChanged);
            // 
            // addProductCombo
            // 
            this.addProductCombo.FormattingEnabled = true;
            this.addProductCombo.Location = new System.Drawing.Point(133, 51);
            this.addProductCombo.Name = "addProductCombo";
            this.addProductCombo.Size = new System.Drawing.Size(322, 28);
            this.addProductCombo.TabIndex = 11;
            this.addProductCombo.SelectedIndexChanged += new System.EventHandler(this.addProductCombo_SelectedIndexChanged);
            // 
            // productidforeignkey
            // 
            this.productidforeignkey.Location = new System.Drawing.Point(699, 8);
            this.productidforeignkey.Name = "productidforeignkey";
            this.productidforeignkey.Size = new System.Drawing.Size(220, 26);
            this.productidforeignkey.TabIndex = 0;
            this.productidforeignkey.Visible = false;
            // 
            // addStockdataGridView
            // 
            this.addStockdataGridView.AllowUserToOrderColumns = true;
            this.addStockdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addStockdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.addStockdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addStockdataGridView.Location = new System.Drawing.Point(35, 313);
            this.addStockdataGridView.Name = "addStockdataGridView";
            this.addStockdataGridView.Size = new System.Drawing.Size(1236, 267);
            this.addStockdataGridView.TabIndex = 0;
            // 
            // supplieridforeignkey
            // 
            this.supplieridforeignkey.Location = new System.Drawing.Point(103, -16);
            this.supplieridforeignkey.Name = "supplieridforeignkey";
            this.supplieridforeignkey.Size = new System.Drawing.Size(240, 26);
            this.supplieridforeignkey.TabIndex = 24;
            this.supplieridforeignkey.Visible = false;
            // 
            // addDate
            // 
            this.addDate.CustomFormat = "";
            this.addDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.addDate.Location = new System.Drawing.Point(133, 236);
            this.addDate.Name = "addDate";
            this.addDate.Size = new System.Drawing.Size(322, 26);
            this.addDate.TabIndex = 9;
            // 
            // addBatchNo
            // 
            this.addBatchNo.Location = new System.Drawing.Point(810, 233);
            this.addBatchNo.MaxLength = 30;
            this.addBatchNo.Name = "addBatchNo";
            this.addBatchNo.Size = new System.Drawing.Size(288, 26);
            this.addBatchNo.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(608, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Batch No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(608, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Units";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(9, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Product";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(608, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Selling Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(608, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Buying Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(6, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(7, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier";
            // 
            // addstockpfsession
            // 
            this.addstockpfsession.Location = new System.Drawing.Point(406, -16);
            this.addstockpfsession.Name = "addstockpfsession";
            this.addstockpfsession.Size = new System.Drawing.Size(201, 26);
            this.addstockpfsession.TabIndex = 22;
            this.addstockpfsession.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(6, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Expiry Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.addUnit);
            this.groupBox1.Controls.Add(this.reoderLevelTextBox);
            this.groupBox1.Controls.Add(this.productidforeignkey);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.currentBatchTextBox);
            this.groupBox1.Controls.Add(this.supplieridforeignkey);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.addstockpfsession);
            this.groupBox1.Controls.Add(this.cancelStock);
            this.groupBox1.Controls.Add(this.saveStock);
            this.groupBox1.Controls.Add(this.sellingPrice);
            this.groupBox1.Controls.Add(this.buyingPrice);
            this.groupBox1.Controls.Add(this.addQuantity);
            this.groupBox1.Controls.Add(this.addSupplierCombo);
            this.groupBox1.Controls.Add(this.addProductCombo);
            this.groupBox1.Controls.Add(this.addDate);
            this.groupBox1.Controls.Add(this.addBatchNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(35, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1236, 298);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Stock";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // addUnit
            // 
            this.addUnit.Location = new System.Drawing.Point(814, 132);
            this.addUnit.Name = "addUnit";
            this.addUnit.Size = new System.Drawing.Size(283, 26);
            this.addUnit.TabIndex = 25;
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(999, 9);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 97;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // AddStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 592);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.addStockdataGridView);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD STOCK";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AddStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.addStockdataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.TextBox reoderLevelTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox currentBatchTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cancelStock;
        private System.Windows.Forms.Button saveStock;
        private System.Windows.Forms.TextBox sellingPrice;
        private System.Windows.Forms.TextBox buyingPrice;
        private System.Windows.Forms.TextBox addQuantity;
        private System.Windows.Forms.ComboBox addSupplierCombo;
        private System.Windows.Forms.ComboBox addProductCombo;
        private System.Windows.Forms.TextBox productidforeignkey;
        private System.Windows.Forms.DataGridView addStockdataGridView;
        private System.Windows.Forms.TextBox supplieridforeignkey;
        private System.Windows.Forms.DateTimePicker addDate;
        private System.Windows.Forms.TextBox addBatchNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addstockpfsession;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox addUnit;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
    }
}