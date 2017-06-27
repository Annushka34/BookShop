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
        public string DelImagePath { get; set; }
        public string PlusImagePath { get; set; }
        public string MinusImagePath { get; set; }
        string localPath = new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Images")).LocalPath;
        MainWindow _mainWindow;
        
        public Basket()
        {
            InitializeComponent();
            DelImagePath = localPath + "/delete-icon.png";
            PlusImagePath = localPath + "/add.png";
            MinusImagePath = localPath + "/minus.png";
            DataContext = this;
        }

        public Basket(MainWindow mainWindow,int customerId)
        {
            InitializeComponent();
            DelImagePath = localPath + "/delete-icon.png";
            PlusImagePath = localPath + "/add.png";
            MinusImagePath = localPath + "/minus.png";
            _mainWindow = mainWindow;

            DataContext = this;
        }

        private void BConfirm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
            _mainWindow.Show();
        }
    }
}
