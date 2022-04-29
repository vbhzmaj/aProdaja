using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfAuction.Model
{
    public class Product : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region Fields

        private int productId;
        private string productName;
        private string category;
        private string productCondition; //allowed values are "new" and "used"
        private DateTime activationDate;
        private decimal productPrice;
        private int auctionStatus; //0 means open, 1 means closed, 2 means archived
        private int remainingTime;
        private string productDescription;
        private string auctionWinner;
        private bool isProductSold;
        private string remainingTimeS;
        private string priceLabel = "Highest bid";
        private string winnerLabel = "Auction leader";
        private DateTime lastBidTime;

        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        #endregion

        #region Properties
        public int ProductId
        {
            get { return productId; }
            set
            {
                if (productId == value)
                {
                    return;
                }
                productId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProductId"));
            }
        }
        public string ProductName
        {
            get { return productName; }
            set
            {
                if (productName == value)
                {
                    return;
                }
                productName = value;

                List<string> errors = new List<string>();
                bool valid = true;

                if (value == null || value == "")
                {
                    errors.Add("Product name cannot be empty.");
                    SetErrors("ProductName", errors);
                    valid = false;
                }

                if (!Regex.Match(value, @"^[- a-zA-Z_0-9]+$").Success)
                {
                    errors.Add("Product name contains not allowed character.");
                    SetErrors("ProductName", errors);
                    valid = false;
                }

                if (value.Length < 3)
                {
                    errors.Add("Product name cannot be shorter than 3 characters.");
                    SetErrors("ProductName", errors);
                    valid = false;
                }

                if (value.Length > 50)
                {
                    errors.Add("Product name cannot be longer than 50 characters.");
                    SetErrors("ProductName", errors);
                    valid = false;
                }

                if (valid)
                {
                    ClearErrors("ProductName");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("ProductName"));
            }
        }
        public string Category
        {
            get { return category; }
            set
            {
                if (category == value)
                {
                    return;
                }
                category = value;

                List<string> errors = new List<string>();
                bool valid = true;

                if (value == null || value == "")
                {
                    errors.Add("Category cannot be empty.");
                    SetErrors("Category", errors);
                    valid = false;
                }


                if (!Regex.Match(value, @"^[a-zA-Z_0-9]+$").Success)
                {
                    errors.Add("Category can only contain letters, numbers and underscore.");
                    SetErrors("Category", errors);
                    valid = false;
                }

                if (value.Length < 3)
                {
                    errors.Add("Category cannot be shorter than 3 characters.");
                    SetErrors("Category", errors);
                    valid = false;
                }

                if (value.Length > 50)
                {
                    errors.Add("Category cannot be longer than 50 characters.");
                    SetErrors("Category", errors);
                    valid = false;
                }

                if (valid)
                {
                    ClearErrors("Category");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("Category"));
            }
        }
        public string ProductCondition
        {
            get { return productCondition; }
            set
            {
                if (productCondition == value)
                {
                    return;
                }
                productCondition = value;
                List<string> errors = new List<string>();
                bool valid = true;

               
                if(value.Length ==3)
                {
                    if (!value.Equals("new"))
                        {
                            errors.Add("Allowed entries for product condition are: new used");
                            SetErrors("ProductCondition", errors);
                            valid = false;
                        }
                }

                if (value.Length == 4)
                {
                    if (!value.Equals("used"))
                    {
                        errors.Add("Allowed entries for product condition are: new used");
                        SetErrors("ProductCondition", errors);
                        valid = false;
                    }
                }

                if (value.Length > 4 || value.Length < 3)
                {
                    errors.Add("Allowed entries for product condition are: new used");
                    SetErrors("ProductCondition", errors);
                    valid = false;
                }

               

                if (valid)
                {
                    ClearErrors("ProductCondition");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("ProductCondition"));
            }
        }
        public DateTime ActivationDate
        {
            get { return activationDate; }
            set
            {
                if (activationDate == value)
                {
                    return;
                }
                activationDate = value;

                OnPropertyChanged(new PropertyChangedEventArgs("ActivationDate"));
            }
        }
        public decimal ProductPrice
        {
            get { return productPrice; }
            set
            {
                if (productPrice == value)
                {
                    return;
                }
                productPrice = value;
                List<string> errors = new List<string>();
                bool valid = true;
                
                if (!decimal.TryParse(value.ToString(), out decimal price))
                {
                    errors.Add("Your entry is not a valid decimal number.");
                    SetErrors("ProductPrice", errors);
                    valid = false;
                }

                if (valid)
                {
                    ClearErrors("ProductPrice");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("ProductPrice"));
            }
        }
        public int AuctionStatus
        {
            get { return auctionStatus; }
            set
            {
                if (auctionStatus == value)
                {
                    return;
                }
                auctionStatus = value;

                OnPropertyChanged(new PropertyChangedEventArgs("AuctionStatus"));
            }
        }
        public int RemainingTime
        {
            get { return remainingTime; }
            set
            {
                if (remainingTime == value)
                {
                    return;
                }
                remainingTime = value;

                OnPropertyChanged(new PropertyChangedEventArgs("RemainingTime"));
            }
         }
        public string ProductDescription
        {
            get { return productDescription; }
            set
            {
                if (productDescription == value)
                {
                    return;
                }
                productDescription = value;
                List<string> errors = new List<string>();
                bool valid = true;

                if (value == null || value == "")
                {
                    errors.Add("Product description cannot be empty.");
                    SetErrors("ProductDescription", errors);
                    valid = false;
                }

                if (!Regex.Match(value, @"^[a-zA-Z_0-9., -]+$").Success)
                {
                    errors.Add("Product description contains prohibited characters(s).");
                    SetErrors("ProductDescription", errors);
                    valid = false;
                }

                if (value.Length < 20)
                {
                    errors.Add("Product description cannot be shorter than 20 characters.");
                    SetErrors("ProductDescription", errors);
                    valid = false;
                }

                if (value.Length > 500)
                {
                    errors.Add("Product description cannot be longer than 500 characters.");
                    SetErrors("ProductDescription", errors);
                    valid = false;
                }

                if (valid)
                {
                    ClearErrors("ProductDescription");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("ProductDescription"));
            }
        }
        public string AuctionWinner
        {
            get { return auctionWinner; }
            set
            {
                if (auctionWinner == value)
                {
                    return;
                }
                auctionWinner = value;

                OnPropertyChanged(new PropertyChangedEventArgs("AuctionWinner"));
            }
        }
        public bool IsProductSold
        {
            get { return isProductSold; }
            set
            {
                if (isProductSold == value)
                {
                    return;
                }
                isProductSold = value;

                OnPropertyChanged(new PropertyChangedEventArgs("IsProductSold"));
            }
        }
        public string RemainingTimeS
        {
            get { return remainingTimeS; }
            set
            {
                if (remainingTimeS == value)
                {
                    return;
                }
                remainingTimeS = value;

                OnPropertyChanged(new PropertyChangedEventArgs("RemainingTimeS"));
            }
        }
        public string PriceLabel
        {
            get { return priceLabel; }
            set
            {
                if (priceLabel == value)
                {
                    return;
                }
                priceLabel = value;

                OnPropertyChanged(new PropertyChangedEventArgs("PriceLabel"));
            }
        }
        public string WinnerLabel
        {
            get { return winnerLabel; }
            set
            {
                if (winnerLabel == value)
                {
                    return;
                }
                winnerLabel = value;

                OnPropertyChanged(new PropertyChangedEventArgs("WinnerLabel"));
            }
        }

        public DateTime LastBidTime
        {
            get { return lastBidTime; }
            set
            {
                if (lastBidTime == value)
                {
                    return;
                }
                lastBidTime = value;

                OnPropertyChanged(new PropertyChangedEventArgs("LastBidTime"));
            }
        }
        #endregion

        #region Constructors and Methods
        public Product(string productName, string category, string productCondition, DateTime activationDate, 
            decimal productPrice, int auctionStatus, string productDescription, string auctionWinner, bool isProductSold, DateTime lastBidTime)
        {
            this.ProductName = productName;
            this.Category = category;
            this.ProductCondition = productCondition;
            this.ActivationDate = activationDate;
            this.ProductPrice = productPrice;
            this.AuctionStatus = auctionStatus;
            this.ProductDescription = productDescription;
            this.AuctionWinner = auctionWinner;
            this.IsProductSold = isProductSold;
            this.LastBidTime = lastBidTime;

        }

        public Product(int productID, string productName, string category, string productCondition, DateTime activationDate,
            decimal productPrice, int auctionStatus, string productDescription, string auctionWinner, bool isProductSold, DateTime lastBidTime)
        {
            this.ProductId = productID;
            this.ProductName = productName;
            this.Category = category;
            this.ProductCondition = productCondition;
            this.ActivationDate = activationDate;
            this.ProductPrice = productPrice;
            this.AuctionStatus = auctionStatus;
            this.ProductDescription = productDescription;
            this.AuctionWinner = auctionWinner;
            this.IsProductSold = isProductSold;
            this.LastBidTime = lastBidTime;

        }

        public Product()
        {
            ProductName = "";
            Category = "";
            ProductPrice =(decimal)1.00;
            ProductCondition ="new";
            RemainingTime = 120;
            AuctionWinner = "None";
            IsProductSold = false;
            ProductDescription = "No details available.";
            ActivationDate = DateTime.Now;
            AuctionStatus = 0;
            RemainingTimeS = "02 min  00 sec";
            PriceLabel = "Highest bid";
            WinnerLabel = "Auction leader";
            LastBidTime = DateTime.Now;

        }

        

        #endregion

        #region Data Access
        public static Product GetProductFromResultSet(SqlDataReader reader)
        {


            Product product = new Product((int)reader["ProductID"], (string)reader["ProductName"], (string)reader["Category"], (string)reader["ProductCondition"], 
                 (DateTime)reader["ActivationDate"], (decimal)reader["ProductPrice"], (int)reader["AuctionStatus"], 
                 (string)reader["ProductDescription"], (string)reader["AuctionWinner"], (bool)reader["IsProductSold"], (DateTime)reader["LastBidTime"]);
            TimeSpan time = (DateTime.Now - product.LastBidTime);
            Console.WriteLine(product.productName + "  time = " + time);
            double seconds = time.TotalSeconds;
            Console.WriteLine("a to je " + seconds + " sekundi");
            if (seconds < 120)
            {
                product.RemainingTime = 120 - (int)seconds;
                AuctionTimer.ProductTimerSubscribe(product); 
            }
            else
            {
                product.RemainingTime = 0;
                product.RemainingTimeS = "00 min  00 sec";
                product.auctionStatus = 1;
                product.PriceLabel = "Selling price";
                product.WinnerLabel = "Auction winner";
            }

            return product;
        }
        public bool Update()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                    conn.Open();

                    SqlCommand command = new SqlCommand("UPDATE Products SET ProductName=@ProductName, Category=@Category," +
                        "ProductCondition=@ProductCondition, ActivationDate=@ActivationDate, ProductPrice=@ProductPrice," +
                        "AuctionStatus=@AuctionStatus, ProductDescription=@ProductDescription," +
                        "AuctionWinner=@AuctionWinner, IsProductSold=@IsProductSold, LastBidTime=@LastBidTime WHERE ProductID=@Id", conn);

                    SqlParameter ProductNameParam = new SqlParameter("@ProductName", SqlDbType.NVarChar);
                    ProductNameParam.Value = this.ProductName;

                    SqlParameter CategoryParam = new SqlParameter("@Category", SqlDbType.NVarChar);
                    CategoryParam.Value = this.Category;

                    SqlParameter ProductConditionParam = new SqlParameter("@ProductCondition", SqlDbType.NVarChar);
                    ProductConditionParam.Value = this.ProductCondition;

                    SqlParameter ActivationDateParam = new SqlParameter("@ActivationDate", SqlDbType.DateTime);
                    ActivationDateParam.Value = this.ActivationDate;

                    SqlParameter ProductPriceParam = new SqlParameter("@ProductPrice", SqlDbType.Int, 1);
                    ProductPriceParam.Value = this.ProductPrice;

                    SqlParameter AuctionStatusParam = new SqlParameter("@AuctionStatus", SqlDbType.Int, 1);
                    AuctionStatusParam.Value = this.AuctionStatus;

                    SqlParameter ProductDescriptionParam = new SqlParameter("@ProductDescription", SqlDbType.NVarChar);
                    ProductDescriptionParam.Value = this.ProductDescription;

                    SqlParameter AuctionWinnerParam = new SqlParameter("@AuctionWinner", SqlDbType.NVarChar);
                    AuctionWinnerParam.Value = this.AuctionWinner;

                    SqlParameter IsProductSoldParam = new SqlParameter("@IsProductSold", SqlDbType.Bit, 1);
                    IsProductSoldParam.Value = this.IsProductSold;

                    SqlParameter LastBidTimeParam = new SqlParameter("@LastBidTime", SqlDbType.DateTime);
                    LastBidTimeParam.Value = this.LastBidTime;

                    SqlParameter myParam = new SqlParameter("@Id", SqlDbType.Int, 11);
                    myParam.Value = this.ProductId;

                    command.Parameters.Add(ProductNameParam);
                    command.Parameters.Add(CategoryParam);
                    command.Parameters.Add(ProductConditionParam);
                    command.Parameters.Add(ActivationDateParam);
                    command.Parameters.Add(ProductPriceParam);
                    command.Parameters.Add(AuctionStatusParam);
                    command.Parameters.Add(ProductDescriptionParam);
                    command.Parameters.Add(AuctionWinnerParam);
                    command.Parameters.Add(IsProductSoldParam);
                    command.Parameters.Add(LastBidTimeParam);
                    command.Parameters.Add(myParam);

                    int rows = command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Insert()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                    conn.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO Products(ProductName, Category, ProductCondition, " +
                        "ActivationDate, ProductPrice, AuctionStatus, ProductDescription, AuctionWinner, " +
                        "IsProductSold, LastBidTime) VALUES(@ProductName, @Category, @ProductCondition, @ActivationDate, @ProductPrice, " +
                        "@AuctionStatus, @ProductDescription, @AuctionWinner, @IsProductSold, @LastBidTime); SELECT IDENT_CURRENT('Products');", conn);

                    SqlParameter ProductNameParam = new SqlParameter("@ProductName", SqlDbType.NVarChar);
                    ProductNameParam.Value = this.ProductName;

                    SqlParameter CategoryParam = new SqlParameter("@Category", SqlDbType.NVarChar);
                    CategoryParam.Value = this.Category;

                    SqlParameter ProductConditionParam = new SqlParameter("@ProductCondition", SqlDbType.NVarChar);
                    ProductConditionParam.Value = this.ProductCondition;

                    SqlParameter ActivationDateParam = new SqlParameter("@ActivationDate", SqlDbType.DateTime);
                    ActivationDateParam.Value = this.ActivationDate;

                    SqlParameter ProductPriceParam = new SqlParameter("@ProductPrice", SqlDbType.Int,1);
                    ProductPriceParam.Value = this.ProductPrice;

                    SqlParameter AuctionStatusParam = new SqlParameter("@AuctionStatus", SqlDbType.Int, 1);
                    AuctionStatusParam.Value = this.AuctionStatus;

                    SqlParameter ProductDescriptionParam = new SqlParameter("@ProductDescription", SqlDbType.NVarChar);
                    ProductDescriptionParam.Value = this.ProductDescription;

                    SqlParameter AuctionWinnerParam = new SqlParameter("@AuctionWinner", SqlDbType.NVarChar);
                    AuctionWinnerParam.Value = this.AuctionWinner;

                    SqlParameter IsProductSoldParam = new SqlParameter("@IsProductSold", SqlDbType.Bit, 1);
                    IsProductSoldParam.Value = this.IsProductSold;

                    SqlParameter LastBidTimeParam = new SqlParameter("@LastBidTime", SqlDbType.DateTime);
                    LastBidTimeParam.Value = this.LastBidTime;

                    command.Parameters.Add(ProductNameParam);
                    command.Parameters.Add(CategoryParam);
                    command.Parameters.Add(ProductConditionParam);
                    command.Parameters.Add(ActivationDateParam);
                    command.Parameters.Add(ProductPriceParam);
                    command.Parameters.Add(AuctionStatusParam);
                    command.Parameters.Add(ProductDescriptionParam);
                    command.Parameters.Add(AuctionWinnerParam);
                    command.Parameters.Add(IsProductSoldParam);
                    command.Parameters.Add(LastBidTimeParam);

                    var id = command.ExecuteScalar();

                if (id != null)
                    {
                        this.ProductId = Convert.ToInt32(id);
                    }
                    return true;
                }
        }
            catch (Exception)
            {

                return false;
            }

}
        public bool DeleteAuction()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {

                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                    conn.Open();

                    SqlCommand command = new SqlCommand("UPDATE Products SET AuctionStatus=2 WHERE ProductID=@Id", conn);

                    SqlParameter myParam = new SqlParameter("@Id", SqlDbType.Int, 1);
                    myParam.Value = this.ProductId;

                    command.Parameters.Add(myParam);

                    int rows = command.ExecuteNonQuery();
                    Console.WriteLine("int rows odgovor iz baze je " + rows);
                    Console.WriteLine("id " + this.ProductId);



                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
                
             
            
        }

        //public void RepeatAuction()
        //{
        //    using (SqlConnection conn = new SqlConnection())
        //    {

        //        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
        //        conn.Open();

        //        SqlCommand command = new SqlCommand("UPDATE Products SET AuctionStatus=0 WHERE ProductID=@Id", conn);

        //        SqlParameter myParam = new SqlParameter("@Id", SqlDbType.Int, 1);
        //        myParam.Value = this.ProductId;

        //        command.Parameters.Add(myParam);

        //        int rows = command.ExecuteNonQuery();

        //    }
        //}

        #endregion

        #region error manipulation

        private void SetErrors(string propertyName, List<string> propertyErrors)
        {
            errors.Remove(propertyName);
            errors.Add(propertyName, propertyErrors);
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private void ClearErrors(string propertyName)
        {
            errors.Remove(propertyName);
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        public bool HasErrors
        {
            get
            {
                return (errors.Count > 0);
            }
        }
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return (errors.Values);
            }
            else
            {
                if (errors.ContainsKey(propertyName))
                {
                    return (errors[propertyName]);
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region converters
        
        #endregion

        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        public void Auction_Tick(object sender, EventArgs e)
        {

            RemainingTime--;
            RemainingTimeS = (RemainingTime / 60).ToString() + " min  " + (RemainingTime % 60).ToString() + " sec";

            if (RemainingTime < 1)
            {
                AuctionTimer.ProductTimerUnsubscribe(this);
                this.auctionStatus = 1;
                this.WinnerLabel = "Auction winner";
                this.PriceLabel = "Selling price";
                this.Update();
            }
        }
        #endregion 

    }
}
