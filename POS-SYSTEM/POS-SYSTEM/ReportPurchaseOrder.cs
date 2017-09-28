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

using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;
using System.Diagnostics;
namespace POS_SYSTEM
{
    public partial class ReportPurchaseOrder : Form
    {
        
        DataTable dataTableOrder;
        public ReportPurchaseOrder(string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            orderListGridView();
            searchSupplier();
            searchDrug();
        }

        private void ReportPurchaseOrder_Load(object sender, EventArgs e)
        {

        }

        //search drug from purchase history.
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


                MySqlCommand c = new MySqlCommand("select product_name AS 'name' FROM `order_price_list_history`  ORDER BY product_name ASC", con);

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


        //search supplier from purchase history.
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


                MySqlCommand c = new MySqlCommand("select supplier_name AS 'name' FROM `order_price_list_history`  ORDER BY supplier_name ASC", con);

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


        // display order price list.
        private void orderListGridView()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `order_price_list_history`.`supplier_name` AS 'SUPPLIER',`order_price_list_history`.`product_name` AS 'PRODUCT',`order_price_list_history`.`price` AS 'PRICE', `order_price_list_history`.`quantity` AS 'QUANTITY',ROUND((`order_price_list_history`.`price`*`order_price_list_history`.`quantity`),2) AS 'TOTAL',`order_price_list_history`.`date_added` AS 'DATE ORDERED',`order_price_list_history`.`added_by` AS 'ORDERED BY' FROM `order_price_list_history`  ORDER BY `order_price_list_history`.`supplier_name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTableOrder = new DataTable();
                // Add autoincrement column.
                dataTableOrder.Columns.Add("#", typeof(int));
                dataTableOrder.PrimaryKey = new DataColumn[] { dataTableOrder.Columns["#"] };
                dataTableOrder.Columns["#"].AutoIncrement = true;
                dataTableOrder.Columns["#"].AutoIncrementSeed = 1;
                dataTableOrder.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dataTableOrder);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTableOrder;
                reportOrderDataGridView.DataSource = bs;

                a.Update(dataTableOrder);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportOrderDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            con.Close();
            getSupplierListAmount();
        }


        // display order price list filter by date.
        private void orderListGridViewFilterByDate()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            string date = dateBorrowedDateTimePicker.Value.ToString("yyyy-MM-dd");
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `order_price_list_history`.`supplier_name` AS 'SUPPLIER',`order_price_list_history`.`product_name` AS 'PRODUCT',`order_price_list_history`.`price` AS 'PRICE', `order_price_list_history`.`quantity` AS 'QUANTITY',ROUND((`order_price_list_history`.`price`*`order_price_list_history`.`quantity`),2) AS 'TOTAL',`order_price_list_history`.`date_added` AS 'DATE ORDERED',`order_price_list_history`.`added_by` AS 'ORDERED BY' FROM `order_price_list_history` WHERE `order_price_list_history`.`date_added`='" + date + "'  ORDER BY `order_price_list_history`.`supplier_name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTableOrder = new DataTable();
                // Add autoincrement column.
                dataTableOrder.Columns.Add("#", typeof(int));
                dataTableOrder.PrimaryKey = new DataColumn[] { dataTableOrder.Columns["#"] };
                dataTableOrder.Columns["#"].AutoIncrement = true;
                dataTableOrder.Columns["#"].AutoIncrementSeed = 1;
                dataTableOrder.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dataTableOrder);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTableOrder;
                reportOrderDataGridView.DataSource = bs;

