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
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        public EfCoreTeacherRepository(PrivateClassAppContext _appContext) : base(_appContext)
        {
        }
        PrivateClassAppContext AppContext
        {
            get { return _dbContext as PrivateClassAppContext; }
        }

        public async Task CreateTeacherAsync(Teacher teacher)
        {
            Education education = new Education();
            await AppContext.Educations.AddAsync(education);
            await AppContext.SaveChangesAsync();

            About about = new About();
            about.EducationId = education.Id;
            await AppContext.Abouts.AddAsync(about);
            await AppContext.SaveChangesAsync();

            teacher.AboutId = about.Id;
            await AppContext.Teachers.AddAsync(teacher);
            await AppContext.SaveChangesAsync();

            TeacherAvailability teacherAvailability = new TeacherAvailability();
            teacherAvailability.TeacherId = teacher.Id;
            await AppContext.TeacherAvailabilities.AddAsync(teacherAvailability);
            await AppContext.SaveChangesAsync();

        }

        public async Task<List<Teacher>> GetAllFullDataAsync()
        {
            return await AppContext
                .Teachers
                .Include(t => t.About)
                .Include(t => t.Lessons)
                .Include(t => t.TeacherAvailabilities)
                .ToListAsync();
        }

        public async Task<Teacher> GetTeacherByUserId(string userId)
        {
            return await AppContext
                .Teachers
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();
        }
    }
}
