using System;
using System.ComponentModel.DataAnnotations;
namespace restEntity.Models

{
    public class ReviewViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string reviewer_name { get; set; }
        [Required(ErrorMessage = "Review is required")]
        public string review { get; set; }

        public Restaurant restaurant { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [ValidDateAttribute]
        public DateTime date_visited { get; set; }
        public int stars { get; set; }
    }
    // Custom Data Annotations for validators
    public class ValidDateAttribute : ValidationAttribute
    {
        private DateTime _today = DateTime.Now;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ReviewViewModel restaurant = (ReviewViewModel)validationContext.ObjectInstance;
            if(_today >= restaurant.date_visited)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date must be not be in the future");
            }
        }
    }
}