using Mapster;
using ThailandCompanion.Api.DTOs;
using ThailandCompanion.Api.Entities;
using ThailandCompanion.Api.Interfaces;
using ThailandCompanion.Api.Repositories.Interfaces;
using ThailandCompanion.Api.Services.Common;

namespace ThailandCompanion.Api.Services;

public class DistrictService
    : BaseReadService<DistrictEntity, DistrictDto>, IDistrictService
{
    public DistrictService(IRepository<DistrictEntity> repository)
        : base(repository)
    {
    }

    public List<DistrictDto> GetByProvinceId(int provinceId)
    {
        return Repository.Query()
            .Where(d => d.ProvinceId == provinceId)
            .OrderBy(d => d.NameEn)
            .ProjectToType<DistrictDto>()
            .ToList();
    }
}