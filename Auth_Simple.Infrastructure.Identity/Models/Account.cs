using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Simple.Infrastructure.Identity.Models
{
    public class Account
    {
        public string ReturnUrl { get; set; }
        public string UserName { get; set; }
        public string EmployeeID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
