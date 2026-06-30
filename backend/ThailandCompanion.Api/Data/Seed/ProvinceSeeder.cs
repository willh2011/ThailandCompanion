using ThailandCompanion.Api.Entities;

namespace ThailandCompanion.Api.Data.Seed;

public static class ProvinceSeeder
{
    public static IEnumerable<ProvinceEntity> GetProvinces()
    {
        return new List<ProvinceEntity>
        {
            new()
            {
                Id = 1,
                NameEn = "Bangkok",
                NameTh = "กรุงเทพมหานคร",
                Slug = "bangkok",
                Code = "BKK",
                Latitude = 13.7563m,
                Longitude = 100.5018m,
                
            },

            new()
            {
                Id = 2,
                NameEn = "Chiang Mai",
                NameTh = "เชียงใหม่",
                Slug = "chiang-mai",
                Code = "CNX",
                Latitude = 18.7883m,
                Longitude = 98.9853m
            },

            new()
            {
                Id = 3,
                NameEn = "Prachuap Khiri Khan",
                NameTh = "ประจวบคีรีขันธ์",
                Slug = "prachuap-khiri-khan",
                Code = "PKN",
                Latitude = 11.8124m,
                Longitude = 99.7973m
            }
        };
    }
}