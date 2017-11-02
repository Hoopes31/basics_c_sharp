using System.ComponentModel.DataAnnotations;
namespace scaffold.Models
{
    public class TransactionViewModel : BaseEntity
    {
        [Required]
        public float amount { get; set; }

        [Required(ErrorMessage = "Please select a transaction type")]
        public string transaction_type { get; set; }
    }
}