using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbConnection;

namespace quotingMVC.Controllers
{
    public class Quotes : Controller
    {
        // adding non static db connection
        private readonly DbConnector _dbConnector;
        public Quotes(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            return View();
        }
        [HttpPost]
        [Route("add_quote")]
        public IActionResult AddQuote(string quote, string name)
        {
            string query = $"INSERT INTO quotes(quote, name) VALUES (\"{quote}\",\"{name}\")";
            _dbConnector.Execute(query);
            return RedirectToAction("ShowQuotes");
        }
        [HttpGet]
        [Route("show_quotes")]
        public IActionResult ShowQuotes()
        {
            List<Dictionary<string, object>> AllQuotes; 
            string query = "SELECT * FROM quotes";
            AllQuotes = _dbConnector.Query(query);
            ViewBag.quotes = AllQuotes;
            return View();
        }
    }

}
