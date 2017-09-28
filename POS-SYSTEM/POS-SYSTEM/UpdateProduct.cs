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
    public partial class UpdateProduct : Form
    {
        public UpdateProduct(string pfn, string databaseString)
        {
            InitializeComponent();
        databaseConnectionStringTextBox.Text = databaseString;
            updateproductpfsession.Text = pfn;
            viewProduct();
            searchProduct();
            productCombo();

        }

        DialogResult dialog;
        DataTable dataTable;


        private void UpdateProduct_Load(object sender, EventArgs e)
        {

        }

        
        //populate drug combo
        public void productCombo()
        {
           try
           {
               string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select * from product_form", con);

                MySqlDataReader mm = c.ExecuteReader();

                while (mm.Read())
                {
                    String form_name = mm.GetString("form_name");
                    updateProductForm.Items.Add(form_name);

                }
                con.Close();
            }
            catch (Exception)
            {

            }
           
        }

        //view drug

        public void viewProduct()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;

                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `product`.`name` AS 'Product Name', `product`.`form` AS 'Product Form',`product`.`pfno` AS 'Registered By', `product`.`registered_date` AS 'Registered Date',`product`.`status` AS 'Status' FROM product ORDER BY name ASC", con);

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
                dataTable.Columns.Add("Product Name");
                dataTable.Columns.Add("Product Form");
                dataTable.Columns.Add("Registered By");
                dataTable.Columns.Add("Registered Date", typeof(string));
                dataTable.Columns.Add("Status");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                updateProductdataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(updateProductdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
            }

        }

        //filter database
        public void filterDatabase() {
            DataView dv = new DataView(dataTable);
            dv.RowFilter = string.Format("name LIKE '%{0}%'", searchProductUpdate.Text);
            updateProductdataGridView.DataSource = dv;
        }


        //clear fields
        public void clearFields()
        {
            updateProductName.Text = string.Empty;
            updateProductForm.Text = string.Empty;
            updateProductId.Text = string.Empty;
            searchProductUpdate.Text = string.Empty;
            statusComboBox.Text = string.Empty;
          
        }

        //search drug from drug
        public void searchProduct()
        {
            searchProductUpdate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchProductUpdate.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            try
            {
                string db = databaseConnectionStringTextBox.Text;

                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select * from product", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    String l = r.GetString("name");
                    collection.Add(l);
                }
                con.Close();
            }
            catch (Exception) { 
            
            }

            searchProductUpdate.AutoCompleteCustomSource = collection;

        }


        //fill data in fields
        public void showProductData()
        {
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM product WHERE name='" + this.searchProductUpdate.Text + "'", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string ids = r.GetInt32("id").ToString();
                    string nm = r.GetString("name");
                    string fr = r.GetString("form");
                    string status = r.GetString("status");

                    updateProductName.Text = nm;
                    updateProductForm.Text = fr;
                    updateProductId.Text = ids;
                    statusComboBox.Text = status;
                }
                con.Close();
            }
            catch (Exception) { 
            
            }

        }


        //update Drug

        public void updateProduct()
        {
            string db = databaseConnectionStringTextBox.Text;
            if (updateProductName.Text == string.Empty || updateProductForm.Text == string.Empty ||  updateProductId.Text == string.Empty || searchProductUpdate.Text == string.Empty || statusComboBox.Text==string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "PRODUCT UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {

                    dialog = MessageBox.Show("Are you sure you want to update the product?", "PRODUCT UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();
                        int did = Convert.ToInt32(updateProductId.Text);
                        MySqlCommand c = new MySqlCommand("UPDATE product SET pfno='" + this.updateproductpfsession.Text + "',status='" + this.statusComboBox.Text + "',name='" + this.updateProductName.Text + "',form='" + this.updateProductForm.Text + "' WHERE id='" + did + "'", con);

                        c.ExecuteNonQuery();

                        MessageBox.Show("Product updated successfully...............!", "PRODUCT UPDATE ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error has occured while updating product............!", "PRODUCT UPDATE", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                
                viewProduct();
            }

        }

        private void searchProductUpdate_TextChanged_1(object sender, EventArgs e)
        {
            showProductData();
        }


        private void updateProductButton_Click(object sender, EventArgs e)
        {
            updateProduct();
            clearFields();
        }


    }
}
