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
    public class AboutManager : IAboutService
    {
        private IAboutRepository _aboutRepository;

        public AboutManager(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task CreateAsync(About about)
        {
            await _aboutRepository.CreateAsync(about);
        }

        public void Delete(About about)
        {
            _aboutRepository.Delete(about);
        }

        public async Task<List<About>> GetAllAsync()
        {
            return await _aboutRepository.GetAllAsync();
        }

        public async Task<About> GetByIdAsync(int id)
        {
            return await _aboutRepository.GetByIdAsync(id);
        }

        public void Update(About about)
        {
            _aboutRepository.Update(about);
        }
    }
}
