using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAuction.Model;

namespace WpfAuction.ViewModel
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {

        private Logger currentUser;
        private string loginLabel;
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

        public LoginWindowViewModel(Logger user, string loginLabel)
        {
            CurrentUser = user;
            LoginLabel = loginLabel;
        }

        public bool CheckLog(string username, string pass)
        {
            CurrentUser = WpfAuction.Model.Logger.FindLogUser(username, pass);
            
            if (CurrentUser == null)
            {
                return false;
            }

            else
            {
                return true;
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
