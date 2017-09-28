﻿namespace POS_SYSTEM
{
    partial class ReportSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportSales));
            this.reverseInitialQuantityTextBox = new System.Windows.Forms.TextBox();
            this.searchDate = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.searchByDate = new System.Windows.Forms.Button();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label32 = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.drugNameTextBox = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.salesReportDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.serialNoTextBox = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.reverseQuantityTextBox = new System.Windows.Forms.TextBox();
            this.discountTextBox = new System.Windows.Forms.TextBox();
            this.discountDataGridView = new System.Windows.Forms.DataGridView();
            this.BuyingAmountTextBox = new System.Windows.Forms.TextBox();
            this.SellingAmountTextBox = new System.Windows.Forms.TextBox();
            this.profitForChartTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.discountLabel = new System.Windows.Forms.Label();
            this.ProfitAmountLabel = new System.Windows.Forms.Label();
            this.TotalSellingAmountLabel = new System.Windows.Forms.Label();
            this.TotalBuyingAmountLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.staffIDTextBox = new System.Windows.Forms.TextBox();
            this.searchByStaffID = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesReportDataGridView)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discountDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // reverseInitialQuantityTextBox
            // 
            this.reverseInitialQuantityTextBox.Location = new System.Drawing.Point(1155, 5);
            this.reverseInitialQuantityTextBox.Name = "reverseInitialQuantityTextBox";
            this.reverseInitialQuantityTextBox.Size = new System.Drawing.Size(204, 20);
            this.reverseInitialQuantityTextBox.TabIndex = 95;
            this.reverseInitialQuantityTextBox.Visible = false;
            // 
            // searchDate
            // 
            this.searchDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchDate.ForeColor = System.Drawing.Color.White;
            this.searchDate.Location = new System.Drawing.Point(258, 20);
            this.searchDate.Name = "searchDate";
            this.searchDate.Size = new System.Drawing.Size(114, 40);
            this.searchDate.TabIndex = 4;
            this.searchDate.Text = "search";
            this.searchDate.UseVisualStyleBackColor = false;
            this.searchDate.Click += new System.EventHandler(this.searchDate_Click_1);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dateDateTimePicker);
            this.groupBox6.Controls.Add(this.searchDate);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Location = new System.Drawing.Point(48, 103);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(383, 66);
            this.groupBox6.TabIndex = 85;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "search by date";
            // 
            // dateDateTimePicker
            // 
            this.dateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDateTimePicker.Location = new System.Drawing.Point(78, 29);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.Size = new System.Drawing.Size(154, 20);
            this.dateDateTimePicker.TabIndex = 5;
            this.dateDateTimePicker.ValueChanged += new System.EventHandler(this.dateDateTimePicker_ValueChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "date";
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::POS_SYSTEM.Properties.Resources.pdf;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(6, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 38);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.searchByDate);
            this.groupBox8.Controls.Add(this.endDateTimePicker);
            this.groupBox8.Controls.Add(this.label32);
            this.groupBox8.Controls.Add(this.startDateTimePicker);
            this.groupBox8.Controls.Add(this.label35);
            this.groupBox8.Location = new System.Drawing.Point(48, 31);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(795, 66);
            this.groupBox8.TabIndex = 83;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "search  by date between";
            this.groupBox8.Enter += new System.EventHandler(this.groupBox8_Enter);
            // 
            // searchByDate
            // 
            this.searchByDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchByDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchByDate.ForeColor = System.Drawing.Color.White;
            this.searchByDate.Location = new System.Drawing.Point(670, 14);
            this.searchByDate.Name = "searchByDate";
            this.searchByDate.Size = new System.Drawing.Size(114, 40);
            this.searchByDate.TabIndex = 4;
            this.searchByDate.Text = "search";
            this.searchByDate.UseVisualStyleBackColor = false;
            this.searchByDate.Click += new System.EventHandler(this.searchByDate_Click_1);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateTimePicker.Location = new System.Drawing.Point(459, 25);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(154, 20);
            this.endDateTimePicker.TabIndex = 3;
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.endDateTimePicker_ValueChanged_1);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(357, 24);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(72, 20);
            this.label32.TabIndex = 2;
            this.label32.Text = "end date";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTimePicker.Location = new System.Drawing.Point(119, 26);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(154, 20);
            this.startDateTimePicker.TabIndex = 1;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(19, 26);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 20);
            this.label35.TabIndex = 0;
            this.label35.Text = "start date";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.rowCountLabel);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Location = new System.Drawing.Point(856, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(503, 66);
            this.groupBox4.TabIndex = 82;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "report";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button11.BackgroundImage = global::POS_SYSTEM.Properties.Resources.chart;
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(153, 17);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 38);
            this.button11.TabIndex = 11;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click_1);
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowCountLabel.Location = new System.Drawing.Point(233, 27);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 20);
            this.rowCountLabel.TabIndex = 10;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button4.BackgroundImage = global::POS_SYSTEM.Properties.Resources.excel;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(87, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 38);
            this.button4.TabIndex = 9;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.drugNameTextBox);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(48, 175);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 66);
            this.groupBox3.TabIndex = 88;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "search by product name";
            // 
            // drugNameTextBox
            // 
            this.drugNameTextBox.Location = new System.Drawing.Point(110, 32);
            this.drugNameTextBox.Name = "drugNameTextBox";
            this.drugNameTextBox.Size = new System.Drawing.Size(152, 20);
            this.drugNameTextBox.TabIndex = 7;
            this.drugNameTextBox.TextChanged += new System.EventHandler(this.drugNameTextBox_TextChanged_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(268, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 40);
            this.button5.TabIndex = 4;
            this.button5.Text = "search";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "product name";
            // 
            // salesReportDataGridView
            // 
            this.salesReportDataGridView.AllowUserToOrderColumns = true;
            this.salesReportDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.salesReportDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.salesReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.salesReportDataGridView.Location = new System.Drawing.Point(48, 334);
            this.salesReportDataGridView.Name = "salesReportDataGridView";
            this.salesReportDataGridView.Size = new System.Drawing.Size(1311, 412);
            this.salesReportDataGridView.TabIndex = 81;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.serialNoTextBox);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(460, 181);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(383, 66);
            this.groupBox5.TabIndex = 89;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "search by serial";
            // 
            // serialNoTextBox
            // 
            this.serialNoTextBox.Location = new System.Drawing.Point(100, 28);
            this.serialNoTextBox.Name = "serialNoTextBox";
            this.serialNoTextBox.Size = new System.Drawing.Size(152, 20);
            this.serialNoTextBox.TabIndex = 7;
            this.serialNoTextBox.TextChanged += new System.EventHandler(this.serialNoTextBox_TextChanged_1);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(258, 20);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(114, 40);
            this.button6.TabIndex = 4;
            this.button6.Text = "search";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "serial";
            // 
            // reverseQuantityTextBox
            // 
            this.reverseQuantityTextBox.Location = new System.Drawing.Point(943, 5);
            this.reverseQuantityTextBox.Name = "reverseQuantityTextBox";
            this.reverseQuantityTextBox.Size = new System.Drawing.Size(204, 20);
            this.reverseQuantityTextBox.TabIndex = 94;
            this.reverseQuantityTextBox.Visible = false;
            // 
            // discountTextBox
            // 
            this.discountTextBox.Location = new System.Drawing.Point(409, 5);
            this.discountTextBox.Name = "discountTextBox";
            this.discountTextBox.Size = new System.Drawing.Size(169, 20);
            this.discountTextBox.TabIndex = 93;
            this.discountTextBox.Visible = false;
            // 
            // discountDataGridView
            // 
            this.discountDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.discountDataGridView.Location = new System.Drawing.Point(12, 334);
            this.discountDataGridView.Name = "discountDataGridView";
            this.discountDataGridView.Size = new System.Drawing.Size(30, 412);
            this.discountDataGridView.TabIndex = 92;
            this.discountDataGridView.Visible = false;
            // 
            // BuyingAmountTextBox
            // 
            this.BuyingAmountTextBox.Location = new System.Drawing.Point(48, 5);
            this.BuyingAmountTextBox.Name = "BuyingAmountTextBox";
            this.BuyingAmountTextBox.Size = new System.Drawing.Size(169, 20);
            this.BuyingAmountTextBox.TabIndex = 91;
            this.BuyingAmountTextBox.Visible = false;
            // 
            // SellingAmountTextBox
            // 
            this.SellingAmountTextBox.Location = new System.Drawing.Point(223, 5);
            this.SellingAmountTextBox.Name = "SellingAmountTextBox";
            this.SellingAmountTextBox.Size = new System.Drawing.Size(176, 20);
            this.SellingAmountTextBox.TabIndex = 90;
            this.SellingAmountTextBox.Visible = false;
            // 
            // profitForChartTextBox
            // 
            this.profitForChartTextBox.Location = new System.Drawing.Point(604, 5);
            this.profitForChartTextBox.Name = "profitForChartTextBox";
            this.profitForChartTextBox.Size = new System.Drawing.Size(169, 20);
            this.profitForChartTextBox.TabIndex = 96;
            this.profitForChartTextBox.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(48, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 66);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "combined search";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(702, 19);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(87, 40);
            this.button10.TabIndex = 31;
            this.button10.Text = "load all";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click_1);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(597, 19);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(87, 40);
            this.button9.TabIndex = 30;
            this.button9.Text = "Reverse";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(429, 20);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(162, 40);
            this.button8.TabIndex = 29;
            this.button8.Text = "date range and product";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(302, 20);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 40);
            this.button7.TabIndex = 28;
            this.button7.Text = "date and product";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(6, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 40);
            this.button2.TabIndex = 27;
            this.button2.Text = "date and staff";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(128, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "date range and staff";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.discountLabel);
            this.groupBox7.Controls.Add(this.ProfitAmountLabel);
            this.groupBox7.Controls.Add(this.TotalSellingAmountLabel);
            this.groupBox7.Controls.Add(this.TotalBuyingAmountLabel);
            this.groupBox7.Location = new System.Drawing.Point(856, 103);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(503, 215);
            this.groupBox7.TabIndex = 86;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "summary";
            // 
            // discountLabel
            // 
            this.discountLabel.AutoSize = true;
            this.discountLabel.Location = new System.Drawing.Point(16, 125);
            this.discountLabel.Name = "discountLabel";
            this.discountLabel.Size = new System.Drawing.Size(10, 13);
            this.discountLabel.TabIndex = 3;
            this.discountLabel.Text = ".";
            // 
            // ProfitAmountLabel
            // 
            this.ProfitAmountLabel.AutoSize = true;
            this.ProfitAmountLabel.Location = new System.Drawing.Point(16, 169);
            this.ProfitAmountLabel.Name = "ProfitAmountLabel";
            this.ProfitAmountLabel.Size = new System.Drawing.Size(10, 13);
            this.ProfitAmountLabel.TabIndex = 2;
            this.ProfitAmountLabel.Text = ".";
            // 
            // TotalSellingAmountLabel
            // 
            this.TotalSellingAmountLabel.AutoSize = true;
            this.TotalSellingAmountLabel.Location = new System.Drawing.Point(16, 78);
            this.TotalSellingAmountLabel.Name = "TotalSellingAmountLabel";
            this.TotalSellingAmountLabel.Size = new System.Drawing.Size(10, 13);
            this.TotalSellingAmountLabel.TabIndex = 1;
            this.TotalSellingAmountLabel.Text = ".";
            // 
            // TotalBuyingAmountLabel
            // 
            this.TotalBuyingAmountLabel.AutoSize = true;
            this.TotalBuyingAmountLabel.Location = new System.Drawing.Point(16, 34);
            this.TotalBuyingAmountLabel.Name = "TotalBuyingAmountLabel";
            this.TotalBuyingAmountLabel.Size = new System.Drawing.Size(10, 13);
            this.TotalBuyingAmountLabel.TabIndex = 0;
            this.TotalBuyingAmountLabel.Text = ".";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.staffIDTextBox);
            this.groupBox2.Controls.Add(this.searchByStaffID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(460, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 66);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search  by staff";
            // 
            // staffIDTextBox
            // 
            this.staffIDTextBox.Location = new System.Drawing.Point(100, 28);
            this.staffIDTextBox.Name = "staffIDTextBox";
            this.staffIDTextBox.Size = new System.Drawing.Size(152, 20);
            this.staffIDTextBox.TabIndex = 6;
            this.staffIDTextBox.TextChanged += new System.EventHandler(this.staffIDTextBox_TextChanged_1);
            // 
            // searchByStaffID
            // 
            this.searchByStaffID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.searchByStaffID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchByStaffID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchByStaffID.ForeColor = System.Drawing.Color.White;
            this.searchByStaffID.Location = new System.Drawing.Point(258, 20);
            this.searchByStaffID.Name = "searchByStaffID";
            this.searchByStaffID.Size = new System.Drawing.Size(114, 40);
            this.searchByStaffID.TabIndex = 4;
            this.searchByStaffID.Text = "search";
            this.searchByStaffID.UseVisualStyleBackColor = false;
            this.searchByStaffID.Click += new System.EventHandler(this.searchByStaffID_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "staff ID";
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(769, 5);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 101;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // ReportSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.reverseInitialQuantityTextBox);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.salesReportDataGridView);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.reverseQuantityTextBox);
            this.Controls.Add(this.discountTextBox);
            this.Controls.Add(this.discountDataGridView);
            this.Controls.Add(this.BuyingAmountTextBox);
            this.Controls.Add(this.SellingAmountTextBox);
            this.Controls.Add(this.profitForChartTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALES REPORT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportSales_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesReportDataGridView)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discountDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox reverseInitialQuantityTextBox;
        private System.Windows.Forms.Button searchDate;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DateTimePicker dateDateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button searchByDate;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox drugNameTextBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView salesReportDataGridView;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox serialNoTextBox;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox reverseQuantityTextBox;
        private System.Windows.Forms.TextBox discountTextBox;
        private System.Windows.Forms.DataGridView discountDataGridView;
        private System.Windows.Forms.TextBox BuyingAmountTextBox;
        private System.Windows.Forms.TextBox SellingAmountTextBox;
        private System.Windows.Forms.TextBox profitForChartTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.Label ProfitAmountLabel;
        private System.Windows.Forms.Label TotalSellingAmountLabel;
        private System.Windows.Forms.Label TotalBuyingAmountLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox staffIDTextBox;
        private System.Windows.Forms.Button searchByStaffID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
    }
}