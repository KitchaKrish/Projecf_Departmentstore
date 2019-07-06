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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        void load()
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
                string sql = "select * from kn.table4";
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {

                    row[0] = (string)reader.GetString(0);
                    row[1] = "" + reader.GetInt64(1);
                    row[2] = "" + reader.GetInt64(2);
                    row[3] = "" + reader.GetString(3);
                    sum = sum + int.Parse(row[3]);
                    dataGridView1.Rows.Add(row);
                    
                }

                label4.Text = "" + sum;

                connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            List<string> id = new List<string>();
            try
            {
                string oradb = "Data Source=localhost;User Id=system;Password=N;";

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = oradb;
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                string sql = "select PRO_ID from kn.table4";
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    id.Add((string)reader.GetString(0));
                    i++;

                }

                connection.Close();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

            string[] id_data = new string[id.Count];
            for (int i = 0; i < id.Count; i++)
            {
                id_data[i] = id.ElementAt(i);
            }


            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            data.AddRange(id_data);
            this.textBox1.AutoCompleteCustomSource = data;



            //end

            load();

            
            

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

                string sql = "select p_id,p_name,price from kn.table4 where p_id='"+textBox1.Text+"'";
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                string name = null, price = null;
                while (reader.Read())
                {
                    name = (string)reader.GetString(0);
                    price = (string)reader.GetString(1);

                }

                if (int.Parse(price) <= 0)
                {
                    MessageBox.Show("stock is over");
                }
                else
                {



                    sql = "insert into kn.table4 VALUES('" + name + "'," + textBox2.Text + "," + price + "," + int.Parse(textBox2.Text) * int.Parse(price) + ")";
                    command.CommandText = sql;

                    command.ExecuteNonQuery();

                    connection.Close();
                    load();
                }
            }
            catch (Exception exc)
            {
                label1.Text = exc.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();

        }
    }
}
