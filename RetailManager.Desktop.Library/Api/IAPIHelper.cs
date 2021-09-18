using RetailManager.Desktop.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RetailManager.Desktop.Library.Api
{
    public interface IAPIHelper
    {
        HttpClient Client { get; }

        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}