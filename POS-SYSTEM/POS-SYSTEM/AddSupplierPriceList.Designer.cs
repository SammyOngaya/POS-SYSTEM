namespace POS_SYSTEM
{
    partial class AddSupplierPriceList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSupplierPriceList));
            this.drugidforeignkey = new System.Windows.Forms.TextBox();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.supplieridforeignkey = new System.Windows.Forms.TextBox();
            this.saveSupplierPriceListButton = new System.Windows.Forms.Button();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.addSupplierCombo = new System.Windows.Forms.ComboBox();
            this.addProductCombo = new System.Windows.Forms.ComboBox();
            this.supplierPriceListDataGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pfsession = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createNewSupplierPriceListButton = new System.Windows.Forms.Button();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.supplierPriceListDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // drugidforeignkey
            // 
            this.drugidforeignkey.Location = new System.Drawing.Point(150, 90);
            this.drugidforeignkey.Name = "drugidforeignkey";
            this.drugidforeignkey.Size = new System.Drawing.Size(100, 20);
            this.drugidforeignkey.TabIndex = 25;
            this.drugidforeignkey.Visible = false;
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(612, 431);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 23;
            // 
            // supplieridforeignkey
            // 
            this.supplieridforeignkey.Location = new System.Drawing.Point(12, 96);
            this.supplieridforeignkey.Name = "supplieridforeignkey";
            this.supplieridforeignkey.Size = new System.Drawing.Size(100, 20);
            this.supplieridforeignkey.TabIndex = 24;
            this.supplieridforeignkey.Visible = false;
            // 
            // saveSupplierPriceListButton
            // 
            this.saveSupplierPriceListButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.saveSupplierPriceListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveSupplierPriceListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSupplierPriceListButton.ForeColor = System.Drawing.Color.White;
            this.saveSupplierPriceListButton.Location = new System.Drawing.Point(79, 209);
            this.saveSupplierPriceListButton.Name = "saveSupplierPriceListButton";
            this.saveSupplierPriceListButton.Size = new System.Drawing.Size(97, 44);
            this.saveSupplierPriceListButton.TabIndex = 16;
            this.saveSupplierPriceListButton.Text = "save";
            this.saveSupplierPriceListButton.UseVisualStyleBackColor = false;
            this.saveSupplierPriceListButton.Click += new System.EventHandler(this.saveSupplierPriceListButton_Click);
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(137, 139);
            this.PriceTextBox.MaxLength = 20;
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(277, 26);
            this.PriceTextBox.TabIndex = 14;
            // 
            // addSupplierCombo
            // 
            this.addSupplierCombo.FormattingEnabled = true;
            this.addSupplierCombo.Location = new System.Drawing.Point(137, 49);
            this.addSupplierCombo.Name = "addSupplierCombo";
            this.addSupplierCombo.Size = new System.Drawing.Size(277, 28);
            this.addSupplierCombo.TabIndex = 12;
            this.addSupplierCombo.SelectedIndexChanged += new System.EventHandler(this.addSupplierCombo_SelectedIndexChanged);
            // 
            // addProductCombo
            // 
            this.addProductCombo.FormattingEnabled = true;
            this.addProductCombo.Location = new System.Drawing.Point(137, 90);
            this.addProductCombo.Name = "addProductCombo";
            this.addProductCombo.Size = new System.Drawing.Size(277, 28);
            this.addProductCombo.TabIndex = 11;
            this.addProductCombo.SelectedIndexChanged += new System.EventHandler(this.addProductCombo_SelectedIndexChanged);
            // 
            // supplierPriceListDataGridView
            // 
            this.supplierPriceListDataGridView.AllowUserToOrderColumns = true;
            this.supplierPriceListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierPriceListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.supplierPriceListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierPriceListDataGridView.Location = new System.Drawing.Point(453, 122);
            this.supplierPriceListDataGridView.Name = "supplierPriceListDataGridView";
            this.supplierPriceListDataGridView.Size = new System.Drawing.Size(803, 359);
            this.supplierPriceListDataGridView.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(11, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(10, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(11, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier";
            // 
            // pfsession
            // 
            this.pfsession.Location = new System.Drawing.Point(274, 90);
            this.pfsession.Name = "pfsession";
            this.pfsession.Size = new System.Drawing.Size(73, 20);
            this.pfsession.TabIndex = 22;
            this.pfsession.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.createNewSupplierPriceListButton);
            this.groupBox1.Controls.Add(this.saveSupplierPriceListButton);
            this.groupBox1.Controls.Add(this.PriceTextBox);
            this.groupBox1.Controls.Add(this.addSupplierCombo);
            this.groupBox1.Controls.Add(this.addProductCombo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(12, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 359);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "supplier price list";
            // 
            // createNewSupplierPriceListButton
            // 
            this.createNewSupplierPriceListButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.createNewSupplierPriceListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createNewSupplierPriceListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createNewSupplierPriceListButton.ForeColor = System.Drawing.Color.White;
            this.createNewSupplierPriceListButton.Location = new System.Drawing.Point(194, 209);
            this.createNewSupplierPriceListButton.Name = "createNewSupplierPriceListButton";
            this.createNewSupplierPriceListButton.Size = new System.Drawing.Size(167, 44);
            this.createNewSupplierPriceListButton.TabIndex = 18;
            this.createNewSupplierPriceListButton.Text = "creat new list";
            this.createNewSupplierPriceListButton.UseVisualStyleBackColor = false;
            this.createNewSupplierPriceListButton.Click += new System.EventHandler(this.createNewSupplierPriceListButton_Click_1);
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(659, 42);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 97;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // AddSupplierPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 534);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.drugidforeignkey);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.supplieridforeignkey);
            this.Controls.Add(this.supplierPriceListDataGridView);
            this.Controls.Add(this.pfsession);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddSupplierPriceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SUPPLIER PRICE LIST";
            this.Load += new System.EventHandler(this.AddSupplierPriceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierPriceListDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox drugidforeignkey;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.TextBox supplieridforeignkey;
        private System.Windows.Forms.Button saveSupplierPriceListButton;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.ComboBox addSupplierCombo;
        private System.Windows.Forms.ComboBox addProductCombo;
        private System.Windows.Forms.DataGridView supplierPriceListDataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pfsession;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button createNewSupplierPriceListButton;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
    }
}