using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.StudentCRUD.Factory;
using Nop.Plugin.Widgets.StudentCRUD.Models;
using Nop.Plugin.Widgets.StudentCRUD.Service;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.StudentCRUD.Controller
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class StudentController : BasePluginController
    {
        private readonly IStudentService _studentService;
        private readonly IStudentModelFactory _studentModelFactory;
        public StudentController(IStudentService studentService, IStudentModelFactory studentFactory)
        {
            _studentService = studentService;
            _studentModelFactory = studentFactory;
        }

        public ActionResult Index()
        {
            var model = _studentModelFactory.PrepareStudentListModelAsync().Result;
            return View("~/Plugins/Widgets.StudentCRUD/Views/Student/Index.cshtml", model);
        }

        public ActionResult Create()
        {
            var model = new StudentViewModel();
            return View("~/Plugins/Widgets.StudentCRUD/Views/Student/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel model)
        {
            if (model == null)
            { return NotFound(); }
            var student = _studentModelFactory.PrepareStudentDomainAsync(model).Result;
            _studentService.InsertStudentAsync(student);
            return RedirectToAction("Index", "Student");
        }

        public ActionResult Edit(int id)
        {
            var model = _studentModelFactory.PrepareStudentModelAsync(id).Result;
            return View("~/Plugins/Widgets.StudentCRUD/Views/Student/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel model)
        {
            if (ModelState.IsValid || model != null)
            {
                var student = _studentModelFactory.PrepareStudentDomainAsync(model).Result;
                _studentService.UpdateStudentAsync(student);
                return RedirectToAction("Index", "Student");
            }
            return RedirectToAction("Index", "Student");
        }

        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid || id > 0)
            {
                var student = _studentModelFactory.PrepareStudentAsync(id).Result;
                _studentService.DeleteStudentAsync(student);
                return RedirectToAction("Index", "Student");
            }
            return RedirectToAction("Index", "Student");
        }
    }
}