using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bank_Management_System.Entities
{
    public class Branch
    {
        [Key]
        public int Code { get; set; }

        [Required] 
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int ManagerId { get; set; } 
        public Manager Manager { get; set; }


        public List<Account> Accounts { get; set; } = [];



    }
}