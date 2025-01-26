using Domain.Entities.Global;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/proof-of-life")]
    [ApiController]
    public class ProofOfLifeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult PoL() => StatusCode(200, Result.Ok("Prueba de vida"));
    }
}
