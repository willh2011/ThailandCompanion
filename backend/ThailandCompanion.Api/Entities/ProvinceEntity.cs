using System.Security.Cryptography.X509Certificates;
using Thailandcompanion.Api.Entities.Common;

namespace ThailandCompanion.Api.Entities;

public class ProvinceEntity : BaseEntity
{
    public string NameEn { get; set; } = string.Empty;

    public string Nameth { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }
}
