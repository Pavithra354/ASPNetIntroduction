using Introduction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // use [controller] token, not {controller}
    public class BankTransactionsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public BankTransactionsController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // POST: https://localhost:7065/api/BankTransactions/GetCustomerTransactions
        [HttpPost("GetCustomerTransactions")]
        public IActionResult GetCustomerTransactions(
            [FromHeader(Name = "Authorization")] string token)
        {
            var message = "Customers can see this transaction";
            return Ok(new { Message = message });
        }

        // Example stubs for other actions
        /*
        [HttpPost("GetCustomerDepositHistory")]
        public IActionResult GetCustomerDepositHistory([FromBody] CustomerDTO customerDto)
        {
            
        }

        [HttpPost("GetCustomerCreditCardTransaction")]
        public IActionResult GetCustomerCreditCardTransaction([FromBody] CustomerDTO customerDto)
        {
            
        }
        */
    }
}
