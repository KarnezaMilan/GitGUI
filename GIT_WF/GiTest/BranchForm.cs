using LibGit2Sharp;
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
    public partial class BranchForm : Form
    {
        public string Path { get; set; }
        
        public BranchForm()
        {
            InitializeComponent();
        }

        public BranchForm(string path)
        {
            InitializeComponent();
            this.Path = path;
            textBox1.Hide();
            button4.Hide();
            label2.Hide();
        }

        private void BranchForm_Load(object sender, EventArgs e)
        {

            string[] file = new string[2];
            string bb = null;

            ListViewItem itm;
            using (var repo = new Repository(Path))
            {
                foreach (Branch b in repo.Branches.Where(b => !b.IsRemote))
                {
                    file[0] = b.FriendlyName;
                    file[1] = b.IsCurrentRepositoryHead.ToString();
                    
                    itm = new ListViewItem(file);
                    listViewBranch.Items.Add(itm);

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Show();
            button4.Show();
            label2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listViewBranch.SelectedItems[0].SubItems[0].Text != "master")
            {
                using (var repo = new Repository(Path))
                {
                
                    repo.Branches.Remove(listViewBranch.SelectedItems[0].SubItems[0].Text);
                }
                listViewBranch.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("You cant remove master");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var repo = new Repository(Path))
            {
                Branch branch = repo.CreateBranch(textBox1.Text);  

            }

            string[] file = new string[2];
            string bb = null;

            ListViewItem itm;
            file[0] = textBox1.Text;
            file[1] = "False";

            itm = new ListViewItem(file);
            listViewBranch.Items.Add(itm);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var repo = new Repository(Path))
            {
                Branch currentBranch = Commands.Checkout(repo, listViewBranch.SelectedItems[0].SubItems[0].Text);
            }

            for(int i=0;i<listViewBranch.Items.Count;i++)
            {
                listViewBranch.Items[i].SubItems[1].Text = "False";
            }

            listViewBranch.SelectedItems[0].SubItems[1].Text = "True";

        }

    }
}
