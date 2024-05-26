using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Simple.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Employees()
        {
            List<Employee> employees = new List<Employee>();
            employees = await _unitOfWork.EmployeeRepository.EmployeesAsync();
            return View(nameof(Employees), employees);
        }
    }
}
