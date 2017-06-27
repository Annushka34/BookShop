using BLL.AbstractProviders;
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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        MainWindow _main;
        public Registration(MainWindow mainWindow)
        {
            InitializeComponent();
            _main = mainWindow;
        }

        private void BRegister_Click(object sender, RoutedEventArgs e)
        {
            IUserProvider userProvider = new UserProvider();
            UserViewModel userModel = new UserViewModel();
            userModel.Login = TLogin.Text;
            userModel.Password = TPassword.Password;
            userModel.Email = TEmail.Text;
            userModel.Role = UserRole.Customer;
            UserStatus userStatus = userProvider.UserRegistration(userModel);
            if(userStatus == UserStatus.Success)
            {
                MessageBox.Show("Registration complete");
                Message mess = new Message("Registration complite");
                mess.Show();
                _main.Show();
                Close();
                return;
            }
            MessageBox.Show("Registration not complite. Try again");
            _main.Show();
            Close();
        }
    }
}
