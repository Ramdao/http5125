using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        [HttpGet(template: "ChiliPeppers")]
        public int SHU(string Ingredients)
        {
            List<string> list = new List<string>();
            list = Ingredients.Split(",").ToList();
            int value = 0;
           for (int i=0; i<list.Count; i++)
            {
                if (list[i] == "Poblano")
                {
                    value += 1500;
                } else if (list[i] == "Mirasol")
                {
                    value += 6000;
                } else if (list[i] == "Serrano")
                {
                    value += 15500;
                } else if (list[i] == "Cayenne")
                {
                    value += 40000;

                } else if(list[i] == "Thai")
                {
                    value += 75000;
                } else if (list[i] == "Habanero")
                {
                    value += 125000;
                } else
                {
                    value += 0;
                }
            }


            return value;

        }

    }
}

