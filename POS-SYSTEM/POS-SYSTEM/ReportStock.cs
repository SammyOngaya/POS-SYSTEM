using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
namespace POS_SYSTEM
{
    public partial class ReportStock : Form
    {

        DataTable dataTable;
        public ReportStock(string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            searchDrug();
            searchSupplier();
            searchBatch();
            viewStock();
        }

        private void ReportStock_Load(object sender, EventArgs e)
        {

        }



        //compute amount transacted.
        public void buyingAmount()
        {

            double sum = 0.00;
            for (int i = 0; i < reportStockDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(reportStockDataGridView.Rows[i].Cells[10].Value);

            }

            buyingAmountLabel.Text = "total buying amount  " + sum.ToString() + " Kshs";
            BuyingAmountTextBox.Text = sum.ToString();
            }

       

        //compute amount transacted.
        public void sellingAmount()
        {

            double sum = 0.00;
            for (int i = 0; i < reportStockDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(reportStockDataGridView.Rows[i].Cells[11].Value);

            }

            sellingAmountLabel.Text = "total selling amount  " + sum.ToString() + " Kshs";
            SellingAmountTextBox.Text = sum.ToString();
            }

        //compute amount transacted.
        public void profitLoss()
        {
            try
            {
                double sum = 0.00;
            for (int i = 0; i < reportStockDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(reportStockDataGridView.Rows[i].Cells[12].Value);

            }
                profitTextBox.Text = "profit  " + sum.ToString() + " Kshs";
                profitForChartTextBox.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { 
            
            }
        }

        //compute Projected amount transacted.
        public void ProjectedsellingAmount()
        {

            double sum = 0.00;
            for (int i = 0; i < reportStockDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(reportStockDataGridView.Rows[i].Cells[13].Value);

            }

            projectedSellingAmountlabel.Text = "projected total selling amount  " + sum.ToString() + " Kshs";
            projectedSellingAmountTextBox.Text = sum.ToString();
        }
      
        //compute Projected amount transacted.
        public void ProjectedProfitLoss()
        {
            try
            {
                double sum = 0.00;
                for (int i = 0; i < reportStockDataGridView.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(reportStockDataGridView.Rows[i].Cells[14].Value);

                }
                projectedProfitlabel.Text = "projected profit  " + sum.ToString() + " Kshs";
                projProfitTextBox.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        //search drug from stock
        public void searchDrug()
        {
            productNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            productNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select `product`.`name` AS 'name' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` GROUP BY `stock`.`product_id`  ORDER BY `product`.`name` ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String name = r.GetString("name");
                    collection.Add(name);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            productNameTextBox.AutoCompleteCustomSource = collection;

        }

        //search supplier from stock
        public void searchSupplier()
        {
            supplierTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            supplierTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();


                MySqlCommand c = new MySqlCommand("select `supplier`.`name` AS 'name' FROM `supplier` JOIN `stock` ON `supplier`.`id`=`stock`.`supplier_id` GROUP BY `stock`.`supplier_id`  ORDER BY `supplier`.`name` ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String name = r.GetString("name");
                    collection.Add(name);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            supplierTextBox.AutoCompleteCustomSource = collection;

        }


        //search batch number from stock
        public void searchBatch()
        {
            batchNoTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            batchNoTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT batch_no FROM stock ORDER BY batch_no DESC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String batch_no = r.GetString("batch_no");
                    collection.Add(batch_no);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            batchNoTextBox.AutoCompleteCustomSource = collection;

        }

       
        // vIEW STOCK.
        public void viewStock()
        {

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*`stock`.`initial_quantity`) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`)))-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROFIT',(`stock`.`selling_price`*`stock`.`initial_quantity`) AS 'PROJECTED SELLING AMOUNT',((`stock`.`selling_price`*`stock`.`initial_quantity`)-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROJECTED PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id`  ORDER BY `product`.`name` ASC", con);
               
                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("PROJECTED SELLING AMOUNT");
                dataTable.Columns.Add("PROJECTED PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.
                
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                reportStockDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportStockDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            buyingAmount();
            sellingAmount();
            profitLoss();

            ProjectedsellingAmount();
            ProjectedProfitLoss();
        }



        // VIEW STOCK FILTER BY DATE ORDERED.
        public void viewStockFilterByDateOrdered()
        {
            string date = dateDateTimePicker.Value.ToString("yyyy-MM-dd");

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*`stock`.`initial_quantity`) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`)))-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROFIT',(`stock`.`selling_price`*`stock`.`initial_quantity`) AS 'PROJECTED SELLING AMOUNT',((`stock`.`selling_price`*`stock`.`initial_quantity`)-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROJECTED PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM  `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE `stock`.`registered_date`='" + date + "'  ORDER BY `product`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("PROJECTED SELLING AMOUNT");
                dataTable.Columns.Add("PROJECTED PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.
                
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                reportStockDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportStockDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            buyingAmount();
            sellingAmount();
             profitLoss();
             ProjectedsellingAmount();
             ProjectedProfitLoss();
        }

        // VIEW STOCK FILTER BY DATE ORDERED AND SUPPLIER.
        public void viewStockFilterByDateOrderedAndSupplier()
        {
            string date = dateDateTimePicker.Value.ToString("yyyy-MM-dd");

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*`stock`.`initial_quantity`) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`)))-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROFIT',(`stock`.`selling_price`*`stock`.`initial_quantity`) AS 'PROJECTED SELLING AMOUNT',((`stock`.`selling_price`*`stock`.`initial_quantity`)-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROJECTED PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM  `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE (`stock`.`registered_date`='" + date + "' AND  `supplier`.`name`='" + this.supplierTextBox.Text + "')   ORDER BY `product`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("PROJECTED SELLING AMOUNT");
                dataTable.Columns.Add("PROJECTED PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.
                
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                reportStockDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportStockDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            buyingAmount();
            sellingAmount();
             profitLoss();
             ProjectedsellingAmount();
             ProjectedProfitLoss();
        }

        // VIEW STOCK FILTER BY DATE ORDERED AND DRUG.
        public void viewStockFilterByDateOrderedAndDrug()
        {
            string date = dateDateTimePicker.Value.ToString("yyyy-MM-dd");

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*`stock`.`initial_quantity`) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`)))-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROFIT',(`stock`.`selling_price`*`stock`.`initial_quantity`) AS 'PROJECTED SELLING AMOUNT',((`stock`.`selling_price`*`stock`.`initial_quantity`)-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROJECTED PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM  `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE (`stock`.`registered_date`='" + date + "' AND  `product`.`name`='" + this.productNameTextBox.Text + "')   ORDER BY `product`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("PROJECTED SELLING AMOUNT");
                dataTable.Columns.Add("PROJECTED PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                reportStockDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportStockDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            buyingAmount();
            sellingAmount();
             profitLoss();
             ProjectedsellingAmount();
             ProjectedProfitLoss();
        }

        // VIEW STOCK FILTER BY batch no AND DRUG.
        public void viewStockFilterByBatchNoAndDrug()
        {

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*`stock`.`initial_quantity`) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`)))-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROFIT',(`stock`.`selling_price`*`stock`.`initial_quantity`) AS 'PROJECTED SELLING AMOUNT',((`stock`.`selling_price`*`stock`.`initial_quantity`)-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROJECTED PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM  `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE (`stock`.`batch_no`='" + this.batchNoTextBox.Text + "' AND  `product`.`name`='" + this.productNameTextBox.Text + "')   ORDER BY `product`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("PROJECTED SELLING AMOUNT");
                dataTable.Columns.Add("PROJECTED PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.
                
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                reportStockDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportStockDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            buyingAmount();
            sellingAmount();
             profitLoss();
             ProjectedsellingAmount();
             ProjectedProfitLoss();
        }

        // VIEW STOCK FILTER BY DATE ORDERED BETWEEN.
        public void viewStockFilterByDateOrderedBetween()
        {
            string startDate = orderedStartDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = orderdEndDateTimePicker.Value.ToString("yyyy-MM-dd");

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*`stock`.`initial_quantity`) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`)))-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROFIT',(`stock`.`selling_price`*`stock`.`initial_quantity`) AS 'PROJECTED SELLING AMOUNT',((`stock`.`selling_price`*`stock`.`initial_quantity`)-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROJECTED PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM  `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE `stock`.`registered_date` BETWEEN '" + startDate + "' AND '" + endDate + "'   ORDER BY `product`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("PROJECTED SELLING AMOUNT");
                dataTable.Columns.Add("PROJECTED PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.
                
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                reportStockDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportStockDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            buyingAmount();
            sellingAmount();
             profitLoss();
             ProjectedsellingAmount();
             ProjectedProfitLoss();
        }


        // VIEW STOCK FILTER BY DATE ORDERED BETWEEN AND SUPPLIER.
        public void viewStockFilterByDateOrderedBetweenAndSupplier()
        {
            string startDate = orderedStartDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = orderdEndDateTimePicker.Value.ToString("yyyy-MM-dd");

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*`stock`.`initial_quantity`) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`)))-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROFIT',(`stock`.`selling_price`*`stock`.`initial_quantity`) AS 'PROJECTED SELLING AMOUNT',((`stock`.`selling_price`*`stock`.`initial_quantity`)-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROJECTED PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM  `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE ((`stock`.`registered_date` BETWEEN '" + startDate + "' AND '" + endDate + "') AND ( `supplier`.`name`='" + this.supplierTextBox.Text + "'))   ORDER BY `product`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("PROJECTED SELLING AMOUNT");
                dataTable.Columns.Add("PROJECTED PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.
                
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                reportStockDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportStockDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            buyingAmount();
            sellingAmount();
             profitLoss();
             ProjectedsellingAmount();
             ProjectedProfitLoss();
        }

        // VIEW STOCK FILTER BY DATE ORDERED BETWEEN AND DRUG.
        public void viewStockFilterByDateOrderedBetweenAndDrug()
        {
            string startDate = orderedStartDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = orderdEndDateTimePicker.Value.ToString("yyyy-MM-dd");

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*`stock`.`initial_quantity`) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`)))-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROFIT',(`stock`.`selling_price`*`stock`.`initial_quantity`) AS 'PROJECTED SELLING AMOUNT',((`stock`.`selling_price`*`stock`.`initial_quantity`)-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROJECTED PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM  `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE ((`stock`.`registered_date` BETWEEN '" + startDate + "' AND '" + endDate + "') AND ( `product`.`name`='" + this.supplierTextBox.Text + "'))   ORDER BY `product`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("PROJECTED SELLING AMOUNT");
                dataTable.Columns.Add("PROJECTED PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.
                
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                reportStockDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportStockDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            buyingAmount();
            sellingAmount();
             profitLoss();
             ProjectedsellingAmount();
             ProjectedProfitLoss();
        }

        // VIEW STOCK FILTER BY EXPIRY DATE.
        public void viewStockFilterByExpiryDate()
        {
            string date = expiryDateDateTimePicker.Value.ToString("yyyy-MM-dd");

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*`stock`.`initial_quantity`) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`)))-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROFIT',(`stock`.`selling_price`*`stock`.`initial_quantity`) AS 'PROJECTED SELLING AMOUNT',((`stock`.`selling_price`*`stock`.`initial_quantity`)-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROJECTED PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE `stock`.`expiry_date`='" + date + "'   ORDER BY `product`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("PROJECTED SELLING AMOUNT");
                dataTable.Columns.Add("PROJECTED PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.
                
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                reportStockDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportStockDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            buyingAmount();
            sellingAmount();
             profitLoss();
             ProjectedsellingAmount();
             ProjectedProfitLoss();
        }


        // VIEW STOCK FILTER BY EXPIRY DATE  BETWEEN.
        public void viewStockFilterByExpiryDateBetween()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);

            string startDate = expiryStartDateDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = expiryEndDateDateTimePicker.Value.ToString("yyyy-MM-dd");
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*`stock`.`initial_quantity`) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`)))-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROFIT',(`stock`.`selling_price`*`stock`.`initial_quantity`) AS 'PROJECTED SELLING AMOUNT',((`stock`.`selling_price`*`stock`.`initial_quantity`)-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROJECTED PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE `stock`.`expiry_date` BETWEEN '" + startDate + "' AND '" + endDate + "'   ORDER BY `product`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("PROJECTED SELLING AMOUNT");
                dataTable.Columns.Add("PROJECTED PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.
                
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                reportStockDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportStockDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            buyingAmount();
            sellingAmount();
             profitLoss();
             ProjectedsellingAmount();
             ProjectedProfitLoss();
        }


        // VIEW STOCK FILTER BY SUPPLIER.
        public void viewStockFilterBySupplier()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
           try
           {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*`stock`.`initial_quantity`) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`)))-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROFIT',(`stock`.`selling_price`*`stock`.`initial_quantity`) AS 'PROJECTED SELLING AMOUNT',((`stock`.`selling_price`*`stock`.`initial_quantity`)-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROJECTED PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE `supplier`.`name`='" + this.supplierTextBox.Text + "'   ORDER BY  `product`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("PROJECTED SELLING AMOUNT");
                dataTable.Columns.Add("PROJECTED PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.
               
               a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                reportStockDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportStockDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            buyingAmount();
            sellingAmount();
             profitLoss();
             ProjectedsellingAmount();
             ProjectedProfitLoss();
        }


        // VIEW STOCK FILTER BY DRUG.
        public void viewStockFilterByDrug()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*`stock`.`initial_quantity`) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`)))-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROFIT',(`stock`.`selling_price`*`stock`.`initial_quantity`) AS 'PROJECTED SELLING AMOUNT',((`stock`.`selling_price`*`stock`.`initial_quantity`)-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROJECTED PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM  `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE `product`.`name`='" + this.productNameTextBox.Text + "'   ORDER BY  `product`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("PROJECTED SELLING AMOUNT");
                dataTable.Columns.Add("PROJECTED PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                reportStockDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportStockDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            buyingAmount();
            sellingAmount();
             profitLoss();
             ProjectedsellingAmount();
             ProjectedProfitLoss();
        }


        // VIEW STOCK FILTER BY BATCH NUMBER.
        public void viewStockFilterByBatchNumber()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*`stock`.`initial_quantity`) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-(`stock`.`initial_quantity`-`stock`.`quantity_sold`)))-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROFIT',(`stock`.`selling_price`*`stock`.`initial_quantity`) AS 'PROJECTED SELLING AMOUNT',((`stock`.`selling_price`*`stock`.`initial_quantity`)-(`stock`.`buying_price`*`stock`.`initial_quantity`)) AS 'PROJECTED PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED' FROM  `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE `stock`.`batch_no`='" + this.batchNoTextBox.Text + "'   ORDER BY  `product`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("BUYING AMOUNT");
                dataTable.Columns.Add("SELLING AMOUNT");
                dataTable.Columns.Add("PROFIT");
                dataTable.Columns.Add("PROJECTED SELLING AMOUNT");
                dataTable.Columns.Add("PROJECTED PROFIT");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                reportStockDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportStockDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            buyingAmount();
            sellingAmount();
             profitLoss();
             ProjectedsellingAmount();
             ProjectedProfitLoss();
        }

        //print pdf for stock
        public void stockPdf()
        {
            try
            {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\POS\\Reports\\Stock pdf", FileMode.Create));
            doc.Open();//open document to write

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\pos\\Resources\\faith2.png");
            img.ScalePercent(79f);
            // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                                                Stock Report");
            doc.Add(p);
            DateTime time = DateTime.Now;

            Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
            doc.Add(p2);

            //load data from datagrid
            PdfPTable table = new PdfPTable(reportStockDataGridView.Columns.Count);

            //add headers from the datagridview to the table
            for (int j = 0; j < reportStockDataGridView.Columns.Count; j++)
            {

                table.AddCell(new Phrase(reportStockDataGridView.Columns[j].HeaderText));

            }

            //flag the first row as header

            table.HeaderRows = 1;

            //add the actual rows to the table from datagridview

            for (int i = 0; i < reportStockDataGridView.Rows.Count; i++)
            {
                for (int k = 0; k < reportStockDataGridView.Columns.Count; k++)
                {

                    if (reportStockDataGridView[k, i].Value != null)
                    {

                        table.AddCell(new Phrase(reportStockDataGridView[k, i].Value.ToString()));
                    }

                }

            }

            doc.Add(table);
            //end querying from datagrid


            doc.Close();//close document after writting in

            MessageBox.Show("Stock Report generated Successful");

            System.Diagnostics.Process.Start("C:\\POS\\Reports\\Stock pdf");

               }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ","DOCUMENT ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            finally
            { 
            
            }

        }


        //print stock excell.
        public void stockExcell()
        {
            //sqlConnection = new MySqlConnection(databaseConnection);

            try
            {
                DataTable dtCopy = dataTable.Copy();

                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dtCopy);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\POS\\Reports\\Stock.xls", ds);

                MessageBox.Show("Report generated successfully");
                Process sts = System.Diagnostics.Process.Start("C:\\POS\\Reports\\Stock.xls");
                sts.WaitForExit();

                // sqlConnection.Close();


            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ", "DOCUMENT ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }

        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            stockPdf();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            stockExcell();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {

                ChartStock cs = new ChartStock(BuyingAmountTextBox.Text, SellingAmountTextBox.Text, projectedSellingAmountTextBox.Text, profitForChartTextBox.Text, projProfitTextBox.Text);
                cs.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            viewStock();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            viewStockFilterByBatchNoAndDrug();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

            viewStockFilterByDateOrderedAndDrug();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            viewStockFilterByDateOrderedBetweenAndSupplier();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            viewStockFilterByDateOrderedAndDrug();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            viewStockFilterByDateOrderedAndSupplier();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            viewStockFilterByBatchNumber();
        }

        private void batchNoTextBox_TextChanged_1(object sender, EventArgs e)
        {
            viewStockFilterByBatchNumber();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            viewStockFilterByDrug();
        }

        private void productNameTextBox_TextChanged(object sender, EventArgs e)
        {
            viewStockFilterByDrug();
        }

        private void supplierTextBox_TextChanged_1(object sender, EventArgs e)
        {
            viewStockFilterBySupplier();
        }

        private void searchBySupplier_Click(object sender, EventArgs e)
        {
            viewStockFilterBySupplier();
        }

        private void dateDateTimePicker_ValueChanged_1(object sender, EventArgs e)
        {
            viewStockFilterByDateOrderedBetween();
        }

        private void searchDate_Click_1(object sender, EventArgs e)
        {
            viewStockFilterByDateOrderedBetween();
        }

        private void orderdEndDateTimePicker_ValueChanged_1(object sender, EventArgs e)
        {
            viewStockFilterByDateOrderedBetween();
        }

        private void orderedStartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            viewStockFilterByDateOrderedBetween();
        }

        private void searchByDate_Click_1(object sender, EventArgs e)
        {
            viewStockFilterByDateOrderedBetween();
        }

        private void expiryDateDateTimePicker_ValueChanged_1(object sender, EventArgs e)
        {
            viewStockFilterByExpiryDate();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            viewStockFilterByExpiryDate();
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

     



    }
}
