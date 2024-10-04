using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MiniBankApp.Application.Configuration;
using MiniBankApp.Domain.Entities;

namespace MiniBankApp.Infrastructure.DataAccess;

public class MiniBankAppDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
        optionsBuilder.UseMySql(Configuration.Database.ConnectionString, serverVersion);
#if DEBUG
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();
#endif
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MiniBankAppDbContext).Assembly);
    }
}
