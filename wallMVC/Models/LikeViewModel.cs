using System.ComponentModel.DataAnnotations;

namespace scaffold.Models
{
    public class LikeViewModel : BaseEntity
    {
        [Required]
        public int message_id {get;set;}
    }
}