using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Abstract
{
    public interface ILikedItemService
    {
        public Task CreateAsync(LikedItem likedItem);
        public Task<LikedItem> GetByIdAsync(int id);
        public Task<List<LikedItem>> GetAllAsync();
        public void Update(LikedItem likedItem);
        public void Delete(LikedItem likedItem);
        public Task ClearLike(int likeId);
    }
}
