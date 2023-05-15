using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Core;
using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.MVC.Areas.Admin.Models.ViewModels;

namespace PrivateClassApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]

	public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly INotyfService _notyfService;

        public CategoriesController(ICategoryService categoryService, INotyfService notyfService)
        {
            _categoryService = categoryService;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            List<CategoryViewModel> categoriesViewModel = new List<CategoryViewModel>();
            categoriesViewModel = categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                UpdatedDate = c.UpdatedDate,
                Name = c.Name
            }).ToList();
            return View(categoriesViewModel);
        }
        #region Kategori Ekleme
        [HttpGet]
        public IActionResult Create()
        {
            CategoryAddViewModel categoryAddViewModel = new CategoryAddViewModel();
            return View(categoryAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddViewModel categoryAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category
                {
                    Name = categoryAddViewModel.Name,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Url = Jobs.GetUrl(categoryAddViewModel.Name)
                };
                await _categoryService.CreateAsync(category);
                _notyfService.Success($"{category.Name} kategorisi eklenmiştir.");
                return RedirectToAction("Index");
            }
            return View(categoryAddViewModel);
        }
        #endregion
        #region Kategori Silme
        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _categoryService.GetByIdAsync(id);
            if (category != null) 
            {
                _categoryService.Delete(category);
            }
            return RedirectToAction("Index");
        }
        #endregion
        #region Kategori Düzenleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Category category = await _categoryService.GetByIdAsync(id);
            CategoryEditViewModel categoryEditViewModel = new CategoryEditViewModel()
            {
                Name = category.Name,
                CreatedDate = category.CreatedDate,
                UpdatedDate = category.UpdatedDate,
                Url = category.Url
            };
            return View(categoryEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditViewModel categoryEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = await _categoryService.GetByIdAsync(categoryEditViewModel.Id);
                category.Name = categoryEditViewModel.Name;
                category.Url = Jobs.GetUrl(categoryEditViewModel.Name);
                category.UpdatedDate = DateTime.Now;
                _categoryService.Update(category);
                return RedirectToAction("Index");
            }
            return View(categoryEditViewModel);
        }
        #endregion
    }
}
