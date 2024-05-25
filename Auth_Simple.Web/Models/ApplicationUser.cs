using Microsoft.AspNetCore.Identity;

namespace Auth_Simple.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public string ProfilePicture { get; set; }
    }
}
