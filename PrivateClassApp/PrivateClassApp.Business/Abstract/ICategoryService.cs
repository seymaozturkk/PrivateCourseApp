using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Abstract
{
    public interface ICategoryService
    {
        public Task<string> GetCategoryNameByUrlAsync(string url);
        public Task CreateAsync(Category category);
        public Task<Category> GetByIdAsync(int id);
        public Task<List<Category>> GetAllAsync();
        public void Update(Category category);
        public void Delete(Category category);
    }
}
