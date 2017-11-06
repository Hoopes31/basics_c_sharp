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
        //Show All Messages & likes
        [HttpGet]
        [Route("wall")]
        public IActionResult Index()
        {
            ViewBag.Messages = messageFactory.GetAllMessages();
            ViewBag.MessageForm = new MessageViewModel();
            ViewBag.LikeForm = new LikeViewModel();
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
        [Route("like")]
        public IActionResult Like(LikeViewModel model)
        {
            //Check if like is already registered in system
            int id = (int)HttpContext.Session.GetInt32("id");
            if(ModelState.IsValid && messageFactory.CheckLikes(model.message_id, id) == null)
                {
                    LikeModel newLike = new LikeModel
                    {
                        message_id = model.message_id
                    };
                    messageFactory.LikePost(newLike, id);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("liked_by")]
        public IActionResult LikedBy(int message_id)
        {
            //Get message and message likers
            ViewBag.Message = messageFactory.GetMessage(message_id);
            return View();
        }
        [HttpGet]
        [Route("profile")]
        public IActionResult Profile(int profileId)
        {
            System.Console.WriteLine(profileId);

            var profile = userFactory.FindById(profileId);

            if (profile != null)
            {
                ViewBag.first_name = profile.first_name;
                ViewBag.last_name = profile.last_name;
                ViewBag.email = profile.email;
                ViewBag.info = messageFactory.UsersMessages(profileId);
            }
            else {
                System.Console.WriteLine("NO");
            }
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