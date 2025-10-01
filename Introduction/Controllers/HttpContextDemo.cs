using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpContextDemoController : ControllerBase
    {
        /// <summary>
        /// Accepts data from route, query, body, and header to demonstrate HttpContext usage.
        /// POST https://localhost:7065/api/HttpContextDemo/ShowContext/1?age=20&location=hye
        /// </summary>
        [HttpPost("ShowContext/{id}")]
        public IActionResult ShowContext(
            int id,                                         // Route parameter
            [FromQuery] int age,                            // Query parameter
            [FromQuery] string location,                     // Query parameter
            [FromBody] UserDto user,                         // Body (JSON)
            [FromHeader(Name = "Custom-Header")] string customHeader // Custom header
        )
        {
            // Example of reading HttpContext data
            HttpContext.Response.Headers.Append("X-Demo-Response", "This came from server");
            HttpContext.Response.Headers.Append("X-Demo-StatusCode", "Successful");

            return Ok(new
            {
                RouterId = id,
                QueryAge = age,
                QueryLocation = location,
                UserFromBody = user,
                CustomHeader = customHeader,
                Message = "✅ Data received successfully from client"
            });
        }
    }

    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
