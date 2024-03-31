namespace Uxl.Back.GetTarget;

[ApiController]
public class GetTargetController(GetTargetService service) : ControllerBase
{
    [HttpGet("api/urls/{hash}")]
    public async Task<IActionResult> GetTarget([FromRoute] string hash)
    {
        var target = await service.Get(hash);

        return Ok(target);
    }
}
