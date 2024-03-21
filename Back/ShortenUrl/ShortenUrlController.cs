using Microsoft.AspNetCore.RateLimiting;

namespace Uxl.Back.ShortenUrl;

[ApiController]
[EnableRateLimiting("Small")]
public class ShortenUrlController(ShortenUrlService service) : ControllerBase
{
    [HttpPost("urls")]
    public async Task<IActionResult> Shorten([FromBody] ShortenUrlIn data)
    {
        var url = await service.Shorten(data);

        return Ok(url);
    }
}
