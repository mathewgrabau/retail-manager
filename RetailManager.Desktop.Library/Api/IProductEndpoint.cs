using RetailManager.Desktop.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailManager.Desktop.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}