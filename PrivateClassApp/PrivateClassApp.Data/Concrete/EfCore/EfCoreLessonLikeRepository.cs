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
    public class EfCoreLessonLikeRepository : EfCoreGenericRepository<LessonLike>, ILessonLikeRepository
    {
        public EfCoreLessonLikeRepository(PrivateClassAppContext _appContext) : base(_appContext)
        {
        }
        PrivateClassAppContext AppContext
        {
            get { return _dbContext as PrivateClassAppContext; }
        }

        public async Task AddToLike(string userId, int lessonId)
        {
            //var like = await GetLikeByUserId(userId);
            //var likedItem = await AppContext.LessonLikes.Where(li => li.LessonId == lessonId).FirstOrDefaultAsync();
            //if (like != null)
            //{
            //    var index = like.LessonLikes.FindIndex(li => li.LessonId == lessonId);
            //    if (index != -1)
            //    {
            //        like.LessonLikes.Remove(likedItem);
            //    }
            //    else
            //    {
            //        like.LessonLikes.Add(new LessonLike
            //        {
            //            LessonId = lessonId,
            //            LikeId = like.UserId
            //        });
            //    }
            //}
        }

        public async Task ClearLike(string likeId)
        {
            //AppContext
            //    .LessonLikes
            //    .Where(li => li.LikeId == likeId)
            //    .ExecuteDelete();
            //await AppContext.SaveChangesAsync();

        }

        public async Task<LessonLike> GetLikeByUserId(string userId)
        {
            //return await AppContext
            //    .Likes
            //    .Include(l => l.LessonLikes)
            //    .ThenInclude(li => li.Lesson)
            //    .FirstOrDefaultAsync();
            return null;
        }
    }
}
