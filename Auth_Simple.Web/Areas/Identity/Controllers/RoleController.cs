using Application.Interfaces;
using Auth_Simple.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Simple.Web.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class RoleController : Controller
    {
        private readonly IAuthService _authService;
        public RoleController(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<IActionResult> Roles()
        {
            var roles = await _authService.Roles();
            var model = new RoleVM() { 
                Roles = roles,
                CreatedDate = DateTime.Now,

            };
            return View(nameof(Roles), model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleVM model)
        {
            if (ModelState.IsValid)
            {
                await _authService.AddRoleAsync(model.RoleName);
                return RedirectToAction(nameof(Roles));
            }
            return View(nameof(Create), model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleVM model)
        {
            if (ModelState.IsValid)
            {
                await _authService.UpdateRoleAsync(model.RoleID);
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Update), model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RoleVM model)
        {
            await _authService.DeleteRoleAsync(model.RoleID);
            return RedirectToAction(nameof(Index));
        }
    }
}
