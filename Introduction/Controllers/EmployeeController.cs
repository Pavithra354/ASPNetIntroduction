using Introduction.Filters;
using Microsoft.AspNetCore.Mvc;


namespace Introduction.Controllers
{




    [ApiController]
    [Route("api/[controller]")]

    public class EmployeeController : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        //[]  ---> Attribute


        //@input , output , component , pipe , directive , module

        //send the request   @gmail.com    @hotmail.com
        //extra behviour to the action

        [RequiredGmailAttribute]
        [RequireWorkingHoursAttribute]
        [HttpGet("validate-employee")]
        public IActionResult ValidateEmployee([FromHeader(Name = "email")] string email)
        {
            var Message = "Employee validated with the proper email. i.e. GMAIL and working hours also good...";
            return Ok(new { Message = Message, Email = email });
        }




        // [RequiredGmailAttribute]
        //extra behviour to the action
        [HttpGet("validate-customer")]
        public IActionResult ValidateCustomer([FromHeader(Name = "email")] string email)
        {
            var message = "Customer validated (gmail check only).";
            return Ok(new { Message = message, Email = email });
        }



    }
}