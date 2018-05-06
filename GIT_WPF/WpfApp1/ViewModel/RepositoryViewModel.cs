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
        private ObservableCollection<CommitModel> _listCommitHistory;
        private FileModel _selectedFileForDiff;
        private string _commitMessage;
        private string _statusItemDiff;

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

        public FileModel SelectedFileForDiff
        {
            get { return _selectedFileForDiff; }
            set
            {
                if (value != null)
                {
                    _selectedFileForDiff = value;
                    FileDiff();
                }
                NotifyPropertyChanged("SelectedFileForDiff");
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

        public ObservableCollection<CommitModel> ListCommitHistory
        {
            get { return _listCommitHistory; }
            set
            {
                _listCommitHistory = value;
                NotifyPropertyChanged("ListCommitHistory");
            }
        }

        public string StatusItemDiff
        {
            get { return _statusItemDiff; }
            set
            {
                _statusItemDiff = value;
                NotifyPropertyChanged("StatusItemDiff");
            }
        }
        #endregion


        #region Command
        //**** Command ****

        // Command property
        public DelegateCommand CommitCommand { get; private set; }

        public DelegateCommand AddToStageCommand { get; set; }

        public DelegateCommand ResetStageCommand { get; set; }

        public DelegateCommand RescanCommand { get; set; }

        //Comand method

        public void Commit(object action)
        {

            using (var repo = new Repository(Pot))
            {

                Signature author = new Signature("James", "@jugglingnutcase", DateTime.Now);
                Signature committer = author;

                // Commit to the repository
                Commit commit = repo.Commit(CommitMessage, author, committer);

            }
            // Vizual efekt
            CommitMessage = "";
            StageOrUnstageFileToList();
            CommitHistory();
        }

        public void AddToStage(object action)
        {
            using (var repo = new Repository(this.Pot))
            {
                Commands.Stage(repo, "*");
            }
            StageOrUnstageFileToList();
            /*if(ListFileUnstage.Count==0)
            {*/
                StatusItemDiff = "";
            //}
        }

        public void ResetStage(object action)
        {
            using (var repo = new Repository(this.Pot))
            {
                Commit currentCommit = repo.Head.Tip;
                repo.Reset(ResetMode.Mixed, currentCommit);
            }
            StageOrUnstageFileToList();
        }

        public void Rescan(object action)
        {
            StageOrUnstageFileToList();
        }

        #endregion


        #region Constructor
        //**** Constructor ****

        public RepositoryViewModel(string pot, bool needToInit)
        {
            this.Pot = pot;
            InitRepo();
            ListFileStage = new ObservableCollection<FileModel>();
            ListFileUnstage = new ObservableCollection<FileModel>();
            ListCommitHistory = new ObservableCollection<CommitModel>();



            StatusItemDiff = "";

            //Commands
            CommitCommand = new DelegateCommand(Commit);
            AddToStageCommand = new DelegateCommand(AddToStage);
            ResetStageCommand = new DelegateCommand(ResetStage);
            RescanCommand = new DelegateCommand(Rescan);

        }

        public RepositoryViewModel(string pot, string remoteUrl)
        {
            this.Pot = pot;
            CloneRepo(remoteUrl);
            ListFileStage = new ObservableCollection<FileModel>();
            ListFileUnstage = new ObservableCollection<FileModel>();
            ListCommitHistory = new ObservableCollection<CommitModel>();
            StageOrUnstageFileToList();
            CommitHistory();


            StatusItemDiff = "";

            //Commands
            CommitCommand = new DelegateCommand(Commit);
            AddToStageCommand = new DelegateCommand(AddToStage);
            ResetStageCommand = new DelegateCommand(ResetStage);
            RescanCommand = new DelegateCommand(Rescan);
        }


        public RepositoryViewModel(string pot)
        {/*
            this.Pot = pot;
            ListFileStage = StageFiles(this.Pot);
            ListFileUnstage = UnStageFiles(this.Pot);
            ListCommitHistory = CommitHistory();
            */

            this.Pot = pot;
            ListFileStage = new ObservableCollection<FileModel>();
            ListFileUnstage = new ObservableCollection<FileModel>();
            ListCommitHistory = new ObservableCollection<CommitModel>();
            StageOrUnstageFileToList();
            CommitHistory();


            StatusItemDiff = "";

            //Commands
            CommitCommand = new DelegateCommand(Commit);
            AddToStageCommand = new DelegateCommand(AddToStage);
            ResetStageCommand = new DelegateCommand(ResetStage);
            RescanCommand = new DelegateCommand(Rescan);
        }
        public RepositoryViewModel()
        {
        }
        #endregion

        #region Method
        //**** Method ****


        //Get the List of Stage Files
        /*
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
                    if (item.State == FileStatus.DeletedFromIndex || item.State == FileStatus.ModifiedInIndex || item.State == FileStatus.NewInIndex || item.State == FileStatus.RenamedInIndex || item.State == FileStatus.TypeChangeInIndex)
                    {
                        listOfStageFiles.Add(fm);
                    }/*
                    if (fm.Status.Contains("ModifiedInIndex") == true)
                    {

                        listOfStageFiles.Add(fm);

                    }*//*
                }
            }

            return listOfStageFiles;
        }

    */
        private void CloneRepo(string remote)
        {
            Repository.Clone(remote, this.Pot);
        }



        private void InitRepo()
        {
            Repository.Init(this.Pot);
        }

        private void StageOrUnstageFileToList()
        {

            ListFileStage = new ObservableCollection<FileModel>();
            ListFileUnstage = new ObservableCollection<FileModel>();

            using (var repo = new Repository(Pot))
            {
                foreach (var item in repo.RetrieveStatus(new LibGit2Sharp.StatusOptions()))
                {

                    FileModel fm = new FileModel();
                    fm.FileName = item.FilePath;
                    fm.Status = item.State.ToString();
                    fm.Size = GetFormattedFileSize(Pot + "/" + fm.FileName);
                    if (item.State == FileStatus.DeletedFromIndex || item.State == FileStatus.ModifiedInIndex || item.State == FileStatus.NewInIndex || item.State == FileStatus.RenamedInIndex || item.State == FileStatus.TypeChangeInIndex)
                    {
                        ListFileStage.Add(fm);
                    }
                    else
                    {
                        ListFileUnstage.Add(fm);
                    }

                }
            }
  
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
        /*
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
        }*/
        /*
        // Add to stage
        public void AddToStage()
        {
            using (var repo = new Repository(Pot))
            {
                Commands.Stage(repo, "*");
                /*this.ListFileStage = new ObservableCollection<FileModel>();
                this.ListFileUnstage = new ObservableCollection<FileModel>();*//*
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
            this.ListFileUnstage = new ObservableCollection<FileModel>();*//*
            this.ListFileUnstage = this.UnStageFiles(Pot);/*
            this.ListFileStage = this.StageFiles(Pot);
        }*/

        public void CommitHistory()
        {
            ListCommitHistory = new ObservableCollection<CommitModel>();

            Repository repo = new Repository(Pot);

            foreach (LibGit2Sharp.Commit commit in repo.Commits)
            {


                CommitModel c = new CommitModel();
                c.AuthorEmail = commit.Author.Email;
                c.AuthorName = commit.Author.Name;
                c.Date = commit.Author.When.ToString("d.M.yyyy H:m:s");
                c.Description = commit.MessageShort;
                c.Hash = commit.Sha;

                ListCommitHistory.Add(c);
            };

        }

        public void FileDiff()
        {

            var repo = new Repository(this.Pot);
            var patch = repo.Diff.Compare<Patch>(new List<string>() { SelectedFileForDiff.FileName });


            this.StatusItemDiff =patch;
        }

        #endregion


        





    }
}
