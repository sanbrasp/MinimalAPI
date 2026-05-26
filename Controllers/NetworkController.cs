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
}