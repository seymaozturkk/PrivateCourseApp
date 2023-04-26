using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Data.Abstract;
using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Concrete
{
    public class LikedItemManager : ILikedItemService
    {
        ILikedItemRepository _likedItemRepository;

        public LikedItemManager(ILikedItemRepository likedItemRepository)
        {
            _likedItemRepository = likedItemRepository;
        }

        public async Task ClearLike(int likeId)
        {
            await _likedItemRepository.ClearLike(likeId);
        }

        public async Task CreateAsync(LikedItem likedItem)
        {
            await _likedItemRepository.CreateAsync(likedItem);
        }

        public void Delete(LikedItem likedItem)
        {
            _likedItemRepository.Delete(likedItem);
        }

        public async Task<List<LikedItem>> GetAllAsync()
        {
            return await _likedItemRepository.GetAllAsync();
        }

        public async Task<LikedItem> GetByIdAsync(int id)
        {
            return await _likedItemRepository.GetByIdAsync(id);
        }

        public void Update(LikedItem likedItem)
        {
            _likedItemRepository.Update(likedItem);
        }
    }
}
