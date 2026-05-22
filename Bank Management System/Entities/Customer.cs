using System;
using System.ComponentModel.DataAnnotations;

namespace Bank_Management_System.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(14)]
        public string NationalId { get; set; }

        public CustomerType CustomerType { get; set; }

        public string Status { get; set; }
        public ICollection<CustomerAccount> CustomerAccounts { get; set; } = [];
    }
}