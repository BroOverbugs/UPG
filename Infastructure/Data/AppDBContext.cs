using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infastructure.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> dbContextOptions) : base(dbContextOptions)
    {
        Database.EnsureCreated();
    }

    public DbSet<Housing> Housings { get; set; }
    public DbSet<Keyboard> Keyboards { get; set; }
    public DbSet<Laptop> Laptops { get; set; }
    public DbSet<Mice> Mices { get; set; }
    public DbSet<Accessories> Accessories { get; set; }
    public DbSet<Domain.Entities.Monitor> Monitors { get; set; }
    public DbSet<Mouse_pads> Mouse_Pads { get; set; }
    public DbSet<RAM> RAMs { get; set; }
    public DbSet<Tables_for_gamers> Tables_For_Gamers { get; set; }
    public DbSet<Power_supplies> Power_Supplies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}