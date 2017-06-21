using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using BLL.AbstractProviders;
using BLL.ConcreteProviders;
using BLL.ViewModels;

namespace WPF_UI
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    /// 

    public partial class Admin : Window
    {
        private Message messWindow;
        private MainWindow main;
        private string tableSelected;
        private string tableSelectedFromExisting;
        public Admin()
        {
            InitializeComponent();
            tableSelected = "";
        }




        //private void CTable_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ComboBox comboBox = (ComboBox)sender;
        //    TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
        //    tableSelected = selectedItem.Text;
        //}
        private void CTableExisting_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            tableSelected = selectedItem.Text;
            switch (tableSelected)
            {
                case "Admin":
                    {
                        StackPanelExistingItems.Children.Clear();
                        UserProvider userProvider = new UserProvider();
                        var users = userProvider.GetAllUsers();
                        foreach (var user in users)
                        {
                            CheckBox checkBox = new CheckBox();
                            checkBox.Content = user.UserLogin;
                            StackPanelExistingItems.Children.Add(checkBox);
                        }
                        break;
                    }
                case "Author":
                    {

                        break;
                    }
                case "Category":
                    {
                        StackPanelExistingItems.Children.Clear();

                        ICategoryProvider categoryProvider = new CategoryProvider();
                        var categories = categoryProvider.GetAllCategoriesNames();
                        foreach (var category in categories)
                        {
                            CheckBox checkBox = new CheckBox();
                            checkBox.Content = category.Name;
                            StackPanelExistingItems.Children.Add(checkBox);
                        }
                        break;
                    }
                case "Book":
                    {

                        break;
                    }
                case "Publish":
                    {

                        break;
                    }
                case "Tag":
                    {

                        break;
                    }
            }
        }



        private void BtnSelect_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            switch (tableSelected)
            {
                case "Admin":
                    {
                        SetHiddenAll();
                        Label1.Content = "Email";
                        Label2.Content = "Login";
                        Label3.Content = "Password";

                        SetVisible(TextBox1);
                        SetVisible(TextBox2);
                        SetVisible(PasswordBox3);
                        SetVisible(Label1);
                        SetVisible(Label2);
                        SetVisible(Label3);
                        break;
                    }
                case "Author":
                    {
                        SetHiddenAll();
                        Label1.Content = "First name";
                        Label2.Content = "LastName";
                        Label3.Content = "SelectBooks";

                        CheckBox checkBox = new CheckBox();
                        checkBox.Content = "book 1";
                        ComboBox3.Items.Add(checkBox);
                        CheckBox checkBox1 = new CheckBox();
                        checkBox1.Content = "book 2";
                        ComboBox3.Items.Add(checkBox1);

                        SetVisible(TextBox1);
                        SetVisible(TextBox2);
                        SetVisible(ComboBox3);
                        SetVisible(Label1);
                        SetVisible(Label2);
                        SetVisible(Label3);
                        break;
                    }
                case "Category":
                    {
                        SetHiddenAll();
                        Label1.Content = "Category name";
                        Label3.Content = "SelectBooks";

                        CheckBox checkBox = new CheckBox();
                        checkBox.Content = "book 1";
                        ComboBox3.Items.Add(checkBox);
                        CheckBox checkBox1 = new CheckBox();
                        checkBox1.Content = "book 2";
                        ComboBox3.Items.Add(checkBox1);

                        SetVisible(Label1);
                        SetVisible(Label3);
                        SetVisible(TextBox1);
                        SetVisible(ComboBox3);
                        break;
                    }
                case "Book":
                    {
                        SetHiddenAll();
                        Label1.Content = "Book name";
                        Label2.Content = "Select category";
                        Label3.Content = "Select author";
                        Label4.Content = "Select publich";
                        Label5.Content = "Select picture";

                        CheckBox checkBox1 = new CheckBox();
                        checkBox1.Content = "Author 1";
                        ComboBox3.Items.Add(checkBox1);
                        CheckBox checkBox2 = new CheckBox();
                        checkBox2.Content = "Author 2";
                        ComboBox3.Items.Add(checkBox2);

                        ICategoryProvider categoryProvider = new CategoryProvider();
                        var categories = categoryProvider.GetAllCategoriesNames();
                        foreach (var category in categories)
                        {
                            CheckBox checkBox = new CheckBox();
                            checkBox.Content = category.Name;
                            ComboBox2.Items.Add(checkBox);
                        }


                        SetVisible(Label1);
                        SetVisible(Label2);
                        SetVisible(Label3);
                        SetVisible(Label4);
                        SetVisible(TextBox1);
                        SetVisible(ComboBox4);
                        SetVisible(ComboBox2);
                        SetVisible(ComboBox3);
                        IPicture.Visibility=Visibility.Visible;
                        break;
                    }
                case "Publish":
                    {
                        SetHiddenAll();
                        Label1.Content = "Publish name";
                        Label3.Content = "Select books";

                        CheckBox checkBox = new CheckBox();
                        checkBox.Content = "book 1";
                        ComboBox3.Items.Add(checkBox);
                        CheckBox checkBox1 = new CheckBox();
                        checkBox1.Content = "book 2";
                        ComboBox3.Items.Add(checkBox1);

                        SetVisible(Label1);
                        SetVisible(Label3);
                        SetVisible(TextBox1);
                        SetVisible(ComboBox3);
                        break;
                    }
                case "Tag":
                    {
                        SetHiddenAll();
                        Label1.Content = "Tag";
                        Label3.Content = "Select books";

                        CheckBox checkBox = new CheckBox();
                        checkBox.Content = "book 1";
                        ComboBox3.Items.Add(checkBox);
                        CheckBox checkBox1 = new CheckBox();
                        checkBox1.Content = "book 2";
                        ComboBox3.Items.Add(checkBox1);

                        SetVisible(Label1);
                        SetVisible(Label3);
                        SetVisible(TextBox1);
                        SetVisible(ComboBox3);
                        break;
                    }
            }
            SPTable.Visibility = Visibility.Visible;
        }
        private void BtnAddToDataBase_OnClick(object sender, RoutedEventArgs e)
        {
            switch (tableSelected)
            {
                case "Admin":
                    {
                        UserViewModel user = new UserViewModel();
                        user.Email = TextBox1.Text;
                        user.Login = TextBox2.Text;
                        user.Password = PasswordBox3.Password;
                        user.Role = UserRole.Admin;
                        IUserProvider userProvider = new UserProvider();
                        userProvider.UserRegistration(user);
                        break;
                    }
                case "Author":
                    {

                        break;
                    }
                case "Category":
                    {
                        CategoryViewModel category = new CategoryViewModel();
                        category.CategoryName = TextBox1.Text;
                        ICategoryProvider categoryProvider = new CategoryProvider();
                        categoryProvider.CreateNewCategory(category);
                        break;
                    }
                case "Book":
                    {

                        break;
                    }
                case "Publish":
                    {

                        break;
                    }
                case "Tag":
                    {

                        break;
                    }

            }
        }
        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void BtnUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            SPTable.Visibility = Visibility.Visible;
        }


        private void SetVisible(Control element)
        {
            element.Visibility = Visibility.Visible;
        }
        private void SetHidden(Control element)
        {
            element.Visibility = Visibility.Hidden;
        }
        private void SetHiddenAll()
        {
            Label1.Visibility = Visibility.Collapsed;
            Label2.Visibility = Visibility.Collapsed;
            Label3.Visibility = Visibility.Collapsed;
            Label4.Visibility = Visibility.Collapsed;
            Label5.Visibility = Visibility.Collapsed;
            TextBox1.Visibility = Visibility.Collapsed;
            TextBox2.Visibility = Visibility.Collapsed;
            TextBox3.Visibility = Visibility.Collapsed;
            TextBox4.Visibility = Visibility.Collapsed;
            ComboBox1.Visibility = Visibility.Collapsed;
            ComboBox2.Visibility = Visibility.Collapsed;
            ComboBox3.Visibility = Visibility.Collapsed;
            ComboBox4.Visibility = Visibility.Collapsed;
            PasswordBox3.Visibility = Visibility.Collapsed;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            Label1.Content="";
            Label2.Content = "";
            Label3.Content = "";
            Label4.Content = "";
            Label5.Content = "";
            ComboBox1.Items.Clear();
            ComboBox2.Items.Clear();
            ComboBox3.Items.Clear();
            ComboBox4.Items.Clear();
            PasswordBox3.Password = "";
            IPicture.Visibility = Visibility.Collapsed;
        }

        internal void Show(MainWindow mainWindow)
        {
            this.Show();
            main = mainWindow;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            main.Show();
        }
    }
}
