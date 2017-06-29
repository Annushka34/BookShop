using BLL.AbstractProviders;
using BLL.ConcreteProviders;
using BLL.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for OrderList.xaml
    /// </summary>
    public partial class OrderList : Window
    {
        ObservableCollection<OrderRecordUIModel> orders = new ObservableCollection<OrderRecordUIModel>();  
        public OrderList()
        {
            InitializeComponent();
            UserProvider userProvider = new UserProvider();
            var users = userProvider.GetAllUsers();
            UserDataGrid.ItemsSource = users;           
        }  
      
        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserUILoginModel selectedUser = (UserUILoginModel)UserDataGrid.SelectedItem;
            IGeneralProvider orderProvider = new GeneralProvider();
            orders = orderProvider.GetAllOrderRecordsByCustomer(selectedUser.UserId);
            LBOrders.ItemsSource = orders;
        }
    }
   
}
