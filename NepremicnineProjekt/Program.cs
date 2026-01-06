namespace NepremicnineProjekt;

public class Program
{
    public static DBManager db_manager = new DBManager();
    public static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.UseStaticFiles();

        app.MapGet("/", LoginPage.Show);
        app.MapGet("/login", LoginPage.Show);
        app.MapPost("/login", LoginPage.Handle);

        app.MapGet("/register", RegisterPage.Show);
        app.MapPost("/register", RegisterPage.Handle);
        
        app.MapGet("/home", HomePage.Show);
        app.MapPost("/home", HomePage.Handle);
        
        app.MapGet("/index", HomePage.Show);
        app.MapPost("/index", HomePage.Handle);
        
        app.MapGet("/posts", PostsPage.Show);
        app.MapPost("/posts", PostsPage.Handle);
        
        app.MapGet("/new-post", NewPostPage.Show);
        app.MapPost("/new-post", NewPostPage.Handle);
        
        app.MapGet("/map", MapPage.Show);
        app.MapPost("/map", MapPage.Handle);
        
        app.MapGet("/post", PostPage.GetPost);
        app.MapPost("/post", PostPage.Handle);
        
        app.MapDelete("/delete-post", (HttpRequest request) =>
        {
            if(!int.TryParse(request.Query["id"], out int id))
                return Results.BadRequest();

            bool deleted = db_manager.DeletePost(id);
            return deleted ? Results.Ok() : Results.NotFound();
        });
        
        app.Run("http://*:8080");
    }
    
}