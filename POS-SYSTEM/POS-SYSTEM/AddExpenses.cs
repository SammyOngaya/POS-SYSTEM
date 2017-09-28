using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POS_SYSTEM
{
    public partial class AddExpenses : Form
    {
        DialogResult dialog;

        public AddExpenses(string databaseString, string pfn)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            addStaffpfsession.Text = pfn;
            addExpenseView();
            expenseTypeCombo();
        }

        private void AddExpenses_Load(object sender, EventArgs e)
        {

        }


 public void addExpenseView()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // MessageBox.Show("Error has occured while displaying expenses details ............!", "EXPENSES DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
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

                MySqlCommand c = new MySqlCommand("SELECT type FROM expense_type ORDER BY type ASC ", con);

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


        // Clear fields.
        public void clearFields()
        {
            addEexpenseTypeCombo.Text = string.Empty;
            addAmountTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
            addExpenseTextBox.Text = string.Empty;
            addDate.Text = string.Empty;
            expenseTypeIdforeignkey.Text = string.Empty;

        }

        private void saveStock_Click(object sender, System.EventArgs e)
        {
            string db = databaseConnectionStringTextBox.Text;
            if (addEexpenseTypeCombo.Text == string.Empty || addAmountTextBox.Text == string.Empty || descriptionTextBox.Text == string.Empty || addExpenseTextBox.Text == string.Empty || addDate.Text == string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "EXPENSE REGISTRATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    string date = addDate.Value.ToString("yyyy-MM-dd");

                    dialog = MessageBox.Show("Are you sure you want to add the expense ?", "EXPENSE REGISTRATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();
                        DateTime dt = DateTime.Now;
                        string dateNow = dt.ToString("yyyy-MM-dd");

                        MySqlCommand c = new MySqlCommand("INSERT INTO expenses VALUES(NULL,'" + this.addExpenseTextBox.Text + "','" + this.expenseTypeIdforeignkey.Text + "','" + this.descriptionTextBox.Text + "','" + this.addAmountTextBox.Text + "','" + date + "','1','" + this.addStaffpfsession.Text + "')", con);
                        c.ExecuteNonQuery();


                        MessageBox.Show("Expense registered successfully...............!", "EXPENSE REGISTRATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con.Close();
                        addExpenseView();
                        clearFields();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error has occured while registering expense details. Please check if you have entered all the fields ...........!", "EXPENSE DETAILS REGISTRATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }

            }
        }

        private void cancelStock_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void addEexpenseTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            expenseTypeForeignKey();
        }


    }
}



