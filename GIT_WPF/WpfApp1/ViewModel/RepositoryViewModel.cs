﻿using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WpfApp1.Model;
using WpfApp1.Other;
using WpfApp1.View;
using WpfApp1.View.Dialogs;


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
        private ObservableCollection<BranchModel> _listBranches;
        private ObservableCollection<TagModel> _listTags;
        private CommitModel _selectedCommit;


        #endregion


        #region Property
        //**** Property ****

        public CommitModel SelectedCommit
        {
            get { return _selectedCommit; }
            set { _selectedCommit = value; }
        }

        public ObservableCollection<TagModel> ListTags
        {
            get { return _listTags; }
            set { _listTags = value; }
        }

        public ObservableCollection<BranchModel> ListBranches
        {
            get { return _listBranches; }
            set
            {
                _listBranches = value;
                NotifyPropertyChanged("ListBranches");
            }
        }

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

        public DelegateCommand PushCommand { get; set; }

        public DelegateCommand PullCommand { get; set; }

        public DelegateCommand AddNewBranchCommand { get; set; }

        public DelegateCommand AddTagCommand { get; set; }

        //public DelegateCommand DeleteNewBranchCommand { get; set; }

        //Comand method


        private void AddTag(object action)
        {
            BranchDialog dialog = new BranchDialog();
            dialog.ShowDialog();
            TagModel mod = new TagModel();
            mod.Name = dialog.ReturnName();

            using (var repo = new Repository(Pot))
            {
                Tag t = repo.ApplyTag(mod.Name);
            }
            ListTags.Add(mod);
        }


        private void AddBranch(object action)
        {
            BranchDialog dialog = new BranchDialog();
            dialog.ShowDialog();
            BranchModel mod = new BranchModel();
            mod.Name = dialog.ReturnName();


            using (var repo = new Repository(Pot))
            {
                repo.CreateBranch(mod.Name);   // Or repo.Branches.Add("develop", "HEAD");

                var branch = repo.Branches[mod.Name];

                mod.IsHead = false;
            }
            ListBranches.Add(mod);

        }



        private void Pull(object action)
        {
            //UserContactView logInForm = new UserContactView();
            UserContactDialog logInForm = new UserContactDialog();
            logInForm.ShowDialog();
            string userName = logInForm.returnUN();
            string pass = logInForm.returnPass();

            using (var repo = new Repository(Pot))
            {
                LibGit2Sharp.PullOptions options = new LibGit2Sharp.PullOptions();
                options.FetchOptions = new FetchOptions();
                options.FetchOptions.CredentialsProvider = new CredentialsHandler(
                    (url, usernameFromUrl, types) =>
                        new UsernamePasswordCredentials()
                        {
                            Username = userName,
                            Password = pass
                        });

                Commands.Pull(repo, new Signature(userName, "@jugglingnutcase", new DateTimeOffset(DateTime.Now)), options);
            }
        }


        private void Push(object action)
        {
            using (var repo = new Repository(this.Pot))
            {
                UserContactDialog logInForm = new UserContactDialog();
                logInForm.ShowDialog();
                string userName = logInForm.returnUN();
                string pass = logInForm.returnPass();


                Remote remote = repo.Network.Remotes["origin"];
                var options = new PushOptions();
                options.CredentialsProvider = (_url, _user, _cred) =>
                    new UsernamePasswordCredentials { Username = userName, Password = pass };


                var pushRefSpec = @"refs/heads/master";
                repo.Network.Push(remote, pushRefSpec, options);

            }

           // MessageBox.Show("YEA-PUSH");
        }

        private void Commit(object action)
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

        private void AddToStage(object action)
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

        private void ResetStage(object action)
        {
            using (var repo = new Repository(this.Pot))
            {
                Commit currentCommit = repo.Head.Tip;
                repo.Reset(ResetMode.Mixed, currentCommit);
            }
            StageOrUnstageFileToList();
        }

        private void Rescan(object action)
        {
            StageOrUnstageFileToList();
        }

        #endregion


        #region Constructor
        //**** Constructor ****

        public RepositoryViewModel(string pot, bool needToInit)
        {
            this.Pot = pot;
            if(needToInit==true)
            {
                InitRepo();
                ListFileStage = new ObservableCollection<FileModel>();
                ListFileUnstage = new ObservableCollection<FileModel>();
                ListCommitHistory = new ObservableCollection<CommitModel>();
                ListTags = new ObservableCollection<TagModel>();

                StatusItemDiff = "";
                FileSystemWatcher();

                //Commands
                CommitCommand = new DelegateCommand(Commit);
                AddToStageCommand = new DelegateCommand(AddToStage);
                ResetStageCommand = new DelegateCommand(ResetStage);
                RescanCommand = new DelegateCommand(Rescan);
                PushCommand = new DelegateCommand(Push);
                PullCommand = new DelegateCommand(Pull);
                AddNewBranchCommand = new DelegateCommand(AddBranch);
                AddTagCommand = new DelegateCommand(AddTag);
            }
            else
            {
                FileSystemWatcher();
            }
            
        }


        public RepositoryViewModel(string pot)
        {
            this.Pot = pot;
            ListFileStage = new ObservableCollection<FileModel>();
            ListFileUnstage = new ObservableCollection<FileModel>();
            ListCommitHistory = new ObservableCollection<CommitModel>();
            ListBranches = new ObservableCollection<BranchModel>();
            ListTags = new ObservableCollection<TagModel>();
            StageOrUnstageFileToList();
            CommitHistory();
            GetBranch();
            GetTags();

            FileSystemWatcher();
            StatusItemDiff = "";

            //Commands
            CommitCommand = new DelegateCommand(Commit);
            AddToStageCommand = new DelegateCommand(AddToStage);
            ResetStageCommand = new DelegateCommand(ResetStage);
            RescanCommand = new DelegateCommand(Rescan);
            PushCommand = new DelegateCommand(Push);
            PullCommand = new DelegateCommand(Pull);
            AddNewBranchCommand = new DelegateCommand(AddBranch);
            AddTagCommand = new DelegateCommand(AddTag);
        }
        public RepositoryViewModel()
        {
            //FileSystemWatcher();
        }
        #endregion

        #region Method
        //**** Method ****

        // Load all the content to refres repo data.
        private void Load()
        {

            StageOrUnstageFileToList();
            GetBranch();
            GetTags();

        }


        private void GetTags()
        {
            ListTags = new ObservableCollection<TagModel>();
            using (var repo = new Repository(Pot))
            {
                TagModel tag;
                foreach (Tag t in repo.Tags)
                {
                    tag = new TagModel();
                    tag.Name = t.FriendlyName;
                    ListTags.Add(tag);
                }
            }
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
                    if (item.State != FileStatus.Ignored)
                    {
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

        private void CommitHistory()
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

        private void FileDiff()
        {

            var repo = new Repository(this.Pot);
            var patch = repo.Diff.Compare<Patch>(new List<string>() { SelectedFileForDiff.FileName });


            this.StatusItemDiff =patch;
        }

        private void GetBranch()
        {
            ListBranches = new ObservableCollection<BranchModel>();
            using (var repo = new Repository(this.Pot))
            {
                foreach (Branch b in repo.Branches.Where(b => !b.IsRemote))
                {
                    BranchModel cnd = new BranchModel();
                    cnd.Name = b.FriendlyName;
                    cnd.IsHead = b.IsCurrentRepositoryHead;
                    ListBranches.Add(cnd);
                }
            }
        }

        #endregion

        #region Public Method

        public bool CloneRepo(string remote, string path, string userName, string pass)
        {
            try
            {
                var co = new CloneOptions();
                co.CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials { Username = userName, Password = pass };
                Repository.Clone(remote, path, co);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CheckoutBranch(BranchModel br)
        {
            using (var repo = new Repository(Pot))
            {
                var branch = repo.Branches[br.Name];

                Branch currentBranch = Commands.Checkout(repo, branch);
            }
        }

        public void DeleteBranch(BranchModel br)
        {
            using (var repo = new Repository(Pot))
            {
                repo.Branches.Remove(br.Name);
                ListBranches.Remove(br);
            }
        }

        public bool IsInit(string pat)
        {

            bool isOrNot = Repository.IsValid(pat);
            if (isOrNot == true)
            {
                return true;
            }
            return false;
        }


        #endregion

        #region Watcher
        // watching if some content in repo is changed
        delegate void ReloadStatusDelegate(object sender, FileSystemEventArgs e);

        private void FileSystemWatcher()
        {

            var watcher = new FileSystemWatcher();

            ReloadStatusDelegate reloadStatusDelegate = delegate (object sender, FileSystemEventArgs e)
            {
                Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    (Action)(() => Load())
                );
            };

            watcher.Changed += new FileSystemEventHandler(reloadStatusDelegate);
            watcher.Deleted += new FileSystemEventHandler(reloadStatusDelegate);
            watcher.Renamed += new RenamedEventHandler(reloadStatusDelegate);
            watcher.Created += new FileSystemEventHandler(reloadStatusDelegate);
            watcher.Path = Pot;
            watcher.EnableRaisingEvents = true;


        }
        #endregion



    }
}
