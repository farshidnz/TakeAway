using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TakeAway.Controllers
{
    public class HealthcheckController : ControllerBase
    {

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok();
        }

        [HttpGet("healthcheck")]
        public IActionResult Healthcheck()
        {
            return Ok();
        }
    }
}
