namespace POS_SYSTEM
{
    partial class AddExpenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddExpenses));
            this.addExpenseTextBox = new System.Windows.Forms.TextBox();
            this.expenseTypeIdforeignkey = new System.Windows.Forms.TextBox();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cancelStock = new System.Windows.Forms.Button();
            this.saveStock = new System.Windows.Forms.Button();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.addAmountTextBox = new System.Windows.Forms.TextBox();
            this.addEexpenseTypeCombo = new System.Windows.Forms.ComboBox();
            this.addDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addStaffpfsession = new System.Windows.Forms.TextBox();
            this.addExpenseDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addExpenseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addExpenseTextBox
            // 
            this.addExpenseTextBox.Location = new System.Drawing.Point(132, 31);
            this.addExpenseTextBox.Name = "addExpenseTextBox";
            this.addExpenseTextBox.Size = new System.Drawing.Size(325, 26);
            this.addExpenseTextBox.TabIndex = 18;
            // 
            // expenseTypeIdforeignkey
            // 
            this.expenseTypeIdforeignkey.Location = new System.Drawing.Point(182, 56);
            this.expenseTypeIdforeignkey.Name = "expenseTypeIdforeignkey";
            this.expenseTypeIdforeignkey.Size = new System.Drawing.Size(240, 20);
            this.expenseTypeIdforeignkey.TabIndex = 32;
            this.expenseTypeIdforeignkey.Visible = false;
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(708, 56);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(509, 20);
            this.databaseConnectionStringTextBox.TabIndex = 33;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(519, 347);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.addExpenseTextBox);
            this.groupBox1.Controls.Add(this.cancelStock);
            this.groupBox1.Controls.Add(this.saveStock);
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
            this.groupBox1.Location = new System.Drawing.Point(67, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1236, 289);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Record Expense";
            // 
            // cancelStock
            // 
            this.cancelStock.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancelStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelStock.ForeColor = System.Drawing.Color.White;
            this.cancelStock.Location = new System.Drawing.Point(989, 245);
            this.cancelStock.Name = "cancelStock";
            this.cancelStock.Size = new System.Drawing.Size(106, 33);
            this.cancelStock.TabIndex = 17;
            this.cancelStock.Text = "cancel";
            this.cancelStock.UseVisualStyleBackColor = false;
            this.cancelStock.Click += new System.EventHandler(this.cancelStock_Click);
            // 
            // saveStock
            // 
            this.saveStock.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.saveStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveStock.ForeColor = System.Drawing.Color.White;
            this.saveStock.Location = new System.Drawing.Point(807, 245);
            this.saveStock.Name = "saveStock";
            this.saveStock.Size = new System.Drawing.Size(109, 33);
            this.saveStock.TabIndex = 16;
            this.saveStock.Text = "save";
            this.saveStock.UseVisualStyleBackColor = false;
            this.saveStock.Click += new System.EventHandler(this.saveStock_Click);
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
            // addStaffpfsession
            // 
            this.addStaffpfsession.Location = new System.Drawing.Point(485, 56);
            this.addStaffpfsession.Name = "addStaffpfsession";
            this.addStaffpfsession.Size = new System.Drawing.Size(201, 20);
            this.addStaffpfsession.TabIndex = 30;
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
            this.addExpenseDataGridView.Location = new System.Drawing.Point(67, 393);
            this.addExpenseDataGridView.Name = "addExpenseDataGridView";
            this.addExpenseDataGridView.Size = new System.Drawing.Size(1236, 301);
            this.addExpenseDataGridView.TabIndex = 29;
            // 
            // AddExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.expenseTypeIdforeignkey);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addStaffpfsession);
            this.Controls.Add(this.addExpenseDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddExpenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RECORD EXPENSES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AddExpenses_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addExpenseDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox addExpenseTextBox;
        private System.Windows.Forms.TextBox expenseTypeIdforeignkey;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancelStock;
        private System.Windows.Forms.Button saveStock;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox addAmountTextBox;
        private System.Windows.Forms.ComboBox addEexpenseTypeCombo;
        private System.Windows.Forms.DateTimePicker addDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addStaffpfsession;
        private System.Windows.Forms.DataGridView addExpenseDataGridView;
    }
}