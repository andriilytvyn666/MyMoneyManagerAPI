using Microsoft.EntityFrameworkCore;
using MyMoneyManagerApi.Models;

namespace MyMoneyManagerApi;

/// <summary>
/// Database context configuration class
/// </summary>
public class DatabaseContext : DbContext
{
    /// <summary>
    /// Users list representation
    /// </summary>
    public DbSet<User> Users { get; set; }
    /// <summary>
    /// Notebooks list representation
    /// </summary>
    public DbSet<Notebook> Notebooks { get; set; }
    /// <summary>
    /// Operations list representation
    /// </summary>
    public DbSet<Operation> Operations { get; set; }

    /// <summary>
    /// On database configuring event
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=./app.db");
    }

    /// <summary>
    /// On model creating event
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Notebook>().HasOne<User>().WithMany().HasForeignKey(n => n.UserId);
        modelBuilder.Entity<Notebook>().HasMany<Operation>().WithOne().HasForeignKey(n => n.NotebookId);
    }
}
