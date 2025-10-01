using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Introduction
{
    /// <summary>
    /// Logs key request information for every HTTP request.
    /// </summary>
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Capture details from the current request
            var headers = context.Request.Headers;
            var path = context.Request.Path;
            var queryString = context.Request.QueryString;

            Console.WriteLine("========== Request Info ==========");
            Console.WriteLine($"Headers      : {string.Join("; ", headers)}");
            Console.WriteLine($"Path         : {path}");
            Console.WriteLine($"QueryString  : {queryString}");
            Console.WriteLine("==================================");

            // Forward the request to the next middleware/component
            await _next(context);
        }
    }
}
