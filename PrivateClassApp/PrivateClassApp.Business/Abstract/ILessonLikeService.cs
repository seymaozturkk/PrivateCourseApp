using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Abstract
{
    public interface ILessonLikeService
    {
        public Task CreateAsync(LessonLike likedItem);
        public Task<LessonLike> GetByIdAsync(int id);
        public Task<List<LessonLike>> GetAllAsync();
        public void Update(LessonLike likedItem);
        public void Delete(LessonLike likedItem);
        public Task AddToLike(string userId, int lessonId);
        public Task<LessonLike> GetLikeByUserId(string userId);
        public Task ClearLike(string likeId);
    }
}
