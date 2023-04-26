using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Abstract
{
    public interface IUniversityService
    {
        public Task CreateAsync(University university);
        public Task<University> GetByIdAsync(int id);
        public Task<List<University>> GetAllAsync();
        public void Update(University university);
        public void Delete(University university);
        public Task<List<University>> GetUniversitiesByTeacher(string userId, int educationId);
    }
}
