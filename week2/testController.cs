using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        [HttpGet(template: "test1")]
        public string test1()
        {
            return "Hello World";


        }
        [HttpGet(template: "test2")]
        public string test2()
        {
            return "Hello 5125";
        }
        [HttpPost(template:"test3")]
        public string test3()
        {

            return "A post request";

        }
    }
}
