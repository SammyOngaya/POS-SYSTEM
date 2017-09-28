using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
//using MySql.Data.MySqlBackup;


using System.Threading;
using System.IO;


namespace POS_SYSTEM
{
    public partial class Reports : Form
    {
        public Reports(string ms, string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            setTime();

            pfsession.Text = ms;

            //staff reports
             viewDebtor();
            totalStaffReports();
           // totalMaleStaffReports();
            //totalFemaleStaffReports();
            totalMangerStaffReports();
            totalPharmacistStaffReports();

            //PRODUCT REPORTS
            totalProductsReports();

            //SUPPLIER REPORTS
            totalSupplierReports();

           
          
            //expired products
            expiredProducts();

            //FINISHED PRODUCTS
            finishedProducts();

            //low product quantity beep
            lowProductQuantityBeeps();
            expiredProductsBeeps();

            
        }

        DialogResult dialog;


        private void button11_Click(object sender, EventArgs e)
        {

            DebtorPayDebt v = new DebtorPayDebt(pfsession.Text, databaseConnectionStringTextBox.Text);
            v.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReportNetStock reportNetStock = new ReportNetStock(databaseConnectionStringTextBox.Text);
            reportNetStock.ShowDialog();
        
        }

        //set time
        public void setTime()
        {
            DateTime salestime = DateTime.Now;
            this.time.Text = salestime.ToString();
        }

        //low quantity products
        public void lowProductQuantityBeeps() {

            try
            {
                int count = int.Parse(ExpiredDrugLabel.Text);

                if (count > 1) {
                  //  for (int i = 0; i < count; i++)
                  //  {
                        Console.Beep();
                        Thread.Sleep(1000);
                   // }

                    MessageBox.Show(count+" products are out of stock","FINISHED PRODUCTS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else if (count == 1)
                {
                    MessageBox.Show(count + " product is out of stock", "FINISHED PRODUCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
            }

        }

        //expires products notification
        public void expiredProductsBeeps()
        {

            try
            {
                int count = int.Parse(finishedDrugLabel.Text);

                if (count > 1)
                {
                   // for (int i = 0; i < count; i++)
                  //  {
                        Console.Beep();
                        Thread.Sleep(1000);
                  //  }

                        MessageBox.Show(count + " products have expired", "EXPIRED PRODUCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (count == 1)
                {
                    MessageBox.Show(count + " product has expired", "EXPIRED PRODUCT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else { 
                
                }
               
            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
            }

        }


       // total staff reports
        public void totalStaffReports() {
             try
             {
                 string db = databaseConnectionStringTextBox.Text;
                 MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM staff",con);
             //  MySqlDataReader mr = mc.ExecuteReader();

                   Int64 count = (Int64)mc.ExecuteScalar();

                   reportsTotalStaffs.Text = count.ToString();
             
                con.Close();
              
            }
            catch (Exception ) {
                  //MessageBox.Show(ex.Message);
            }
        }
      

        // total Managers staff reports
        public void totalMangerStaffReports()
        {
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM staff WHERE category='Manager'", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                reportsManagers.Text = count.ToString();

                con.Close();

            }
            catch (Exception )
            {
              //  MessageBox.Show(ex.Message);
            }
        }

       
        // total Suppervisor staff reports
        public void totalPharmacistStaffReports()
        {
             try
             {
                 string db = databaseConnectionStringTextBox.Text;
                 MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM staff WHERE category='Pharmacist'", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                reportsPharmacists.Text = count.ToString();

                con.Close();

            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
            }
        }
        

            ///////===========PRODUCT==========

        // total products reports
        public void totalProductsReports()
        {
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM product", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                totalProducts.Text = count.ToString();

                con.Close();

            }
            catch (Exception )
            {
               //MessageBox.Show(ex.Message);
            }
        }

           ///////===========SUPPLIER==========

             // total supplier reports
        public void totalSupplierReports()
        {
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT COUNT(*) FROM supplier", con);
                //  MySqlDataReader mr = mc.ExecuteReader();

                Int64 count = (Int64)mc.ExecuteScalar();

                totalSupplier.Text = count.ToString();

                con.Close();

            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
            }
        }
        
   
       

        //EXPIRED PRODUCTS
        public void expiredProducts()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();
                DateTime dtt = DateTime.Now;
                String dateNow = dtt.ToString("yyyy-MM-dd");

                MySqlCommand com = new MySqlCommand("SELECT `stock`.`stock_id` AS 'STOCK ID',`product`.`name` AS 'PRODUCT NAME', expiry_date AS 'EXPIRY DATE',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY', DATEDIFF(expiry_date,'" + dateNow + "') AS 'DAYS PASSED' FROM product JOIN stock ON `product`.`id`=`stock`.`product_id` WHERE ((DATEDIFF(expiry_date,'" + dateNow + "')<=0) AND (`stock`.`initial_quantity`>`stock`.`quantity_sold`) AND (`stock`.`status`='1')) ", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dt = new DataTable();
                // Add autoincrement column.
                dt.Columns.Add("#", typeof(int));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["#"] };
                dt.Columns["#"].AutoIncrement = true;
                dt.Columns["#"].AutoIncrementSeed = 1;
                dt.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                expiredProductDataGridView.DataSource = bs;

                a.Update(dt);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(expiredProductDataGridView.Rows.Count) - 1;
                ExpiredDrugLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           // DateTime dtt = DateTime.Now;
           // String dateNow = dtt.ToString("MM/dd/yyyy");
            // textBox2.Text = dateNow;



        }

        //FINISHED PRODUCTS
        public void finishedProducts()
        {
           
            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT  `stock`.`stock_id` AS 'STOCK ID',`product`.`name` AS 'PRODUCT NAME',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY',`stock`.`reoder_level` AS 'RE-ODER LEVEL' FROM product JOIN stock ON `product`.`id`=`stock`.`product_id` WHERE ((`stock`.`status`='1') AND ((`stock`.`initial_quantity`-`stock`.`quantity_sold`) <= (`reoder_level`))) ", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dt = new DataTable();
                // Add autoincrement column.
                dt.Columns.Add("#", typeof(int));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["#"] };
                dt.Columns["#"].AutoIncrement = true;
                dt.Columns["#"].AutoIncrementSeed = 1;
                dt.Columns["#"].ReadOnly = true;
                // End adding AI column.
                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                finishedProductsdataGridView1.DataSource = bs;

                a.Update(dt);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(finishedProductsdataGridView1.Rows.Count) - 1;
                finishedDrugLabel.Text = count.ToString() + " Records";
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);
            }


        }

