
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Model;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public string Pot = "C:/Users/Mili/Desktop/Novamapa";

        public MainWindow()
        {
           
            InitializeComponent();

            this.PreLoad();
            this.UnstageFileScan();
        }

        private void UnstageFileScan()
        {
            List<FileModel> FileList = new List<FileModel>();
            string bb = null;

            using (var repo = new Repository(Pot))
            {

                foreach (var item in repo.RetrieveStatus(new LibGit2Sharp.StatusOptions()))
                {
                    
                    bb = Convert.ToString(item.State);

                    if (bb.Contains("DeletedFromWorkdir") == true)
                    {
                        bb = "Deleted";
                    }
                    else if (bb.Contains("ModifiedInWorkdir") == true)
                    {
                        bb = "Modified";
                    }
                    else if (bb.Contains("NewInWorkdir") == true)
                    {
                        bb = "New Added";
                    }

                    FileList.Add(new FileModel() { Name = item.FilePath, Status = bb });

                }
            }

            List123.ItemsSource = FileList;

        }

        private void PreLoad()
        {
            Repository repo = new Repository(Pot);
            //Branch master = repo.Branches.ElementAt(0);

            foreach (LibGit2Sharp.Commit commit in repo.Commits)
            {
                IEnumerable<Branch> branches = ListBranchesContaininingCommit(repo, commit.Sha);

                CommitModel c = new CommitModel();
                c.AuthorEmail = commit.Author.Email;
                c.AuthorName = commit.Author.Name;
                c.Date = commit.Author.When.ToString("d.M.yyyy H:m:s");
                c.Description = commit.MessageShort;
                c.Hash = commit.Sha;
                //c.Source = branches.ElementAt(0).ToString();



                CommitHistory.Items.Add(c);
            };
        }


        private IEnumerable<Branch> ListBranchesContaininingCommit(Repository repo, string commitSha)
        {
            bool directBranchHasBeenFound = false;
            foreach (var branch in repo.Branches)
            {
                if (branch.Tip.Sha != commitSha)
                {
                    continue;
                }

                directBranchHasBeenFound = true;
                yield return branch;
            }

            if (directBranchHasBeenFound)
            {
                yield break;
            }
            /*
            foreach (var branch in repo.Branches)
            {
                var commits = repo.Commits.QueryBy(new Filter { Since = branch }).Where(c => c.Sha == commitSha);

                if (commits.Count() == 0)
                {
                    continue;
                }

                yield return branch;
            }*/
        }

        private void Rescan_Click(object sender, RoutedEventArgs e)
        {
            this.UnstageFileScan();
        }
    }
}
