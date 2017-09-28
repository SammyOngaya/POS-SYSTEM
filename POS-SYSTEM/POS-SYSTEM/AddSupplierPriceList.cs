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
    public partial class AddSupplierPriceList : Form
    {
        public AddSupplierPriceList(string user, string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            pfsession.Text = user;
            supplierCombo();
            drugCombo();
            displayPriceListRecords();

        }
        DialogResult dialog;


        private void AddSupplierPriceList_Load(object sender, EventArgs e)
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

                MySqlCommand c = new MySqlCommand("select * from supplier WHERE status='Active'", con);

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
        //populate drug combo
        public void drugCombo()
        {
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM product WHERE `product`.`status`='Active'", con);

                MySqlDataReader mm = c.ExecuteReader();

                while (mm.Read())
                {
                    String l = mm.GetString("name");
                    addProductCombo.Items.Add(l);

                } 
                con.Close();
            }
            catch (Exception) { 
            }
            
        }


        //fetch id from supplier and use the foreign key
        public void supplierForeignKey()
        {
           
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM supplier WHERE (name='" + this.addSupplierCombo.Text + "' AND status='Active')", con);
                MySqlDataReader n = mc.ExecuteReader();

                while (n.Read())
                {
                    String supid = n.GetInt32("id").ToString();
                    supplieridforeignkey.Text = supid;

                }


                con.Close();

            }
            catch (Exception)
            {

            }


           

        }

        
        //fetch id from drug and use the foreign key
        public void drugForeignKey()
        {
            
            try
            {
                string db = databaseConnectionStringTextBox.Text;

                MySqlConnection con = new MySqlConnection(db);

                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM product WHERE name='" + this.addProductCombo.Text + "'", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {
                    String did = nn.GetInt32("id").ToString();
                    //String drn = nn.GetString("drug_name");

                    drugidforeignkey.Text = did;
                    // drugnameforeignkey.Text = drn;


                }

                con.Close();

            }
            catch (Exception)
            {

            }


        }


        private void clearSaveFields() {
            PriceTextBox.Text = string.Empty;
            addProductCombo.Text = string.Empty;
            drugidforeignkey.Text = string.Empty;
        }

        private void createNewPriceList()
        {
            PriceTextBox.Text = string.Empty;
            addProductCombo.Text = string.Empty;
            drugidforeignkey.Text = string.Empty;
            supplieridforeignkey.Text = string.Empty;
            addSupplierCombo.Text = string.Empty;
        }

        private void displayPriceListRecords() {
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
                dataTable.Columns.Add("#", typeof(string));
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
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(supplierPriceListDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying  price list ............!", "DISPLAY PRODUCT PRICE LIST", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }
        }

        private void addSupplierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            supplierForeignKey();
        }

        private void createNewSupplierPriceListButton_Click_1(object sender, EventArgs e)
        {
            createNewPriceList();
        }

        private void saveSupplierPriceListButton_Click(object sender, EventArgs e)
        {
            string db = databaseConnectionStringTextBox.Text;
            if (addSupplierCombo.Text == string.Empty || PriceTextBox.Text == string.Empty || addProductCombo.Text == string.Empty || drugidforeignkey.Text == string.Empty || supplieridforeignkey.Text == string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "SUPPLIER ORDER LIST REGISTRATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    DateTime dt = DateTime.Now;
                    string date = dt.ToString("yyyy-MM-dd");

                    dialog = MessageBox.Show("Are you sure you want to add the price list?", "SUPPLIER ORDER LIST REGISTRATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();


                        //convert drug id to integer
                        int drugID = Convert.ToInt32(drugidforeignkey.Text);
                        //convert supplierforeignkey to integer
                        int supplierID = Convert.ToInt32(supplieridforeignkey.Text);

                        //insert into order list
                        MySqlCommand c = new MySqlCommand("INSERT INTO supplier_price_list VALUES('" + supplierID + "','" + drugID + "','" + this.PriceTextBox.Text + "','" + date + "','" + this.pfsession.Text + "')", con);
                        c.ExecuteNonQuery();

                        MessageBox.Show("Price list details registered successfully...............!", "SUPPLIER ORDER LIST REGISTRATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Insert to events
                        //current date
                        DateTime curdate = DateTime.Now;
                        String dateCurrent = curdate.ToString("yyyy-MM-dd");

                        MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.pfsession.Text + "','" + dateCurrent + "','added supplier price list for. ''" + this.addProductCombo.Text + "')", con);
                        me.ExecuteNonQuery();
                        // End inserting to events.



                        con.Close();

                        clearSaveFields();
                        displayPriceListRecords();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error has occured while registering price list details............!", "SUPPLIER ORDER LIST REGISTRATION", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }

            }
        
        }

        private void addProductCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            drugForeignKey();
        }


    }
}
