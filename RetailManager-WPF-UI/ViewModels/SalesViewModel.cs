using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManager_WPF_UI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;

        public BindingList<string> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<string> _cartContents;

        public BindingList<string> CartContents
        {
            get { return _cartContents; }
            set
            {
                _cartContents = value;

                NotifyOfPropertyChange(() => CartContents);
            }
        }

        private string _itemQuantity;

        public string ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        public string Subtotal
        {
            // TODO need to do the calculation
            get { return string.Empty; }
        }

        public string Tax
        {
            // TODO need to do the calculation
            get { return string.Empty; }
        }

        public string Total
        {
            // TODO need to do the calculation
            get { return string.Empty; }
        }

        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                // Make sure there is something selected and a valid quantity
                if (int.TryParse(ItemQuantity, out int quantity))
                {

                }

                return output;
            }
        }

        public void AddToCart()
        {

        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                // Make sure there is something selected from the cart to remove
                

                return output;
            }
        }

        public void RemoveFromCart()
        {

        }

        public bool CanCheckout
        {
            get
            {
                bool output = false;

                // Make sure there is something in the cart to be able to checkout.

                return output;
            }
        }

        public void Checkout()
        {

        }
    }
}
