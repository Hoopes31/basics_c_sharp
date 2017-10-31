using System;
using System.Linq;
using Newtonsoft.Json;
using entity_learn.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace entity_learn.Controllers
{
    //Context gets entire data sets
    //Use LINQ to manipulate these sets
    public class HomeController : Controller
    {

        private LearnContext _context;

        public HomeController(LearnContext context)
        {
            _context = context;
        }

        //READ
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //Get all users
            List<User> AllUsers = _context.Users.ToList();
            ViewBag.AllUsers = AllUsers;

            //Get Users that match parameters
            List<User> SpecificUsers = AllUsers.Where(user => user.first_name == "Roger").ToList();

            //Get a Single User
            User OneUser = _context.Users.SingleOrDefault(user => user.email == "test@gmail.com");
            ViewBag.OneUser = OneUser;
            return View();
        }
        //CREATE
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //UPDATE
        public IActionResult Update(int id)
        {
            User user = _context.Users.SingleOrDefault(check => check.id == id);
            if (user != null)
            {
                user.first_name = "Roger";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //DELETE
        public IActionResult Delete(int id)
        {
            User user = _context.Users.SingleOrDefault(check => check.id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
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