using ThailandCompanion.Api.DTOs;

namespace ThailandCompanion.Api.Interfaces;

public interface IDistrictService
{
    List<DistrictDto> GetAll();

    List<DistrictDto> GetByProvinceId(int provinceId);

    DistrictDto? GetById(int id);
}