using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WindowsFormsApplication6
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] row = new string[4];
            try
            {
                string oradb = "Data Source=localhost;User Id=system;Password=N;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = oradb;
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                string sql = "select * from kn.table4";
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    row[0] = "" + reader.GetString(0);
                    row[1] = "" + reader.GetString(1);
                    row[2] = "" + reader.GetString(2);
                    row[3] = "" + reader.GetString(3);
                   

                    dataGridView1.Rows.Add(row);

                }
                MessageBox.Show("ok");

                connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }
        }
    }

