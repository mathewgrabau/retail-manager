using RetailManager.Desktop.Library.Models;
using RetailManager.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RetailManager.Desktop.Library.Api
{
    /// <summary>
    /// Abstraction for views to use (requiring it)
    /// </summary>
    public class APIHelper : IAPIHelper
    {
        private HttpClient _client;
        private ILoggedInUserViewModel _currentUser;

        public APIHelper(ILoggedInUserViewModel loggedInUser)
        {
            InitializeClient();
            _currentUser = loggedInUser;
        }

        private void InitializeClient()
        {
            string apiAddress = ConfigurationManager.AppSettings["api"];

            _client = new HttpClient();
            _client.BaseAddress = new Uri(apiAddress);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
            });

            // Allowing easier subbing of the server URL this way.
            using (HttpResponseMessage response = await _client.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task GetLoggedInUserInfo(string accessToken)
        {
            // Adjust/correct the headers
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            using (HttpResponseMessage response = await _client.GetAsync("/api/User"))
            {
                if (response.IsSuccessStatusCode)
                {
                    // Grab the result and attach the token.
                    var result = await response.Content.ReadAsAsync<LoggedInUserModel>();
                    if (result != null)
                    {
                        result.Token = accessToken;
                        // Storing this in a singleton available for the rest of the application.
                        _currentUser.Token = accessToken;
                        _currentUser.Id = result.Id;
                        _currentUser.FirstName = result.FirstName;
                        _currentUser.LastName = result.LastName;
                        _currentUser.EmailAddress = result.EmailAddress;
                        _currentUser.CreatedDate = result.CreatedDate;
                    }
                    
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
