using Microsoft.AspNetCore.Mvc;
using TakeAway.Libs.Contracts;
using TakeAway.Libs.Services;

namespace TakeAway.Controllers
{
    [Produces("application/json")]
    [Route("ProvisionTakeAway")]
    public class ProvisionTakeAwayController : Controller
    {
        private readonly IProvisionService _service;

        public ProvisionTakeAwayController(IProvisionService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public AcceptedResult ProvisionTakeAway([FromBody] ProvisionTakeAwayRequest request)
        {
            _service.SendPrivisionRequestion(request);
            return Accepted();
        }
    }
}