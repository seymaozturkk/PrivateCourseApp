using Microsoft.AspNetCore.Mvc;
using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.MVC.Areas.Admin.Models.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace PrivateClassApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly ITeacherService _teacherService;
        private readonly ICategoryService _categoryService;

        public HomeController(ILessonService lessonService, ITeacherService teacherService, ICategoryService categoryService)
        {
            _lessonService = lessonService;
            _teacherService = teacherService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            //CategoryViewModel categoryViewModel = new CategoryViewModel()
            //{
            //    Name = 
            //};
            return View();
        }

    }
}