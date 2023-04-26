using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Abstract
{
    public interface IAboutService
    {
        public Task CreateAsync(About about);
        public Task<About> GetByIdAsync(int id);
        public Task<List<About>> GetAllAsync();
        public void Update(About about);
        public void Delete(About about);
    }
}
