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
using System.Diagnostics;

namespace POS_SYSTEM
{
    public partial class ViewProduct : Form
    {

        public ViewProduct(string databaseString)
        {
            InitializeComponent();
            databaseConnectionStringTextBox.Text = databaseString;
            
            ProductView();
        
        }

        private void ViewProduct_Load(object sender, EventArgs e)
        {

        }


        DataTable dataTable=null;

        //view drugs
        public void ProductView()
        {

            try
            {
                string db = databaseConnectionStringTextBox.Text;
                MySqlConnection con = new MySqlConnection(db);

                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT  `product`.`name` AS 'Product Name', `product`.`form` AS 'Product Form',`product`.`pfno` AS 'Registered By', `product`.`registered_date` AS 'Registered Date' , status AS 'Status' FROM product ORDER BY name ASC", con);

                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = com;

                 dataTable = new DataTable();
                // Add autoincrement column.
                dataTable.Columns.Add("#", typeof(string));
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["#"] };
                dataTable.Columns["#"].AutoIncrement = true;
                dataTable.Columns["#"].AutoIncrementSeed = 1;
                dataTable.Columns["#"].ReadOnly = true;
                // End adding AI column.

                // Format titles.
                dataTable.Columns.Add("Product Name");
                dataTable.Columns.Add("Product Form");
                dataTable.Columns.Add("Registered By");
                dataTable.Columns.Add("Registered Date", typeof(string));
                dataTable.Columns.Add("Status");
                // End formating titles.

                a.Fill(dataTable);

                BindingSource bs = new BindingSource();
                bs.DataSource = dataTable;
                viewProductdataGridView.DataSource = bs;

                a.Update(dataTable);
                // Count number of rows to return records.
                Int64 count = Convert.ToInt64(viewProductdataGridView.Rows.Count) - 1;
                rowCountLabel.Text = count.ToString() + " Records";

            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured while displaying product details............!", "PRODUCT DETAILS DISPLAY ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }

       
        //print pdf for drug
        public void productPdf() {

            try
            {

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
            PdfWriter PW = PdfWriter.GetInstance(doc, new FileStream("C:\\POS\\Reports\\PRODUCTS", FileMode.Create));
            doc.Open();//open document to write
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\POS\\Resources\\faith2.png");
            img.ScalePercent(79f);
            // img.SetAbsolutePosition(doc.PageSize.Width - 250f - 250f, doc.PageSize.Height - 30f - 20.6f);



            doc.Add(img); //add image to document
            Paragraph p = new Paragraph("                                                                Products Report");
            doc.Add(p);
            DateTime time = DateTime.Now;

            Paragraph p2 = new Paragraph("                       " + this.rowCountLabel.Text + "        Produced On         " + time.ToString() + "        \n\n");
            doc.Add(p2);


            //load data from datagrid
            PdfPTable table = new PdfPTable(viewProductdataGridView.Columns.Count);

            //add headers from the datagridview to the table
            for (int j = 0; j < viewProductdataGridView.Columns.Count; j++) {

                table.AddCell(new Phrase(viewProductdataGridView.Columns[j].HeaderText));
            
            }

            //flag the first row as header

            table.HeaderRows = 1;

            //add the actual rows to the table from datagridview

            for (int i = 0; i < viewProductdataGridView.Rows.Count; i++) {
                for (int k = 0; k < viewProductdataGridView.Columns.Count; k++) {

                    if (viewProductdataGridView[k,i].Value != null) {

                        table.AddCell(new Phrase(viewProductdataGridView[k,i].Value.ToString()));
                    }
                
                }
            
            }

            doc.Add(table);
            //end querying from datagrid


                doc.Close();//close document after writting in

            MessageBox.Show("Product Report generated Successful");

            System.Diagnostics.Process.Start("C:\\POS\\Reports\\PRODUCTS");

               }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the report ","DOCUMENT ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            finally
            { 
            
            }
        
        }


        //print drug excell.
        public void productExcel()
        {
            //sqlConnection = new MySqlConnection(databaseConnection);

            try
            {
                DataTable dtCopy = dataTable.Copy();

                DataSet ds = new DataSet("SHEET");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

                //a.Fill(dataTable); // Never fill or else it will display duplicates on data grid.
                ds.Tables.Add(dtCopy);
                ExcelLibrary.DataSetHelper.CreateWorkbook("C:\\POS\\Reports\\PRODUCTS.xls", ds);

                MessageBox.Show("Report generated successfully");
                Process sts = System.Diagnostics.Process.Start("C:\\POS\\Reports\\PRODUCTS.xls");
                sts.WaitForExit();


            }
            catch (Exception )
            {
              // MessageBox.Show(ex.Message);
                MessageBox.Show("Unable to open the report ", "DOCUMENT ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {

            }

        }


        private void printProductPdfButton_Click_1(object sender, EventArgs e)
        {
            productPdf();
        }

        private void printProductExcel_Click(object sender, EventArgs e)
        {
            productExcel();
        }



    }
}
