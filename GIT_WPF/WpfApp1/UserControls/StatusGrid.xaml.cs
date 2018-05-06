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
using WpfApp1.ViewModel;
using System.ComponentModel;

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
        }
        
        private void HHh_Click(object sender, RoutedEventArgs e)
        {/*
            RepositoryViewModel aa = new RepositoryViewModel(Pot);
            aa.ResetStage();*/
        }
    }
}
