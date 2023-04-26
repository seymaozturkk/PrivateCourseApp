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
    public class UniversityManager : IUniversityService
    {
        IUniversityRepository _universityRepository;

        public UniversityManager(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        public async Task CreateAsync(University university)
        {
            await _universityRepository.CreateAsync(university);
        }

        public void Delete(University university)
        {
            _universityRepository.Delete(university);
        }

        public async Task<List<University>> GetAllAsync()
        {
            return await _universityRepository.GetAllAsync();
        }

        public async Task<University> GetByIdAsync(int id)
        {
            return await _universityRepository.GetByIdAsync(id);
        }

        public async Task<List<University>> GetUniversitiesByTeacher(string userId, int educationId)
        {
            return await _universityRepository.GetUniversitiesByTeacher(userId, educationId);
        }

        public void Update(University university)
        {
            _universityRepository.Update(university);
        }
    }
}
