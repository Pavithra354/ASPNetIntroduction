using Introduction.Services;

namespace Introduction.Middleware
{
    public class CustomAuthenticationMiddleware
    {



        RequestDelegate _next;
        IAuthenticationService _authetnicationService;
        public CustomAuthenticationMiddleware(RequestDelegate next, IAuthenticationService authenticationService)
        {

            _next = next;
            _authetnicationService = authenticationService;
        }

        public async Task InvokeAsync(HttpContext context)   //Gatekeeper
        {

            if (context.Request.Path.ToString().Contains("Login"))
            {
                await _next(context);  //respetive action
                return;
            }

            var authizationToken = context.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(authizationToken))
            {
                string status = _authetnicationService.ValidateToken(authizationToken);

                if (status == "Valid")
                {
                    context.Response.Headers["MyTokenisValidOrnot"] = status;
                    await _next(context); //respetive action
                }
                else
                {
                    context.Response.Headers["MyTokenisValidOrnot"] = status;
                    return;
                }
            }
            else
            {
                context.Response.Headers["MyTokenisValidOrnot"] = "Plese give your token";
                return;
            }

        }
    }
}