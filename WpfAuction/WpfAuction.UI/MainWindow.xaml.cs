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
using WpfAuction.ViewModel;
using WpfAuction.Model;

namespace WpfAuction.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AuctionTimer.ProductTimer();
            MainWindowViewModel mainViewModel = new MainWindowViewModel();
            this.DataContext = mainViewModel;
            AdminButtons.IsEnabled = false;
        }

        public MainWindow(Logger user, string label)
        {
            InitializeComponent();
            MainWindowViewModel mainViewModel = new MainWindowViewModel(MyMediator.Instance, user, label);
            this.DataContext = mainViewModel;
            mainViewModel.CurrentUser = user;
            mainViewModel.LoginLabel = label;
            AdminButtons.IsEnabled = mainViewModel.CurrentUser.IsAdmin;
        }

        private void loginBttn_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = (MainWindowViewModel)DataContext;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.DataContext = new LoginWindowViewModel(viewModel.CurrentUser, viewModel.LoginLabel);
            loginWindow.Show();
            this.Close();
        }

        private void bidBttn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bttnInsert_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow productWin = new ProductWindow();
            productWin.DataContext = new ProductWindowViewModel(MyMediator.Instance);
            productWin.ShowDialog();
        }

        private void bttnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
