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

namespace WpfApp1.UserControls
{
    /// <summary>
    /// Interaction logic for ChangesetHistory.xaml
    /// </summary>
    public partial class ChangesetHistory : UserControl
    {
        public string Pot = "C:/Users/Mili/Desktop/Novamapa";

        public ChangesetHistory()
        {
            InitializeComponent();
            this.PreLoad();
        }

        private void PreLoad()
        {
            this.CommitHistoryDataGrid();
        }

        public void CommitHistoryDataGrid()
        {
            Repository repo = new Repository(Pot);
            Branch master = repo.Branches.ElementAt(0);

            foreach (LibGit2Sharp.Commit commit in repo.Commits)
            {
                //IEnumerable<Branch> branches = ListBranchesContaininingCommit(repo, commit.Sha);

                CommitModel c = new CommitModel();
                c.AuthorEmail = commit.Author.Email;
                c.AuthorName = commit.Author.Name;
                c.Date = commit.Author.When.ToString("d.M.yyyy H:m:s");
                c.Description = commit.MessageShort;
                c.Hash = commit.Sha;
                
                CommitHistory.Items.Add(c);
            };
        }

    }
}
