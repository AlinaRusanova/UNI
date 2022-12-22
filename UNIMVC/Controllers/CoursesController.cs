using Microsoft.AspNetCore.Mvc;
using UNI.Domain.Contracts;
using UNI.Domain.Entities;
using UNI.Persistence.Models;
using UNI.Tests.Common.Exceptions;

namespace UNI.WebApi.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService<CourseModel> _courseService;
        public CoursesController(ICourseService<CourseModel> courseService)
        {
            _courseService = courseService;
        }
        public async Task<ActionResult<List<CourseModel>>> List(CancellationToken ct)
        {
            var listOfCourse = await _courseService.ListAllAsync(ct);
            return View(listOfCourse);
        }

        public async Task<ActionResult<CourseModel>> Create(CancellationToken ct)
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult<CourseModel>> Create(CourseModel course, CancellationToken ct)
        {
            if (course == null || course.Id < 0)
                throw new NotFoundException(nameof(GroupModel), course);

            if (!ModelState.IsValid)
            {
                return View(course);
            }

            await _courseService.AddAsync(course, ct);
            return RedirectToAction(nameof(List));
        }

        public async Task<ActionResult<CourseModel>> Edit(int id, CancellationToken ct)
        {
            if (id < 1)
                throw new NotFoundException(nameof(CourseModel), id);

            var studentContact = await _courseService.GetByIdAsync(id, ct);

            if (studentContact == null)
            { return View("NotFound"); }

            return View(studentContact);
        }

        [HttpPost]
        public async Task<ActionResult<CourseModel>> Edit(CourseModel course, CancellationToken ct)
        {
            var studentContact = await _courseService.UpdateAsync(course, ct);

            if (!ModelState.IsValid)
            {
                return View(course);
            }

            return RedirectToAction(nameof(List));
        }

        public async Task<ActionResult<CourseModel>> Delete(int id, CancellationToken ct)
        {
            if (id < 1)
                throw new NotFoundException(nameof(CourseModel), id);

            var courseContact = await _courseService.GetByIdAsync(id, ct);

            if (courseContact == null)
            { return View("NotFound"); }

            return View(courseContact);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult<CourseModel>> DeleteConfirmed(CourseModel course, CancellationToken ct)
        {
            await _courseService.DeleteAsync(course, ct);

            return RedirectToAction(nameof(List));
        }
    }
}
