using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        [HttpPost(template: "Delivedroid")]
        [Consumes("application/x-www-form-urlencoded")]
        public int points([FromForm] int Collisions, [FromForm] int Deliveries) {

            int total = Deliveries * 50 - Collisions * 10;
            if (Deliveries > Collisions) {
                return total + 500;
            } 
            return total;
        }

    }
}
