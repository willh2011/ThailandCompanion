using Microsoft.EntityFrameworkCore;
using ThailandCompanion.Api.Data;
using ThailandCompanion.Api.DTOs;
using ThailandCompanion.Api.Interfaces;
using Mapster;

namespace ThailandCompanion.Api.Services;

public class DistrictService : IDistrictService
{
    private readonly ApplicationDbContext _context;

    public DistrictService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<DistrictDto> GetAll()
    {
        return _context.Districts
            .Include(d => d.Province)
            .OrderBy(d => d.NameEn)
            .ProjectToType<DistrictDto>()
            .ToList();
    }

    public List<DistrictDto> GetByProvinceId(int provinceId)
    {
        return _context.Districts
            .Include(d => d.Province)
            .Where(d => d.ProvinceId == provinceId)
            .OrderBy(d => d.NameEn)
            .ProjectToType<DistrictDto>()
            .ToList();
    }

    public DistrictDto? GetById(int id)
    {
        return _context.Districts
            .Include(d => d.Province)
            .Where(d => d.Id == id)
            .ProjectToType<DistrictDto>()
            .FirstOrDefault();
    }
}