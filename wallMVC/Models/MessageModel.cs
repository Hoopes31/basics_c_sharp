using System.Collections.Generic;
namespace scaffold.Models
{
    public class MessageModel : BaseEntity
    {
        public string body {get;set;}
        public User user { get; set; }
    }
}