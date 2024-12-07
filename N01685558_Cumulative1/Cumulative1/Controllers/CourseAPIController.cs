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
        /// <summary>
        /// Deletes an Course from the database
        /// </summary>
        /// <param name="CourseId">Primary key of the Teacher to delete</param>
        /// <example>
        /// DELETE: api/CourseData/DeleteCourse -> 1
        /// </example>
        /// <returns>
        /// Number of rows affected by delete operation.
        /// </returns>
        [HttpDelete(template: "DeleteCourse/{CourseId}")]
        public int DeleteCourse(int CourseId)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();


                Command.CommandText = "delete from courses where courseid=@id";
                Command.Parameters.AddWithValue("@id", CourseId);
                return Command.ExecuteNonQuery();

            }
            // if failure
            return 0;
        }

        /// <summary>
        /// Adds an Course to the database
        /// </summary>
        /// <param name="CourseData">Author Object</param>
        /// <example>
        /// POST: api/CourseData/AddCourse
        /// Headers: Content-Type: application/json
        /// Request Body:
        /// {
        ///	    "courseCode":"Http5101",
        ///	    "teacherid":"1",
        ///	    "startdate":"2018-09-04",
        ///	    "finishdate":"2018-09-04"
        ///	    "coursename":"Web application"
        ///	   
        /// } -> 409
        /// </example>
        /// <returns>
        /// The inserted Author Id from the database if successful. 0 if Unsuccessful
        /// </returns>
        [HttpPost(template: "AddCourse")]
        public int AddCourse([FromBody] Course CourseData)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

               
                Command.CommandText = "insert into courses (coursecode, teacherid, startdate, finishdate, coursename) values (@coursecode,@teacherid,@startdate,@finishdate,@coursename)";
                Command.Parameters.AddWithValue("@coursecode", CourseData.CourseCode);
                Command.Parameters.AddWithValue("@teacherid", CourseData.TeacherId);
                Command.Parameters.AddWithValue("@startdate", CourseData.StartDate);
                Command.Parameters.AddWithValue("@finishdate", CourseData.FinishDate);
                Command.Parameters.AddWithValue("@coursename", CourseData.CourseName);


                Command.ExecuteNonQuery();

                return Convert.ToInt32(Command.LastInsertedId);

            }
            // if failure
            return 0;
        }

        /// <summary>
        /// Updates an Course in the database. Data is Teacher object, request query contains ID
        /// </summary>
        /// <param name="CourseData">Teacher Object</param>
        /// <param name="CourseId">The Teacher ID primary key</param>
        /// <example>
        /// PUT: api/Course/UpdateCourse/1
        /// Headers: Content-Type: application/json
        /// Request Body:
        /// {   
        ///     "Courseid":1,
        ///	    "Coursecode":"Http5101",
        ///	    "teacherid":"1",
        ///	    "startdate":"2018-09-04"
        ///	    "finishdate":"2018-12-14"
        ///	    "Coursename":"Web Application Development",
        ///	  
        ///	    
        /// } -> 
        /// {
        ///     "Courseid":1,
        ///	    "Coursecode":"Http5101",
        ///	    "teacherid":"2"
        ///	    "startdate":"2018-09-04"
        ///	    "finishdate":"2018-12-14"
        ///	    "coursename":"Web Application Development"
        /// }
        /// </example>
        /// <returns>
        /// The updated Teacher object
        /// </returns>
        /// 

        [HttpPut("CourseUpdate/{CourseId}")]
        public IActionResult UpdateCourse(int CourseId, [FromBody] Course CourseData)
        {
           

            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                // parameterize query
                Command.CommandText = "UPDATE courses SET coursecode=@coursecode, teacherid=@teacherid, startdate=@startdate, finishdate=@finishdate, coursename=@coursename WHERE courseid=@id";
                Command.Parameters.AddWithValue("@coursecode", CourseData.CourseCode);
                Command.Parameters.AddWithValue("@teacherid", CourseData.TeacherId);
                Command.Parameters.AddWithValue("@startdate", CourseData.StartDate);
                Command.Parameters.AddWithValue("@finishdate", CourseData.FinishDate);
                Command.Parameters.AddWithValue("@coursename", CourseData.CourseName);
                Command.Parameters.AddWithValue("@id", CourseId);

                Command.ExecuteNonQuery();

                return Ok(FindCourse(CourseId));
            }
        }

    }
}
