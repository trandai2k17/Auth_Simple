using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<bool> AddRoleAsync(string roleName);
        Task<Employee> FindByNameAsync(Account account);
        Task<bool> RegisterAsync(Account account);
        Task<List<IdentityRole>> Roles();
        Task<bool> SignInAsync(Account account);
        Task SignOutAsync();
        Task<bool> DeleteRoleAsync(string id);
        Task<bool> UpdateRoleAsync(string id);
        Task<IdentityRole> GetRoleByName(string roleName);
    }
}
