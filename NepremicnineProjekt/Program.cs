var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "gg2ez");
app.MapGet("/health", () => "Healthy");

app.Run("http://*:8080");
