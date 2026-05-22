using Bank_Management_System.Data;
using Bank_Management_System.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Management_System.Operations;

public  class CustomerAccountServies
{

    public async Task UpdateAccountAsync(ApplicationDbContext dbContext)
    {
        Console.Write("Enter Account ID: ");

        int accountId;
        CustomerAccount updateAcc;

        while (!int.TryParse(Console.ReadLine(), out accountId) )
        {
            Console.WriteLine("Error: Invalid account number format or account not found.");
            Console.Write("Please enter a valid Account ID: ");
        }
        int customerId;

        Console.Write("Enter Customer ID: ");

        while (!int.TryParse(Console.ReadLine(), out customerId) )
        {
            Console.WriteLine("Error: Invalid customer number format or customer not found.");
            Console.Write("Please enter a valid Customer ID: ");
        }



            updateAcc = await dbContext.CustomerAccounts.FirstOrDefaultAsync(ca => ca.AccountId == accountId && ca.CustomerId == customerId);
        if (updateAcc==null)
        {
            Console.WriteLine("Error: Link between this Customer and Account not found in the database.");
            return;
        }

        Console.Write("Enter AccountStatus (Active/Inactive): ");
        string accountStatusInput = Console.ReadLine();
        if (!Enum.TryParse(accountStatusInput, out AccountStatus accountStatus) || !Enum.IsDefined(typeof(AccountStatus), accountStatus))
        {
            Console.WriteLine("Error: Invalid account status. Please enter 'Active' or 'Inactive'.");
            return;
        }
        updateAcc.AccountStatus = accountStatus;

        try
        { 
            await dbContext.SaveChangesAsync();
            Console.WriteLine("Account updated successfully.");

    }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating account: {ex.Message}");
        }
    }

    public async Task DeleteAccount(ApplicationDbContext dbContext)
    {
        Console.Write("Enter Account ID: ");

        int accountId;
        CustomerAccount deleteAcc;

        while (!int.TryParse(Console.ReadLine(), out accountId))
        {
            Console.WriteLine("Error: Invalid account number format or account not found.");
            Console.Write("Please enter a valid Account ID: ");
        }
        int customerId;

        Console.Write("Enter Customer ID: ");

        while (!int.TryParse(Console.ReadLine(), out customerId))
        {
            Console.WriteLine("Error: Invalid customer number format or customer not found.");
            Console.Write("Please enter a valid Customer ID: ");
        }



        deleteAcc = await dbContext.CustomerAccounts.FirstOrDefaultAsync(ca => ca.AccountId == accountId && ca.CustomerId == customerId);
        if (deleteAcc == null)
        {
            Console.WriteLine("Error: Link between this Customer and Account not found in the database.");
            return;
        }

       

        try
        {
            dbContext.CustomerAccounts.Remove(deleteAcc);
            await dbContext.SaveChangesAsync();
            Console.WriteLine("Account deleted successfully.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting account: {ex.Message}");
        }
    }


    



}
