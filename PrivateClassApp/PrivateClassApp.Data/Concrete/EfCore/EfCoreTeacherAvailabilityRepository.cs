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
    public class EfCoreTeacherAvailabilityRepository : EfCoreGenericRepository<TeacherAvailability>, ITeacherAvailabilityRepository
    {
        public EfCoreTeacherAvailabilityRepository(PrivateClassAppContext _appContext) : base(_appContext)
        {
        }
        PrivateClassAppContext AppContext
        {
            get { return _dbContext as PrivateClassAppContext; }
        }

        public async Task<List<TeacherAvailability>> GetAvailabilitiesByTeacherIdAsync(int id)
        {
            return await AppContext
                .TeacherAvailabilities
                .Where(ta => ta.TeacherId == id)
                .ToListAsync();

        }

        public async Task<TeacherAvailability> GetAvailabilityByTeacherIdByTimeAsync(int id, TimeSpan time)
        {
            return await AppContext
                .TeacherAvailabilities
                .Where(ta => ta.TeacherId == id)
                .Where(ta => ta.Time==time)
                .FirstOrDefaultAsync();
        }
    }
}
