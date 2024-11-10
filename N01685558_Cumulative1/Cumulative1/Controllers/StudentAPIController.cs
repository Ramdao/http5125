using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Cumulative1.Models;

namespace Cumulative1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : Controller
    {
        private readonly SchoolDbContext _context;
        public StudentAPIController(SchoolDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route(template: "StudentList")]
        public List<Student> ListStudents()
        {

            List<Student> students = new List<Student>();

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                MySqlCommand Command = Connection.CreateCommand();

                Command.CommandText = "select * from students";

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {

                    while (ResultSet.Read())
                    {

                        int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                        string StudentFName = ResultSet["studentfname"].ToString();
                        string StudentLName = ResultSet["studentlname"].ToString();
                        string StudentNumber = ResultSet["studentnumber"].ToString();
                        DateTime enroldate = Convert.ToDateTime(ResultSet["enroldate"]);
                  


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



            return students;


        }

        [HttpGet]
        [Route(template: "FindStudent/{id}")]

        public Student FindStudent(int id)
        {
            Student SelectedStudent = new Student();

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "select * from students where studentid=@id";
                Command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {

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


            return SelectedStudent;

        }

    }
}

