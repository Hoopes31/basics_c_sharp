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
    public class BankController : Controller
    {
        private readonly MyContext _context;
        public BankController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("bank")]
        public IActionResult Index()
        {
            int id = (int)HttpContext.Session.GetInt32("id");
            Account Account = _context.Accounts
                .Include(account => account.User)
                .Include(account => account.Transactions)
                .ToList()
                .SingleOrDefault(account => account.User.id == id);
            
            ViewBag.balance = Account.balance.ToString("C");
            ViewBag.user = Account.User.first_name;

            if (Account.Transactions != null)
            {
                ViewBag.transactions = Account.Transactions.OrderBy(trans => trans.created_date);
            }
            return View();
        }

        [HttpPost]
        [Route("transaction")]
        public IActionResult Transaction(TransactionViewModel model)
        {
            if(ModelState.IsValid)
            {
                int id = (int)HttpContext.Session.GetInt32("id");
                float deposit = model.amount;

                if (model.transaction_type != "deposit")
                {
                    deposit = deposit * -1;
                }

                Account Account = _context.Accounts
                    .Include(account => account.User)
                    .SingleOrDefault(account => account.UserId == id);

                Transaction newTransaction = new Transaction
                {
                    amount = deposit,
                    AccountId = Account.id,
                    created_date = DateTime.Now,
                    updated_date = DateTime.Now
                };

                Account.balance = Account.balance + deposit;

                _context.Add(newTransaction);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}