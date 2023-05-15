using Microsoft.EntityFrameworkCore;
using PrivateClassApp.Data.Abstract;
using PrivateClassApp.Data.Context;
using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Data.Concrete.EfCore
{
    public class EfCoreUniversityEducationRepository : EfCoreGenericRepository<UniversityEducation>, IUniversityEducationRepository
    {
        public EfCoreUniversityEducationRepository(PrivateClassAppContext _appContext) : base(_appContext)
        {
        }
        PrivateClassAppContext AppContext
        {
            get { return _dbContext as PrivateClassAppContext; }
        }

        public async Task<UniversityEducation> GetUniversityEducationByUniversityIdAndEducationIdAsync(int universityId, int educationId)
        {
            return await AppContext
                .UniversityEducations
                .FirstOrDefaultAsync(x => x.UniversityId == universityId && x.EducationId == educationId);
        }
    }
}
