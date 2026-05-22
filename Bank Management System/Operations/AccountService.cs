using Bank_Management_System.Data;
using Bank_Management_System.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Bank_Management_System.Operations;

public class AccountService
{
    public async Task AddAccountAsync(ApplicationDbContext dbContext)
    {
        Console.WriteLine("\n--- Opening a New Account ---");

        Console.Write("Enter Account Number: ");
        int accountNumber;
        while (!int.TryParse(Console.ReadLine(), out accountNumber))
        {
            Console.WriteLine("Error: Account number cannot be empty.");
            Console.Write("Enter Account Number: ");
        }

        Console.WriteLine("Enter Account Type (1 for Savings, 2 for Checking , 3 for Business):");
        string accountTypeInput = Console.ReadLine();
        AccountType accountType;
        while (Enum.TryParse(accountTypeInput, out accountType) || Enum.IsDefined(typeof(AccountType), accountType))
        {
            Console.Write("Invalid choice. Please enter 1 , 2 , or 3: ");


        }

        Console.Write("Enter Branch Code (ID): ");
        int branchId;
        while (!int.TryParse(Console.ReadLine(), out branchId) || !await dbContext.Branches.AnyAsync(b => b.Code == branchId))
        {
            Console.WriteLine("Error: Branch not found or invalid Code. Please enter a valid existing Branch Code.");
            Console.Write("Enter Branch Code (ID): ");
        }

        Console.Write("Enter Customer ID: ");
        int customerId;
        while (!int.TryParse(Console.ReadLine(),out customerId ) || !await dbContext.Customers.AnyAsync(c => c.Id == customerId))
        {
            Console.WriteLine("Error: Customer not found or invalid ID. Please enter a valid existing Customer ID.");
            Console.Write("Enter Customer ID: ");
        }

        Console.WriteLine("Enter ownership Type (1 for Primary Holder, 2 for Co-Holder): ");
        int ownershipTypeInput;
        OwnershipType ownershipType;
        while (!Enum.TryParse(Console.ReadLine(), out ownershipType)|| !Enum.IsDefined(typeof(OwnershipType), ownershipType))
        {
            Console.Write("Invalid choice. Please enter 1 or 2: ");
        }

        Console.WriteLine("Enter Account Status (1 for Active, 2 for Inactive, 3 for Suspended, 4 for Closed): ");
        AccountStatus accountStatus;

        while (!Enum.TryParse(Console.ReadLine(), out accountStatus) || !Enum.IsDefined(typeof(AccountStatus), accountStatus))
        {
            Console.Write("Invalid choice. Please enter a number between 1 and 4: ");
        }
        try
        {
            var newAccount = new Account
            {
                Id = accountNumber,
                CurrentBalance = 0,
                AccountType = accountType,
                OpeningDate = DateTime.Now,
                BranchCode = branchId,

            };
            await dbContext.Accounts.AddAsync(newAccount);
            await dbContext.SaveChangesAsync();


            var customerAccountLink = new CustomerAccount
            {
                CustomerId = customerId,
                AccountId = newAccount.Id,
                OwnershipType = ownershipType,
                OwnershipStartDate = DateTime.Now, 
                AccountStatus = accountStatus
            };


            await dbContext.CustomerAccounts.AddAsync(customerAccountLink);
            await dbContext.SaveChangesAsync();
        }
        
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while adding account: {ex.Message}");
        }




    }


    
}
