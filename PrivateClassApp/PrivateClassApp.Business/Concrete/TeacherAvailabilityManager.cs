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
    public class TeacherAvailabilityManager : ITeacherAvailabilityService
    {
        ITeacherAvailabilityRepository _repository;

        public TeacherAvailabilityManager(ITeacherAvailabilityRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(TeacherAvailability teacherAvailability)
        {
            await _repository.CreateAsync(teacherAvailability);
        }

        public void Delete(TeacherAvailability teacherAvailability)
        {
            _repository.Delete(teacherAvailability);
        }

        public async Task<List<TeacherAvailability>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TeacherAvailability> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Update(TeacherAvailability teacherAvailability)
        {
            _repository.Update(teacherAvailability);
        }
    }
}
