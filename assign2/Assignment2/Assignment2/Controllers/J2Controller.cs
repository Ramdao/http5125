using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Everytime you add a pepper ({Ingredients}) it will increases SHU value, depending on the pepper
    /// </summary>
    /// <param name="Ingredients">Takes the 'Ingredients' to check what type of pepper it is and adds to the toal SHU</param>
    /// <return> Total SHU value</return>
    /// 
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
            foreach (string item in list) {
                if (item == "Poblano")
                {
                    value += 1500;
                }
                else if (item == "Mirasol")
                {
                    value += 6000;
                }
                else if (item == "Serrano")
                {
                    value += 15500;
                }
                else if (item == "Cayenne")
                {
                    value += 40000;

                }
                else if (item == "Thai")
                {
                    value += 75000;
                }
                else if (item == "Habanero")
                {
                    value += 125000;
                }
                else
                {
                    value += 0;
                }

            }
          


            return value;

        }

    }
}

