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
    public partial class AddProduct : Form
    {
        public AddProduct(string pfn, string databaseString)
        {
            InitializeComponent(); 
            databaseConnectionStringTextBox.Text = databaseString;
            productPfsession.Text = pfn;
            addProductView();
            productCombo();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {

        }

        DialogResult dialog;

        //populate drug combo
        public void productCombo()
        {
             try
             {
                 string db = databaseConnectionStringTextBox.Text;
                 MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM product_form", con);

                MySqlDataReader mm = c.ExecuteReader();

                while (mm.Read())
                {
                    string form_name = mm.GetString("form_name");
                    productform.Items.Add(form_name);

                } 
                 con.Close();
            }
            catch (Exception) { 
            
            }
            
        }

       

        //clear fields
        public void clearFields() {
            productname.Text = string.Empty;
            productform.Text = string.Empty;
            statusComboBox.Text = string.Empty;
        }

        public void addProductView()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);

                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT  `product`.`name` AS 'Product Name', `product`.`form` AS 'Product Form',`product`.`pfno` AS 'Registered By', `product`.`registered_date` AS 'Registered Date' , status AS 'Status' FROM product ORDER BY name ASC", con);

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
                dataTable.Columns.Add("Product Name");
                dataTable.Columns.Add("Product Form");
                dataTable.Columns.Add("Registered By");
                dataTable.Columns.Add("Registered Date", typeof(string));
                dataTable.Columns.Add("Status");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                addProductdataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addProductdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception )
            {
                MessageBox.Show("Error has occured while displaying product details............!", "PRODUCT DETAILS DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string db = databaseConnectionStringTextBox.Text;
             if (productname.Text == string.Empty || productform.Text == string.Empty ||  statusComboBox.Text==string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "PRODUCT DETAILS REGISTRATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {


                    dialog = MessageBox.Show("Are you sure you want to register the product details?", "PRODUCT DETALS REGISTRATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                     if (dialog == DialogResult.Yes)
                     {
                         MySqlConnection con = new MySqlConnection(db);

                         con.Open();
                         DateTime dt = DateTime.Now;
                         String dateNow = dt.ToString("yyyy-MM-dd");

                         MySqlCommand c = new MySqlCommand("INSERT INTO product VALUES(NULL,'" + this.productname.Text + "','" + this.productform.Text + "','" + this.productPfsession.Text + "','" + dateNow + "','" + this.statusComboBox.Text + "')", con);
                         c.ExecuteNonQuery();
                         MessageBox.Show("Product details registered successfully...............!", "PRODUCT DETAILS REGISTRATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                         con.Close();

                         addProductView();
                         clearFields();
                     }
                }
                catch (Exception) {
                    //MessageBox.Show(ex.Message);
                    MessageBox.Show("Error has occured while registering product details............!", "PRODUCT DETAILS REGISTRATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
        }

    }
}
