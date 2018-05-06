using Microsoft.Win32;
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
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for OpenWindow.xaml
    /// </summary>
    public partial class OpenWindow : Window
    {
        public OpenWindow()
        {
            InitializeComponent();
        }

        private void OpenRepo_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = false
            };

            DialogResult result = dialog.ShowDialog();
            string selectedFolder = null;
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                selectedFolder = dialog.SelectedPath;

                ViewUC view = new ViewUC(selectedFolder);
                view.Show();
                this.Close();

            }
        }

        private void UCWindow_Click(object sender, RoutedEventArgs e)
        {
            ViewUC uc = new ViewUC();
            uc.Show();
            this.Close();
        }


        private void CloseRepo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloneRepo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
