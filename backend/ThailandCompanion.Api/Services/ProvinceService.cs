using ThailandCompanion.Api.Domain.Location;
using ThailandCompanion.Api.Interfaces;

namespace ThailandCompanion.Api.Services;

public class ProvinceService : IProvinceService
{
    private readonly List<Province> _provinces =
    [
        new Province { Id = 1, Name = "Bangkok", Code = "BKK"},
        new Province { Id = 2, Name = "Chiang Mai", Code = "CNX"},
        new Province { Id = 3, Name = "Prachuap Khiri Khan", Code = "PKN"}
    ];

    public List<Province> GetAll()
    {
        return _provinces;
    }

    public Province? GetById(int id)
    {
        return _provinces.FirstOrDefault(p => p.Id == id);
    }
}