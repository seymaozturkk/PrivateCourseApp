using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Data.Abstract;
using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Concrete
{
    public class LessonManager : ILessonService
    {
        ILessonRepository _lessonRepository;

        public LessonManager(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task CreateAsync(Lesson lesson)
        {
            await _lessonRepository.CreateAsync(lesson);
        }

        public async Task CreateLesson(Lesson lesson, int[] SelectedCategories)
        {
            await _lessonRepository.CreateLesson(lesson, SelectedCategories);
        }

        public void Delete(Lesson lesson)
        {
            _lessonRepository.Delete(lesson);
        }

        public async Task<List<Lesson>> GetAllAsync()
        {
            return await _lessonRepository.GetAllAsync();
        }

        public async Task<List<Lesson>> GetAllFullDataAsync(string categoryurl)
        {
            return await _lessonRepository.GetAllFullDataAsync(categoryurl);
        }

        public async Task<Lesson> GetByIdAsync(int id)
        {
            return await _lessonRepository.GetByIdAsync(id);
        }

        public async Task<Lesson> GetByIdFullDataAsync(int id)
        {
            return await _lessonRepository.GetByIdFullDataAsync(id);
        }

        public void Update(Lesson lesson)
        {
            _lessonRepository.Update(lesson);
        }

        public async Task UpdateLesson(Lesson lesson, int[] SelectedCategories)
        {
            await _lessonRepository.UpdateLesson(lesson, SelectedCategories);
        }
    }
}
