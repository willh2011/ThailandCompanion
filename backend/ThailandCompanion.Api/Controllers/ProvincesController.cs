using Microsoft.AspNetCore.Mvc;
using ThailandCompanion.Api.Interfaces;

namespace ThailandCompanion.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProvincesController : ControllerBase
{
    private readonly IProvinceService _provinceService;

    public ProvincesController(IProvinceService provinceService)
    {
        _provinceService = provinceService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_provinceService.GetAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var province = _provinceService.GetById(id);

        if (province is null)
        {
            return NotFound();
        }

        return Ok(province);
    }

}



