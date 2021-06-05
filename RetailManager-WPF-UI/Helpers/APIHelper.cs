using RetailManager_WPF_UI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RetailManager_WPF_UI.Helpers
{
    /// <summary>
    /// Abstraction for views to use (requiring it)
    /// </summary>
    public class APIHelper : IAPIHelper
    {
        private HttpClient _client;

        public APIHelper()
        {
            InitializeClient();
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
    }
}
