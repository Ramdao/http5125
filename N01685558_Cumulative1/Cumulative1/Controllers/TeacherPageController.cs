using Cumulative1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cumulative1.Controllers
{
    public class TeacherPageController : Controller
    {
        private readonly TeacherAPIController _api;
        //relying on the API to retrieve Teacher information
        public TeacherPageController(TeacherAPIController api)
        {
            _api = api;
        }
        //GET : TeacherPage/List
        public IActionResult List()
        {
            List<Teacher> Teachers = _api.ListTeachers();
            return View(Teachers);
        }
        //GET : TeacherPage/Show/{id}
        public IActionResult Show(int id)
        {
            Teacher SelectedTeacher = _api.FindTeacher(id);
            return View(SelectedTeacher);
        }
        // GET: TeacherPage/DeleteConfirm/{id}
        public IActionResult DeleteConfirm(int id)
        {
            Teacher SelectedTeacher = _api.FindTeacher(id);
            return View(SelectedTeacher);
        }
        // DELETE: TeacherPage/DeleteConfirm/{id}
        public IActionResult Delete(int id)
        {
            int TeacherId = _api.DeleteTeacher(id);
            // redirects to list action
            return RedirectToAction("List");
        }
        //GET : TeacherPage/New{id}
        public IActionResult New(int id)
        {
            return View();
        }
        //POST: TeacherPage/Create
        public IActionResult Create(Teacher NewTeacher)
        {
            int TeacherId = _api.AddTeacher(NewTeacher);

            
            return RedirectToAction("Show", new { id = TeacherId });
        }

    }
}
