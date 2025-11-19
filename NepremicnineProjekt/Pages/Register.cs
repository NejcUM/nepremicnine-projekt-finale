using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Text.Json;
using NepremicnineProjekt;
public static class RegisterPage
{
    public static IResult Show()
    {
        return Results.Redirect("/register.html");
    }
    
    public static async Task<IResult> Handle(HttpRequest request)
    {
        var form = await request.ReadFormAsync();
        var username = form["username"];
        var email = form["email"];
        var password = form["password"];
        var passwordAgain = form["password-again"];

        if (password != passwordAgain)
        {
            return Results.Text("Passwords do not match");
        }
        
        var (success, message) = Program.db_manager.AddUser(new User
        {
            Username = username,
            Email = email,
            Password = password
        });
        
        if (!success)
            return Results.Redirect(message);
        
        return Results.Redirect("/home.html");
    }
}