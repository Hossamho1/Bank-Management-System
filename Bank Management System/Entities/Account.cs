using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Management_System.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public decimal CurrentBalance { get; set; }

        public AccountType AccountType { get; set; }

        public required DateTime OpeningDate { get; set; }

        public int BranchCode { get; set; }
        public Branch Branch { get; set; }
        public List<Transaction> Transactions { get; set; } = [];
        public ICollection<CustomerAccount> CustomerAccounts { get; set; } = [];

    }
}
