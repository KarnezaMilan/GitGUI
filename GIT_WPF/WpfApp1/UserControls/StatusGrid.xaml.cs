using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for StatusGrid.xaml
    /// </summary>
    public partial class StatusGrid : UserControl
    {
        public string Pot = "C:/Users/Mili/Desktop/Novamapa";

        public StatusGrid()
        {
            InitializeComponent();
            PreLoad();
        }

        private void PreLoad()
        {
            StageFiles();
        }

        private void StageFiles()
        {
            using (var repo = new Repository(Pot))
            {
                foreach (var item in repo.RetrieveStatus(new LibGit2Sharp.StatusOptions()))
                {

                    FileModel fm = new FileModel();
                    fm.FileName = item.FilePath;
                    fm.Status = item.State.ToString();
                    fm.Size = GetFormattedFileSize(Pot+"/"+fm.FileName);
                    if (fm.Status.Contains("ModifiedInIndex") == true)
                    {
                        StageFilesDataGrid.Items.Add(fm);
                    }else
                    {
                        UnStageFilesDataGrid.Items.Add(fm);
                    }
                }
            }
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
