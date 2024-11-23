using Cumulative1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cumulative1.Controllers
{
    public class CoursePageController : Controller
    {
        private readonly CourseAPIController _api;

        //relying on the API to retrieve Course information
        public CoursePageController(CourseAPIController api) {
            _api = api;
        }

        //GET : CoursePage/List
        public IActionResult List()
        {
            List<Course> courses = _api.ListCourse();
            return View(courses);
        }
        //GET : CoursePage/Show/{id}
        public IActionResult Show(int id)
        {
            Course SelectedCourse = _api.FindCourse(id);
            return View(SelectedCourse);
        }
        // GET: CoursePage/DeleteConfirm/{id}
        public IActionResult DeleteConfirm(int id)
        {
            Course SelectedStudent = _api.FindCourse(id);
            return View(SelectedStudent);
        }
        // DELETE: CoursePage/DeleteConfirm/{id}
        public IActionResult Delete(int id)
        {
            int StudentId = _api.DeleteCourse(id);
            // redirects to list action
            return RedirectToAction("List");
        }
        //GET : CoursePage/New{id}
        public IActionResult New(int id)
        {
            return View();
        }
        //POST: CoursePage/Create
        public IActionResult Create(Course NewCourse)
        {
            int TeacherId = _api.AddCourse(NewCourse);


            return RedirectToAction("Show", new { id = TeacherId });
        }
    }
}
