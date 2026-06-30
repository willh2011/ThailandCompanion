using Microsoft.EntityFrameworkCore;
using ThailandCompanion.Api.Data.Import;

namespace ThailandCompanion.Api.Data.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var filePath = Path.Combine(
            AppContext.BaseDirectory,
            "..", "..", "..", "..", "..",
            "database",
            "seed",
            "thailand-administrative-data.csv"
        );

        var importResult = ThailandAdministrativeImporter.Import(filePath);

        var existingProvinceCodes = context.Provinces
            .Select(p => p.Code)
            .ToHashSet();

        var missingProvinces = importResult.Provinces
            .Where(p => !existingProvinceCodes.Contains(p.Code))
            .ToList();

        if (missingProvinces.Any())
        {
            context.Provinces.AddRange(missingProvinces);
            await context.SaveChangesAsync();
        }

        if (!context.Districts.Any())
        {
            var existingProvinces = await context.Provinces.ToListAsync();

            foreach (var district in importResult.Districts)
            {
                var matchingProvince = existingProvinces
                    .First(p => p.Code == district.Province.Code);

                district.Province = matchingProvince;
                district.ProvinceId = matchingProvince.Id;
            }

            context.Districts.AddRange(importResult.Districts);
            await context.SaveChangesAsync();
        }
    }
}