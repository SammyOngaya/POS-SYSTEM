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
    public partial class AddStock : Form
    {
        public AddStock(string pfn, string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            addstockpfsession.Text = pfn;
            addStockView();
            supplierCombo();
            productCombo();

            getCurrentBatchNo();

        }

        private void AddStock_Load(object sender, EventArgs e)
        {

        }

        DialogResult dialog;


        // Get current batch no.
        private void getCurrentBatchNo()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*)  FROM stock WHERE product_id='" + this.productidforeignkey.Text + "'", con);

                MySqlCommand command = new MySqlCommand("SELECT MAX(batch_no) AS 'batch' FROM stock WHERE product_id='" + this.productidforeignkey.Text + "'", con);


                Int64 count = (Int64)mc.ExecuteScalar();


                if (count >= 1)
                {

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string batch = reader.GetString("batch");
                        currentBatchTextBox.Text = batch;
                    }


                }
                else
                {
                    currentBatchTextBox.Text = "No stock";
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
            addSupplierCombo.Text = string.Empty;
            addQuantity.Text = string.Empty;
            buyingPrice.Text = string.Empty;
            sellingPrice.Text = string.Empty;
            addProductCombo.Text = string.Empty;
            addUnit.Text = string.Empty;
            addDate.Text = string.Empty;
            addBatchNo.Text = string.Empty;
            supplieridforeignkey.Text = string.Empty;
            productidforeignkey.Text = string.Empty;

        }


       
        public void addStockView()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED',`stock`.`reoder_level` AS 'RE-ODER LEVEL' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE `stock`.`status`='1' ORDER BY `product`.`name` ASC", con);

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
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("RE-ODER LEVEL");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                addStockdataGridView.DataSource = bs;

                a.Update(dataTable);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(addStockdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying product stock ............!", "PRODUCT DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }



        }

        //populate supplier combo
        public void supplierCombo()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM supplier WHERE status='Active' ORDER BY name ASC ", con);

                MySqlDataReader m = c.ExecuteReader();

                while (m.Read())
                {
                    String l = m.GetString("name");
                    addSupplierCombo.Items.Add(l);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //populate product combo
        public void productCombo()
        {
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT * FROM product WHERE `product`.`status`='Active' ORDER BY name ASC", con);

                MySqlDataReader mm = c.ExecuteReader();

                while (mm.Read())
                {
                    String l = mm.GetString("name");
                    addProductCombo.Items.Add(l);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    //  String supid = n.GetInt32("id").ToString();
                    String supid = n.GetString("id");
                    supplieridforeignkey.Text = supid;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //fetch id from product and use the foreign key
        public void productForeignKey()
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
                    //   String did = nn.GetInt32("id").ToString();
                    String did = nn.GetString("id");

                    productidforeignkey.Text = did;

                }

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            getCurrentBatchNo();
        }


        private void saveStock_Click(object sender, EventArgs e)
        {
            string db = databaseConnectionStringTextBox.Text;
            if (addSupplierCombo.Text == string.Empty || addQuantity.Text == string.Empty || buyingPrice.Text == string.Empty || sellingPrice.Text == string.Empty || addProductCombo.Text == string.Empty || addDate.Text == string.Empty || this.addBatchNo.Text == string.Empty || reoderLevelTextBox.Text == string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "STOCK REGISTRATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                try
                {
                    string expiryDate = addDate.Value.ToString("yyyy-MM-dd");

                    dialog = MessageBox.Show("Are you sure you want to add the stock ?", "STOCK REGISTRATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        MySqlConnection con = new MySqlConnection(db);
                        con.Open();
                        DateTime dt = DateTime.Now;
                        String dateNow = dt.ToString("yyyy-MM-dd");


                        //convert product id to integer
                        //int dr = Convert.ToInt32(drugidforeignkey.Text);
                        //convert supplierforeignkey to integer
                        // int i = Convert.ToInt32(supplieridforeignkey.Text);

                        //insert into stock
                        MySqlCommand c = new MySqlCommand("INSERT INTO stock VALUES(NULL,'" + this.supplieridforeignkey.Text + "','" + this.addQuantity.Text + "','0.00','" + this.buyingPrice.Text + "','" + this.sellingPrice.Text + "','" + this.productidforeignkey.Text + "','" + this.addUnit.Text + "','" + expiryDate + "','" + this.addBatchNo.Text.ToUpper() + "','" + this.addstockpfsession.Text + "','" + dateNow + "','1','" + this.reoderLevelTextBox.Text + "')", con);
                        c.ExecuteNonQuery();


                        MessageBox.Show("Stock registered successfully...............!", "STOCK  REGISTRATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con.Close();
                        // updateNetstock();
                        // updateDrudPrice();
                        addStockView();
                        clearFields();
                        getCurrentBatchNo();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   // MessageBox.Show("Error has occured while registering stock details. Please check if you have entered all the fields ...........!", "STOCK DETAILS REGISTRATION ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }

            }
        }

        
        private void reoderLevelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(reoderLevelTextBox.Text, "[^ 0-9]"))
            {
                reoderLevelTextBox.Text = "";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void addProductCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            productForeignKey();
            getCurrentBatchNo();
        
        }

        private void addSupplierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierForeignKey();
        
        }


    }
}
