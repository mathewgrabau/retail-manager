using RetailManager.Desktop.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RetailManager.Desktop.Library.Api
{
    public class ProductEndpoint : IProductEndpoint
    {
        private IAPIHelper _helper;

        public ProductEndpoint(IAPIHelper helper)
        {
            _helper = helper;
        }

        public async Task<List<string>> GetAll()
        {
            // Perform call and retunr it
            using (HttpResponseMessage response = await _helper.Client.GetAsync("/api/Product"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ProductModel>>();
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
