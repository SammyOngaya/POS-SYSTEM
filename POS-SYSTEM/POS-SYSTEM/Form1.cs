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
using System.Net.NetworkInformation;
using System.Threading;

namespace POS_SYSTEM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            readServerConfigFile();
            CopyrightDetails();
        }

        private void Form1_Load(object sender, EventArgs e)
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

        //read from server details file
        public void readServerConfigFile()
        {
            try
            {
                string fileLocation = @"C:\POS\Data\Server-Details.txt";

                if (File.Exists(fileLocation))
                {

                    FileStream fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(fs);
                    serverConnectionTextBox.Text = reader.ReadLine();
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("No configuration file found...", "MISSING CONFIGURATON FILE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("You are missing something in the system. Make sure the installation was successful...", "CONFGURATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        //login method
        public void loginForm()
        {

            //current date
            DateTime curdate = DateTime.Now;
            string dateCurrent = curdate.ToString("yyyy-MM-dd");

            //convert loginusername to integer
            //int pf = Convert.ToInt32(loginusername.Text);

            string db = serverConnectionTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);

            // DatabaseConnection con = new DatabaseConnection();


            try
            {
                con.Open();
                MySqlCommand mc = new MySqlCommand("SELECT * FROM staff WHERE (pfno='" + this.loginusername.Text + "' AND password='" + this.loginpassword.Text + "' AND status='Active') ", con);

                MySqlDataReader mr = mc.ExecuteReader();

                int count = 0;

                while (mr.Read())
                {
                    string rn = mr.GetString("category");
                    string firstname = mr.GetString("firstname");
                    string lastname = mr.GetString("lastname");

                    firstNameTextBox.Text = firstname;
                    lastNameTextBox.Text = lastname;

                    userCategory.Text = rn;

                    count += 1;

                }

                mr.Close();

                if ((count == 1) && (userCategory.Text == "Manager"))
                {
                    MessageBox.Show("You have logged in successfully", "Manager LOGGED IN SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    ManagerHome d = new ManagerHome(loginusername.Text, firstNameTextBox.Text, lastNameTextBox.Text, serverConnectionTextBox.Text);
                    //Dashboard d = new Dashboard(loginusername.Text);
                    d.ShowDialog();

                    MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.loginusername.Text + "','" + dateCurrent + "','manager login')", con);
                    me.ExecuteNonQuery();

                }
                else if ((count == 1) && (userCategory.Text == "Supervisor"))
                {

                    MessageBox.Show("You have logged in successfully", "SUPERVISOR LOGGED IN SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    SupervisorHome d = new SupervisorHome(loginusername.Text, firstNameTextBox.Text, lastNameTextBox.Text, serverConnectionTextBox.Text);
                    d.ShowDialog();
                    MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.loginusername.Text + "','" + dateCurrent + "','supervisor login')", con);
                    me.ExecuteNonQuery();

                }
                else if ((count == 1) && (userCategory.Text == "Cashier"))
                {

                    MessageBox.Show("You have logged in successfully", "CASHIER LOGGED IN SUCCESSFULLY", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    CashierHome d = new CashierHome(loginusername.Text, firstNameTextBox.Text, lastNameTextBox.Text, serverConnectionTextBox.Text);
                    d.ShowDialog();
                    MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.loginusername.Text + "','" + dateCurrent + "','Cashier login')", con);
                    me.ExecuteNonQuery();//SupervisorHome

                }
                else if (count > 1)
                {

                    MessageBox.Show("More records found. Access denied...", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loginusername.Select();
                }
                else
                {
                    MessageBox.Show("Wrong username / password combination. Access denied...", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MySqlCommand me = new MySqlCommand("INSERT INTO `events` VALUES(NULL,'" + this.loginusername.Text + "','" + dateCurrent + "','failed login attempt')", con);
                    me.ExecuteNonQuery();

                    loginusername.Select();

                }

                con.Close();

            }
            catch (Exception)
            {
                // MessageBox.Show("Error has occured. Please try again with different data"+ex.Message);
            }
        }

        private void login_Click(object sender, EventArgs e)
        {
            loginForm();
        }


    }
}
