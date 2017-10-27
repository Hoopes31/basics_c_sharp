using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using scaffold.Models;
using DbConnection;

namespace scaffold.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
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
                User NewUser = new User
                {
                    firstName = model.firstName,    
                    lastName = model.lastName,    
                    email = model.email,    
                    password = model.password   
                };
                string query = $"INSERT INTO users(firstName, lastName, email, password, created_date, updated_date)" + 
                $"VALUES('{NewUser.firstName}', '{NewUser.lastName}', '{NewUser.email}', '{NewUser.password}', NOW(), NOW())";
                _dbConnector.Execute(query);
                return View("Welcome");
            }
            
            return View(model);
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                string query = $"SELECT * FROM users WHERE email='{model.email}'";
                List<Dictionary<string, object>> user = _dbConnector.Query(query);
                return View("Profile");
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