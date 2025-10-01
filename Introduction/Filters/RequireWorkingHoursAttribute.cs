using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Introduction.Filters
{

    // i want to make this class as action filter. so steps
    public class RequiredGmailAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //i need the email

            var email = context.HttpContext.Request.Headers["email"].ToString(); //madan@gmail.com

            if (string.IsNullOrEmpty(email) || !email.EndsWith("@gmail.com"))
            {
                context.Result = new BadRequestObjectResult("Only @gmail.com emails are accepted");
                return;
            }
            //throw new NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var response = context.HttpContext.Response;

            response.Headers.Append("X-Checked-By", "Requreied Gmail Attribute Decorator");
            response.Headers.Append("X-Processed-AT", DateTime.UtcNow.ToString());

            //throw new NotImplementedException();
        }
    }
}