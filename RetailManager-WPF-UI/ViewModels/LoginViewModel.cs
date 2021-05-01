using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManager_WPF_UI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public LoginViewModel()
        {

        }

        public bool CanLogin(string username, string password)
        {
            bool allow = false;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                allow = true;
            }

            return allow;
        }

        public void Login(string username, string password)
        {
            Console.WriteLine("Logging in now");
        }
    }
}
