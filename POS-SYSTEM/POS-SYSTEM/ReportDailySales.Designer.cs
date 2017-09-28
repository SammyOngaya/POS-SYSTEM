﻿namespace POS_SYSTEM
{
    partial class ReportDailySales
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportDailySales));
            this.salesBarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.salesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ProfitAmountLabel = new System.Windows.Forms.Label();
            this.TotalSellingAmountLabel = new System.Windows.Forms.Label();
            this.TotalBuyingAmountLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.discountLabel = new System.Windows.Forms.Label();
            this.discountTextBox = new System.Windows.Forms.TextBox();
            this.discountDataGridView = new System.Windows.Forms.DataGridView();
            this.BuyingAmountTextBox = new System.Windows.Forms.TextBox();
            this.SellingAmountTextBox = new System.Windows.Forms.TextBox();
            this.profitForChartTextBox = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.reverseQuantityTextBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.salesPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.searchByDate = new System.Windows.Forms.Button();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label32 = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.searchDate = new System.Windows.Forms.Button();
            this.reverseInitialQuantityTextBox = new System.Windows.Forms.TextBox();
            this.salesReportDataGridView = new System.Windows.Forms.DataGridView();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.salesBarChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountDataGridView)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesPieChart)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesReportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // salesBarChart
            // 
            chartArea1.Name = "ChartArea1";
            this.salesBarChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.salesBarChart.Legends.Add(legend1);
            this.salesBarChart.Location = new System.Drawing.Point(949, 504);
            this.salesBarChart.Name = "salesBarChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "SALES";
            this.salesBarChart.Series.Add(series1);
            this.salesBarChart.Size = new System.Drawing.Size(413, 246);
            this.salesBarChart.TabIndex = 114;
            this.salesBarChart.Text = "SALES CHART";
            // 
            // salesChart
            // 
            chartArea2.Name = "ChartArea1";
            this.salesChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.salesChart.Legends.Add(legend2);
            this.salesChart.Location = new System.Drawing.Point(51, 443);
            this.salesChart.Name = "salesChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "SALES";
            this.salesChart.Series.Add(series2);
            this.salesChart.Size = new System.Drawing.Size(889, 307);
            this.salesChart.TabIndex = 112;
            this.salesChart.Text = "DATE VS. SELLING";
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
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button3.BackgroundImage = global::POS_SYSTEM.Properties.Resources.pdf;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(6, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 38);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            // discountTextBox
            // 
            this.discountTextBox.Location = new System.Drawing.Point(412, 1);
            this.discountTextBox.Name = "discountTextBox";
            this.discountTextBox.Size = new System.Drawing.Size(169, 20);
            this.discountTextBox.TabIndex = 108;
            this.discountTextBox.Visible = false;
            // 
            // discountDataGridView
            // 
            this.discountDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.discountDataGridView.Location = new System.Drawing.Point(9, 27);
            this.discountDataGridView.Name = "discountDataGridView";
            this.discountDataGridView.Size = new System.Drawing.Size(30, 374);
            this.discountDataGridView.TabIndex = 107;
            this.discountDataGridView.Visible = false;
            // 
            // BuyingAmountTextBox
            // 
            this.BuyingAmountTextBox.Location = new System.Drawing.Point(51, 1);
            this.BuyingAmountTextBox.Name = "BuyingAmountTextBox";
            this.BuyingAmountTextBox.Size = new System.Drawing.Size(169, 20);
            this.BuyingAmountTextBox.TabIndex = 106;
            this.BuyingAmountTextBox.Visible = false;
            // 
            // SellingAmountTextBox
            // 
            this.SellingAmountTextBox.Location = new System.Drawing.Point(226, 1);
            this.SellingAmountTextBox.Name = "SellingAmountTextBox";
            this.SellingAmountTextBox.Size = new System.Drawing.Size(176, 20);
            this.SellingAmountTextBox.TabIndex = 105;
            this.SellingAmountTextBox.Visible = false;
            // 
            // profitForChartTextBox
            // 
            this.profitForChartTextBox.Location = new System.Drawing.Point(607, 1);
            this.profitForChartTextBox.Name = "profitForChartTextBox";
            this.profitForChartTextBox.Size = new System.Drawing.Size(169, 20);
            this.profitForChartTextBox.TabIndex = 111;
            this.profitForChartTextBox.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.discountLabel);
            this.groupBox7.Controls.Add(this.ProfitAmountLabel);
            this.groupBox7.Controls.Add(this.TotalSellingAmountLabel);
            this.groupBox7.Controls.Add(this.TotalBuyingAmountLabel);
            this.groupBox7.Location = new System.Drawing.Point(946, 27);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(413, 198);
            this.groupBox7.TabIndex = 104;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "summary";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(153, 17);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 40);
            this.button10.TabIndex = 31;
            this.button10.Text = "load all";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowCountLabel.Location = new System.Drawing.Point(306, 27);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 20);
            this.rowCountLabel.TabIndex = 10;
            // 
            // reverseQuantityTextBox
            // 
            this.reverseQuantityTextBox.Location = new System.Drawing.Point(946, 1);
            this.reverseQuantityTextBox.Name = "reverseQuantityTextBox";
            this.reverseQuantityTextBox.Size = new System.Drawing.Size(204, 20);
            this.reverseQuantityTextBox.TabIndex = 109;
            this.reverseQuantityTextBox.Visible = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button4.BackgroundImage = global::POS_SYSTEM.Properties.Resources.excel1;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(87, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 38);
            this.button4.TabIndex = 9;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // salesPieChart
            // 
            chartArea3.Name = "ChartArea1";
            this.salesPieChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.salesPieChart.Legends.Add(legend3);
            this.salesPieChart.Location = new System.Drawing.Point(946, 231);
            this.salesPieChart.Name = "salesPieChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "SALES";
            this.salesPieChart.Series.Add(series3);
            this.salesPieChart.Size = new System.Drawing.Size(413, 246);
            this.salesPieChart.TabIndex = 113;
            this.salesPieChart.Text = "SALES CHART";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.rowCountLabel);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Location = new System.Drawing.Point(396, 105);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(544, 66);
            this.groupBox4.TabIndex = 101;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "report";
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
            this.searchByDate.Click += new System.EventHandler(this.searchByDate_Click);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateTimePicker.Location = new System.Drawing.Point(459, 25);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(154, 20);
            this.endDateTimePicker.TabIndex = 3;
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.endDateTimePicker_ValueChanged);
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
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.searchByDate);
            this.groupBox8.Controls.Add(this.endDateTimePicker);
            this.groupBox8.Controls.Add(this.label32);
            this.groupBox8.Controls.Add(this.startDateTimePicker);
            this.groupBox8.Controls.Add(this.label35);
            this.groupBox8.Location = new System.Drawing.Point(51, 27);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(889, 66);
            this.groupBox8.TabIndex = 102;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "search  by date between";
            this.groupBox8.Enter += new System.EventHandler(this.groupBox8_Enter);
            // 
            // dateDateTimePicker
            // 
            this.dateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDateTimePicker.Location = new System.Drawing.Point(53, 25);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.Size = new System.Drawing.Size(154, 20);
            this.dateDateTimePicker.TabIndex = 5;
            this.dateDateTimePicker.ValueChanged += new System.EventHandler(this.dateDateTimePicker_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "date";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dateDateTimePicker);
            this.groupBox6.Controls.Add(this.searchDate);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Location = new System.Drawing.Point(51, 99);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(339, 66);
            this.groupBox6.TabIndex = 103;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "search by date";
            // 
            // searchDate
            // 
            this.searchDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchDate.Location = new System.Drawing.Point(345, 38);
            this.searchDate.Name = "searchDate";
            this.searchDate.Size = new System.Drawing.Size(114, 40);
            this.searchDate.TabIndex = 4;
            this.searchDate.Text = "search";
            this.searchDate.UseVisualStyleBackColor = true;
            // 
            // reverseInitialQuantityTextBox
            // 
            this.reverseInitialQuantityTextBox.Location = new System.Drawing.Point(1158, 1);
            this.reverseInitialQuantityTextBox.Name = "reverseInitialQuantityTextBox";
            this.reverseInitialQuantityTextBox.Size = new System.Drawing.Size(204, 20);
            this.reverseInitialQuantityTextBox.TabIndex = 110;
            this.reverseInitialQuantityTextBox.Visible = false;
            // 
            // salesReportDataGridView
            // 
            this.salesReportDataGridView.AllowUserToOrderColumns = true;
            this.salesReportDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.salesReportDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.salesReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.salesReportDataGridView.Location = new System.Drawing.Point(45, 177);
            this.salesReportDataGridView.Name = "salesReportDataGridView";
            this.salesReportDataGridView.Size = new System.Drawing.Size(895, 224);
            this.salesReportDataGridView.TabIndex = 100;
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(745, 1);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 115;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // ReportDailySales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.salesBarChart);
            this.Controls.Add(this.salesChart);
            this.Controls.Add(this.discountTextBox);
            this.Controls.Add(this.discountDataGridView);
            this.Controls.Add(this.BuyingAmountTextBox);
            this.Controls.Add(this.SellingAmountTextBox);
            this.Controls.Add(this.profitForChartTextBox);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.reverseQuantityTextBox);
            this.Controls.Add(this.salesPieChart);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.reverseInitialQuantityTextBox);
            this.Controls.Add(this.salesReportDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportDailySales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DAILY SALES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportDailySales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salesBarChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountDataGridView)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesPieChart)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesReportDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart salesBarChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart salesChart;
        private System.Windows.Forms.Label ProfitAmountLabel;
        private System.Windows.Forms.Label TotalSellingAmountLabel;
        private System.Windows.Forms.Label TotalBuyingAmountLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label discountLabel;
        private System.Windows.Forms.TextBox discountTextBox;
        private System.Windows.Forms.DataGridView discountDataGridView;
        private System.Windows.Forms.TextBox BuyingAmountTextBox;
        private System.Windows.Forms.TextBox SellingAmountTextBox;
        private System.Windows.Forms.TextBox profitForChartTextBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.TextBox reverseQuantityTextBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataVisualization.Charting.Chart salesPieChart;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button searchByDate;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DateTimePicker dateDateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button searchDate;
        private System.Windows.Forms.TextBox reverseInitialQuantityTextBox;
        private System.Windows.Forms.DataGridView salesReportDataGridView;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;

    }
}