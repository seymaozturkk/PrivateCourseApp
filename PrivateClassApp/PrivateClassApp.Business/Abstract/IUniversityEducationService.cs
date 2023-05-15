using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Abstract
{
    public interface IUniversityEducationService
    {
        public Task CreateAsync(UniversityEducation universityEducation);
        public Task<UniversityEducation> GetByIdAsync(int id);
        public Task<List<UniversityEducation>> GetAllAsync();
        public void Update(UniversityEducation universityEducation);
        public void Delete(UniversityEducation universityEducation);
        Task<UniversityEducation> GetUniversityEducationByUniversityIdAndEducationIdAsync(int universityId, int educationId);
    }
}
