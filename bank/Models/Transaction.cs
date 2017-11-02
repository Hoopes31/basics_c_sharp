using System.ComponentModel.DataAnnotations;
namespace scaffold.Models
{
    public class Transaction : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public float amount { get; set; }
        public int AccountId { get; set; }
    }
}