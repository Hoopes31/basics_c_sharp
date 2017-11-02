using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace scaffold.Models
{
    public class Account : BaseEntity
    {
        //Notice no Transaction ID is supplied here
        //Entity implicitly searches for Transactions that match this accounts ID
        //As we have established a 1 to many relation between Account => Transactions
        public Account()
        {
            Transactions = new List<Transaction>();
        }
        [Key]
        public int id { get; set; }
        public float balance { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}