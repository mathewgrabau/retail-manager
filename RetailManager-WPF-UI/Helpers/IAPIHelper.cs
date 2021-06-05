using RetailManager_WPF_UI.Models;
using System.Threading.Tasks;

namespace RetailManager_WPF_UI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}