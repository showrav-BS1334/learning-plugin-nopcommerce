using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.StudentCRUD.Domain;
using Nop.Plugin.Widgets.StudentCRUD.Models;
using Nop.Plugin.Widgets.StudentCRUD.Service;

namespace Nop.Plugin.Widgets.StudentCRUD.Factory
{
    internal class StudentModelFactory : IStudentModelFactory
    {
        private readonly IStudentService _studentService;
        public StudentModelFactory(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IEnumerable<StudentViewModel>> PrepareStudentListModelAsync()
        {
            // service theke list niye then send korbo
            // _studentService.GetAllStudentsAsync().Result -> eita asole ekta sudent type er list
            // convert it to a list of studentviewmodel

            var students = _studentService.GetAllStudentsAsync().Result;
            var model = new List<StudentViewModel>();

            foreach (var student in students)
            {
                model.Add(new StudentViewModel
                {
                    Id = student.Id,
                    Name = student.Name,
                    Age = student.Age
                });
            }

            return model;
        }

        public async Task<StudentViewModel> PrepareStudentModelAsync(int id)
        {
            var student = _studentService.GetStudentByIdAsync(id).Result;
            var model = new StudentViewModel
            {
                Id = id,
                Name = student.Name,
                Age = student.Age
            };
            return model;
        }

        public async Task<Student> PrepareStudentAsync(int id)
        {
            var student = _studentService.GetStudentByIdAsync(id).Result;
            return student;
        }

        public async Task<Student> PrepareStudentDomainAsync(StudentViewModel model)
        {
            var student = new Student
            {
                Id = model.Id,
                Name = model.Name,
                Age = model.Age
            };
            return student;
        }
    }
}
