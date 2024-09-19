using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    //question 1
    [Route("api/[controller]")]
    [ApiController]

    public class q1 : ControllerBase
    {
        [HttpGet(template: "welcome")]
        public string welcome()
        {
            return "Welcome to 5125!";

        }


    }
    //question 2
    [Route("api/[controller]")]
    
    public class q2 : ControllerBase
    {
        [HttpGet(template: "greeting")]
        public string name(string name)
        {
            return $"Hi {name}!";

        }


    }

    //question 3
    [Route("api/[controller]")]
    
    public class q3 : ControllerBase
    {
        [HttpGet(template: "cube/{cube}")]
        public string cube(int cube)
        {   
            return $"{Math.Pow(cube,3)}";

        }


    }
    //question 4
    [Route("api/[controller]")]

    public class q4 : ControllerBase
    {
        [HttpPost(template: "knockknock")]
        public string knockknock()
        {
            return "Who's there?";

        }


    }
    [Route("api/[controller]")]
    public class q6 : ControllerBase
    {
        [HttpGet(template: "hexagon")]
        public double side(double side)
        {
            side = ((3*Math.Sqrt(3))/2)*Math.Pow(side,2);
            return side ;

        }


    }


}
