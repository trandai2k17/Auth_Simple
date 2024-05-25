using Auth_Simple.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Auth_Simple.Web.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        public IActionResult Register(string ReturnUrl = null)
        {
            var model = new Account()
            {
                ReturnUrl = ReturnUrl,
            };
            return View(nameof(Register), model);
        }

        public IActionResult Accounts()
        {
            return View(nameof(Accounts));
        }

        [HttpPost]
        public IActionResult Register(Account model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    EmployeeID = model.EmployeeID,
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper(),
                    EmailConfirmed = true,
                    UserName = model.EmployeeID,
                };
            }

            return View(nameof(Register), model);
        }
    }
}
