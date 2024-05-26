using Application.Interfaces;
using Auth_Simple.Web.Data;
using Domain.Entities;
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
        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Register()
        {
            AccountTable model = new AccountTable();
            return View(nameof(Register), model);
        }

        public async Task<IActionResult> Accounts()
        {
            List<SYSUserTable> users = new List<SYSUserTable>();

            return View(nameof(Accounts), users);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterIdentity(SYSUserTable model)
        {
            List<SYSUserTable> users = new List<SYSUserTable>();
            //users = await _db.SYSUserTableDB.ToListAsync();

            return View(nameof(Accounts), users);
        }
    }
}
