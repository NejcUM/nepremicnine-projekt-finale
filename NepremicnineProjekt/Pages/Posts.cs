using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using NepremicnineProjekt;

public static class PostsPage
{
    public static IResult Show()
    {
        var htmlTemplate = File.ReadAllText("wwwroot/posts.html");
        var cardsHtml = "";
        foreach (var post in Program.db_manager.GetPosts())
        {
            cardsHtml += $@"
            <div class='post_card'>
                <img src='{post.ImageUrl}'>
                <div class='price_banner' style='background:{post.Color}'>
                    <h2>{post.Price} &euro;</h2>
                </div>
                <div class='banner' style='background:{post.Color}'>
                    <h2>{post.Title}</h2>
                    <h2 style='display:none'>{post.Size}</h2>
                </div>
            </div>";
        }
        
        var finalHtml = htmlTemplate.Replace("<!--CARDS_GO_HERE-->", cardsHtml);
        return Results.Content(finalHtml, "text/html");
    }
    
    public static async Task<IResult> Handle(HttpRequest request)
    {
        return Results.Redirect("/posts.html");
    }
}