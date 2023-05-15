using Microsoft.AspNetCore.Mvc;
using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Entity.Concrete;
using PrivateClassApp.MVC.Models;

namespace PrivateClassApp.MVC.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
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
            return View(categoryViewModelList);
        }
        
    }
}
