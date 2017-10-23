using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace rock_paper_scissors.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // if (!TempData.ContainsKey("wins"))
            // {
            //     TempData["wins"] = 0;
            //     TempData["losses"] = 0;
            // }
            if (HttpContext.Session.Get("wins") == null)
            {
                HttpContext.Session.SetInt32("wins", 0);
                HttpContext.Session.SetInt32("losses", 0);
            }
            return View();
        }
        [HttpPost]
        [Route("choice")]
        public IActionResult Choice(string choice)
        {   
            Random rand = new Random();
            string[] computerChoices = {"rock", "paper", "scissors"};
            string computerChoice = computerChoices[rand.Next(0,3)];
            // int wins = (int)TempData["wins"];
            // int losses = (int)TempData["losses"];
            int wins = 0;
            int losses = 0;
            if (choice == "rock" && computerChoice == "scissors")
                {
                    wins += 1;
                }
            if (choice == "scissors" && computerChoice == "paper")
                {
                    wins += 1;
                }
            if (choice == "paper" && computerChoice == "rock")
                {
                    wins += 1;
                }
            if (choice == "rock" && computerChoice == "paper")
                {
                    losses += 1;
                }
            if (choice == "scissors" && computerChoice == "rock")
                {
                    losses += 1;
                }
            if (choice == "paper" && computerChoice == "scissors")
                {
                    losses += 1;
                }
            HttpContext.Session.SetInt32("wins", wins);
            HttpContext.Session.SetInt32("losses", losses);
            HttpContext.Session.SetInt32("total", wins + losses);
            return Redirect("");
        }
    }
}
