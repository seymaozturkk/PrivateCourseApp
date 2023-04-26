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
    public class StudentManager : IStudentService
    {
        IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task CreateAsync(Student student)
        {
            await _studentRepository.CreateAsync(student);
        }

        public void Delete(Student student)
        {
            _studentRepository.Delete(student);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Student> GetStudentByUserId(string userId)
        {
            return await _studentRepository.GetStudentByUserId(userId);
        }

        public void Update(Student student)
        {
            _studentRepository.Update(student);
        }
    }
}
