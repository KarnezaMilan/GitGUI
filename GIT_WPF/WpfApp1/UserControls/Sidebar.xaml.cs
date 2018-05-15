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
using WpfApp1.View.Dialogs;
using WpfApp1.ViewModel;

namespace WpfApp1.UserControls
{
    /// <summary>
    /// Interaction logic for Sidebar.xaml
    /// </summary>
    public partial class Sidebar : UserControl
    {
        public Sidebar()
        {
            InitializeComponent();
        }

        private void AddNewBranch_Click(object sender, RoutedEventArgs e)
        {
            BranchDialog dialog = new BranchDialog();
            dialog.ShowDialog();
            string nameOfNewBranch = dialog.ReturnName();
            if(nameOfNewBranch!=null)
            {
                RepositoryViewModel repo = new RepositoryViewModel();
                //repo.AddNewBranch();
            }

        }

        private void CheckoutBranch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBranch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
