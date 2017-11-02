using System;
using System.Linq;
using Newtonsoft.Json;
using scaffold.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace scaffold.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;
 
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserViewModel model)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                User newUser = new User
                {
                    first_name = model.first_name,
                    last_name = model.last_name,
                    email = model.email,
                    password = model.password,
                    created_date = DateTime.Now,
                    updated_date = DateTime.Now
                };
                newUser.password = hasher.HashPassword(newUser, newUser.password);
                _context.Add(newUser);
                _context.SaveChanges();

                User user = _context.Users.SingleOrDefault(u => u.email == model.email);
                HttpContext.Session.SetInt32("id", newUser.id);

                Account newAccount = new Account
                {
                    balance = 0,
                    UserId = user.id,
                    created_date = DateTime.Now,
                    updated_date = DateTime.Now
                };

                //Save new user
                _context.Add(newAccount);
                _context.SaveChanges();

                return RedirectToAction("Index", "Bank");
            }
            return View(model);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                //Get user
                User User = _context.Users.SingleOrDefault(user => user.email == model.email);

                if (User != null && model.password != null)
                {
                    var Hasher = new PasswordHasher<User>();
                    if(0 != Hasher.VerifyHashedPassword(User, User.password, model.password))
                    {
                        HttpContext.Session.SetInt32("id", User.id);
                        return RedirectToAction("Index", "Bank");
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
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
