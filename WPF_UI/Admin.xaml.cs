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
            tableSelectedFromExisting = "";
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

        private void BtnBookAdd_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            switch (tableSelected)
            {
                case "Admin":
                {
                        UserViewModel user = new UserViewModel();
                        user.Email = TextBox1.Text;
                        user.Login = TextBox2.Text;
                        user.Password = TextBox3.Text;
                        user.Role=UserRole.Admin;
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


        private void CTable_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            tableSelected = selectedItem.Text;
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

                        TextBlock textBlock=new TextBlock();
                        textBlock.Text = "book 1";
                        ComboBox3.Items.Add(textBlock);

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
                    SetVisible(Label1);
                    SetVisible(TextBox1);
                    break;
                }
                case "Book":
                {
                    SetHiddenAll();
                    break;
                }
                case "Publish":
                {
                    SetHiddenAll();
                    break;
                }
                case "Tag":
                {
                    SetHiddenAll();
                    break;
                }
            }
        }
        private void CTableExisting_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            tableSelectedFromExisting = selectedItem.Text;
            switch (tableSelectedFromExisting)
            {
                case "Admin":
                {
                   UserProvider userProvider=new UserProvider();
                   var users=userProvider.GetAllUsers();
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

        private void SetVisible(Control element)
        {
           element.Visibility=Visibility.Visible;
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
            TextBox1.Visibility = Visibility.Collapsed;
            TextBox2.Visibility = Visibility.Collapsed;
            TextBox3.Visibility = Visibility.Collapsed;
            TextBox4.Visibility = Visibility.Collapsed;
            ComboBox3.Visibility = Visibility.Collapsed;
            PasswordBox3.Visibility = Visibility.Collapsed;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            ComboBox3.Text = "";
            PasswordBox3.Password = "";
        }

       
    }
}
