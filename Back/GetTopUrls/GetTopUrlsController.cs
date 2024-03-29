namespace Uxl.Back.GetTopUrls;

[ApiController]
public class GetTopUrlsController(GetTopUrlsService service) : ControllerBase
{
    [HttpGet("top")]
    public async Task<IActionResult> GetTop()
    {
        var urls = await service.GetTop();

        return Ok(urls);
    }
}
