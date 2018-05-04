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

namespace WpfApp1.UserControls
{
    /// <summary>
    /// Interaction logic for Toolbars.xaml
    /// </summary>
    public partial class Toolbars : UserControl
    { 

        public string Pot = "C:/Users/Mili/Desktop/Novamapa";

        public Toolbars()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            RepositoryViewModel repoVM = new RepositoryViewModel(Pot);
            repoVM.AddToStage();
        }

        private void RescanBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            RepositoryViewModel repoVM = new RepositoryViewModel(Pot);
            repoVM.ResetStage();
        }
    }
}
