using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAuction.Model
{
    public class ProductCollection : ObservableCollection<Product>
    {
        private static bool isAdmin = false;
        
        public static void setAdmin() {

            isAdmin = true;
        }
        public static ProductCollection GetAllProducts()
        {
            try
            {
                ProductCollection products = new ProductCollection();
                Product product = null;
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString =
                    ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT ProductID, ProductName,  Category, ProductCondition, ActivationDate, ProductPrice, AuctionStatus," +
                        "ProductDescription, AuctionWinner, IsProductSold, LastBidTime  FROM Products WHERE AuctionStatus<2", conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product = Product.GetProductFromResultSet(reader);

                            if (product.AuctionStatus == 0)
                            {
                                
                                products.Add(product); 
                            }

                            if(product.AuctionStatus == 1)
                            {
                                if (isAdmin) { products.Add(product); }
                            }
                        }
                    }
                }
                return products;
            }
            catch (global::System.Exception)
            {
                throw;
            }

        }
    }
}
