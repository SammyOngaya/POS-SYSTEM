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
    public partial class ManagerHome : Form
    {
        MySqlConnection con = null;

        public ManagerHome(string mess, string firstname, string lastname, string databaseString)
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
            setTime();
            CopyrightDetails();
        }

        private void ManagerHome_Load(object sender, EventArgs e)
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
                // MessageBox.Show("There is no image!", "EMPTY IMAGE", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }


        //set time
        public void setTime()
        {
            DateTime salestime = DateTime.Now;
            this.time.Text = salestime.ToString("yyyy-MM-dd");
        }

        //viewed admin help method
        public void adminHelpEvent()
        {
            //current date
            DateTime curdate = DateTime.Now;
            String dateCurrent = curdate.ToString("yyyy-MM-dd");

            //convert loginusername to integer
            int pf = Convert.ToInt32(pfsession.Text);


            try
            {
                con.Open();

                MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + pf + "','" + dateCurrent + "','Viewed admin help')", con);
                me.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                // MessageBox.Show("THERE IS NO HELP!", "HELP ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

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

        private void label3_Click(object sender, EventArgs e)
        {
            AddStaff a = new AddStaff(databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void addStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStaff a = new AddStaff(databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UpdateStaff a = new UpdateStaff(databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void updateStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStaff a = new UpdateStaff(databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ViewStaff a = new ViewStaff(databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void viewStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStaff a = new ViewStaff(databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text, databaseConnectionStringTextBox.Text);
            inventory.ShowDialog();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory(pfsession.Text, firstNameTextBox.Text, lastNameTextBox.Text, databaseConnectionStringTextBox.Text);
            inventory.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            AddDebtor a = new AddDebtor(pfsession.Text, databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            UpdateDebtor u = new UpdateDebtor(pfsession.Text, databaseConnectionStringTextBox.Text);
            u.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {

            DebtorPayDebt v = new DebtorPayDebt(pfsession.Text, databaseConnectionStringTextBox.Text);
            v.ShowDialog();
        }

        private void viewDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DebtorPayDebt v = new DebtorPayDebt(pfsession.Text, databaseConnectionStringTextBox.Text);
            v.ShowDialog();
        }

        private void updateDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            UpdateDebtor u = new UpdateDebtor(pfsession.Text, databaseConnectionStringTextBox.Text);
            u.ShowDialog();
        }

        private void addDebtorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddDebtor a = new AddDebtor(pfsession.Text, databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports r = new Reports(pfsession.Text, databaseConnectionStringTextBox.Text);
            r.ShowDialog();
        
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Reports r = new Reports(pfsession.Text, databaseConnectionStringTextBox.Text);
            r.ShowDialog();
        
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            ReportSales salesReport = new ReportSales(databaseConnectionStringTextBox.Text);
            salesReport.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Log log = new Log(databaseConnectionStringTextBox.Text);
            log.ShowDialog();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Log log = new Log(databaseConnectionStringTextBox.Text);
            log.ShowDialog();
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log log = new Log(databaseConnectionStringTextBox.Text);
            log.ShowDialog();
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

        private void viewOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewOrderList view = new ViewOrderList(databaseConnectionStringTextBox.Text);
            view.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
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

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            logoutEvent();
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            logoutEvent();
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ExportDatabase export = new ExportDatabase(databaseConnectionStringTextBox.Text);
            export.ShowDialog();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            ExportDatabase export = new ExportDatabase(databaseConnectionStringTextBox.Text);
            export.ShowDialog();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportDatabase import = new ImportDatabase(databaseConnectionStringTextBox.Text);
            import.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ImportDatabase import = new ImportDatabase(databaseConnectionStringTextBox.Text);
            import.ShowDialog();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            ImportDatabase import = new ImportDatabase(databaseConnectionStringTextBox.Text);
            import.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logoutEvent();
            this.Hide();
            Form1 lg = new Form1();
            lg.ShowDialog();
            this.Close();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vat vat = new Vat();
            vat.ShowDialog();
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
                    MessageBox.Show("YOU HAVE A PRINTER SET AND READY", "CHECKING FRO PRINTER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            CheckForPrinterIfConnected();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            CheckForPrinterIfConnected();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            ExpenseType expense = new ExpenseType(databaseConnectionStringTextBox.Text);
            expense.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            AddExpenses expenses = new AddExpenses(databaseConnectionStringTextBox.Text,pfsession.Text);
            expenses.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            UpdateExpenses expense = new UpdateExpenses(databaseConnectionStringTextBox.Text, pfsession.Text);
            expense.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewExpenses expense = new ViewExpenses(databaseConnectionStringTextBox.Text);
            expense.ShowDialog();
        }

        private void expenseTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpenseType expense = new ExpenseType(databaseConnectionStringTextBox.Text);
            expense.ShowDialog();
        }

        private void addExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddExpenses expenses = new AddExpenses(databaseConnectionStringTextBox.Text, pfsession.Text);
            expenses.ShowDialog();
        }

        private void updateExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateExpenses expense = new UpdateExpenses(databaseConnectionStringTextBox.Text, pfsession.Text);
            expense.ShowDialog();
        }

        private void viewExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewExpenses expense = new ViewExpenses(databaseConnectionStringTextBox.Text);
            expense.ShowDialog();
        }

            
    }
}
