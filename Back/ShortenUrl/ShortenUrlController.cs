namespace Uxl.Back.ShortenUrl;

[ApiController]
public class ShortenUrlController(ShortenUrlService service) : ControllerBase
{
    [HttpPost("urls")]
    public async Task<IActionResult> Shorten([FromBody] ShortenUrlIn data)
    {
        var url = await service.Shorten(data);

        return Ok(url);
    }
}
