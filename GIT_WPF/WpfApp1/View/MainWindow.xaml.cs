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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        protected CommitHistory changesetHistory;

        public MainWindow()
        {

            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            //this.Style = (Style)Resources["GlassStyle"];
            this.changesetHistory = new CommitHistory(this);
            this.Preload();

        }

        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {
            RepositoryViewModel repo = new RepositoryViewModel();

            repo.OpenRepository();
            
            this.Close();

        }

        protected void Preload()
        {
            this.changesetHistory.Load();
        }

        private void MenuItem_Click_Create(object sender, RoutedEventArgs e)
        {
            RepositoryViewModel repo = new RepositoryViewModel();

            repo.CreateRepositor();

        }

    }
}
