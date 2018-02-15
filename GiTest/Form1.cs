using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;
//using System.Security.Permissions.FileIOPermission;
using WinForms = System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace GiTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new WinForms.FolderBrowserDialog
            {
                Description = "Create and choose the folder for your new repository."
            };

            dialog.ShowDialog();

            // Open the selected folder if possible.
            if (!String.IsNullOrEmpty(dialog.SelectedPath))
            {
                LibGit2Sharp.Repository.Init(dialog.SelectedPath);


               // LibGit2Sharp.RepositoryInformation.
                //if (OpenNewRepository(dialog.SelectedPath) == false)
                    //MessageBox.Show(String.Format("Something went wrong with the creation of the new repository. Try again."));
            }
            FIleLAB.Text = dialog.SelectedPath;
            
            dialog.Dispose();
        }

        private void openReposotoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new WinForms.FolderBrowserDialog
            {
                ShowNewFolderButton = false
            };

            dialog.ShowDialog();

            if (!String.IsNullOrEmpty(dialog.SelectedPath))
            {
                //if (OpenNewRepository(dialog.SelectedPath) == false)
                   // MessageBox.Show(String.Format("Could not open \"{0}\". Are you sure it is an existing Git repository?", dialog.SelectedPath));
            }
            FIleLAB.Text = dialog.SelectedPath;
            dialog.Dispose();

            
        }

        private void closeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConnectBTN_Click(object sender, EventArgs e)
        {
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloneReposotoryForm f = new CloneReposotoryForm();
            f.Show();


        }
       


    }
}
