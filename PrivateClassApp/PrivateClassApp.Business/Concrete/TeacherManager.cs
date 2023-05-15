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
    public class TeacherManager : ITeacherService
    {
        ITeacherRepository _teacherRepository;

        public TeacherManager(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task CreateAsync(Teacher teacher)
        {
            await _teacherRepository.CreateAsync(teacher);
        }

        public async Task CreateTeacherAsync(Teacher teacher)
        {
            await _teacherRepository.CreateTeacherAsync(teacher);
        }

        public void Delete(Teacher teacher)
        {
            _teacherRepository.Delete(teacher);
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<List<Teacher>> GetAllFullDataAsync()
        {
            return await _teacherRepository.GetAllFullDataAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _teacherRepository.GetByIdAsync(id);
        }

        public async Task<Teacher> GetTeacherByUserId(string userId)
        {
            return await _teacherRepository.GetTeacherByUserId(userId);
        }

		public async Task<Teacher> GetTeacherFullDataAsync(int id)
		{
            return await _teacherRepository.GetTeacherFullDataAsync(id);
		}

		public void Update(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
        }
    }
}
