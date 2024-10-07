using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1_studentController : ControllerBase
    {
        //https://cemc.uwaterloo.ca/sites/default/files/documents/2022/2022CCCJrProblemSet.html
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

