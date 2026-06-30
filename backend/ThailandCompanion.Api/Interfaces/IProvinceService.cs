using ThailandCompanion.Api.DTOs;

namespace ThailandCompanion.Api.Interfaces;

public interface IProvinceService
{
    List<ProvinceDto> GetAll();

    ProvinceDto? GetById(int id);
}