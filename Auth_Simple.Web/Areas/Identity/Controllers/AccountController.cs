using Application.Interfaces;
using Auth_Simple.Infrastructure.Identity.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.DapperContext;
using Persistence.Repositories;

namespace Auth_Simple.Web.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        
        public AccountController(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }
        public IActionResult Register()
        {
            Account model = new Account();
            return View(nameof(Register), model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(Account account)
        {
            if(ModelState.IsValid)
            {
                var result = await _authService.RegisterAsync(account);
                if(result)
                {
                    await _authService.SignInAsync(account);
                    return Redirect(account.ReturnUrl);
                }
               
            }
            Account model = new Account();
            return View(nameof(Register), account);
        }
        public IActionResult Login(string ReturnUrl = null)
        {
            Account model = new Account()
            {
                ReturnUrl = ReturnUrl?? "~"
            };
            return View(nameof(Login), model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(Account model, string ReturnUrl)
        {
            var result = await _authService.SignInAsync(model);
            if(result)
            {
                return Redirect("~" + ReturnUrl);
            }
            return View(nameof(Login), model);
        }
        [Authorize]
        public async Task<IActionResult> Accounts()
        {
            List<SYSUserTable> users = new List<SYSUserTable>();
            users = await _unitOfWork.AccountRepo.AccountsAsync();
            return View(nameof(Accounts), users);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterIdentity(SYSUserTable model)
        {
            List<SYSUserTable> users = new List<SYSUserTable>();
            //users = await _db.SYSUserTableDB.ToListAsync();

            return View(nameof(Accounts), users);
        }

        public async Task<IActionResult> Logout()
        {
            await _authService.SignOutAsync();

            return Redirect("~/Home");
        }


        public async Task<IActionResult> CreateAccount(Employee EmplID)
        {
            Account account = new Account();
            return View(nameof(Register), account);
        }
    }
}
