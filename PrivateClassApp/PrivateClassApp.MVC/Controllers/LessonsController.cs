using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Core;
using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.Entity.Concrete.Identity;
using PrivateClassApp.MVC.Models;

namespace PrivateClassApp.MVC.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly ICategoryService _categoryService;
        private readonly ITeacherService _teacherService;
        private readonly UserManager<User> _userManager;
        private readonly IAboutService _aboutService;

        public LessonsController(ILessonService lessonService, ICategoryService categoryService, ITeacherService teacherService, UserManager<User> userManager, IAboutService aboutService)
        {
            _lessonService = lessonService;
            _categoryService = categoryService;
            _teacherService = teacherService;
            _userManager = userManager;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index(string categoryurl)
        {
            await _aboutService.GetAllAsync();
            await _userManager.GetUsersInRoleAsync("User");
            await _teacherService.GetAllAsync();
            await _categoryService.GetAllAsync();
            List<Lesson> lessons = await _lessonService.GetAllFullDataAsync(categoryurl);
            List<LessonModel> lessonModels = new List<LessonModel>();
            lessonModels = lessons.Select(l => new LessonModel
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                UpdatedDate = l.UpdatedDate,
                Url = l.Url,
                Price = l.Price,
                Teacher = l.Teacher,
                Categories = l.LessonCategories.Select(bc => bc.Category).ToList()
            }).ToList();
            if (RouteData.Values["categoryurl"] != null)
            {
                ViewBag.SelectedCategoryName = await _categoryService.GetCategoryNameByUrlAsync(RouteData.Values["categoryurl"].ToString());
            }
            return View(lessonModels);
        }
       

    }
}
