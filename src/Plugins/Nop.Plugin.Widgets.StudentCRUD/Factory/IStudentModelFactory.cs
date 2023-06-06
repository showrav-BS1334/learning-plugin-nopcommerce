using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.StudentCRUD.Domain;
using Nop.Plugin.Widgets.StudentCRUD.Models;

namespace Nop.Plugin.Widgets.StudentCRUD.Factory
{
    public interface IStudentModelFactory
    {
        public Task<IEnumerable<StudentViewModel>> PrepareStudentListModelAsync();
        public Task<StudentViewModel> PrepareStudentModelAsync(int id);
        public Task<Student> PrepareStudentAsync(int id);
        public Task<Student> PrepareStudentDomainAsync(StudentViewModel model);
    }
}
