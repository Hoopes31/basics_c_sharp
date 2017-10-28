using System;
namespace scaffold.Models
{
    public class User : BaseEntity
    {
        public string firstName {get;set;}
        public string lastName {get;set;}
        public string email {get;set;}
        public string password {get;set;}
    }   
}