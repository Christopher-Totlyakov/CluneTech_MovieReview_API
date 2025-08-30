using System.Reflection;
using Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

/// <summary>
/// Database
/// </summary>
public class RepositoryContext : IdentityDbContext<ApplicationUser>
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
       : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<Episode> Episodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Seed();
    }
}
