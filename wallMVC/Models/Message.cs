using System;
namespace scaffold.Models
{
    public class Message : BaseEntity
    {
        public string body {get;set;}
        public User user {get;set;}
        public DateTime createdDate {get;set;}
        public DateTime updatedDate {get;set;}
    }
}