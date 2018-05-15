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
    /// Interaction logic for UserContactDialog.xaml
    /// </summary>
    public partial class UserContactDialog : Window
    {
        public UserContactDialog()
        {
            InitializeComponent();
        }

        private void CancleBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConformBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserNameTextbox.Text != "" && PasswordTextbox.Password != "")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to fill the form !");
            }
        }

        public string returnUN()
        {
            return UserNameTextbox.Text;
        }
        public string returnPass()
        {
            return PasswordTextbox.Password;
        }

    }
}
