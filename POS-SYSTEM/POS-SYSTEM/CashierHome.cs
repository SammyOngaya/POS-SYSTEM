using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Management;


namespace POS_SYSTEM
{
    public partial class CashierHome : Form
    {
        MySqlConnection con = null;

        public CashierHome(string mess, string firstname, string lastname, string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            con = DBHandler.CreateConnection();
            firstNameTextBox.Text = firstname;
            lastNameTextBox.Text = lastname;
            //Welcome user.
            welcomeLabel.Text = firstname;
            pfsession.Text = mess;
            getImage();
            CopyrightDetails();
        }

        public void CopyrightDetails()
        {
            string db = databaseConnectionStringTextBox.Text;

            try
            {
                MySqlConnection con = new MySqlConnection(db);
                con.Open();

                MySqlCommand c = new MySqlCommand("SELECT system_copyright_details FROM server_details", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    string system_copyright_details = r.GetString("system_copyright_details");

                    copyrightDetailsTextBox.Text = system_copyright_details;

                }
                con.Close();
            }
            catch (Exception)
            {
            }

        }

        //fetch image from database
        public void getImage()
        {
            try
            {
                con.Open();
                //MySqlCommand c = new MySqlCommand("SELECT * from staff ", con);
                MySqlCommand c = new MySqlCommand("SELECT photo,pfno FROM staff WHERE pfno='" + this.pfsession.Text + "'", con);

                MySqlDataReader r = c.ExecuteReader();

                while (r.Read())
                {
                    //retrieve image from the database upon the user
                    byte[] imgg = (byte[])(r["photo"]);
                    if (imgg == null)
                    {
                        QuantitySalePictureBox.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(imgg);
                        QuantitySalePictureBox.Image = System.Drawing.Image.FromStream(ms);
                    }
                    //end fetching image
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error caught" + ex.Message);
            }
        }
        private void CashierHome_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            ReportNetStock reportNetStock = new ReportNetStock(databaseConnectionStringTextBox.Text);
            reportNetStock.ShowDialog();
        }

        private void viewNetStockToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ReportNetStock reportNetStock = new ReportNetStock(databaseConnectionStringTextBox.Text);
            reportNetStock.ShowDialog();
        }

        private void viewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewProduct viewProduct = new ViewProduct(databaseConnectionStringTextBox.Text);
            viewProduct.ShowDialog();
        
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text, databaseConnectionStringTextBox.Text);
            dashboard.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddDebtor a = new AddDebtor(pfsession.Text,databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            UpdateDebtor u = new UpdateDebtor(pfsession.Text, databaseConnectionStringTextBox.Text);
            u.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

            DebtorPayDebt v = new DebtorPayDebt(pfsession.Text, databaseConnectionStringTextBox.Text);
            v.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            logoutEvent();
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }
        //logout method
        public void logoutEvent()
        {
            //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString("yyyy-MM-dd");

            //convert loginusername to integer
            int pf = Convert.ToInt32(pfsession.Text);


            try
            {
                con.Open();

                MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + pf + "','" + dateCurrent + "','logged out')", con);
                me.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

            }

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logoutEvent();
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }

        private void addDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDebtor a = new AddDebtor(pfsession.Text, databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void updateDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDebtor u = new UpdateDebtor(pfsession.Text, databaseConnectionStringTextBox.Text);
            u.ShowDialog();
        }

        private void viewDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebtorPayDebt v = new DebtorPayDebt(pfsession.Text, databaseConnectionStringTextBox.Text);
            v.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashierReport c = new CashierReport(pfsession.Text, databaseConnectionStringTextBox.Text);
            c.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            CashierReport c = new CashierReport(pfsession.Text, databaseConnectionStringTextBox.Text);
            c.ShowDialog();
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
                    MessageBox.Show("YOU DONT HAVE ANY PRINTER ATTACHED TO THE COMPUTER", "CHECKING FRO PRINTER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("YOU HAVE A PRINTER SET AND READY", "CHECKING FOR PRINTER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CheckForPrinterIfConnected();
        }
    }
}
