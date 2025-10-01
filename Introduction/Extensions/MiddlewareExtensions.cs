using Introduction.Middleware;
using Microsoft.AspNetCore.Builder;        // ✅ Needed for IApplicationBuilder
using Microsoft.AspNetCore.Authentication; // Only required if your middleware uses it

namespace Introduction.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpContextDemo(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HTTPContextMiddleware>();
        }

        public static IApplicationBuilder UseLoggingContextDemo(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }

        public static IApplicationBuilder UseAuthenticationDemo(this IApplicationBuilder builder) // ✅ spelling fixed
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
