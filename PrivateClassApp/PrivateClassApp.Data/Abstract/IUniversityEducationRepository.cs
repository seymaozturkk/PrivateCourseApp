using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Data.Abstract
{
    public interface IUniversityEducationRepository : IGenericRepository<UniversityEducation>
    {
        Task<UniversityEducation> GetUniversityEducationByUniversityIdAndEducationIdAsync(int universityId, int educationId);
    }
}