                a.Update(dataTableOrder);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportOrderDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            con.Close();
            getSupplierListAmount();
        }

        // display order price list filter by date and supplier.
        private void orderListGridViewFilterByDateAndSupplier()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            string date = dateBorrowedDateTimePicker.Value.ToString("yyyy-MM-dd");
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `order_price_list_history`.`supplier_name` AS 'SUPPLIER',`order_price_list_history`.`product_name` AS 'PRODUCT',`order_price_list_history`.`price` AS 'PRICE', `order_price_list_history`.`quantity` AS 'QUANTITY',ROUND((`order_price_list_history`.`price`*`order_price_list_history`.`quantity`),2) AS 'TOTAL',`order_price_list_history`.`date_added` AS 'DATE ORDERED',`order_price_list_history`.`added_by` AS 'ORDERED BY' FROM `order_price_list_history` WHERE (`order_price_list_history`.`date_added`='" + date + "' AND `order_price_list_history`.`supplier_name`='" + this.supplierTextBox.Text + "')  ORDER BY `order_price_list_history`.`supplier_name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTableOrder = new DataTable();
                // Add autoincrement column.
                dataTableOrder.Columns.Add("#", typeof(int));
                dataTableOrder.PrimaryKey = new DataColumn[] { dataTableOrder.Columns["#"] };
                dataTableOrder.Columns["#"].AutoIncrement = true;
                dataTableOrder.Columns["#"].AutoIncrementSeed = 1;
                dataTableOrder.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dataTableOrder);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTableOrder;
                reportOrderDataGridView.DataSource = bs;

                a.Update(dataTableOrder);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportOrderDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            con.Close();
            getSupplierListAmount();
        }


        // display order price list filter by date between.
        private void orderListGridViewFilterByDateBetween()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `order_price_list_history`.`supplier_name` AS 'SUPPLIER',`order_price_list_history`.`product_name` AS 'PRODUCT',`order_price_list_history`.`price` AS 'PRICE', `order_price_list_history`.`quantity` AS 'QUANTITY',ROUND((`order_price_list_history`.`price`*`order_price_list_history`.`quantity`),2) AS 'TOTAL',`order_price_list_history`.`date_added` AS 'DATE ORDERED',`order_price_list_history`.`added_by` AS 'ORDERED BY' FROM `order_price_list_history` WHERE `order_price_list_history`.`date_added` BETWEEN '" + startDate + "' AND '" + endDate + "'  ORDER BY `order_price_list_history`.`supplier_name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTableOrder = new DataTable();
                // Add autoincrement column.
                dataTableOrder.Columns.Add("#", typeof(int));
                dataTableOrder.PrimaryKey = new DataColumn[] { dataTableOrder.Columns["#"] };
                dataTableOrder.Columns["#"].AutoIncrement = true;
                dataTableOrder.Columns["#"].AutoIncrementSeed = 1;
                dataTableOrder.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dataTableOrder);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTableOrder;
                reportOrderDataGridView.DataSource = bs;

                a.Update(dataTableOrder);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportOrderDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            con.Close();
            getSupplierListAmount();
        }

        // display order price list filter by date between and supplier.
        private void orderListGridViewFilterByDateBetweenAndSupplier()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `order_price_list_history`.`supplier_name` AS 'SUPPLIER',`order_price_list_history`.`product_name` AS 'PRODUCT',`order_price_list_history`.`price` AS 'PRICE', `order_price_list_history`.`quantity` AS 'QUANTITY',ROUND((`order_price_list_history`.`price`*`order_price_list_history`.`quantity`),2) AS 'TOTAL',`order_price_list_history`.`date_added` AS 'DATE ORDERED',`order_price_list_history`.`added_by` AS 'ORDERED BY' FROM `order_price_list_history` WHERE ((`order_price_list_history`.`date_added` BETWEEN '" + startDate + "' AND '" + endDate + "') AND (`order_price_list_history`.`supplier_name`='" + this.supplierTextBox.Text + "'))  ORDER BY `order_price_list_history`.`supplier_name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTableOrder = new DataTable();
                // Add autoincrement column.
                dataTableOrder.Columns.Add("#", typeof(int));
                dataTableOrder.PrimaryKey = new DataColumn[] { dataTableOrder.Columns["#"] };
                dataTableOrder.Columns["#"].AutoIncrement = true;
                dataTableOrder.Columns["#"].AutoIncrementSeed = 1;
                dataTableOrder.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dataTableOrder);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTableOrder;
                reportOrderDataGridView.DataSource = bs;

                a.Update(dataTableOrder);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportOrderDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            con.Close();
            getSupplierListAmount();
        }


        // display order price list filter by date.
        private void orderListGridViewFilterByDateMinList()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            string date = minDateTimePicker.Value.ToString("yyyy-MM-dd");
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `min_order_price_list_history`.`supplier_name` AS 'SUPPLIER',`min_order_price_list_history`.`product_name` AS 'PRODUCT',`min_order_price_list_history`.`price` AS 'PRICE', `min_order_price_list_history`.`quantity` AS 'QUANTITY',ROUND((`min_order_price_list_history`.`price`*`min_order_price_list_history`.`quantity`),2) AS 'TOTAL',`min_order_price_list_history`.`date_added` AS 'DATE ORDERED',`min_order_price_list_history`.`added_by` AS 'ORDERED BY' FROM `min_order_price_list_history` WHERE `min_order_price_list_history`.`date_added`='" + date + "'  ORDER BY `min_order_price_list_history`.`supplier_name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTableOrder = new DataTable();
                // Add autoincrement column.
                dataTableOrder.Columns.Add("#", typeof(int));
                dataTableOrder.PrimaryKey = new DataColumn[] { dataTableOrder.Columns["#"] };
                dataTableOrder.Columns["#"].AutoIncrement = true;
                dataTableOrder.Columns["#"].AutoIncrementSeed = 1;
                dataTableOrder.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dataTableOrder);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTableOrder;
                reportOrderDataGridView.DataSource = bs;

                a.Update(dataTableOrder);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportOrderDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            con.Close();
            getSupplierListAmount();
        }

        // display order price list filter by supplier.
        private void orderListGridViewFilterBySupplier()
        {

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `order_price_list_history`.`supplier_name` AS 'SUPPLIER',`order_price_list_history`.`product_name` AS 'PRODUCT',`order_price_list_history`.`price` AS 'PRICE', `order_price_list_history`.`quantity` AS 'QUANTITY',ROUND((`order_price_list_history`.`price`*`order_price_list_history`.`quantity`),2) AS 'TOTAL',`order_price_list_history`.`date_added` AS 'DATE ORDERED',`order_price_list_history`.`added_by` AS 'ORDERED BY' FROM `order_price_list_history` WHERE `order_price_list_history`.`supplier_name`='" + this.supplierTextBox.Text + "'  ORDER BY `order_price_list_history`.`supplier_name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTableOrder = new DataTable();
                // Add autoincrement column.
                dataTableOrder.Columns.Add("#", typeof(int));
                dataTableOrder.PrimaryKey = new DataColumn[] { dataTableOrder.Columns["#"] };
                dataTableOrder.Columns["#"].AutoIncrement = true;
                dataTableOrder.Columns["#"].AutoIncrementSeed = 1;
                dataTableOrder.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dataTableOrder);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTableOrder;
                reportOrderDataGridView.DataSource = bs;

                a.Update(dataTableOrder);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportOrderDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            con.Close();
            getSupplierListAmount();
        }


        // display order price list filter by drug name.
        private void orderListGridViewFilterByDrugName()
        {

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `order_price_list_history`.`supplier_name` AS 'SUPPLIER',`order_price_list_history`.`product_name` AS 'PRODUCT',`order_price_list_history`.`price` AS 'PRICE', `order_price_list_history`.`quantity` AS 'QUANTITY',ROUND((`order_price_list_history`.`price`*`order_price_list_history`.`quantity`),2) AS 'TOTAL',`order_price_list_history`.`date_added` AS 'DATE ORDERED',`order_price_list_history`.`added_by` AS 'ORDERED BY' FROM `order_price_list_history` WHERE `order_price_list_history`.`product_name`='" + this.productNameTextBox.Text + "'  ORDER BY `order_price_list_history`.`supplier_name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTableOrder = new DataTable();
                // Add autoincrement column.
                dataTableOrder.Columns.Add("#", typeof(int));
                dataTableOrder.PrimaryKey = new DataColumn[] { dataTableOrder.Columns["#"] };
                dataTableOrder.Columns["#"].AutoIncrement = true;
                dataTableOrder.Columns["#"].AutoIncrementSeed = 1;
                dataTableOrder.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dataTableOrder);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTableOrder;
                reportOrderDataGridView.DataSource = bs;

                a.Update(dataTableOrder);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(reportOrderDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                // MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY DRUG PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            con.Close();
            getSupplierListAmount();
        }


        public void getSupplierListAmount()
        {
            double sum = 0.00;
            for (int i = 0; i < reportOrderDataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(reportOrderDataGridView.Rows[i].Cells[5].Value);

            }
            //string amt = "amount  "+sum.ToString();
            allSupplierToTalAmountLabel.Text = "  " + sum.ToString() + " Kshs";
        }

        //print pdf for order price list.
        public void orderPriceList()
        {

            try
            {

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\POS\\Reports\\Order List pdf", FileMode.Create));
            doc.Open();//open document to write

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\pos\\Resources\\faith2.png");
            img.ScalePercent(79f);
            // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                                           Order List");
            doc.Add(p);
            DateTime time = DateTime.Now;

            Paragraph p2 = new Paragraph("   Supplier  " + this.supplierTextBox.Text + "             Amount " + this.allSupplierToTalAmountLabel.Text + "      Produced On     " + time.ToString() + "        \n\n");
            doc.Add(p2);


            //load data from datagrid
            PdfPTable table = new PdfPTable(reportOrderDataGridView.Columns.Count);

            //add headers from the datagridview to the table
            for (int j = 0; j < reportOrderDataGridView.Columns.Count; j++)
            {

                table.AddCell(new Phrase(reportOrderDataGridView.Columns[j].HeaderText));

            }

            //flag the first row as header

            table.HeaderRows = 1;

            //add the actual rows to the table from datagridview

            for (int i = 0; i < reportOrderDataGridView.Rows.Count; i++)
            {
                for (int k = 0; k < reportOrderDataGridView.Columns.Count; k++)
                {

                    if (reportOrderDataGridView[k, i].Value != null)
                    {

                        table.AddCell(new Phrase(reportOrderDataGridView[k, i].Value.ToString()));
                    }

                }

            }

            doc.Add(table);
            //end querying from datagrid


            doc.Close();//close document after writting in

            MessageBox.Show("Order List Report generated Successfully");

            System.Diagnostics.Process.Start("C:\\POS\\Reports\\Order List pdf");

               }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ","DOCUMENT ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            finally
            { 
            
            }

        }


        private void button10_Click_1(object sender, EventArgs e)
        {
            orderListGridView();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            orderListGridViewFilterByDateBetweenAndSupplier();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            orderListGridViewFilterByDateAndSupplier();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            orderListGridViewFilterByDrugName();
        }

        private void productNameTextBox_TextChanged(object sender, EventArgs e)
        {
            orderListGridViewFilterByDrugName();
        }

        private void supplierTextBox_TextChanged_1(object sender, EventArgs e)
        {
            orderListGridViewFilterBySupplier();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            orderListGridViewFilterBySupplier();
        }

        private void searchByDate_Click_1(object sender, EventArgs e)
        {
            orderListGridViewFilterByDateBetween();
        }

        private void endDateTimePicker_ValueChanged_1(object sender, EventArgs e)
        {
            orderListGridViewFilterByDateBetween();
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            orderListGridViewFilterByDateBetween();
        }

        private void minDateTimePicker_ValueChanged_1(object sender, EventArgs e)
        {
            orderListGridViewFilterByDateMinList();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            orderListGridViewFilterByDateMinList();
        }

        private void dateBorrowedDateTimePicker_ValueChanged_1(object sender, EventArgs e)
        {
            orderListGridViewFilterByDate();
        }

        private void searchDate_Click_1(object sender, EventArgs e)
        {
            orderListGridViewFilterByDate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            orderPriceList();
        }



    }
}
