using Cumulative1.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Cumulative1.Controllers
{
    public class CourseAPIController : Controller
    {

        // dependency injection of database context
        private readonly SchoolDbContext _context;

        public CourseAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a list of Course in the system
        /// </summary>
        /// <example>
        /// GET api/Course/ListCourse -> {"courseId": 1, "courseCode": "http5101","teacherId": 1,"startDate": "2018-09-04T00:00:00","finishDate": "2018-12-14T00:00:00","courseName": "Web Application Development"}
    /// </example>
    /// <returns>
    /// A list of Course objects 
    /// </returns>



    [HttpGet]
        [Route(template: "CoursetList")]
        public List<Course> ListCourse()
        {
            // Create an empty list of course
            List<Course> course = new List<Course>();

            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                //SQL QUERY
                Command.CommandText = "select * from courses";

                // Gather Result Set of Query into a variable
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    //Loop Through Each Row the Result Set
                    while (ResultSet.Read())
                    {
                        //Access Column information by the DB column name as an index
                        int CourseId = Convert.ToInt32(ResultSet["courseid"]);
                        string CourseCode = ResultSet["coursecode"].ToString();
                        int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                        DateTime StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                        DateTime FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);
                        string CourseName= ResultSet["coursename"].ToString();

                        //short form for setting all properties while creating the object
                        Course CurrentCourse = new Course()
                        {
                            CourseId = CourseId,
                            CourseCode = CourseCode,
                            TeacherId = TeacherId,
                            StartDate = StartDate,
                            FinishDate = FinishDate,
                            CourseName = CourseName
                        };

                        course.Add(CurrentCourse);

                    }
                }
            }


            //Return the final list of course
            return course;


    }

        /// <summary>
        /// Returns an course in the database by their ID
        /// </summary>
        /// <example>
        /// GET api/Course/FindCourse/1 -> {"courseId": 1,"courseCode": "http5101","teacherId": 1,"startDate": "2018-09-04T00:00:00","finishDate": "2018-12-14T00:00:00","courseName": "Web Application Development"}
/// </example>
/// <returns>
/// A matching course object by its ID. Empty object if course not found
/// </returns>


[HttpGet]
        [Route(template: "FindCourse/{id}")]
        //Create empty course
        public Course FindCourse(int id)
        {
            Course SelectedCourse = new Course();

            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();
                // @id is replaced with a id
                Command.CommandText = "select * from courses where courseid=@id";
                Command.Parameters.AddWithValue("@id", id);

                // Gather Result Set of Query into a variable
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    //Loop Through Each Row the Result Set
                    while (ResultSet.Read())
                    {
                        //Access Column information by the DB column name as an index
                        int CourseId = Convert.ToInt32(ResultSet["courseid"]);
                        string CourseCode = ResultSet["coursecode"].ToString();
                        int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                        DateTime StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                        DateTime FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);
                        string CourseName = ResultSet["coursename"].ToString();

                        SelectedCourse.CourseId = CourseId;
                        SelectedCourse.CourseCode = CourseCode;
                        SelectedCourse.TeacherId = TeacherId;
                        SelectedCourse.StartDate = StartDate;
                        SelectedCourse.FinishDate = FinishDate;
                        SelectedCourse.CourseName = CourseName;
                    }
                }
            }

            //Return SelectedCourse
            return SelectedCourse;

        }

    }
}
