using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Text.Json;
using NepremicnineProjekt;
public static class NewPostPage
{
    public static IResult Show()
    {
        return Results.Redirect("/new-post");
    }
    
    public static async Task<IResult> Handle(HttpRequest request)
    {
        var form = await request.ReadFormAsync();
        var title = form["title"];
        var description = form["description"];
        var imageUrl = form["imageUrl"];
        var size = form["size"];
        var price = form["price"];
        
        var (success, _message) = Program.db_manager.AddPost(new Post(
            title, description, imageUrl, size,"", price
        ));
        
        if (!success)
            return Results.Json(new { success = false, message = _message });
        
        return Results.Json(new { success = true});
    }
}