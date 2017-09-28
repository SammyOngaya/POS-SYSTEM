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
    public partial class UpdateSupplierPriceList : Form
    {
        //MySqlConnection con = null;
        DialogResult dialog;
        public UpdateSupplierPriceList(string user, string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            pfsession.Text = user;
            supplierCombo();
            displayPriceListRecords();
            searchDrug();
        }
        

        private void UpdateSupplierPriceList_Load(object sender, EventArgs e)
        {

        }
        
        //populate supplier combo
        public void supplierCombo()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select * from supplier WHERE status='Active' ORDER BY name ASC", con);

                MySqlDataReader m = c.ExecuteReader();

                while (m.Read())
                {
                    String l = m.GetString("name");
                    addSupplierCombo.Items.Add(l);



                }
                con.Close();
            }
            catch (Exception) { 
            }
        }
       
        private void displayPriceListRecords()
        {
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER',`product`.`name` AS 'PRODUCT',`supplier_price_list`.`price` AS 'PRICE' FROM `supplier` JOIN `supplier_price_list` ON `supplier`.`id`=`supplier_price_list`.`supplier_id` JOIN `product` ON `product`.`id`=`supplier_price_list`.`product_id` ORDER BY `supplier`.`name` ASC", con);

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
                supplierPriceListDataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(supplierPriceListDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY PRODUCT PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }

            

        }


        // Search drug.
        public void searchDrug()
        {
            searchProductTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchProductTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

           try
           {
               string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `product`.`name` AS 'name' FROM `product` JOIN `supplier_price_list` ON `product`.`id`=`supplier_price_list`.`product_id` WHERE `product`.`status`='Active' ORDER BY `product`.`name` ASC", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("name");
                    collection.Add(name);
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while searching product details............!", "PRODUCT DETAILS SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

            searchProductTextBox.AutoCompleteCustomSource = collection;
         
        }// End search drug.

        // Show drug name.
        public void drugData()
        {
           
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `product`.`name` AS 'name',`product`.`id` AS 'id' FROM `supplier` JOIN `supplier_price_list` ON `supplier`.`id`=`supplier_price_list`.`supplier_id` JOIN `product` ON `product`.`id`=`supplier_price_list`.`product_id` WHERE `product`.`name`='" + this.searchProductTextBox.Text + "' GROUP BY `supplier_price_list`.`product_id`", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String name = reader.GetString("name");

                    searchProductTextBox.Text = name;

                    

                }
                con.Close();
            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
               //MessageBox.Show("Error has occured while searching order list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
           
        } // End show drug name.

        public void getDrugID() {
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `product`.`id` AS 'id' FROM `supplier` JOIN `supplier_price_list` ON `supplier`.`id`=`supplier_price_list`.`supplier_id` JOIN `product` ON `product`.`id`=`supplier_price_list`.`product_id` WHERE `product`.`name`='" + this.searchProductTextBox.Text + "' GROUP BY `supplier_price_list`.`product_id`", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    

                    string id = reader.GetInt64("id").ToString();

                    drugIDTextBox.Text = id;

                }
                con.Close();
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
                //MessageBox.Show("Error has occured while searching order list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
           
        }

        // Show drug price.
        public void drugPrice()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand sqlCommand = new MySqlCommand("SELECT `supplier_price_list`.`price` AS 'price' FROM `supplier` JOIN `supplier_price_list` ON `supplier`.`id`=`supplier_price_list`.`supplier_id` JOIN `product` ON `product`.`id`=`supplier_price_list`.`product_id` WHERE `supplier`.`name`='" + this.addSupplierCombo.Text + "' AND `product`.`name`='" + this.searchProductTextBox.Text + "'", con);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    String price = reader.GetString("price");

                    PriceTextBox.Text = price;

                }
                con.Close();
            }
            catch (Exception )
            {
                 MessageBox.Show("Error has occured while searching order list price............!", "ORDER PRICE SEARCH ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            
        } // End show drug name.



        //fetch id from supplier and use the foreign key
        public void supplierForeignKey()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;

                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM supplier WHERE name='" + this.addSupplierCombo.Text + "'", con);
                MySqlDataReader n = mc.ExecuteReader();

                while (n.Read())
                {
                    String supid = n.GetInt32("id").ToString();
                    supplierIDTextBox.Text = supid;

                }


                con.Close();

            }
            catch (Exception)
            {

            }


        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            string db = databaseConnectionStringTextBox.Text;
            if (addSupplierCombo.Text == string.Empty || PriceTextBox.Text == string.Empty || searchProductTextBox.Text == string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "SUPPLIER ORDER LIST DELETE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    DateTime dt = DateTime.Now;
                    string date = dt.ToString("yyyy-MM-dd");

                    dialog = MessageBox.Show("Are you sure you want to remove the price list?", "SUPPLIER ORDER LIST DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();

                        // Update price.
                        MySqlCommand c = new MySqlCommand("DELETE FROM supplier_price_list  WHERE `supplier_price_list`.`supplier_id`='" + this.supplierIDTextBox.Text + "' AND `supplier_price_list`.`product_id`='" + this.drugIDTextBox.Text + "'", con);

                        c.ExecuteNonQuery();


                        MessageBox.Show("Price list details removed successfully...............!", "SUPPLIER ORDER LIST DELETE ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        // Insert to events
                        //current date
                        DateTime curdate = DateTime.Now;
                        String dateCurrent = curdate.ToString("yyyy-MM-dd");

                        MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.pfsession.Text + "','" + dateCurrent + "','removed supplier order list for supplier ''" + this.addSupplierCombo.Text + "')", con);
                        me.ExecuteNonQuery();
                        // End inserting to events.

                        con.Close();
                        displayPriceListRecords();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error has occured while removing price list details............!", "SUPPLIER ORDER LIST DELETE", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }

            }

        }

        private void addSupplierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierForeignKey();
        }

        private void saveSupplierPriceListButton_Click(object sender, EventArgs e)
        {
            string db = databaseConnectionStringTextBox.Text;
            if (addSupplierCombo.Text == string.Empty || PriceTextBox.Text == string.Empty || searchProductTextBox.Text == string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "SUPPLIER ORDER LIST UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    DateTime dt = DateTime.Now;
                    string date = dt.ToString("yyyy-MM-dd");

                    dialog = MessageBox.Show("Are you sure you want to update the price?", "SUPPLIER ORDER LIST UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();

                        // Update price.
                        MySqlCommand c = new MySqlCommand("UPDATE supplier_price_list SET `supplier_price_list`.`price` ='" + this.PriceTextBox.Text + "'  WHERE `supplier_price_list`.`supplier_id`='" + this.supplierIDTextBox.Text + "' AND `supplier_price_list`.`product_id`='" + this.drugIDTextBox.Text + "'", con);

                        c.ExecuteNonQuery();

                        MessageBox.Show("Price list details updated successfully...............!", "SUPPLIER ORDER LIST UPDATE ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Insert to events
                        //current date
                        DateTime curdate = DateTime.Now;
                        String dateCurrent = curdate.ToString("yyyy-MM-dd");

                        MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.pfsession.Text + "','" + dateCurrent + "','updated order list for supplier ''" + this.addSupplierCombo.Text + "')", con);
                        me.ExecuteNonQuery();
                        // End inserting to events.

                        con.Close();
                        displayPriceListRecords();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error has occured while registering price list details............!", "SUPPLIER ORDER LIST REGISTRATION", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }

            }

        }

        private void searchSupplierPriceListButton_Click_1(object sender, EventArgs e)
        {

            drugData();
            drugPrice();
        }

        private void searchProductTextBox_TextChanged(object sender, EventArgs e)
        {

            drugData();
            getDrugID();
            drugPrice();
        }


    }
}
