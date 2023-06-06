using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Widgets.StudentCRUD.Domain;

namespace Nop.Plugin.Widgets.StudentCRUD.Service
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public virtual async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await _studentRepository.GetByIdAsync(studentId);
        }

        public virtual async Task DeleteStudentAsync(Student student)
        {
            await _studentRepository.DeleteAsync(student);
        }

        public virtual async Task InsertStudentAsync(Student student)
        {
            await _studentRepository.InsertAsync(student);
        }

        public virtual async Task UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
        }
        
        public virtual async Task<IList<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync(query =>
            {
                query = query.Where(x => x.Id > 0);
                return query;
            });
        }
    }
}
