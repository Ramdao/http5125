using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    //question 1
    /* 
     > GET Request http://localhost:xx/api/q1/welcome
     > Method(welcome()) return string "Welcome to 5125!"
     */

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
    /* 
      > GET Request http://localhost:xx/api/q2/greeting?name={name}
      > {name} value is stored
      > Method (name(string name) returns string "Hi {name}!
     */

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
    /* 
     > GET Request http://localhost:xx/api/q3/cube/{cube}
     > {cube} value is stored
     > Method (cube(int cube)) calculates the cube of value and returns string  
     
     */
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
    /* 
    > POST Request http://localhost:xx/api/q4/knockknock
    > Method (knockknock) return string "Who's there?"
     
     */
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
    /* 
     > POST Request http://localhost:xx/api/q5/secret
     > Takes value from body
     > Method (secret (int secret)) returns string "Shh.. the secret {secret}
     
     */
    [Route("api/[controller]")]

    public class q5 : ControllerBase
    {
        [HttpPost(template: "secret")]
        public string secret([FromBody] int secret)
        {
            return $"Shh.. the secret is {secret}";

        }


    }
    // question 6
    /* 
     > GET Request http://localhost:xx/api/q6/hexagon?side={side}
     > Stores {side} value
     > Calculates (3xsqrt(3))/2 X side^2
     > Returns double of calculation
     
     */
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
    /* 
     > GET Request http://localhost:xx/api/q7/timemachine?days={days}
     > Takes the Current day date
     > Updates day by adding Current day with {days}
     > Format Date time with year-month-day to string
     > Return formated date as string
     
     */
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
    /* 
     > POST Request http://localhost/api/q8/squashfellows 
     > Takes Small and Large value from body
     > Calculates Total value of small items 25.50 * Small
     > Calculates Total value of small items 40.50 * Large
     > Subtotal value = TotalSmall + TotalLarge
     > Tax = 13% of subtotal
     > Total value = Subtotal + Tax
     > Converts all double to string and format them with 2 decimal places
     > returns string based on the calculated values

     
     */
    [Route("api/[controller]")]
    public class q8 : ControllerBase
    {
        [HttpPost(template: "squashfellows")]
        public string Order([FromForm] int Small, [FromForm] int Large)
        {
            double TotalSmall = 25.50 * Small;
            string totalsmallstring = TotalSmall.ToString("F2");
            double TotalLarge = 40.50 * Large;
            string totalbigstring = TotalLarge.ToString("F2");
            double Subtotal = TotalSmall+TotalLarge;
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
