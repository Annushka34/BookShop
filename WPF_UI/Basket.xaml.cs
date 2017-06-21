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
    /// Interaction logic for Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        public Basket()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource userProviderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userProviderViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // userProviderViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource userViewModelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewModelViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // userViewModelViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource userUILoginModelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userUILoginModelViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // userUILoginModelViewSource.Source = [generic data source]
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            IUserProvider userProvider = new UserProvider();
            List<UserUILoginModel> users = userProvider.GetAllUsers();
            userUILoginModelDataGrid.ItemsSource = users;
        }
    }
}
