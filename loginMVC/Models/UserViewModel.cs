using System.ComponentModel.DataAnnotations;

namespace scaffold.Models
{
    public class UserViewModel : BaseEntity
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be greater than 2 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Non-Letter Characters are not permitted")]
        public string firstName {get;set;}
        [Required]
        [MinLength(2, ErrorMessage = "Name must be greater than 2 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Non-Letter Characters are not permitted")]
        public string lastName {get;set;}
        [Required]
        [EmailAddress]
        public string email {get;set;}
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password {get;set;}
        [Required]
        [MinLength(8)]
        [Compare("password", ErrorMessage = "Password and confirmation must match.")]
        public string passwordConfirm{get;set;}
    }
}