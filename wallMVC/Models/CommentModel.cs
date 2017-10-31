using System;
using System.Collections.Generic;
namespace scaffold.Models
{
    public class CommentModel : BaseEntity
    {
        public string body {get;set;}
        public User user {get;set;}
        public int message_id {get;set;}
    }
}