using Application.Interfaces;
using Auth_Simple.Infrastructure.Identity.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Simple.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        public EmployeeController(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }
        public async Task<IActionResult> Employees()
        {
            List<Employee> employees = new List<Employee>();
            employees = await _unitOfWork.EmployeeRepository.EmployeesAsync();
            return View(nameof(Employees), employees);
        }
        public async Task<IActionResult> CreateAccount(string EmployeeID, Employee employee)
        { 
            if(!string.IsNullOrEmpty(EmployeeID))
            {
                var empl = await _unitOfWork.EmployeeRepository.GetEmployeeByEmplID(EmployeeID);

                if(empl != null)
                {
                    Account account = new Account()
                    {
                        EmployeeID = EmployeeID,
                        Password = "123123",
                        UserName = EmployeeID,
                        Email = empl.EmailAddress,
                        EmployeeName = empl.EmployeeName
                    };

                    await _authService.RegisterAsync(account);
                }
            }
            
            return Redirect(nameof(Employees));
        }
    }
}
