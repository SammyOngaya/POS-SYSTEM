namespace POS_SYSTEM
{
    partial class UpdateExpenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateExpenses));
            this.ExpenseIDTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.searchExpenseIDTextBox = new System.Windows.Forms.TextBox();
            this.expenseNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cancelStock = new System.Windows.Forms.Button();
            this.updateStockButton = new System.Windows.Forms.Button();
            this.addStaffpfsession = new System.Windows.Forms.TextBox();
            this.addExpenseDataGridView = new System.Windows.Forms.DataGridView();
            this.addExpenseTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.addAmountTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.expenseTypeIdforeignkey = new System.Windows.Forms.TextBox();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addEexpenseTypeCombo = new System.Windows.Forms.ComboBox();
            this.addDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addExpenseDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExpenseIDTextBox
            // 
            this.ExpenseIDTextBox.Enabled = false;
            this.ExpenseIDTextBox.Location = new System.Drawing.Point(979, 90);
            this.ExpenseIDTextBox.Name = "ExpenseIDTextBox";
            this.ExpenseIDTextBox.Size = new System.Drawing.Size(214, 20);
            this.ExpenseIDTextBox.TabIndex = 43;
            this.ExpenseIDTextBox.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(566, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 24);
            this.label11.TabIndex = 8;
            this.label11.Text = "Expense ID";
            // 
            // searchExpenseIDTextBox
            // 
            this.searchExpenseIDTextBox.Location = new System.Drawing.Point(723, 16);
            this.searchExpenseIDTextBox.Name = "searchExpenseIDTextBox";
            this.searchExpenseIDTextBox.Size = new System.Drawing.Size(193, 20);
            this.searchExpenseIDTextBox.TabIndex = 9;
            this.searchExpenseIDTextBox.TextChanged += new System.EventHandler(this.searchExpenseIDTextBox_TextChanged);
            // 
            // expenseNameTextBox
            // 
            this.expenseNameTextBox.Location = new System.Drawing.Point(195, 19);
            this.expenseNameTextBox.Name = "expenseNameTextBox";
            this.expenseNameTextBox.Size = new System.Drawing.Size(242, 20);
            this.expenseNameTextBox.TabIndex = 7;
            this.expenseNameTextBox.TextChanged += new System.EventHandler(this.expenseNameTextBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.searchExpenseIDTextBox);
            this.groupBox2.Controls.Add(this.expenseNameTextBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(67, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(964, 50);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search by expense id";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(35, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 24);
            this.label10.TabIndex = 6;
            this.label10.Text = "Expense Name";
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "1",
            "0"});
            this.statusComboBox.Location = new System.Drawing.Point(807, 218);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(322, 28);
            this.statusComboBox.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(602, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Status";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1017, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 31);
            this.button1.TabIndex = 22;
            this.button1.Text = "load all drugs";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelStock
            // 
            this.cancelStock.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancelStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelStock.ForeColor = System.Drawing.Color.White;
            this.cancelStock.Location = new System.Drawing.Point(912, 265);
            this.cancelStock.Name = "cancelStock";
            this.cancelStock.Size = new System.Drawing.Size(80, 31);
            this.cancelStock.TabIndex = 21;
            this.cancelStock.Text = "cancel";
            this.cancelStock.UseVisualStyleBackColor = false;
            this.cancelStock.Click += new System.EventHandler(this.cancelStock_Click);
            // 
            // updateStockButton
            // 
            this.updateStockButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.updateStockButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateStockButton.ForeColor = System.Drawing.Color.White;
            this.updateStockButton.Location = new System.Drawing.Point(797, 265);
            this.updateStockButton.Name = "updateStockButton";
            this.updateStockButton.Size = new System.Drawing.Size(80, 31);
            this.updateStockButton.TabIndex = 20;
            this.updateStockButton.Text = "update";
            this.updateStockButton.UseVisualStyleBackColor = false;
            this.updateStockButton.Click += new System.EventHandler(this.updateStockButton_Click);
            // 
            // addStaffpfsession
            // 
            this.addStaffpfsession.Location = new System.Drawing.Point(485, 90);
            this.addStaffpfsession.Name = "addStaffpfsession";
            this.addStaffpfsession.Size = new System.Drawing.Size(201, 20);
            this.addStaffpfsession.TabIndex = 38;
            this.addStaffpfsession.Visible = false;
            // 
            // addExpenseDataGridView
            // 
            this.addExpenseDataGridView.AllowUserToOrderColumns = true;
            this.addExpenseDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addExpenseDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.addExpenseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addExpenseDataGridView.Location = new System.Drawing.Point(67, 464);
            this.addExpenseDataGridView.Name = "addExpenseDataGridView";
            this.addExpenseDataGridView.Size = new System.Drawing.Size(1236, 264);
            this.addExpenseDataGridView.TabIndex = 37;
            // 
            // addExpenseTextBox
            // 
            this.addExpenseTextBox.Location = new System.Drawing.Point(132, 31);
            this.addExpenseTextBox.Name = "addExpenseTextBox";
            this.addExpenseTextBox.Size = new System.Drawing.Size(325, 26);
            this.addExpenseTextBox.TabIndex = 18;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(807, 61);
            this.descriptionTextBox.MaxLength = 20;
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(322, 151);
            this.descriptionTextBox.TabIndex = 15;
            // 
            // addAmountTextBox
            // 
            this.addAmountTextBox.Location = new System.Drawing.Point(130, 200);
            this.addAmountTextBox.MaxLength = 30;
            this.addAmountTextBox.Name = "addAmountTextBox";
            this.addAmountTextBox.Size = new System.Drawing.Size(322, 26);
            this.addAmountTextBox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(601, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(601, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(3, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(6, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type";
            // 
            // expenseTypeIdforeignkey
            // 
            this.expenseTypeIdforeignkey.Location = new System.Drawing.Point(182, 90);
            this.expenseTypeIdforeignkey.Name = "expenseTypeIdforeignkey";
            this.expenseTypeIdforeignkey.Size = new System.Drawing.Size(240, 20);
            this.expenseTypeIdforeignkey.TabIndex = 40;
            this.expenseTypeIdforeignkey.Visible = false;
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(730, 90);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 41;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(524, 438);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 39;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.statusComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cancelStock);
            this.groupBox1.Controls.Add(this.updateStockButton);
            this.groupBox1.Controls.Add(this.addExpenseTextBox);
            this.groupBox1.Controls.Add(this.descriptionTextBox);
            this.groupBox1.Controls.Add(this.addAmountTextBox);
            this.groupBox1.Controls.Add(this.addEexpenseTypeCombo);
            this.groupBox1.Controls.Add(this.addDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(67, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1236, 309);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Expenses";
            // 
            // addEexpenseTypeCombo
            // 
            this.addEexpenseTypeCombo.FormattingEnabled = true;
            this.addEexpenseTypeCombo.Location = new System.Drawing.Point(132, 116);
            this.addEexpenseTypeCombo.Name = "addEexpenseTypeCombo";
            this.addEexpenseTypeCombo.Size = new System.Drawing.Size(322, 28);
            this.addEexpenseTypeCombo.TabIndex = 12;
            this.addEexpenseTypeCombo.SelectedIndexChanged += new System.EventHandler(this.addEexpenseTypeCombo_SelectedIndexChanged);
            // 
            // addDate
            // 
            this.addDate.CustomFormat = "";
            this.addDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.addDate.Location = new System.Drawing.Point(807, 25);
            this.addDate.Name = "addDate";
            this.addDate.Size = new System.Drawing.Size(322, 26);
            this.addDate.TabIndex = 9;
            // 
            // UpdateExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.ExpenseIDTextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.addStaffpfsession);
            this.Controls.Add(this.addExpenseDataGridView);
            this.Controls.Add(this.expenseTypeIdforeignkey);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateExpenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPDATE EXPENSES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UpdateExpenses_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addExpenseDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ExpenseIDTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox searchExpenseIDTextBox;
        private System.Windows.Forms.TextBox expenseNameTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cancelStock;
        private System.Windows.Forms.Button updateStockButton;
        private System.Windows.Forms.TextBox addStaffpfsession;
        private System.Windows.Forms.DataGridView addExpenseDataGridView;
        private System.Windows.Forms.TextBox addExpenseTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox addAmountTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox expenseTypeIdforeignkey;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox addEexpenseTypeCombo;
        private System.Windows.Forms.DateTimePicker addDate;
    }
}