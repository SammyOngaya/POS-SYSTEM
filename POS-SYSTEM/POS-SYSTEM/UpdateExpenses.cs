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
    public partial class UpdateExpenses : Form
    { 
        DataTable dataTable;
        DialogResult dialog;
        public UpdateExpenses(string databaseString, string pfn)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;

            addStaffpfsession.Text = pfn;
            addExpenseView();
            expenseTypeCombo();
            searchExpenses();
            searchExpenseID();
        }

        private void UpdateExpenses_Load(object sender, EventArgs e)
        {

        }

        private void updateStockButton_Click(object sender, System.EventArgs e)
        {
            string db = databaseConnectionStringTextBox.Text;
            if (addEexpenseTypeCombo.Text == string.Empty || addAmountTextBox.Text == string.Empty || descriptionTextBox.Text == string.Empty || addExpenseTextBox.Text == string.Empty || addDate.Text == string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "EXPENSE MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    string date = addDate.Value.ToString("yyyy-MM-dd");

                    dialog = MessageBox.Show("Are you sure you want to update the expense ?", "EXPENSE MODIFICATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();
                        DateTime dt = DateTime.Now;
                        string dateNow = dt.ToString("yyyy-MM-dd");

                        MySqlCommand c = new MySqlCommand("UPDATE expenses SET expense_name='" + this.addExpenseTextBox.Text + "',expense_type_id='" + this.expenseTypeIdforeignkey.Text + "', description='" + this.descriptionTextBox.Text + "',amount='" + this.addAmountTextBox.Text + "', expense_date='" + date + "',status='"+this.statusComboBox.Text+"', pfno='"+ this.addStaffpfsession.Text +"' WHERE expense_id='"+this.ExpenseIDTextBox.Text+"' ", con);
                        c.ExecuteNonQuery();


                        MessageBox.Show("Expense updated successfully...............!", "EXPENSE MODIFICATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con.Close();
                        addExpenseView();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Error has occured while updating expense details. Please check if you have entered all the fields ...........!", "EXPENSE DETAILS MODIFICATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }

            }
        }



        //filter database
        public void filterDatabase()
        {
            dataTable = new DataTable();
            DataView dv = new DataView(dataTable);
            dv.RowFilter = string.Format("EXPENSE LIKE '%{0}%'", expenseNameTextBox.Text);
            addExpenseDataGridView.DataSource = dv;
        }

        private void UpdateExpense_Load(object sender, EventArgs e)
        {

        }



        //search expense id from expenses
        public void searchExpenseID()
        {
            string db = databaseConnectionStringTextBox.Text;

            searchExpenseIDTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchExpenseIDTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {

                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select `expense_id` from expenses ", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string l = r.GetString("expense_id");
                    collection.Add(l);


                }
                con.Close();
            }
            catch (Exception)
            {

            }
            searchExpenseIDTextBox.AutoCompleteCustomSource = collection;


        }


        // Fill data in fields.
        public void showStockDataFilterByExpenseIDOnly()
        {
            string db = databaseConnectionStringTextBox.Text;

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT `expenses`.`expense_id`, `expense_type`.`expense_type_id`,`expenses`.`expense_name`,`expenses`.`description`,`expenses`.`amount`,`expense_type`.`type`,`expenses`.`expense_date`,`expenses`.`status` FROM expense_type JOIN expenses on `expense_type`.`expense_type_id`=`expenses`.`expense_type_id` WHERE (expense_id='" + this.searchExpenseIDTextBox.Text + "' )", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {

                    string expenseID = r.GetString("expense_id");
                    string expenseName = r.GetString("expense_name");
                    string description = r.GetString("description");
                    string type = r.GetString("type");
                    string expense_date = r.GetString("expense_date");
                    string status = r.GetString("status");
                    string amount = r.GetString("amount");
                    string expense_type_id = r.GetString("expense_type_id");
                    
                    addExpenseTextBox.Text = expenseName;
                    addEexpenseTypeCombo.Text = type;
                    addAmountTextBox.Text = amount;
                    addDate.Text = expense_date;
                    descriptionTextBox.Text = description;
                    statusComboBox.Text = status;
                    expenseTypeIdforeignkey.Text = expense_type_id;
                    ExpenseIDTextBox.Text = expenseID;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        // Clear fields.
        public void clearFields()
        {
            addEexpenseTypeCombo.Text = string.Empty;
            addAmountTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
            addExpenseTextBox.Text = string.Empty;
            addDate.Text = string.Empty;
            expenseTypeIdforeignkey.Text = string.Empty;
            ExpenseIDTextBox.Text = string.Empty;
            searchExpenseIDTextBox.Text = string.Empty;
            expenseNameTextBox.Text = string.Empty;

        }


        public void addExpenseView()
        {
            string db = databaseConnectionStringTextBox.Text;
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `expenses`.`expense_id` AS 'EXPENSE ID',`expenses`.`expense_name` AS 'EXPENSE',`expense_type`.`type` AS 'TYPE',`expenses`.`amount` AS 'AMOUNT',`expenses`.`description` AS 'DESCRIPTION',`expenses`.`expense_date` AS 'DATE' FROM `expense_type` JOIN `expenses` ON `expense_type`.`expense_type_id`=`expenses`.`expense_type_id` WHERE `expenses`.`status`='1' ORDER BY `expenses`.`expense_name` ASC", con);

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
        }


        public void SearchByNameExpenseViewFilterByName()
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

        }


        //populate expense combo
        public void expenseTypeCombo()
        {
            string db = databaseConnectionStringTextBox.Text;
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM expense_type ORDER BY type ASC ", con);

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

        //fetch id from expense type and use the foreign key
        public void expenseTypeForeignKey()
        {
            string db = databaseConnectionStringTextBox.Text;
            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT `expense_type_id` FROM expense_type WHERE (type='" + this.addEexpenseTypeCombo.Text + "' )", con);
                MySqlDataReader n = mc.ExecuteReader();

                while (n.Read())
                {
                    string supid = n.GetString("expense_type_id");
                    expenseTypeIdforeignkey.Text = supid;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void addEexpenseTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            expenseTypeForeignKey();
        }

        private void expenseNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchByNameExpenseViewFilterByName();
        }

        private void cancelStock_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addExpenseView();
        }

        private void searchExpenseIDTextBox_TextChanged(object sender, EventArgs e)
        {
            showStockDataFilterByExpenseIDOnly();
        }


    }
}



