using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Data.Abstract
{
    public interface ILikeRepository : IGenericRepository<Like>
    {
        Task AddToLike(string userId, int lessonId);
        Task<Like> GetLikeByUserId(string userId);
    }
}
