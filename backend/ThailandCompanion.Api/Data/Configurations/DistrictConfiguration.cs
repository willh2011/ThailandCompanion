using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThailandCompanion.Api.Entities;

namespace ThailandCompanion.Api.Data.Configurations;

public class DistrictConfiguration : IEntityTypeConfiguration<DistrictEntity>
{
    public void Configure(EntityTypeBuilder<DistrictEntity> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.NameEn)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(d => d.NameTh)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(d => d.Slug)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(d => d.Code)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(d => d.PublicId).IsUnique();
        builder.HasIndex(d => d.Code);
        builder.HasIndex(d => new { d.ProvinceId, d.Slug }).IsUnique();
    }
}