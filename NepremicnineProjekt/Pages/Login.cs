using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using NepremicnineProjekt;

public static class LoginPage
{
    public static IResult Show()
    {
        return Results.Redirect("/login.html");
    }
    
    public static async Task<IResult> Handle(HttpRequest request)
    {
        var form = await request.ReadFormAsync();
        var username = form["username"];
        var password = form["password"];
        
        if (Program.db_manager.LoginCheck(username, password))
        {
           return Results.Redirect("/home.html");
        }
        else
        {
           return Results.Redirect("/login.html");
        }
    }
    
}