using Bank_Management_System.Data;
using Bank_Management_System.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank_Management_System
{
    public static class BranchSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (await dbContext.Branches.AnyAsync())
            {
                return; 
            }
            var managers = await dbContext.Managers.ToListAsync();


            if (managers.Count < 3)
            {
                return;
            }

            List<Branch> branches = new List<Branch>
{
    new Branch
    {
        ManagerId = managers[0].Id, 
        Name = "Downtown Main",
        Address = "123 Financial District, New York, NY 10005",
        PhoneNumber = "212-555-0101"
    },
    new Branch
    {
        ManagerId = managers[1].Id,
        Name = "Westside Retail",
        Address = "456 Suburbia Avenue, Seattle, WA 98109",
        PhoneNumber = "206-555-0202"
    },
    new Branch
    {
        ManagerId = managers[2].Id, 
        Name = "Tech Hub Corporate",
        Address = "789 Innovation Parkway, Austin, TX 73301",
        PhoneNumber = "512-555-0303"
    }
};

            await dbContext.Branches.AddRangeAsync(branches);
            await dbContext.SaveChangesAsync();
        }
    }
}