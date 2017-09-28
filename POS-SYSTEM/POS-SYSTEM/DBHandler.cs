using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace POS_SYSTEM
{
    class DBHandler
    {

        public static MySqlConnection CreateConnection()
        {
            try
            {
                string fileLocation = @"C:\POS\Data\Server-Details.txt";
                MySqlConnection con;
                if (!(File.Exists(fileLocation)))
                {
                    MessageBox.Show("No configuration file found...", "MISSING CONFIGURATON FILE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                FileStream fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fs);
                string db = reader.ReadLine();
                reader.Close();
                con = new MySqlConnection(db);

                return con;
            }
            catch (Exception)
            {
                MessageBox.Show("You are missing something in the system. Make sure the installation was successful...", "CONFGURATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
