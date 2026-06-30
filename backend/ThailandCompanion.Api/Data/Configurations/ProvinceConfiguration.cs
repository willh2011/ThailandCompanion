using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThailandCompanion.Api.Entities;

namespace ThailandCompanion.Api.Data.Configurations;

public class ProvinceConfiguration : IEntityTypeConfiguration<ProvinceEntity>
{
    public void Configure(EntityTypeBuilder<ProvinceEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.NameEn)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.NameTh)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Slug)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(p => p.Slug).IsUnique();
        builder.HasIndex(p => p.Code).IsUnique();
        builder.HasIndex(p => p.PublicId).IsUnique();

        builder.HasMany(p => p.Districts)
            .WithOne(d => d.Province)
            .HasForeignKey(d => d.ProvinceId);
    }
}