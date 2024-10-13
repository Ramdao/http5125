using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics.CodeAnalysis;

namespace Assignment2.Controllers
{   //https://cemc.uwaterloo.ca/sites/default/files/documents/2022/2022CCCJrProblemSet.html
    /// <summary>
    /// Calculates total stars of each player in a team(Points*5 - Fouls*3), if each player more than 40 stars than the team is considered a gold team returns with +.
    /// </summary>
    /// <param name="score"> Takes the score in the format Points,Fouls</param>
    /// <reutrn> if everyone on team scores greater than 40, return {countscores} "+", {countscores} that have 40 or more </reutrn>
    /// <example>
    /// curl -X "GET" https://localhost:7204/api/J2_student/FergusonballRatings?score=12,4,10,3,9,1
    /// -> 3+
    /// curl -X "GET" https://localhost:7204/api/J2_student/FergusonballRatings?score=8,0,12,1
    ///-> 1
    ///curl -X "GET" https://localhost:7204/api/J2_student/FergusonballRatings?score=8,0,12
    ///-> Not enough information given
    /// </example>
        [Route("api/[controller]")]
    [ApiController]
    public class J2_studentController : ControllerBase
    {
        
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
