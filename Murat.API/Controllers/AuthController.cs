using Microsoft.AspNetCore.Mvc;

namespace Murat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login()
        {
            return Created("", new JwtTokenGenerator().GeneratorToken());
        }

    }
}
