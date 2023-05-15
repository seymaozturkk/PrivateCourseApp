using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Abstract
{
    public interface ILessonService
    {
        public Task CreateAsync(Lesson lesson);
        public Task<Lesson> GetByIdAsync(int id);
        public Task<List<Lesson>> GetAllAsync();
        public void Update(Lesson lesson);
        public void Delete(Lesson lesson);
        public Task<List<Lesson>> GetAllFullDataAsync(string categoryurl);
        public Task<Lesson> GetByIdFullDataAsync(int id);
        public Task UpdateLesson(Lesson lesson, int[] SelectedCategories);
        public Task CreateLesson(Lesson lesson, int[] SelectedCategories);
    }
}
