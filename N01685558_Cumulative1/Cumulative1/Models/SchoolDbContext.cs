using MySql.Data.MySqlClient;

namespace Cumulative1.Models
{
    public class SchoolDbContext
    {
        //These are readonly properties. 
        //Settings for Xampp
        //database for school
        private static string User { get { return "root"; } }
        private static string Password { get { return ""; } }
        private static string Database { get { return "school"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //This is the method we actually use to get the database!
        /// <summary>
        /// Returns a connection to the school database.
        /// </summary>
        /// <example>
        /// private SchoolDbContext School = new SchoolDbContext();
        /// MySqlConnection Connection = School.AccessDatabase();
        /// </example>
        /// <returns>A MySqlConnection Object</returns>
        protected static string ConnectionString
        {
            get
            { 
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password
                    + "; convert zero datetime = True";
            }
        }
        //We are instantiating the MySqlConnection Class to create an object
        //the object is a specific connection to our blog database on port 3306 of localhost
        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
