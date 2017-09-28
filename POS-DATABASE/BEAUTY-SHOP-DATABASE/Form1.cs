using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace BEAUTY_SHOP_DATABASE
{
    public partial class Form1 : Form
    {
        DialogResult dialog;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void installDatabase() {
             dialog = MessageBox.Show("Do you want to uninstall the old database before installing the new one?", "UNINSTALL DATABASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if (dialog == DialogResult.Yes)
             {
                 try
                 {

                     string db = "datasource='" + this.datasourceTextBox.Text + "'; port='" + this.portNumberTextBox.Text + "'; username='" + this.usernameTextBox.Text + "'; password='" + this.passwordTextBox.Text + "'; database='" + this.databaseNameTextBox.Text + "' ";
                
                     MySqlConnection con = new MySqlConnection(db);

                     con.Open();

                     MySqlCommand drop = new MySqlCommand("DROP DATABASE IF EXISTS `" + this.databaseNameTextBox.Text + "`", con);

                     drop.ExecuteNonQuery();

                     con.Close();
                     MessageBox.Show("Database Uninstalled successfully!! Click Ok to proceed to new Installation.", "DATABASE UNINSTAL SUCCESSFUL ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     createDatabase();
                     createTables();

                 }
                 catch (Exception )
                 {
                     MessageBox.Show("Error has occured while uninstalling the current database.", "DATABASE UNINSTAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  
                 }

             }
             else {
                 createDatabase();
                 createTables();
             }
        
        }


        //create database
        public void createDatabase()
        {
            try
            {
                string db = "datasource='" + this.datasourceTextBox.Text + "'; port='" + this.portNumberTextBox.Text + "'; username='" + this.usernameTextBox.Text + "'; password='" + this.passwordTextBox.Text + "' ";
               
                MySqlConnection con = new MySqlConnection(db);

                con.Open();

                MySqlCommand mc1 = new MySqlCommand("CREATE DATABASE IF NOT EXISTS `" + this.databaseNameTextBox.Text + "` ", con);

                mc1.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception )
            {
                MessageBox.Show("Error has occured while creating the database.", "DATABASE CREATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        public void cretaeFirstUser() {
            try
            {
                string db = "datasource='" + this.datasourceTextBox.Text + "'; port='" + this.portNumberTextBox.Text + "'; username='" + this.usernameTextBox.Text + "'; password='" + this.passwordTextBox.Text + "'; database='" + this.databaseNameTextBox.Text + "' ";
                
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand mc = new MySqlCommand("SELECT * FROM staff", con);

                MySqlDataReader mr = mc.ExecuteReader();

                int count = 0;

                while (mr.Read())
                {
                         count += 1;
                  }

                mr.Close();

                if (count < 1)
                {
                    MySqlCommand c = new MySqlCommand("INSERT INTO staff VALUES('3030','22','22','" + dateNow + "','22','22','22','22','22','22','" + dateNow + "','Manager','3030','22','Active')", con);
                    c.ExecuteNonQuery();

                    // Insert into vat a default value.
                    MySqlCommand vatQuery = new MySqlCommand("INSERT INTO vat VALUES('1','00.00','XXXXX','XXXXX','XXXXX','XXXXX','XXXXX','XXXXX','XXXXXX','NO')", con);
                    vatQuery.ExecuteNonQuery();

                    MySqlCommand serverDetails = new MySqlCommand("INSERT INTO server_details VALUES(NULL,'" + this.datasourceTextBox.Text + "','" + this.usernameTextBox.Text + "','" + this.portNumberTextBox.Text + "','" + this.passwordTextBox.Text + "','" + this.databaseNameTextBox.Text + "','" + this.copyrightTextBox.Text + "' )", con);
                    serverDetails.ExecuteNonQuery();


                }
                else {
                    MessageBox.Show("The user already exists.", "REGISTER DEFAULT USER ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                con.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
              //  MessageBox.Show("Error has occured while registering default user.", "DEFAULT USER REGISTRATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }


        //create database
        public void createTables()
        {
            try
            {
                string db = "datasource='" + this.datasourceTextBox.Text + "'; port='" + this.portNumberTextBox.Text + "'; username='" + this.usernameTextBox.Text + "'; password='" + this.passwordTextBox.Text + "'; database='" + this.databaseNameTextBox.Text + "' ";
                MySqlConnection con = new MySqlConnection(db);

                con.Open();

                MySqlCommand mc1 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `staff`(pfno varchar(30) NOT NULL PRIMARY KEY,firstname varchar(100) NOT NULL, lastname varchar(100) NOT NULL, dob DATETIME NOT NULL,gender varchar(10) NOT NULL,nationalid int(30) NOT NULL UNIQUE,phone varchar(30), email varchar(100),county varchar(100) NOT NULL, location varchar(150),doe DATETIME NOT NULL,category varchar(100) NOT NULL,password varchar(100) NOT NULL, photo BLOB ,status varchar(20) NOT NULL)", con);
                MySqlCommand mcd = new MySqlCommand("CREATE TABLE IF NOT EXISTS  `supplier`(id int(30) NOT NULL PRIMARY KEY AUTO_INCREMENT,name varchar(200) NOT NULL UNIQUE KEY,phone varchar(30) NOT NULL,address varchar(100), location varchar(200) NOT NULL,pfno varchar(30) NOT NULL, registered_date DATETIME NOT NULL,status varchar(20) NOT NULL, FOREIGN KEY(pfno) REFERENCES staff(pfno) ON UPDATE CASCADE)", con);
                MySqlCommand mcd1 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `product` (`id` bigint(30) NOT NULL AUTO_INCREMENT,`name` varchar(200) NOT NULL,`form` varchar(100) NOT NULL,`pfno` varchar(100) NOT NULL,`registered_date` datetime NOT NULL,`status` varchar(20) NOT NULL,PRIMARY KEY (`id`),UNIQUE KEY `name` (`name`),KEY `pfno` (`pfno`),CONSTRAINT `product_ibfk_1` FOREIGN KEY (`pfno`) REFERENCES `staff` (`pfno`) ON UPDATE CASCADE)",con);
                MySqlCommand mcd2 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `stock` (  `stock_id` bigint(44) NOT NULL AUTO_INCREMENT,  `supplier_id` int(22) NOT NULL,  `initial_quantity` decimal(16,2) NOT NULL,  `quantity_sold` decimal(16,2) NOT NULL,  `buying_price` decimal(11,2) NOT NULL, `selling_price` decimal(11,2) NOT NULL,  `product_id` bigint(33) NOT NULL,  `units` varchar(100) NOT NULL, `expiry_date` datetime NOT NULL,  `batch_no` varchar(50) NOT NULL,  `pfno` varchar(100) NOT NULL,  `registered_date` datetime NOT NULL,  `status` int(2) NOT NULL,  `reoder_level` int(11) NOT NULL,  PRIMARY KEY (`stock_id`),  KEY `supplier_id` (`supplier_id`), KEY `product_id` (`product_id`), KEY `pfno` (`pfno`), CONSTRAINT `stock_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `supplier` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,  CONSTRAINT `stock_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE, CONSTRAINT `stock_ibfk_3` FOREIGN KEY (`pfno`) REFERENCES `staff` (`pfno`) ON UPDATE CASCADE)",con);
                MySqlCommand mcd3 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `debtor` (`id` bigint(30) NOT NULL AUTO_INCREMENT,`name` varchar(200) NOT NULL,`stock_id` bigint(44) NOT NULL,`quantity` decimal(16,2) NOT NULL, `price` decimal(11,2) NOT NULL,`date_borrowed` datetime NOT NULL, `phone` varchar(30) NOT NULL,`deposit` decimal(11,2) NOT NULL, `date_of_payment` datetime DEFAULT NULL,`pfno` varchar(100) NOT NULL,`registered_date` datetime NOT NULL,PRIMARY KEY (`id`),KEY `stock_id` (`stock_id`),KEY `pfno` (`pfno`),CONSTRAINT `debtor_ibfk_1` FOREIGN KEY (`stock_id`) REFERENCES `stock` (`stock_id`) ON DELETE CASCADE ON UPDATE CASCADE, CONSTRAINT `debtor_ibfk_2` FOREIGN KEY (`pfno`) REFERENCES `staff` (`pfno`) ON UPDATE CASCADE)",con);     
                MySqlCommand mcd5 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `sales` (  `sales_id` bigint(44) NOT NULL AUTO_INCREMENT, `cart_id` bigint(44) NOT NULL,  `stock_id` bigint(44) NOT NULL, `quantity` double(11,2) NOT NULL,  `price` decimal(11,2) NOT NULL,`pfno` varchar(100) NOT NULL,`sales_date` datetime NOT NULL,`serial` varchar(100) NOT NULL, `discount` varchar(20) DEFAULT NULL, PRIMARY KEY (`sales_id`), KEY `stock_id` (`stock_id`), KEY `pfno` (`pfno`), CONSTRAINT `sales_ibfk_1` FOREIGN KEY (`stock_id`) REFERENCES `stock` (`stock_id`) ON UPDATE CASCADE, CONSTRAINT `sales_ibfk_2` FOREIGN KEY (`pfno`) REFERENCES `staff` (`pfno`) ON UPDATE CASCADE)",con);
                MySqlCommand mcd6 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `cart` (`cart_id` bigint(33) NOT NULL AUTO_INCREMENT,`stock_id` bigint(44) NOT NULL,`quantity` double(11,2) NOT NULL, `price` decimal(11,2) NOT NULL,PRIMARY KEY (`cart_id`),KEY `stock_id` (`stock_id`), CONSTRAINT `cart_ibfk_1` FOREIGN KEY (`stock_id`) REFERENCES `stock` (`stock_id`) ON UPDATE CASCADE )",con);
                MySqlCommand mcd7 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `events`(event_id bigint(33) NOT NULL PRIMARY KEY AUTO_INCREMENT, pfno varchar(50) NOT NULL, event_time DATETIME NOT NULL, description varchar(200) NOT NULL, FOREIGN KEY(pfno) REFERENCES staff(pfno)  ON UPDATE CASCADE)", con);
                MySqlCommand mcd8 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `vat`(vat_id varchar(2) NOT NULL PRIMARY KEY, vat_value decimal(11,2)NOT NULL,etr_id varchar(50), pin varchar(50), business_name varchar(100), address varchar(50), location varchar(100),phone varchar(50),printer_name varchar(100), print_receipt varchar(10))", con);
                MySqlCommand mcd9 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `product_form`(product_form_id int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY, form_name VARCHAR(50)NOT NULL UNIQUE KEY)", con);
                MySqlCommand mcd12 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `expense_type`(expense_type_id int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY, type VARCHAR(100)NOT NULL UNIQUE KEY)", con);
                MySqlCommand mcd13 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `expenses`(expense_id bigint(33) NOT NULL AUTO_INCREMENT PRIMARY KEY, expense_name VARCHAR(100)NOT NULL, expense_type_id int(11) NOT NULL, description TEXT, amount decimal(11,2) NOT NULL,expense_date datetime NOT NULL,status int (2) NOT NULL, pfno varchar(50) NOT NULL, FOREIGN KEY (expense_type_id) REFERENCES `expense_type` (`expense_type_id`) ON UPDATE CASCADE, FOREIGN KEY(pfno) REFERENCES staff(pfno)  ON UPDATE CASCADE)", con);
               

                MySqlCommand mcd11 = new MySqlCommand("CREATE TABLE IF NOT EXISTS `server_details`(id int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,datasource varchar(100) NOT NULL, port VARCHAR(50)NOT NULL,username varchar(100) NOT NULL, password varchar(100), database_name varchar(20) NOT NULL, system_copyright_details varchar(150) NOT NULL)", con);
               

        // Purchase order system tables.
                MySqlCommand supplierPriceList = new MySqlCommand("CREATE TABLE IF NOT EXISTS `supplier_price_list`(supplier_id int(11) NOT NULL, product_id bigint(30) NOT NULL,price decimal(11,2)NOT NULL, date_added DATETIME NOT NULL, added_by varchar(20) NOT NULL, PRIMARY KEY(supplier_id,product_id),FOREIGN KEY(added_by) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE,FOREIGN KEY(supplier_id) REFERENCES supplier(id) ON DELETE CASCADE ON UPDATE CASCADE,FOREIGN KEY(product_id) REFERENCES product(id)  ON UPDATE CASCADE)", con);
                MySqlCommand minOrderPriceList = new MySqlCommand("CREATE TABLE IF NOT EXISTS `min_order_price_list`(supplier_id int(11) NOT NULL, product_id bigint(30) NOT NULL,price decimal(11,2)NOT NULL,quantity decimal (22,2) NOT NULL, date_added DATETIME NOT NULL, added_by varchar(20) NOT NULL, PRIMARY KEY(supplier_id,product_id),FOREIGN KEY(added_by) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE,FOREIGN KEY(supplier_id) REFERENCES supplier(id) ON DELETE CASCADE ON UPDATE CASCADE,FOREIGN KEY(product_id) REFERENCES product(id) ON UPDATE CASCADE)", con);
                MySqlCommand orderPriceList = new MySqlCommand("CREATE TABLE IF NOT EXISTS `order_price_list`( supplier_id int(11) NOT NULL, product_id bigint(30) NOT NULL,price decimal(11,2)NOT NULL,quantity decimal (22,2) NOT NULL, date_added DATETIME NOT NULL, added_by varchar(20) NOT NULL, PRIMARY KEY(supplier_id,product_id),FOREIGN KEY(added_by) REFERENCES staff(pfno) ON DELETE CASCADE ON UPDATE CASCADE,FOREIGN KEY(supplier_id) REFERENCES supplier(id) ON DELETE CASCADE ON UPDATE CASCADE,FOREIGN KEY(product_id) REFERENCES product(id)  ON UPDATE CASCADE)", con);
                MySqlCommand minOrderPriceListHistory = new MySqlCommand("CREATE TABLE IF NOT EXISTS `min_order_price_list_history`( supplier_name varchar(100) NOT NULL, product_name varchar(100) NOT NULL,price varchar(30)NOT NULL,quantity varchar (30) NOT NULL, date_added DATETIME NOT NULL, added_by varchar(20) NOT NULL,FOREIGN KEY(added_by) REFERENCES staff(pfno)  ON UPDATE CASCADE)", con);
                MySqlCommand orderPriceListHistory = new MySqlCommand("CREATE TABLE IF NOT EXISTS `order_price_list_history`(supplier_name varchar(100) NOT NULL, product_name varchar(100) NOT NULL,price varchar(30)NOT NULL,quantity varchar (30) NOT NULL, date_added DATETIME NOT NULL, added_by varchar(20) NOT NULL,FOREIGN KEY(added_by) REFERENCES staff(pfno)  ON UPDATE CASCADE)", con);
                // End purchase order system tables.

                // NOTIFICATION MODULE TABLES //////////////////////
                MySqlCommand messagein = new MySqlCommand("CREATE TABLE IF NOT EXISTS `ozekimessagein` (`id` bigint(44) NOT NULL AUTO_INCREMENT,`sender` varchar(30) DEFAULT NULL,`receiver` varchar(30) DEFAULT NULL,`msg` varchar(160) DEFAULT NULL,`senttime` varchar(100) DEFAULT NULL,`receivedtime` varchar(100) DEFAULT NULL,`operator` varchar(100) DEFAULT NULL,`msgtype` varchar(160) DEFAULT NULL,`reference` varchar(100) DEFAULT NULL,PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;)",con);
                MySqlCommand messageout = new MySqlCommand("CREATE TABLE `ozekimessageout` (`id` int(11) NOT NULL AUTO_INCREMENT,`sender` varchar(30) DEFAULT NULL,`receiver` varchar(30) DEFAULT NULL,`msg` varchar(256) DEFAULT NULL,`senttime` datetime DEFAULT NULL,`receivedtime` datetime DEFAULT NULL,`reference` varchar(100) DEFAULT NULL,`status` varchar(20) DEFAULT NULL,`msgtype` varchar(160) DEFAULT NULL,`operator` varchar(100) DEFAULT NULL,PRIMARY KEY (`id`))ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;", con);
                MySqlCommand op=new MySqlCommand("CREATE TABLE IF NOT EXISTS `operator`(sender varchar(100),operator varchar(100),organization varchar(100))",con);
                // END NOTIFICATION MODULE TABLES ///////////////////

                mc1.ExecuteNonQuery();
                mcd.ExecuteNonQuery();
                mcd1.ExecuteNonQuery();
                mcd2.ExecuteNonQuery();
                mcd3.ExecuteNonQuery();
              //  mcd4.ExecuteNonQuery();
                mcd5.ExecuteNonQuery();
                mcd6.ExecuteNonQuery();
                mcd7.ExecuteNonQuery();
                mcd8.ExecuteNonQuery();
                mcd9.ExecuteNonQuery();
                mcd11.ExecuteNonQuery();
                mcd12.ExecuteNonQuery();
                mcd13.ExecuteNonQuery();

                // Purchase order system tables.
                supplierPriceList.ExecuteNonQuery();
                minOrderPriceList.ExecuteNonQuery();
                orderPriceList.ExecuteNonQuery();
                minOrderPriceListHistory.ExecuteNonQuery();
                orderPriceListHistory.ExecuteNonQuery();

                // message tables.
               // messagein.ExecuteNonQuery();
              //  messageout.ExecuteNonQuery();
             //   op.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Congradulations, you have successfully installed the database.", "INSTALLATION SUCCESS ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                // MessageBox.Show("Error when creatint tables; "+ex.Message);
               MessageBox.Show("Error has occured while creating tables.", "SCHEMA CREATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cretaeFirstUser();
        }




        // Create a file and write to it.
        public void serverDetailsFile()
        {
            try
            {

                string configDetails = "datasource='" + this.datasourceTextBox.Text + "'; port='" + this.portNumberTextBox.Text + "'; username='" + this.usernameTextBox.Text + "'; password='" + this.passwordTextBox.Text + "'; database='" + this.databaseNameTextBox.Text + "' ";

                //string file = "C:\\PMS\\Data\\backup.sql";
                string fileLocation = "C:\\POS\\Data\\Server-Details.txt";
                FileStream fs = null;

                if (!File.Exists(fileLocation))
                {
                    // fs = File.Create(fileLocation);

                    //Write to the file.
                    fs = new FileStream(fileLocation, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    writer.Write(configDetails);
                    writer.Close();



                }
                else
                {
                    // Delete the file then write again.
                    File.Delete(fileLocation);

                    // fs = File.Create(fileLocation);

                    //Write to the file.
                    fs = new FileStream(fileLocation, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    writer.Write(configDetails);
                    writer.Close();


                }
            }
            catch (Exception )
            {
               MessageBox.Show("Error has occured while configuring the database. Check the configuration file location.");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            serverDetailsFile();
            installDatabase();
        }

        private void updateServerDetailsButton_Click(object sender, EventArgs e)
        {
            serverDetailsFile();

            string db = "datasource='" + this.datasourceTextBox.Text + "'; port='" + this.portNumberTextBox.Text + "'; username='" + this.usernameTextBox.Text + "'; password='" + this.passwordTextBox.Text + "'; database='" + this.databaseNameTextBox.Text + "' ";
            MySqlConnection con = new MySqlConnection(db);

            try
            {
                dialog = MessageBox.Show("Are you sure you want to update the server details?", "SERVER DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {

                    con.Open();
                    MySqlCommand c = new MySqlCommand("UPDATE `server_details` SET datasource='" + this.datasourceTextBox.Text + "', port='" + this.portNumberTextBox.Text + "', username='" + this.usernameTextBox.Text + "', password='" + this.passwordTextBox.Text + "', database_name='" + this.databaseNameTextBox.Text + "', system_copyright_details='" + this.copyrightTextBox.Text + "' WHERE id='1' ", con);

                    c.ExecuteNonQuery();

                    MessageBox.Show("SERVER DETAILS UPDATED SUCCESSFULLY", "SERVER DETAILS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Has occured" + ex.Message);
            }
            con.Close();
        }

    }
}
