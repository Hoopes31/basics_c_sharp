// Custom Validations

//--- Model/model.cs
using System;
using System.ComponentModel.DataAnnotations;
namespace restEntity.Models

{
    public class ModelName
    {

        [Required(ErrorMessage = "Date is required")]
        [DateCheck]
        public DateTime date_visited { get; set; }
    }

    public class DateCheck : ValidationAttribute
    {
        //Check variables here
        private DateTime _today = DateTime.Now;

        //IsValid Override
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){

            ModelName restaurant = (ModelName)validationContext.ObjectInstance;

            if(_today >= restaurant.date_visited){
                return ValidationResult.Success;
            }
            else{
                //Create new ValidationResult to be sent to fornt end
                return new ValidationResult("Date must be not be in the future");
            }
        }
    }
}

// --Extensions.cs
// To use create instance of EmailValidator in your controller
// with your local _context variable as a parameter
// Then call the CheckEmail Method
// Returns True if the email is Valid and False otherwise. 

using WeddingApp.Models;

    public class EmailValidator
    {
        private readonly MyContext _context;
        public EmailValidator(MyContext context)
        {
            _context = context;
        }
        public bool CheckEmail(string email)
        {
            User user = _context.Users.SingleOrDefault(User => User.email == email);
            if (user != null)
            {
                return false;
            }
            return true;
        }
    }