using System;
namespace restEntity.Models
{
    public class Review
    {
        public int id { get; set; }
        public string reviewer_name { get; set; }
        public string review { get; set; }
        public int stars { get; set; }
        public Restaurant restaurant { get; set; }
        public DateTime date_visited { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
    }
}
    