using AliexpressItemsParser.Interfaces;
using AliexpressItemsParser.Out;
using Microsoft.AspNetCore.Mvc;

namespace AliexpressItemsParser.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AliController : ControllerBase
{
    private readonly ILogger<AliController> _logger;
    private readonly IAliParser _parser;

    public AliController(ILogger<AliController> logger, IAliParser parser)
    {
        _logger = logger;
        _parser = parser;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string id)
    {
        AliexpressItem? data = await _parser.Parse(id);
        return Ok(data);
    }
}