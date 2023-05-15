using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Core;
using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.Entity.Concrete.Identity;
using PrivateClassApp.MVC.Areas.Admin.Models.ViewModels;
using System.Data;

namespace PrivateClassApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]

	public class RolesController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly INotyfService _notyfService;

        public RolesController(RoleManager<Role> roleManager, UserManager<User> userManager, INotyfService notyfService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            List<RoleViewModel> roles = await _roleManager.Roles.Select(r => new RoleViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToListAsync();

            return View(roles);
        }
        #region Rol Oluşturma
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleAddViewModel roleAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new Role
                {
                    Name = roleAddViewModel.Name,
                    Description = roleAddViewModel.Description
                });
                if (result.Succeeded)
                {
                    _notyfService.Success("Rol oluşturma başarıyla gerçekleşti.");
                }
                return RedirectToAction("Index", "Roles");
            }

            return View(roleAddViewModel);
        }
        #endregion
        #region Rol Silme
        public async Task<IActionResult> Delete(string id)
        {
            Role role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
        #endregion
        #region Rol Düzenleme
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            Role role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            RoleEditViewModel roleEditViewModel = new RoleEditViewModel()
            {
                Id = id,
                Name = role.Name,
                Description = role.Description
            };
            return View(roleEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleEditViewModel roleEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Role role = await _roleManager.FindByIdAsync(roleEditViewModel.Id);
                role.Name = roleEditViewModel.Name;
                role.Description = roleEditViewModel.Description;
                await _roleManager.UpdateAsync(role);
                return RedirectToAction("Index");
            }
            return View(roleEditViewModel);
        }
        #endregion

    }
}
