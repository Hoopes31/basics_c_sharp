using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using restEntity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace restEntity.Controllers
{
    public class HomeController : Controller
    {
        private EntityContext _context;
 
        public HomeController(EntityContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Restaurant> all_restaurants = _context.Restaurants.OrderBy(restaurant => restaurant.name).ToList();
            ViewBag.restaurants = all_restaurants;
            return View();
        }
        [HttpGet]
        [Route("review")]
        public IActionResult Review(string restaurant)
        {
            ViewBag.restaurant = restaurant;
            return View();
        }
        [HttpPost]
        [Route("add_review")]
        public IActionResult AddReview(ReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                System.Console.WriteLine("work it");
            }
            return View(model);
        }
    }

    // Session:
    // HttpContext.Session.SetString("KeyName", "Value");
    // string sessionStr = HttpContext.Session.GetString("KeyName");

    // HttpContext.Session.SetInt32("KeyName", Int);
    // int? sessionInt = HttpContext.Session.GetInt32("KeyName");

    // JSON:
    // session.SetString(key, JsonConvert.SerializeObject(value);
    // string jsonValue = session.GetString(key)
    // JsonConvert.DeserializeObject<T>(value);
}
