using System;
namespace App.Models
{
    public abstract class BaseEntity 
    {
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
    }
}