
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
    public partial class ExpenseType : Form
    {
        MySqlConnection con = null;
        DialogResult dialog;
        public ExpenseType(string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            con = DBHandler.CreateConnection();
            expenseTypeView();
            searchExpenseType();
        }

        private void ExpenseType_Load(object sender, EventArgs e)
        {

        }

    //search expense type
        public void searchExpenseType()
        {
           
            searchExpenseTypetextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchExpenseTypetextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            try
            {
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM expense_type", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string form_name = r.GetString("type");
                    collection.Add(form_name);

                }

                con.Close();
            }
            catch (Exception) { 
            
            }
            
            searchExpenseTypetextBox.AutoCompleteCustomSource = collection;
            
        }


        // Get expense type data in fields.
        public void showExpenseTypeData()
        {
            try
            {
               // MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM expense_type WHERE type='" + this.searchExpenseTypetextBox.Text + "'", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string drug_form_id = r.GetString("expense_type_id");
                    string form_name = r.GetString("type");

                    expenseTypeIDTextBox.Text = drug_form_id;
                    expenseTypeTextBox.Text = form_name;

                }
                con.Close();
            }
            catch (Exception) { 
            }
            
        }

        private void update_Click(object sender, System.EventArgs e)
        {
               if (expenseTypeTextBox.Text == string.Empty || expenseTypeIDTextBox.Text == string.Empty || searchExpenseTypetextBox.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "EXPENSE TYPE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {
                   // MySqlConnection con = new MySqlConnection(db);
                    con.Open();

                    dialog = MessageBox.Show("Are you sure you want to update the expense type?", "EXPENSE TYPE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        DateTime dt = DateTime.Now;
                        string dateNow = dt.ToString("yyyy-MM-dd");

                        MySqlCommand c = new MySqlCommand("UPDATE expense_type SET type='" + this.expenseTypeTextBox.Text + "' WHERE expense_type_id='" + this.expenseTypeIDTextBox.Text + "' ", con);
                        c.ExecuteNonQuery();
                        MessageBox.Show("Expense type updated successfully...............!", "EXPENSE TYPE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                    }
                    con.Close();
                    expenseTypeView();
                    
                }
                catch (Exception )
                {
                   MessageBox.Show("Error has occured while updating expense type............!", "EXPENSE TYPE ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                searchExpenseType();
            }
        }

 // View expense type.
        public void expenseTypeView() {

           
            try
            {
                con.Open();
               
                MySqlCommand com = new MySqlCommand("SELECT `expense_type`.`type` AS 'EXPENSE TYPE' FROM `expense_type`  ORDER BY `expense_type`.`type` ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(int));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                drugFormdataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(drugFormdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Error has occured while displaying drug form............!", "DRUG FORM DETAILS DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            
        }


     // Clear fields.
        private void clearFields() {
            expenseTypeTextBox.Text = string.Empty;
            expenseTypeIDTextBox.Text = string.Empty;
            searchExpenseTypetextBox.Text = string.Empty;
        }

        private void save_Click(object sender, System.EventArgs e)
        {
             if (expenseTypeTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "EXPENSE TYPE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {

                    dialog = MessageBox.Show("Are you sure you want to add the expense type?", "EXPENSE TYPE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        con.Open();


                        MySqlCommand c = new MySqlCommand("INSERT INTO expense_type VALUES(NULL,'" + this.expenseTypeTextBox.Text + "')", con);
                        c.ExecuteNonQuery();
                        MessageBox.Show("Expense type registered successfully...............!", "EXPENSE TYPE ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        expenseTypeView();
                        clearFields();
                    }


                }
                catch (Exception )
                {
                   MessageBox.Show("Error has occured while adding expense type............!", "EXPENSE TYPE ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                searchExpenseType();
            }
            clearFields();
        }

        private void searchExpenseTypetextBox_TextChanged(object sender, EventArgs e)
        {
            showExpenseTypeData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showExpenseTypeData();
        }



    }
}

