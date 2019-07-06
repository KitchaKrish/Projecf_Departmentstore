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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            panel1.Visible = false;
            dataGridView1.Visible = true;

            String[] row = new string[6];
            try
            {
                string oradb = "Data Source=localhost;User Id=system;Password=N;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = oradb;
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                string sql =" SELECT * from kn.emp_de where emp_id='"+textBox1.Text+"'";
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    row[0] = "" + reader.GetString(0);
                    row[1] = "" + reader.GetString(1);
                    row[2] = "" + reader.GetString(2);
                    row[3] = "" + reader.GetString(3);
                    row[4] = "" + reader.GetString(4);
                    row[5] = "" + reader.GetString(5);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
            this.Hide();
        }  
    }
}
