using Bank_Management_System.Entities;
using Microsoft.EntityFrameworkCore;
namespace Bank_Management_System.Data;

public class ApplicationDbContext : DbContext
{


    protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BankManagementDB;Trusted_Connection=True;TrustServerCertificate=True;");

    }


    public DbSet<Account> Accounts { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<CustomerAccount> CustomerAccounts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.FullName)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.Property(c => c.NationalId)
                  .IsRequired()
                  .HasMaxLength(14);
        });


        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(t => t.TransactionNumber);

            entity.Property(t => t.Amount)
                  .HasColumnType("decimal(18,2)")
                  .IsRequired();

            entity.Property(t => t.TransactionType)
                  .IsRequired();
            entity.HasOne(t => t.Account)
            .WithMany(a => a.Transactions)
            .HasForeignKey(t => t.AccountId)
            .IsRequired();
        });


        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(b => b.Code);

            entity.Property(b => b.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.HasOne(b => b.Manager)
                  .WithOne(m => m.Branch)
                  .HasForeignKey<Branch>(b => b.ManagerId)
                  .IsRequired();
                                
        });
        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(m => m.Id);

            entity.Property(m => m.FullName)
                  .IsRequired();
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.CurrentBalance)
                  .HasColumnType("decimal(18,2)")
                  .IsRequired();

            entity.HasOne(b => b.Branch)
              .WithMany(b => b.Accounts)
              .HasForeignKey(a => a.BranchCode)
              .IsRequired();
        });


    }
}