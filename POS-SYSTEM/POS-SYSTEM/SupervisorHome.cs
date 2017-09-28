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
    public partial class SupervisorHome : Form
    {
        MySqlConnection con = null;

        public SupervisorHome(string mess, string firstname, string lastname, string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            firstNameTextBox.Text = firstname;
            lastNameTextBox.Text = lastname;
            //Welcome user.
            welcomeLabel.Text = firstname;
            pfsession.Text = mess;
            CopyrightDetails();
        }

        private void SupervisorHome_Load(object sender, EventArgs e)
        {

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

        //logout method
        public void logoutEvent()
        {
            //current date
            DateTime curdate = DateTime.Now;
            string dateCurrent = curdate.ToString("yyyy-MM-dd");

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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text, databaseConnectionStringTextBox.Text);
            inventory.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text, databaseConnectionStringTextBox.Text);
            dashboard.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            OrderList orderlist = new OrderList(pfsession.Text, databaseConnectionStringTextBox.Text);
            orderlist.ShowDialog();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderList orderlist = new OrderList(pfsession.Text, databaseConnectionStringTextBox.Text);
            orderlist.ShowDialog();
        }

        private void updateOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateOrderList update = new UpdateOrderList(pfsession.Text, databaseConnectionStringTextBox.Text);
            update.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            UpdateOrderList update = new UpdateOrderList(pfsession.Text, databaseConnectionStringTextBox.Text);
            update.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ViewOrderList view = new ViewOrderList(databaseConnectionStringTextBox.Text);
            view.ShowDialog();
        }

        private void viewOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewOrderList view = new ViewOrderList(databaseConnectionStringTextBox.Text);
            view.ShowDialog();
        }

        private void addSupplierPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSupplierPriceList supplier = new AddSupplierPriceList(pfsession.Text, databaseConnectionStringTextBox.Text);
            supplier.ShowDialog();
        }

        private void updateSupplierPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSupplierPriceList supplier = new UpdateSupplierPriceList(pfsession.Text, databaseConnectionStringTextBox.Text);
            supplier.ShowDialog();
        }

        private void viewSupplierPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSupplierPriceList supplier = new ViewSupplierPriceList(databaseConnectionStringTextBox.Text);
            supplier.ShowDialog();
        }
      

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // logoutEvent();
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportDatabase export = new ExportDatabase(databaseConnectionStringTextBox.Text);
            export.ShowDialog();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportDatabase import = new ImportDatabase(databaseConnectionStringTextBox.Text);
            import.ShowDialog();
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logoutEvent();
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddDebtor a = new AddDebtor(pfsession.Text, databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void viewDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebtorPayDebt v = new DebtorPayDebt(pfsession.Text, databaseConnectionStringTextBox.Text);
            v.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

            UpdateDebtor u = new UpdateDebtor(pfsession.Text, databaseConnectionStringTextBox.Text);
            u.ShowDialog();
        }

        private void addDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDebtor a = new AddDebtor(pfsession.Text, databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void updateDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDebtor u = new UpdateDebtor(pfsession.Text, databaseConnectionStringTextBox.Text);
            u.ShowDialog();
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
                    MessageBox.Show("YOU DONT HAVE ANY PRINTER ATTACHED TO THE COMPUTER", "CHECKING FOR PRINTER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    MessageBox.Show("YOU HAVE A PRINTER SET AND READY", "CHECKING FOR PRINTER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            CheckForPrinterIfConnected();
            }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Vat vat = new Vat();
            vat.ShowDialog();
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

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text, databaseConnectionStringTextBox.Text);
            inventory.ShowDialog();
        
        }

    }
}
