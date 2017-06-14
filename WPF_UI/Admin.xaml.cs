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

namespace WPF_UI
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private Message messWindow;
        private MainWindow main;
        public Admin()
        {
            InitializeComponent();
        }

        private void BtnAuthorAdd_OnClick(object sender, RoutedEventArgs e)
        {
            string name = AuthorName.Text;
            string surname = AuthorLastName.Text;
            messWindow=new Message(name+" "+surname+" was added");
            messWindow.Show();
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
    }
}
