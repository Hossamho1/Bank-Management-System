using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Management_System.Entities;

public class CustomerAccount
{
    public int id { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public required DateTime OwnershipStartDate { get; set; }

    public OwnershipType OwnershipType { get; set; }

    public AccountStatus AccountStatus { get; set; }


}
