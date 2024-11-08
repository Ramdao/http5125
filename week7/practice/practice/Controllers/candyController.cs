using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using practice.Models; // you need this for class

using MySql.Data.MySqlClient;

namespace practice.Controllers
{
    public class candyController : Controller
    { 

       
        [HttpGet]
        public IActionResult shop()
        {
            return View();
        }
        [HttpPost]
        public IActionResult checkout(string address)
        {
            ViewData["address"]=address;
            Candy candy = new Candy();
            candy.address = address;
            return View(candy);
        }
        

    }
}
// controllers -> create empty mvc. views -> create new folder ->  add new empy view file (names matter)
/*
 < li class = "nav-item" >
                            < a class = "nav-link text-dark" href = "candy/shop" > Candy </ a >
 </ li >
modify in shared layout.chstml
*/
/* model add class file */