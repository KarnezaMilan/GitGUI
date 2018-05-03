using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class RepositoryViewModel
    {

        public List<FileModel> StageFiles(string fileFullPath)
        {
            List<FileModel> listOfStageFiles = new List<FileModel>();
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

        public List<FileModel> UnStageFiles(string fileFullPath)
        {
            List<FileModel> listOfUnStageFiles = new List<FileModel>();
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


        /// <summary>
        /// Size Of DAta
        /// </summary>
        /// <param name="fileFullPath"></param>
        /// <returns></returns>
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




    }
}
