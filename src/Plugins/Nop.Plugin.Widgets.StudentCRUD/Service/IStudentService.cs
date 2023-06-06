using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.StudentCRUD.Domain;

namespace Nop.Plugin.Widgets.StudentCRUD.Service
{
    public interface IStudentService
    {
        public Task<Student> GetStudentByIdAsync(int studentId);
        public Task DeleteStudentAsync(Student student);
        public Task InsertStudentAsync(Student student);
        public Task UpdateStudentAsync(Student student);
        public Task<IList<Student>> GetAllStudentsAsync();
    }
}
