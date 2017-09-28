using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
namespace POS_SYSTEM
{
    public partial class CashierReport : Form
    {
        MySqlConnection con = null;

        public CashierReport(string user, string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            pfSessionTextBox.Text = user;
            con = DBHandler.CreateConnection();
            //expired drugs
            expiredDrugs();

            //FINISHED DRUGS
            finisheddDrugs();
            viewDebtor();

            //low drug quantity beep
         //   lowDrugQuantityBeeps();
           // expiredDrugsBeeps();
        }
        private void CashierReport_Load(object sender, EventArgs e)
        {

        }


        //low quantity drugs
        public void lowDrugQuantityBeeps()
        {

            try
            {
                int count = int.Parse(ExpiredDrugLabel.Text);

                if (count > 1)
                {
                    //  for (int i = 0; i < count; i++)
                    //  {
                    Console.Beep();
                     //   Thread.Sleep(1000);
                    // }

                    MessageBox.Show(count + " products are out of stock", "FINISHED PRODUCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (count == 1)
                {
                    MessageBox.Show(count + " product is out of stock", "FINISHED PRODUCT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        //expires drugs notification
        public void expiredDrugsBeeps()
        {

            try
            {
                int count = int.Parse(finishedDrugLabel.Text);

                if (count > 1)
                {
                    // for (int i = 0; i < count; i++)
                    //  {
                    Console.Beep();
                    // Thread.Sleep(1000);
                    //  }

                    MessageBox.Show(count + " products have expired", "EXPIRED PRODUCTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (count == 1)
                {
                    MessageBox.Show(count + " product has expired", "EXPIRED PRODUCT", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                }

            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);
            }

        }



        //EXPIRED DRUGS
        public void expiredDrugs()
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
                expiredDrugDataGridView.DataSource = bs;

                a.Update(dt);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(expiredDrugDataGridView.Rows.Count) - 1;
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

        //FINISHED DRUGS
        public void finisheddDrugs()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

               // MySqlCommand com = new MySqlCommand("SELECT  `stock`.`stock_id` AS 'STOCK ID',`product`.`name` AS 'PRODUCT NAME',(`stock`.`initial_quantity`-`stock`.`quantity_sold`) AS 'REMAINING QUANTITY' FROM product JOIN stock ON `product`.`id`=`stock`.`product_id` WHERE ((`stock`.`status`='1') AND ((`stock`.`initial_quantity`-`stock`.`quantity_sold`) <= '" + level + "')) ", con);
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
                finishedDrugdataGridView1.DataSource = bs;

                a.Update(dt);
                con.Close();
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(finishedDrugdataGridView1.Rows.Count) - 1;
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
                dt.PrimaryKey = new DataColumn[] { dt.Columns["#"] };
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


        private void button12_Click(object sender, EventArgs e)
        {
             ExpiredPaymentDateDebtorReport debtor = new ExpiredPaymentDateDebtorReport(pfSessionTextBox.Text,databaseConnectionStringTextBox.Text);
            debtor.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DebtorPayDebt v = new DebtorPayDebt(pfSessionTextBox.Text, databaseConnectionStringTextBox.Text);
            v.ShowDialog();
        }
 
    }
}
