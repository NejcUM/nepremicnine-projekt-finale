using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

public static class LoginPage
{
    public static IResult Show()
    {
        return Results.Redirect("/login.html");
    }
    
    public static async Task<IResult> Handle(HttpRequest request)
    {
        var users = new DBManager().GetUsers();
        var form = await request.ReadFormAsync();
        var username = form["username"];
        var password = form["password"];

        var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
           return Results.Redirect("/home.html");
        }
        else
        {
           return Results.Redirect("/login.html");
        }
    }
}