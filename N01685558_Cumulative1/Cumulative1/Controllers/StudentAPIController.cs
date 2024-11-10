using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Cumulative1.Models;

namespace Cumulative1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : Controller
    {
        // dependency injection of database context
        private readonly SchoolDbContext _context;
        public StudentAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a list of Students in the system
        /// </summary>
        /// <example>
        /// GET api/Student/ListStudents -> [{"AuthorId":1,"AuthorFname":"Brian", "AuthorLName":"Smith"},{"AuthorId":2,"AuthorFname":"Jillian", "AuthorLName":"Montgomery"},..]
        /// </example>
        /// <returns>
        /// A list of Student objects 
        /// </returns>
        [HttpGet]
        [Route(template: "StudentList")]
        public List<Student> ListStudents()
        {
            // Create an empty list of course
            List<Student> students = new List<Student>();
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {

                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();
                //SQL QUERY
                Command.CommandText = "select * from students";
                // Gather Result Set of Query into a variable
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    //Loop Through Each Row the Result Set
                    while (ResultSet.Read())
                    {
                        //Access Column information by the DB column name as an index
                        int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                        string StudentFName = ResultSet["studentfname"].ToString();
                        string StudentLName = ResultSet["studentlname"].ToString();
                        string StudentNumber = ResultSet["studentnumber"].ToString();
                        DateTime enroldate = Convert.ToDateTime(ResultSet["enroldate"]);


                        //short form for setting all properties while creating the object
                        Student CurrentStudent = new Student()
                        {
                            StudentId = StudentId,
                            StudentFName = StudentFName,
                            StudentLName = StudentLName,
                            StudentNumber = StudentNumber,
                            enroldate = enroldate,
                            
                        };

                        students.Add(CurrentStudent);

                    }
                }
            }


            //Return the final list of students
            return students;


        }

        /// <summary>
        /// Returns an student in the database by their ID
        /// </summary>
        /// <example>
        /// GET api/Student/FindStudent/3 -> {"AuthorId":3,"AuthorFname":"Sam","AuthorLName":"Cooper"}
        /// </example>
        /// <returns>
        /// A matching student object by its ID. Empty object if course not found
        /// </returns>
        [HttpGet]
        [Route(template: "FindStudent/{id}")]
        //Create empty student
        public Student FindStudent(int id)
        {
            
            Student SelectedStudent = new Student();
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();
                // @id is replaced with a id
                Command.CommandText = "select * from students where studentid=@id";
                Command.Parameters.AddWithValue("@id", id);
                // Gather Result Set of Query into a variable
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    //Loop Through Each Row the Result Set
                    while (ResultSet.Read())
                    {
                        int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                        string StudentFName = ResultSet["studentfname"].ToString();
                        string StudentLName = ResultSet["studentlname"].ToString();
                        string StudentNumber = ResultSet["studentnumber"].ToString();
                        DateTime enroldate = Convert.ToDateTime(ResultSet["enroldate"]);

                       SelectedStudent.StudentId = StudentId;
                       SelectedStudent.StudentFName = StudentFName;
                       SelectedStudent.StudentLName = StudentLName;
                       SelectedStudent.StudentNumber = StudentNumber;
                       SelectedStudent.enroldate = enroldate;

                    }
                }
            }

            //Return SelectedStudent
            return SelectedStudent;

        }

    }
}

