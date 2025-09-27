var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Enable CORS for Angular (http://localhost:4200)
builder.Services.AddCors(cors =>
{
    cors.AddPolicy("AllowLocalhost4200", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use CORS
app.UseCors("AllowLocalhost4200");

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Swagger available at root
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
