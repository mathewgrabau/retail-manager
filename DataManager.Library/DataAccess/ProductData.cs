using System.Collections.Generic;
using DataManager.Library.Internal.DataAccess;
using DataManager.Library.Models;

namespace DataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetProducts()
        {
            SqlDataAccess sql = new SqlDataAccess();

            // Anonymous class for the parameters... basically just to get around it.
            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "RetailManagerConnection");

            return output;
        }
    }
}
