using Microsoft.AspNetCore.Mvc;

namespace B2BApprovals.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController:ControllerBase
    {
        [HttpGet]
        public IActionResult Health()
        {
            return Ok(new { status = "ok" });
        }
    }
}
