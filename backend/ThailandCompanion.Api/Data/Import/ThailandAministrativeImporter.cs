using ThailandCompanion.Api.Data.Seed;
using ThailandCompanion.Api.Entities;

namespace ThailandCompanion.Api.Data.Import;

public class ThailandImportResult
{
    public List<ProvinceEntity> Provinces { get; set; } = [];
    public List<DistrictEntity> Districts { get; set; } = [];
}

public static class ThailandAdministrativeImporter
{
    public static ThailandImportResult Import(string filePath)
    {
        var provinces = new Dictionary<string, ProvinceEntity>();

        var districts = new Dictionary<string, DistrictEntity>();
        var now = DateTime.UtcNow;


        var lines = File.ReadAllLines(filePath).Skip(1);

        foreach (var line in lines)
        {
            var columns = line.Split(',');

            var provinceEn = columns[0].Trim();
            var provinceTh = columns[1].Trim();
            var provinceCode = columns[2].Trim();
            var districtEn = columns[3].Trim();
            var districtTh = columns[4].Trim();
            var districtCode = columns[5].Trim();

            if (!provinces.ContainsKey(provinceCode))
            {
                provinces[provinceCode] = new ProvinceEntity
                {
                    PublicId = Guid.NewGuid(),
                    NameEn = provinceEn,
                    NameTh = provinceTh,
                    Slug = CreateSlug(provinceEn),
                    Code = provinceCode,
                    CreatedAt = now,
                    UpdatedAt = now
                };
            }

            var province = provinces[provinceCode];

            var districtKey = $"{provinceCode}-{districtEn}";

            if (!districts.ContainsKey(districtKey))
                {
                    districts[districtKey] = new DistrictEntity
                        {
                            PublicId = Guid.NewGuid(),
                            NameEn = districtEn,
                            NameTh = districtTh,
                            Code = CreateSlug(districtEn),
                            Slug = CreateSlug(districtEn),
                            Province = province,
                            CreatedAt = now,
                            UpdatedAt = now
                        };
                }
        }

        return new ThailandImportResult
        {
            Provinces = provinces.Values.ToList(),
            Districts = districts.Values.ToList()
        };
    }

    private static string CreateSlug(string value)
    {
        return value
            .Trim()
            .ToLowerInvariant()
            .Replace(" ", "-");
    }
}