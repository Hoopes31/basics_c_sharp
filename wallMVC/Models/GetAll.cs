using System;
using System.Collections.Generic;
namespace scaffold.Models
{
    public class GetAll : BaseEntity
    {
        public List<MessageModel> messages {get;set;}
        public List<LikeModel> likes {get;set;}
    }
}