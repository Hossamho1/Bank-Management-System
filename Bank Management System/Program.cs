using Bank_Management_System.Data;
using Bank_Management_System.Operations;
using Bank_Management_System.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Bank_Management_System;

public class Program
{
    static async Task Main(string[] args)
    {

        using var dbContext = new ApplicationDbContext();

      await  dbContext.Database.MigrateAsync();

        await DbSeeder.SeedAllAsync(dbContext);

        var accountService = new AccountService();

        var customerService = new CustomerService();

        var customerAccountServices = new CustomerAccountServies();

        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear(); 
            Console.WriteLine("========================================");
            Console.WriteLine("       BANK MANAGEMENT SYSTEM           ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Add a new Customer");
            Console.WriteLine("2. Open a new Account for a Customer");
            Console.WriteLine("3. Update Account Status");
            Console.WriteLine("4. Remove an Account from a Customer");
            Console.WriteLine("5. List all Customers (with accounts)");
            Console.WriteLine("0. Exit");
            Console.WriteLine("========================================");
            Console.Write("Enter your choice: ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("\nFriendly Error: Invalid input! Please enter a number.");
                PauseToReturn();
                continue; 
            }
            try
            {
                switch (input)
                {
                    case "1":
                        await customerService.AddCustomerAsync(dbContext);
                        break;
                    case "2":
                        await accountService.AddAccountAsync(dbContext);
                        break;
                    case "3":
                        await customerAccountServices.UpdateAccountAsync(dbContext);
                        break;
                    case "4":
                        await customerAccountServices.DeleteAccount(dbContext);

                        break;
                    case "5":

                        await customerService.GetAllCustomerAccountsAsync(dbContext);

                        break;

                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
            }

            if (isRunning)
            {
                PauseToReturn();
            }


            

        }
        static void PauseToReturn()
        {
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}