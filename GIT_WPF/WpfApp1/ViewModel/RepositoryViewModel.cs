using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using WpfApp1.Other;

namespace WpfApp1.ViewModel
{
    public class RepositoryViewModel : BaseViewModel
    {
        #region Atribute
        //**** Atribute ****
        private string _pot;
        private ObservableCollection<FileModel> _listFileStage;
        private ObservableCollection<FileModel> _listFileUnstage;
        private FileModel _selectedFileInStageFiles;
        private string _commitMessage;

        #endregion
        
        #region Property
        //**** Property ****
        public ObservableCollection<FileModel> ListFileUnstage
        {
            get { return _listFileUnstage; }
            set
            {
                _listFileUnstage = value;
                NotifyPropertyChanged("ListFileUnstage");
            }
        }

        public ObservableCollection<FileModel> ListFileStage
        {
            get { return _listFileStage; }
            set
            {
                _listFileStage = value;
                NotifyPropertyChanged("ListFileStage");
            }
        }

        public string Pot
        {
            get { return _pot; }
            set
            {
                _pot = value;
                NotifyPropertyChanged("Pot");
            }
        }

        public FileModel SelectedFileInStageFiles
        {
            get { return _selectedFileInStageFiles; }
            set
            {
                _selectedFileInStageFiles = value;
                NotifyPropertyChanged("SelectedFileInStageFiles");
            }
        }

        public string CommitMessage
        {
            get { return _commitMessage; }
            set
            {
                _commitMessage = value;
                NotifyPropertyChanged("CommitMessage");
            }
        }
        #endregion


        #region Command
        //**** Command ****

        // Command property
        public DelegateCommand CommitCommand { get; private set; }



        //Comand method

        public void Commit(object action)
        {
            
            /*
            // Write content to file system
            if (richTextBoxCommitText.Text == "")
            {
                MessageBox.Show("Write commit message");
            }
            else
            {


                LibGit2Sharp.Commands.Stage(repo, "*");


                // Create the committer's signature and commit

                UserConnectForm form = new UserConnectForm();
                form.ShowDialog();

                Signature author = new Signature(form.ReturnName(), form.ReturnEmail(), DateTime.Now);
                Signature committer = author;

                // Commit to the repository
                Commit commit = repo.Commit(richTextBoxCommitText.Text, author, committer);



                MessageBox.Show("YEY");
            }*/
        }



        #endregion


        #region Constructor
        //**** Constructor ****
        public RepositoryViewModel(string pot)
        {
            this.Pot = pot;
            ListFileStage = StageFiles(this.Pot);
            ListFileUnstage = UnStageFiles(this.Pot);

            //Commands
            CommitCommand = new DelegateCommand(Commit);
        }
        public RepositoryViewModel()
        {
        }
        #endregion

        #region Method
        //**** Method ****

        //Get the List of Stage Files
        private ObservableCollection<FileModel> StageFiles(string fileFullPath)
        {
            ObservableCollection<FileModel> listOfStageFiles = new ObservableCollection<FileModel>();
            using (var repo = new Repository(fileFullPath))
            {
                foreach (var item in repo.RetrieveStatus(new LibGit2Sharp.StatusOptions()))
                {

                    FileModel fm = new FileModel();
                    fm.FileName = item.FilePath;
                    fm.Status = item.State.ToString();
                    fm.Size = GetFormattedFileSize(fileFullPath + "/" + fm.FileName);
                    if (fm.Status.Contains("ModifiedInIndex") == true)
                    {

                        listOfStageFiles.Add(fm);

                    }
                }
            }
            return listOfStageFiles;
        }

        //Get the size of file
        private static string GetFormattedFileSize(string fileFullPath)
        {
            if (!File.Exists(fileFullPath))
                return "--";

            double bytes = new System.IO.FileInfo(fileFullPath).Length;

            string[] suffixes = { "B", "KB", "MB", "GB" };
            int order = 0;

            while (bytes >= 1024 && order + 1 < suffixes.Length)
            {
                order++;
                bytes = bytes / 1024;
            }

            return string.Format("{0:0.##} {1}", bytes, suffixes[order]);
        }

        //get the List of Unstagefiles
        private ObservableCollection<FileModel> UnStageFiles(string fileFullPath)
        {
            ObservableCollection<FileModel> listOfUnStageFiles = new ObservableCollection<FileModel>();
            using (var repo = new Repository(fileFullPath))
            {
                foreach (var item in repo.RetrieveStatus(new LibGit2Sharp.StatusOptions()))
                {

                    FileModel fm = new FileModel();
                    fm.FileName = item.FilePath;
                    fm.Status = item.State.ToString();
                    fm.Size = GetFormattedFileSize(fileFullPath + "/" + fm.FileName);
                    if (fm.Status.Contains("ModifiedInIndex") == true)
                    {
                    }
                    else
                    {
                        listOfUnStageFiles.Add(fm);
                    }
                }
            }
            return listOfUnStageFiles;
        }

        // Add to stage
        public void AddToStage()
        {
            using (var repo = new Repository(Pot))
            {
                Commands.Stage(repo, "*");
                /*this.ListFileStage = new ObservableCollection<FileModel>();
                this.ListFileUnstage = new ObservableCollection<FileModel>();*/
                this.ListFileUnstage = this.UnStageFiles(Pot);
                this.ListFileStage = this.StageFiles(Pot);
            }
        }

        public void ResetStage()
        {
            using (var repo = new Repository(this.Pot))
            {
                Commit currentCommit = repo.Head.Tip;
                repo.Reset(ResetMode.Mixed, currentCommit);
            }
            /*this.ListFileStage = new ObservableCollection<FileModel>();
            this.ListFileUnstage = new ObservableCollection<FileModel>();*/
            this.ListFileUnstage = this.UnStageFiles(Pot);
            this.ListFileStage = this.StageFiles(Pot);
        }
        #endregion

        /*
        //COMMIT
        //
        //**/

        





    }
}
