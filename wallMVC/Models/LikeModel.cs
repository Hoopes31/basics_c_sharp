using System;
using System.Collections.Generic;
namespace scaffold.Models
{
    public class LikeModel : BaseEntity
    {
        public User user {get;set;}
        public int message_id {get;set;}
    }
}