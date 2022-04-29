using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAuction.Model;
using System.Windows.Data;
using System.Windows.Input;

namespace WpfAuction.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string loginLabel;
        private Logger currentUser;
        private Product currentProduct;
        private ProductCollection productList;
        private ListCollectionView productListView;
        private string filteringText;
        private MyMediator mediator;

        #endregion

        #region Properties

        public Logger CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (currentUser == value)
                {
                    return;
                }
                currentUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentUser"));
            }
        }

        public Product CurrentProduct
        {
            get { return currentProduct; }
            set
            {
                if (currentProduct == value)
                {
                    return;
                }
                currentProduct = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentProduct"));
            }
        }
        public ProductCollection ProductList
        {
            get { return productList; }
            set
            {
                if (productList == value)
                {
                    return;
                }
                productList = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProductList"));
            }
        }

        public ListCollectionView ProductListView
        {
            get { return productListView; }
            set
            {
                if (productListView == value)
                {
                    return;
                }
                productListView = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProductListView"));
            }
        }

        public String FilteringText
        {
            get { return filteringText; }
            set
            {
                if (filteringText == value)
                {
                    return;
                }
                filteringText = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FilteringText"));
            }
        }

        public string LoginLabel
        {
            get { return loginLabel; }
            set
            {
                if (loginLabel == value)
                {
                    return;
                }
                loginLabel = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LoginLabel"));
            }
        }

        #endregion

        #region Commands
        private ICommand bidCommand;
        public ICommand BidCommand
        {
            get { return bidCommand; }
            set
            {
                if (bidCommand == value)
                {
                    return;
                }
                bidCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("BidCommand"));
            }
        }
        
        private ICommand loginCommand; 
        public ICommand LoginCommand
        {
            get { return loginCommand; }
            set
            {
                if (loginCommand == value)
                {
                    return;
                }
                loginCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LoginCommand"));
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get { return deleteCommand; }
            set
            {
                if (deleteCommand == value)
                {
                    return;
                }
                deleteCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DeleteCommand"));
            }
        }
        void BidExecute(object obj)
        {
            CurrentProduct.RemainingTime = 120;
            CurrentProduct.IsProductSold = true;
            CurrentProduct.AuctionWinner = CurrentUser.UserName;
            CurrentProduct.ProductPrice++;
            CurrentProduct.LastBidTime = DateTime.Now;
            //CurrentProduct
            CurrentProduct.Update();
            CurrentProduct.RemainingTimeS = (CurrentProduct.RemainingTime / 60).ToString() + " min  " + (CurrentProduct.RemainingTime % 60).ToString() + " sec";
            //AuctionTimer.ProductTimerSubscribe(CurrentProduct); ;
            
            
        }
        bool CanBid(object obj)
        {
            if (CurrentUser == null) return false;
            if (CurrentProduct == null) return false;
            if (CurrentProduct.AuctionWinner == CurrentUser.UserName) return false;
            if (CurrentProduct.AuctionStatus > 0) return false;
            if (CurrentUser.IsAdmin == true) return false;

            return true;
        }
        void LoginExecute (object obj)
        {

            

        }
        bool CanLogin (object obj)
        { 
            if (CurrentUser == null) return true;

            return false;
        }
        void DeleteExecute(object obj)
        {
            CurrentProduct.DeleteAuction();

            ProductList.Remove(CurrentProduct);
            
        }
        bool CanDelete(object obj)
        {

            if (CurrentProduct == null) return false;

            return true;
        }

        #endregion

        #region Constructors and Methods

        public MainWindowViewModel()
        {
            
            LoginCommand = new RelayCommand(LoginExecute, CanLogin);
            BidCommand = new RelayCommand(BidExecute, CanBid);

            this.PropertyChanged += MainWindowViewModel_PropertyChanged;

            ProductList = ProductCollection.GetAllProducts();
            ProductListView = new ListCollectionView(ProductList);
            ProductListView.Filter = ProductFilter;
                   
            CurrentUser = null;
            LoginLabel = "Log in to participate in auction!";
        }
        public MainWindowViewModel(MyMediator mediator, Logger user, string label)
        {
            this.mediator = mediator;
            LoginCommand = new RelayCommand(LoginExecute, CanLogin);
            BidCommand = new RelayCommand(BidExecute, CanBid);
            DeleteCommand = new RelayCommand(DeleteExecute, CanDelete);

            this.PropertyChanged += MainWindowViewModel_PropertyChanged;

            ProductList = ProductCollection.GetAllProducts();
            ProductListView = new ListCollectionView(ProductList);
            ProductListView.Filter = ProductFilter;

            mediator.Register("ProductAdded", ProductAdded);




        }
        private void ProductAdded(object obj)
        {
            Product product = (Product)obj;
            ProductList.Add(product);
            AuctionTimer.ProductTimerSubscribe(product);
        }
        private bool ProductFilter(object obj)
        {
            if (FilteringText == null) return true;
            if (FilteringText.Equals("")) return true;
            Product product = obj as Product;
            return (product.ProductCondition.ToLower().Contains(FilteringText.ToLower()) || product.ProductName.ToLower().Contains(FilteringText.ToLower()));
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        private void MainWindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("FilteringText"))
            {
                ProductListView.Refresh();
            }
        }

    }
}
