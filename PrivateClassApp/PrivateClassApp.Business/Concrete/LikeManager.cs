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
    public class LikeManager : ILikeService
    {
        ILikeRepository _likeRepository;

        public LikeManager(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task AddToLike(string userId, int lessonId)
        {
            await _likeRepository.AddToLike(userId, lessonId);
        }

        public async Task CreateAsync(Like like)
        {
            await _likeRepository.CreateAsync(like);
        }

        public void Delete(Like like)
        {
            _likeRepository.Delete(like);
        }

        public async Task<List<Like>> GetAllAsync()
        {
            return await _likeRepository.GetAllAsync();
        }

        public async Task<Like> GetByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<Like> GetLikeByUserId(string userId)
        {
            return await _likeRepository.GetLikeByUserId(userId);
        }

        public void Update(Like like)
        {
            _likeRepository.Update(like);
        }
    }
}
