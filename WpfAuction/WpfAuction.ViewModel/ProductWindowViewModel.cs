using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAuction.Model;

namespace WpfAuction.ViewModel
{
    public class ProductWindowViewModel : INotifyPropertyChanged
    {
        #region fields

        private MyMediator mediator;
        private Product currentProduct;
        private ICommand saveCommand;
        

        #endregion

        #region properties
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

        public ICommand SaveCommand
        {
            get { return saveCommand; }
            set
            {
                if (saveCommand == value)
                {
                    return;
                }
                saveCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SaveCommand"));
            }
        }


        #endregion

        #region constructors and methods

        public ProductWindowViewModel (MyMediator mediator)
        {
            this.mediator = mediator;
            
            SaveCommand = new RelayCommand(SaveExecute, CanSave);

            CurrentProduct = new Product();
           
        }

        void SaveExecute(object obj)
        {

            if (CurrentProduct != null && !CurrentProduct.HasErrors)
            {
                bool result = CurrentProduct.Insert();
                if (result == false) { OnSave(new SavedEventArgs("Product not saved. Try to modify your input.")); }
                else
                {
                   OnSave(new SavedEventArgs("New product saved, auction started."));

                    mediator.Notify("ProductAdded", CurrentProduct);

                    CurrentProduct = new Product();
                    


                }
            }
            else
            {
                OnSave(new SavedEventArgs("Check your input."));
            }
        }

        bool CanSave(object obj)
        {
            return true;
        }


        #endregion

        #region events
        public delegate void SavedEventHandler(object sender, SavedEventArgs e);

        public class SavedEventArgs : EventArgs
        {
            private string message;

            public string Message
            {
                get { return message; }
                set
                {
                    if (message == value)
                    {
                        return;
                    }
                    message = value;
                }
            }

            public SavedEventArgs(string message)
            {
                this.message = message;
            }
        }


        public event SavedEventHandler Saved;

        public void OnSave(SavedEventArgs e)
        {
            if (Saved != null)
            {
                Saved(this, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }


        #endregion

    }
}
