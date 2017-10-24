using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace portfolioMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            return View();
        }
        [HttpGet]
        [Route("projects")]
        public IActionResult Projects()
        {
            return View();
        }
        [HttpGet]
        [Route("about")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
