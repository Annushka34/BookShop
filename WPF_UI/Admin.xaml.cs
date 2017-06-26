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
        private IGeneralProvider generalProvider;
        public Admin()
        {
            InitializeComponent();
            tableSelected = "";
            generalProvider = new GeneralProvider();
        }




        //private void CTable_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ComboBox comboBox = (ComboBox)sender;
        //    TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
        //    tableSelected = selectedItem.Text;
        //}
        private void CTableExisting_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SPTable.Visibility=Visibility.Collapsed;
            this.Height = 400;
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            tableSelected = selectedItem.Text;
            switch (tableSelected)
            {
                case "Admin":
                {
                        UserProvider userProvider = new UserProvider();
                        var table = userProvider.GetAllUsers();
                        DataGridSelectedTable.ItemsSource = table;
                        break;
                    }
                case "Author":
                    {
                        var table = generalProvider.GetAllAuthorsNames();
                        DataGridSelectedTable.ItemsSource = table;
                        break;
                    }
                case "Category":
                    {
                        var table = generalProvider.GetAllCategoriesNames();
                        DataGridSelectedTable.ItemsSource = table;
                        break;
                    }
                case "Book":
                    {
                        IBookProvider bookProvider=new BookProvider();
                        var table = bookProvider.GetAllBooks();
                        DataGridSelectedTable.ItemsSource = table;
                        break;
                    }
                case "Publish":
                    {
                        var table = generalProvider.GetAllPublishNames();
                        DataGridSelectedTable.ItemsSource = table;
                        break;
                    }
                case "Tag":
                    {
                        var table = generalProvider.GetAllTagsNames();
                        DataGridSelectedTable.ItemsSource = table;
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
            SetVisible(BtnAddToDataBase);
            switch (tableSelected)
            {
                case "Admin":
                    {
                        SetHiddenAll();
                        Label1.Content = "Email";
                        Label2.Content = "Login";
                        Label8.Content = "Password";

                        SetVisible(TextBox1);
                        SetVisible(TextBox2);
                        SetVisible(PasswordBox8);
                        SetVisible(Label1);
                        SetVisible(Label2);
                        SetVisible(Label8);
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
                        Label2.Content = "SelectBooks";

                        CheckBox checkBox = new CheckBox();
                        checkBox.Content = "book 1";
                        ComboBox3.Items.Add(checkBox);
                        CheckBox checkBox1 = new CheckBox();
                        checkBox1.Content = "book 2";
                        ComboBox3.Items.Add(checkBox1);

                        SetVisible(Label1);
                        SetVisible(Label2);
                        SetVisible(TextBox1);
                        SetVisible(ComboBox2);
                        break;
                    }
                case "Book":
                    {
                        SetHiddenAll();
                        Label1.Content = "Book name";
                        Label2.Content = "ISBN";
                        Label3.Content = "Description";
                        Label4.Content = "Select price";
                        Label5.Content = "Select publish";
                        Label6.Content = "Select category";
                        Label7.Content = "Select author";
                        Label9.Content = "Select picture";

                        CheckBox checkBox1 = new CheckBox();
                        checkBox1.Content = "Author 1";
                        ComboBox2.Items.Add(checkBox1);
                        CheckBox checkBox2 = new CheckBox();
                        checkBox2.Content = "Author 2";
                        ComboBox2.Items.Add(checkBox2);

                       
                        var categories = generalProvider.GetAllCategoriesNames();
                        foreach (var category in categories)
                        {
                            CheckBox checkBox = new CheckBox();
                            checkBox.Content = category.CategoryName;
                            ComboBox2.Items.Add(checkBox);
                        }


                        SetVisible(Label1);
                        SetVisible(Label2);
                        SetVisible(Label3);
                        SetVisible(Label4);
                        SetVisible(Label5);
                        SetVisible(Label6);
                        SetVisible(Label7);
                        SetVisible(Label9);
                        SetVisible(TextBox1);
                        SetVisible(TextBox2);
                        SetVisible(TextBox3);
                        SetVisible(TextBox4);
                        SetVisible(ComboBox5);
                        SetVisible(ComboBox6);
                        SetVisible(ComboBox7);
                        IPicture.Visibility=Visibility.Visible;
                        this.Height = 700;
                        break;
                    }
                case "Publish":
                    {
                        SetHiddenAll();
                        Label1.Content = "Publish name";
                        Label2.Content = "Select books";

                        CheckBox checkBox = new CheckBox();
                        checkBox.Content = "book 1";
                        ComboBox3.Items.Add(checkBox);
                        CheckBox checkBox1 = new CheckBox();
                        checkBox1.Content = "book 2";
                        ComboBox3.Items.Add(checkBox1);

                        SetVisible(Label1);
                        SetVisible(Label2);
                        SetVisible(TextBox1);
                        SetVisible(ComboBox2);
                        break;
                    }
                case "Tag":
                    {
                        SetHiddenAll();
                        Label1.Content = "Tag";
                        Label2.Content = "Select books";

                        CheckBox checkBox = new CheckBox();
                        checkBox.Content = "book 1";
                        ComboBox2.Items.Add(checkBox);
                        CheckBox checkBox1 = new CheckBox();
                        checkBox1.Content = "book 2";
                        ComboBox2.Items.Add(checkBox1);

                        SetVisible(Label1);
                        SetVisible(Label2);
                        SetVisible(TextBox1);
                        SetVisible(ComboBox2);
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
                        user.Password = PasswordBox8.Password;
                        user.Role = UserRole.Admin;
                        IUserProvider userProvider = new UserProvider();
                        userProvider.UserRegistration(user);
                        break;
                    }
                case "Author":
                    {
                        AuthorViewModel author = new AuthorViewModel();
                        author.FirstName = TextBox1.Text;
                        author.FirstName = TextBox2.Text;
                        generalProvider.CreateNewAuthor(author);
                        break;
                    }
                case "Category":
                    {
                        CategoryViewModel category = new CategoryViewModel();
                        category.CategoryName = TextBox1.Text;
                        generalProvider.CreateNewCategory(category);
                        break;
                    }
                case "Book":
                    {
                        BookCreateViewModel book=new BookCreateViewModel();
                        book.Name = TextBox1.Text;
                        int num = 0;
                        int.TryParse(TextBox2.Text, out num);
                        book.Isbn = num;
                        book.Description = TextBox3.Text;
                        int.TryParse(TextBox4.Text, out num);
                        book.Price = num;
                        //book.PublishId;
                        break;
                    }
                case "Publish":
                    {
                        PublishViewModel publish = new PublishViewModel();
                        publish.PublishName = TextBox1.Text;
                        generalProvider.CreateNewPublish(publish);
                        break;
                    }
                case "Tag":
                    {
                        TagViewModel tag = new TagViewModel();
                        tag.TagName = TextBox1.Text;
                        generalProvider.CreateNewTag(tag);
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
            Label6.Visibility = Visibility.Collapsed;
            Label7.Visibility = Visibility.Collapsed;
            Label8.Visibility = Visibility.Collapsed;
            Label9.Visibility = Visibility.Collapsed;
            TextBox1.Visibility = Visibility.Collapsed;
            TextBox2.Visibility = Visibility.Collapsed;
            TextBox3.Visibility = Visibility.Collapsed;
            TextBox4.Visibility = Visibility.Collapsed;
            TextBox5.Visibility = Visibility.Collapsed;
            TextBox6.Visibility = Visibility.Collapsed;
            TextBox7.Visibility = Visibility.Collapsed;
            ComboBox1.Visibility = Visibility.Collapsed;
            ComboBox2.Visibility = Visibility.Collapsed;
            ComboBox3.Visibility = Visibility.Collapsed;
            ComboBox4.Visibility = Visibility.Collapsed;
            ComboBox5.Visibility = Visibility.Collapsed;
            ComboBox6.Visibility = Visibility.Collapsed;
            ComboBox7.Visibility = Visibility.Collapsed;
            PasswordBox8.Visibility = Visibility.Collapsed;
            PasswordBox8.Password = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            Label1.Content="";
            Label2.Content = "";
            Label3.Content = "";
            Label4.Content = "";
            Label5.Content = "";
            Label6.Content = "";
            Label7.Content = "";
            Label8.Content = "";
            Label9.Content = "";
            ComboBox1.Items.Clear();
            ComboBox2.Items.Clear();
            ComboBox3.Items.Clear();
            ComboBox4.Items.Clear();
            ComboBox5.Items.Clear();
            ComboBox6.Items.Clear();
            ComboBox7.Items.Clear();
            PasswordBox8.Password = "";
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
