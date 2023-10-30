using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Home;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> Home()
    {

        return Task.FromResult<IActionResult>(Ok("API is running"));
    }
}