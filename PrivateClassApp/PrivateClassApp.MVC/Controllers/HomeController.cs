using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.Entity.Concrete.Identity;
using PrivateClassApp.MVC.Models;
using System.Diagnostics;
using System.Linq;

namespace PrivateClassApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly ITeacherService _teacherService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<User> _userManager;
        private readonly IStudentService _studentService;
        private readonly IAboutService _aboutService;

        public HomeController(ILessonService lessonService, ITeacherService teacherService, ICategoryService categoryService, UserManager<User> userManager, IStudentService studentService, IAboutService aboutService)
        {
            _lessonService = lessonService;
            _teacherService = teacherService;
            _categoryService = categoryService;
            _userManager = userManager;
            _studentService = studentService;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            await _aboutService.GetAllAsync();
            await _categoryService.GetAllAsync();
            await _userManager.GetUsersInRoleAsync("User");
            var teachers = await _teacherService.GetAllAsync();
            var students = await _studentService.GetAllAsync();
            //Burada daha sonra en çok rezervasyon alan kullanıcılara göre çekeceğiz verileri
            List<Lesson> lessons = await _lessonService.GetAllFullDataAsync(null);
            List<LessonModel> lessonViewModels = new List<LessonModel>();
            lessonViewModels = lessons.Select(l => new LessonModel
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                Price = l.Price,
                UpdatedDate = l.UpdatedDate,
                Url = l.Url,
                Teacher = l.Teacher,
                Categories = l.LessonCategories.Select(bc => bc.Category).ToList()
            }).ToList();
            ViewBag.TeachersCount = $"{teachers.Count()}";
            ViewBag.StudentsCount = $"{students.Count()}";

            return View(lessonViewModels);
        }

    }
}