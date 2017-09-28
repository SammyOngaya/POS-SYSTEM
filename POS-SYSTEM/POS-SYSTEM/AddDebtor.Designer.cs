namespace POS_SYSTEM
{
    partial class AddDebtor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDebtor));
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.stkQtyLabel = new System.Windows.Forms.Label();
            this.remainingQtylabel = new System.Windows.Forms.Label();
            this.stockDrugQuantityTextbox = new System.Windows.Forms.Label();
            this.debtorPriceTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.adddebtorpfsession = new System.Windows.Forms.TextBox();
            this.stockIDTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.saveDebtor = new System.Windows.Forms.Button();
            this.addPhone = new System.Windows.Forms.TextBox();
            this.addDeposit = new System.Windows.Forms.TextBox();
            this.addQuantity = new System.Windows.Forms.TextBox();
            this.dateOfPayment = new System.Windows.Forms.DateTimePicker();
            this.dateBorrowed = new System.Windows.Forms.DateTimePicker();
            this.addProductCombo = new System.Windows.Forms.ComboBox();
            this.addDebtorName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addDebtordataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.addDebtordataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(469, 27);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(723, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "Amount";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(863, 98);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(77, 16);
            this.amountLabel.TabIndex = 23;
            this.amountLabel.Text = "0.00 Kshs.";
            // 
            // stkQtyLabel
            // 
            this.stkQtyLabel.AutoSize = true;
            this.stkQtyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.stkQtyLabel.Location = new System.Drawing.Point(488, 170);
            this.stkQtyLabel.Name = "stkQtyLabel";
            this.stkQtyLabel.Size = new System.Drawing.Size(101, 16);
            this.stkQtyLabel.TabIndex = 22;
            this.stkQtyLabel.Text = "stockQuantity";
            this.stkQtyLabel.Visible = false;
            this.stkQtyLabel.Click += new System.EventHandler(this.stkQtyLabel_Click_1);
            // 
            // remainingQtylabel
            // 
            this.remainingQtylabel.AutoSize = true;
            this.remainingQtylabel.Location = new System.Drawing.Point(149, 192);
            this.remainingQtylabel.Name = "remainingQtylabel";
            this.remainingQtylabel.Size = new System.Drawing.Size(12, 16);
            this.remainingQtylabel.TabIndex = 21;
            this.remainingQtylabel.Text = ".";
            // 
            // stockDrugQuantityTextbox
            // 
            this.stockDrugQuantityTextbox.AutoSize = true;
            this.stockDrugQuantityTextbox.Location = new System.Drawing.Point(149, 167);
            this.stockDrugQuantityTextbox.Name = "stockDrugQuantityTextbox";
            this.stockDrugQuantityTextbox.Size = new System.Drawing.Size(12, 16);
            this.stockDrugQuantityTextbox.TabIndex = 20;
            this.stockDrugQuantityTextbox.Text = ".";
            // 
            // debtorPriceTextBox
            // 
            this.debtorPriceTextBox.Location = new System.Drawing.Point(152, 142);
            this.debtorPriceTextBox.MaxLength = 20;
            this.debtorPriceTextBox.Name = "debtorPriceTextBox";
            this.debtorPriceTextBox.Size = new System.Drawing.Size(348, 22);
            this.debtorPriceTextBox.TabIndex = 19;
            this.debtorPriceTextBox.TextChanged += new System.EventHandler(this.debtorPriceTextBox_TextChanged_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(22, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Price";
            // 
            // adddebtorpfsession
            // 
            this.adddebtorpfsession.Location = new System.Drawing.Point(391, -10);
            this.adddebtorpfsession.Name = "adddebtorpfsession";
            this.adddebtorpfsession.Size = new System.Drawing.Size(149, 22);
            this.adddebtorpfsession.TabIndex = 17;
            this.adddebtorpfsession.Visible = false;
            // 
            // stockIDTextBox
            // 
            this.stockIDTextBox.Location = new System.Drawing.Point(152, 9);
            this.stockIDTextBox.Name = "stockIDTextBox";
            this.stockIDTextBox.Size = new System.Drawing.Size(148, 22);
            this.stockIDTextBox.TabIndex = 16;
            this.stockIDTextBox.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1013, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 38);
            this.button2.TabIndex = 15;
            this.button2.Text = "clear";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // saveDebtor
            // 
            this.saveDebtor.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.saveDebtor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveDebtor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveDebtor.ForeColor = System.Drawing.Color.White;
            this.saveDebtor.Location = new System.Drawing.Point(866, 181);
            this.saveDebtor.Name = "saveDebtor";
            this.saveDebtor.Size = new System.Drawing.Size(90, 38);
            this.saveDebtor.TabIndex = 14;
            this.saveDebtor.Text = "save";
            this.saveDebtor.UseVisualStyleBackColor = false;
            this.saveDebtor.Click += new System.EventHandler(this.saveDebtor_Click_1);
            // 
            // addPhone
            // 
            this.addPhone.Location = new System.Drawing.Point(866, 63);
            this.addPhone.MaxLength = 30;
            this.addPhone.Name = "addPhone";
            this.addPhone.Size = new System.Drawing.Size(374, 22);
            this.addPhone.TabIndex = 13;
            // 
            // addDeposit
            // 
            this.addDeposit.Location = new System.Drawing.Point(866, 123);
            this.addDeposit.MaxLength = 20;
            this.addDeposit.Name = "addDeposit";
            this.addDeposit.Size = new System.Drawing.Size(374, 22);
            this.addDeposit.TabIndex = 12;
            this.addDeposit.TextChanged += new System.EventHandler(this.addDeposit_TextChanged_1);
            // 
            // addQuantity
            // 
            this.addQuantity.Location = new System.Drawing.Point(152, 98);
            this.addQuantity.MaxLength = 20;
            this.addQuantity.Name = "addQuantity";
            this.addQuantity.Size = new System.Drawing.Size(348, 22);
            this.addQuantity.TabIndex = 11;
            this.addQuantity.TextChanged += new System.EventHandler(this.addQuantity_TextChanged_1);
            // 
            // dateOfPayment
            // 
            this.dateOfPayment.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateOfPayment.Location = new System.Drawing.Point(864, 151);
            this.dateOfPayment.Name = "dateOfPayment";
            this.dateOfPayment.Size = new System.Drawing.Size(374, 22);
            this.dateOfPayment.TabIndex = 10;
            // 
            // dateBorrowed
            // 
            this.dateBorrowed.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBorrowed.Location = new System.Drawing.Point(866, 16);
            this.dateBorrowed.Name = "dateBorrowed";
            this.dateBorrowed.Size = new System.Drawing.Size(374, 22);
            this.dateBorrowed.TabIndex = 9;
            // 
            // addProductCombo
            // 
            this.addProductCombo.FormattingEnabled = true;
            this.addProductCombo.Location = new System.Drawing.Point(152, 66);
            this.addProductCombo.Name = "addProductCombo";
            this.addProductCombo.Size = new System.Drawing.Size(348, 24);
            this.addProductCombo.TabIndex = 8;
            this.addProductCombo.SelectedIndexChanged += new System.EventHandler(this.addProductCombo_SelectedIndexChanged);
            // 
            // addDebtorName
            // 
            this.addDebtorName.Location = new System.Drawing.Point(152, 35);
            this.addDebtorName.MaxLength = 150;
            this.addDebtorName.Name = "addDebtorName";
            this.addDebtorName.Size = new System.Drawing.Size(348, 22);
            this.addDebtorName.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(723, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Date of Payment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(725, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Deposit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(725, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(725, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date Borrowed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(22, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(22, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // addDebtordataGridView
            // 
            this.addDebtordataGridView.AllowUserToOrderColumns = true;
            this.addDebtordataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.addDebtordataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.addDebtordataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addDebtordataGridView.Location = new System.Drawing.Point(34, 260);
            this.addDebtordataGridView.Name = "addDebtordataGridView";
            this.addDebtordataGridView.Size = new System.Drawing.Size(1281, 478);
            this.addDebtordataGridView.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.databaseConnectionStringTextBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.amountLabel);
            this.groupBox1.Controls.Add(this.stkQtyLabel);
            this.groupBox1.Controls.Add(this.remainingQtylabel);
            this.groupBox1.Controls.Add(this.stockDrugQuantityTextbox);
            this.groupBox1.Controls.Add(this.debtorPriceTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.adddebtorpfsession);
            this.groupBox1.Controls.Add(this.stockIDTextBox);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.saveDebtor);
            this.groupBox1.Controls.Add(this.addPhone);
            this.groupBox1.Controls.Add(this.addDeposit);
            this.groupBox1.Controls.Add(this.addQuantity);
            this.groupBox1.Controls.Add(this.dateOfPayment);
            this.groupBox1.Controls.Add(this.dateBorrowed);
            this.groupBox1.Controls.Add(this.addProductCombo);
            this.groupBox1.Controls.Add(this.addDebtorName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(34, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1303, 226);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Debtor";
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(938, -10);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 22);
            this.databaseConnectionStringTextBox.TabIndex = 97;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // AddDebtor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.addDebtordataGridView);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddDebtor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTER DEBTOR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AddDebtor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.addDebtordataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label stkQtyLabel;
        private System.Windows.Forms.Label remainingQtylabel;
        private System.Windows.Forms.Label stockDrugQuantityTextbox;
        private System.Windows.Forms.TextBox debtorPriceTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox adddebtorpfsession;
        private System.Windows.Forms.TextBox stockIDTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button saveDebtor;
        private System.Windows.Forms.TextBox addPhone;
        private System.Windows.Forms.TextBox addDeposit;
        private System.Windows.Forms.TextBox addQuantity;
        private System.Windows.Forms.DateTimePicker dateOfPayment;
        private System.Windows.Forms.DateTimePicker dateBorrowed;
        private System.Windows.Forms.ComboBox addProductCombo;
        private System.Windows.Forms.TextBox addDebtorName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView addDebtordataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
    }
}