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
    }
}
