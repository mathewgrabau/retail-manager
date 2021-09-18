using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace DataManagerService.Controllers
{
    [Authorize]
    public class ProductController : ApiController 
    {
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData();

            return data.GetProducts();
        }
    }
}
