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
    public partial class billing : Form
    {
        public billing()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        void load()
        {

            int sum = 0;
            dataGridView1.Rows.Clear();
            
            try
            {
                String[] row = new string[4];
                string oradb = "Data Source=localhost;User Id=system;Password=N;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = oradb;
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                string sql = " SELECT * from kn.nill";
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    row[0] = "" + reader.GetString(0);
                    row[1] = "" + reader.GetString(1);
                    row[2] = "" + reader.GetString(2);
                    row[3] = "" + reader.GetString(3);
                    sum =sum+ int.Parse(row[3]);
                    dataGridView1.Rows.Add(row);

                }

                label3.Text = "" + sum;
                connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string oradb = "Data Source=localhost;User Id=system;Password=N;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = oradb;
                connection.Open();
                OracleCommand command = connection.CreateCommand();

               


               String sql = "update KN.TABLE4 set QTY=QTY-" + textBox2.Text + " where P_ID='" + textBox1.Text + "'";
                command.CommandText = sql;

                command.ExecuteNonQuery();


                sql = "insert into kn.nill  select P_id,P_name,"+textBox2.Text+",price*"+textBox2.Text+" from kn.table4 where p_id='"+textBox1.Text+"'";
                command.CommandText = sql;

                command.ExecuteNonQuery();
                load();

                connection.Close();

            }
            catch (Exception exc)
            {
                label1.Text = exc.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                string oradb = "Data Source=localhost;User Id=system;Password=N;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = oradb;
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                string sql = "delete kn.nill";
                command.CommandText = sql;

                 command.ExecuteNonQuery();
                
                connection.Close();
            }
            catch (Exception exc)
            {
                label1.Text = exc.ToString();
            }
            MessageBox.Show("thankyou");


        }

        private void billing_Load(object sender, EventArgs e)
        {
            load();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }

    }
}

    

