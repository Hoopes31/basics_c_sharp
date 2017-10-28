using System;
namespace scaffold.Models
{
    public class Message : BaseEntity
    {
        public string body {get;set;}
        public User user {get;set;}
    }
}