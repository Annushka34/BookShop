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

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Admin adminWindow;
        public MainWindow()
        {
            InitializeComponent();
            ratings1.Value = 3;
            ratings1.NumberOfStars = 5;
            ratings1.BackgroundColor = Brushes.White;
            ratings1.StarForegroundColor = Brushes.Orange;
            ratings1.StarOutlineColor = Brushes.DarkGray;
        }

        private void Admin_OnClick(object sender, RoutedEventArgs e)
        {
            adminWindow = new Admin();
            adminWindow.Show(this);
            this.Hide();
        }

        private void BLogIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BRegistration_Click(object sender, RoutedEventArgs e)
        {
            Registration register = new Registration(this);
            register.Show();
            Hide();
        }
    }
}
