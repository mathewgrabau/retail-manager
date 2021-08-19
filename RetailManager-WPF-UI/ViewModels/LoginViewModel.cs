using Caliburn.Micro;
using RetailManager_WPF_UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailManager.Desktop.Library.Api;
using RetailManager.Desktop.Models;
using RetailManager_WPF_UI.EventModels;

namespace RetailManager_WPF_UI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private IAPIHelper _apiHelper;
        private IEventAggregator _events;

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }

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

        public bool IsErrorVisible
        {
            get
            {
                return !string.IsNullOrEmpty(_errorMessage);
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            { 
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
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

        public async Task Login()
        {
            try
            {
                ErrorMessage = string.Empty;
                AuthenticatedUser result = await _apiHelper.Authenticate(Username, Password);

                // Retrieve the additional information about the user
                await _apiHelper.GetLoggedInUserInfo(result.AccessToken);

                // Push the event for the login
                _events.PublishOnUIThread(new LogOnEvent());
                
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
    }
}