        public void viewDebtor()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                DateTime dtt = DateTime.Now;
                string dateNow = dtt.ToString("yyyy-MM-dd");

                
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand com = new MySqlCommand("SELECT DISTINCT(phone) AS 'PHONE',name AS 'NAMES',date_of_payment AS 'DATE OF PAYMENT' FROM `debtor`  WHERE ((DATEDIFF(`debtor`.`date_of_payment`,'" + dateNow + "')<=0) AND ((quantity*price)>deposit))  ORDER BY date_of_payment DESC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                DataTable dt = new DataTable();

                // Add autoincrement column.
               dt.Columns.Add("#", typeof(string));
                dt.PrimaryKey = new DataColumn[] {dt.Columns["#"] };
               dt.Columns["#"].AutoIncrement = true;
               dt.Columns["#"].AutoIncrementSeed = 1;
               dt.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
               dt.Columns.Add("NAMES");
               dt.Columns.Add("PHONE");
               dt.Columns.Add("DATE OF PAYMENT", typeof(string));
                // End formating titles.

                a.Fill(dt);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                viewDebtorDataGridView.DataSource = bs;

                a.Update(dt);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewDebtorDataGridView.Rows.Count) - 1;
                totalUpaidDebtorslabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                string db = databaseConnectionStringTextBox.Text;

                MySqlConnection con = new MySqlConnection(db);

