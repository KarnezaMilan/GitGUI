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
    public partial class UserConnectForm : Form
    {
        public UserConnectForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text != "" && textBoxName.Text != "")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to fill the form !");
            }
        }

        public string ReturnEmail ()
        {
            return textBoxEmail.Text;
        }
        public string ReturnName()
        {
            return textBoxName.Text;
        }
    }
}
