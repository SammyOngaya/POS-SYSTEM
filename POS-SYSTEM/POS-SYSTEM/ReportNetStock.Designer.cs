namespace POS_SYSTEM
{
    partial class ReportNetStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportNetStock));
            this.button2 = new System.Windows.Forms.Button();
            this.profitForChartTextBox = new System.Windows.Forms.TextBox();
            this.BuyingAmountTextBox = new System.Windows.Forms.TextBox();
            this.viewNetStockdataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.netStockPdfReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchProductTextBox = new System.Windows.Forms.TextBox();
            this.searchSupplierPriceListButton = new System.Windows.Forms.Button();
            this.exportToExcelButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.remainingQuantityLabel = new System.Windows.Forms.Label();
            this.ProfitAmountLabel = new System.Windows.Forms.Label();
            this.TotalSellingAmountLabel = new System.Windows.Forms.Label();
            this.TotalBuyingAmountLabel = new System.Windows.Forms.Label();
            this.SellingAmountTextBox = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.viewNetStockdataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button2.BackgroundImage = global::POS_SYSTEM.Properties.Resources.chart;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1027, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 36);
            this.button2.TabIndex = 115;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // profitForChartTextBox
            // 
            this.profitForChartTextBox.Location = new System.Drawing.Point(626, 13);
            this.profitForChartTextBox.Name = "profitForChartTextBox";
            this.profitForChartTextBox.Size = new System.Drawing.Size(169, 20);
            this.profitForChartTextBox.TabIndex = 114;
            this.profitForChartTextBox.Visible = false;
            // 
            // BuyingAmountTextBox
            // 
            this.BuyingAmountTextBox.Location = new System.Drawing.Point(234, 13);
            this.BuyingAmountTextBox.Name = "BuyingAmountTextBox";
            this.BuyingAmountTextBox.Size = new System.Drawing.Size(169, 20);
            this.BuyingAmountTextBox.TabIndex = 113;
            this.BuyingAmountTextBox.Visible = false;
            // 
            // viewNetStockdataGridView
            // 
            this.viewNetStockdataGridView.AllowUserToOrderColumns = true;
            this.viewNetStockdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.viewNetStockdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewNetStockdataGridView.Location = new System.Drawing.Point(23, 177);
            this.viewNetStockdataGridView.Name = "viewNetStockdataGridView";
            this.viewNetStockdataGridView.Size = new System.Drawing.Size(1291, 564);
            this.viewNetStockdataGridView.TabIndex = 111;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(521, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 31);
            this.button1.TabIndex = 110;
            this.button1.Text = "load all drugs";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // netStockPdfReport
            // 
            this.netStockPdfReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.netStockPdfReport.BackgroundImage = global::POS_SYSTEM.Properties.Resources.pdf;
            this.netStockPdfReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.netStockPdfReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.netStockPdfReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.netStockPdfReport.Location = new System.Drawing.Point(841, 13);
            this.netStockPdfReport.Name = "netStockPdfReport";
            this.netStockPdfReport.Size = new System.Drawing.Size(90, 33);
            this.netStockPdfReport.TabIndex = 106;
            this.netStockPdfReport.UseVisualStyleBackColor = false;
            this.netStockPdfReport.Click += new System.EventHandler(this.netStockPdfReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(52, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 105;
            this.label1.Text = "View Net Stock";
            // 
            // searchProductTextBox
            // 
            this.searchProductTextBox.Location = new System.Drawing.Point(59, 17);
            this.searchProductTextBox.MaxLength = 150;
            this.searchProductTextBox.Name = "searchProductTextBox";
            this.searchProductTextBox.Size = new System.Drawing.Size(213, 20);
            this.searchProductTextBox.TabIndex = 19;
            this.searchProductTextBox.TextChanged += new System.EventHandler(this.searchProductTextBox_TextChanged_1);
            // 
            // searchSupplierPriceListButton
            // 
            this.searchSupplierPriceListButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.searchSupplierPriceListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchSupplierPriceListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchSupplierPriceListButton.ForeColor = System.Drawing.Color.White;
            this.searchSupplierPriceListButton.Location = new System.Drawing.Point(278, 13);
            this.searchSupplierPriceListButton.Name = "searchSupplierPriceListButton";
            this.searchSupplierPriceListButton.Size = new System.Drawing.Size(78, 31);
            this.searchSupplierPriceListButton.TabIndex = 18;
            this.searchSupplierPriceListButton.Text = "search";
            this.searchSupplierPriceListButton.UseVisualStyleBackColor = false;
            this.searchSupplierPriceListButton.Click += new System.EventHandler(this.searchSupplierPriceListButton_Click);
            // 
            // exportToExcelButton
            // 
            this.exportToExcelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.exportToExcelButton.BackgroundImage = global::POS_SYSTEM.Properties.Resources.excel;
            this.exportToExcelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportToExcelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportToExcelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportToExcelButton.Location = new System.Drawing.Point(947, 10);
            this.exportToExcelButton.Name = "exportToExcelButton";
            this.exportToExcelButton.Size = new System.Drawing.Size(74, 36);
            this.exportToExcelButton.TabIndex = 108;
            this.exportToExcelButton.UseVisualStyleBackColor = false;
            this.exportToExcelButton.Click += new System.EventHandler(this.exportToExcelButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Product";
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(321, 140);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 107;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.searchProductTextBox);
            this.groupBox2.Controls.Add(this.searchSupplierPriceListButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(56, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 50);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "search";
            // 
            // remainingQuantityLabel
            // 
            this.remainingQuantityLabel.AutoSize = true;
            this.remainingQuantityLabel.Location = new System.Drawing.Point(24, 21);
            this.remainingQuantityLabel.Name = "remainingQuantityLabel";
            this.remainingQuantityLabel.Size = new System.Drawing.Size(10, 13);
            this.remainingQuantityLabel.TabIndex = 6;
            this.remainingQuantityLabel.Text = ".";
            // 
            // ProfitAmountLabel
            // 
            this.ProfitAmountLabel.AutoSize = true;
            this.ProfitAmountLabel.Location = new System.Drawing.Point(24, 97);
            this.ProfitAmountLabel.Name = "ProfitAmountLabel";
            this.ProfitAmountLabel.Size = new System.Drawing.Size(10, 13);
            this.ProfitAmountLabel.TabIndex = 5;
            this.ProfitAmountLabel.Text = ".";
            // 
            // TotalSellingAmountLabel
            // 
            this.TotalSellingAmountLabel.AutoSize = true;
            this.TotalSellingAmountLabel.Location = new System.Drawing.Point(24, 69);
            this.TotalSellingAmountLabel.Name = "TotalSellingAmountLabel";
            this.TotalSellingAmountLabel.Size = new System.Drawing.Size(10, 13);
            this.TotalSellingAmountLabel.TabIndex = 4;
            this.TotalSellingAmountLabel.Text = ".";
            // 
            // TotalBuyingAmountLabel
            // 
            this.TotalBuyingAmountLabel.AutoSize = true;
            this.TotalBuyingAmountLabel.Location = new System.Drawing.Point(24, 41);
            this.TotalBuyingAmountLabel.Name = "TotalBuyingAmountLabel";
            this.TotalBuyingAmountLabel.Size = new System.Drawing.Size(10, 13);
            this.TotalBuyingAmountLabel.TabIndex = 3;
            this.TotalBuyingAmountLabel.Text = ".";
            // 
            // SellingAmountTextBox
            // 
            this.SellingAmountTextBox.Location = new System.Drawing.Point(422, 13);
            this.SellingAmountTextBox.Name = "SellingAmountTextBox";
            this.SellingAmountTextBox.Size = new System.Drawing.Size(176, 20);
            this.SellingAmountTextBox.TabIndex = 112;
            this.SellingAmountTextBox.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.remainingQuantityLabel);
            this.groupBox7.Controls.Add(this.ProfitAmountLabel);
            this.groupBox7.Controls.Add(this.TotalSellingAmountLabel);
            this.groupBox7.Controls.Add(this.TotalBuyingAmountLabel);
            this.groupBox7.Location = new System.Drawing.Point(839, 55);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(508, 116);
            this.groupBox7.TabIndex = 104;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "summary";
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(1107, 17);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 116;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // ReportNetStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.profitForChartTextBox);
            this.Controls.Add(this.BuyingAmountTextBox);
            this.Controls.Add(this.viewNetStockdataGridView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.netStockPdfReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportToExcelButton);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SellingAmountTextBox);
            this.Controls.Add(this.groupBox7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportNetStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NET STOCK";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportNetStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewNetStockdataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox profitForChartTextBox;
        private System.Windows.Forms.TextBox BuyingAmountTextBox;
        private System.Windows.Forms.DataGridView viewNetStockdataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchProductTextBox;
        private System.Windows.Forms.Button searchSupplierPriceListButton;
        private System.Windows.Forms.Button exportToExcelButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label remainingQuantityLabel;
        private System.Windows.Forms.Label ProfitAmountLabel;
        private System.Windows.Forms.Label TotalSellingAmountLabel;
        private System.Windows.Forms.Label TotalBuyingAmountLabel;
        private System.Windows.Forms.TextBox SellingAmountTextBox;
        private System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.Button netStockPdfReport;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
    }
}