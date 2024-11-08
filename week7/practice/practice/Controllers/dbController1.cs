using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using practice.Models;

namespace practice.Controllers
{
    public class dbController1 : Controller
    /* for db */
    {
        private readonly db _context; //name of file with db 

        public dbController1(db context)
        {
            _context = context;
        }
        [HttpGet]


        public author suthorsdb()
        {
            author author = new author();
         

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                MySqlCommand Command = Connection.CreateCommand();

                Command.CommandText = "select * from authors";
                


                using (MySqlDataReader Reader = Command.ExecuteReader())
                {

                    while (Reader.Read())
                    {

                       author.Authorname = Reader["authorfname"].ToString();
                       

                    }
                }
            }
            return author;
        }
    }
}
