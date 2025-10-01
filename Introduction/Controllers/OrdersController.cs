using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Introduction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {

        [HttpGet("badrequest")]
        public IActionResult BadRequestExample()
        {
            throw new ValidationException("Amount must be positive."); // → 400
        }


        [HttpGet("unauthorized")]
        public IActionResult UnauthorizedExample()
        {
            throw new UnauthorizedAccessException("Token invalid."); // → 401
        }


        [HttpGet("notfound")]
        public IActionResult NotFoundExample()
        {
            throw new KeyNotFoundException("Order not found."); // → 404
        }

    }
}