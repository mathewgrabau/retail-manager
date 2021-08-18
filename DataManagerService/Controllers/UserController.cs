using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DataManagerService.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        public UserModel GetById()
        {
            // Getting the id from the currently logged in user
            string userId = RequestContext.Principal.Identity.GetUserId();

            UserData userData = new UserData();

            List<UserModel> output = userData.GetUserById(userId);

            // Data access model is okay here (no need for a display model right now)
            if (output == null)
            {
                return default;
            }
            return output.FirstOrDefault();
        }

        public List<UserModel> GetById(string id)
        {
            UserData userData = new UserData();

            return userData.GetUserById(id);
        }
    }
}
