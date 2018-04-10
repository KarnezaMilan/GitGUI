using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiTest
{
    public partial class UserPushForm : Form
    {

        public UserPushForm()
        {
            InitializeComponent();
            label3.Hide();
            textBox3.Hide();
        }

        public UserPushForm(string show)
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to fill the form");
            }


        }

        public string returnUserName ()
        {
            return textBox1.Text;
        }

        public string returnPassword()
        {
            return textBox2.Text;
        }

        public string returnEmail()
        {
            return textBox3.Text;
        }

    }
}
