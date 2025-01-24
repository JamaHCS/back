using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/proof-of-life")]
    [ApiController]
    public class ProofOfLifeController : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> PoL() => StatusCode(200, "Ok");

    }
}
