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
    public partial class Vat : Form
    {

        MySqlConnection con = null;
        public Vat()
        {
            InitializeComponent();
            con = DBHandler.CreateConnection();
            getVat();

        }


        private void Vat_Load(object sender, EventArgs e)
        {

        }


        DialogResult dialog;

        // Get vat tax from database.
        public void getVat()
        {
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
                    vatUpdadteValue.Text = vat;
                    vatLabel.Text = etr_id;
                    etrVatTextBox.Text = etr_id;
                    pinLabel.Text = pin;
                    pinTextBox.Text = pin;
                    businessLabel.Text = business_name;
                    bussinessNameTextBox.Text = business_name;
                    addressLabel.Text = address;
                    addressTextBox.Text = address;
                    locationLabel.Text = location;
                    locationTextBox.Text = location;
                    phoneLabel.Text = phone;
                    phoneTextBox.Text = phone;
                    PrinterNameTextBox.Text = printer_name;
                    PrinterNameLabel.Text = printer_name;
                    printReceiptLabel.Text = print_receipt;
                    printReceiptComboBox.Text = print_receipt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Has occured" + ex.Message);
            }
            con.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (vatTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the above field...............!", "VAT VALUE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    dialog = MessageBox.Show("Are you sure you want to update the VAT value?", "VAT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {

                        con.Open();
                        MySqlCommand c = new MySqlCommand("UPDATE `vat` SET printer_name='" + this.PrinterNameTextBox.Text+ "', vat_value='" + this.vatUpdadteValue.Text + "', etr_id='" + this.etrVatTextBox.Text + "', pin='" + this.pinTextBox.Text + "', business_name='" + this.bussinessNameTextBox.Text + "', location='" + this.locationTextBox.Text + "',address='" + this.addressTextBox.Text + "', phone='" + this.phoneTextBox.Text + "', print_receipt='" + this.printReceiptComboBox.Text + "' WHERE vat_id='1'", con);

                        c.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Has occured" + ex.Message);
                }
                con.Close();
                getVat();
            }
        }
    }
}
