using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManager.Desktop.Library.Models
{
    public class LoggedInUserModel : ILoggedInUserViewModel
    {
        /// <summary>
        /// Bearer token (for accessing the API).
        /// </summary>
        public string Token { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
