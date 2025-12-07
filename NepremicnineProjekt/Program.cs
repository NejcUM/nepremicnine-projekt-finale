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

        app.MapGet("/admin", AdminPage.Show);
        app.MapPost("/admin", AdminPage.Handle);
        
        app.MapGet("/home", HomePage.Show);
        app.MapPost("/home", HomePage.Handle);
        
        app.MapGet("/index", HomePage.Show);
        app.MapPost("/index", HomePage.Handle);
        
        app.MapGet("/posts", PostsPage.Show);
        app.MapPost("/posts", PostsPage.Handle);
        
        app.MapGet("/new-post", NewPostPage.Show);
        app.MapPost("/new-post", NewPostPage.Handle);
        
       db_manager.AddPost(new Post(
            "Nova hiša",
            "Na prodaji zelo lepa nova bela hiša",
            "https://www.krka-nepremicnine.si/wp-content/uploads/2025/06/IMG_4639.jpg",
            "150",
            "#ec5929",
            "180 000"
           ));
        
           db_manager.AddPost(new Post(
            "Stara hiša",
            "Na prodaji stara hiša",
            "https://img.nepremicnine.net/slonep_oglasi2/18630086.jpg",
            "110",
            "#5f3119",
            "99 000"
        ));
        
        db_manager.AddPost(new Post(
            "1 sobno stanovanje",
            "NOVOGRADNJA - OTOK KRK !! Mesto Krk, na dobri lokaciji 500 m od morja.",
            "https://img.nepremicnine.net/slonep_oglasi2/16903995.jpg",
            "64",
            "#58647c",
            "362 500"
        ));
        
        db_manager.AddPost(new Post(
            "1,5 sobno stanovanje",
            "",
            "https://img.nepremicnine.net/slonep_oglasi2/16467713.jpg",
            "85",
            "#63a1d0",
            "159 000"
        ));
        
        db_manager.AddPost(new Post(
            "Vrstna hiša v šentvidu",
            "V mirnem in zelenem okolju v Šentvidu prodamo sodobno zasnovano vrstno hišo, ki se nahaja v urejeni soseski osmih vrstnih hiš.",
            "https://www.mestonepremicnin.si/uploads/novogradnja/brez-31__ujyd1wVE-1500x972_1763560328.jpg",
            "192",
            "#82874f",
            "682 000"
        ));
        
        
        
        

        app.Run("http://*:8080");
    }
    
}