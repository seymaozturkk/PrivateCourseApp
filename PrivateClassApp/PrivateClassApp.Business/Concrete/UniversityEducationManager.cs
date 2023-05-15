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
    public class UniversityEducationManager : IUniversityEducationService
    {
        IUniversityEducationRepository _universityEducationRepository;
        public UniversityEducationManager(IUniversityEducationRepository universityEducationRepository)
        {
            _universityEducationRepository = universityEducationRepository;
        }

        public async Task CreateAsync(UniversityEducation universityEducation)
        {
            await _universityEducationRepository.CreateAsync(universityEducation);
        }

        public void Delete(UniversityEducation universityEducation)
        {
            _universityEducationRepository.Delete(universityEducation);
        }

        public async Task<List<UniversityEducation>> GetAllAsync()
        {
            return await _universityEducationRepository.GetAllAsync();
        }

        public async Task<UniversityEducation> GetByIdAsync(int id)
        {
            return await _universityEducationRepository.GetByIdAsync(id);
        }

        public async Task<UniversityEducation> GetUniversityEducationByUniversityIdAndEducationIdAsync(int universityId, int educationId)
        {
            return await _universityEducationRepository.GetUniversityEducationByUniversityIdAndEducationIdAsync(universityId, educationId);
        }

        public void Update(UniversityEducation universityEducation)
        {
            _universityEducationRepository.Update(universityEducation);
        }
    }
}
