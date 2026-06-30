using ThailandCompanion.Api.Entities.Common;

namespace ThailandCompanion.Api.Entities;

public class DistrictEntity : BaseEntity
{
    public int ProvinceId { get; set; }

    public ProvinceEntity Province { get; set; } = null!;

    public string NameEn { get; set; } = string.Empty;

    public string NameTh { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}