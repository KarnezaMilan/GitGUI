using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Security.Permissions.FileIOPermission;
using WinForms = System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;

namespace GiTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // just for testing purposes
            //string pot = @"C:\Users\Mili\Documents\Visual Studio 2013\Projects\GitPushTest";
            //FIleLAB.Text = pot;

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


        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloneReposotoryForm f = new CloneReposotoryForm();
            f.Show();
        }

        private void RescanBTN_Click(object sender, EventArgs e)
        {
            listViewStatus.Items.Clear();

            string[] file = new string[2];
            string bb = null;

            ListViewItem itm;

            using (var repo = new Repository(FIleLAB.Text))
            {
                foreach (var item in repo.RetrieveStatus(new LibGit2Sharp.StatusOptions()))
                {
                    file[0] = item.FilePath;
                    bb = Convert.ToString(item.State);

                    if (bb.Contains("DeletedFromWorkdir")== true)
                    {
                        file[1] = "Deleted";
                        itm = new ListViewItem(file);
                        listViewStatus.Items.Add(itm);

                    }else if (bb.Contains("ModifiedInWorkdir") == true)
                    {
                        file[1] = "Modified";
                        itm = new ListViewItem(file);
                        listViewStatus.Items.Add(itm);
                    }
                    else if (bb.Contains("NewInWorkdir") == true)
                    {
                        file[1] = "New Added";
                        itm = new ListViewItem(file);
                        listViewStatus.Items.Add(itm);
                    }
           
                }
            }
            

        }

        private void AddBTN_Click(object sender, EventArgs e)
        {
  
            
            foreach (ListViewItem item in listViewStatus.Items)
            {
            listViewAdded.Items.Add((ListViewItem)item.Clone());
            }

            listViewStatus.Items.Clear();

           
            using (var repo = new Repository(FIleLAB.Text))
            {
                Commands.Stage(repo, "*");
            }


        }

        private void listViewStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Select item from ListView 
            if(this.listViewStatus.SelectedItems.Count == 0)
            {
                return;
            }
            string namn = this.listViewStatus.SelectedItems[0].Text;

            var repo = new Repository(FIleLAB.Text);
            var patch = repo.Diff.Compare<Patch>(new List<string>() { namn });

            richTextBoxDIff.Text = patch;
            
              
        }

        /*
        private void buttonAddSelected_Click(object sender, EventArgs e)
        {
            string aa = listViewStatus.SelectedItems[0].Text;
            listViewAdded.Items.Add(aa);
            listViewStatus.SelectedItems[0].Remove();

         

            using(var repo = new Repository(FIleLAB.Text))
            {
                Commands.Stage(repo, aa);
            }


        }*/

        private void CommitBTN2_Click(object sender, EventArgs e)
        {
            using (var repo = new Repository(FIleLAB.Text))
            {
                // Write content to file system
                if (richTextBoxCommitText.Text == "")
                {
                    MessageBox.Show("Write commit message");
                }
                else
                {
                    //string fileName = Path.GetFileName(FIleLAB.Text);
                    //var content = "Commit this!";
                    //File.WriteAllText(Path.Combine(repo.Info.WorkingDirectory, "fileToCommit.txt"), content);
                    
                    // Stage the file
                    //repo.Stage("fileToCommit.txt");
                    //LibGit2Sharp.Commands.Stage(repo, "fileToCommit.txt");

                    //repo.Stage("*");

                    LibGit2Sharp.Commands.Stage(repo, "*");


                    // Create the committer's signature and commit

                    UserConnectForm form = new UserConnectForm();
                    form.ShowDialog();

                    Signature author = new Signature(form.ReturnName(), form.ReturnEmail(), DateTime.Now);
                    Signature committer = author;

                    // Commit to the repository
                    Commit commit = repo.Commit(richTextBoxCommitText.Text, author, committer);



                    MessageBox.Show("YEY");
                }


            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void PushBTN_Click(object sender, EventArgs e)
        {
            using (var repo = new Repository(FIleLAB.Text))
            {

                UserPushForm form = new UserPushForm();
                form.ShowDialog();
                string userName = form.returnUserName();
                string pass = form.returnPassword();


                Remote remote = repo.Network.Remotes["origin"];
                var options = new PushOptions();
                options.CredentialsProvider = (_url, _user, _cred) =>
                    new UsernamePasswordCredentials { Username = userName, Password = pass };


                var pushRefSpec = @"refs/heads/master";
                repo.Network.Push(remote, pushRefSpec, options);
                
            }

            MessageBox.Show("YEA-PUSH");
        }



        

    }
}
