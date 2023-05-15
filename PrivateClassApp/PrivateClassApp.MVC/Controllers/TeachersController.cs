using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Core;
using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.Entity.Concrete.Identity;
using PrivateClassApp.MVC.EmailServices;
using PrivateClassApp.MVC.Models;

namespace PrivateClassApp.MVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherAvailabilityService _teacherAvailabilityService;
        private readonly ITeacherService _teacherService;
        private readonly ILessonService _lessonService;
        private readonly IAboutService _aboutService;
        private readonly IEducationService _educationService;
        private readonly UserManager<User> _userManager;
        private readonly ICategoryService _categoryService;
        private readonly IUniversityEducationService _universityEducationService;
        private readonly IUniversityService _uniiversityService;


        public TeachersController(ITeacherAvailabilityService teacherAvailabilityService, ITeacherService teacherService, ILessonService lessonService, IAboutService aboutService, IEducationService educationService, UserManager<User> userManager, ICategoryService categoryService, IUniversityEducationService universityEducationService, IUniversityService uniiversityService)
        {
            _teacherAvailabilityService = teacherAvailabilityService;
            _teacherService = teacherService;
            _lessonService = lessonService;
            _aboutService = aboutService;
            _educationService = educationService;
            _userManager = userManager;
            _categoryService = categoryService;
            _universityEducationService = universityEducationService;
            _uniiversityService = uniiversityService;
        }

        public async Task<IActionResult> Index(string categoryurl, bool? isApproved)
        {
            _userManager.Users.Where(x => x.UserType == EnumUserType.Öğretmen).ToList();
            await _aboutService.GetAllAsync();
            var teachers = await _teacherService.GetAllFullDataAsync();

            if (isApproved.HasValue && isApproved.Value)
                teachers = teachers.Where(x => x.IsApproved).ToList();

            List<Category> categories = await _categoryService.GetAllAsync();
            List<TeacherViewModel> teachersViewModel = new List<TeacherViewModel>();
            List<CategoryViewModel> categoryViewModelList = new List<CategoryViewModel>();
            foreach (Category category in categories)
            {
                categoryViewModelList.Add(new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Url = category.Url
                });
            }
            if (RouteData.Values["categoryurl"] != null)
            {
                ViewBag.SelectedCategory = RouteData.Values["categoryurl"];
            }
            if (categoryurl != null)
            {
                teachersViewModel = teachers.Select(x => new TeacherViewModel
                {
                    Id = x.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Title = x.Title,
                    IsApproved = x.IsApproved,
                    ImageUrl = x.ImageUrl,
                    About = x.About
                }).Where(x => !string.IsNullOrEmpty(x.Title) && x.Title.ToLower().Contains($"{categoryurl.ToLower()}")).ToList();
            }
            else
            {
                teachersViewModel = teachers.Select(x => new TeacherViewModel
                {
                    Id = x.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Title = x.Title,
                    IsApproved = x.IsApproved,
                    ImageUrl = x.ImageUrl,
                    About = x.About,
                }).ToList();
            }
            ViewBag.Categories = categoryViewModelList;
            return View(teachersViewModel);
        }
        public JsonResult AddTeacherAvailability(TeacherAvailabilityModel teacherAvailabilityModel)
        {
            if (ModelState.IsValid)
            {
                TeacherAvailability teacherAvailability = new TeacherAvailability();
                teacherAvailability.TeacherId = teacherAvailabilityModel.TeacherId;
                teacherAvailability.DayOfWeek = teacherAvailabilityModel.DayOfWeek;
                teacherAvailability.Time = teacherAvailabilityModel.Time;
                _teacherAvailabilityService.CreateAsync(teacherAvailability);

            }
            else
            {
                return Json(false);
            }
            return Json(true);
        }
        public async Task<JsonResult> DeleteTeacherAvailability(int id)
        {
            if (ModelState.IsValid)
            {
                var teacherAvailability = await _teacherAvailabilityService.GetByIdAsync(id);
                _teacherAvailabilityService.Delete(teacherAvailability);
            }
            else
            {
                return Json(false);
            }
            return Json(true);
        }
        
        public async Task<IActionResult> ShowTeacherDetails(int id)
        {
            var teacher = await _teacherService.GetTeacherFullDataAsync(id);
            await _userManager.GetUsersInRoleAsync("User");
            await _aboutService.GetAllAsync();
            await _educationService.GetEducationFullDataAsync(teacher.About.EducationId);
            await _lessonService.GetAllAsync();
            await _teacherAvailabilityService.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();
            if (teacher == null) return NotFound();
            TeacherViewModel teacherViewModel = new TeacherViewModel()
            {
                Id = teacher.Id,
                FirstName = teacher.User.FirstName,
                LastName = teacher.User.LastName,
                Title = teacher.Title,
                IsApproved = teacher.IsApproved,
                ImageUrl = teacher.ImageUrl,
                Lessons = teacher.Lessons.Select(x => new LessonModel
                {
                    Id = x.Id,
                    UpdatedDate = x.UpdatedDate,
                    Url = x.Url,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    Teacher = teacher,
                    Categories = x.LessonCategories.Select(bc => bc.Category).ToList()
                }).ToList(),
                TeacherAvailabilities = teacher.TeacherAvailabilities,
                About = teacher.About,
            };
            return View("TeacherDetails", teacherViewModel);
        }
        #region Ders Ekleme
        [HttpGet]
        public async Task<IActionResult> AddLesson()
        {
            await _userManager.GetUsersInRoleAsync("User");
            LessonAddViewModel lessonAddViewModel = new LessonAddViewModel();
            lessonAddViewModel.Categories = await _categoryService.GetAllAsync();
            return View(lessonAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddLesson(LessonAddViewModel lessonAddViewModel)
        {
            User user = await _userManager.GetUserAsync(User);
            if (lessonAddViewModel == null) return NotFound();
            if (ModelState.IsValid)
            {
                Lesson lesson = new Lesson();

                lesson.Name = lessonAddViewModel.Name;
                lesson.Url = Jobs.GetUrl(lessonAddViewModel.Name);
                lesson.CreatedDate = DateTime.Now;
                lesson.UpdatedDate = DateTime.Now;
                lesson.Description = lessonAddViewModel.Description;
                lesson.Teacher = await _teacherService.GetTeacherByUserId(user.Id);
                lesson.Price = lessonAddViewModel.Price;

                await _lessonService.CreateLesson(lesson, lessonAddViewModel.SelectedCategories);

                return RedirectToAction("Index");
            }
            lessonAddViewModel.Categories = await _categoryService.GetAllAsync();
            return View(lessonAddViewModel);
        }
        #endregion
        #region Ders Silme
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var lesson = await _lessonService.GetByIdAsync(id);
            if (lesson == null) return NotFound();
            _lessonService.Delete(lesson);
            return RedirectToAction("ShowProfile", "Account");
        }
        #endregion
        #region Profil Düzenleme
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            User user = await _userManager.GetUserAsync(User);
            var idTeacher = await _teacherService.GetTeacherByUserId(user.Id);
            var teacher = await _teacherService.GetTeacherFullDataAsync(idTeacher.Id);
            if (teacher == null) return NotFound();
            TeacherEditViewModel teacherEditViewModel = new TeacherEditViewModel()
            {
                Id = teacher.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UpdatedDate = user.UpdatedDate,
                CreatedDate = user.CreatedDate,
                Url = user.Url,
                ImageUrl = teacher.ImageUrl,
                IsApproved = teacher.IsApproved,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                Gender = user.Gender,
                BirthDate = user.BirthDate,
                Experience = teacher.About.Experience,
                OtherEducations = teacher.About.Education.OtherEducations,
                ShortInfo = teacher.About.ShortInfo,
                Title = teacher.Title,
                UniversityEducations = teacher.About.Education.UniversityEducations.Select(x => new UniversityEducationModel()
                {
                    Description = x.Description,
                    Education = x.Education,
                    University = x.University,
                }).ToList()
            };
            ViewBag.Universities = await _uniiversityService.GetAllAsync();
            return View(teacherEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(TeacherEditViewModel teacherEditViewModel, int teacherId)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.GetUserAsync(User);
                if (user == null) return NotFound();
                var usert = await _teacherService.GetTeacherByUserId(user.Id);
                var teacher = await _teacherService.GetTeacherFullDataAsync(usert.Id);
                if (teacher == null) return NotFound();
                var about = teacher.About;
                var education = teacher.About.Education;

                teacher.Title = teacherEditViewModel.Title;
                if (teacherEditViewModel.Image != null)
                {
                    teacher.ImageUrl = Jobs.UploadTeacherImage(teacherEditViewModel.Image);
                }
                else
                {
                    return View(teacherEditViewModel);
                }
                _teacherService.Update(teacher);

                about.Experience = teacherEditViewModel.Experience;
                about.ShortInfo = teacherEditViewModel.ShortInfo;
                _aboutService.Update(about);

                education.OtherEducations = teacherEditViewModel.OtherEducations;
                _educationService.Update(education);

                user.Gender = teacherEditViewModel.Gender;
                user.BirthDate = teacherEditViewModel.BirthDate;
                user.UpdatedDate = DateTime.Now;
                if (teacherEditViewModel.Email != user.Email)
                {
                    user.Email = teacherEditViewModel.Email;
                    user.EmailConfirmed = false;
                }
                user.FirstName = teacherEditViewModel.FirstName;
                user.LastName = teacherEditViewModel.LastName;
                user.NormalizedEmail = Jobs.NormalizedEmail(teacherEditViewModel.Email);
                user.NormalizedName = Jobs.NormalizedName(teacherEditViewModel.FirstName + teacherEditViewModel.LastName);
                bool logOut = !(user.UserName == teacherEditViewModel.UserName);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    if (logOut)
                    {
                        return RedirectToAction("Logout","Account");
                    }
                    return RedirectToAction("ShowProfile","Account");
                }
            }

            return View(teacherEditViewModel);
        }
        public async Task<JsonResult> DeleteUniversityEducation(int universityId, int educationId)
        {
            if (ModelState.IsValid)
            {
                var entity = await _universityEducationService.GetUniversityEducationByUniversityIdAndEducationIdAsync(universityId, educationId);

                _universityEducationService.Delete(entity);
            }
            else
            {
                return Json(false);
            }
            return Json(true);
        }

        public async Task<IActionResult> GetUniversityEducationPartial(int teacherId)
        {
            var teacher = await _teacherService.GetTeacherFullDataAsync(teacherId);
            var model = teacher.About.Education?.UniversityEducations.Select(x => new UniversityEducationModel()
            {
                Description = x.Description,
                Education = x.Education,
                University = x.University,
            }).ToList() ?? new List<UniversityEducationModel>();

            return PartialView("_UniversityEducationPartial", model);
        }

        public async Task<JsonResult> AddUniversityEducation(int teacherId, int universityId, string description)
        {
            if (ModelState.IsValid)
            {
                var teacher = await _teacherService.GetTeacherFullDataAsync(teacherId);

                var universityEducation = new UniversityEducation()
                {
                    Description = description,
                    UniversityId = universityId,
                    EducationId = teacher.About.EducationId
                };

                await _universityEducationService.CreateAsync(universityEducation);
            }
            else
                return Json(false);

            return Json(true);
        }

        #endregion

        
    }
}
