namespace POS_SYSTEM
{
    partial class ChartStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartStock));
            this.salesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.projProfitTextBox = new System.Windows.Forms.TextBox();
            this.profitForChartTextBox = new System.Windows.Forms.TextBox();
            this.projectedSellingAmountTextBox = new System.Windows.Forms.TextBox();
            this.BuyingAmountTextBox = new System.Windows.Forms.TextBox();
            this.SellingAmountTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).BeginInit();
            this.SuspendLayout();
            // 
            // salesChart
            // 
            chartArea1.Name = "ChartArea1";
            this.salesChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.salesChart.Legends.Add(legend1);
            this.salesChart.Location = new System.Drawing.Point(174, 114);
            this.salesChart.Name = "salesChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.LegendText = "STOCK CHART";
            series1.Name = "STOCK";
            this.salesChart.Series.Add(series1);
            this.salesChart.Size = new System.Drawing.Size(988, 392);
            this.salesChart.TabIndex = 97;
            this.salesChart.Text = "STOCK CHART";
            // 
            // projProfitTextBox
            // 
            this.projProfitTextBox.Location = new System.Drawing.Point(914, 62);
            this.projProfitTextBox.Name = "projProfitTextBox";
            this.projProfitTextBox.Size = new System.Drawing.Size(169, 20);
            this.projProfitTextBox.TabIndex = 96;
            this.projProfitTextBox.Visible = false;
            // 
            // profitForChartTextBox
            // 
            this.profitForChartTextBox.Location = new System.Drawing.Point(730, 62);
            this.profitForChartTextBox.Name = "profitForChartTextBox";
            this.profitForChartTextBox.Size = new System.Drawing.Size(169, 20);
            this.profitForChartTextBox.TabIndex = 95;
            this.profitForChartTextBox.Visible = false;
            // 
            // projectedSellingAmountTextBox
            // 
            this.projectedSellingAmountTextBox.Location = new System.Drawing.Point(535, 62);
            this.projectedSellingAmountTextBox.Name = "projectedSellingAmountTextBox";
            this.projectedSellingAmountTextBox.Size = new System.Drawing.Size(169, 20);
            this.projectedSellingAmountTextBox.TabIndex = 94;
            this.projectedSellingAmountTextBox.Visible = false;
            // 
            // BuyingAmountTextBox
            // 
            this.BuyingAmountTextBox.Location = new System.Drawing.Point(174, 62);
            this.BuyingAmountTextBox.Name = "BuyingAmountTextBox";
            this.BuyingAmountTextBox.Size = new System.Drawing.Size(169, 20);
            this.BuyingAmountTextBox.TabIndex = 93;
            this.BuyingAmountTextBox.Visible = false;
            // 
            // SellingAmountTextBox
            // 
            this.SellingAmountTextBox.Location = new System.Drawing.Point(349, 62);
            this.SellingAmountTextBox.Name = "SellingAmountTextBox";
            this.SellingAmountTextBox.Size = new System.Drawing.Size(176, 20);
            this.SellingAmountTextBox.TabIndex = 92;
            this.SellingAmountTextBox.Visible = false;
            // 
            // ChartStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 568);
            this.Controls.Add(this.salesChart);
            this.Controls.Add(this.projProfitTextBox);
            this.Controls.Add(this.profitForChartTextBox);
            this.Controls.Add(this.projectedSellingAmountTextBox);
            this.Controls.Add(this.BuyingAmountTextBox);
            this.Controls.Add(this.SellingAmountTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STOCK";
            this.Load += new System.EventHandler(this.ChartStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart salesChart;
        private System.Windows.Forms.TextBox projProfitTextBox;
        private System.Windows.Forms.TextBox profitForChartTextBox;
        private System.Windows.Forms.TextBox projectedSellingAmountTextBox;
        private System.Windows.Forms.TextBox BuyingAmountTextBox;
        private System.Windows.Forms.TextBox SellingAmountTextBox;

    }
}