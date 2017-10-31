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
    public class WallController : Controller
    {
        private readonly MessageFactory messageFactory;
        private readonly UserFactory userFactory;
        public WallController(MessageFactory connectMessage, UserFactory connectUser)
        {
            messageFactory = connectMessage;
            userFactory = connectUser;
        }
        //Show All Messages & Comments
        [HttpGet]
        [Route("wall")]
        public IActionResult Index()
        {
            ViewBag.Messages = messageFactory.GetAllMessages();
            ViewBag.MessageForm = new MessageViewModel();
            ViewBag.CommentForm = new CommentViewModel();
            return View();
        }
        
        [HttpPost]
        [Route("add_message")]
        public IActionResult AddMessage(MessageViewModel model)
        {
                if(ModelState.IsValid)
                {
                    int id = (int)HttpContext.Session.GetInt32("id");
                    MessageModel newMessage = new MessageModel
                    {
                        body = model.body
                    };
                    messageFactory.AddNewMessage(newMessage, id);
                return RedirectToAction("Index");
            }
            //Find a way to make the AddMessage Syntax match the controller call.
            return View(model);
        }
        [HttpPost]
        [Route("add_comment")]
        public IActionResult AddComment(CommentViewModel model)
        {
            if(ModelState.IsValid)
                {
                    int id = (int)HttpContext.Session.GetInt32("id");
                    CommentModel newComment = new CommentModel
                    {
                        body = model.body,
                        message_id = model.message_id
                    };
                    messageFactory.AddNewComment(newComment, id);
                return RedirectToAction("Index");
            }
            //Find a way to make the AddMessage Syntax match the controller call.
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