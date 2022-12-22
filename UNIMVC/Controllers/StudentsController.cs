using Microsoft.AspNetCore.Mvc;
using UNI.Domain.Contracts;
using UNI.Persistence.Models;
using UNI.Tests.Common.Exceptions;
using UNI.WebApi.Models;

namespace UNI.WebApi.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService<StudentModel> _studentService;
        public StudentsController(IStudentService<StudentModel> studentService)
        {
            _studentService = studentService;
        }


        [Route("Students/List/{id?}")]
        public async Task<ActionResult<List<StudentModel>>> List(int id, CancellationToken ct, int pg = 1)
        {
            if (id < 0)
                throw new NotFoundException(nameof(StudentModel), id);

            var students = await _studentService.ListAllAsync(id, ct);

            const int pageSize = 10;
            if (pg < 1)
            { pg = 1; }

            int recsCount = students.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = students.Skip(recSkip).Take(pageSize).ToList();

            this.ViewBag.Pager = pager;
            
            if (students.Count() == 0)
            {
                return View("NoStudents");
            }

            return View(data);
        }

        public async Task<ActionResult<StudentModel>> Create()
        {           
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult<StudentModel>> Create(StudentModel student,CancellationToken ct)
        {
            if (student == null || student.Id < 0)
                throw new NotFoundException(nameof(StudentModel), student);

            if (!ModelState.IsValid)
            {
                return View(student);
            }

            await _studentService.AddAsync(student,ct);
            return Redirect("List");
        }


        public async Task<ActionResult<StudentModel>> Contact(int id, CancellationToken ct)
        {
            if (id < 1)
                throw new NotFoundException(nameof(StudentModel), id);

            var studentContact = await _studentService.GetByIdAsync(id, ct);

            if (studentContact == null)
            { return View("NotFound"); }

            return View(studentContact);
        }

        public async Task<ActionResult<StudentModel>> Edit(int id, CancellationToken ct)
        {
            if (id < 1)
                throw new NotFoundException(nameof(StudentModel), id);

            var studentDetails = await _studentService.GetByIdAsync(id, ct);
            if (studentDetails == null)
            { return View("NotFound"); }
            return View(studentDetails);
        }

        [HttpPost]
        public async Task<ActionResult<StudentModel>> Edit(StudentModel student, CancellationToken ct)
        {
            await _studentService.UpdateAsync(student, ct);

            if (!ModelState.IsValid)
            {
                return View(student);
            }

            return RedirectToAction("List");
        }

        public async Task<ActionResult<StudentModel>> Delete(int id, CancellationToken ct)
        {
            if (id < 1)
                throw new NotFoundException(nameof(StudentModel), id);

            var studentContact = await _studentService.GetByIdAsync(id, ct);

            if (studentContact == null)
            { return View("NotFound"); }

            return View(studentContact);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult<StudentModel>> DeleteConfirmed(StudentModel student, CancellationToken ct)
        {
            await _studentService.DeleteAsync(student, ct);

            return RedirectToAction("List");
        }




    }
}
