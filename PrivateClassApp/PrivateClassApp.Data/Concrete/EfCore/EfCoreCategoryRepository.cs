using Microsoft.EntityFrameworkCore;
using PrivateClassApp.Data.Abstract;
using PrivateClassApp.Data.Context;
using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(PrivateClassAppContext _appContext) : base(_appContext)
        {
        }
        PrivateClassAppContext AppContext
        {
            get { return _dbContext as PrivateClassAppContext; }
        }

        public async Task<string> GetCategoryNameByUrlAsync(string url)
        {
            Category category = await AppContext
                .Categories
                .Where(c => c.Url == url)
                .FirstOrDefaultAsync();
            return category.Name;
        }
    }
}
