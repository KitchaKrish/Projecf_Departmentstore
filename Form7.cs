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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }



      /*  void load()
        {

            dataGridView1.Rows.Clear();
            int sum = 0;

            string[] row = new string[4];
            try
            {
                string oradb = "Data Source=localhost;User Id=system;Password=N;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = oradb;
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                string sql = "select * from kn.stock";
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                Boolean ck = false;
                while (reader.Read())
                {

                    row[0] = (string)reader.GetString(0);
                    row[1] = "" + reader.GetInt64(1);
                    row[2] = "" + reader.GetInt64(2);
                    row[3] = "" + reader.GetString(3);
                    sum = sum + int.Parse(row[3]);
                    dataGridView1.Rows.Add(row);
                    ck = true;

                }

                //  label4.Text = "" + sum;

                connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

        }*/
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string oradb = "Data Source=localhost;User Id=system;Password=N;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = oradb;
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                string sql = "insert into kn.table4 VALUES('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox4.Text + "')";
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // MessageBox.Show("ok");

                }
                connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show( exc.ToString());
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            String[] row = new string[4];
            try
            {
                string oradb = "Data Source=localhost;User Id=system;Password=N;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = oradb;
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                string sql = " SELECT * from kn.table4";
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }
    }
}