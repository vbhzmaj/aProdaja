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

namespace WpfAuction.UI
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProductWindowViewModel viewModel = (ProductWindowViewModel)DataContext;
            viewModel.Saved += ViewModel_Saved; 
        }

        private void ViewModel_Saved(object sender, ProductWindowViewModel.SavedEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        private void BttnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BttnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}
