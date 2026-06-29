using ThailandCompanion.Api.Domain.Location;

namespace ThailandCompanion.Api.Services;

public class ProvinceService
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

    public Province? GetByID(int id)
    {
        return _provinces.FirstOrDefault(p => p.Id == id);
    }
}