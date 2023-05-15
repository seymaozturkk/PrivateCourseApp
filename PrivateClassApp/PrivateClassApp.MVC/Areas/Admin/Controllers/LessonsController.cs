using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

	public class LessonsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILessonService _lessonService;
        private readonly ITeacherService _teacherService;
        private readonly ICategoryService _categoryService;
        private readonly INotyfService _notyfService;

        public LessonsController(ILessonService lessonService, ITeacherService teacherService, ICategoryService categoryService, Microsoft.AspNetCore.Identity.UserManager<User> userManager, INotyfService notyfService)
        {
            _lessonService = lessonService;
            _teacherService = teacherService;
            _categoryService = categoryService;
            _userManager = userManager;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var lessons = await _lessonService.GetAllFullDataAsync(null);
            var teachers = await _teacherService.GetAllAsync();
            List<LessonViewModel> lessonList = new List<LessonViewModel>();
            lessonList = lessons.Select(l => new LessonViewModel
            {
                Id = l.Id,
                UpdatedDate = l.UpdatedDate,
                Name = l.Name,
                Price = l.Price,
                Teacher = teachers.Where(t => t.Id == l.Teacher.Id).FirstOrDefault(),
                User = _userManager.Users.FirstOrDefault(u => u.Id == l.Teacher.UserId)
            }).ToList();
            return View(lessonList);
        }
        #region Ders Düzenleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await _userManager.GetUsersInRoleAsync("User");
            Lesson lesson = await _lessonService.GetByIdFullDataAsync(id);
            if (lesson == null) return NotFound();
            LessonEditViewModel lessonEditViewModel = new LessonEditViewModel();

            lessonEditViewModel.Id = lesson.Id;
            lessonEditViewModel.Name = lesson.Name;
            lessonEditViewModel.UpdatedDate = lesson.UpdatedDate;
            lessonEditViewModel.CreatedDate = lesson.CreatedDate;
            lessonEditViewModel.Url = lesson.Url;
            lessonEditViewModel.Price = lesson.Price;
            lessonEditViewModel.Description = lesson.Description;
            lessonEditViewModel.TeacherId = lesson.TeacherId;
            lessonEditViewModel.SelectedCategories = lesson.LessonCategories.Select(lc => lc.Category.Id).ToArray();
            lessonEditViewModel.Categories = await _categoryService.GetAllAsync();
            lessonEditViewModel.Teachers = await _teacherService.GetAllFullDataAsync();
        
            return View(lessonEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LessonEditViewModel lessonEditViewModel)
        {
            await _userManager.GetUsersInRoleAsync("User");

            if (lessonEditViewModel == null) return NotFound();
            if (ModelState.IsValid)
            {
                Lesson lesson = await _lessonService.GetByIdFullDataAsync(lessonEditViewModel.Id);
                lesson.Name = lessonEditViewModel.Name;
                lesson.Url = Jobs.GetUrl(lessonEditViewModel.Name);
                lesson.CreatedDate = lesson.CreatedDate;
                lesson.UpdatedDate = DateTime.Now;
                lesson.Description = lessonEditViewModel.Description;
                lesson.Teacher = await _teacherService.GetByIdAsync(lessonEditViewModel.TeacherId);
                lesson.Price = lessonEditViewModel.Price;

                await _lessonService.UpdateLesson(lesson, lessonEditViewModel.SelectedCategories);

                _notyfService.Success("Ders başarıyla güncellendi.");
                return RedirectToAction("Index");
            }
            lessonEditViewModel.Categories = await _categoryService.GetAllAsync();
            lessonEditViewModel.Teachers = await _teacherService.GetAllFullDataAsync();
            return View(lessonEditViewModel);
        }
        #endregion
        #region Ders Ekleme
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await _userManager.GetUsersInRoleAsync("User");
            LessonAddViewModel lessonAddViewModel = new LessonAddViewModel();
			lessonAddViewModel.Categories = await _categoryService.GetAllAsync();
			lessonAddViewModel.Teachers = await _teacherService.GetAllFullDataAsync();
			return View(lessonAddViewModel);
        }
        [HttpPost]
		public async Task<IActionResult> Create(LessonAddViewModel lessonAddViewModel)
        {
            await _userManager.GetUsersInRoleAsync("User");

            if (lessonAddViewModel == null) return NotFound();
            if (ModelState.IsValid)
            {
                Lesson lesson = new Lesson();

                lesson.Name = lessonAddViewModel.Name;
                lesson.Url = Jobs.GetUrl(lessonAddViewModel.Name);
                lesson.CreatedDate = DateTime.Now;
                lesson.UpdatedDate = DateTime.Now;
                lesson.Description = lessonAddViewModel.Description;
                lesson.Teacher = await _teacherService.GetByIdAsync(lessonAddViewModel.TeacherId);
                lesson.Price = lessonAddViewModel.Price;

                await _lessonService.CreateLesson(lesson, lessonAddViewModel.SelectedCategories);

                _notyfService.Success("Ders başarıyla eklendi.");
                return RedirectToAction("Index");
            }
            lessonAddViewModel.Categories = await _categoryService.GetAllAsync();
            lessonAddViewModel.Teachers = await _teacherService.GetAllFullDataAsync();
            return View(lessonAddViewModel);
        }
        #endregion
        #region Ders Silme
        public async Task<IActionResult> Delete(int id)
        {
            Lesson lesson = await _lessonService.GetByIdAsync(id);
            if (lesson == null) return NotFound();
            _lessonService.Delete(lesson);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
