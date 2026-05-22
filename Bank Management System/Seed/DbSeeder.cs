using Bank_Management_System.Data;
using Bank_Management_System.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Seed;

    public class DbSeeder
{
    public static async Task SeedAllAsync(ApplicationDbContext dbContext)
    {
        await ManagerSeeder.SeedAsync(dbContext);  
        await BranchSeeder.SeedAsync(dbContext); 
        await CustomerSeeder.SeedAsync(dbContext);
    }
}
