using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using NepremicnineProjekt;

public static class HomePage
{
    public static IResult Show()
    {
        return Results.Redirect("/home.html");
    }
    
    public static async Task<IResult> Handle(HttpRequest request)
    {
        return Results.Redirect("/home.html");
    }
}