using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Text.Json;

public static class RegisterPage
{
    public static IResult Show()
    {
        return Results.Redirect("/register.html");
    }
    
    public static async Task<IResult> Handle(HttpRequest request)
    {
        var users = new DBManager().GetUsers();
        var form = await request.ReadFormAsync();
        var username = form["username"];
        var email = form["email"];
        var password = form["password"];
        var passwordAgain = form["password-again"];

        if (password != passwordAgain)
        {
            return Results.Text("Passwords do not match");
        }

        if(users.Any(u => u.Username == username))
            return Results.Text("Username already exists");
        
        if(users.Any(u => u.Email == email))
            return Results.Text("Email already registered");

        users.Add(
            new User
            {
                Username = username, 
                Email = email,
                Password = password
            });
        
        new DBManager().SetUsers(users);

        return Results.Redirect("/home.html");
    }
}