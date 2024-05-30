using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<Employee> FindByNameAsync(Account account);
        Task<bool> RegisterAsync(Account account);
        Task<bool> SignInAsync(Account account);
        Task SignOutAsync();
    }
}
