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
    public class EfCoreLikeRepository : EfCoreGenericRepository<Like>, ILikeRepository
    {
        public EfCoreLikeRepository(PrivateClassAppContext _appContext) : base(_appContext)
        {
        }
        PrivateClassAppContext AppContext
        {
            get { return _dbContext as PrivateClassAppContext; }
        }

        public async Task AddToLike(string userId, int lessonId)
        {
            var like = await GetLikeByUserId(userId);
            var likedItem = await AppContext.LikedItems.Where(li => li.LessonId==lessonId).FirstOrDefaultAsync();
            if (like != null)
            {
                var index = like.LikedItems.FindIndex(li => li.LessonId==lessonId);
                if (index != -1)
                {
                    like.LikedItems.Remove(likedItem);
                }
                else
                {
                    like.LikedItems.Add(new LikedItem
                    {
                        LessonId = lessonId,
                        LikeId = like.Id
                    });
                }
            }
        }

        public async Task<Like> GetLikeByUserId(string userId)
        {
            return await AppContext
                .Likes
                .Include(l => l.LikedItems)
                .ThenInclude(li => li.Lesson)
                .FirstOrDefaultAsync();
        }
    }
}
