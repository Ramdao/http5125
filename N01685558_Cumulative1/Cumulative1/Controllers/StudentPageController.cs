using Cumulative1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cumulative1.Controllers
{
    
    public class StudentPageController : Controller
    {
        private readonly StudentAPIController _api;
        //relying on the API to retrieve student information
        public StudentPageController(StudentAPIController api)
        {
            _api = api;
        }
        //GET : StudentPage/List
        public IActionResult List()
        {
            List<Student> students = _api.ListStudents();
            return View(students);
        }
        //GET : StudentPage/Show/{id}
        public IActionResult Show(int id)
        {
            Student SelectedStudent = _api.FindStudent(id);
            return View(SelectedStudent);
        }

    }
}
