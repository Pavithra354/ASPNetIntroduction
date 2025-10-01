using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet("conflict")]
        public IActionResult ConflictExample()
        {
            ////
            ///
            /////


            ////

            throw new Exception("User already exists, conflict error."); // will be → 500 (since no ConflictException)
        }

        [HttpGet("forbidden")]
        public IActionResult ForbiddenExample()
        {
            throw new Exception("You are not allowed to access this user."); // → 500 (no ForbiddenException handling now)
        }

        [HttpGet("internalerror")]
        public IActionResult InternalServerErrorExample()
        {
            throw new Exception("Unexpected crash in Users API."); // → 500
        }
    }
}