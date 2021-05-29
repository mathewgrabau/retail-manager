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
                NotifyOfPropertyChange(() => CanLogin);
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
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public LoginViewModel()
        {

        }

        public bool CanLogin
        {
            get
            {
                bool allow = false;

                if (!string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_password))
                {
                    allow = true;
                }

                return allow;
            }
        }

        public void Login()
        {
            Console.WriteLine("Logging in now");
        }
    }
}
