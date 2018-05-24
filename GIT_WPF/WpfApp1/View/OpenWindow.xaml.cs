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
using WpfApp1.Model;
using WpfApp1.View.Dialogs;

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
            CloneRepoPanel.Visibility = Visibility.Hidden;
        }

        private void OpenRepo_Click(object sender, RoutedEventArgs e)
        {
            CloneRepoPanel.Visibility = Visibility.Hidden;
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

        private void CreateRepo_Click(object sender, RoutedEventArgs e)
        {
            CloneRepoPanel.Visibility = Visibility.Hidden;
            var dialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };

            DialogResult result = dialog.ShowDialog();
            string selectedFolder = null;
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                selectedFolder = dialog.SelectedPath;

                ViewUC view = new ViewUC(selectedFolder, true);
                view.Show();
                this.Close();

            }
        }

        private void CloneRepo_Click(object sender, RoutedEventArgs e)
        {
            if (CloneRepoPanel.Visibility == Visibility.Visible)
            {
                CloneRepoPanel.Visibility = Visibility.Hidden;
            }
            else
            {
                CloneRepoPanel.Visibility = Visibility.Visible;
            }

        }

        private void CloneRepoPaste_Click(object sender, RoutedEventArgs e)
        {
            UrlTextbox.Paste();
        }

        private void CloneRepoSerch_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };

            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                LocalTextbox.Text = dialog.SelectedPath;
            }
        }

        private void CloneRepoClone_Click(object sender, RoutedEventArgs e)
        {
            UserContactDialog dialog = new UserContactDialog();
            dialog.ShowDialog();
            RepositoryViewModel repo = new RepositoryViewModel();

            if (repo.CloneRepo(UrlTextbox.Text, LocalTextbox.Text, dialog.returnUN(), dialog.returnPass()) == true)
            {
                dialog.Close();
                ViewUC view = new ViewUC(LocalTextbox.Text);
                view.Show();
                this.Close();

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Ups..something went wrong!!");
            }


        }
    }
}