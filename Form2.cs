using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "a" && textBox2.Text == "a")
            {


                Form3 frm = new Form3();
                frm.Show();
                this.Hide();
            }
            else if (textBox1.Text == "b" && textBox2.Text == "b")
            {
                Form4 frm = new Form4();
                frm.Show();
                this.Hide();
            }


        }
    }
}
