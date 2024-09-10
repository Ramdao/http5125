using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataTypes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTypes : ControllerBase
    {
        /// <summary>
        /// Adds two integers together
        /// </summary>
        /// <returns>Integer</returns>
        /// <example>
        /// GET api/GetInteger
        /// </example>
        /// <remarks>
        /// Integers are whole numbers which are positive, negative, or zero.
        /// </remarks>
        [HttpGet(template: "GetInteger")]
        public int GetInteger()
        {
            int firstNum = 5;
            int secondNum = 10;
            return firstNum + secondNum;
        }

        /// <summary>
        /// Uses the string data type and returns a message.
        /// </summary>
        /// <returns>string</returns>
        /// <example>GET api/GetString -> "Hello World!"</example>
        /// <remarks>
        /// C# strings have many useful built in methods.
        /// https://learn.microsoft.com/en-us/dotnet/api/system.string?view=net-8.0
        /// </remarks>
        [HttpGet(template: "GetString")]
        public string GetString()
        {
            string firstMessage = "Hello";
            string secondMessage = "World!";
            // adding strings together is called concatentation
            return firstMessage + " " + secondMessage;
        }

        /// <summary>
        /// Adds two decimals together to return a decimal
        /// </summary>
        /// <returns>decimal</returns>
        /// <example>
        /// GET api/GetDecimal -> 10.9
        /// </example>
        /// <remarks>
        /// Decimals are useful when representing currency. There is little risk of floating point arithmetic errors than with double or float.
        /// https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-decimal
        /// https://learn.microsoft.com/en-us/dotnet/api/system.decimal?view=net-8.0
        /// </remarks>
        [HttpGet(template: "GetDecimal")]
        public Decimal GetDecimal()
        {
            decimal firstDecimal = 10.1M;
            decimal secondDecimal = 0.8M;

            return firstDecimal + secondDecimal;
        }

        /// <summary>
        /// Adds to floats together to return a float.
        /// </summary>
        /// <returns>float</returns>
        /// <remarks>
        /// Floats use 32 bytes to store the number with a given precision, which does not always exactly into a decimal representation (i.e. 1/3 is not 0.3333)
        /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types
        /// </remarks>
        [HttpGet(template: "GetFloat")]
        public float GetFloat()
        {
            float firstFloat = 0.001F;
            float secondFloat = -10.2F;

            //Note: NOT -10.199
            return firstFloat + secondFloat;
        }

        /// <summary>
        /// Gets the current date
        /// </summary>
        /// <returns>DateTime</returns>
        /// <example>
        /// (If called midnight Jan 1, 2030)
        /// GET api/GetDateTime -> 2030-01-01T00:00:00.000Z
        /// </example>
        /// <remarks>
        /// C# DateTime has many useful features, such as converting from a string to a date, addition, subtraction, and calendar features.
        /// https://learn.microsoft.com/en-us/dotnet/api/system.datetime?view=net-8.0
        /// </remarks>
        [HttpGet(template: "GetDateTime")]
        public DateTime GetDateTime()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate;
        }


    }
}
