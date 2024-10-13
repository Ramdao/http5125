using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Deliv-e-droid Gain 50 points for every {Deliveries}, lose 10 points {Collisions}, gain 500 points if Deliveries> Collisions
    /// </summary>
    /// <param name="Collisions">  Number of Collisions which will be compared with Deliveries</param>
    /// <param name="Deliveris"> Number of Deliveries which will be compared to Collisions </param>
    /// <return>if Deliveries>{Collisions} then return {Deliveries} * 50 - {Collisions} * 10 + 500, else returns {Deliveries} * 50 - {Collisions} * 10</return>
    /// <example>
    /// curl -X "POST" -d "Collisions=2&Deliveries=5" -H "application/x-www-form-urlencoded" https://localhost:7204/api/J1/Delivedroid
    /// -> 730
    /// >curl -X "POST" -d "Collisions=5&Deliveries=0" -H "application/x-www-form-urlencoded" https://localhost:7204/api/J1/Delivedroid
    /// -> -50
    /// </example>
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
