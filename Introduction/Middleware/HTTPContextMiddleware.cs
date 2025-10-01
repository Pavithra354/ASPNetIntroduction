namespace Introduction.Middleware
{
    //Middleware is nothing but act as gate keeper of your every request



    public class HTTPContextMiddleware
    {
        //"RequestDelete is a kind of a pointer whiech is useful to give your context to the controller

        RequestDelegate _next;
        public HTTPContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)   //Gatekeeper
        {

            //var context = HttpContext;

            //var httpContextHeaders = context.Request.Headers;
            //var httpContextBody    = context.Request.Body;
            //var httpContextPath    = context.Request.Path;
            //var httpContextQueryString = context.Request.QueryString;

            //Console.WriteLine("==========Request headers =================");
            //Console.WriteLine($"httpContextHeaders : {httpContextHeaders}");
            //Console.WriteLine($"httpContextBody    : {httpContextHeaders}");
            //Console.WriteLine($"httpContextPath    : {httpContextPath}");
            //Console.WriteLine($"httpContextQueryString : {httpContextQueryString}");
            //Console.WriteLine("=====================================");



            //POST https://localhost:7115/api/HttpContextDemo/ShowContext/1 HTTP/1.1 application/json 200 OK
            //https://localhost:7115/api/HttpContextDemo/ShowContext/1

            //https://localhost:7115/api/Emmploee/ShowContext/1
            //context is nothtin but request

            //Console.WriteLine("==========Response headers starts===========");
            //context.Response.Headers["X-demo-Response"] = "This came from server";
            //context.Response.Headers["X-demo-statusCode"] = "Successfull";
            //Console.WriteLine("===========Response headers Eds======");


            Console.WriteLine("==========Response headers starts===========");
            //context.Response.Headers["X-demo-Response"] = "This came from server";
            //context.Response.Headers["X-demo-statusCode"] = "Successfull";
            context.Response.Headers["UserName"] = "Madan";
            context.Response.Headers["Password"] = "Madan!1233";
            context.Response.Headers["Mail"] = "madan.patakota@gmail.com";
            context.Response.Headers["PhoneNumber"] = "76555555";
            context.Response.Headers["PostolCode"] = "34333333";
            context.Response.Headers["HomeAddress"] = "Proddatrue";

            Console.WriteLine("===========Response headers Eds======");


            await _next(context);     //Forware your request by asp.netcore compiler


            //context.Response.OnStarting(() =>
            //{
            //    Console.WriteLine("==========Response headers starts===========");
            //    context.Response.Headers["X-demo-Response"] = "This came from server";
            //    context.Response.Headers["X-demo-statusCode"] = "Successfull";
            //    Console.WriteLine("===========Response headers Eds======");

            //    return Task.CompletedTask;
            //});
            //context.Response.Headers.Append("X-demo-Response", "This came from server");
            //context.Response.Headers.Append("X-demo-statusCode", "Successfull");



            //

        }
    }
}