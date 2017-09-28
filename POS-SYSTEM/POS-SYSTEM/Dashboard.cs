
using System.Runtime.InteropServices;



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Management;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace POS_SYSTEM
{
    public partial class Dashboard : Form
    {




        DataTable dt;
        DataTable dtdelete = new DataTable();
        DialogResult dialog;


        public string PrinterName
        {
            //get { return @"\\{0}\POS58".FormatWith(Environment.MachineName); }
           //get { return @"\\{0}\" + this.PrinterNameLabel.Text +(Environment.MachineName); }
            get { return PrinterNameLabel.Text; }

        }

        /// MySqlConnection con = null;
        public string product_name { get; set; }
        public string quantity { get; set; }
        public string units { get; set; }
        public string price { get; set; }
        public string total_amount { get; set; }
        // public string sum { get; set; }

        

        public Dashboard() { }

        public Dashboard(string mess, string firstname, string lastname,string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            firstNameTextBox.Text = firstname;
            lastNameTextBox.Text = lastname;
            //Welcome user.
            welcomeLabel.Text = firstname;

            setTime();
            cartQuantityTextBox.Text = "0.00";
            cartStockIDtextBox.Text = "0";
            searchDrug();
            cartView();
            // totalAmount();
            pfsession.Text = mess;
            timer1.Start();

            checkCart();
            getVat();
          }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        // Not so important BUT NECESSAR /////////////#######################################################################################3

        //set time
        public void setTime()
        {
            DateTime salestime = DateTime.Now;
            string time = salestime.ToString("yyyy-MM-dd");
        }

        // Get vat tax from database.
        public void getVat()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand c = new MySqlCommand("SELECT * FROM vat", con);

                MySqlDataReader reader = c.ExecuteReader();

                while (reader.Read())
                {
                    string vat = reader.GetString("vat_value");
                    string etr_id = reader.GetString("etr_id");
                    string pin = reader.GetString("pin");
                    string business_name = reader.GetString("business_name");
                    string address = reader.GetString("address");
                    string location = reader.GetString("location");
                    string phone = reader.GetString("phone"); 
                    string printer_name = reader.GetString("printer_name");
                    string print_receipt = reader.GetString("print_receipt");

                    vatTextBox.Text = vat;
                    vatLabel.Text = etr_id;
                    pinLabel.Text = pin;
                    businessLabel.Text = business_name;
                    addressLabel.Text = address;
                    locationLabel.Text = location;
                    phoneLabel.Text = phone;
                    PrinterNameLabel.Text = printer_name;
                    printReceiptLabel.Text = print_receipt;
                }
                con.Close();
            }
            catch (Exception)
            {
                //  MessageBox.Show("Error Has occured" + ex.Message);
            }
        }

        // end Not so important BUT NECESSAR /////////////#######################################################################################3


        //clear fields
        public void clearFields()
        {
            cashSaleTotal.Text = string.Empty;
            cashSaleAmountTextBox.Text = string.Empty;
            cashSaleDiscount.Text = string.Empty;
            cashSaleBalance.Text = string.Empty;
            cashSaleDrugSearch.Text = string.Empty;
            cashSaleQuantity.Text = string.Empty;
            pricePerUnit.Text = string.Empty;
            stockIDTextBox.Text = string.Empty;
            drugDetailsLabel.Text = string.Empty;
            setSerial.Text = string.Empty;
            cartQuantityTextBox.Text = "0.00";
            cartStockIDtextBox.Text = "0";
        }

        //clear drug search field
        public void clearDrugSearch()
        {
            cashSaleDrugSearch.Text = string.Empty;
            cashSaleQuantity.Text = string.Empty;
            pricePerUnit.Text = string.Empty;
            drugStockQuantityTextBox.Text = string.Empty;
            stockIDTextBox.Text = string.Empty;
            drugDetailsLabel.Text = string.Empty;
            setSerial.Text = string.Empty;
            cartQuantityTextBox.Text = "0.00";
            cartStockIDtextBox.Text = "0";
        }
        //check for data in cart

        public void checkCart()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM cart", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                if (count >= 1)
                {
                    totalAmount();
                }

                con.Close();

            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);
            }
        }


        // Search drug from stock
        public void searchDrug()
        {
            cashSaleDrugSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cashSaleDrugSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();


            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand c = new MySqlCommand("SELECT `product`.`name` AS 'product_name',`stock`.`batch_no` AS 'batch_no',`stock`.`expiry_date` AS 'product_exiry_date',`stock`.`stock_id` AS 'stock_id' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` WHERE ((`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0) AND (`stock`.`status`='1')) GROUP BY `stock`.`product_id` ORDER BY `product`.`name` ASC", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {

                    string drugName = r.GetString("product_name");

                    collection.Add(drugName);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message);
            }
            cashSaleDrugSearch.AutoCompleteCustomSource = collection;
        }


        // Fetch cart id  and quantity from stock and use the.
        public void CartStockIDKeyAndQuantity()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand mc = new MySqlCommand("SELECT `stock`.`stock_id` AS 'stock_id', (`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'remaining_quantity' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` WHERE ((`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0) AND (`stock`.`status`='1') AND (`product`.`name`='" + this.cashSaleDrugSearch.Text + "'))  GROUP BY `stock`.`product_id` ORDER BY `product`.`name` ASC", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {

                    string stockID = nn.GetString("stock_id");

                    string qty = nn.GetString("remaining_quantity");

                    stockIDTextBox.Text = stockID;
                    drugStockQuantityTextBox.Text = qty;

                }

                con.Close();

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }


        }


        // Fetch stock id from stock and use the.
        public void stockIDKey()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                double cartQty = Convert.ToDouble(cartQuantityTextBox.Text);

                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand mc = new MySqlCommand("SELECT `product`.`name` AS 'product_name',`stock`.`batch_no` AS 'batch_no',`stock`.`expiry_date` AS 'product_exiry_date',`stock`.`stock_id` AS 'stock_id',`stock`.`selling_price` AS 'selling_price', (`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'remaining_quantity' FROM `product` JOIN `stock` ON `product`.`id`=`stock`.`product_id` WHERE ((`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (DATEDIFF(`stock`.`expiry_date`,'" + dateNow + "')>0) AND (`stock`.`status`='1') AND (`product`.`name`='" + this.cashSaleDrugSearch.Text + "') AND((`stock`.`initial_quantity`-`stock`.`quantity_sold`) > '" + cartQty + "'))  GROUP BY `stock`.`product_id` ORDER BY `product`.`name` ASC", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {

                    string stockID = nn.GetString("stock_id");
                    string batchNo = nn.GetString("batch_no");
                    string expiryDate = nn.GetString("product_exiry_date");

                    string qty = nn.GetString("remaining_quantity");
                    string drug = "BATCH : " + batchNo + " | EXP DATE : " + expiryDate + " | STOCK QUANTITY : " + qty + " ";
                    string pr = nn.GetString("selling_price");

                    drugDetailsLabel.Text = drug;
                    drugDetailsLabel.ForeColor = Color.Blue;
                    pricePerUnit.Text = pr;
                    stockIDTextBox.Text = stockID;
                    drugStockQuantityTextBox.Text = qty;

                }

                con.Close();

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }


        }


        //view drugs in cart

        public void cartView()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);

                MySqlCommand com = new MySqlCommand("SELECT `cart`.`cart_id` AS 'Item Id',`stock`.`stock_id` AS 'Stock ID', `product`.`name` AS 'Product Name',`cart`.`quantity` AS 'Quantity',`cart`.`price` AS 'Price', ROUND((`cart`.`quantity`*`cart`.`price`),2) AS 'Total Amount',`stock`.`units` AS 'Units' FROM product JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `cart` ON `stock`.`stock_id`=`cart`.`stock_id` ORDER BY `cart`.`cart_id` DESC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dt = new DataTable();

                // Add autoincrement column.
                dt.Columns.Add("No.", typeof(string));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["No."] };
                dt.Columns["No."].AutoIncrement = true;
                dt.Columns["No."].AutoIncrementSeed = 1;
                dt.Columns["No."].ReadOnly = true;
                // End adding AI column.

                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                saleDashboardDataGridView.DataSource = bs;

                // SET ITEMID COLUMN TO HAVE SMALL WIDTH AND INVISIBLE.
                saleDashboardDataGridView.Columns["No."].Width = 100;
                saleDashboardDataGridView.Columns["Item Id"].Visible = false;
                saleDashboardDataGridView.Columns["Stock ID"].Visible = false;
                saleDashboardDataGridView.Columns["Product Name"].Width = 450;
                saleDashboardDataGridView.Columns["Quantity"].Width = 200;
                saleDashboardDataGridView.Columns["Price"].Width = 200;
                saleDashboardDataGridView.Columns["Total Amount"].Width = 200;

                // END setting them invisible.
                a.Update(dt);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(saleDashboardDataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " items";
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);
            }
        }



        //Compute total amount
        public void totalAmount()
        {

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();

                MySqlCommand mc = new MySqlCommand("SELECT ROUND(SUM(quantity*price),2) AS amount FROM cart", con);
                MySqlDataReader nn = mc.ExecuteReader();

                while (nn.Read())
                {
                    // String am = nn.GetInt32("amount").ToString();
                    string am = nn.GetDouble("amount").ToString();
                    cashSaleTotal.Text = am;

                }

                con.Close();

            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);
            }

        }


        public void checkDrugStockQuantity()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();



                MySqlCommand mc = new MySqlCommand("SELECT SUM(quantity) AS 'quantity', stock_id FROM cart WHERE stock_id='" + this.stockIDTextBox.Text + "' ", con);
                MySqlDataReader nn = mc.ExecuteReader();

                // int count = 0;

                while (nn.Read())
                {
                    string stockID = nn.GetString("stock_id");
                    string qty = nn.GetString("quantity");

                    cartStockIDtextBox.Text = stockID;
                    cartQuantityTextBox.Text = qty;

                    // count += 1;
                }

                con.Close();

                //  if (count == 0)
                //  {
                //      cartQuantityTextBox.Text = "0";
                //  }

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        //Compute Balance
        public void computeBalance()
        {

            try
            {

                if ((this.cashSaleTotal.Text != ""))
                {

                    double amt = Convert.ToDouble(cashSaleAmountTextBox.Text);
                    double total = Convert.ToDouble(cashSaleTotal.Text);


                    if (string.IsNullOrEmpty(this.cashSaleDiscount.Text))
                    {

                        double ans = (amt - total);
                        cashSaleBalance.Text = "Balence : " + Convert.ToString(ans);

                    }
                    else
                    {
                        //int disc = Convert.ToInt32(cashSaleDiscount.Text);
                        double disc = Convert.ToDouble(cashSaleDiscount.Text);

                        double ans = ((amt + disc) - total);
                        cashSaleBalance.Text = "Balence : " + Convert.ToString(ans);

                    }
                }
                else
                {
                    //  MessageBox.Show("No Product!","NO DRUG",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cashSaleBalance.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                cashSaleBalance.Text = string.Empty;
                // MessageBox.Show("No amount","NO AMOUNT",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        //deletes all records from cart
        public void cashSaleDelete()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                //current date
                DateTime curdate = DateTime.Now;
                string dateCurrent = curdate.ToString("yyyy-MM-dd");

                //convert loginusername to integer
                int pf = Convert.ToInt32(pfsession.Text);

                con.Open();
                MySqlCommand mc = new MySqlCommand("DELETE FROM cart", con);
                MySqlDataReader nn = mc.ExecuteReader();
                while (nn.Read())
                {
                }
                //MessageBox.Show("All Data Deleted Successfull");
                nn.Close(); //close rader

                //insert to events
                MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + pf + "','" + dateCurrent + "',Deleted products worth Kshs. '" + this.cashSaleTotal.Text + "')", con);
                me.ExecuteNonQuery();

                con.Close(); //close connection

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

            cartView(); //displays the cart method

        } //end delete from cart method
        //String.IsNullOrEmpty(this.cashSaleDiscount.Text)

        public void DrugQuantityAlert()
        {
            try
            {
                double qty = Convert.ToDouble(cashSaleQuantity.Text);
                double cartQty = Convert.ToDouble(cartQuantityTextBox.Text);
                double stockQty = Convert.ToDouble(drugStockQuantityTextBox.Text);

                double ans =qty - (stockQty - cartQty);

                if ((stockQty - cartQty) >= qty)
                {
                    remainedDrugQuantitylabel.ForeColor = Color.Green;
                    remainedDrugQuantitylabel.Text = "REMAINING QTY : " + ans;
                }
                else
                {
                    remainedDrugQuantitylabel.Text = "REMAINING QTY : " + (stockQty - cartQty);
                    remainedDrugQuantitylabel.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {
                remainedDrugQuantitylabel.Text = string.Empty;
            }
        }

        //insert into cart
        public void insertToCart()
        {

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);

            if ((this.cashSaleDrugSearch.Text != string.Empty) && (this.cashSaleQuantity.Text != string.Empty) && (this.pricePerUnit.Text != string.Empty))
            {


                try
                {
                    con.Open();
                    double qty = Convert.ToDouble(cashSaleQuantity.Text);
                    double cartQty = Convert.ToDouble(cartQuantityTextBox.Text);
                    double stockQty = Convert.ToDouble(drugStockQuantityTextBox.Text);

                    int stockStockID = int.Parse(stockIDTextBox.Text);
                    int cartStockID = int.Parse(cartStockIDtextBox.Text);

                    if ((stockQty - cartQty) >= qty)
                    {

                        if (stockStockID == cartStockID)
                        {
                            DateTime dt = DateTime.Now;
                            String dateNow = dt.ToString("yyyy-MM-dd");
                            // int drid = Convert.ToInt32(drugidforeignkey.Text);
                            int pfs = Convert.ToInt32(pfsession.Text);
                            //int pr = Convert.ToInt32(priceforeignkey.Text);

                            MySqlCommand c = new MySqlCommand("UPDATE cart SET quantity=(quantity + ('" + this.cashSaleQuantity.Text + "'))  WHERE stock_id='" + this.stockIDTextBox.Text + "' ", con);

                            c.ExecuteNonQuery();
                        }
                        else
                        {

                            DateTime dt = DateTime.Now;
                            String dateNow = dt.ToString("yyyy-MM-dd");
                            // int drid = Convert.ToInt32(drugidforeignkey.Text);
                            int pfs = Convert.ToInt32(pfsession.Text);
                            //int pr = Convert.ToInt32(priceforeignkey.Text);

                            MySqlCommand c = new MySqlCommand("INSERT INTO cart VALUES(NULL,'" + this.stockIDTextBox.Text + "','" + this.cashSaleQuantity.Text + "','" + this.pricePerUnit.Text + "')", con);

                            c.ExecuteNonQuery();
                        }

                    }
                    else
                    {

                        MessageBox.Show("The quantity you entered is more than what is in the stock. : " + (stockQty - cartQty), "EXCESS QUANTITY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    con.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro has occured    " + ex.Message);
                }

                cartView();//display in grid
                totalAmount();//display in total

            }
            else
            {
                MessageBox.Show("Wrong Operation!", "WRONG OPERATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        //end insert to cart method



        public void removeFromCart()
        {

            try
            {

                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);

                if (saleDashboardDataGridView.SelectedRows.Count > 0)
                {

                    int selectedIndex = saleDashboardDataGridView.SelectedRows[0].Index;
                    int RowID = int.Parse(saleDashboardDataGridView[1, selectedIndex].Value.ToString());

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM cart WHERE cart_id = " + RowID + "", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("No data selected", "NO PRODUCT SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has occured!" + ex.Message);
            }
            cartView();


        }


        //update net stock
        public void updateStock()
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);
            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("UPDATE stock set quantity_sold=(quantity_sold+@quantity) WHERE stock_id=@stock_id", con);

                foreach (DataRow row in dt.Rows)
                {
                    mc.Parameters.Clear();
                    mc.Parameters.AddWithValue("@stock_id", row["Stock ID"]);
                    mc.Parameters.AddWithValue("@quantity", row["quantity"]);
                    mc.ExecuteNonQuery();
                }
                con.Close();
            }
            catch (Exception)
            {

                // MessageBox.Show("Problem has occured while updating net stock" + ex.Message);
            }
        }


        // Insert to sales from cart
        public void insertToSales()
        {

            //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString("yyyy-MM-dd");

            //convert loginusername to integer
            int pf = Convert.ToInt32(pfsession.Text);

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);


            try
            {

                con.Open();

                if (!string.IsNullOrWhiteSpace(cashSaleDiscount.Text))
                {
                    MySqlCommand c = new MySqlCommand("INSERT INTO sales VALUES(NULL,@cart_id,@stock_id,@quantity,@price,'" + this.pfsession.Text + "','" + dateCurrent + "','" + this.setSerial.Text + "','" + this.cashSaleDiscount.Text + "')", con);

                    foreach (DataRow row in dt.Rows)
                    {

                        //  Random rn = new Random();
                        // int serial=rn.Next(10,20);

                        c.Parameters.Clear();

                        c.Parameters.AddWithValue("@cart_id", row["Item Id"]);
                        c.Parameters.AddWithValue("@stock_id", row["Stock ID"]);
                        c.Parameters.AddWithValue("@quantity", row["Quantity"]);
                        c.Parameters.AddWithValue("@price", row["Price"]);

                        c.ExecuteNonQuery();

                    }

                }
                else
                {
                    MySqlCommand c = new MySqlCommand("INSERT INTO sales VALUES(NULL,@cart_id,@stock_id,@quantity,@price,'" + this.pfsession.Text + "','" + dateCurrent + "','" + this.setSerial.Text + "','0.00')", con);

                    foreach (DataRow row in dt.Rows)
                    {

                        //  Random rn = new Random();
                        // int serial=rn.Next(10,20);

                        c.Parameters.Clear();

                        c.Parameters.AddWithValue("@cart_id", row["Item Id"]);
                        c.Parameters.AddWithValue("@stock_id", row["Stock ID"]);
                        c.Parameters.AddWithValue("@quantity", row["Quantity"]);
                        c.Parameters.AddWithValue("@price", row["Price"]);

                        c.ExecuteNonQuery();

                    }
                }


                updateStock();

                // cashSaleDelete();
                MessageBox.Show("SUCCESS", "SECSESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //insert to events
                MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + pf + "','" + dateCurrent + "','sold products worth kshs. '" + this.cashSaleTotal.Text + "')", con);
                me.ExecuteNonQuery();


                con.Close();

                cartView();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }


        private void cashSalePay_Click(object sender, EventArgs e)
        {

            computeBalance();
            cashSaleDrugSearch.Select();
        }




        ///////////////////////////////////GENERATE RECEIPT AND PRINT IT //////////////////////////////////////////


        public void createReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs events)
        {
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);

            //current date and time of sale.
            DateTime curdate = DateTime.Now;
            String timeOfSale = curdate.ToString();

            // Get vat from textBox.
            double vat = Convert.ToDouble(vatTextBox.Text);
            double cost = Convert.ToDouble(cashSaleTotal.Text);

            double vatableAmount = (vat / 100) * cost;

            con.Open();
            MySqlCommand command = new MySqlCommand("SELECT product_name AS 'Product Name',quantity AS 'QTY',price AS 'PRICE',quantity*price AS 'TOTAL',unit AS 'UNITS' FROM cart ORDER BY cart_id ASC", con);
            MySqlDataReader reader = command.ExecuteReader();

            //create a new instance of printReceipt class
            Dashboard newPrintReceipt = new Dashboard();

            //print the receipt layout first

            Graphics graphic = events.Graphics;

            System.Drawing.Font font = new System.Drawing.Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 150;

            // Locate the image of the receipt.
            System.Drawing.Image headerImage = System.Drawing.Image.FromFile("C:\\pos\\Resources\\faith2.png");
            graphic.DrawImage(headerImage, startX, startY, 830, 150);

            // This is the title of the receipt. Put the address here.
            string headerText = this.businessLabel.Text + "\n".PadLeft(35) + " P.O BOX " + this.addressLabel.Text + "".PadLeft(35) + " TOWN" + this.locationLabel.Text + "\n".PadLeft(35) + " PHONE " + this.phoneLabel + "\n".PadLeft(35) + "VAT : " + this.vatLabel.Text + "".PadLeft(35) + "PIN:" + this.pinLabel.Text + "\n";
            graphic.DrawString(headerText, new System.Drawing.Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 55; //make the spacing consistent

            graphic.DrawString("-----------------------------------------------------------------------------------".PadLeft(55), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 7; //make the spacing consistent

            graphic.DrawString("Product Name |".PadRight(5) + " Qty |".PadRight(5) + " Price |".PadRight(5) + " Total |".PadRight(5) + " Units".PadRight(5), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            graphic.DrawString("--------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            while (reader.Read())
            {
                try
                {
                    newPrintReceipt.product_name = reader.GetString(0);
                    newPrintReceipt.quantity = reader.GetString(1);
                    newPrintReceipt.price = reader.GetString(2);
                    newPrintReceipt.total_amount = reader.GetString(3);
                    newPrintReceipt.units = reader.GetString(4);

                    graphic.DrawString(newPrintReceipt.product_name.PadRight(12) + newPrintReceipt.quantity.PadRight(5) +
                                       newPrintReceipt.price.PadRight(9) + newPrintReceipt.total_amount.PadRight(5) + newPrintReceipt.units.PadRight(7), font, new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + (int)fontHeight; //make the spacing consistent

                    graphic.DrawString("--------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight + 5; //make the spacing consistent.
                }
                catch (InvalidCastException er)
                {
                    MessageBox.Show(er.Message);
                }
            }

            con.Close();

            offset = offset + 5; //make some room so that the footer stands out.

            graphic.DrawString("Total items bought : ".PadLeft(5) + rowCountLabel.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Total Cost : ".PadLeft(5) + cashSaleTotal.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("VAT : ".PadLeft(5) + vatTextBox.Text + " %     VAT amount : " + vatableAmount, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Amount received : ".PadLeft(5) + cashSaleAmountTextBox.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Discount : ".PadLeft(5) + cashSaleDiscount.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Change : ".PadLeft(5) + cashSaleBalance.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Served by : ".PadLeft(5) + firstNameTextBox.Text + "  " + lastNameTextBox.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Date of purchase : ".PadLeft(5) + timeOfSale, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("Receipt serial no. : ".PadLeft(5) + setSerial.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20;
            graphic.DrawString("PRICES INCLUSIVE OF VAT WHERE APPLICABLE ".PadLeft(5), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 25;
            graphic.DrawString("Thank you and welcome again!! ".PadLeft(5), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 25;
            graphic.DrawString("Sample beauty shop \"TOUCHING LIVES REACHING PEOPLE.\"".PadLeft(20), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("DESIGNED BY TESMOLITE TECHNOLOGIES.".PadLeft(20), font, new SolidBrush(Color.Black), startX, startY + offset + 20);

        }


        public void print(object sender, EventArgs e)
        {
            try
            {

                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(createReceipt); //add an event handler that will do the printing

                printDocument.Print();

                //DialogResult result = printDialog.ShowDialog();


                //if (result == DialogResult.OK)
                // {
                printDocument.Print();

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //   MessageBox.Show("Something wrong has occured while printing receipt.  ", "RECEIPT PRINTING ERROR", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {

            }

        }


        /////////////////////////////END PRINT RECEIPT ////////////////////////////////////////////////////////


        // Key press events and shortcut.


        private void Dashboard_KeyDown(object sender, KeyEventArgs e)
        {
            /*   if (e.KeyCode == Keys.Enter)
               {// Insert drug to cart.
                  // insertToCart();
                  // clearDrugSearch();
                  // cashSaleDrugSearch.Select();

               }
               else if (e.Control && e.KeyCode == Keys.R)
               {// Remove drug from cart.
                   dialog = MessageBox.Show("Are you sure you want to remove the product?", "REMOVE PRODUCT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                   if (dialog == DialogResult.Yes)
                   {
                       removeFromCart();
                       totalAmount();
                       cashSaleDrugSearch.Select();
                   }
                   cashSaleDrugSearch.Select();
               }
               else if (e.Control && e.KeyCode == Keys.C)
               {// Cancel transaction.
                   dialog = MessageBox.Show("Are you sure you want to cancel the transaction ?", "CANCEL SALES", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                   if (dialog == DialogResult.Yes)
                   {
                       cashSaleDelete();
                       clearFields();
                       cashSaleDrugSearch.Select();
                   }
                   cashSaleDrugSearch.Select();
               }
               else if (e.Control && e.KeyCode == Keys.S)
               {// Sale drugs.
                   Int64 count = Convert.ToInt64(saleDashboardDataGridView.Rows.Count) - 1;

                   if ((this.cashSaleTotal.Text != "") && (count > 0))
                   {
                       // Generate receipt serial number first.
                       Random rd = new Random();
                       int serial = rd.Next(1, 1000000000);
                       setSerial.Text = serial.ToString();

                       // Call the print method from printReceipt class to print the client receipt.
                       // Print receipr before clearing the window.
                       print(sender, e);
                       // End printing the receipt.

                       insertToSales();
                       //salesReceipt();
                       clearFields();
                       cashSaleDelete();
                       cashSaleDrugSearch.Select();
                   }
                   else
                   {
                       MessageBox.Show("NO PRODUCT");
                       cashSaleDrugSearch.Select();
                   }
               }
               else if (e.Control && e.KeyCode == Keys.P)
               {// Calculate balance.
                   computeBalance();
                   cashSaleDrugSearch.Select();
               }
               else if (e.Control && e.KeyCode == Keys.A)
               {// Focus cursor on amount.
                   cashSaleAmountTextBox.Select();
               }
               else if (e.Control && e.KeyCode == Keys.X)
               {// Open A calculator.
                   Calculator c = new Calculator();
                   c.ShowDialog();
               }
            
               /*
               if (e.KeyCode == Keys.Enter)
               {
                   MessageBox.Show("Enter Drug to cart.");

               }
               else if (e.Control && e.KeyCode == Keys.R)
               {
                   MessageBox.Show("CTRL+R for remove drug.");
               }
               else if (e.Control && e.KeyCode == Keys.C)
               {
                   MessageBox.Show("CTRL+C for canceling sales transaction.");
               }
               else if (e.Control && e.KeyCode == Keys.S)
               {
                   MessageBox.Show("CTRL+S for selling drugs.");
               }
               else if (e.Control && e.KeyCode == Keys.P)
               {
                   MessageBox.Show("CTRL+P for calculating the balance drug sale.");
               }
               else if (e.Control && e.KeyCode == Keys.A)
               {
                   MessageBox.Show("CTRL+A for for entering amount from client.");
               }
               */
        }


        /////.
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //


        private void stockIDTextBox_TextChanged_1(object sender, EventArgs e)
        {
            checkDrugStockQuantity();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.ShowDialog();
        }

        private void cashSaleQuantity_TextChanged_1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cashSaleQuantity.Text, "[^ 0-9]"))
            {
                cashSaleQuantity.Text = "";
            }

            if (cartStockIDtextBox.Text != stockIDTextBox.Text)
            {
                cartQuantityTextBox.Text = "0.00";
            }


            DrugQuantityAlert();
        }

        private void cashSaleRemove_Click_1(object sender, EventArgs e)
        {
            dialog = MessageBox.Show("Are you sure you want to remove the product?", "REMOVE PRODUCT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                removeFromCart();
                totalAmount();
                cashSaleDrugSearch.Select();
            }
            cashSaleDrugSearch.Select();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Int64 count = Convert.ToInt64(saleDashboardDataGridView.Rows.Count) - 1;

            if ((this.cashSaleTotal.Text != "") && (count > 0))
            {
                // Generate receipt serial number first.
                Random rd = new Random();
                int serial = rd.Next(1, 1000000000);
                setSerial.Text = serial.ToString();

                if (this.printReceiptLabel.Text == "YES")
                {

                 /*
                    // Call the print method from printReceipt class to print the client receipt.
                    // Print receipr before clearing the window.
                    ManagementScope scope = new ManagementScope(@"\root\cimv2");
                    scope.Connect();
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
                    foreach (ManagementObject printer in searcher.Get())
                    {
                        if (printer["WorkOffline"].ToString().Equals("true"))
                        {

                        }
                        else
                        {
                            //print(sender, e);
                        }
                    }*/
                    try
                    {
                        //print(sender, e);
                        Print(PrinterName, GetDocument());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                // print(sender, e);

                //################# UNCOMMENT THIS LINE TO ENABLE PRINTING.
                // End printing the receipt.

                insertToSales();
                //salesReceipt();
                clearFields();
                cashSaleDelete();
                cashSaleDrugSearch.Select();
            }
            else
            {
                MessageBox.Show("The Product Name you entered does not exist ", "NO SUCH PRODUCT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cashSaleDrugSearch.Select();
            }
        }


        public void CheckForPrinterIfConnected()
        {
            ManagementScope scope = new ManagementScope(@"\root\cimv2");
            scope.Connect();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            foreach (ManagementObject printer in searcher.Get())
            {
                if (printer["WorkOffline"].ToString().Equals("true"))
                {
                    MessageBox.Show("YOU HAVE A PRINTER SET AND READY", "CHECKING FRO PRINTER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("YOU DONT HAVE ANY PRINTER ATTACHED TO THE COMPUTER", "CHECKING FRO PRINTER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }


        private void cashSaleCancel_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show("Are you sure you want to cancel the transaction ?", "CANCEL SALES", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                cashSaleDelete();
                clearFields();
                cashSaleDrugSearch.Select();
            }
            cashSaleDrugSearch.Select();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            insertToCart();
            clearDrugSearch();
            cashSaleDrugSearch.Select();
        }

        private void cashSaleDrugSearch_TextChanged_1(object sender, EventArgs e)
        {
            CartStockIDKeyAndQuantity();
            stockIDKey();
        }

        private void cashSaleAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cashSaleAmountTextBox.Text, "[^ 0-9]"))
            {
                cashSaleAmountTextBox.Text = "";
            }

            computeBalance();
        }

        private void cashSaleDiscount_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cashSaleDiscount.Text, "[^ 0-9]"))
            {
                cashSaleDiscount.Text = "";
            }
            computeBalance();

        }




        ///////////////                 ///////////////////
        ////////////////// NEW PRINTER ///////////////////
        //////////////////             ///////////////////
















      

        

        private static void Print(string printerName, byte[] document)
        {

            NativeMethods.DOC_INFO_1 documentInfo;
            IntPtr printerHandle;

            try
            {

                documentInfo = new NativeMethods.DOC_INFO_1();
                documentInfo.pDataType = "RAW";
                documentInfo.pDocName = "Receipt";

                printerHandle = new IntPtr(0);

                if (NativeMethods.OpenPrinter(printerName.Normalize(), out printerHandle, IntPtr.Zero))
                {
                    if (NativeMethods.StartDocPrinter(printerHandle, 1, documentInfo))
                    {
                        int bytesWritten;
                        byte[] managedData;
                        IntPtr unmanagedData;

                        managedData = document;
                        unmanagedData = Marshal.AllocCoTaskMem(managedData.Length);
                        Marshal.Copy(managedData, 0, unmanagedData, managedData.Length);

                        if (NativeMethods.StartPagePrinter(printerHandle))
                        {
                            NativeMethods.WritePrinter(
                                printerHandle,
                                unmanagedData,
                                managedData.Length,
                                out bytesWritten);
                            NativeMethods.EndPagePrinter(printerHandle);
                        }
                        else
                        {
                            throw new Win32Exception();
                        }

                        Marshal.FreeCoTaskMem(unmanagedData);

                        NativeMethods.EndDocPrinter(printerHandle);
                    }
                    else
                    {
                        throw new Win32Exception();
                    }

                    NativeMethods.ClosePrinter(printerHandle);
                }
                else
                {
                    throw new Win32Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("here error: "+ex.Message);
            }

        }



        private byte[] GetDocument()
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                // Reset the printer bws (NV images are not cleared)
                bw.Write(AsciiControlChars.Escape);
                bw.Write('@');

                // Render the logo
                //RenderLogo(bw);
                PrintReceipt(bw);

                // Feed 3 vertical motion units and cut the paper with a 1 point cut
                bw.Write(AsciiControlChars.GroupSeparator);
                bw.Write('V');
                bw.Write((byte)66);
                bw.Write((byte)3);

                bw.Flush();

                return ms.ToArray();
            }
        }

        /// <summary>
        /// This is the method we print the receipt the way we want. Note the spaces. 
        /// Wasted a lot of paper on this to get it right.
        /// </summary>
        /// <param name="bw"></param>
        private void PrintReceipt(BinaryWriter bw)
        {

            
            //current date and time of sale.
            DateTime curdate = DateTime.Now;
            String timeOfSale = curdate.ToString();

            // Get vat from textBox.
            double vat = Convert.ToDouble(vatTextBox.Text);
            double cost = Convert.ToDouble(cashSaleTotal.Text);

            double vatableAmount = (vat / 100) * cost;



            
            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);


            con.Open();

            MySqlCommand command = new MySqlCommand("SELECT `product`.`name` AS 'product_name',`cart`.`quantity` AS 'quantity',`cart`.`price` AS 'price', ROUND((`cart`.`quantity`*`cart`.`price`),2) AS 'total_amount',`stock`.`units` AS 'units' FROM product JOIN `stock` ON `product`.`id`=`stock`.`product_id` JOIN `cart` ON `stock`.`stock_id`=`cart`.`stock_id` ORDER BY `cart`.`cart_id` DESC", con);

            //MySqlCommand command = new MySqlCommand("SELECT name AS 'product_name',quantity AS 'quantity',price AS 'price',quantity*price AS 'total_amount',unit AS 'units' FROM cart ORDER BY cart_id ASC", con);
            MySqlDataReader reader = command.ExecuteReader();

            //create a new instance of printReceipt class
            Dashboard newPrintReceipt = new Dashboard();


            bw.LargeText(this.businessLabel.Text);
            bw.LargeText(this.addressLabel.Text);
            bw.NormalFont("  Phone: "+this.phoneLabel);
            bw.FeedLines(1);
            bw.NormalFont("Pin #: "+ this.pinLabel.Text  );
            bw.NormalFont("Date: " + timeOfSale);
            bw.FeedLines(1);

            bw.NormalFont("Itm     Qty     Price    Total");
            bw.NormalFont("-----------------------------");



            while (reader.Read())
            {
                try
                {
                    newPrintReceipt.product_name = reader.GetString(0);
                    newPrintReceipt.quantity = reader.GetString(1);
                    newPrintReceipt.price = reader.GetString(2);
                    newPrintReceipt.total_amount = reader.GetString(3);
                   // newPrintReceipt.units = reader.GetString(4);


                    // var idx = InvoiceItems.IndexOf(item) + 1;
                    bw.NormalFont(newPrintReceipt.product_name + "  " + newPrintReceipt.quantity + " " + newPrintReceipt.price + " " + newPrintReceipt.total_amount);

                }
                catch (Exception)
                {
                    MessageBox.Show("The receipt was not generated.", "RECEIPT GENERATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                }
            }

            bw.FeedLines(2);
            bw.NormalFont(" Discount:  " + cashSaleDiscount.Text);
            bw.NormalFont("  VAT:  " + vatTextBox.Text + " %");
            bw.FeedLines(1);
            bw.High("     Total:  " + cashSaleTotal.Text);
            bw.FeedLines(1);
            bw.NormalFont("  Payment:  " + cashSaleAmountTextBox.Text);
            bw.NormalFont("  Balance:  " + cashSaleBalance.Text);
            bw.NormalFont("  Served by:  " + firstNameTextBox.Text);
            bw.NormalFont("  Date:  " + timeOfSale);
            bw.NormalFont("  Receipt No.:  " + setSerial.Text);
            bw.Finish();


        }


    }










    /// <summary>
    /// Contains native methods invoked via P/Invoke to the underlying Windows
    /// operating system. Only supported on NT platforms.
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// An enumeration of GetDeviceCaps parameters.
        /// </summary>
        internal enum DeviceCap : int
        {
            /// <summary>
            /// Device driver version
            /// </summary>
            DRIVERVERSION = 0,

            /// <summary>
            /// Device classification
            /// </summary>
            TECHNOLOGY = 2,

            /// <summary>
            /// Horizontal size in millimeters
            /// </summary>
            HORZSIZE = 4,

            /// <summary>
            /// Vertical size in millimeters
            /// </summary>
            VERTSIZE = 6,

            /// <summary>
            /// Horizontal width in pixels
            /// </summary>
            HORZRES = 8,

            /// <summary>
            /// Vertical height in pixels
            /// </summary>
            VERTRES = 10,

            /// <summary>
            /// Number of bits per pixel
            /// </summary>
            BITSPIXEL = 12,

            /// <summary>
            /// Number of planes
            /// </summary>
            PLANES = 14,

            /// <summary>
            /// Number of brushes the device has
            /// </summary>
            NUMBRUSHES = 16,

            /// <summary>
            /// Number of pens the device has
            /// </summary>
            NUMPENS = 18,

            /// <summary>
            /// Number of markers the device has
            /// </summary>
            NUMMARKERS = 20,

            /// <summary>
            /// Number of fonts the device has
            /// </summary>
            NUMFONTS = 22,

            /// <summary>
            /// Number of colors the device supports
            /// </summary>
            NUMCOLORS = 24,

            /// <summary>
            /// Size required for device descriptor
            /// </summary>
            PDEVICESIZE = 26,

            /// <summary>
            /// Curve capabilities
            /// </summary>
            CURVECAPS = 28,

            /// <summary>
            /// Line capabilities
            /// </summary>
            LINECAPS = 30,

            /// <summary>
            /// Polygonal capabilities
            /// </summary>
            POLYGONALCAPS = 32,

            /// <summary>
            /// Text capabilities
            /// </summary>
            TEXTCAPS = 34,

            /// <summary>
            /// Clipping capabilities
            /// </summary>
            CLIPCAPS = 36,

            /// <summary>
            /// Bitblt capabilities
            /// </summary>
            RASTERCAPS = 38,

            /// <summary>
            /// Length of the X leg
            /// </summary>
            ASPECTX = 40,

            /// <summary>
            /// Length of the Y leg
            /// </summary>
            ASPECTY = 42,

            /// <summary>
            /// Length of the hypotenuse
            /// </summary>
            ASPECTXY = 44,

            /// <summary>
            /// Shading and Blending caps
            /// </summary>
            SHADEBLENDCAPS = 45,

            /// <summary>
            /// Logical pixels inch in X
            /// </summary>
            LOGPIXELSX = 88,

            /// <summary>
            /// Logical pixels inch in Y
            /// </summary>
            LOGPIXELSY = 90,

            /// <summary>
            /// Number of entries in physical palette
            /// </summary>
            SIZEPALETTE = 104,

            /// <summary>
            /// Number of reserved entries in palette
            /// </summary>
            NUMRESERVED = 106,

            /// <summary>
            /// Actual color resolution
            /// </summary>
            COLORRES = 108,

            /// <summary>
            /// Physical Width in device units
            /// </summary>
            PHYSICALWIDTH = 110,

            /// <summary>
            /// Physical Height in device units
            /// </summary>
            PHYSICALHEIGHT = 111,

            /// <summary>
            /// Physical Printable Area x margin
            /// </summary>
            PHYSICALOFFSETX = 112,

            /// <summary>
            /// Physical Printable Area y margin
            /// </summary>
            PHYSICALOFFSETY = 113,

            /// <summary>
            /// Scaling factor x
            /// </summary>
            SCALINGFACTORX = 114,

            /// <summary>
            /// Scaling factor y
            /// </summary>
            SCALINGFACTORY = 115,

            /// <summary>
            /// Current vertical refresh rate of the display device (for displays only) in Hz
            /// </summary>
            VREFRESH = 116,

            /// <summary>
            /// Horizontal width of entire desktop in pixels
            /// </summary>
            DESKTOPVERTRES = 117,

            /// <summary>
            /// Vertical height of entire desktop in pixels
            /// </summary>
            DESKTOPHORZRES = 118,

            /// <summary>
            /// Preferred blt alignment
            /// </summary>
            BLTALIGNMENT = 119
        }

        /// <summary>
        /// The CreateDC function creates a device context (DC) for a device 
        /// using the specified name.
        /// </summary>
        /// <param name="lpszDriver">Pointer to a null-terminated character
        /// string that specifies either DISPLAY or the name of a specific 
        /// display device or the name of a print provider, which is usually WINSPOOL.</param>
        /// <param name="lpszDevice">Pointer to a null-terminated character string 
        /// that specifies the name of the specific output device being used, 
        /// as shown by the Print Manager (for example, Epson FX-80). It is not 
        /// the printer model name. The lpszDevice parameter must be used.</param>
        /// <param name="lpszOutput">This parameter is ignored and should be set
        /// to NULL. It is provided only for compatibility with 16-bit Windows.</param>
        /// <param name="lpInitData">Pointer to a DEVMODE structure containing 
        /// device-specific initialization data for the device driver. The 
        /// DocumentProperties function retrieves this structure filled in for
        /// a specified device. The lpInitData parameter must be NULL if the
        /// device driver is to use the default initialization (if any) specified
        /// by the user.</param>
        /// <returns>If the function succeeds, the return value is the handle
        /// to a DC for the specified device. If the function fails, the 
        /// return value is NULL. The function will return NULL for a DEVMODE
        /// structure other than the current DEVMODE.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateDC(
            string lpszDriver,
            string lpszDevice,
            string lpszOutput,
            IntPtr lpInitData);

        /// <summary>
        /// The DeleteDC function deletes the specified device context (DC).
        /// </summary>
        /// <param name="hdc">Handle to the device context.</param>
        /// <returns>If the function succeeds, the return value is nonzero. 
        /// If the function fails, the return value is zero.</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteDC(IntPtr hdc);

        [DllImport(
            "winspool.drv",
            EntryPoint = "OpenPrinterW",
            SetLastError = true,
            CharSet = CharSet.Unicode,
            ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool OpenPrinter(
            [MarshalAs(UnmanagedType.LPWStr)] string szPrinter,
            out IntPtr hPrinter,
            IntPtr pd);

        /// <summary>
        /// Closes the specified printer object.
        /// </summary>
        /// <param name="hPrinter">Handle to the printer object to be closed.
        /// This handle is returned by the OpenPrinter or AddPrinter function.</param>
        /// <returns>If the function succeeds, the return value is a nonzero value.
        /// If the function fails, the return value is zero</returns>
        [DllImport(
            "winspool.drv",
            EntryPoint = "ClosePrinter",
            SetLastError = true,
            ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ClosePrinter(IntPtr hPrinter);

        /// <summary>
        /// The StartDoc function starts a print job.
        /// </summary>
        /// <param name="hdc">Handle to the device context for the print job.</param>
        /// <param name="lpdi">Pointer to a DOCINFO structure containing the name 
        /// of the document file and the name of the output file.</param>
        /// <returns>If the function succeeds, the return value is greater than
        /// zero. This value is the print job identifier for the document.</returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int StartDoc(IntPtr hdc, DOCINFO lpdi);

        /// <summary>
        /// The EndDoc function ends a print job.
        /// </summary>
        /// <param name="hdc">Handle to the device context for the print job.</param>
        /// <returns>If the function succeeds, the return value is greater than zero.
        /// If the function fails, the return value is less than or equal
        /// to zero.</returns>
        [DllImport("gdi32.dll")]
        internal static extern int EndDoc(IntPtr hdc);

        /// <summary>
        /// The GetDeviceCaps function retrieves device-specific information 
        /// for the specified device.
        /// </summary>
        /// <param name="hdc">Handle to the DC.</param>
        /// <param name="capindex">Specifies the item to return.</param>
        /// <returns>The return value specifies the value of the desired item.</returns>
        [DllImport("gdi32.dll")]
        internal static extern int GetDeviceCaps(IntPtr hdc, DeviceCap capindex);

        /// <summary>
        /// The StartPage function prepares the printer driver to accept data.
        /// </summary>
        /// <param name="hdc">Handle to the device context for the print job.</param>
        /// <returns>If the function succeeds, the return value is greater than zero.
        /// If the function fails, the return value is less than or equal to zero.</returns>
        [DllImport("gdi32.dll")]
        internal static extern int StartPage(IntPtr hdc);

        /// <summary>
        /// The EndPage function notifies the device that the application has
        /// finished writing to a page. This function is typically used to 
        /// direct the device driver to advance to a new page.
        /// </summary>
        /// <param name="hdc">Handle to the device context for the print job.</param>
        /// <returns>If the function succeeds, the return value is greater than zero.
        /// If the function fails, the return value is less than or equal to zero.</returns>
        [DllImport("gdi32.dll")]
        internal static extern int EndPage(IntPtr hdc);

        /// <summary>
        /// The StartDocPrinter function notifies the print spooler
        /// that a document is to be spooled for printing.
        /// </summary>
        /// <param name="hPrinter">Handle to the printer. Use the OpenPrinter or
        /// AddPrinter function to retrieve a printer handle.</param>
        /// <param name="level">Specifies the version of the structure to 
        /// which pDocInfo points. On WIndows NT/2000/XP, the value must be 1.</param>
        /// <param name="di">Pointer to a structure that describes the document to print.</param>
        /// <returns>If the function succeeds, the return value identifies the print job.
        /// If the function fails, the return value is zero. </returns>
        [DllImport(
            "winspool.drv",
            EntryPoint = "StartDocPrinterW",
            SetLastError = true,
            CharSet = CharSet.Unicode,
            ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool StartDocPrinter(
            IntPtr hPrinter,
            int level,
            [In, MarshalAs(UnmanagedType.LPStruct)] DOC_INFO_1 di);

        [DllImport(
            "winspool.drv",
            EntryPoint = "EndDocPrinter",
            SetLastError = true,
            ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport(
            "winspool.drv",
            EntryPoint = "StartPagePrinter",
            SetLastError = true,
            ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport(
            "winspool.drv",
            EntryPoint = "EndPagePrinter",
            SetLastError = true,
            ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport(
            "winspool.drv",
            EntryPoint = "WritePrinter",
            SetLastError = true,
            ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool WritePrinter(
            IntPtr hPrinter,
            IntPtr pBytes,
            int dwCount,
            out int dwWritten);

        /// <summary>
        /// The DOCINFO structure contains the input and output file names and 
        /// other information used by the StartDoc function.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal class DOCINFO
        {
            /// <summary>
            /// The size, in bytes, of the structure.
            /// </summary>
            public int cbSize = 20;

            /// <summary>
            /// Pointer to a null-terminated string that specifies the name
            /// of the document.
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszDocName;

            /// <summary>
            /// Pointer to a null-terminated string that specifies the name of 
            /// an output file. If this pointer is NULL, the output will be 
            /// sent to the device identified by the device context handle that 
            /// was passed to the StartDoc function.
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszOutput;

            /// <summary>
            /// Pointer to a null-terminated string that specifies the type of 
            /// data used to record the print job. The legal values for this 
            /// member can be found by calling EnumPrintProcessorDatatypes and 
            /// can include such values as raw, emf, or XPS_PASS. This member 
            /// can be NULL. Note that the requested data type might be ignored.
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszDatatype;

            /// <summary>
            /// Specifies additional information about the print job. This 
            /// member must be zero or one of the following values.
            /// </summary>
            public int fwType;
        }

        /// <summary>
        /// The DOC_INFO_1 structure describes a document that will be printed.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal class DOC_INFO_1
        {
            /// <summary>
            /// Pointer to a null-terminated string that specifies the name of
            /// the document.
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDocName;

            /// <summary>
            /// Pointer to a null-terminated string that specifies the name of
            /// an output file. To print to a printer, set this to NULL.
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pOutputFile;

            /// <summary>
            /// Pointer to a null-terminated string that identifies the type 
            /// of data used to record the document.
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDataType;
        }
    }













    public static class PosExt
    {
        public static void Enlarged(this BinaryWriter bw, string text)
        {
            bw.Write(AsciiControlChars.Escape);
            bw.Write((byte)33);
            bw.Write((byte)32);
            bw.Write(text);
            bw.Write(AsciiControlChars.Newline);
        }
        public static void High(this BinaryWriter bw, string text)
        {
            bw.Write(AsciiControlChars.Escape);
            bw.Write((byte)33);
            bw.Write((byte)16);
            bw.Write(text); //Width,enlarged
            bw.Write(AsciiControlChars.Newline);
        }
        public static void LargeText(this BinaryWriter bw, string text)
        {
            bw.Write(AsciiControlChars.Escape);
            bw.Write((byte)33);
            bw.Write((byte)48);
            bw.Write(text);
            bw.Write(AsciiControlChars.Newline);
        }
        public static void FeedLines(this BinaryWriter bw, int lines)
        {
            bw.Write(AsciiControlChars.Newline);
            if (lines > 0)
            {
                bw.Write(AsciiControlChars.Escape);
                bw.Write('d');
                bw.Write((byte)lines - 1);
            }
        }

        public static void Finish(this BinaryWriter bw)
        {
            bw.FeedLines(1);
            bw.NormalFont("---  Thank You, Come Again ---");
            bw.FeedLines(1);
            bw.Write(AsciiControlChars.Newline);
        }

        public static void NormalFont(this BinaryWriter bw, string text, bool line = true)
        {
            bw.Write(AsciiControlChars.Escape);
            bw.Write((byte)33);
            bw.Write((byte)8);
            bw.Write(" " + text);
            if (line)
                bw.Write(AsciiControlChars.Newline);
        }



        /*
27 33 0     ESC ! NUL    Master style: pica                              ESC/P
27 33 1     ESC ! SOH    Master style: elite                             ESC/P
27 33 2     ESC ! STX    Master style: proportional                      ESC/P
27 33 4     ESC ! EOT    Master style: condensed                         ESC/P
27 33 8     ESC ! BS     Master style: emphasised                        ESC/P
27 33 16    ESC ! DLE    Master style: enhanced (double-strike)          ESC/P
27 33 32    ESC ! SP     Master style: enlarged (double-width)           ESC/P
27 33 64    ESC ! @      Master style: italic                            ESC/P
27 33 128   ESC ! ---    Master style: underline                         ESC/P
                     Above values can be added for combined styles.
         
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)33);
        bw.Write((byte)0);
        bw.Write("test"); //Default, Pica
        bw.Write(AsciiControlChars.Newline);
 
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)33);
        bw.Write((byte)4);
        bw.Write("test"); //condensed
        bw.Write(AsciiControlChars.Newline);
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)33);
        bw.Write((byte)8);
        bw.Write("test"); //emphasised
        bw.Write(AsciiControlChars.Newline);
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)33);
        bw.Write((byte)16);
        bw.Write("test"); //Height,enhanced
        bw.Write(AsciiControlChars.Newline);
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)33);
        bw.Write((byte)32);
        bw.Write("test"); //Width,enlarged
        bw.Write(AsciiControlChars.Newline);
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)33);
        bw.Write((byte)48);
        bw.Write("test");   //WxH
        bw.Write(AsciiControlChars.Newline);
             */
    }















    /// <summary>
    /// A listing of ASCII control characters for readability.
    /// </summary>
    public static class AsciiControlChars
    {
        /// <summary>
        /// Usually indicates the end of a string.
        /// </summary>
        public const char Nul = (char)0x00;

        /// <summary>
        /// Meant to be used for printers. When receiving this code the 
        /// printer moves to the next sheet of paper.
        /// </summary>
        public const char FormFeed = (char)0x0C;

        /// <summary>
        /// Starts an extended sequence of control codes.
        /// </summary>
        public const char Escape = (char)0x1B;

        /// <summary>
        /// Advances to the next line.
        /// </summary>
        public const char Newline = (char)0x0A;

        /// <summary>
        /// Defined to separate tables or different sets of data in a serial
        /// data storage system.
        /// </summary>
        public const char GroupSeparator = (char)0x1D;

        /// <summary>
        /// A horizontal tab.
        /// </summary>
        public const char HorizontalTab = (char)0x09;


        /// <summary>
        /// Vertical Tab
        /// </summary>
        public const char VerticalTab = (char)0x11;


        /// <summary>
        /// Returns the carriage to the start of the line.
        /// </summary>
        public const char CarriageReturn = (char)0x0D;

        /// <summary>
        /// Cancels the operation.
        /// </summary>
        public const char Cancel = (char)0x18;

        /// <summary>
        /// Indicates that control characters present in the stream should
        /// be passed through as transmitted and not interpreted as control
        /// characters.
        /// </summary>
        public const char DataLinkEscape = (char)0x10;

        /// <summary>
        /// Signals the end of a transmission.
        /// </summary>
        public const char EndOfTransmission = (char)0x04;

        /// <summary>
        /// In serial storage, signals the separation of two files.
        /// </summary>
        public const char FileSeparator = (char)0x1C;

    }
}



