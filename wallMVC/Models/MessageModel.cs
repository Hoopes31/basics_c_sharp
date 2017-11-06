using System;
using System.Collections.Generic;
namespace scaffold.Models
{
    public class MessageModel : BaseEntity
    {
        public MessageModel()
        {
            List<LikeModel> likes = new List<LikeModel>();
        }
        public string body {get;set;}
        public User user {get;set;}
        public List<LikeModel> likes {get;set;}
        public int id {get;set;}
    }
}