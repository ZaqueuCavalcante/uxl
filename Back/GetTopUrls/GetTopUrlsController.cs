namespace Uxl.Back.GetTopUrls;

[ApiController]
public class GetTopUrlsController(GetTopUrlsService service) : ControllerBase
{
    [HttpGet("api/top-urls")]
    public async Task<IActionResult> GetTop()
    {
        var urls = await service.GetTop();

        return Ok(urls);
    }
}
