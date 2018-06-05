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

namespace WpfApp1.View.Dialogs
{
    /// <summary>
    /// Interaction logic for CommitDialog.xaml
    /// </summary>
    public partial class CommitDialog : Window
    {
        public CommitDialog()
        {
            InitializeComponent();
        }
        public CommitDialog(UserModel user)
        {
            InitializeComponent();
            UserNameTextbox.Text = user.Name;
            EmailTextbox.Text = user.Email;
        }

        private void ConformBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public UserModel returnData()
        {
            
            UserModel ne = new UserModel();
            ne.Name = UserNameTextbox.Text;
            ne.Email = EmailTextbox.Text;
            return ne;
        }

    }
}
