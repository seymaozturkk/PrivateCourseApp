using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Core;
using PrivateClassApp.Entity.Concrete.Identity;
using PrivateClassApp.MVC.Models;

namespace PrivateClassApp.MVC.Controllers
{
    public class AdminsController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AdminsController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            AdminViewModel adminViewModel = new AdminViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                UpdatedDate = user.UpdatedDate,
                CreatedDate = user.CreatedDate,
                UserName = user.UserName,
                BirthDate = user.BirthDate,
                Email = user.Email

            };
            return View(adminViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(AdminViewModel adminViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null) return NotFound();
                user.Gender = adminViewModel.Gender;
                user.BirthDate = adminViewModel.BirthDate;
                user.UpdatedDate = DateTime.Now;
                if (adminViewModel.Email != user.Email)
                {
                    user.Email = adminViewModel.Email;
                    user.EmailConfirmed = false;
                }
                user.FirstName = adminViewModel.FirstName;
                user.LastName = adminViewModel.LastName;
                user.NormalizedEmail = Jobs.NormalizedEmail(adminViewModel.Email);
                user.NormalizedName = Jobs.NormalizedName(adminViewModel.FirstName + adminViewModel.LastName);
                bool logOut = !(user.UserName == adminViewModel.UserName);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    if (logOut)
                    {
                        return RedirectToAction("Logout", "Account");
                    }
                    return RedirectToAction("ShowProfile", "Account");
                }
            }

            return View(adminViewModel);
        }
    }
}
