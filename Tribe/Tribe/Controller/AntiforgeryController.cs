using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class AntiforgeryController : ControllerBase
{
    private readonly IAntiforgery _antiforgery;

    public AntiforgeryController(IAntiforgery antiforgery)
    {
        _antiforgery = antiforgery;
    }

    [HttpGet("GetToken")]
    public IActionResult GetToken()
    {
        var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
        return Ok(tokens.RequestToken); // Nur das Token senden
    }
}