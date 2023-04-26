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
    public class EfCoreUniversityRepository : EfCoreGenericRepository<University>, IUniversityRepository
    {
        public EfCoreUniversityRepository(PrivateClassAppContext _appContext) : base(_appContext)
        {
        }
        PrivateClassAppContext AppContext
        {
            get { return _dbContext as PrivateClassAppContext; }
        }

        public async Task<List<University>> GetUniversitiesByTeacher(string userId, int educationId)
        {
            return await AppContext
                .Universities
                .Include(x => x.UniversityEducations)
                .ThenInclude(x => x.Education)
                .ThenInclude(x => x.About)
                .Where(x => x.UniversityEducations.Any(x => x.EducationId == educationId))
                .ToListAsync();
        }
    }
}
