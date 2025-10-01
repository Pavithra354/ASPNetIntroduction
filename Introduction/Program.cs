using Introduction;
using Introduction.Extensions;
using Introduction.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();




builder.Services.AddCors((cors) =>
{
    cors.AddPolicy("AllowLocalhost4200", policy =>
    {
        policy.
        WithOrigins("http://localhost:4200").
        AllowAnyHeader().
        AllowAnyMethod();
    });
});

//http://localhost:4200

//https://localhost:7115/api/Employees/GetEmpName

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseCors("AllowLocalhost4200");


//'afadafsdfadfasdsfdasdasdasd';


//Multiple middlewares in future
//app.UseMiddleware<HTTPContextMiddleware>();
//logging
//excption
//autthenication
//app.UseHttpContextDemo();
//app.UseLoggingContextDemo();


//app.UseAuthentictionDemo();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();