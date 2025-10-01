using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ExBasicsWithoutTryCatchController : ControllerBase
    {
        [HttpGet("dividebyzero")]
        public IActionResult DivideByZeroExample()
        {
            int x = 10, y = 0;
            int result = x / y; // ❌ DivideByZeroException
            return Ok(result);
        }



        [HttpGet("dividebyzeroWithTryCatchWithDivideByZeroException")]
        public IActionResult dividebyzeroWithTryCatchWithDivideByZeroException()
        {
            //try
            //{
            int x = 10, y = 0;
            int result = x / y; // ❌ DivideByZeroException
            return Ok(result);
            //}
            //catch(DivideByZeroException ex)
            //{
            //    return BadRequest($"Math error: {ex.Message}");
            //}
        }


        [HttpGet("dividebyzeroWithTryCatchWithException")]
        public IActionResult dividebyzeroWithTryCatchWithException()
        {
            //try
            //{
            int x = 10, y = 0;
            int result = x / y; // ❌ DivideByZeroException
            return Ok(result);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest($"Math error: {ex.Message}");
            //}
        }



        [HttpGet("ThrowDivideByZeroException")]
        public IActionResult ThrowDivideByZeroException()
        {
            //try
            //{
            //Explicit way i am throwint excetion...
            throw new DivideByZeroException("Please cross-verify your 2 values...");
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest($"Math error: {ex.Message}");
            //}
        }


        [HttpGet("ThrowForbiddenException")]
        public IActionResult ThrowForbiddenException()
        {
            //try
            //{
            //Explicit way i am throwint excetion...
            throw new ForbiddenException("Please cross-verify your 2 values...");
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest($"Math error: {ex.Message}");
            //}
        }


        [HttpGet("ThrowConflictException")]
        public IActionResult ThrowConflictException()
        {
            //try
            //{
            //Explicit way i am throwint excetion...
            throw new ConflictException("Please cross-verify your 2 values...");
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest($"Math error: {ex.Message}");
            //}
        }

        //[HttpGet("ThrowForbiddenException")]
        //public IActionResult ThrowForbiddenException()
        //{
        //    try
        //    {
        //        //Explicit way i am throwint excetion...
        //        throw new ForbiddenException("Please cross-verify your 2 values...");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Math error: {ex.Message}");
        //    }
        //}


    }
}