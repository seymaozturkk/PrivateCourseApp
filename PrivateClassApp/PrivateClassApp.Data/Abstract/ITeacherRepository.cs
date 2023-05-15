using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Data.Abstract
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<List<Teacher>> GetAllFullDataAsync();
        Task<Teacher> GetTeacherByUserId(string userId);
		Task<Teacher> GetTeacherFullDataAsync(int id);
		public Task CreateTeacherAsync(Teacher teacher);
    }
}
