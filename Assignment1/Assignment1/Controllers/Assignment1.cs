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
    //question 5
    [Route("api/[controller]")]

    public class q5 : ControllerBase
    {
        [HttpPost(template: "secret")]
        public string secret(int secret)
        {
            return $"Shh.. the secret is {secret}";

        }


    }
    // question 6
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
    // question 7
    [Route("api/[controller]")]
    public class q7 : ControllerBase
    {
        [HttpGet(template: "timemachine")]
        public string days(int days)
        {
            DateTime Currentday = DateTime.Now;
            DateTime Updatedday = Currentday.AddDays(days);
            string FormatedDate = Updatedday.ToString("yyyy-MM-dd");
            return FormatedDate;

        }


    }
    // question 8
    [Route("api/[controller]")]
    public class q8 : ControllerBase
    {
        [HttpPost(template: "squashfellows")]
        public string Order([FromForm] int Small, [FromForm] int Large)
        {
            double TotalSmall = 25.50 * Small;
            string totalsmallstring = TotalSmall.ToString("F2");
            double TotalBig = 40.50 * Large;
            string totalbigstring = TotalBig.ToString("F2");
            double Subtotal = TotalSmall+TotalBig;
            string subtotalstring = Subtotal.ToString("F2");
            double tax = (13.0 / 100.0)*Subtotal;
            string taxstring = tax.ToString("F2");
            double total = Subtotal + tax;
            string totalstring = total.ToString("F2");
            return $"{Small} Small @ $25.50 = ${totalsmallstring}; {Large} Large @ $40.50 = ${totalbigstring}; Subtotal = ${subtotalstring}; " +
                $"Tax = ${taxstring} HST; Toal = ${totalstring}";

        }


    }


}
