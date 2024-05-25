using Microsoft.AspNetCore.Authentication;

namespace Auth_Simple.Web.Models
{
    public class Account
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string EmployeeID { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
