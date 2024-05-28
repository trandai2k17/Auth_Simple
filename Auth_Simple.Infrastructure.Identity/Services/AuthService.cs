using Application.Interfaces;
using Auth_Simple.Infrastructure.Identity.Models;
using Azure.Core;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Simple.Infrastructure.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> SignInAsync(Account account)
        {
            ApplicationUser user = new ApplicationUser
            {
                Email = account.Email,
                UserName = account.EmployeeID,
                EmployeeID = account.EmployeeID,
            };

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user.UserName, account.Password, true, false);
            return signInResult.Succeeded;
        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<bool> RegisterAsync(Account account)
        {
            ApplicationUser user = new ApplicationUser
            {
                Email = account.Email,
                UserName = account.EmployeeID,
                EmployeeID = account.EmployeeID,
            };

            IdentityResult result = await _userManager.CreateAsync(user, account.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return false;
        }
    }
}
