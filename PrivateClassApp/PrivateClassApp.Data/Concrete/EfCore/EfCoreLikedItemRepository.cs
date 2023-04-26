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
    public class EfCoreLikedItemRepository : EfCoreGenericRepository<LikedItem>, ILikedItemRepository
    {
        public EfCoreLikedItemRepository(PrivateClassAppContext _appContext) : base(_appContext)
        {
        }
        PrivateClassAppContext AppContext
        {
            get { return _dbContext as PrivateClassAppContext; }
        }

        public async Task ClearLike(int likeId)
        {
            AppContext
                .LikedItems
                .Where(li => li.LikeId == likeId)
                .ExecuteDelete();
            await AppContext.SaveChangesAsync();

        }
    }
}
