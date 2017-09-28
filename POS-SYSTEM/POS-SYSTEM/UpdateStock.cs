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
    public partial class UpdateStock : Form
    {
        public UpdateStock(string pfn, string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            updatestockpfsession.Text = pfn;
            supplierCombo();
            productCombo();
            viewStock();
            searchStock();
            searchProduct();
            //showStockData();

        }

        private void UpdateStock_Load(object sender, EventArgs e)
        {

        }


        //MySqlConnection con = null;

        DataTable dataTable;
        DialogResult dialog;

        //filter database
        public void filterDatabase()
        {
            DataView dv = new DataView(dataTable);
            dv.RowFilter = string.Format("batch_no LIKE '%{0}%'", searchUpdateStock.Text);
            updateStockdataGridView.DataSource = dv;
        }


        //clear fields
        public void clearFields()
        {
            updateSupplierCombo.Text = string.Empty;
            originalQuantityTextBox.Text = string.Empty;
            updateStockBuyingPrice.Text = string.Empty;
            updateStockSellingPrice.Text = string.Empty;
            updateProductCombo.Text = string.Empty;
            updateStockUnit.Text = string.Empty;
            updateStockExpiriDate.Text = string.Empty;
            updateStockBatchNo.Text = string.Empty;
            supplieridforeignkey.Text = string.Empty;
            productidforeignkey.Text = string.Empty;
            updateStockId.Text = string.Empty;
            StatuscomboBox.Text = string.Empty;
            remainingQuantityTextBox.Text = string.Empty;
            quantitySoldTextBox.Text = string.Empty;
            searchProductNameTextBox.Text = string.Empty;
            searchUpdateStock.Text = string.Empty;
            stockIDTextBox.Text = string.Empty;
            updateStockId.Text = string.Empty;
            quantityCheckWarningLabel.Text = string.Empty;
            reoderLevelTextBox.Text = string.Empty;
        }



        //search product from netsock
        public void searchProduct()
        {
            searchProductNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchProductNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");
                MySqlCommand c = new MySqlCommand("select `product`.`id`,`product`.`name` FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` GROUP BY `stock`.`product_id` ORDER BY `product`.`name` ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string l = r.GetString("name");
                    collection.Add(l);

                }
                con.Close();
            }
            catch (Exception)
            {

            }

            searchProductNameTextBox.AutoCompleteCustomSource = collection;


        }


        //search prduct from netsock
        public void productData()
        {

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");
                MySqlCommand c = new MySqlCommand("SELECT * FROM product WHERE name='" + this.searchProductNameTextBox.Text + "'", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string id = r.GetString("id");
                    productidforeignkey.Text = id;

                }
                con.Close();
            }
            catch (Exception)
            {

            }
        }


        //view stock
        public void viewStock()
        {
            DateTime dtt = DateTime.Now;
            string dateNow = dtt.ToString("yyyy-MM-dd");

            try
            {
                string db = databaseConnectionStringTextBox.Text;

                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED',`stock`.`reoder_level` AS 'RE-ODER LEVEL' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE ((`stock`.`status`=1) AND (`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0)) ORDER BY `product`.`name` ASC", con);

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
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("RE-ODER LEVEL");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                updateStockdataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(updateStockdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        // Filter stock by PRODUCT NAME.
        public void filterStockByProductName()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`supplier`.`name` AS 'SUPPLIER NAME',`product`.`name` AS 'PRODUCT NAME',`stock`.`buying_price` AS 'BUYING PRICE',`stock`.`selling_price` AS 'SELLING PRICE',`stock`.`initial_quantity` AS 'ORIGINAL QUANTITY',`stock`.`quantity_sold` AS 'QUANTITY SOLD',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY', `stock`.`units` AS 'UNITS', `stock`.`expiry_date` AS 'EXPIRY DATE',`stock`.`batch_no` AS 'BATCH NUMBER',`stock`.`pfno` AS 'REGISTERED BY',`stock`.`registered_date` AS 'DATE REGISTERED',`stock`.`reoder_level` AS 'RE-ODER LEVEL' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `supplier` ON `supplier`.`id`=`stock`.`supplier_id` WHERE (`product`.`name`='" + this.searchProductNameTextBox.Text + "') AND `stock`.`status`=1 ORDER BY `stock`.`registered_date` DESC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("STOCK ID");
                dataTable.Columns.Add("SUPPLIER NAME");
                dataTable.Columns.Add("PRODUCT NAME");
                dataTable.Columns.Add("BATCH NUMBER", typeof(string));
                dataTable.Columns.Add("BUYING PRICE");
                dataTable.Columns.Add("SELLING PRICE");
                dataTable.Columns.Add("ORIGINAL QUANTITY");
                dataTable.Columns.Add("REMAINING QUANTITY");
                dataTable.Columns.Add("QUANTITY SOLD");
                dataTable.Columns.Add("RE-ODER LEVEL");
                dataTable.Columns.Add("UNITS");
                dataTable.Columns.Add("EXPIRY DATE", typeof(string));
                dataTable.Columns.Add("DATE REGISTERED", typeof(string));
                dataTable.Columns.Add("REGISTERED BY");
                // End formating titles.


                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                updateStockdataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(updateStockdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }




        //search stock from stock
        public void searchStock()
        {
            searchUpdateStock.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchUpdateStock.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            try
            {
                string db = databaseConnectionStringTextBox.Text;

                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select * from stock WHERE status='1' ", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string l = r.GetString("batch_no");
                    collection.Add(l);


                }
                con.Close();
            }
            catch (Exception)
            {

            }
            searchUpdateStock.AutoCompleteCustomSource = collection;


        }


        //fill data in fields
        public void showStockData()
        {
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT `stock`.`stock_id`, `product`.`id`,`supplier`.`id`,`stock`.`status` AS 'status',`stock`.`supplier_id`  AS supplier_id ,`stock`.`product_id`  AS product_id,`product`.`name` as 'productname',`stock`.`initial_quantity` ,(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'remaining_quantity',`stock`.`quantity_sold` AS 'quantity_sold' ,`stock`.`buying_price` AS 'buying_price',`stock`.`selling_price` AS 'selling_price',batch_no,expiry_date,`supplier`.`id`,`supplier`.`name` as suppliername,`stock`.`units`,`stock`.`reoder_level` AS 'reoder_level' FROM product JOIN stock on `product`.`id`=`stock`.`product_id` JOIN supplier on `supplier`.`id`=`stock`.`supplier_id` WHERE (product_id='" + this.productidforeignkey.Text + "' AND batch_no='" + this.searchUpdateStock.Text + "' AND stock_id='" + this.stockIDTextBox.Text + "' )", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {

                    string stockID = r.GetString("stock_id");
                    string supplier_id = r.GetString("supplier_id");
                    string product_id = r.GetString("product_id");
                    string sp = r.GetString("suppliername");
                    string dr = r.GetString("productname");
                    string qty = r.GetString("initial_quantity");
                    string bp = r.GetString("buying_price");
                    string spr = r.GetString("selling_price");
                    string units = r.GetString("units");
                    string expdate = r.GetString("expiry_date");
                    string bt = r.GetString("batch_no");
                    string status = r.GetString("status");
                    string quantittSold = r.GetString("quantity_sold");
                    string remainingQuantity = r.GetString("remaining_quantity");
                    string reoderLevel = r.GetString("reoder_level");

                    updateStockId.Text = stockID;
                    originalQuantityTextBox.Text = qty;
                    updateStockBuyingPrice.Text = bp;
                    updateStockSellingPrice.Text = spr;
                    updateStockUnit.Text = units;
                    updateStockExpiriDate.Text = expdate;
                    updateStockBatchNo.Text = bt;
                    updateSupplierCombo.Text = sp;
                    updateProductCombo.Text = dr;
                    StatuscomboBox.Text = status;
                    quantitySoldTextBox.Text = quantittSold;
                    supplieridforeignkey.Text = supplier_id;
                    remainingQuantityTextBox.Text = remainingQuantity;
                    productidforeignkey.Text = product_id;
                    reoderLevelTextBox.Text = reoderLevel;


                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Fill data in fields.
        public void showStockDataFilterByStockOnly()
        {
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT `stock`.`stock_id`, `product`.`id`,`supplier`.`id`,`stock`.`status` AS 'status',`stock`.`supplier_id`  AS supplier_id ,`stock`.`product_id`  AS product_id,`product`.`name` as 'productname',`stock`.`initial_quantity` ,(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'remaining_quantity',`stock`.`quantity_sold` AS 'quantity_sold' ,`stock`.`buying_price` AS 'buying_price',`stock`.`selling_price` AS 'selling_price',batch_no,expiry_date,`supplier`.`id`,`supplier`.`name` as suppliername,`stock`.`units`,`stock`.`reoder_level` AS 'reoder_level' FROM product JOIN stock on `product`.`id`=`stock`.`product_id` JOIN supplier on `supplier`.`id`=`stock`.`supplier_id` WHERE (stock_id='" + this.stockIDTextBox.Text + "' )", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {

                    string stockID = r.GetString("stock_id");
                    string supplier_id = r.GetString("supplier_id");
                    string product_id = r.GetString("product_id");
                    string sp = r.GetString("suppliername");
                    string dr = r.GetString("productname");
                    string qty = r.GetString("initial_quantity");
                    string bp = r.GetString("buying_price");
                    string spr = r.GetString("selling_price");
                    string units = r.GetString("units");
                    string expdate = r.GetString("expiry_date");
                    string bt = r.GetString("batch_no");
                    string status = r.GetString("status");
                    string quantittSold = r.GetString("quantity_sold");
                    string remainingQuantity = r.GetString("remaining_quantity");
                    string reoderLevel = r.GetString("reoder_level");

                    updateStockId.Text = stockID;
                    originalQuantityTextBox.Text = qty;
                    updateStockBuyingPrice.Text = bp;
                    updateStockSellingPrice.Text = spr;
                    updateStockUnit.Text = units;
                    updateStockExpiriDate.Text = expdate;
                    updateStockBatchNo.Text = bt;
                    updateSupplierCombo.Text = sp;
                    updateProductCombo.Text = dr;
                    StatuscomboBox.Text = status;
                    quantitySoldTextBox.Text = quantittSold;
                    supplieridforeignkey.Text = supplier_id;
                    remainingQuantityTextBox.Text = remainingQuantity;
                    productidforeignkey.Text = product_id;
                    reoderLevelTextBox.Text = reoderLevel;

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //update Stock

        public void updateStock()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                string expiryDate = updateStockExpiriDate.Value.ToString("yyyy-MM-dd");

                MySqlCommand c = new MySqlCommand("UPDATE `stock` SET supplier_id='" + this.supplieridforeignkey.Text + "', initial_quantity='" + this.originalQuantityTextBox.Text + "', pfno='" + this.updatestockpfsession.Text + "',buying_price='" + this.updateStockBuyingPrice.Text + "',selling_price='" + this.updateStockSellingPrice.Text + "',units='" + this.updateStockUnit.Text + "' , expiry_date='" + expiryDate + "', product_id='" + this.productidforeignkey.Text + "' , batch_no='" + this.updateStockBatchNo.Text.ToUpper() + "', status='" + this.StatuscomboBox.Text + "',reoder_level='" + this.reoderLevelTextBox.Text + "'  WHERE stock_id='" + this.updateStockId.Text + "' ", con);

                c.ExecuteNonQuery();

                MessageBox.Show("Stock Updated successfully", "STOCK UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);


                con.Close();

                viewStock();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating stock!!......................" + ex.Message);
            }

            viewStock();
        }




        //populate supplier combo
        public void supplierCombo()
        {
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("select * from supplier WHERE  status='Active'", con);

                MySqlDataReader m = c.ExecuteReader();

                while (m.Read())
                {
                    string l = m.GetString("name");
                    updateSupplierCombo.Items.Add(l);

                }
                con.Close();
            }
            catch (Exception)
            {

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

                MySqlCommand c = new MySqlCommand("SELECT * FROM product WHERE status='Active' ", con);

                MySqlDataReader mm = c.ExecuteReader();

                while (mm.Read())
                {
                    string l = mm.GetString("name");
                    updateProductCombo.Items.Add(l);

                }

                con.Close();
            }
            catch (Exception)
            {
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
                MySqlCommand mc = new MySqlCommand("SELECT * FROM supplier WHERE (name='" + this.updateSupplierCombo.Text + "' AND status='Active')", con);
                MySqlDataReader n = mc.ExecuteReader();

                while (n.Read())
                {
                    string supid = n.GetString("id");
                    supplieridforeignkey.Text = supid;

                }


                con.Close();

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
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
                MySqlCommand mc = new MySqlCommand("SELECT * FROM product WHERE name='" + this.updateProductCombo.Text + "' AND status='Active' ", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {
                    string did = nn.GetString("id");
                    productidforeignkey.Text = did;

                }

                con.Close();

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }


        }

        
        public void CheckQuantities()
        {
            try
            {

                decimal originalQuantity = Convert.ToDecimal(originalQuantityTextBox.Text);
                decimal soldQuantity = Convert.ToDecimal(quantitySoldTextBox.Text);

                if (soldQuantity > originalQuantity)
                {
                    quantityCheckWarningLabel.Text = "You cannot add stock less than the quantity sold.";
                    quantityCheckWarningLabel.ForeColor = Color.Red;
                }
                else
                {
                    quantityCheckWarningLabel.Text = string.Empty;
                }
            }
            catch (Exception)
            {
            }
        }


        private void reoderLevelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(reoderLevelTextBox.Text, "[^ 0-9]"))
            {
                reoderLevelTextBox.Text = "";
            }
        }

        private void originalQuantityTextBox_TextChanged_1(object sender, EventArgs e)
        {
            CheckQuantities();
        }

        private void cancelStock_Click_1(object sender, EventArgs e)
        {
            clearFields();
        }

        private void stockIDTextBox_TextChanged_1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(stockIDTextBox.Text, "[^ 0-9]"))
            {
                searchUpdateStock.Text = "";
            }
            showStockDataFilterByStockOnly();
            showStockData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewStock();
        }

       
        private void updateStockButton_Click(object sender, EventArgs e)
        {
            if (updateSupplierCombo.Text == string.Empty || updateProductCombo.Text == string.Empty || originalQuantityTextBox.Text == string.Empty || updateStockUnit.Text == string.Empty || updateStockBuyingPrice.Text == string.Empty || updateStockSellingPrice.Text == string.Empty || this.updateStockExpiriDate.Text == string.Empty || this.updateStockBatchNo.Text == string.Empty || this.StatuscomboBox.Text == string.Empty || this.reoderLevelTextBox.Text == string.Empty)
            {

                MessageBox.Show("Please fill all the required fields...............!", "STOCK UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                decimal originalQuantity = Convert.ToDecimal(originalQuantityTextBox.Text);
                decimal soldQuantity = Convert.ToDecimal(quantitySoldTextBox.Text);


                if (soldQuantity <= originalQuantity)
                {
                    //quantityCheckWarningLabel.Text = "You cannot add more stock";
                    //quantityCheckWarningLabel.ForeColor = Color.Red;

                    dialog = MessageBox.Show("Are you sure you want to update stock?", "UPDATE STOCK", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        updateStock();
                    }
                }
                else
                {
                    MessageBox.Show("You cannot update stock. The quantity sold is greater than the original stock you are updating?", "UPDATE STOCK ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                viewStock();
                clearFields();
            }

        }

        private void updateSupplierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierForeignKey();
        }

        private void updateProductCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            productForeignKey();
        }

        private void searchProductNameTextBox_TextChanged(object sender, EventArgs e)
        {

            productForeignKey();
            filterStockByProductName();
            //productData();
        }

        private void searchUpdateStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateStockId_TextChanged(object sender, EventArgs e)
        {

        }

    }  
    }


   
