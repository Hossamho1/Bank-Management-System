

using Bank_Management_System.Data;
using Bank_Management_System.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Seed
{
    public static class CustomerSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if(await dbContext.Customers.AnyAsync()) 
            { 
                return; 
            }
            List<Customer> customers = new List<Customer>
{
    new Customer
    {
        FullName = "John Doe",
        Address = "123 Main St, Alexandria",
        DateOfBirth = new DateTime(1990, 5, 15), 
        Email = "john.doe@example.com",
        PhoneNumber = "01000000000",
        NationalId = "29005150200000", 
        Status = "Active"
    },
    new Customer
    {
        FullName = "Jane Smith",
        Address = "456 Corniche Rd, Alexandria",
        DateOfBirth = new DateTime(1995, 8, 20),
        Email = "jane.smith@example.com",
        PhoneNumber = "01100002300",
        NationalId = "29508200200000",
        Status = "Active"
    },
    new Customer
    {
        FullName = "Bob Johnson",
        Address = "789 Smouha, Alexandria",
        DateOfBirth = new DateTime(1985, 3, 10),
        Email = "bob.johnson@example.com",
        PhoneNumber = "01201200000",
        NationalId = "28503100200000",
        Status = "Active"
    }
};

            await dbContext.Customers.AddRangeAsync(customers);
            await dbContext.SaveChangesAsync();
        }

    }
}
