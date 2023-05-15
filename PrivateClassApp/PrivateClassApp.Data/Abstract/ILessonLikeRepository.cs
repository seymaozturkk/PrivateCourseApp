using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Data.Abstract
{
    public interface ILessonLikeRepository : IGenericRepository<LessonLike>
    {
        Task AddToLike(string userId, int lessonId);
        Task<LessonLike> GetLikeByUserId(string userId);
        public Task ClearLike(string likeId);
    }
}
