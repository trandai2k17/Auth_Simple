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
            var model = new RoleVM()
            {
                Roles = roles,
                CreatedDate = DateTime.Now,
            };
            return View(nameof(Roles), model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleVM role)
        {
            if(!string.IsNullOrEmpty(role.RoleID))
            {
                var updateRole = await _authService.GetRoleByID(role.RoleID);

                updateRole.Name = role.RoleName;
                if (await _authService.UpdateRoleAsync(updateRole))
                {
                    TempData["success"] = "Success";
                } else
                {
                    TempData["error"] = "failed";
                }
                return RedirectToAction(nameof(Roles));
            } else
            {
                var existsRole = await _authService.GetRoleByName(role.RoleName);
                if (existsRole != null)
                {
                    TempData["warning"] = "Exists";
                }
                else
                {
                    var result = await _authService.AddRoleAsync(role.RoleName);
                    if (result)
                    {
                        TempData["success"] = "Success";
                    }
                    else
                    {
                        TempData["error"] = "failed";
                    }
                }
            }
            
            return RedirectToAction(nameof(Roles));
        }
        [HttpGet]
        public async Task<IActionResult> Update(string RoleName)
        {
            var role = await _authService.GetRoleByName(RoleName);
            var model = new RoleVM()
            {
                RoleID = role.Id,
                RoleName = role.Name,
                Roles = await _authService.Roles()
            };
            return View(nameof(Roles), model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleVM model)
        {
            //if (ModelState.IsValid)
            //{
            //    await _authService.UpdateRoleAsync(model.RoleID);
            //    return RedirectToAction(nameof(Roles));
            //}
            return View(nameof(Roles), model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RoleVM model)
        {
            await _authService.DeleteRoleAsync(model.RoleID);
            return RedirectToAction(nameof(Roles));
        }
    }
}
