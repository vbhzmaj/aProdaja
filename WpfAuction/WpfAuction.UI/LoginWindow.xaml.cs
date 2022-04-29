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
using WpfAuction.Model;
using WpfAuction.ViewModel;


namespace WpfAuction.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
   
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BttnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindowViewModel viewModelLog = (LoginWindowViewModel)DataContext;

            Boolean checkInput;


            checkInput = viewModelLog.CheckLog(TextBoxAddUsername.Text.ToString().Trim(),
                                  Typepass.Password.ToString().Trim());

            if (checkInput)
            {
                if (viewModelLog.CurrentUser.IsAdmin == true)
                {
                    ProductCollection.setAdmin();
                    viewModelLog.LoginLabel = " " + viewModelLog.CurrentUser.UserName + "  logged in as an admin.";
                    MainWindow adminWindow = new MainWindow(viewModelLog.CurrentUser, viewModelLog.LoginLabel);
                    adminWindow.Show();
                    this.Close();
                }

                else 
                {
                    viewModelLog.LoginLabel = " " + viewModelLog.CurrentUser.UserName + "  logged in.";
                    MainWindow newMainWindow = new MainWindow(viewModelLog.CurrentUser, viewModelLog.LoginLabel);
                    newMainWindow.Show();
                    this.Close(); 
                }
            }
            else
            {
                MessageBox.Show("Login failed. Please try again.");
            }
        }

        private void BttnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new MainWindowViewModel();
            mainWindow.Show();
            this.Close();
        }
    }
}
