
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", LoginPage.Show);
app.MapGet("/login", LoginPage.Show);
app.MapPost("/login", LoginPage.Handle);

app.MapGet("/register", RegisterPage.Show);
app.MapPost("/register", RegisterPage.Handle);

app.MapGet("/admin", AdminPage.Show);
app.MapPost("/admin", AdminPage.Handle);


app.Run("http://*:8080");


