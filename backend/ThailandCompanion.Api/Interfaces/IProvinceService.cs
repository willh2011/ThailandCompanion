using ThailandCompanion.Api.Domain.Location;

namespace ThailandCompanion.Api.Interfaces;

public interface IProvinceService
{
    List<Province> GetAll();

    Province? GetById(int id);
}