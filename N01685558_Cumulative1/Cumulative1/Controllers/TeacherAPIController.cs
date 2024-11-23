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
    /// GET api/Teacher/Listteacher -> {"teacherId": 1,"teacherFName": "Alexander","teacherLName": "Bennett","employeeNumber": "T378","hiredate": "2016-08-05T00:00:00","salary": 55.3}
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
                        decimal salary = Convert.ToDecimal(ResultSet["salary"]);

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
        /// GET api/Teacher/FindTeacher/1 -> {"teacherId": 1,"teacherFName": "Alexander","teacherLName": "Bennett","employeeNumber": "T378","hiredate": "2016-08-05T00:00:00","salary": 55.3}
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
                        decimal salary = Convert.ToDecimal(ResultSet["salary"]);
       
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
        /// <summary>
        /// Deletes an Teacher from the database
        /// </summary>
        /// <param name="TeacherId">Primary key of the Teacher to delete</param>
        /// <example>
        /// DELETE: api/TeacherData/DeleteTeacher -> 1
        /// </example>
        /// <returns>
        /// Number of rows affected by delete operation.
        /// </returns>

        [HttpDelete(template: "DeleteTeacher/{TeacherId}")]
        public int DeleteTeacher(int TeacherId)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();


                Command.CommandText = "delete from teachers where teacherid=@id";
                Command.Parameters.AddWithValue("@id", TeacherId);
                return Command.ExecuteNonQuery();

            }
            // if failure
            return 0;
        }

        /// <summary>
        /// Adds an Teacher to the database
        /// </summary>
        /// <param name="TeacherData">Author Object</param>
        /// <example>
        /// POST: api/TeacherData/AddTeacher
        /// Headers: Content-Type: application/json
        /// Request Body:
        /// {
        ///	    "teacherFname":"Alexander",
        ///	    "teacherLname":"Bennett",
        ///	    "employeebumber":"T378",
        ///	    "hiredate":"CURRENT.DATE()"
        ///	    "salary":"55.30"
        /// } -> 409
        /// </example>
        /// <returns>
        /// The inserted Author Id from the database if successful. 0 if Unsuccessful
        /// </returns>
        [HttpPost(template: "AddTeacher")]
        public int AddTeacher([FromBody] Teacher TeacherData)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "insert into teachers (teacherfname, teacherlname, employeenumber, hiredate, salary) values (@teacherfname,@teacherlname ,@employeenumber, CURRENT_DATE(), @salary)";
                Command.Parameters.AddWithValue("@teacherfname", TeacherData.TeacherFName);
                Command.Parameters.AddWithValue("@teacherlname", TeacherData.TeacherLName);
                Command.Parameters.AddWithValue("@employeenumber", TeacherData.EmployeeNumber);
                Command.Parameters.AddWithValue("@salary", TeacherData.salary);

                Command.ExecuteNonQuery();

                return Convert.ToInt32(Command.LastInsertedId);

            }
            // if failure
            return 0;
        }
    }

}
  
    

