using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Text.Json;
using NepremicnineProjekt;
public static class PostPage
{
    public static IResult Show()
    {
        return Results.Redirect("/post.html");
    }
    
    public static async Task<IResult> Handle(HttpRequest request)
    {
        return Results.Redirect("/post.html");
        
    }
    
    public static async Task<IResult> GetPost(HttpRequest request)
    {
        if (!int.TryParse(request.Query["id"], out int id))
            return Results.BadRequest(new { error = "Invalid or missing id" });
        
        var post = Program.db_manager.GetPost(id);

        if (post == null)
            return Results.NotFound(new { error = "Post not found" });
        
        return Results.Json(post, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        });
    }
}