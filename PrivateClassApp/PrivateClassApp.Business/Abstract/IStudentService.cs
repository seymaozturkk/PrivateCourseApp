using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Abstract
{
    public interface IStudentService
    {
        public Task CreateAsync(Student student);
        public Task<Student> GetByIdAsync(int id);
        public Task<List<Student>> GetAllAsync();
        public void Update(Student student);
        public void Delete(Student student);
        public Task<Student> GetStudentByUserId(string userId);

    }
}
