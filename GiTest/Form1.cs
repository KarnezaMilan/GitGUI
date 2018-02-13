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

            // Open the selected repository, if possible.
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
        /*
        private bool OpenNewRepository(string path)
        {
            var repository = new RepositoryViewModel
            {
                NotOpened = false,
                RepositoryFullPath = path
            };

            // Try loading the repository information and see if it worked.
            var result = repository.Init();
            if (result)
            {
               // var mainWindowViewModel = (MainWindowViewModel)Application.Current.MainWindow.DataContext;

                // Ask the user for the Name.
                var nameDialog = new PromptDialog
                {
                    ResponseText = repository.RepositoryFullPath.Split(System.IO.Path.DirectorySeparatorChar).Last(),
                    Message = "Give a name for this repository:",
                    Title = "Information needed"
                };

                repository.Name = nameDialog.ShowDialog() == true ? nameDialog.ResponseText : repository.RepositoryFullPath;

                // Open the repository and display it visually.
                mainWindowViewModel.RepositoryViewModels.Add(repository);
                mainWindowViewModel.RecentRepositories.Add(repository);

                repository.SetThisRepositoryAsTheActiveTab();
            }
            else
            {
                return false;
            }

            return true;
        }
        */


    }
}
