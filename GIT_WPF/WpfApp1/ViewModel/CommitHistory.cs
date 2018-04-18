using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class CommitHistory
    {
        protected MainWindow window;

        public CommitHistory(MainWindow window)
        {
            this.window = window;
        }


        public void Load()
        {
            Repository repo = new Repository("C:/Users/Mili/Desktop/Novamapa");

            foreach (LibGit2Sharp.Commit commit in repo.Commits)
            {
                IEnumerable<Branch> branches = ListBranchesContaininingCommit(repo, commit.Sha);

                CommitModel c = new CommitModel();
                c.AuthorEmail = commit.Author.Email;
                c.AuthorName = commit.Author.Name;
                c.Date = commit.Author.When.ToString("d.M.yyyy H:m:s");
                c.Description = commit.MessageShort;
                c.Hash = commit.Sha;


                this.window.CommitHistory.Items.Add(c);
            }

        }

        private IEnumerable<Branch> ListBranchesContaininingCommit(Repository repo, string sha)
        {
            bool directBranchHasBeenFound = false;
            foreach (var branch in repo.Branches)
            {
                if (branch.Tip.Sha != sha)
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

            foreach (var branch in repo.Branches)
            {
                var commits = repo.Commits.QueryBy(new Filter { Since = branch }).Where(c => c.Sha == sha);

                if (commits.Count() == 0)
                {
                    continue;
                }

                yield return branch;
            }
        }
    }
}
