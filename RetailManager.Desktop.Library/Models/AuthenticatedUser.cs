using Newtonsoft.Json;

namespace RetailManager.Desktop.Models
{
    public class AuthenticatedUser
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        public string UserName { get; set; }
    }
}
