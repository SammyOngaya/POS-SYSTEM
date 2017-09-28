﻿using System;
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
using System.Diagnostics;

namespace POS_SYSTEM
{
    public partial class ViewSupplier : Form
    {
        public ViewSupplier(string databaseString)
        {
            InitializeComponent(); 
            databaseConnectionStringTextBox.Text = databaseString;
            viewSupplier();
        }

        DataTable dataTable;

        private void viewSupplierdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void viewSupplier()
        {

            string db = databaseConnectionStringTextBox.Text;
            MySqlConnection con = new MySqlConnection(db);

            try
            {

                MySqlCommand com = new MySqlCommand("SELECT `supplier`.`name` AS 'Supplier Name',`supplier`.`phone` AS 'Supplier Phone',`supplier`.`address` AS 'Supplier Adress',`supplier`.`location` AS 'Supplier Location',`supplier`.`pfno` AS 'Registered By',`supplier`.`registered_date` AS 'Registered Date',`supplier`.`status` AS 'Status' FROM supplier ORDER BY name ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(int));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("Supplier Name");
                dataTable.Columns.Add("Supplier Phone");
                dataTable.Columns.Add("Supplier Adress");
                dataTable.Columns.Add("Supplier Location");
                dataTable.Columns.Add("Registered By");
                dataTable.Columns.Add("Registered Date", typeof(string));
                dataTable.Columns.Add("Status");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                viewSupplierdataGridView.DataSource = bs;

                a.Update(dataTable);

                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewSupplierdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //print pdf for Supplier
        public void supplierPdf()
        {

            try
            {

                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
                PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\POS\\Reports\\Supplier pdf", FileMode.Create));
                doc.Open();//open document to write

                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\pos\\Resources\\faith2.png");
                img.ScalePercent(79f);
                // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);

                doc.Add(img); //add image to document
                Paragraph p = new Paragraph("                                                                Supplier Report");
                doc.Add(p);
                DateTime time = DateTime.Now;

                Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
                doc.Add(p2);


                //load data from datagrid
                PdfPTable table = new PdfPTable(viewSupplierdataGridView.Columns.Count);

                //add headers from the datagridview to the table
                for (int j = 0; j < viewSupplierdataGridView.Columns.Count; j++)
                {

                    table.AddCell(new Phrase(viewSupplierdataGridView.Columns[j].HeaderText));

                }

                //flag the first row as header

                table.HeaderRows = 1;

                //add the actual rows to the table from datagridview

                for (int i = 0; i < viewSupplierdataGridView.Rows.Count; i++)
                {
                    for (int k = 0; k < viewSupplierdataGridView.Columns.Count; k++)
                    {

                        if (viewSupplierdataGridView[k, i].Value != null)
                        {

                            table.AddCell(new Phrase(viewSupplierdataGridView[k, i].Value.ToString()));
                        }

                    }

                }

                doc.Add(table);
                //end querying from datagrid


                doc.Close();//close document after writting in

                MessageBox.Show("Suppliers Report generated Successful");

                System.Diagnostics.Process.Start("C:\\POS\\Reports\\Supplier pdf");

            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ", "DOCUMENT ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }

        }



        //print suppliers excel.
        public void supplierExcel()
        {
            
            try
            {
                DataTable dtCopy = dataTable.Copy();

                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dtCopy);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\POS\\Reports\\Suppliers.xls", ds);

                MessageBox.Show("Report generated successfully");
                Process sts = System.Diagnostics.Process.Start("C:\\POS\\Reports\\Suppliers.xls");
                sts.WaitForExit();

                // sqlConnection.Close();


            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ", "DOCUMENT ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }

        }

        private void ViewSupplier_Load(object sender, EventArgs e)
        {

        }

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            supplierExcel();
        }

        private void supplierReportPdf_Click(object sender, EventArgs e)
        {
            supplierPdf();
        }
    }
}
