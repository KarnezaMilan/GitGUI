using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms = System.Windows.Forms;

namespace GiTest
{
    public partial class CloneReposotoryForm : Form
    {
        public CloneReposotoryForm()
        {
            InitializeComponent();
            textBox_remote.Text = null;
            textBox_local.Text = null;
        }

        private void btn_paste_Click(object sender, EventArgs e)
        {
            textBox_remote.Paste();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            var dialog = new WinForms.FolderBrowserDialog
            {
                Description = "hoose the folder for your new repository."
            };

            dialog.ShowDialog();

            textBox_local.Text = dialog.SelectedPath;

            dialog.Dispose();
        }

        private void btn_Clone_Click(object sender, EventArgs e)
        {
            if (textBox_local.Text == "" || textBox_remote.Text == "")
            {
                MessageBox.Show("Invalid data");

            }else
            {
                LibGit2Sharp.Repository.Clone(textBox_remote.Text, textBox_local.Text);
                this.Close();
            }
            

        }
    }
}
