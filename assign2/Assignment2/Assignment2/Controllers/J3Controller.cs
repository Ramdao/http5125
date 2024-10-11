using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {
        //https://cemc.uwaterloo.ca/sites/default/files/documents/2022/2022CCCJrProblemSet.html
        /// <summary>
        /// The instructions for tightening or loosening is not human friendly, takes the instuctions and converts to human friendly text.
        /// Each line of output will consist of three parts, each separated by a single space: the uppercase letters referring to the strings,
        /// tighten if the instruction contained a plus sign or loosen if the instruction contained a minus sign, and the number of turns.
        /// </summary>
        /// <param name="tune"> Takes the instruction as string and splits into + and - </param>
        /// <returns> returns the string value of the tones that needs to tightened or loosen based on inistructions </returns>
        /// 
        [HttpGet(template: "HarpTuning")]
        public string tuning(string tune)
        {
            char[] arr;
            arr = tune.ToCharArray();
            List<string> loosen = new List<string>();
            List<string> tighten = new List<string>();

            string add = "";  
            for (int i = 0; i < arr.Length; i++)
            {
              
                    add += arr[i].ToString();
              
               
                if (arr[i].ToString() == "+")
                {
                    i++;
                    while (i<arr.Length && char.IsDigit(arr[i]))
                    {
                        add += arr[i].ToString();
                        i++;
                    }
                    
                    //add += arr[i + 1].ToString();
                    tighten.Add(add);
                    add = "";
                    i--;
                } else if (arr[i].ToString() == "-")
                {
                    i++;
                    while (i < arr.Length && char.IsDigit(arr[i]))
                    {
                        add += arr[i].ToString();
                        i++;
                    }
                    
                    //add += arr[i + 1].ToString();
                    loosen.Add(add);
                    add = "";
                    i--;
                }


            }

           
            List<string> TuneTighten = new List<string>();
            List<string> TuneLoosen = new List<string>();

            for (int i = 0; tighten.Count > i; i++)
            {
                TuneTighten.AddRange(tighten[i].Split('+'));
            }

            for (int i = 0; loosen.Count > i; i++)
            {
                TuneLoosen.AddRange(loosen[i].Split('-'));
            }


            //test = tighten[1].Split("+").ToList();
            string result = "";
            
            for (int i =0; TuneTighten.Count> i; i+=2)
            {
                result += TuneTighten[i] +" tighten "+ TuneTighten[i+1] + "\n";
                
            }
            for (int i = 0; TuneLoosen.Count > i; i += 2)
            {
                result += TuneLoosen[i] + " loosen " + TuneLoosen[i + 1] + "\n";

            }
            return result ;

        }
    }
}
