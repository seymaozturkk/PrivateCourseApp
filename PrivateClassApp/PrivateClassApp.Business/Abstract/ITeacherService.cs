using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Abstract
{
    public interface ITeacherService
    {
        public Task CreateAsync(Teacher teacher);
        public Task<Teacher> GetByIdAsync(int id);
        public Task<List<Teacher>> GetAllAsync();
        public void Update(Teacher teacher);
        public void Delete(Teacher teacher);
        Task<List<Teacher>> GetAllFullDataAsync();
        public Task<Teacher> GetTeacherByUserId(string userId);
        public Task CreateTeacherAsync(Teacher teacher);
		Task<Teacher> GetTeacherFullDataAsync(int id);


	}
}
