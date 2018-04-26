using LibGit2Sharp;
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
using WpfApp1.Model;
using WpfApp1.UserControls;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for ViewUC.xaml
    /// </summary>
    public partial class ViewUC : Window
    {
        public string Pot = "C:/Users/Mili/Desktop/Novamapa";

        public ViewUC()
        {
            InitializeComponent();
            this.Preload();
        }

        public void Preload()
        {


        }
        

        public void StageFileDataGrid()
        {
        }

        public void UnStageFileDataGrid()
        {
        }



    }
}
