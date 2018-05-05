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
        }

        private void UCWindow_Click(object sender, RoutedEventArgs e)
        {
            ViewUC uc = new ViewUC();
            uc.Show();
            this.Close();
        }
    }
}
