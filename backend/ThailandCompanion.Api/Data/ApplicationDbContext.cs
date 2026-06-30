using Microsoft.EntityFrameworkCore;
using ThailandCompanion.Api.Entities;
using ThailandCompanion.Api.Data.Seed;

namespace ThailandCompanion.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<ProvinceEntity> Provinces => Set<ProvinceEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}