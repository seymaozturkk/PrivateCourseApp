using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using NuGet.DependencyResolver;
using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Core;
using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.Entity.Concrete.Identity;
using PrivateClassApp.MVC.Areas.Admin.Models.ViewModels;
using PrivateClassApp.MVC.EmailServices;
using PrivateClassApp.MVC.Models;
using System.Security.Policy;

namespace PrivateClassApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IAboutService _aboutService;
        private readonly ILessonService _lessonService;
        private readonly ITeacherAvailabilityService _teacherAvailabilityService;
        private readonly ICategoryService _categoryService;
        private readonly IEducationService _educationService;
        private readonly IEmailSender _emailSender;


        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IStudentService studentService, ITeacherService teacherService, IAboutService aboutService, ILessonService lessonService, ITeacherAvailabilityService teacherAvailabilityService, ICategoryService categoryService, IEducationService educationService, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _studentService = studentService;
            _teacherService = teacherService;
            _aboutService = aboutService;
            _lessonService = lessonService;
            _teacherAvailabilityService = teacherAvailabilityService;
            _categoryService = categoryService;
            _educationService = educationService;
            _emailSender = emailSender;
        }
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Email = registerViewModel.Email,
                    EmailConfirmed = registerViewModel.EmailConfirmed,
                    BirthDate = registerViewModel.BirthDate,
                    Gender = registerViewModel.Gender,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    UserName = registerViewModel.UserName,
                    Url = Jobs.GetUrl(registerViewModel.FirstName + registerViewModel.LastName),
                    NormalizedName = Jobs.NormalizedName(registerViewModel.FirstName + registerViewModel.LastName),
                    NormalizedUserName = Jobs.NormalizedName(registerViewModel.UserName),
                    NormalizedEmail = Jobs.NormalizedEmail(registerViewModel.Email),
                    UserType = registerViewModel.UserType
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    if (registerViewModel.UserType==EnumUserType.Öğrenci)
                    {
                        Student student = new Student();
                        student.UserId = user.Id;
                        await _studentService.CreateAsync(student);
                    }
                    else if(registerViewModel.UserType == EnumUserType.Öğretmen)
                    {
                        Teacher teacher = new Teacher();
                        teacher.UserId = user.Id;
                        await _teacherService.CreateTeacherAsync(teacher);
                    }
                    return RedirectToAction("Login");
                }
            }
            return View(registerViewModel);
        }
        #endregion
        #region Login
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bilgileri hatalı!");
                    return View(loginViewModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, isPersistent: true, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return Redirect(loginViewModel.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Kullanıcı adı ya da parola hatalı!");
            }
            return View(loginViewModel);
        }
        #endregion
        #region Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
        public async Task<IActionResult> ShowProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            var lessons = await _lessonService.GetAllFullDataAsync(null);
            var categories = await _categoryService.GetAllAsync();
            await _aboutService.GetAllAsync();
            await _teacherAvailabilityService.GetAllAsync();
            
            if (user.UserType==EnumUserType.Öğretmen)
            {
                Teacher teacher = await _teacherService.GetTeacherByUserId(user.Id);
                if (teacher != null)
                {
                    await _educationService.GetEducationFullDataAsync(teacher.About.EducationId);
                    var viewModel = new TeacherViewModel()
                    {
                        Id = teacher.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        About = teacher.About,
                        Title = teacher.Title,
                        IsApproved = teacher.IsApproved,
                        ImageUrl = teacher.ImageUrl,
						Lessons = teacher.Lessons?.Select(x => new LessonModel
						{
							Id = x.Id,
							UpdatedDate = x.UpdatedDate,
							Url = x.Url,
							Name = x.Name,
							Price = x.Price,
							Description = x.Description,
							Teacher = teacher,
                            Categories = x.LessonCategories.Select(bc => bc.Category).ToList()
                        }).ToList() ?? new List<LessonModel>(),
						TeacherAvailabilities = teacher.TeacherAvailabilities,
                    };
                    return View("ShowTeacherProfile",viewModel);
                }
            }
                
            else if (user.UserType == EnumUserType.Öğrenci)
            {
                Student student = await _studentService.GetStudentByUserId(user.Id);
                if (student == null) return NotFound();
                
                return RedirectToAction("EditProfile","Students", student);
            }
            else
            {
                
				return RedirectToAction("EditProfile","Admins");

			}
			return View();
        }

        public async Task<IActionResult> ConfirmEmail()
        {
            User user = await _userManager.GetUserAsync(User);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (user != null)
            {
                string url = Url.Action("EmailConfirmed", "Account", new
                {
                    userId = user.Id,
                    token = token
                });
                await _emailSender.SendEmailAsync(
                user.Email,
                "BirebirAkademi Email Onayı!",
                $"Mailinizi onaylamak için <a href='http://localhost:7295{url}'>tıklayınız</a>"
                );
                return Redirect("/");
            }
            return View();
        }
        public async Task<IActionResult> EmailConfirmed(string userId, string token)
        {
            if (userId == null || token == null)
            {
                var user = await _userManager.FindByIdAsync(userId);
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return Redirect("/");
            }
            return RedirectToAction("ShowProfile");

        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return View();
            }
            User user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return View();
            }
            string code = await _userManager.GeneratePasswordResetTokenAsync(user);
            string url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });
            await _emailSender.SendEmailAsync(
                email,
                "BirebirAkademi Şifre Sıfırlama!",
                $"Parolanızı yeniden belirlemek için <a href='http://localhost:7295{url}'>tıklayınız</a>"
                );
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return Redirect("/");
            }
            ResetPasswordViewModel resetPasswordViewModel = new ResetPasswordViewModel
            {
                Token = token
            };
            return View(resetPasswordViewModel);
        }

        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid) { return View(resetPasswordViewModel); }
            User user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (user == null)
            {
                return Redirect("/");
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Token, resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View(resetPasswordViewModel);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
