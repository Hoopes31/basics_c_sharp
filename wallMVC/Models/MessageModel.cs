using System;
using System.Collections.Generic;
namespace scaffold.Models
{
    public class MessageModel : BaseEntity
    {
        public string body {get;set;}
        public User user {get;set;}
        public CommentModel comment {get;set;}
        public int id {get;set;}
    }
}