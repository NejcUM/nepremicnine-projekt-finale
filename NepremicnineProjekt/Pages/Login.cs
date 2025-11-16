using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

public static class LoginPage
{
    // GET /login
    public static IResult ShowLogin()
    {
        return Results.Redirect("/login.html");
    }

    // POST /login
    public static async Task<IResult> HandleLogin(HttpRequest request)
    {
        var form = await request.ReadFormAsync();
        var username = form["username"];
        var password = form["password"];

        if (username == "admin" && password == "1234")
            return Results.Text("<h1>Login successful!</h1>", "text/html");
        else
            return Results.Text("<h1>Invalid credentials!</h1>", "text/html");
    }
}