using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2_studentController : ControllerBase
    {
        //https://cemc.uwaterloo.ca/sites/default/files/documents/2022/2022CCCJrProblemSet.html
        [HttpGet(template: "FergusonballRatings")]
        public string points(string score)
        {
            List<string> list = new List<string>();
            List<int> playerscores = new List<int>();
            list = score.Split(",").ToList();
            if (list.Count%2 != 0)
            {
                return "Not enough information given";
            }
            int points = 0;
            int fouls = 0;
            int size=0;
            if (list.Count/2 <=2) { 
             size = 0;
            }
            else
            {
                size = 2;
            }
            for (int i=0; i<=list.Count/2+size; i+=2)
            {
               
                points += Int32.Parse(list[i])*5;
                fouls += Int32.Parse(list[i+1])*3;

                playerscores.Add(points-fouls);
                points = 0;
                fouls = 0;
            }
            //return $"{playerscores[1]}";
            int countplayer = playerscores.Count;
            int countscores = 0;
            for (int i = 0; i < playerscores.Count; i++)
            {
                if (playerscores[i] < 41)
                {
                    countscores += 0;
                }
                else
                {
                    countscores++;
                }
            }

            if (countscores == countplayer)
            {
                return $"{countscores}+";
            }
            else
            {
                return $"{countscores}";
            }
        }
    }
}
