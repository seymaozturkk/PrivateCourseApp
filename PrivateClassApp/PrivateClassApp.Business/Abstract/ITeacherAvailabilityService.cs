using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Abstract
{
    public interface ITeacherAvailabilityService
    {
        public Task CreateAsync(TeacherAvailability teacherAvailability);
        public Task<TeacherAvailability> GetByIdAsync(int id);
        public Task<List<TeacherAvailability>> GetAllAsync();
        public void Update(TeacherAvailability teacherAvailability);
        public void Delete(TeacherAvailability teacherAvailability);
    }
}
