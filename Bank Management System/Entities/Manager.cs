using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bank_Management_System.Entities
{
    public class Manager
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        public Branch Branch { get; set; }


    }
}                                                     