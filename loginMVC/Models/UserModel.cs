using System;
namespace scaffold.Models
{
    public class User : BaseEntity
    {
        public string firstName {get;set;}
        public string lastName {get;set;}
        public string email {get;set;}
        public string password {get;set;}
        public DateTime createdDate {get;set;}
        public DateTime updatedDate {get;set;}
    }   
}