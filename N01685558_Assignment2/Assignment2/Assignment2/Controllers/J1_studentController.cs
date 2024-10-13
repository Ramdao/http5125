using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    //https://cemc.uwaterloo.ca/sites/default/files/documents/2022/2022CCCJrProblemSet.html
    /// <summary>
    /// Calculate how many cupcake is left over if regular cupcake holds 8 cupcakes and small holds 3 cupcakes and there are 28 students
    /// </summary>
    /// <param name="Regular" > The number of regualar boxes </param>
    /// <param name="Small"> The number of small boxes</param>
    /// <return> if {Regular} * 8 + Small * 3 -28>=28 return total else return "Not enough cupcakes </return>
    /// <example>
    ///  -X "POST" -d "Regular=2&Small=5" -H "Content-Type: application/x-www-form-urlencoded" https://localhost:7204/api/J1_student/Cupcakeparty
    ///  -> 3
    ///  -X "POST" -d "Regular=0&Small=0" -H "Content-Type: application/x-www-form-urlencoded" https://localhost:7204/api/J1_student/Cupcakeparty
    ///  -> Not enough cupcakes
    /// </example>
    [Route("api/[controller]")]
    [ApiController]
    public class J1_studentController : ControllerBase
    {
        
        [HttpPost(template: "Cupcakeparty")]
        [Consumes("application/x-www-form-urlencoded")]
        public string leftover([FromForm] int Regular, [FromForm] int Small)
        {
            if (Regular*8+Small*3 < 28)
            {
                return "Not enough cupcakes";
            }

            int total = Regular * 8 + Small * 3 - 28;
            return $"{total}";
        }

    }
}

