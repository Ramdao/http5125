using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet(template:"test")]
        public string practice()
        {

            return "";
        }
        [HttpGet(template: "height")]
        [Consumes("application/x-www-form-urlencoded")]
        public string height([FromForm]int Sam, [FromForm]int Alex) {


            if (Sam > Alex)
            {
                return "Sam";
            } else
            {
                return "Alex";
            }
            
        }
    }
}
