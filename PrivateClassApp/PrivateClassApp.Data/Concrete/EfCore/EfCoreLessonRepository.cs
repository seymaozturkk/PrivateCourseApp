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
    public class EfCoreLessonRepository : EfCoreGenericRepository<Lesson>, ILessonRepository
    {
        public EfCoreLessonRepository(PrivateClassAppContext _appContext) : base(_appContext)
        {
        }
        PrivateClassAppContext AppContext
        {
            get { return _dbContext as PrivateClassAppContext; }
        }

        public async Task CreateLesson(Lesson lesson, int[] SelectedCategories)
        {
            await AppContext.Lessons.AddAsync(lesson);
            await AppContext.SaveChangesAsync();
            List<LessonCategory> lessonCategories = new List<LessonCategory>();
            foreach (var categoryId in SelectedCategories) 
            {
                lessonCategories.Add(new LessonCategory
                {
                    CategoryId = categoryId,
                    LessonId = lesson.Id
                });
            }
            AppContext.LessonCategories.AddRange(lessonCategories);
            await AppContext.SaveChangesAsync();
        }

        public async Task<List<Lesson>> GetAllFullDataAsync()
        {
            return await AppContext
                .Lessons
                .Include(l => l.LessonCategories)
                .ThenInclude(lc => lc.Category)
                .Include(l => l.Teacher)
                .ToListAsync();
        }

        public async Task<Lesson> GetByIdFullDataAsync(int id)
        {
            return await AppContext
                .Lessons
                .Where(l => l.Id == id)
                .Include(l => l.LessonCategories)
                .ThenInclude(lc => lc.Category)
                .Include(l => l.Teacher)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateLesson(Lesson lesson, int[] SelectedCategories)
        {
            Lesson newLesson = await AppContext
                .Lessons
                .Include(l => l.LessonCategories)
                .FirstOrDefaultAsync(l => l.Id == lesson.Id);
            newLesson.Name = lesson.Name;
            newLesson.Price = lesson.Price;
            newLesson.Description = lesson.Description;
            newLesson.Url = lesson.Url;
            newLesson.Teacher = lesson.Teacher;
            newLesson.CreatedDate = lesson.CreatedDate;
            newLesson.UpdatedDate = lesson.UpdatedDate;
            newLesson.LessonCategories = SelectedCategories
                .Select(sc => new LessonCategory
                {
                    LessonId = lesson.Id,
                    CategoryId = sc
                }).ToList();
            AppContext.Update(lesson);
            await AppContext.SaveChangesAsync();
        }
    }
}
