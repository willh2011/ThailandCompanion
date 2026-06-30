using Microsoft.EntityFrameworkCore;
using ThailandCompanion.Api.Entities;

namespace ThailandCompanion.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProvinceEntity> Provinces => Set<ProvinceEntity>();

    public DbSet<DistrictEntity> Districts => Set<DistrictEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}