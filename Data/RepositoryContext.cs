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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Seed();
    }
}
