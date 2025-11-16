var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/login", LoginPage.ShowLogin);
app.MapPost("/login", LoginPage.HandleLogin);

app.Run("http://*:8080");


