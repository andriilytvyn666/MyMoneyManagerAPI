using Microsoft.EntityFrameworkCore;
using MyMoneyManagerApi.Models;

namespace MyMoneyManagerApi;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Notebook> Notebooks { get; set; }
    public DbSet<Operation> Operations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=./app.db");
    }
}
