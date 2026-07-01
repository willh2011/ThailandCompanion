using ThailandCompanion.Api.DTOs;
using ThailandCompanion.Api.Entities;
using ThailandCompanion.Api.Interfaces;
using ThailandCompanion.Api.Repositories.Interfaces;
using ThailandCompanion.Api.Services.Common;

namespace ThailandCompanion.Api.Services;

public class ProvinceService
    : BaseReadService<ProvinceEntity, ProvinceDto>, IProvinceService
{
    public ProvinceService(IRepository<ProvinceEntity> repository)
        : base(repository)
    {
    }
}