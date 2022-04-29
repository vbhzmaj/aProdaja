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

namespace WpfAuction.Model
{
    public class Logger : INotifyPropertyChanged 
    {
        #region Fields

        private int id;
        private string userName;
        private string userPass;
        private bool isAdmin;

        #endregion

        #region Properties
        public int Id
        {
            get { return id; }
            set
            {
                if (id == value)
                {
                    return;
                }
                id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }
        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName == value)
                {
                    return;
                }
                userName = value;

                OnPropertyChanged(new PropertyChangedEventArgs("UserName"));
            }
        }
        public string UserPass
        {
            get { return userPass; }
            set
            {
                if (userPass == value)
                {
                    return;
                }
                userPass = value;

               OnPropertyChanged(new PropertyChangedEventArgs("UserPass"));
            }
        }
        public bool IsAdmin
        {
            get { return isAdmin; }

            set
            {
                if (isAdmin == value)
                {
                    return;
                }
                isAdmin = value;

                OnPropertyChanged(new PropertyChangedEventArgs("IsAdmin"));
            }
        }

        #endregion

        #region Constructor
        public Logger(string userName, string userPass, bool isAdmin)
        {
            this.UserName = userName;
            this.UserPass = userPass;
            this.IsAdmin = isAdmin;

        }

        public Logger(int id, string userName, string userPass, bool isAdmin)
        {
            this.UserName = userName;
            this.UserPass = userPass;
            this.IsAdmin = isAdmin;
            this.id = id;
        }

        public Logger()
        {
            UserName = "";
            UserPass = "";
            IsAdmin = false;
        }



        #endregion

        #region Data Access
        public static Logger FindLogUser(string username, string pass)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Users2", conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Logger logUser = new Logger
                                {
                                    id = reader.GetInt32(0),
                                    userName = reader.GetString(1),
                                    userPass = Decrypt(reader.GetString(2), "my_Crypto_EncDec"),
                                    isAdmin = reader.GetBoolean(3)
                                };

                                if (username == logUser.userName && pass == logUser.userPass)
                                {
                                    return logUser;
                                }
                            }
                        }
                        return null;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }
       

        #endregion

        #region converters
        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion

        #region events

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        #endregion

    }
}
