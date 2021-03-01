using Microsoft.AspNetCore.Mvc;

namespace Task_1.Controllers
{
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<string> Check()
        {
            return "Made by Mulish Vadym\nTask 1 Prime Numbers Web Service";
        }
    }
}
