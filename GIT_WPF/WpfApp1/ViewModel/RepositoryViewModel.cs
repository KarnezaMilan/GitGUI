using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms = System.Windows.Forms;



namespace WpfApp1.ViewModel
{
    public class RepositoryViewModel : MainWindow
    {

        protected MainWindow window;

        public RepositoryViewModel(MainWindow window)
        {
            this.window = window;
        }

        public RepositoryViewModel()
        {   
        }

        public void OpenRepository()
        {
            string aa=null;

            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            aa = dialog.SelectedPath;

            MainWindow mw = new MainWindow();
            

            mw.Show();
          


        }

        public void CreateRepositor()
        {
            var dialog = new WinForms.FolderBrowserDialog
            {
                Description = "hoose the folder for your new repository."
            };

            dialog.ShowDialog();

            if (!String.IsNullOrEmpty(dialog.SelectedPath))
            {
                LibGit2Sharp.Repository.Init(dialog.SelectedPath);

            }
            dialog.Dispose();
        }


    }



}
