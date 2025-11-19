using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using NepremicnineProjekt;
public static class MapPage
{
    public static IResult Show()
    {
        return Results.Redirect("/map.html");
    }
    
    public static async Task<IResult> Handle(HttpRequest request)
    {
        return Results.Redirect("/map.html");
        
    }
}