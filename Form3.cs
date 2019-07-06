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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = false;
            pictureBox4.Visible = true;
           dataGridView1.Visible = true;
          // dataGridView1.Columns.Clear();
            

            String[] row = new string[6];
            try
            {
                string oradb = "Data Source=localhost;User Id=system;Password=N;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = oradb;
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                string sql = "select * from kn.emp_de";
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form9 frm = new Form9();
            frm.Show();
        }
    

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            pictureBox4.Visible = false;
            panel1.Visible = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
