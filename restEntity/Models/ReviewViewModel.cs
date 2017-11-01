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
        public DateTime date_visited { get; set; }
        public int stars { get; set; }
    }
}