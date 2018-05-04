using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class RepositoryViewModel
    {
        #region Atribute
        private string _pot;
        private ObservableCollection<FileModel> _ListFileStage;
        private ObservableCollection<FileModel> _listFileUnstage;
        #endregion

        #region Property
        public ObservableCollection<FileModel> ListFileUnstage
        {
            get { return _listFileUnstage; }
            set { _listFileUnstage = value; }
        }

        public ObservableCollection<FileModel> ListFileStage
        {
            get { return _ListFileStage; }
            set { _ListFileStage = value; }
        }

        public string Pot
        {
            get { return _pot; }
            set { _pot = value; }
        }
        #endregion

        #region Constructor
        public RepositoryViewModel(string pot)
        {
            this.Pot = pot;
            ListFileStage = StageFiles(this.Pot);
            ListFileUnstage = UnStageFiles(this.Pot);
        }
        #endregion

        #region Method

        public ObservableCollection<FileModel> StageFiles(string fileFullPath)
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

        public static string GetFormattedFileSize(string fileFullPath)
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

        public ObservableCollection<FileModel> UnStageFiles(string fileFullPath)
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
                this.ListFileStage= StageFiles(Pot);
            }
        }
        #endregion

    }
}
