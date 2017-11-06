using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using scaffold.Models;
using DbConnection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace scaffold.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserFactory userFactory;
        public HomeController(UserFactory connect)
        {
            userFactory = connect;
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
                    first_name = model.first_name,    
                    last_name = model.last_name,    
                    email = model.email,    
                    password = model.password   
                };
                userFactory.AddNewUser(NewUser);
                return RedirectToAction("Index", "Wall");
            }
            
            return View(model);
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                LoginModel user = new LoginModel
                {
                    email = model.email,
                    password = model.password
                };
                User returnedUser = userFactory.Login(user);

                if (returnedUser != null)
                {
                    if (returnedUser.password == user.password)
                    {
                        HttpContext.Session.SetInt32("id", returnedUser.id);
                        return RedirectToAction("Index", "Wall");
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
        [HttpGet]
        [Route("get_all")]
        public IActionResult GetAllUsers()
        {
            ViewBag.Users = userFactory.GetAllUsers();
            return View();
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