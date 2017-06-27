using BLL.ConcreteProviders;
using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        Admin _adminWindow;
        string localPath = new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Images")).LocalPath;
        List<CategoryUIModel> categoriesInfo = new List<CategoryUIModel>();
        List<AuthorUIModel> authorsInfo = new List<AuthorUIModel>();
        List<PublishUIModel> publishesInfo = new List<PublishUIModel>();
        List<TagUIModel> tagsInfo = new List<TagUIModel>();
        //List<BookUIShortModel> booksInfo = new List<BookUIShortModel>();
        ObservableCollection<BookUIShortModel> booksInfo = new ObservableCollection<BookUIShortModel>();
        UserUILoginModel user = new UserUILoginModel();
        UserProvider userProvider = new UserProvider();
        BookProvider bookProvider = new BookProvider();

        public string BasketImagePath { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //BasketImagePath = Directory.GetCurrentDirectory() + "/Image/2772.png";
            BasketImagePath = localPath + "/2772.png";
            
            GeneralProvider generalProvider = new GeneralProvider();
            categoriesInfo = generalProvider.GetAllCategoriesNames();
            CBCategories.ItemsSource = categoriesInfo;
            authorsInfo = generalProvider.GetAllAuthorsNames();
            CBAuthors.ItemsSource = authorsInfo;
            publishesInfo = generalProvider.GetAllPublishNames();
            CBPublishes.ItemsSource = publishesInfo;
            tagsInfo = generalProvider.GetAllTagsNames();
            CBTags.ItemsSource = tagsInfo;
            
            booksInfo = bookProvider.GetAllBooksShortInfo();
            CopyImagePath(booksInfo);

            LBBooks.ItemsSource = booksInfo;
            
            DataContext = this;
        }

        private void Admin_OnClick(object sender, RoutedEventArgs e)
        {
            _adminWindow = new Admin();
            _adminWindow.Show(this);
            this.Hide();
        }

        public void CopyImagePath(ObservableCollection<BookUIShortModel> books)
        {
            for (int i = 0; i < books.Count; i++)
            {
                booksInfo[i].BookImagePath = localPath + booksInfo[i].BookImagePath;
            }
        }

        private void BLogIn_Click(object sender, RoutedEventArgs e)
        {
            LogIn logWindow = new LogIn(this);
            Hide();
            logWindow.ShowDialog();
            user = logWindow.user;
            if (user.IsCustomer)
            {
                BBasket.Visibility = Visibility.Visible;
                BInfo.Visibility = Visibility.Visible;
                BLogOut.Visibility = Visibility.Visible;
                BLogIn.Visibility = Visibility.Hidden;
                BRegistration.Visibility = Visibility.Hidden;
                LLoggedUser.Content = user.UserLogin;
                BasketConter = user.BasketRecordsCount.ToString();
            }
            if(user.IsAdmin)
            {
                BAdmin.Visibility = Visibility.Visible;
            }
        }

        private void BLogOut_Click(object sender, RoutedEventArgs e)
        {
            user = null;
            BBasket.Visibility = Visibility.Hidden;
            BInfo.Visibility = Visibility.Hidden;
            BLogOut.Visibility = Visibility.Hidden;
            BLogIn.Visibility = Visibility.Visible;
            BRegistration.Visibility = Visibility.Visible;
            LLoggedUser.Content = "";
            BAdmin.Visibility = Visibility.Hidden;
        }

        private void BRegistration_Click(object sender, RoutedEventArgs e)
        {
            Registration register = new Registration(this);
            Hide();
            register.Show();
        }
        private void BAddToBasket_Click(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Plese LogIn before buying books");
                return;
            }
            Button button = sender as Button;
            int index = LBBooks.Items.IndexOf(button.DataContext);
            CustomerProvider customerProvider = new CustomerProvider();
            BasksetRecordViewModel basketRecord = new BasksetRecordViewModel(user.UserId, booksInfo[index].BookId, AddOrEditStatus.Add);
            customerProvider.AddBasketRecord(basketRecord);

            BasketConter = userProvider.GetUserBasketRecordsCount(user.UserId).ToString();
        }

        #region BasketConterProperty

        private string _basketConter;
        public string BasketConter
        {
            get { return _basketConter; }
            set
            {
                _basketConter = value;
                OnPropertyChanged("BasketConter");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        private void LBBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBBooks.SelectedIndex == -1)
            {
                return;
            }
            BookDetails bookDetails = new BookDetails();
            bookDetails.ShowDialog();
            LBBooks.SelectedIndex = -1;
        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchViewModel searchModel = new SearchViewModel();
            if (CBCategories.SelectedIndex != -1)
                searchModel.CategoryId = categoriesInfo[CBCategories.SelectedIndex].Id;
            if (CBAuthors.SelectedIndex != -1)
                searchModel.AuthorId = authorsInfo[CBAuthors.SelectedIndex].Id;
            if (CBPublishes.SelectedIndex != -1)
                searchModel.PublishId = publishesInfo[CBPublishes.SelectedIndex].Id;
            if (CBTags.SelectedIndex != -1)
                searchModel.TagId = tagsInfo[CBTags.SelectedIndex].Id;
            searchModel.BookName = TBSearch.Text;
            booksInfo = bookProvider.SearchBooks(searchModel);
            LBBooks.ItemsSource = booksInfo;
        }

        private void BBasket_Click(object sender, RoutedEventArgs e)
        {
            Basket basket = new Basket(this, user.UserId);
            Hide();
            basket.ShowDialog();
        }
    }
}
