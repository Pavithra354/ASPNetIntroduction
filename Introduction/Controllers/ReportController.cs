using Introduction.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    [RequireDomainEmailAttribute]
    public class ReportsController : ControllerBase
    {
        [HttpGet("daily")]
        public IActionResult GetDaily([FromHeader(Name = "email")] string email)
        {
            return Ok(new { Message = "Daily report generated.", Email = email });
        }

        [HttpGet("monthly")]
        public IActionResult GetMonthly([FromHeader(Name = "email")] string email)
        {
            return Ok(new { Message = "Monthly report generated.", Email = email });
        }
    }
}