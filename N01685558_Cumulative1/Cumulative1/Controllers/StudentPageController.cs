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

        // GET: StudentPage/DeleteConfirm/{id}
        public IActionResult DeleteConfirm(int id)
        {
            Student SelectedStudent = _api.FindStudent(id);
            return View(SelectedStudent);
        }
        // DELETE: StudentPage/DeleteConfirm/{id}
        public IActionResult Delete(int id)
        {
            int StudentId = _api.DeleteStudent(id);
            // redirects to list action
            return RedirectToAction("List");
        }
        //GET : StudentPage/New{id}
        public IActionResult New(int id)
        {
            return View();
        }
        //POST: StudentPage/Create
        public IActionResult Create(Student NewStudent)
        {
            int TeacherId = _api.AddStudent(NewStudent);


            return RedirectToAction("Show", new { id = TeacherId });
        }

    }
}
