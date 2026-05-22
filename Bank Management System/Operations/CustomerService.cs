using Bank_Management_System.Data;
using Bank_Management_System.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Bank_Management_System.Operations;

public class CustomerService
{
    public async Task AddCustomerAsync(ApplicationDbContext dbContext)
    {
        Console.WriteLine("\n--- Adding new customer ---");

        Console.WriteLine("Enter customer name:");
        string fullName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(fullName))
        {
            Console.WriteLine("Error: Name cannot be empty or just spaces.");
            Console.WriteLine("Enter customer name:");
            fullName = Console.ReadLine();
        }

        Console.Write("Enter customer national ID (14 digits): ");
        string nationalId = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nationalId) || nationalId.Length != 14 || !nationalId.All(char.IsDigit))
        {
            Console.WriteLine("Error: Invalid national ID format. It must be exactly 14 digits.");
            Console.Write("Enter customer national ID (14 digits): ");
            nationalId = Console.ReadLine();
        }

        DateTime dob;
        Console.Write("Enter your Date of Birth (e.g., 1995-05-20): ");
        while (!DateTime.TryParse(Console.ReadLine(), out dob))
        {
            Console.Write("Invalid format. Please enter a valid date: ");
        }

        Console.WriteLine("Enter customer email:");
        string email = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Error: Email cannot be empty.");
            }
            else
            {
                Console.WriteLine("Error: Invalid email format. It must contain '@'.");
            }
            Console.WriteLine("Enter customer email:");
            email = Console.ReadLine();
        }

        Console.WriteLine("Enter customer phone number:");
        string phoneNumber = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(phoneNumber) || !phoneNumber.All(char.IsDigit))
        {
            Console.WriteLine("Error: Phone number cannot be empty and must contain only digits.");
            Console.WriteLine("Enter customer phone number:");
            phoneNumber = Console.ReadLine();
        }

        Console.WriteLine("Enter customer Address:");
        string address = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(address))
        {
            Console.WriteLine("Error: Address cannot be empty.");
            Console.WriteLine("Enter customer Address:");
            address = Console.ReadLine();
        }

        Console.WriteLine("Enter customer type (1 for Individual, 2 for Business):");
        string customerTypeInput = Console.ReadLine();
        CustomerType customerType;

        while (!Enum.TryParse(customerTypeInput, out customerType) || !Enum.IsDefined(typeof(CustomerType), customerType))
        {
            Console.Write("Invalid choice. Please enter 1 or 2: ");
            customerTypeInput = Console.ReadLine();
        }

        var customerObject = new Customer
        {
            FullName = fullName,
            NationalId = nationalId,
            DateOfBirth = dob,
            Email = email,
            PhoneNumber = phoneNumber,
            Address = address,
            CustomerType = customerType,
        };

        try
        {
            await dbContext.Customers.AddAsync(customerObject);
            await dbContext.SaveChangesAsync();

            Console.WriteLine("\nCustomer added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while saving: {ex.Message}");
        }










    }

   

    public async Task GetAllCustomerAccountsAsync(ApplicationDbContext dbContext)
    {
        Console.WriteLine("\n--- All Customers and their Accounts ---");

        var customers = await dbContext.Customers
            .Include(c => c.CustomerAccounts)
            .ThenInclude(ca => ca.Account)
            .ToListAsync();

        foreach (var customer in customers)
        {
            Console.WriteLine($"\nCustomer: {customer.FullName} (ID: {customer.Id})");

            if (customer.CustomerAccounts.Any())
            {
                Console.WriteLine("Accounts:");
                foreach (var customerAccount in customer.CustomerAccounts)
                {
                    var account = customerAccount.Account;
                    Console.WriteLine($"- Account Number: {account.Id}, Balance: {account.CurrentBalance:C}");
                }
            }
            else
            {
                Console.WriteLine("No accounts found for this customer.");
            }
        }
    }

}