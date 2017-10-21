using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mvcBASICS{
    public class HelloController : Controller
    {
        //GET
    
        [HttpGet] //Whaaaaat add the get route on the controller! Woo!
        [Route("index")] //This is the route! Note no leading slashes!
        public string index()
        {
            return "Hello World";
        }

        //GET with Parameter
        [HttpGet]
        [Route("name/{firstName}/{lastName}/{age}/{favoriteColor}")]
        public JsonResult Method(string firstName, string lastName, int age, string favoriteColor)
        {
            string hello = $"Hello, {firstName} {lastName} {age} {favoriteColor}";
            return Json(hello);
        }
        //POST

        // [HttpPost]
        // [Route("")]
        // public IActionResult Other()
        // {

        // }
    }
}