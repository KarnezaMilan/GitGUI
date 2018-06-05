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

namespace WpfApp1.View.Dialogs
{
    /// <summary>
    /// Interaction logic for BranchDialog.xaml
    /// </summary>
    public partial class BranchDialog : Window
    {
        public BranchDialog()
        {
            InitializeComponent();
        }

        public BranchDialog(string rm)
        {
            InitializeComponent();
            NameTextbox.Text = rm;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CancleBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public string ReturnName()
        {
            return NameTextbox.Text;
        }
    }
}
