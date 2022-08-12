using Microsoft.EntityFrameworkCore;
using MyMoneyManager.Api.Models;

namespace MyMoneyManager.Api;

/// <summary>
/// Database context configuration class
/// </summary>
public class ApplicationDbContext : DbContext
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

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    /// <summary>
    /// On model creating event
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Notebook>().HasOne<User>().WithMany().HasForeignKey(n => n.UserId);
        modelBuilder.Entity<Notebook>().HasMany<Operation>().WithOne().HasForeignKey(n => n.NotebookId);
    }
}
