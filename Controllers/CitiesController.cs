using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Services;

namespace MinimalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly CityService _cityService;
    
    public CitiesController(CityService cityService)
    {
        _cityService = cityService;
    }


    [HttpGet("cheapest")]
    public IActionResult FindCheapest([FromQuery] string from, [FromQuery] string to)
    {
        var result = _cityService.FindCheapest(from, to);

        if (result is null)
            return NotFound(new { message = $"No route found from {from} to {to}" });

        return Ok(new { from, to, cost = result.Value.cost, path = result.Value.path });
    }
}