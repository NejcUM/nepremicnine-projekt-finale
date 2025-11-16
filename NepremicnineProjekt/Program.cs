var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", () => Results.Redirect("/login.html"));

app.MapPost("/login", async (HttpRequest request) =>
{
    var form = await request.ReadFormAsync();
    var username = form["username"];
    var password = form["password"];
    
    if(username == "admin" && password == "1234")
        return Results.Text("<h1>Login successful!</h1>", "text/html");
    else
        return Results.Text("<h1>Invalid credentials!</h1>", "text/html");
});

app.Run("http://*:8080");


