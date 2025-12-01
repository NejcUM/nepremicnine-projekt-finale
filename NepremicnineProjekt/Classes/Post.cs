
public class Post
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Size { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Color { get; set; }
    
    public Post(string title, string description, string imageUrl, string size, string color, string price)
    {
        Title = title;
        Description = description;
        ImageUrl = imageUrl;
        Size = size;
        Color = color;
        Price = price;
    }
   
}