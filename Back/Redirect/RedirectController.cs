namespace Uxl.Back.Redirect;

[ApiController]
public class RedirectController(RedirectService service) : ControllerBase
{
    [HttpGet("{hash}")]
    public async Task<IActionResult> RedirectTo([FromRoute] string hash)
    {
        var target = await service.GetTarget(hash);

        if (target == "")
            return NotFound();

        return Redirect(target);
    }
}
