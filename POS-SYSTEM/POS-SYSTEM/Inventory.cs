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
    public partial class Inventory : Form
    {
        MySqlConnection con = null;
        public Inventory(string mess, string firstname, string lastname, string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            con = DBHandler.CreateConnection();
            firstNameTextBox.Text = firstname;
            lastNameTextBox.Text = lastname;
            //Welcome user.
            pfsession.Text = mess;
        }
        private void Inventory_Load(object sender, EventArgs e)
        {

        }



        private void label5_Click(object sender, EventArgs e)
        {
            ViewSupplier viewSupplier = new ViewSupplier(databaseConnectionStringTextBox.Text);
            viewSupplier.ShowDialog();
        }

        private void viewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ViewSupplier viewSupplier = new ViewSupplier(databaseConnectionStringTextBox.Text);
            viewSupplier.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddSupplier ad = new AddSupplier(pfsession.Text, databaseConnectionStringTextBox.Text);
            ad.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            UpdateSupplier u = new UpdateSupplier(pfsession.Text, databaseConnectionStringTextBox.Text);
            u.ShowDialog();
        }

        private void updateSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSupplier u = new UpdateSupplier(pfsession.Text, databaseConnectionStringTextBox.Text);
            u.ShowDialog();
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSupplier ad = new AddSupplier(pfsession.Text, databaseConnectionStringTextBox.Text);
            ad.ShowDialog();
        
        }

        private void label10_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm();
            form.ShowDialog();
        
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ViewProduct viewProduct = new ViewProduct(databaseConnectionStringTextBox.Text);
            viewProduct.ShowDialog();
        }

        private void viewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewProduct viewProduct = new ViewProduct(databaseConnectionStringTextBox.Text);
            viewProduct.ShowDialog();
        
        }

        private void label9_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct(pfsession.Text, databaseConnectionStringTextBox.Text);
            addProduct.ShowDialog();
        }

        private void addDrugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct(pfsession.Text, databaseConnectionStringTextBox.Text);
            addProduct.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            UpdateProduct updateProduct = new UpdateProduct(pfsession.Text, databaseConnectionStringTextBox.Text);
            updateProduct.ShowDialog();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            AddStock a = new AddStock(pfsession.Text, databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStock a = new AddStock(pfsession.Text, databaseConnectionStringTextBox.Text);
            a.ShowDialog();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            UpdateStock u = new UpdateStock(pfsession.Text, databaseConnectionStringTextBox.Text);
            u.ShowDialog();
        }

        private void updateStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStock u = new UpdateStock(pfsession.Text, databaseConnectionStringTextBox.Text);
            u.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ReportNetStock reportNetStock = new ReportNetStock(databaseConnectionStringTextBox.Text);
            reportNetStock.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            ViewSupplierPriceList supplier = new ViewSupplierPriceList(databaseConnectionStringTextBox.Text);
            supplier.ShowDialog();
        
        }

        private void addSupplierPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSupplierPriceList supplier = new AddSupplierPriceList(pfsession.Text, databaseConnectionStringTextBox.Text);
            supplier.ShowDialog();
       
        }

        private void label11_Click(object sender, EventArgs e)
        {
            AddSupplierPriceList supplier = new AddSupplierPriceList(pfsession.Text, databaseConnectionStringTextBox.Text);
            supplier.ShowDialog();
       
        }

        private void updateSupplierPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSupplierPriceList supplier = new UpdateSupplierPriceList(pfsession.Text, databaseConnectionStringTextBox.Text);
            supplier.ShowDialog();
        
        }

        private void label15_Click(object sender, EventArgs e)
        {
            UpdateSupplierPriceList supplier = new UpdateSupplierPriceList(pfsession.Text, databaseConnectionStringTextBox.Text);
            supplier.ShowDialog();
        
        }

        private void viewSupplierPriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSupplierPriceList supplier = new ViewSupplierPriceList(databaseConnectionStringTextBox.Text);
            supplier.ShowDialog();
        
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderList orderlist = new OrderList(pfsession.Text, databaseConnectionStringTextBox.Text);
            orderlist.ShowDialog();
        
        }

        private void label2_Click(object sender, EventArgs e)
        {
            OrderList orderlist = new OrderList(pfsession.Text, databaseConnectionStringTextBox.Text);
            orderlist.ShowDialog();
        
        }

        private void updateOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateOrderList update = new UpdateOrderList(pfsession.Text, databaseConnectionStringTextBox.Text);
            update.ShowDialog();
        
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UpdateOrderList update = new UpdateOrderList(pfsession.Text, databaseConnectionStringTextBox.Text);
            update.ShowDialog();
        
        }

        private void viewOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewOrderList view = new ViewOrderList(databaseConnectionStringTextBox.Text);
            view.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewOrderList view = new ViewOrderList(databaseConnectionStringTextBox.Text);
            view.ShowDialog();
        }


    }
}
