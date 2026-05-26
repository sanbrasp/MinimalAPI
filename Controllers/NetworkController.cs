using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Services;

namespace MinimalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NetworkController : ControllerBase
{
    private readonly NetworkService _networkService;
    
    public NetworkController(NetworkService networkService)
    {
        _networkService = networkService;
    }


    [HttpGet("connected")]
    public IActionResult IsConnected([FromQuery] string from, [FromQuery] string to)
    {
        var result = _networkService.IsConnected(from, to);
        return Ok(new { from, to, connected = result });
    }

    [HttpGet("path")]
    public IActionResult FindPath([FromQuery] string from, [FromQuery] string to)
    {
        var path = _networkService.FindPath(from, to);

        if (path is null)
            return NotFound(new { message = $"No path found from {from} to {to}" });
        
        return Ok(new { from, to, path });
    }
}