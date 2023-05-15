using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Core;
using PrivateClassApp.Data.Abstract;
using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.Entity.Concrete.Identity;
using PrivateClassApp.MVC.Areas.Admin.Models.ViewModels;
using System.Data;

namespace PrivateClassApp.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]

	public class UsersController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<Role> _roleManager;
        private readonly INotyfService _notyfService;
		private readonly ILessonLikeService _lessonLikeService;
		private readonly IStudentService _studentService;
		private readonly ITeacherService _teacherService;

        public UsersController(UserManager<User> userManager, RoleManager<Role> roleManager, INotyfService notyfService, ILessonLikeService lessonLikeService, IStudentService studentService, ITeacherService teacherService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _notyfService = notyfService;
            _lessonLikeService = lessonLikeService;
            _studentService = studentService;
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index(EnumUserType userType)
		{
			if (userType==EnumUserType.Admin)
			{
                List<UserManageViewModel> users = await _userManager
                .Users
                .Select(u => new UserManageViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    EmailConfirmed = u.EmailConfirmed,
                    UserType = u.UserType,
                    UpdatedDate = u.UpdatedDate
                }).ToListAsync();
                return View(users);
            }
			else
			{
                List<UserManageViewModel> users = await _userManager
                .Users
				.Where(u => u.UserType==userType)
                .Select(u => new UserManageViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    EmailConfirmed = u.EmailConfirmed,
                    UserType = u.UserType,
                    UpdatedDate = u.UpdatedDate
                }).ToListAsync();
                return View(users);
            }
			
		}
		#region User Silme
		public async Task<IActionResult> Delete(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user == null) return NotFound();
            await _userManager.DeleteAsync(user);

   //         if (user.UserType == EnumUserType.Öğrenci)
			//{
			//	Student student = await _studentService.GetStudentByUserId(id);
			//	if (student!=null)
			//	{
   //                 _studentService.Delete(student);
   //             }
   //         }
			//else if(user.UserType == EnumUserType.Öğretmen)
			//{
			//	Teacher teacher = await _teacherService.GetTeacherByUserId(id);
			//	if (teacher!=null)
			//	{
   //                 _teacherService.Delete(teacher);
   //             }
   //         }

			//Like like = await _likeService.GetLikeByUserId(id);
			//if (like!=null)
			//{
   //             _likeService.Delete(like);
   //         }

			//var userRoles = await _userManager.GetRolesAsync(user);
			//await _userManager.RemoveFromRolesAsync(
			//                   user,
			//                   userRoles.ToList<string>());

			
			_notyfService.Error("Kullanıcı silindi!");
            return RedirectToAction("Index");
		}
		#endregion
		#region User Düzenleme
		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }
			UserEditViewModel userEditViewModel = new UserEditViewModel
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				NormalizedName = user.NormalizedName,
				Email = user.Email,
				EmailConfirmed = user.EmailConfirmed,
				NormalizedEmail = user.NormalizedEmail,
				UserType = user.UserType,
				UpdatedDate = user.UpdatedDate,
				CreatedDate = user.CreatedDate,
				UserName = user.UserName,
				NormalizedUserName = user.NormalizedUserName,
				Url = user.Url,
				Gender = user.Gender,
				BirthDate = user.BirthDate,
				
			};
			return View(userEditViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(UserEditViewModel userEditViewModel)
		{
			if (userEditViewModel == null) return NotFound();
			if (ModelState.IsValid)
			{
				User user = await _userManager.FindByIdAsync(userEditViewModel.Id);
				if (user == null) return NotFound();
				user.Id = userEditViewModel.Id;
				user.FirstName = userEditViewModel.FirstName;
				user.LastName = userEditViewModel.LastName;
				user.Email = userEditViewModel.Email;
				user.EmailConfirmed = userEditViewModel.EmailConfirmed;
				user.BirthDate = userEditViewModel.BirthDate;
				user.Gender = userEditViewModel.Gender;
				user.CreatedDate = userEditViewModel.CreatedDate;
				user.UpdatedDate = DateTime.Now;
				user.UserName = userEditViewModel.UserName;
				user.Url = Jobs.GetUrl(userEditViewModel.FirstName + userEditViewModel.LastName);
                user.NormalizedUserName = Jobs.NormalizedName(userEditViewModel.FirstName + userEditViewModel.LastName);
				user.NormalizedEmail = Jobs.NormalizedEmail(userEditViewModel.Email);
				user.UserType = userEditViewModel.UserType;

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded) { return NotFound(); }

                var userRoles = await _userManager.GetRolesAsync(user);

				if (userEditViewModel.UserType==EnumUserType.Admin)
				{
                    await _userManager.AddToRoleAsync( user, "Admin");
					await _userManager.RemoveFromRoleAsync(user, "User");
                }
				else
				{
                    await _userManager.AddToRoleAsync(user, "User");
                    await _userManager.RemoveFromRoleAsync(user, "Admin");
                }
                _notyfService.Success("Kullanıcı başarıyla güncellendi.");
				return RedirectToAction("Index");

			}
            return View(userEditViewModel);
		}
		#endregion
		#region User Oluşturma
		public IActionResult Create()
		{
			UserAddViewModel userAddViewModel = new UserAddViewModel();
			return View(userAddViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Create(UserAddViewModel userAddViewModel)
		{
			if (ModelState.IsValid)
			{
				User user = new User
				{
					FirstName = userAddViewModel.FirstName,
					LastName = userAddViewModel.LastName,
					Email = userAddViewModel.Email,
					EmailConfirmed = userAddViewModel.EmailConfirmed,
					BirthDate = userAddViewModel.BirthDate,
					Gender = userAddViewModel.Gender,
					CreatedDate = DateTime.Now,
					UpdatedDate = DateTime.Now,
					UserName = userAddViewModel.UserName,
					Url = Jobs.GetUrl(userAddViewModel.FirstName + userAddViewModel.LastName),
					NormalizedUserName = Jobs.NormalizedName(userAddViewModel.FirstName + userAddViewModel.LastName),
					NormalizedEmail = Jobs.NormalizedEmail(userAddViewModel.Email),
					UserType = userAddViewModel.UserType
				};
				var result = await _userManager.CreateAsync(user, userAddViewModel.Password);
				if (result.Succeeded)
				{
                    if (userAddViewModel.UserType == EnumUserType.Admin)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
					else
					{
                        await _userManager.AddToRoleAsync(user, "User");
						if(userAddViewModel.UserType == EnumUserType.Öğrenci)
						{
							Student student = new Student();
							student.UserId = user.Id;
							await _studentService.CreateAsync(student);
						}
						else
						{
							Teacher teacher = new Teacher();
							teacher.UserId = user.Id;
							await _teacherService.CreateTeacherAsync(teacher);
							
						}
                    }
					//await _likeService.CreateAsync(new Like
					//{
					//	UserId = user.Id
					//});
					
                }
				return RedirectToAction("Index");
			}
			_notyfService.Error("Bir hata oluştu, lütfen tekrar deneyin.");
			return View(userAddViewModel);
		}
		#endregion
		[HttpGet]
		public async Task<IActionResult> EditAdminProfile()
		{
            var user = await _userManager.GetUserAsync(User);
            return View(user);
		}
		[HttpPost]
        public IActionResult EditAdminProfile(User user)
		{
			return View(user);
		}

    }
}
