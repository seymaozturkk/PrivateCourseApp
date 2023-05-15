using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Data.Abstract
{
    public interface ILessonRepository : IGenericRepository<Lesson>
    {
        Task<List<Lesson>> GetAllFullDataAsync(string categoryurl);
        Task<Lesson> GetByIdFullDataAsync(int id);
        Task UpdateLesson(Lesson lesson, int[] SelectedCategories);
        Task CreateLesson(Lesson lesson, int[] SelectedCategories);


    }
}
