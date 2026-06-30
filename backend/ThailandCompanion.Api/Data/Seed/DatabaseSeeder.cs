namespace ThailandCompanion.Api.Data.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (!context.Provinces.Any())
        {
            var now = DateTime.UtcNow;

            var provinces = ProvinceSeeder.GetProvinces();

            foreach (var province in provinces)
            {
                province.PublicId = Guid.NewGuid();
                province.CreatedAt = now;
                province.UpdatedAt = now;
            }

            context.Provinces.AddRange(provinces);
            await context.SaveChangesAsync();
        }
    }
}