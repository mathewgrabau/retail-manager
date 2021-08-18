using RetailManager.Desktop.Models;
using System.Threading.Tasks;

namespace RetailManager.Desktop.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}