using System.ComponentModel.DataAnnotations;

namespace scaffold.Models
{
    public class MessageViewModel : BaseEntity
    {
        [Required]
        public string body {get;set;}
    }
}