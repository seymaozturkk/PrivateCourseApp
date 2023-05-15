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
    public class LessonLikeManager : ILessonLikeService
    {
        ILessonLikeRepository _likedItemRepository;

        public LessonLikeManager(ILessonLikeRepository likedItemRepository)
        {
            _likedItemRepository = likedItemRepository;
        }

        public async Task AddToLike(string userId, int lessonId)
        {
            await _likedItemRepository.AddToLike(userId, lessonId);
        }

        public async Task ClearLike(string likeId)
        {
            await _likedItemRepository.ClearLike(likeId);
        }

        public async Task CreateAsync(LessonLike likedItem)
        {
            await _likedItemRepository.CreateAsync(likedItem);
        }

        public void Delete(LessonLike likedItem)
        {
            _likedItemRepository.Delete(likedItem);
        }

        public async Task<List<LessonLike>> GetAllAsync()
        {
            return await _likedItemRepository.GetAllAsync();
        }

        public async Task<LessonLike> GetByIdAsync(int id)
        {
            return await _likedItemRepository.GetByIdAsync(id);
        }

        public async Task<LessonLike> GetLikeByUserId(string userId)
        {
            return await _likedItemRepository.GetLikeByUserId(userId);
        }

        public void Update(LessonLike likedItem)
        {
            _likedItemRepository.Update(likedItem);
        }
    }
}
