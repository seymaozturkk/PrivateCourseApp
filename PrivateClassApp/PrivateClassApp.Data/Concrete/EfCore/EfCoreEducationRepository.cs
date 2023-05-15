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
    public class EfCoreEducationRepository : EfCoreGenericRepository<Education>, IEducationRepository
    {
        public EfCoreEducationRepository(PrivateClassAppContext _appContext) : base(_appContext)
        {
        }
        PrivateClassAppContext AppContext
        {
            get { return _dbContext as PrivateClassAppContext; }
        }

		public async Task<Education> GetEducationFullDataAsync(int id)
		{
            return await AppContext
                .Educations
                .Where(x => x.Id == id)
                .Include(x => x.UniversityEducations)
                .ThenInclude(x => x.University)
                .Include(x => x.About)
                .ThenInclude(x => x.Teacher)
                .FirstOrDefaultAsync();
		}
	}
}
