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
    public partial class ProductForm : Form
    {   
        MySqlConnection con = null;
        DialogResult dialog;
       
        public ProductForm()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            drugFormView();
            searchProductForm();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

        private void DrugForm_Load(object sender, EventArgs e)
        {

        }


        // Clear fields.
        private void clearFields() {
            productFormTextBox.Text = string.Empty;
            productFormIDTextBox.Text = string.Empty;
            searchProductFormtextBox.Text = string.Empty;
        }

        // View drug form.
        public void drugFormView() {

           
            try
            {
                //MySqlConnection con = new MySqlConnection(db);
                con.Open();
               
                MySqlCommand com = new MySqlCommand("SELECT `product_form`.`form_name` AS 'Product' FROM `product_form`  ORDER BY `product_form`.`form_name` ASC", con);

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
                productFormdataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(productFormdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Error has occured while displaying drug form............!", "DRUG FORM DETAILS DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            

        }

       
       
        //search drug form
        public void searchProductForm()
        {
           
            searchProductFormtextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchProductFormtextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            try
            {
               // MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM product_form", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string form_name = r.GetString("form_name");
                    collection.Add(form_name);

                }

                con.Close();
            }
            catch (Exception) { 
            
            }
            
            searchProductFormtextBox.AutoCompleteCustomSource = collection;
            
        }


        // Get drug form data in fields.
        public void showDrugFormData()
        {
            
            try
            {
               // MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM product_form WHERE form_name='" + this.searchProductFormtextBox.Text + "'", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string product_form_id = r.GetString("product_form_id");
                    string form_name = r.GetString("form_name");

                    productFormIDTextBox.Text = product_form_id;
                    productFormTextBox.Text = form_name;

                }
                con.Close();
            }
            catch (Exception) { 
            }
            
        }

        private void searchProductFormtextBox_TextChanged(object sender, EventArgs e)
        {
            showDrugFormData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showDrugFormData();
        }

        private void delete_Click(object sender, EventArgs e)
        {
              if (productFormTextBox.Text == string.Empty || productFormIDTextBox.Text == string.Empty || searchProductFormtextBox.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "PRODUCT FORM DETAILS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {
                   // MySqlConnection con = new MySqlConnection(db);
                    con.Open();

                    dialog = MessageBox.Show("Are you sure you want to delete the product form?", "PRODUCT FORM DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        
                        DateTime dt = DateTime.Now;
                        string dateNow = dt.ToString("yyyy-MM-dd");

                        MySqlCommand c = new MySqlCommand("DELETE FROM product_form WHERE product_form_id='" + this.productFormIDTextBox.Text + "' ", con);
                        c.ExecuteNonQuery();
                        MessageBox.Show("Product form deleted successfully...............!", "PRODUCT FORM DETAILS ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        clearFields();
                    }
                    con.Close();
                    drugFormView();
                }
                catch (Exception )
                {
                   // MessageBox.Show(ex.Message);
                   // MessageBox.Show("Error has occured while deleting drug form details............!", "DRUG FORM DETAILS ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                searchProductForm();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
             if (productFormTextBox.Text == string.Empty || productFormIDTextBox.Text == string.Empty || searchProductFormtextBox.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "PRODUCT FORM DETAILS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {
                   // MySqlConnection con = new MySqlConnection(db);
                    con.Open();

                    dialog = MessageBox.Show("Are you sure you want to update the product details?", "PRODUCT FORM DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        DateTime dt = DateTime.Now;
                        string dateNow = dt.ToString("yyyy-MM-dd");

                        MySqlCommand c = new MySqlCommand("UPDATE product_form SET form_name='" + this.productFormTextBox.Text + "' WHERE product_form_id='" + this.productFormIDTextBox.Text + "' ", con);
                        c.ExecuteNonQuery();
                        MessageBox.Show("Product form updated successfully...............!", "PRODUCT FORM DETAILS ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                    }
                    con.Close();
                    drugFormView();
                    
                }
                catch (Exception )
                {
                    //MessageBox.Show(ex.Message);
                   // MessageBox.Show("Error has occured while updating drug form details............!", "DRUG FORM DETAILS ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                searchProductForm();
            }
            
        }

        private void save_Click(object sender, EventArgs e)
        {
             if (productFormTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the required fields...............!", "PRODUCT FORM DETAILS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                try
                {

                    dialog = MessageBox.Show("Are you sure you want to register the product details?", "PRODUCT FORM DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                      //  MySqlConnection con = new MySqlConnection(db);
                        con.Open();

                        DateTime dt = DateTime.Now;
                        string dateNow = dt.ToString("yyyy-MM-dd");

                        MySqlCommand c = new MySqlCommand("INSERT INTO product_form VALUES(NULL,'" + this.productFormTextBox.Text + "')", con);
                        c.ExecuteNonQuery();
                        MessageBox.Show("Product form registered successfully...............!", "PRODUCT FORM DETAILS ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        drugFormView();
                        clearFields();
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Error has occured while adding drug form details............!", "DRUG FORM DETAILS ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                searchProductForm();
            }
            
        }

        

    }
}
