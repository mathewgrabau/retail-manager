using System;

namespace RetailManager.Desktop.Library.Models
{
    public interface ILoggedInUserViewModel
    {
        string Token { get; set; }
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }
        DateTime CreatedDate { get; set; }
    }
}