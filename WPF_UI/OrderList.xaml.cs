using BLL.AbstractProviders;
using BLL.ConcreteProviders;
using BLL.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for OrderList.xaml
    /// </summary>
    public partial class OrderList : Window
    {
        List<OrderUIModel> orders = new List<OrderUIModel>();  
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
            IOrderProvider orderProvider = new OrderProvider();
            orders = orderProvider.GetAllOrdersByCustomer(selectedUser.UserId);
            AddOrderToStack();

        }
        private void AddOrderToStack()
        {
            OrderStack.Children.Clear();
            foreach(OrderUIModel order in orders)
            {
                var newExpander = new Expander { Header =order.CloseDate.ToString() };
                var newstackPanel = new StackPanel { };
                DataGrid orderRecordsDataGrid = new DataGrid();
                orderRecordsDataGrid.ItemsSource = order.OrderRecords;
                     
                newstackPanel.Children.Add(orderRecordsDataGrid);
                newExpander.Content = newstackPanel;
                OrderStack.Children.Add(newExpander);
                Separator separatop = new Separator();
                OrderStack.Children.Add(separatop);
            }                     
        }
    }
   
}
