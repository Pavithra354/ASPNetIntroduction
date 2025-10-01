using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Introduction
{
    /// <summary>
    /// Logs request information and adds custom response headers.
    /// Acts as a gatekeeper for every HTTP request.
    /// </summary>
    public class HTTPContextMiddleware
    {
        private readonly RequestDelegate _next;

        public HTTPContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // ----- Request Logging -----
            Console.WriteLine("========== Request Info ==========");
            Console.WriteLine($"Headers      : {string.Join("; ", context.Request.Headers)}");
            Console.WriteLine($"Path         : {context.Request.Path}");
            Console.WriteLine($"QueryString  : {context.Request.QueryString}");
            Console.WriteLine("==================================");

            // Forward the request to the next component in the pipeline
            await _next(context);

            // ----- Response Headers -----
            context.Response.OnStarting(() =>
            {
                // Add custom headers to every response
                context.Response.Headers["X-Demo-Response"] = "This came from server";
                context.Response.Headers["X-Demo-StatusCode"] = "Successful";

                Console.WriteLine("========== Response Info ==========");
                Console.WriteLine("Custom headers added to response");
                Console.WriteLine("===================================");
                return Task.CompletedTask;
            });
        }
    }
}
