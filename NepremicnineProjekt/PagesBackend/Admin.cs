using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

public static class AdminPage
{
    public static IResult Show()
    {
        return Results.Redirect("/admin.html");
    }
    
    public static async Task<IResult> Handle(HttpRequest request)
    {
       return Results.Redirect("/admin.html");
    }
}