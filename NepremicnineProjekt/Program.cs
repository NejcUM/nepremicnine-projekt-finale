var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

var app = builder.Build();

// Simple middleware
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"ERROR: {ex}");
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync($"Error: {ex.Message}");
    }
});

// Simple route
app.MapGet("/", () => "Hello World from Azure App Service!");

app.MapGet("/health", () => "Healthy");

app.Run("http://*:8080");
