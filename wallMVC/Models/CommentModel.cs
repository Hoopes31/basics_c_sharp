namespace scaffold.Models
{
    public class Comment : BaseEntity
    {
        public string body {get;set;}
        public User user {get;set;}
    }
}