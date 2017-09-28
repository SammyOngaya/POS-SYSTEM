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
    public partial class ViewExpenses : Form
    {
        public ViewExpenses(string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;

            addExpenseView();
            searchExpenses();
            searchAmount();
            searchType();

            expenseTypeCombo();
        }

        DataTable dataTable ;

        private void ViewExpenses_Load(object sender, EventArgs e)
        {

        }

  //compute amount transacted.
        public void TotalBuyingAmount()
        {
            try
            {
                double sum = 0.00;
                for (int i = 0; i < addExpenseDataGridView.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(addExpenseDataGridView.Rows[i].Cells[4].Value);

                }

                TotalBuyingAmountLabel.Text = "Total Expense  " + sum.ToString() + " Kshs";
                }
            catch (Exception)
            {
            }
            finally
            {
            }
        }




        //search name from expenses
        public void searchExpenses()
        {
            string db = databaseConnectionStringTextBox.Text;
            expenseNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            expenseNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT `expenses`.`expense_name` AS 'name' FROM expenses ORDER BY `expense_name` ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string name = r.GetString("name");
                    collection.Add(name);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            expenseNameTextBox.AutoCompleteCustomSource = collection;

        }

        //search amount from expenses
        public void searchAmount()
        {
            string db = databaseConnectionStringTextBox.Text;

            amountTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            amountTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT amount AS 'amount' FROM `expenses`  ORDER BY amount ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string name = r.GetString("amount");
                    collection.Add(name);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            amountTextBox.AutoCompleteCustomSource = collection;

        }

        //search expense type from sales
        public void searchType()
        {

            string db = databaseConnectionStringTextBox.Text;
            addEexpenseTypeCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            addEexpenseTypeCombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT type FROM `expense_type` JOIN `expenses` ON `expense_type`.`expense_type_id`=`expenses`.`expense_type_id` GROUP BY `expenses`.`expense_type` ORDER BY type ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string serial = r.GetString("type");
                    collection.Add(serial);

                }
                con.Close();
            }
            catch (Exception)
            {
            }
            addEexpenseTypeCombo.AutoCompleteCustomSource = collection;

        }



        public void addExpenseView()
        {
            string db = databaseConnectionStringTextBox.Text;
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `expenses`.`expense_id` AS 'EXPENSE ID', `expenses`.`expense_name` AS 'EXPENSE',`expense_type`.`type` AS 'TYPE',`expenses`.`amount` AS 'AMOUNT',`expenses`.`description` AS 'DESCRIPTION',`expenses`.`expense_date` AS 'DATE' FROM `expense_type` JOIN `expenses` ON `expense_type`.`expense_type_id`=`expenses`.`expense_type_id` WHERE `expenses`.`status`='1' ORDER BY `expenses`.`expense_name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("EXPENSE ID");
                dataTable.Columns.Add("EXPENSE");
                dataTable.Columns.Add("TYPE");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("DESCRIPTION");
                dataTable.Columns.Add("DATE", typeof(string));
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                addExpenseDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addExpenseDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying expenses details ............!", "EXPENSES DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            TotalBuyingAmount();
        }

        public void addExpenseViewFilterByDate()
        {
            string db = databaseConnectionStringTextBox.Text;
            string date = dateDateTimePicker.Value.ToString("yyyy-MM-dd");
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `expenses`.`expense_id` AS 'EXPENSE ID', `expenses`.`expense_name` AS 'EXPENSE',`expense_type`.`type` AS 'TYPE',`expenses`.`amount` AS 'AMOUNT',`expenses`.`description` AS 'DESCRIPTION',`expenses`.`expense_date` AS 'DATE' FROM `expense_type` JOIN `expenses` ON `expense_type`.`expense_type_id`=`expenses`.`expense_type_id` WHERE expense_date='" + date + "' ORDER BY `expenses`.`expense_date` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("EXPENSE ID");
                dataTable.Columns.Add("EXPENSE");
                dataTable.Columns.Add("TYPE");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("DESCRIPTION");
                dataTable.Columns.Add("DATE", typeof(string));
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                addExpenseDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addExpenseDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying expenses details ............!", "EXPENSES DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            TotalBuyingAmount();
        }



        public void addExpenseViewFilterByDateRange()
        {
            string db = databaseConnectionStringTextBox.Text;

            string startDate = startDateTimePicker.Value.ToString("yyyy-MM-dd");
            string endDate = endDateTimePicker.Value.ToString("yyyy-MM-dd");

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `expenses`.`expense_id` AS 'EXPENSE ID',`expenses`.`expense_name` AS 'EXPENSE',`expense_type`.`type` AS 'TYPE',`expenses`.`amount` AS 'AMOUNT',`expenses`.`description` AS 'DESCRIPTION',`expenses`.`expense_date` AS 'DATE' FROM `expense_type` JOIN `expenses` ON `expense_type`.`expense_type_id`=`expenses`.`expense_type_id` WHERE expense_date BETWEEN '" + startDate + "' AND '" + endDate + "' ORDER BY `expenses`.`expense_date` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("EXPENSE ID");
                dataTable.Columns.Add("EXPENSE");
                dataTable.Columns.Add("TYPE");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("DESCRIPTION");
                dataTable.Columns.Add("DATE", typeof(string));
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                addExpenseDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addExpenseDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying expenses details ............!", "EXPENSES DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            TotalBuyingAmount();
        }

        public void addExpenseViewFilterByAmount()
        {
            string db = databaseConnectionStringTextBox.Text;
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `expenses`.`expense_id` AS 'EXPENSE ID', `expenses`.`expense_name` AS 'EXPENSE',`expense_type`.`type` AS 'TYPE',`expenses`.`amount` AS 'AMOUNT',`expenses`.`description` AS 'DESCRIPTION',`expenses`.`expense_date` AS 'DATE' FROM `expense_type` JOIN `expenses` ON `expense_type`.`expense_type_id`=`expenses`.`expense_type_id` WHERE amount='" + this.amountTextBox.Text + "' ORDER BY `expenses`.`amount` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("EXPENSE ID");
                dataTable.Columns.Add("EXPENSE");
                dataTable.Columns.Add("TYPE");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("DESCRIPTION");
                dataTable.Columns.Add("DATE", typeof(string));
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                addExpenseDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addExpenseDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying expenses details ............!", "EXPENSES DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            TotalBuyingAmount();
        }

        public void addExpenseViewFilterByType()
        {
            string db = databaseConnectionStringTextBox.Text;
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `expenses`.`expense_id` AS 'EXPENSE ID', `expenses`.`expense_name` AS 'EXPENSE',`expense_type`.`type` AS 'TYPE',`expenses`.`amount` AS 'AMOUNT',`expenses`.`description` AS 'DESCRIPTION',`expenses`.`expense_date` AS 'DATE' FROM `expense_type` JOIN `expenses` ON `expense_type`.`expense_type_id`=`expenses`.`expense_type_id` WHERE type='" + this.addEexpenseTypeCombo.Text + "' ORDER BY `type` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("EXPENSE ID");
                dataTable.Columns.Add("EXPENSE");
                dataTable.Columns.Add("TYPE");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("DESCRIPTION");
                dataTable.Columns.Add("DATE", typeof(string));
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                addExpenseDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addExpenseDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying expenses details ............!", "EXPENSES DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            TotalBuyingAmount();
        }

        public void addExpenseViewFilterByName()
        {
            string db = databaseConnectionStringTextBox.Text;
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `expenses`.`expense_id` AS 'EXPENSE ID', `expenses`.`expense_name` AS 'EXPENSE',`expense_type`.`type` AS 'TYPE',`expenses`.`amount` AS 'AMOUNT',`expenses`.`description` AS 'DESCRIPTION',`expenses`.`expense_date` AS 'DATE' FROM `expense_type` JOIN `expenses` ON `expense_type`.`expense_type_id`=`expenses`.`expense_type_id` WHERE expense_name='" + this.expenseNameTextBox.Text + "' ORDER BY `expenses`.`expense_name` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("EXPENSE ID");
                dataTable.Columns.Add("EXPENSE");
                dataTable.Columns.Add("TYPE");
                dataTable.Columns.Add("AMOUNT");
                dataTable.Columns.Add("DESCRIPTION");
                dataTable.Columns.Add("DATE", typeof(string));
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                addExpenseDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addExpenseDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying expenses details ............!", "EXPENSES DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            TotalBuyingAmount();
        }

        //populate expense combo
        public void expenseTypeCombo()
        {
            string db = databaseConnectionStringTextBox.Text;
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT `type` FROM expense_type JOIN expenses ON `expense_type`.`expense_type_id`=`expenses`.`expense_type_id` GROUP BY `expenses`.`expense_type_id` ORDER BY type ASC ", con);

                MySqlDataReader m = c.ExecuteReader();

                while (m.Read())
                {
                    string l = m.GetString("type");
                    addEexpenseTypeCombo.Items.Add(l);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //print pdf for expenses
        public void expensePdf()
        {

            try
            {

                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
                PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\POS\\Reports\\EXPENSES REPORT", FileMode.Create));
                doc.Open();//open document to write
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\POS\\Resources\\faith2.png");
                img.ScalePercent(79f);
                // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



                doc.Add(img); //add image to document
                Paragraph p = new Paragraph("                                                                Expenses Report");
                doc.Add(p);
                DateTime time = DateTime.Now;

                Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
                doc.Add(p2);


                //load data from datagrid
                PdfPTable table = new PdfPTable(addExpenseDataGridView.Columns.Count);

                //add headers from the datagridview to the table
                for (int j = 0; j < addExpenseDataGridView.Columns.Count; j++)
                {

                    table.AddCell(new Phrase(addExpenseDataGridView.Columns[j].HeaderText));

                }

                //flag the first row as header

                table.HeaderRows = 1;

                //add the actual rows to the table from datagridview

                for (int i = 0; i < addExpenseDataGridView.Rows.Count; i++)
                {
                    for (int k = 0; k < addExpenseDataGridView.Columns.Count; k++)
                    {

                        if (addExpenseDataGridView[k, i].Value != null)
                        {

                            table.AddCell(new Phrase(addExpenseDataGridView[k, i].Value.ToString()));
                        }

                    }

                }

                doc.Add(table);
                //end querying from datagrid


                doc.Close();//close document after writting in

                MessageBox.Show("Expenses Report generated Successful");

                System.Diagnostics.Process.Start("C:\\POS\\Reports\\EXPENSES REPORT");

            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ", "DOCUMENT ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }

        }


        //print expenses excell.
        public void expenseExcel()
        {
            try
            {
                dataTable = new DataTable();

                DataTable dtCopy = dataTable.Copy();

                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dtCopy);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\POS\\Reports\\EXPENSES REPORT.xls", ds);

                MessageBox.Show("Report generated successfully");
                Process sts = System.Diagnostics.Process.Start("C:\\POS\\Reports\\EXPENSES REPORT.xls");
                sts.WaitForExit();


            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);
                MessageBox.Show("Unable to open the report ", "DOCUMENT ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            addExpenseView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            expenseExcel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            expensePdf();
        }

        private void expenseNameTextBox_TextChanged(object sender, EventArgs e)
        {
            addExpenseViewFilterByName();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addExpenseViewFilterByName();
        }

        private void addEexpenseTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            addExpenseViewFilterByType();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addExpenseViewFilterByType();
        }

        private void amountTextBox_TextChanged(object sender, EventArgs e)
        {
            addExpenseViewFilterByAmount();
        }

        private void searchByDriverID_Click(object sender, EventArgs e)
        {
            addExpenseViewFilterByAmount();
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            addExpenseViewFilterByDateRange();
        }

        private void endDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            addExpenseViewFilterByDateRange();
        }

        private void searchByDate_Click(object sender, EventArgs e)
        {
            addExpenseViewFilterByDateRange();
        }

        private void dateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            addExpenseViewFilterByDate();
        }

        private void searchDate_Click(object sender, EventArgs e)
        {
            addExpenseViewFilterByDate();
        }


    }
}

