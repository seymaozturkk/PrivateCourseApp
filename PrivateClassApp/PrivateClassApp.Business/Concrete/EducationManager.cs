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
    public class EducationManager : IEducationService
    {
        IEducationRepository _educationRepository;

        public EducationManager(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task CreateAsync(Education education)
        {
            await _educationRepository.CreateAsync(education);
        }

        public void Delete(Education education)
        {
            _educationRepository.Delete(education);
        }

        public Task<List<Education>> GetAllAsync()
        {
            return _educationRepository.GetAllAsync();
        }

        public async Task<Education> GetByIdAsync(int id)
        {
            return await _educationRepository.GetByIdAsync(id);
        }

		public async Task<Education> GetEducationFullDataAsync(int id)
		{
            return await _educationRepository.GetEducationFullDataAsync(id);
		}

		public void Update(Education education)
        {
            _educationRepository.Update(education);
        }
    }
}
