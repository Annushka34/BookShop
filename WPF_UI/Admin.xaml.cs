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
        public Admin()
        {
            InitializeComponent();
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

        private void BtnUserAdd_OnClick(object sender, RoutedEventArgs e)
        {
            //UserViewModel user = new UserViewModel();
            //user.Login = UserLogin.Text;
            //user.Email = UserEmail.Text;
            //user.Password = UserPassword.Text;
            //IUserProvider userProvider = new UserProvider();
            //userProvider.UserRegistration(user);
        }


        private void CTable_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            MessageBox.Show(selectedItem.Text);
            switch (selectedItem.Text)
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
