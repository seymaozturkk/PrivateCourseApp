using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Data.Abstract
{
    public interface ITeacherAvailabilityRepository : IGenericRepository<TeacherAvailability>
    {
        public Task<List<TeacherAvailability>> GetAvailabilitiesByTeacherIdAsync(int id);
        public Task<TeacherAvailability> GetAvailabilityByTeacherIdByTimeAsync(int id, TimeSpan time);

    }
}
