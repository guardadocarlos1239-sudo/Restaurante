using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;

namespace Restaurante.Infrastructure.Data;

public class HabitForgeDbContext : DbContext
{
    public HabitForgeDbContext(DbContextOptions<HabitForgeDbContext> options)
        : base(options) { }

    public DbSet<Comida> Comidas { get; set; }
    public DbSet<Bebida> Bebidas { get; set; }
    public DbSet<Postre> Postres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comida>().ToTable("comidas");
        modelBuilder.Entity<Bebida>().ToTable("bebidas");
        modelBuilder.Entity<Postre>().ToTable("postres");

        base.OnModelCreating(modelBuilder);
    }
}