                if (finishedProductsdataGridView1.SelectedRows.Count > 0)
                {

                    dialog = MessageBox.Show("Are you sure you want to remove finished product from stock?", "REMOVE FINISHED PRODUCT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        int selectedIndex = finishedProductsdataGridView1.SelectedRows[0].Index;
                        int RowID = int.Parse(finishedProductsdataGridView1[1, selectedIndex].Value.ToString());

                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("UPDATE stock set status='0' WHERE stock_id = " + RowID + "", con);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("sales id is : " + salesReportDataGridView[2, selectedIndex].Value.ToString());
                        con.Close();

                        MessageBox.Show("DruProductg Removed Successfully", "FINISHED PRODUCT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        finishedProducts();
                    }
                }
                else
                {
                    MessageBox.Show("No Product selected", "NO PRODUCT SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has occured while removing finished product!" + ex.Message);
            }
            finally
            {
                //salesView();
            }
             
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                string db = databaseConnectionStringTextBox.Text;

                MySqlConnection con = new MySqlConnection(db);

                if (expiredProductDataGridView.SelectedRows.Count > 0)
                {
                    dialog = MessageBox.Show("Are you sure you want to update product expiry date?", "UPDATE EXPIRY DATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        int selectedIndex = expiredProductDataGridView.SelectedRows[0].Index;
                        int RowID = int.Parse(expiredProductDataGridView[1, selectedIndex].Value.ToString());

                        DateTime date = DateTime.Parse(expiredProductDataGridView[3, selectedIndex].Value.ToString());
                        string expiryDate = date.ToString("yyyy-MM-dd");

                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("UPDATE stock set expiry_date='" + expiryDate + "' WHERE stock_id = " + RowID + "", con);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("sales id is : " + salesReportDataGridView[2, selectedIndex].Value.ToString());
                        con.Close();

                        MessageBox.Show("Product updated Successfully", "EXPIRED PRODUCT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        expiredProducts();
                    }
                }
                else
                {
                    MessageBox.Show("No Product selected", "NO PRODUCT SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has occured while updating product expiry date!" + ex.Message);
            }
            finally
            {
                //salesView();
            }
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            dialog = MessageBox.Show("Are you sure you want to remove expired product from stock?", "REMOVE EXPIRED PRODUCT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string db = databaseConnectionStringTextBox.Text;
            if (dialog == DialogResult.Yes)
            {

                try
                {

                    MySqlConnection con = new MySqlConnection(db);

                    if (expiredProductDataGridView.SelectedRows.Count > 0)
                    {

                        int selectedIndex = expiredProductDataGridView.SelectedRows[0].Index;
                        int RowID = int.Parse(expiredProductDataGridView[1, selectedIndex].Value.ToString());

                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("UPDATE stock set status='0' WHERE stock_id = " + RowID + "", con);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("sales id is : " + salesReportDataGridView[2, selectedIndex].Value.ToString());
                        con.Close();

                        MessageBox.Show("Product Removed Successfully", "EXPIRED PRODUCT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        expiredProducts();
                    }
                    else
                    {
                        MessageBox.Show("No Product selected", "NO PRODUCT SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has occured while removing expired product!" + ex.Message);
                }
                finally
                {
                    //salesView();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddStock a = new AddStock(pfsession.Text, databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportStock stock = new ReportStock(databaseConnectionStringTextBox.Text);
            stock.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ReportDailySales rds = new ReportDailySales(databaseConnectionStringTextBox.Text);
            rds.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportSales salesReport = new ReportSales(databaseConnectionStringTextBox.Text);
            salesReport.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Log log = new Log(databaseConnectionStringTextBox.Text);
            log.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ExpiredPaymentDateDebtorReport debtor = new ExpiredPaymentDateDebtorReport(pfsession.Text,databaseConnectionStringTextBox.Text);
            debtor.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportDebtor debtor = new ReportDebtor(pfsession.Text,databaseConnectionStringTextBox.Text);
            debtor.ShowDialog();
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportPurchaseOrder purchase = new ReportPurchaseOrder(databaseConnectionStringTextBox.Text);
            purchase.ShowDialog();
        
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

    }
}
