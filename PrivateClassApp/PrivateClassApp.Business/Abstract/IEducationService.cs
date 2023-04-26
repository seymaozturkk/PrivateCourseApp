using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Abstract
{
    public interface IEducationService
    {
        public Task CreateAsync(Education education);
        public Task<Education> GetByIdAsync(int id);
        public Task<List<Education>> GetAllAsync();
        public void Update(Education education);
        public void Delete(Education education);
    }
}
