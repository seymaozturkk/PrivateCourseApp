using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Abstract
{
    public interface ILikeService
    {
        public Task CreateAsync(Like like);
        public Task<Like> GetByIdAsync(int id);
        public Task<List<Like>> GetAllAsync();
        public void Update(Like like);
        public void Delete(Like like);
        public Task AddToLike(string userId, int lessonId);
        public Task<Like> GetLikeByUserId(string userId);
    }
}
