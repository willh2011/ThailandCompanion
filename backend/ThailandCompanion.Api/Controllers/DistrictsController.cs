using Microsoft.AspNetCore.Mvc;
using ThailandCompanion.Api.Interfaces;

namespace ThailandCompanion.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DistrictsController : ControllerBase
{
    private readonly IDistrictService _districtService;

    public DistrictsController(IDistrictService districtService)
    {
        _districtService = districtService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_districtService.GetAll());
    }

    [HttpGet("by-province/{provinceId:int}")]
    public IActionResult GetByProvinceId(int provinceId)
    {
        return Ok(_districtService.GetByProvinceId(provinceId));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var district = _districtService.GetById(id);

        if (district is null)
        {
            return NotFound();
        }

        return Ok(district);
    }
}