using System;
using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionNumber { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now; 

        [Required]
        public decimal Amount { get; set; } 

        [Required]
        public TransactionType TransactionType { get; set; }

        public string? Note { get; set; } 
        public int AccountId { get; set; }

        public  Account Account { get; set; }
    }
}