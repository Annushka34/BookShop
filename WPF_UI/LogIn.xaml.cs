using BLL.ConcreteProviders;
using BLL.ViewModels;
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

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public UserUILoginModel user = new UserUILoginModel();
        MainWindow _main;
        public LogIn()
        {
            InitializeComponent();
        }

        public LogIn(MainWindow main)
        {
            InitializeComponent();
           
            _main = main;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserViewModelLogin guest = new UserViewModelLogin();
            guest.Login = TBLogin.Text;
            guest.Password = PBPassword.Password;
            UserProvider userProvider = new UserProvider();
            user = userProvider.UserLogin(guest);
            if(user!=null)
            {
                _main.Show();
                Close();
                return;
            }
            MessageBox.Show("Incorrect Login Or Password");
        }
    }
}
