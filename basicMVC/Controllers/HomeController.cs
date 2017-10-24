using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using creature;
namespace basicMVC.Controllers
{
    public class HomeController : Controller
    {
        public DojoChi userDojoChi;

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (userDojoChi == null)
            {
                return View("Welcome");
            }
            ViewBag.DojoChi = userDojoChi;
            return View();
        }
        [HttpPost]
        [Route("addName/{name}")]
        public IActionResult AddName(string name)
        {
            userDojoChi = new DojoChi(name);
            return RedirectToAction("Index");
        }
        public IActionResult Play(DojoChi userDojoChi)
        {
            userDojoChi.Play();
            if (userDojoChi.Win())
            {
                return View("Win!");
            }
            if (userDojoChi.Death())
            {
                return View("Death!");
            }
            HttpContext.Session.SetObjectAsJson("DojoChi", userDojoChi);
            return RedirectToAction("Index", userDojoChi);
        }
        public IActionResult Work(DojoChi userDojoChi)
        {
            userDojoChi.Work();
            if (userDojoChi.Win())
            {
                return View("Win!");
            }
            if (userDojoChi.Death())
            {
                return View("Death!");
            }
            HttpContext.Session.SetObjectAsJson("DojoChi", userDojoChi);
            return RedirectToAction("Index", userDojoChi);
        }
        public IActionResult Sleep(DojoChi userDojoChi)
        {
            userDojoChi.Sleep();
            if (userDojoChi.Win())
            {
                return View("Win!");
            }
            if (userDojoChi.Death())
            {
                return View("Death!");
            }
            HttpContext.Session.SetObjectAsJson("DojoChi", userDojoChi);
            return RedirectToAction("Index", userDojoChi);
        }
        public IActionResult Feed(DojoChi userDojoChi)
        {
            userDojoChi.Feed();
            if (userDojoChi.Win())
            {
                return View("Win!");
            }
            if (userDojoChi.Death())
            {
                return View("Death!");
            }
            HttpContext.Session.SetObjectAsJson("DojoChi", userDojoChi);
            return RedirectToAction("Index", userDojoChi);
        }
        [HttpPost]
        [Route("clear")]
        public IActionResult Clear()
        {
            HttpContext.Session.Clear();
            return View("Welcome");
        }
    }
}
 
// Somewhere in your namespace, outside other classes
public static class SessionExtensions
{
    // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        // This helper function simply serializes theobject to JSON and stores it as a string in session
        session.SetString(key, JsonConvert.SerializeObject(value));
    }
       
    // generic type T is a stand-in indicating that we need to specify the type on retrieval
    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        string value = session.GetString(key);
        // Upon retrieval the object is deserialized based on the type we specified
        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
}
