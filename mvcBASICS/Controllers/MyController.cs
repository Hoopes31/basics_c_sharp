using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mvcBASICS
{
    public class MyController : Controller 
    // When using Views, the Controller name is used as
    // a search param in the Views folder
    // Make a folder that matches the Controller name inside Views
    {
        [HttpGet] //Request method
        [Route("my")] //route handler
        public IActionResult index() //View Matching Occurs within the Controller/View folder in Views.
        {
            return View(); //This is the implicit version of a return. You can explicitly call a cshtml file here if you like.
        }
    }
}