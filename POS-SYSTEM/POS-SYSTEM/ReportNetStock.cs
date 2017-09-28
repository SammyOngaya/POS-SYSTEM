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
    public partial class ReportNetStock : Form
    {
        DataTable dataTable;

        public ReportNetStock(string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            searchProduct();
            netStockView();
        }

        private void ReportNetStock_Load(object sender, EventArgs e)
        {

        }





        //compute remaining Quantity transacted.
        public void RemainingQuantity()
        {
            try
            {
                double sum = 0.00;
                for (int i = 0; i < viewNetStockdataGridView.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(viewNetStockdataGridView.Rows[i].Cells[8].Value);

                }

                remainingQuantityLabel.Text = "remaining quantity  " + sum.ToString() + " ";
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }

        //compute amount transacted.
        public void TotalBuyingAmount()
        {
            try
            {
                double sum = 0.00;
                for (int i = 0; i < viewNetStockdataGridView.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(viewNetStockdataGridView.Rows[i].Cells[10].Value);

                }

                TotalBuyingAmountLabel.Text = "total buying amount  " + sum.ToString() + " Kshs";
                BuyingAmountTextBox.Text = sum.ToString();
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }
        //compute amount transacted.
        public void TotalSellingAmount()
        {
            try
            {
                double sum = 0.00;
                for (int i = 0; i < viewNetStockdataGridView.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(viewNetStockdataGridView.Rows[i].Cells[11].Value);

                }

                TotalSellingAmountLabel.Text = "total selling amount  " + sum.ToString() + " Kshs";
                SellingAmountTextBox.Text = sum.ToString();
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }
        //compute amount transacted.
        public void TotalPproffitAmount()
        {

            try
            {
                double sum = 0.00;
                for (int i = 0; i < viewNetStockdataGridView.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(viewNetStockdataGridView.Rows[i].Cells[12].Value);

                }

                ProfitAmountLabel.Text = "total profit  " + sum.ToString() + " Kshs";
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


        // Search product.
        public void searchProduct()
        {
            searchProductTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchProductTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);

                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");

                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `product`.`name` AS 'product_name' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` WHERE ((`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0) AND (`stock`.`status`='1')) GROUP BY `stock`.`product_id` ORDER BY `product`.`name` ASC", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString("product_name");
                    collection.Add(name);
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while searching product details............!", "PRODUCT DETAILS SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

            searchProductTextBox.AutoCompleteCustomSource = collection;

        }// End search product.


        public void searchNetStockView()
        {

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {

                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`)) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`)) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`))-(`stock`.`buying_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED',`stock`.`reoder_level` AS 'RE-ODER LEVEL' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE ((`stock`.`status`=1) AND ( `product`.`name`='" + this.searchProductTextBox.Text + "') AND  (`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0) ) ORDER BY `product`.`name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(int));
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
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("RE-ODER LEVEL");
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                viewNetStockdataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewNetStockdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TotalBuyingAmount();
            TotalSellingAmount();
            TotalPproffitAmount();
            RemainingQuantity();
        }

        public void netStockView()
        {

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);

            try
            {
                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`buying_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`)) AS 'BUYING AMOUNT',(`stock`.`selling_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`)) AS 'SELLING AMOUNT',((`stock`.`selling_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`))-(`stock`.`buying_price`*(`stock`.`initial_quantity`-`stock`.`quantity_sold`))) AS 'PROFIT', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED',`stock`.`reoder_level` AS 'RE-ODER LEVEL' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE ((`stock`.`status`=1) AND (`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0))  ORDER BY `product`.`name` ASC", con);
                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(int));
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
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("RE-ODER LEVEL");
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                viewNetStockdataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewNetStockdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TotalBuyingAmount();
            TotalSellingAmount();
            TotalPproffitAmount();
            RemainingQuantity();
        }



        //print pdf for net stock
        public void netStockPdf()
        {
            try
            {

                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
                PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\POS\\Reports\\Net Stock pdf", FileMode.Create));
                doc.Open();//open document to write

                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\pos\\Resources\\faith2.png");
                img.ScalePercent(79f);
                // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



                doc.Add(img); //add image to document
                Paragraph p = new Paragraph("                                                               Net Stock Report");
                doc.Add(p);
                DateTime time = DateTime.Now;

                Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
                doc.Add(p2);


                //load data from datagrid
                PdfPTable table = new PdfPTable(viewNetStockdataGridView.Columns.Count);

                //add headers from the datagridview to the table
                for (int j = 0; j < viewNetStockdataGridView.Columns.Count; j++)
                {

                    table.AddCell(new Phrase(viewNetStockdataGridView.Columns[j].HeaderText));

                }

                //flag the first row as header

                table.HeaderRows = 1;

                //add the actual rows to the table from datagridview

                for (int i = 0; i < viewNetStockdataGridView.Rows.Count; i++)
                {
                    for (int k = 0; k < viewNetStockdataGridView.Columns.Count; k++)
                    {

                        if (viewNetStockdataGridView[k, i].Value != null)
                        {

                            table.AddCell(new Phrase(viewNetStockdataGridView[k, i].Value.ToString()));
                        }

                    }

                }

                doc.Add(table);
                //end querying from datagrid


                doc.Close();//close document after writting in

                MessageBox.Show("Net Stock Report generated Successful");

                System.Diagnostics.Process.Start("C:\\POS\\Reports\\Net Stock pdf");

            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ", "DOCUMENT ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }

        }

        //print net stock excel.
        public void netStockExcel()
        {
            //sqlConnection = new MySqlConnection(databaseConnection);

            try
            {
                DataTable dtCopy = dataTable.Copy();

                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dtCopy);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\POS\\Reports\\Net Stock.xls", ds);

                MessageBox.Show("Report generated successfully");
                Process sts = System.Diagnostics.Process.Start("C:\\POS\\Reports\\Net Stock.xls");
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



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                ChartNetStock cs = new ChartNetStock(BuyingAmountTextBox.Text, SellingAmountTextBox.Text, profitForChartTextBox.Text);
                cs.ShowDialog();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            netStockView();
        }

        
        private void searchSupplierPriceListButton_Click(object sender, EventArgs e)
        {
            searchNetStockView();
        }

        private void netStockPdfReport_Click(object sender, EventArgs e)
        {
            netStockPdf();
        }

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            netStockExcel();
        }

        private void searchProductTextBox_TextChanged_1(object sender, EventArgs e)
        {
            searchNetStockView();
        }
    }
}
