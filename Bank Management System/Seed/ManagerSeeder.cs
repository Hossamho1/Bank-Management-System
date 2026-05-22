using Bank_Management_System.Data;
using Bank_Management_System.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Management_System.Seed
{
    public static class ManagerSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (!await dbContext.Managers.AnyAsync())
            {
                List<Manager> managers = new List<Manager>()
                {
                   new Manager {  FullName = "Alice...", PhoneNumber = "01012345678", Email = "alice@bank.com" },
                   new Manager { FullName = "Charlie...", PhoneNumber = "01198765432", Email = "charlie@bank.com" },
                   new Manager {  FullName = "Mo Salah", PhoneNumber = "01234567890", Email = "mosalah@bank.com" }
                };

                await dbContext.Managers.AddRangeAsync(managers);
                await dbContext.SaveChangesAsync();
                                                }
        }
    }
}
