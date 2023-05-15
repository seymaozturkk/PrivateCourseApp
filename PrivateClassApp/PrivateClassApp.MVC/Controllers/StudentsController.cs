using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Core;
using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.Entity.Concrete.Identity;
using PrivateClassApp.MVC.Models;

namespace PrivateClassApp.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IStudentService _studentService;

        public StudentsController(UserManager<User> userManager, IStudentService studentService)
        {
            _userManager = userManager;
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> EditProfile(Student student)
        {
            var user = await _userManager.GetUserAsync(User);
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Id = student.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                ImageUrl = student.ImageUrl,
                UpdatedDate = user.UpdatedDate,
                CreatedDate = user.CreatedDate,
                UserName = user.UserName,
                BirthDate = user.BirthDate,
                Email = user.Email
            };
            return View(studentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(StudentViewModel studentViewModel)
        {
            if(ModelState.IsValid)
            {
                User user = await _userManager.GetUserAsync(User);
                var idStudent = await _studentService.GetStudentByUserId(user.Id);
                var student = await _studentService.GetByIdAsync(idStudent.Id);
                if (student == null) return NotFound();
                if (studentViewModel.Image != null)
                {
                    student.ImageUrl = Jobs.UploadStudentImage(studentViewModel.Image);
                }
                else
                {
                    return View(studentViewModel);
                }
                _studentService.Update(student);
                user.Gender = studentViewModel.Gender;
                user.BirthDate = studentViewModel.BirthDate;
                user.UpdatedDate = DateTime.Now;
                if (studentViewModel.Email != user.Email)
                {
                    user.Email = studentViewModel.Email;
                    user.EmailConfirmed = false;
                }
                user.FirstName = studentViewModel.FirstName;
                user.LastName = studentViewModel.LastName;
                user.NormalizedEmail = Jobs.NormalizedEmail(studentViewModel.Email);
                user.NormalizedName = Jobs.NormalizedName(studentViewModel.FirstName + studentViewModel.LastName);
                bool logOut = !(user.UserName == studentViewModel.UserName);
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

            return View(studentViewModel);
        }
    }
}
