using System.ComponentModel.DataAnnotations;

namespace scaffold.Models
{
    public class CommentViewModel : BaseEntity
    {
        [Required]
        public string body {get;set;}
        public int message_id {get;set;}
    }
}