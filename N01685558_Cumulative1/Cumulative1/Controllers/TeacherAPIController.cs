using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Cumulative1.Models;

namespace Cumulative1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAPIController : Controller
    {
        // dependency injection of database context
        private readonly SchoolDbContext _context;

        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Returns a list of Teacher in the system
        /// </summary>
        /// <example>
        /// GET api/Teacher/Listteacher -> [{"AuthorId":1,"AuthorFname":"Brian", "AuthorLName":"Smith"},{"AuthorId":2,"AuthorFname":"Jillian", "AuthorLName":"Montgomery"},..]
        /// </example>
        /// <returns>
        /// A list of Teacher objects 
        /// </returns>


        [HttpGet]
        [Route(template: "TeacherList")]

        public List<Teacher> ListTeachers()
        {
            // Create an empty list of Teacher
            List<Teacher> Teachers = new List<Teacher>();
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();
                
                //SQL QUERY
                Command.CommandText = "select * from teachers";
                // Gather Result Set of Query into a variable
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    //Loop Through Each Row the Result Set
                    while (ResultSet.Read())
                    {
                        //Access Column information by the DB column name as an index
                        int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                        string TeacherFName = ResultSet["teacherfname"].ToString();
                        string TeacherLName = ResultSet["teacherlname"].ToString();
                        string EmployeeNumber = ResultSet["employeenumber"].ToString();
                        DateTime hiredate = Convert.ToDateTime(ResultSet["hiredate"]);
                        double salary = Convert.ToDouble(ResultSet["salary"]);

                        //short form for setting all properties while creating the object
                        Teacher CurrentTeacher = new Teacher()
                        {
                            TeacherId = TeacherId,
                            TeacherFName = TeacherFName,
                            TeacherLName = TeacherLName,
                            EmployeeNumber = EmployeeNumber,
                            hiredate = hiredate,
                            salary = salary
                        };

                        Teachers.Add(CurrentTeacher);

                    }
                }
            }


            //Return the final list of teachers
            return Teachers;


        }
        /// <summary>
        /// Returns an Teacher in the database by their ID
        /// </summary>
        /// <example>
        /// GET api/Teacher/FindTeacher/3 -> {"AuthorId":3,"AuthorFname":"Sam","AuthorLName":"Cooper"}
        /// </example>
        /// <returns>
        /// A matching Teacher object by its ID. Empty object if course not found
        /// </returns>

        [HttpGet]
        [Route(template: "FindTeacher/{id}")]
        //Create empty Teacher
        public Teacher FindTeacher(int id)
        {

            Teacher SelectedTeacher = new Teacher();
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();
                // @id is replaced with a id
                Command.CommandText = "select * from teachers where teacherid=@id";
                Command.Parameters.AddWithValue("@id", id);
                // Gather Result Set of Query into a variable
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    //Loop Through Each Row the Result Set
                    while (ResultSet.Read())
                    {
                        int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                        string TeacherFName = ResultSet["teacherfname"].ToString();
                        string TeacherLName = ResultSet["teacherlname"].ToString();
                        string EmployeeNumber = ResultSet["employeenumber"].ToString();
                        DateTime hiredate = Convert.ToDateTime(ResultSet["hiredate"]);
                        double salary = Convert.ToDouble(ResultSet["salary"]);
       
                            SelectedTeacher.TeacherId = TeacherId;
                            SelectedTeacher.TeacherFName = TeacherFName;
                            SelectedTeacher.TeacherLName = TeacherLName;
                            SelectedTeacher.EmployeeNumber = EmployeeNumber;
                            SelectedTeacher.hiredate = hiredate;
                            SelectedTeacher.salary = salary;
                        
                    }
                }
            }


            //Return SelectedTeacher
            return SelectedTeacher;
        }

    }
  }
    

