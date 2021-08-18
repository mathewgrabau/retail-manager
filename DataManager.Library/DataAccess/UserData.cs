using System.Collections.Generic;
using DataManager.Library.Internal.DataAccess;
using DataManager.Library.Models;

namespace DataManager.Library.DataAccess
{
    /// <summary>
    /// Provides access to the user data portion of the database.
    /// </summary>
    public class UserData
    {
        public List<UserModel> GetUserById(string id)
        {
            // TODO adding AutoFac later
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { id = id };

            List<UserModel> output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", parameters, "RetailManagerConnection");

            return output;
        }
    }
}
