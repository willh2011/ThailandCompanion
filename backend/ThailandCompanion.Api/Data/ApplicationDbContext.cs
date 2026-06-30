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
}