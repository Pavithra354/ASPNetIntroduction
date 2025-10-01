using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Introduction.Filters
{
    //if employee lets say 


    // 9:00(9am) to 18:00(6pm)


    //header --> starthour
    //header --> endhour

    public class RequireWorkingHoursAttribute : Attribute, IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var headers = context.HttpContext.Request.Headers;

            if (!headers.ContainsKey("starthour") || !headers.ContainsKey("endhour"))
            {
                context.Result = new BadRequestObjectResult("Please cross-verify your starthour and endhour . Values are not in proper...");
                return;
            }

            ////Logic

            int startHour = int.Parse(headers["starthour"]);
            int endHour = int.Parse(headers["endhour"]);

            int currentHour = 17; //DateTime.Now.Hour; //19 hour

            if (currentHour < startHour || currentHour >= endHour)
            {
                context.Result = new BadRequestObjectResult("Allowed only between 9:00 am to 6:00Pm");
                return;
            }


            //throw new NotImplementedException();
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            var response = context.HttpContext.Response;

            response.Headers.Append("X-Working-Hours", "09:00 - 18:00");
            //throw new NotImplementedException();
        }


    }
}